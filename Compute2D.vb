
Imports System.Data.SqlClient
Imports System.Linq
Public Class Compute2D

    Dim ind As Integer
    Dim dt As Double 'time interval (s)
    Dim tmax As Double 'end time (s) 72h
    Dim T_sauv As Double
    Dim directory As String

    Dim H_int As Double  'initial relative humidity in the material
    Dim Tc As Double 'initial temperature in the material
    Dim Tk As Double  '(K)
    Dim rho_v As Double = 1 'density of vapor (kg/m3)
    Dim rho_l As Double = 1000 'density of liquid (kg/m3)
    Dim yita_l As Double = 0.00089 'viscosity of water (kg/m.s=pa.s)
    Dim pg As Double = 101325 'atmosphere pressure(pa)
    Dim D0 As Double
    Dim alpha_0 As Double
    Dim Hc As Double
    Dim type As Integer

    Public LgLim As Integer = 40
    Public pPH As Double = 12.6
    Public mPh As Double = 6.5
    Public RoW As Integer = 1000        'kg/m3
    Public R As Double = 8.3145        'J/mol.K

    'recuperer depuis database
    Dim C As Double
    Dim W_C_ratio As Double  'ratio E/C (kg/m3)
    Dim Water_tot As Double  'densite eau (kg/m3)
    Dim wsat As Double 'teneur en eau sature (kg/m3)
    Dim phi As Double  'porosity (-)
    Dim w As Double  'indicator for isotherm curve, judge if we choose to use desorption (w = 0) or adsorption curve (w = 1) 
    Dim alpha As Double  'material initial hydration degree (-)
    Dim day As Double  'age du beton
    Dim rho_c As Double  'density of concrete (kg/m3)
    Dim KK As Double 'material's intrinsic permeability (m2)
    Dim m As Double 'relative permeability parameter
    Dim pc_0 As Double 'capillary pressure parameter
    Dim beta As Double 'capillary pressure parameter
    'Dim H_old() As Double
    'Dim H_new() As Double
    'Dim S_old() As Double
    'Dim S_new() As Double
    'Dim w_old() As Double
    'Dim w_new() As Double
    Dim St As Double = 0.2 'capillary pressure residual saturation
    Dim dH_avg As Double
    Dim dw_avg As Double
    Dim dS_avg As Double

    Dim OutputFile As OutputFile2D


    Public Function Read_InputFile() As Integer

        ''''''''''''''''''''''''''''''''''''''''''''
        Dim Filtre As String = "Text files (INPUT2D_*.txt)|INPUT2D_*.txt"
        Dim Index As Short = 1
        Dim Directoire As Boolean = True
        Dim Titre As String = "Select 2D input file"
        Dim OutFile As String
        Dim Canc As Boolean = False
        Dim nFic As Integer = FreeFile()
        OpenDialog(OutFile, Canc, Filtre, Index, Directoire, Titre)
        If Canc = True Then End
        ''''''''''''''''''''''''''''''''''''''''''''
        Dim Postfile As String = frmTrans2D.Directory & "\"
        FileOpen(nFic, OutFile, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
        FilePost(OutFile, Postfile)

        Dim NameMat As String
        Input(nFic, NameMat)
        DBInput(NameMat)
        Input(nFic, alpha)
        Input(nFic, H_int)
        Input(nFic, Tc)
        Input(nFic, tmax)
        Input(nFic, dt)
        Input(nFic, T_sauv)

        ind = CInt(tmax / dt)

        Return ind

    End Function

    Public Sub DBInput(ByRef MatName As String)

        Dim con As New SqlConnection("Data Source=GCI-DACON-01.FSG.ULAVAL.CA;Initial Catalog=\\GCI-DACON-01\TRANSCHLOR\DATABASE\TRANSCHLORMAT.MDF;Integrated Security=True")

        Try

            con.Open()
            Dim sql As String = "SELECT * FROM Materials WHERE Name IN ('" + MatName + "')"
            Dim command As New SqlCommand(sql, con)
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read()
                type = CDbl(reader("Type").ToString())
                W_C_ratio = CDbl(reader("W/C").ToString())
                rho_c = CDbl(reader("Density").ToString()) 'density of concrete (kg/m3)
                C = CDbl(reader("CementContent").ToString())
                phi = CDbl(reader("Porosity").ToString())
                D0 = CDbl(reader("Dvap").ToString()) * 1000000.0
                alpha_0 = CDbl(reader("alpha0").ToString())
                Hc = CDbl(reader("Hc").ToString())
                KK = CDbl(reader("KK").ToString())
                m = CDbl(reader("m").ToString())
                pc_0 = CDbl(reader("a").ToString())
                beta = CDbl(reader("b").ToString())
            End While

        Catch ex As SqlException
            MsgBox("Material not found in the Database")
        End Try
    End Sub

    Public Sub CalculInitialization(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef NElements As Integer, ByRef Elements() As ElementTrans, ByRef Time() As Double)
        Tk = Tc + 273
        Water_tot = W_C_ratio * C 'densite eau (kg/m3)
        wsat = GetWsat(Water_tot, C, alpha) 'teneur en eau sature (kg/m3)
        w = 0 'indicator for isotherm curve, the initial value for desorption (w = 0) or adsorption curve (w = 1) for the first step
        day = 0 'age du beton (problem)

        For i As Integer = 0 To NNodes - 1

            Dim S_int As Double = GetHtoS(H_int, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
            Nodes(i).SetFieldsNew(H_int, S_int, wsat * S_int)
            Nodes(i).SetFieldsNewToOld()

        Next

        Dim w_avg_0, H_avg_0, S_avg_0 As Double

        FieldAverage(Nodes, H_avg_0, w_avg_0, S_avg_0)
        OutputFile.WriteLine(H_avg_0, w_avg_0, S_avg_0)

        'plot initial state

        For i As Integer = 0 To NElements - 1

            Elements(i).ReDimFields(ind + 2)
            Elements(i).SetFields(0, Nodes(i).GetHRNew() * 100, Nodes(i).GetSNew() * 100)

        Next

        'apply BC
        For i_node As Integer = 0 To NNodes - 1

            OutputFile.WriteFirstLine(Nodes(i_node).GetHROld(), Nodes(i_node).GetWOld(), Nodes(i_node).GetSOld())

            Dim HNew As Double

            If Nodes(i_node).NumExpo <> 0 Then
                HNew = Expo(Nodes(i_node).NumExpo).Humidite(0) / 100
            Else
                HNew = Nodes(i_node).GetHROld()
            End If

            'isotherm state check 
            If w = 0 And Nodes(i_node).GetHRNew() > Nodes(i_node).GetHROld() Then 'state change from desorption to adsorption
                w = 1
            ElseIf w = 1 And Nodes(i_node).GetHRNew() < Nodes(i_node).GetHROld() Then 'adsorption to desorption
                w = 0
            End If

            Dim SNew As Double = GetHtoS(HNew, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
            Nodes(i_node).SetFieldsNew(HNew, SNew, wsat * SNew)

        Next

        OutputFile.WriteBlankLine()

        'compute variation
        'dH_avg += H_new.Average - H_old.Average
        'dw_avg += w_new.Average - w_old.Average
        'dS_avg += S_new.Average - S_old.Average

        'imagine BC is applied in very short time (dt/1000), then output the field variables with BC applied on it

        'OutputFile.WriteField(0, dt / 1000.0, NNodes, dH_avg, H_new)
        'OutputFile.WriteField(1, dt / 1000.0, NNodes, dw_avg, w_new)
        'OutputFile.WriteField(2, dt / 1000.0, NNodes, dS_avg, S_new)

    End Sub

    Public Sub Compute_All(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef NElements As Integer,
                           ByRef Elements() As ElementTrans, ByRef Nodes() As NodeTrans, ByRef Time() As Double)

        Dim LHS(,) As Double
        Dim R(,) As Double
        Dim RHS() As Double
        Dim bg(NNodes - 1, NNodes - 1) As Double 'Global b matrix
        Dim Ag(NNodes - 1, NNodes - 1) As Double 'Global A matrix
        Dim cieNew As CIETransNew
        Dim he As HETrans
        Dim H_ele() As Double

        OutputFile = New OutputFile2D(directory, 3, NNodes)

        CalculInitialization(Expo, NNodes, Nodes, NElements, Elements, Time)

        ''Global time loop
        For ti As Integer = 1 To ind

            frmTrans2D.PlotProgressTime(ind, ti)


            ' step 1: initialisation and boundary check
            For i_node As Integer = 0 To NNodes - 1 ''regular loop
                Nodes(i_node).SetFieldsNewToOld()
            Next

            'step 2: elemental and global Matrix constructions
            'Matrix assembling
            For i As Integer = 0 To NElements - 1

                he = New HETrans(Nodes(Elements(i).Node1 - 1).GetHROld(), Nodes(Elements(i).Node2 - 1).GetHROld(), Nodes(Elements(i).Node3 - 1).GetHROld(), Nodes(Elements(i).Node4 - 1).GetHROld())
                H_ele = he.getHe

                ' new program using nodal interpolations instead of mean value on elements to calculate diffusion coefficient 2020.08.15 Xuande
                Dim d1 As Double = GetDh(D0, alpha_0, Hc, Tc, H_ele(0))
                Dim d2 As Double = GetDh(D0, alpha_0, Hc, Tc, H_ele(1))
                Dim d3 As Double = GetDh(D0, alpha_0, Hc, Tc, H_ele(2))
                Dim d4 As Double = GetDh(D0, alpha_0, Hc, Tc, H_ele(3))
                cieNew = New CIETransNew(
                              Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
                              Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
                              Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
                              Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
                              d1, d2, d3, d4)
                AssembleKg(cieNew.getbe, bg, Elements, i)
                AssembleKg(cieNew.getAe, Ag, Elements, i)

            Next

            'step 3: now, we have assembled Hg_old, Ag and bg , to get LHS and RHS
            getLHS(LHS, NNodes, Ag, bg, dt)
            getRHS(R, NNodes, Ag, bg, dt)

            Dim HOld(NNodes - 1) As Double
            For i As Integer = 0 To NNodes - 1

                HOld(i) = Nodes(i).GetHROld()

            Next

            RHS = MultiplyMatrixWithVector(R, HOld)

            Dim HNew(NNodes - 1) As Double
            GetX(HNew, LHS, RHS)

            'step 4: result check
            For j As Integer = 0 To NNodes - 1
                If HNew(j) >= 1 Then
                    HNew(j) = 1
                ElseIf HNew(j) <= 0 Then
                    HNew(j) = 0
                End If
                Dim NbExpo As Integer = Nodes(j).NumExpo
                If NbExpo <> 0 Then

                    'Dim DtExpo As Single = Expo(NbExpo).DtExpo
                    HNew(j) = Expo(NbExpo).Humidite(CInt(ti)) / 100 ' check whether the current boundary is exposed to a boundary condition

                End If
                ''isotherm state check 
                If w = 0 And HNew(j) > HOld(j) Then 'state change from desorption to adsorption
                    w = 1
                ElseIf w = 1 And HNew(j) < HOld(j) Then 'adsorption to desorption
                    w = 0
                End If

                Dim SNew As Double = GetHtoS(HNew(j), type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
                Nodes(j).SetFieldsNew(HNew(j), SNew, wsat * SNew)

            Next

            'step 5: Post-process : plot 2D image and export result .txt file 
            For i As Integer = 0 To NElements - 1

                Elements(i).CalcFieldInElement(ti, Nodes)

            Next
            Time(ti) = (ti) * dt / 3600 ' Time in hour

            'compute variation

            'dH_avg += H_new.Average - H_old.Average
            'dw_avg += w_new.Average - w_old.Average
            'dS_avg += S_new.Average - S_old.Average

            If (ti * dt / T_sauv) = Int(ti * dt / T_sauv) And Int(ti * dt / T_sauv) > 0 Then ' check register time
                'OutputFile.WriteField(0, ti * dt, NNodes, dH_avg, H_new)
                'OutputFile.WriteField(1, ti * dt, NNodes, dw_avg, w_new)
                'OutputFile.WriteField(2, ti * dt, NNodes, dS_avg, S_new)
            End If
        Next

        MsgBox("End of 2D diffusion", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "End")

    End Sub

    'Assembling global matrix /water diffusion
    Private Shared Sub AssembleKg(ByRef ke(,) As Double, ByRef Kg(,) As Double, ByRef Elements() As ElementTrans, ElementNo As Integer)
        Dim i, j As Integer
        Dim dofs() As Integer = {getDOF(Elements(ElementNo).Node1 - 1),
                                 getDOF(Elements(ElementNo).Node2 - 1),
                                 getDOF(Elements(ElementNo).Node3 - 1),
                                 getDOF(Elements(ElementNo).Node4 - 1)}
        Dim dofi, dofj As Integer
        For i = 0 To 3 'each dof of the Se
            dofi = dofs(i)
            For j = 0 To 3
                dofj = dofs(j)
                Kg(dofi, dofj) = Kg(dofi, dofj) + ke(i, j)
            Next
        Next
    End Sub


End Class
