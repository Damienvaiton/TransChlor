Imports System.Data.SqlClient
Imports System.Linq
Public Class Compute2D
    Dim ServerName As String = "(LocalDB)\MSSQLLocalDB"
    Dim DatabaseName As String = "|DataDirectory|\TransChlorMat.mdf"

    Dim ind As Integer
    Dim directory As String
    Dim wsat As Double
    Dim Water_tot As Double
    Dim Tk As Double
    Dim day As Double
    'Constant parameters
    Public rho_v As Double = 1 'density of vapor (kg/m3)
    Public rho_l As Double = 1000 'density of liquid (kg/m3)
    Public yita_l As Double = 0.00089 'viscosity of water (kg/m.s=pa.s)
    Public pg As Double = 101325 'atmosphere pressure(pa)
    Public LgLim As Integer = 40
    Public pPH As Double = 12.6
    Public mPh As Double = 6.5
    Public RoW As Integer = 1000        'kg/m3
    Public R As Double = 8.3145        'J/mol.K
    Public F As Double = 96484.6    'Farady constant
    Public z_Na As Double = 1   'Na + valence number
    Public z_Cl As Double = 1   'Cl - ...
    Public z_K As Double = 1    'K + ...
    Public z_OH As Double = 1    'OH - ...
    Public z_Ca As Double = 1   'Ca 2+ ...
    Public z_SO4 As Double = 1   'SO4 2- ...
    'Parameters from input file (Eriture à l'ordre de lecture)
    Dim alpha As Double      'hydration degree(-)
    Dim w As Double         'indicator for isotherm curve
    Dim H_int As Double      'initial relative humidity in the material
    Dim T_int As Double      'initial temperature in the material
    Dim Na_int As Double     'initial Sodium concentration in the material
    Dim Cl_int As Double     'initial chloride concentration in the material
    Dim K_int As Double      'initial Potassium concentration in the material
    Dim OH_int As Double     'initial Hydroxide ion oncentration in the material
    Dim Ca_int As Double     'initial Calcium concentration in the material
    Dim SO4_int As Double     'initial Sulfate concentration in the material
    Dim Tc As Double    'initial temperature in the material
    Dim Model As Integer 'Computation model
    Dim tmax As Double 'end time (s) 72h
    Dim dt As Double 'time interval (s)
    Dim T_sauv As Double
    'Material data from database (Eriture à l'ordre de lecture)
    Dim Des As String 'material description (-)
    Dim type As Integer 'cement type (-)
    Dim W_C_ratio As Double  'ratio E/C (kg/m3)
    Dim rho_c As Double  'density of concrete (kg/m3)
    Dim C As Double 'cement content (kg/m3)
    Dim phi As Double  'porosity (-)
    Dim D0 As Double 'water vapour diffusivity [Bazant model](m2/s)
    Dim alpha_0 As Double 'water vapour diffusivity parameters [Bazant model](-)
    Dim Hc As Double 'water vapour diffusivity parameters [Bazant model](-)
    Dim kg As Double 'intrinsic permeability to liquid (m2)
    Dim kl As Double 'intrinsic permeability to liquid (m2)
    Dim pc_0 As Double 'capillary pressure parameter
    Dim beta As Double 'capillary pressure parameter
    Dim m As Double 'relative permeability parameter
    'Dim H_old() As Double
    'Dim H_new() As Double
    'Dim S_old() As Double
    'Dim S_new() As Double
    'Dim w_old() As Double
    'Dim w_new() As Double
    Dim dH_avg As Double
    Dim dw_avg As Double
    Dim dS_avg As Double
    Dim dT_avg As Double
    Dim dNa_avg As Double
    Dim dCl_avg As Double
    Dim dK_avg As Double
    Dim dOH_avg As Double
    Dim dCa_avg As Double
    Dim dSO4_avg As Double
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
        directory = FrmTrans2D.Directory & "\"
        FileOpen(nFic, OutFile, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
        FilePost(OutFile, directory)

        Dim NameMat As String
        Input(nFic, NameMat)
        DBInput(NameMat)
        Input(nFic, alpha)
        Input(nFic, w)
        Input(nFic, H_int)
        Input(nFic, Tc)
        Input(nFic, Model)
        Input(nFic, tmax)
        Input(nFic, dt)
        Input(nFic, T_sauv)
        ind = CInt(tmax / dt)
        Return ind

    End Function

    Public Sub DBInput(ByRef MatName As String)

        Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TransChlorMat.mdf;Integrated Security=True")

        Try
            con.Open()
            Dim sql As String = "SELECT * FROM Materials WHERE Name IN ('" + MatName + "')"
            Dim command As New SqlCommand(sql, con)
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read()
                Des = CStr(reader("Description").ToString())
                type = CDbl(reader("Type").ToString())
                W_C_ratio = CDbl(reader("W/C").ToString())
                rho_c = CDbl(reader("Density").ToString()) 'density of concrete (kg/m3)
                C = CDbl(reader("CementContent").ToString())
                phi = CDbl(reader("Porosity").ToString())
                D0 = CDbl(reader("Dvap").ToString()) * 1000000.0
                alpha_0 = CDbl(reader("alpha0").ToString())
                Hc = CDbl(reader("Hc").ToString())
                kg = CDbl(reader("kg").ToString())
                kl = CDbl(reader("kl").ToString())
                pc_0 = CDbl(reader("a").ToString())
                beta = CDbl(reader("b").ToString())
                m = CDbl(reader("m").ToString())
            End While

        Catch ex As SqlException
            MsgBox("Material not found in the Database")
        End Try
    End Sub

    Public Sub CalculInitialization(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef NElements As Integer, ByRef Elements() As ElementTrans, ByRef Time() As Double)

        Tk = Tc + 273 '(K) 
        Water_tot = W_C_ratio * C 'densite eau (kg/m3)
        wsat = GetWsat(Water_tot, C, alpha) 'teneur en eau sature (kg/m3)
        w = 0 'the initial value for desorption (w = 0) or adsorption curve (w = 1) for the first step
        day = 0 'age du beton (problem)

        Dim St As Double = 0.2 'capillary pressure residual saturation
        Dim w_avg_0, H_avg_0, S_avg_0, T_avg_0, Na_avg_0, Cl_avg_0, K_avg_0, OH_avg_0, Ca_avg_0, SO4_avg_0 As Double
        Dim HNew As Double
        Dim SNew As Double
        Dim TNew As Double
        Dim NaNew As Double
        Dim ClNew As Double
        Dim KNew As Double
        Dim OHNew As Double
        Dim CaNew As Double
        Dim SO4New As Double
        Dim S_int As Double
        Dim HRAvg, WAvg, SAvg, TAvg, NaAvg, ClAvg, KAvg, OHAvg, CaAvg, SO4Avg As Double
        For i As Integer = 0 To NNodes - 1
            S_int = GetHtoS(H_int, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
            Nodes(i).SetFieldsNew(H_int, S_int, wsat * S_int, T_int, Na_int, Cl_int, K_int, OH_int, Ca_int, SO4_int)
            Nodes(i).SetFieldsNewToOld()
        Next

        FieldAverage(Nodes, H_avg_0, w_avg_0, S_avg_0, T_avg_0, Na_avg_0, Cl_avg_0, K_avg_0, OH_avg_0, Ca_avg_0, SO4_avg_0)
        OutputFile.WriteLine(H_avg_0, w_avg_0, S_avg_0, T_avg_0, Na_avg_0, Cl_avg_0, K_avg_0, OH_avg_0, Ca_avg_0, SO4_avg_0)

        'plot initial state
        For i As Integer = 0 To NElements - 1
            Elements(i).ReDimFields(ind + 2)
            Elements(i).SetFields(0, Nodes(i).GetHRNew() * 100, Nodes(i).GetSNew() * 100, Nodes(i).GetTNew(), Nodes(i).GetNaNew(), Nodes(i).GetClNew(), Nodes(i).GetKNew(), Nodes(i).GetOHNew(), Nodes(i).GetCaNew(), Nodes(i).GetSO4New())
        Next

        'apply BC
        For i_node As Integer = 0 To NNodes - 1
            OutputFile.WriteFirstLine(Nodes(i_node).GetHROld(), Nodes(i_node).GetWOld(), Nodes(i_node).GetSOld(), Nodes(i_node).GetTOld(), Nodes(i_node).GetNaOld(), Nodes(i_node).GetClOld(), Nodes(i_node).GetKOld(), Nodes(i_node).GetOHOld(), Nodes(i_node).GetCaOld(), Nodes(i_node).GetSO4Old())
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
            SNew = GetHtoS(HNew, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)

            Nodes(i_node).SetFieldsNew(HNew, SNew, wsat * SNew, TNew, NaNew, ClNew, KNew, OHNew, CaNew, SO4New)
        Next

        OutputFile.WriteBlankLine()

        'compute variation
        UpdatediffAverage(Nodes, dH_avg, dw_avg, dS_avg, dT_avg, dNa_avg, dCl_avg, dK_avg, dOH_avg, dCa_avg, dSO4_avg)
        GetNewAverage(Nodes, HRAvg, WAvg, SAvg, TAvg, NaAvg, ClAvg, KAvg, OHAvg, CaAvg, SO4Avg)

        'imagine BC is applied in very short time (dt/1000), then output the field variables with BC applied on it

        OutputFile.WriteHR(dt / 1000.0, NNodes, dH_avg, HRAvg, Nodes)
        OutputFile.WriteW(dt / 1000.0, NNodes, dw_avg, WAvg, Nodes)
        OutputFile.WriteS(dt / 1000.0, NNodes, dS_avg, SAvg, Nodes)
        OutputFile.WriteT(dt / 1000.0, NNodes, dT_avg, TAvg, Nodes)
        OutputFile.WriteCl(dt / 1000.0, NNodes, dCl_avg, ClAvg, Nodes)
    End Sub

    Public Sub Compute_All(ByRef Frm As FrmTrans2D, ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef NElements As Integer,
                           ByRef Elements() As ElementTrans, ByRef Nodes() As NodeTrans, ByRef Time() As Double)

        Dim LHS(,) As Double
        Dim R(,) As Double
        Dim RHS() As Double
        Dim bg(NNodes - 1, NNodes - 1) As Double 'Global b matrix
        Dim Ag(NNodes - 1, NNodes - 1) As Double 'Global A matrix
        Dim cieNew As CIETransNew
        Dim he As HETrans
        Dim H_ele() As Double
        OutputFile = New OutputFile2D(directory, 5, NNodes, Model)
        CalculInitialization(Expo, NNodes, Nodes, NElements, Elements, Time)

        ''Global time loop
        For ti As Integer = 1 To ind

            Frm.PlotProgressTime(ind, ti)

            ' step 1: initialisation and boundary check
            For i_node As Integer = 0 To NNodes - 1 ''regular loop
                Nodes(i_node).SetFieldsNewToOld()
            Next

            'step 2: elemental and global Matrix constructions
            'Matrix assembling
            For i As Integer = 0 To NElements - 1

                he = New HETrans(Nodes(Elements(i).Node1 - 1).GetHROld(), Nodes(Elements(i).Node2 - 1).GetHROld(), Nodes(Elements(i).Node3 - 1).GetHROld(), Nodes(Elements(i).Node4 - 1).GetHROld())
                H_ele = he.getHe

                'new program using nodal interpolations instead of mean value on elements to calculate diffusion coefficient 2020.08.15 Xuande
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
                Dim TNew As Double
                Dim NaNew As Double
                Dim ClNew As Double
                Dim KNew As Double
                Dim OHNew As Double
                Dim CaNew As Double
                Dim SO4New As Double
                Nodes(j).SetFieldsNew(HNew(j), SNew, wsat * SNew, TNew, NaNew, ClNew, KNew, OHNew, CaNew, SO4New)

            Next

            'step 5: Post-process : plot 2D image and export result .txt file 
            ''Post-process : plot 2D image and export result .txt file 
            Dim HRAvg, WAvg, SAvg, TAvg, NaAvg, ClAvg, KAvg, OHAvg, CaAvg, SO4Avg As Double
            For i As Integer = 0 To NElements - 1
                Elements(i).CalcFieldInElement(ti, Nodes)
            Next
            Time(ti) = ti * dt / 3600 ' Time in hour
            'compute variation
            UpdatediffAverage(Nodes, dH_avg, dw_avg, dS_avg, dT_avg, dNa_avg, dCl_avg, dK_avg, dOH_avg, dCa_avg, dSO4_avg)
            If (ti * dt / T_sauv) = Int(ti * dt / T_sauv) And Int(ti * dt / T_sauv) > 0 Then ' check register time
                GetNewAverage(Nodes, HRAvg, WAvg, SAvg, TAvg, NaAvg, ClAvg, KAvg, OHAvg, CaAvg, SO4Avg)
                OutputFile.WriteHR(ti * dt, NNodes, dH_avg, HRAvg, Nodes)
                OutputFile.WriteW(ti * dt, NNodes, dw_avg, WAvg, Nodes)
                OutputFile.WriteS(ti * dt, NNodes, dS_avg, SAvg, Nodes)
                OutputFile.WriteT(ti * dt, NNodes, dT_avg, TAvg, Nodes)
                OutputFile.WriteNa(ti * dt, NNodes, dCl_avg, ClAvg, Nodes)
                OutputFile.WriteCl(ti * dt, NNodes, dCl_avg, ClAvg, Nodes)
                OutputFile.WriteK(ti * dt, NNodes, dCl_avg, ClAvg, Nodes)
                OutputFile.WriteOH(ti * dt, NNodes, dCl_avg, ClAvg, Nodes)
                OutputFile.WriteCa(ti * dt, NNodes, dCl_avg, ClAvg, Nodes)
                OutputFile.WriteSO4(ti * dt, NNodes, dCl_avg, ClAvg, Nodes)
            End If
        Next

        MsgBox("End of 2D computation", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "End")

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
