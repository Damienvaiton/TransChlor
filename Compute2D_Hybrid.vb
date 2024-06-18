Imports System.Data.SqlClient
Imports System.Linq
Public Class Compute2D_trial
    Dim ind As Integer
    Dim directory As String
    Dim wsat As Double
    Dim Water_tot As Double
    Dim Tk As Double
    Dim day As Double
    'Constant parameters
    Public rho_v As Double = 1 'density of vapor water (kg/m3)
    Public rho_l As Double = 1000 'density of liquid water (kg/m3)
    Public yita_l As Double = 0.00089 'viscosity of water (kg/m.s=pa.s)
    Public pg As Double = 101325 'atmosphere pressure(pa)
    Public LgLim As Integer = 40
    Public pPH As Double = 12.6
    Public mPh As Double = 6.5
    Public RoW As Integer = 1000 '(kg/m3)
    Public R As Double = 8.3145 '(J/mol.K)
    Public Mw As Double = 0.018 'molecular mass of water (kg/mol)
    'Computation parameters from input file (Eriture à l'ordre de lecture)
    Dim alpha As Double  'hydration degree(-)
    Dim w As Double 'indicator for isotherm curve (0 or 1, -)
    Dim H_int As Double  'initial relative humidity in the material (-)
    Dim T_int As Double  'initial temperature in the material (celcius degree C)
    Dim Cl_int As Double  'initial chloride concentration in the material (mol/L)
    Dim Tc As Double 'initial temperature in the material (celcius degree C)
    Dim Model As Integer 'Computation mode (-)
    Dim tmax As Double 'end time (s) (hour)
    Dim dt As Double 'time interval (s)
    Dim T_sauv As Double
    'Material parameters from database (Eriture à l'ordre de lecture)
    Dim Des As String 'material description (-)
    Dim type As Integer 'cement type (-)
    Dim W_C_ratio As Double  'ratio E/C (kg/m3)
    Dim rho_c As Double  'density of concrete (kg/m3)
    Dim C As Double 'cement content (kg/m3)
    Dim phi As Double  'porosity (-)
    Dim D0 As Double 'water vapour diffusivity [Bazant model](m2/s)
    Dim alpha_0 As Double 'water vapour diffusivity parameters [Bazant model](-)
    Dim Hc As Double 'water vapour diffusivity parameters [Bazant model](-)
    Dim kg As Double 'intrinsic permeability to gas (m2)
    Dim kl As Double 'intrinsic permeability to liquid (m2)
    Dim pc_0 As Double 'capillary pressure parameter (Mpa)
    Dim beta As Double 'capillary pressure parameter (-)
    Dim m As Double 'relative permeability parameter (-)
    Dim G As Double 'granulat content (kg/m3)
    'Other non-constant parameters
    Dim dH_avg As Double
    Dim dw_avg As Double
    Dim dS_avg As Double
    Dim dT_avg As Double
    Dim dCl_avg As Double
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
        Input(nFic, T_int)
        Input(nFic, Model)
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

    Public Sub Compute_All(ByRef Frm As FrmTrans2D, ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef NElements As Integer,
                           ByRef Elements() As ElementTrans, ByRef Nodes() As NodeTrans, ByRef Time() As Double)
        OutputFile = New OutputFile2D(directory, 5, NNodes, Model)
        CalculInitialization(Expo, NNodes, Nodes, NElements, Elements, Time)
        ''Global time loop
        For ti As Integer = 1 To ind - 1
            Frm.PlotProgressTime(ind, ti)
            ''Field value initialization
            setVariables(NNodes, Nodes)
            If Model = 0 Then
                '' HTC_old model
                ' Thermo
                Thermo(Expo, NNodes, Nodes, NElements, Elements, ti)
                ' Diff
                Diff(Expo, NNodes, Nodes, NElements, Elements, ti)
                ' Chemo
                'Chemo()
            ElseIf Model = 1 Then
                '' HTC_new model
                ' Thermo
                Thermo(Expo, NNodes, Nodes, NElements, Elements, ti)
                ' Cap
                Cap(Expo, NNodes, Nodes, NElements, Elements, ti)
                ' Chemo
                'Chemo()
            End If
            Postprocess(NNodes, Nodes, NElements, Elements, ti, Time)
        Next
        MsgBox("End of 2D computation", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "End")
    End Sub

    Public Sub CalculInitialization(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef NElements As Integer, ByRef Elements() As ElementTrans, ByRef Time() As Double)
        Tc = T_int
        Tk = Tc + 273 '(K) 
        Water_tot = W_C_ratio * C 'densite eau (kg/m3)
        wsat = GetWsat(Water_tot, C, alpha) 'teneur en eau sature (kg/m3)
        day = 0 'age du beton (problem)
        Dim w_avg_0, H_avg_0, S_avg_0, T_avg_0, Cl_avg_0 As Double
        Dim HNew As Double
        Dim SNew As Double
        Dim TNew As Double
        Dim ClNew As Double
        Dim S_int As Double
        Dim HRAvg, WAvg, SAvg, TAvg, ClAvg As Double
        'apply initial field value to all nodes
        For i As Integer = 0 To NNodes - 1
            S_int = GetHtoS(H_int, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
            Nodes(i).SetFieldsNew(H_int, S_int, wsat * S_int, T_int, Cl_int)
            Nodes(i).SetFieldsNewToOld()
        Next
        FieldAverage(Nodes, H_avg_0, w_avg_0, S_avg_0, T_avg_0, Cl_avg_0)
        OutputFile.WriteLine(H_avg_0, w_avg_0, S_avg_0, T_avg_0, Cl_avg_0)
        'plot initial state
        For i As Integer = 0 To NElements - 1
            Elements(i).ReDimFields(ind + 2)
            Elements(i).SetFields(0, Nodes(i).GetHRNew() * 100, Nodes(i).GetSNew() * 100, Nodes(i).GetTNew(), Nodes(i).GetClNew())
        Next
        'apply initial boundary condition to all nodes
        For i_node As Integer = 0 To NNodes - 1
            OutputFile.WriteFirstLine(Nodes(i_node).GetHROld(), Nodes(i_node).GetWOld(), Nodes(i_node).GetSOld(), Nodes(i_node).GetTOld(), Nodes(i_node).GetClOld())
            If Nodes(i_node).TypeExpo.Contains("Dirichlet") Then
                HNew = Expo(Nodes(i_node).NumExpo).Humidite(0) / 100
                TNew = Expo(Nodes(i_node).NumExpo).Temperature(0)
            Else
                HNew = Nodes(i_node).GetHROld()
                TNew = Nodes(i_node).GetTOld()
            End If
            SNew = GetHtoS(HNew, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
            Nodes(i_node).SetFieldsNew(HNew, SNew, wsat * SNew, TNew, ClNew)
        Next
        OutputFile.WriteBlankLine()
        'compute variation
        UpdatediffAverage(Nodes, dH_avg, dw_avg, dS_avg, dT_avg, dCl_avg)
        GetNewAverage(Nodes, HRAvg, WAvg, SAvg, TAvg, ClAvg)
        'imagine BC is applied in very short time (dt/1000), then output the field variables with BC applied on it
        OutputFile.WriteFirstHR(dt / 1000.0, NNodes, dH_avg, HRAvg, Nodes)
        OutputFile.WriteW(dt / 1000.0, NNodes, dw_avg, WAvg, Nodes)
        OutputFile.WriteS(dt / 1000.0, NNodes, dS_avg, SAvg, Nodes)
        OutputFile.WriteT(dt / 1000.0, NNodes, dT_avg, TAvg, Nodes)
        OutputFile.WriteCl(dt / 1000.0, NNodes, dCl_avg, ClAvg, Nodes)
    End Sub

    Public Sub Thermo(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef NElements As Integer, ByRef Elements() As ElementTrans, ByRef ti As Integer)
        ''Elemental and global matrix constructions and resolution 
        Dim LHS(,) As Double
        Dim R(,) As Double
        Dim RHS() As Double
        Dim bg(NNodes - 1, NNodes - 1) As Double 'Global b matrix
        Dim Ag(NNodes - 1, NNodes - 1) As Double 'Global A matrix
        Dim JX(NNodes - 1) As Double 'Global x flux vector
        Dim JY(NNodes - 1) As Double 'Global y flux vector
        Dim cieNew As CIETransNew
        Dim Te As TETrans
        Dim Se As SETrans
        Dim T_ele() As Double
        Dim S_ele() As Double
        ' provisoire
        Dim Granulat As Double = 1917
        Dim Cement As Double = 375
        Dim TOld(NNodes - 1) As Double
        Dim TNew(NNodes - 1) As Double
        'Stiffness matrix assembling
        For i As Integer = 0 To NElements - 1
            Te = New TETrans(Nodes(Elements(i).Node1 - 1).GetTOld(), Nodes(Elements(i).Node2 - 1).GetTOld(), Nodes(Elements(i).Node3 - 1).GetTOld(), Nodes(Elements(i).Node4 - 1).GetTOld())
            Se = New SETrans(Nodes(Elements(i).Node1 - 1).GetSOld(), Nodes(Elements(i).Node2 - 1).GetSOld(), Nodes(Elements(i).Node3 - 1).GetSOld(), Nodes(Elements(i).Node4 - 1).GetSOld())
            T_ele = Te.getTe
            S_ele = Se.getSe
            ' new program using nodal interpolations instead of mean value on elements to calculate diffusion coefficient 2020.08.15 Xuande
            Dim Lambta1 As Double = lambtafunc(T_ele(0), phi, S_ele(0), Granulat, Cement)
            Dim Lambta2 As Double = lambtafunc(T_ele(1), phi, S_ele(1), Granulat, Cement)
            Dim Lambta3 As Double = lambtafunc(T_ele(2), phi, S_ele(2), Granulat, Cement)
            Dim Lambta4 As Double = lambtafunc(T_ele(3), phi, S_ele(3), Granulat, Cement)
            Dim rho_Cp1 As Double = Cpfunc(T_ele(0), phi, S_ele(0), Granulat, Cement)
            Dim rho_Cp2 As Double = Cpfunc(T_ele(1), phi, S_ele(1), Granulat, Cement)
            Dim rho_Cp3 As Double = Cpfunc(T_ele(2), phi, S_ele(2), Granulat, Cement)
            Dim rho_Cp4 As Double = Cpfunc(T_ele(3), phi, S_ele(3), Granulat, Cement)
            Dim d1 As Double = GetDlambta(Lambta1, rho_Cp1)
            Dim d2 As Double = GetDlambta(Lambta2, rho_Cp2)
            Dim d3 As Double = GetDlambta(Lambta3, rho_Cp3)
            Dim d4 As Double = GetDlambta(Lambta4, rho_Cp4)
            cieNew = New CIETransNew(
                          Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
                          Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
                          Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
                          Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
                          d1, d2, d3, d4)
            'flux model, xuande 2020.08.28
            Dim J1_inv As Double(,) = cieNew.GetInversedJac(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J2_inv As Double(,) = cieNew.GetInversedJac(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J3_inv As Double(,) = cieNew.GetInversedJac(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim J4_inv As Double(,) = cieNew.GetInversedJac(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim Dmat1 As Double(,) = cieNew.getDmat(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim Dmat2 As Double(,) = cieNew.getDmat(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim Dmat3 As Double(,) = cieNew.getDmat(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim Dmat4 As Double(,) = cieNew.getDmat(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim flux_x1 As Double = cieNew.getXFlux(Dmat1(0, 0), T_ele, J1_inv, cieNew.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_x2 As Double = cieNew.getXFlux(Dmat2(0, 0), T_ele, J2_inv, cieNew.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_x3 As Double = cieNew.getXFlux(Dmat3(0, 0), T_ele, J3_inv, cieNew.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_x4 As Double = cieNew.getXFlux(Dmat4(0, 0), T_ele, J4_inv, cieNew.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_y1 As Double = cieNew.getYFlux(Dmat1(1, 1), T_ele, J1_inv, cieNew.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_y2 As Double = cieNew.getYFlux(Dmat2(1, 1), T_ele, J2_inv, cieNew.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_y3 As Double = cieNew.getYFlux(Dmat3(1, 1), T_ele, J3_inv, cieNew.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_y4 As Double = cieNew.getYFlux(Dmat4(1, 1), T_ele, J4_inv, cieNew.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim vec_fluxX As Double() = getve(flux_x1, flux_x2, flux_x3, flux_x4)
            Dim vec_fluxY As Double() = getve(flux_y1, flux_y2, flux_y3, flux_y4)
            AssembleVg(vec_fluxX, JX, Elements, i)
            AssembleVg(vec_fluxY, JY, Elements, i)
            AssembleKg(cieNew.getbe, bg, Elements, i)
            AssembleKg(cieNew.getAe, Ag, Elements, i)
        Next
        'Now, we have assembled Hg_old, Ag and bg , get LHS and RHS and resolve the linear matrix system
        getLHS(LHS, NNodes, Ag, bg, dt)
        getRHS(R, NNodes, Ag, bg, dt)
        For i As Integer = 0 To NNodes - 1
            TOld(i) = Nodes(i).GetTOld()
        Next
        RHS = MultiplyMatrixWithVector(R, TOld)
        GetX(TNew, LHS, RHS)
        'Result check and update
        updateVariableT(Expo, NNodes, Nodes, TNew, ti)
        updateThermoFlux(NNodes, Nodes, JX, JY)
    End Sub

    Public Sub Diff(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef NElements As Integer, ByRef Elements() As ElementTrans, ByRef ti As Integer)
        ''Elemental and global matrix constructions and resolution 
        Dim LHS(,) As Double
        Dim R(,) As Double
        Dim RHS() As Double
        Dim bg(NNodes - 1, NNodes - 1) As Double 'Global b matrix
        Dim Ag(NNodes - 1, NNodes - 1) As Double 'Global A matrix
        Dim JX(NNodes - 1) As Double 'Global x flux vector
        Dim JY(NNodes - 1) As Double 'Global y flux vector
        Dim cieNew As CIETransNew
        Dim He As HETrans
        Dim Te As TETrans
        Dim Se As SETrans
        Dim H_ele() As Double
        Dim T_ele() As Double
        Dim S_ele() As Double
        Dim HOld(NNodes - 1) As Double
        Dim HNew(NNodes - 1) As Double
        'Matrix assembling
        For i As Integer = 0 To NElements - 1
            He = New HETrans(Nodes(Elements(i).Node1 - 1).GetHROld(), Nodes(Elements(i).Node2 - 1).GetHROld(), Nodes(Elements(i).Node3 - 1).GetHROld(), Nodes(Elements(i).Node4 - 1).GetHROld())
            H_ele = He.getHe
            Te = New TETrans(Nodes(Elements(i).Node1 - 1).GetTOld(), Nodes(Elements(i).Node2 - 1).GetTOld(), Nodes(Elements(i).Node3 - 1).GetTOld(), Nodes(Elements(i).Node4 - 1).GetTOld())
            Se = New SETrans(Nodes(Elements(i).Node1 - 1).GetSOld(), Nodes(Elements(i).Node2 - 1).GetSOld(), Nodes(Elements(i).Node3 - 1).GetSOld(), Nodes(Elements(i).Node4 - 1).GetSOld())
            T_ele = Te.getTe
            S_ele = Se.getSe
            'new program using nodal interpolations instead of mean value on elements to calculate diffusion coefficient 2020.08.15 Xuande
            Dim d1 As Double = GetDh(D0, alpha_0, Hc, T_ele(0), H_ele(0))
            Dim d2 As Double = GetDh(D0, alpha_0, Hc, T_ele(1), H_ele(1))
            Dim d3 As Double = GetDh(D0, alpha_0, Hc, T_ele(2), H_ele(2))
            Dim d4 As Double = GetDh(D0, alpha_0, Hc, T_ele(3), H_ele(3))
            cieNew = New CIETransNew(
                          Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
                          Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
                          Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
                          Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
                          d1, d2, d3, d4)
            'flux model, xuande 2020.08.28
            Dim J1_inv As Double(,) = cieNew.GetInversedJac(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J2_inv As Double(,) = cieNew.GetInversedJac(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J3_inv As Double(,) = cieNew.GetInversedJac(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim J4_inv As Double(,) = cieNew.GetInversedJac(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim Dmat1 As Double(,) = cieNew.getDmat(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim Dmat2 As Double(,) = cieNew.getDmat(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim Dmat3 As Double(,) = cieNew.getDmat(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim Dmat4 As Double(,) = cieNew.getDmat(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim flux_x1 As Double = cieNew.getXFlux(Dmat1(0, 0), T_ele, J1_inv, cieNew.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_x2 As Double = cieNew.getXFlux(Dmat2(0, 0), T_ele, J2_inv, cieNew.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_x3 As Double = cieNew.getXFlux(Dmat3(0, 0), T_ele, J3_inv, cieNew.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_x4 As Double = cieNew.getXFlux(Dmat4(0, 0), T_ele, J4_inv, cieNew.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_y1 As Double = cieNew.getYFlux(Dmat1(1, 1), T_ele, J1_inv, cieNew.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_y2 As Double = cieNew.getYFlux(Dmat2(1, 1), T_ele, J2_inv, cieNew.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_y3 As Double = cieNew.getYFlux(Dmat3(1, 1), T_ele, J3_inv, cieNew.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_y4 As Double = cieNew.getYFlux(Dmat4(1, 1), T_ele, J4_inv, cieNew.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim vec_fluxX As Double() = getve(flux_x1, flux_x2, flux_x3, flux_x4)
            Dim vec_fluxY As Double() = getve(flux_y1, flux_y2, flux_y3, flux_y4)
            AssembleVg(vec_fluxX, JX, Elements, i)
            AssembleVg(vec_fluxY, JY, Elements, i)
            AssembleKg(cieNew.getbe, bg, Elements, i)
            AssembleKg(cieNew.getAe, Ag, Elements, i)
        Next
        'Now, we have assembled Hg_old, Ag and bg , Now, we have assembled Hg_old, Ag and bg , get LHS and RHS and resolve the linear matrix system
        getLHS(LHS, NNodes, Ag, bg, dt)
        getRHS(R, NNodes, Ag, bg, dt)
        For i As Integer = 0 To NNodes - 1
            HOld(i) = Nodes(i).GetHROld()
        Next
        RHS = MultiplyMatrixWithVector(R, HOld)
        GetX(HNew, LHS, RHS)
        'Result check and update
        updateVariableH(Expo, NNodes, Nodes, HOld, HNew, ti)
        updateDiffusionFlux(NNodes, Nodes, JX, JY)
    End Sub

    Public Sub Cap(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef NElements As Integer, ByRef Elements() As ElementTrans, ByRef ti As Integer)
        ''Elemental and global matrix constructions and resolution 
        Dim NewLHS(,) As Double
        Dim NewR(,) As Double
        Dim RHS() As Double
        Dim bg(NNodes - 1, NNodes - 1) As Double 'Global b matrix
        Dim Ag(NNodes - 1, NNodes - 1) As Double 'Global A matrix
        Dim JX(NNodes - 1) As Double 'Global x flux vector
        Dim JY(NNodes - 1) As Double 'Global y flux vector
        Dim cieNew As CIETransNew
        Dim He As HETrans
        Dim Te As TETrans
        Dim Se As SETrans
        Dim H_ele() As Double
        Dim T_ele() As Double
        Dim S_ele() As Double
        Dim SOld(NNodes - 1) As Double
        Dim SNew(NNodes - 1) As Double
        Dim HNew(NNodes - 1) As Double
        Dim Node_w(NNodes - 1) As Integer
        Dim St As Double = 0.2 'capillary pressure residual saturation
        'Matrix assembling
        For i As Integer = 0 To NElements - 1
            Te = New TETrans(Nodes(Elements(i).Node1 - 1).GetTOld(), Nodes(Elements(i).Node2 - 1).GetTOld(), Nodes(Elements(i).Node3 - 1).GetTOld(), Nodes(Elements(i).Node4 - 1).GetTOld())
            Se = New SETrans(Nodes(Elements(i).Node1 - 1).GetSOld(), Nodes(Elements(i).Node2 - 1).GetSOld(), Nodes(Elements(i).Node3 - 1).GetSOld(), Nodes(Elements(i).Node4 - 1).GetSOld())
            T_ele = Te.getTe
            S_ele = Se.getSe
            'New program using nodal interpolations instead of mean value on elements to calculate transport coefficient 2020.08.15 Xuande
            Dim Di1 As Double = GetD(T_ele(0), pg)
            Dim Di2 As Double = GetD(T_ele(1), pg)
            Dim Di3 As Double = GetD(T_ele(2), pg)
            Dim Di4 As Double = GetD(T_ele(3), pg)
            Dim kr1 As Double = Getkr(S_ele(0), m)
            Dim kr2 As Double = Getkr(S_ele(1), m)
            Dim kr3 As Double = Getkr(S_ele(2), m)
            Dim kr4 As Double = Getkr(S_ele(3), m)
            Dim pc1 As Double = Getpc(S_ele(0), pc_0, beta, St)
            Dim pc2 As Double = Getpc(S_ele(1), pc_0, beta, St)
            Dim pc3 As Double = Getpc(S_ele(2), pc_0, beta, St)
            Dim pc4 As Double = Getpc(S_ele(3), pc_0, beta, St)
            Dim dpcdS1 As Double = GetdpcdS(S_ele(0), pc_0, beta, St)
            Dim dpcdS2 As Double = GetdpcdS(S_ele(1), pc_0, beta, St)
            Dim dpcdS3 As Double = GetdpcdS(S_ele(2), pc_0, beta, St)
            Dim dpcdS4 As Double = GetdpcdS(S_ele(3), pc_0, beta, St)
            Dim Dl1 As Double = GetDl(kl, yita_l, dpcdS1, kr1)
            Dim Dl2 As Double = GetDl(kl, yita_l, dpcdS2, kr2)
            Dim Dl3 As Double = GetDl(kl, yita_l, dpcdS3, kr3)
            Dim Dl4 As Double = GetDl(kl, yita_l, dpcdS4, kr4)
            Dim f1 As Double = Getf(phi, S_ele(0))
            Dim f2 As Double = Getf(phi, S_ele(1))
            Dim f3 As Double = Getf(phi, S_ele(2))
            Dim f4 As Double = Getf(phi, S_ele(3))
            Dim Dv1 As Double = GetDv(rho_v, rho_l, dpcdS1, f1, Di1, pg)
            Dim Dv2 As Double = GetDv(rho_v, rho_l, dpcdS2, f2, Di2, pg)
            Dim Dv3 As Double = GetDv(rho_v, rho_l, dpcdS3, f3, Di3, pg)
            Dim Dv4 As Double = GetDv(rho_v, rho_l, dpcdS4, f4, Di4, pg)
            Dim d1 As Double = Dl1 + Dv1
            Dim d2 As Double = Dl2 + Dv2
            Dim d3 As Double = Dl3 + Dv3
            Dim d4 As Double = Dl4 + Dv4
            cieNew = New CIETransNew(
        Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
        Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
        Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
        Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
        d1, d2, d3, d4)
            'flux model, xuande 2020.08.28
            Dim J1_inv As Double(,) = cieNew.GetInversedJac(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J2_inv As Double(,) = cieNew.GetInversedJac(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J3_inv As Double(,) = cieNew.GetInversedJac(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim J4_inv As Double(,) = cieNew.GetInversedJac(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim Dmat1 As Double(,) = cieNew.getDmat(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim Dmat2 As Double(,) = cieNew.getDmat(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim Dmat3 As Double(,) = cieNew.getDmat(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim Dmat4 As Double(,) = cieNew.getDmat(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim flux_x1 As Double = cieNew.getXFlux(Dmat1(0, 0), S_ele, J1_inv, cieNew.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_x2 As Double = cieNew.getXFlux(Dmat2(0, 0), S_ele, J2_inv, cieNew.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_x3 As Double = cieNew.getXFlux(Dmat3(0, 0), S_ele, J3_inv, cieNew.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_x4 As Double = cieNew.getXFlux(Dmat4(0, 0), S_ele, J4_inv, cieNew.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_y1 As Double = cieNew.getYFlux(Dmat1(1, 1), S_ele, J1_inv, cieNew.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_y2 As Double = cieNew.getYFlux(Dmat2(1, 1), S_ele, J2_inv, cieNew.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_y3 As Double = cieNew.getYFlux(Dmat3(1, 1), S_ele, J3_inv, cieNew.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_y4 As Double = cieNew.getYFlux(Dmat4(1, 1), S_ele, J4_inv, cieNew.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim vec_fluxX As Double() = getve(flux_x1, flux_x2, flux_x3, flux_x4)
            Dim vec_fluxY As Double() = getve(flux_y1, flux_y2, flux_y3, flux_y4)
            AssembleVg(vec_fluxX, JX, Elements, i)
            AssembleVg(vec_fluxY, JY, Elements, i)
            AssembleKg(cieNew.getbe, bg, Elements, i)
            AssembleKg(cieNew.getAe, Ag, Elements, i)
        Next
        'Now, we have assembled Sg_old, Ag and bg , to get LHS and RHS
        getNewLHS(NewLHS, NNodes, phi, Ag, bg, dt)
        getNewR(NewR, NNodes, phi, Ag, bg, dt)
        For i As Integer = 0 To NNodes - 1
            SOld(i) = Nodes(i).GetSOld()
        Next
        RHS = MultiplyMatrixWithVector(NewR, SOld)
        GetX(SNew, NewLHS, RHS)
        'Result check and update
        updateVariableS(Expo, NNodes, Nodes, SOld, SNew, Node_w, ti)
        updateCapillaryFlux(NNodes, Nodes, JX, JY)
    End Sub

    'Public Sub Chemo()
    '    ''Elemental and global matrix constructions and resolution 
    '    'Matrix assembling
    '    For i As Integer = 0 To NElements - 1

    '        he = New HETrans(Nodes(Elements(i).Node1 - 1).GetHROld(), Nodes(Elements(i).Node2 - 1).GetHROld(), Nodes(Elements(i).Node3 - 1).GetHROld(), Nodes(Elements(i).Node4 - 1).GetHROld())
    '        H_ele = he.getHe

    '        ' new program using nodal interpolations instead of mean value on elements to calculate diffusion coefficient 2020.08.15 Xuande
    '        Dim d1 As Double = GetDh(D0, alpha_0, Hc, Tc, H_ele(0))
    '        Dim d2 As Double = GetDh(D0, alpha_0, Hc, Tc, H_ele(1))
    '        Dim d3 As Double = GetDh(D0, alpha_0, Hc, Tc, H_ele(2))
    '        Dim d4 As Double = GetDh(D0, alpha_0, Hc, Tc, H_ele(3))
    '        cieNew = New CIETransNew(
    '                      Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
    '                      Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
    '                      Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
    '                      Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
    '                      d1, d2, d3, d4)
    '        AssembleKg(cieNew.getbe, bg, Elements, i)
    '        AssembleKg(cieNew.getAe, Ag, Elements, i)

    '    Next

    '    'step 3: now, we have assembled Hg_old, Ag and bg , to get LHS and RHS
    '    getLHS(LHS, NNodes, Ag, bg, dt)
    '    getRHS(R, NNodes, Ag, bg, dt)

    '    Dim HOld(NNodes - 1) As Double
    '    For i As Integer = 0 To NNodes - 1

    '        HOld(i) = Nodes(i).GetHROld()

    '    Next

    '    RHS = MultiplyMatrixWithVector(R, HOld)

    '    Dim HNew(NNodes - 1) As Double
    '    GetX(HNew, LHS, RHS)

    '    'step 4: result check
    '    For j As Integer = 0 To NNodes - 1
    '        If HNew(j) >= 1 Then
    '            HNew(j) = 1
    '        ElseIf HNew(j) <= 0 Then
    '            HNew(j) = 0
    '        End If
    '        Dim NbExpo As Integer = Nodes(j).NumExpo
    '        If NbExpo <> 0 Then

    '            'Dim DtExpo As Single = Expo(NbExpo).DtExpo
    '            HNew(j) = Expo(NbExpo).Humidite(CInt(ti)) / 100 ' check whether the current boundary is exposed to a boundary condition

    '        End If
    '        ''isotherm state check 
    '        If w = 0 And HNew(j) > HOld(j) Then 'state change from desorption to adsorption
    '            w = 1
    '        ElseIf w = 1 And HNew(j) < HOld(j) Then 'adsorption to desorption
    '            w = 0
    '        End If

    '        Dim SNew As Double = GetHtoS(HNew(j), type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
    '        Nodes(j).SetFieldsNew(HNew(j), SNew, wsat * SNew)

    '    Next
    'End Sub

    Public Sub setVariables(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans)
        For i_node As Integer = 0 To NNodes - 1
            Nodes(i_node).SetFieldsNewToOld()
        Next
    End Sub

    'flux , xuande 2020.08.28
    Public Sub setThermoFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans)
        For i_node As Integer = 0 To NNodes - 1
            Nodes(i_node).SetThermoFluxNewToOld()
        Next
    End Sub
    Public Sub setCapillaryFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans)
        For i_node As Integer = 0 To NNodes - 1
            Nodes(i_node).SetCapillaryFluxNewToOld()
        Next
    End Sub
    Public Sub setDiffusionFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans)
        For i_node As Integer = 0 To NNodes - 1
            Nodes(i_node).SetDiffusionFluxNewToOld()
        Next
    End Sub
    Public Sub setIonicFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans)
        For i_node As Integer = 0 To NNodes - 1
            Nodes(i_node).SetIonicFluxNewToOld()
        Next
    End Sub

    Public Sub updateVariableT(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef TNew() As Double, ByRef ti As Integer)
        Dim NbExpo As Integer
        Dim SNew As Double
        Dim HNew As Double
        Dim ClNew As Double
        For j As Integer = 0 To NNodes - 1
            NbExpo = Nodes(j).NumExpo
            SNew = Nodes(j).GetSNew()
            HNew = Nodes(j).GetHRNew()
            ClNew = Nodes(j).GetClNew()
            If Nodes(j).NumExpo <> 0 Then
                If Nodes(j).TypeExpo.Contains("Dirichlet") = True Then
                    TNew(j) = Expo(NbExpo).Temperature(CInt(ti))  ' check whether the current boundary is exposed to a boundary condition
                End If
            End If
            Nodes(j).SetFieldsNew(HNew, SNew, wsat * SNew, TNew(j), ClNew)
        Next
    End Sub
    Public Sub updateVariableH(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef HOld() As Double, ByRef HNew() As Double, ByRef ti As Integer)
        Dim NbExpo As Integer
        Dim SNew As Double
        Dim TNew As Double
        Dim ClNew As Double
        For j As Integer = 0 To NNodes - 1
            NbExpo = Nodes(j).NumExpo
            SNew = GetHtoS(HNew(j), type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
            TNew = Nodes(j).GetTNew()
            ClNew = Nodes(j).GetClNew()
            If HNew(j) >= 1 Then
                HNew(j) = 1
            ElseIf HNew(j) <= 0 Then
                HNew(j) = 0
            End If
            If Nodes(j).NumExpo <> 0 Then
                If Nodes(j).TypeExpo.Contains("Dirichlet") = True Then
                    HNew(j) = Expo(NbExpo).Humidite(CInt(ti)) / 100 ' check whether the current boundary is exposed to a boundary condition
                End If
            End If
            ''isotherm state check 
            If w = 0 And HNew(j) > HOld(j) Then 'state change from desorption to adsorption
                w = 1
            ElseIf w = 1 And HNew(j) < HOld(j) Then 'adsorption to desorption
                w = 0
            End If
            Nodes(j).SetFieldsNew(HNew(j), SNew, wsat * SNew, TNew, ClNew)
        Next
    End Sub
    Public Sub updateVariableS(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef SOld() As Double, ByRef SNew() As Double, ByRef Node_w() As Integer, ByRef ti As Integer)
        Dim NbExpo As Integer
        Dim HNew As Double
        Dim TNew As Double
        Dim ClNew As Double
        For j As Integer = 0 To NNodes - 1
            NbExpo = Nodes(j).NumExpo
            HNew = Nodes(j).GetHRNew()
            TNew = Nodes(j).GetTNew()
            ClNew = Nodes(j).GetClNew()
            If SNew(j) >= 1 Then
                SNew(j) = 1
            ElseIf SNew(j) <= 0 Then
                SNew(j) = 0
            End If
            If Nodes(j).NumExpo <> 0 Then
                If Nodes(j).TypeExpo.Contains("Dirichlet") = True Then
                    HNew = Expo(NbExpo).Humidite(CInt(ti)) / 100 ' check whether the current boundary is exposed to a boundary condition
                    SNew(j) = GetHtoS(HNew, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, Node_w(j))
                End If
            End If
            ''isotherm state check 
            If Node_w(j) = 0 And SNew(j) > SOld(j) Then 'state change from desorption to adsorption
                Node_w(j) = 1
            ElseIf Node_w(j) = 1 And SNew(j) < SOld(j) Then 'adsorption to desorption
                Node_w(j) = 0
            End If
            Nodes(j).SetFieldsNew(HNew, SNew(j), wsat * SNew(j), TNew, ClNew)
        Next
    End Sub

    'flux , xuande 2020.08.28
    Public Sub updateThermoFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef Jx_New() As Double, ByRef Jy_New() As Double)

        For j As Integer = 0 To NNodes - 1
            Nodes(j).SetThermoFluxNew(Jx_New(j), Jy_New(j))
        Next

    End Sub
    Public Sub updateCapillaryFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef Jx_New() As Double, ByRef Jy_New() As Double)

        For j As Integer = 0 To NNodes - 1
            Nodes(j).SetCapillaryFluxNew(Jx_New(j), Jy_New(j))
        Next

    End Sub
    Public Sub updateDiffusionFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef Jx_New() As Double, ByRef Jy_New() As Double)

        For j As Integer = 0 To NNodes - 1
            Nodes(j).SetDiffusionFluxNew(Jx_New(j), Jy_New(j))
        Next

    End Sub
    Public Sub updateIonicFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef Jx_New() As Double, ByRef Jy_New() As Double)

        For j As Integer = 0 To NNodes - 1
            Nodes(j).SetIonicFluxNew(Jx_New(j), Jy_New(j))
        Next

    End Sub

    Public Sub Postprocess(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef NElements As Integer, ByRef Elements() As ElementTrans, ByRef ti As Integer, ByRef Time() As Double)
        ''Post-process : plot 2D image and export result .txt file 
        Dim HRAvg, WAvg, SAvg, TAvg, ClAvg As Double
        For i As Integer = 0 To NElements - 1
            Elements(i).CalcFieldInElement(ti, Nodes)
        Next
        Time(ti) = ti * dt / 3600 ' Time in hour
        'compute variation
        UpdatediffAverage(Nodes, dH_avg, dw_avg, dS_avg, dT_avg, dCl_avg)
        If (ti * dt / T_sauv) = Int(ti * dt / T_sauv) And Int(ti * dt / T_sauv) > 0 Then ' check register time
            GetNewAverage(Nodes, HRAvg, WAvg, SAvg, TAvg, ClAvg)
            OutputFile.WriteHR(ti * dt, NNodes, dH_avg, HRAvg, Nodes)
            OutputFile.WriteW(ti * dt, NNodes, dw_avg, WAvg, Nodes)
            OutputFile.WriteS(ti * dt, NNodes, dS_avg, SAvg, Nodes)
            OutputFile.WriteT(ti * dt, NNodes, dT_avg, TAvg, Nodes)
            OutputFile.WriteCl(ti * dt, NNodes, dCl_avg, ClAvg, Nodes)
        End If
    End Sub
    Public Sub AssembleKg(ByRef ke(,) As Double, ByRef Kg(,) As Double, ByRef Elements() As ElementTrans, ElementNo As Integer)
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
    Public Sub AssembleVg(ByRef ve() As Double, ByRef Vg() As Double, ByRef Elements() As ElementTrans, ElementNo As Integer)
        Dim i As Integer
        Dim dofs() As Integer = {getDOF(Elements(ElementNo).Node1 - 1),
                                 getDOF(Elements(ElementNo).Node2 - 1),
                                 getDOF(Elements(ElementNo).Node3 - 1),
                                 getDOF(Elements(ElementNo).Node4 - 1)}
        Dim dofi As Integer
        For i = 0 To 3 'each dof of the Se
            dofi = dofs(i)
            Vg(dofi) = Vg(dofi) + ve(i)
        Next
    End Sub
    Public Sub DataMonitoring()

    End Sub
End Class

