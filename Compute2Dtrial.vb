Imports System.Data.SqlClient
Imports System.Linq
Public Class Compute2Dtrial
    Dim ServerName As String = "(LocalDB)\MSSQLLocalDB"
    Dim DatabaseName As String = "|DataDirectory|\TransChlorMat.mdf"

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
    Public F As Double = 96484.6 'Farady constant
    Public z_Na As Double = 1 'Na + valence number
    Public z_Cl As Double = -1 'Cl - ...
    Public z_K As Double = 1 'K + ...
    Public z_OH As Double = -1 'OH - ...
    Public z_Ca As Double = 2 'Ca 2+ ...
    Public z_SO4 As Double = -2 'SO4 2- ...
    'Computation parameters from input file (Eriture à l'ordre de lecture)
    Dim alpha As Double  'hydration degree(-)
    Dim w As Double 'indicator for isotherm curve (0 or 1, -)
    Dim H_int As Double  'initial relative humidity in the material (-)
    Dim T_int As Double  'initial temperature in the material (celcius degree C)

    Dim Na_int As Double  'initial Sodium concentration in the material, Xuande 2021.09.05
    Dim Cl_int As Double  'initial chloride concentration in the material
    Dim K_int As Double  'initial Potassium concentration in the material
    Dim OH_int As Double  'initial Hydroxide ion oncentration in the material
    Dim Ca_int As Double  'initial Calcium concentration in the material
    Dim SO4_int As Double  'initial Sulfate concentration in the material
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
    Dim OutputFile As OutputFile2D
    Dim dNa_avg As Double
    Dim dCl_avg As Double
    Dim dK_avg As Double
    Dim dOH_avg As Double
    Dim dCa_avg As Double
    Dim dSO4_avg As Double
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

        Input(nFic, Na_int) ' read initial ion concentrations
        Input(nFic, Cl_int)
        Input(nFic, K_int)
        Input(nFic, OH_int)
        Input(nFic, Ca_int)
        Input(nFic, SO4_int)

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

    Public Sub Compute_All(ByRef Frm As FrmTrans2D, ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef NElements As Integer,
                           ByRef Elements() As ElementTrans, ByRef Nodes() As NodeTrans, ByRef Time() As Double)
        OutputFile = New OutputFile2D(directory, 10, NNodes, Model)
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
                ' MultiIonic
                MultiIonic(Expo, NNodes, Nodes, NElements, Elements, ti)
            ElseIf Model = 1 Then
                '' HTC_new model
                ' Thermo
                Thermo(Expo, NNodes, Nodes, NElements, Elements, ti)
                ' Cap
                Cap(Expo, NNodes, Nodes, NElements, Elements, ti)
                ' MultiIonic
                MultiIonic(Expo, NNodes, Nodes, NElements, Elements, ti)
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
        Dim w_avg_0, H_avg_0, S_avg_0, T_avg_0, Na_avg_0, Cl_avg_0, K_avg_0, OH_avg_0, Ca_avg_0, SO4_avg_0 As Double
        Dim HNew As Double
        Dim SNew As Double
        Dim TNew As Double
        Dim S_int As Double
        Dim NaNew As Double 'Xuande, 2021.09.05
        Dim ClNew As Double
        Dim KNew As Double
        Dim OHNew As Double
        Dim CaNew As Double
        Dim SO4New As Double
        Dim HRAvg, WAvg, SAvg, TAvg, NaAvg, ClAvg, KAvg, OHAvg, CaAvg, SO4Avg As Double
        'apply initial field value to all nodes
        For i As Integer = 0 To NNodes - 1
            S_int = GetHtoS(H_int, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
            Nodes(i).SetFieldsNew(H_int, S_int, wsat * S_int, T_int, Na_int, Cl_int, K_int, OH_int, Ca_int, SO4_int)
            Nodes(i).SetFieldsNewToOld()
        Next
        FieldAverage(Nodes, H_avg_0, w_avg_0, S_avg_0, T_avg_0, Na_avg_0, Cl_avg_0, K_avg_0, OH_avg_0, Ca_avg_0, SO4_avg_0) ' Xuande 2021.09.03
        OutputFile.WriteLine(H_avg_0, w_avg_0, S_avg_0, T_avg_0, Na_avg_0, Cl_avg_0, K_avg_0, OH_avg_0, Ca_avg_0, SO4_avg_0)
        'plot initial state
        For i As Integer = 0 To NElements - 1
            Elements(i).ReDimFields(ind + 2)
            Elements(i).SetFields(0, Nodes(i).GetHRNew() * 100, Nodes(i).GetSNew() * 100, Nodes(i).GetTNew(), Nodes(i).GetNaNew(), Nodes(i).GetClNew(), Nodes(i).GetKNew(), Nodes(i).GetOHNew(), Nodes(i).GetCaNew(), Nodes(i).GetSO4New()) ' Xuande 2021.09.03
        Next
        'apply initial boundary condition to all nodes
        For i_node As Integer = 0 To NNodes - 1
            OutputFile.WriteFirstLine(Nodes(i_node).GetHROld(), Nodes(i_node).GetWOld(), Nodes(i_node).GetSOld(), Nodes(i_node).GetTOld(), Nodes(i_node).GetNaOld(), Nodes(i_node).GetClOld(), Nodes(i_node).GetKOld(), Nodes(i_node).GetOHOld(), Nodes(i_node).GetCaOld(), Nodes(i_node).GetSO4Old())
            If Nodes(i_node).TypeExpo.Contains("Dirichlet") Then
                HNew = Expo(Nodes(i_node).NumExpo).Humidite(0) / 100
                TNew = Expo(Nodes(i_node).NumExpo).Temperature(0)
                NaNew = Expo(Nodes(i_node).NumExpo).Conc_Na(0) ' Xuande 2021.09.03
                ClNew = Expo(Nodes(i_node).NumExpo).Conc_Cl(0)
                KNew = Expo(Nodes(i_node).NumExpo).Conc_K(0)
                OHNew = Expo(Nodes(i_node).NumExpo).Conc_OH(0)
                CaNew = Expo(Nodes(i_node).NumExpo).Conc_Ca(0)
                SO4New = Expo(Nodes(i_node).NumExpo).Conc_SO4(0)
            Else
                HNew = Nodes(i_node).GetHROld()
                TNew = Nodes(i_node).GetTOld()
                NaNew = Nodes(i_node).GetNaOld() ' Xuande 2021.09.03
                ClNew = Nodes(i_node).GetClOld()
                KNew = Nodes(i_node).GetKOld()
                OHNew = Nodes(i_node).GetOHOld()
                CaNew = Nodes(i_node).GetCaOld()
                SO4New = Nodes(i_node).GetSO4Old()
            End If
            SNew = GetHtoS(HNew, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
            Nodes(i_node).SetFieldsNew(HNew, SNew, wsat * SNew, TNew, NaNew, ClNew, KNew, OHNew, CaNew, SO4New)
        Next
        OutputFile.WriteBlankLine()
        'compute variation
        UpdatediffAverage(Nodes, dH_avg, dw_avg, dS_avg, dT_avg, dNa_avg, dCl_avg, dK_avg, dOH_avg, dCa_avg, dSO4_avg)
        GetNewAverage(Nodes, HRAvg, WAvg, SAvg, TAvg, NaAvg, ClAvg, KAvg, OHAvg, CaAvg, SO4Avg)
        'imagine BC is applied in very short time (dt/1000), then output the field variables with BC applied on it
        OutputFile.WriteFirstHR(dt / 1000.0, NNodes, dH_avg, HRAvg, Nodes)
        OutputFile.WriteW(dt / 1000.0, NNodes, dw_avg, WAvg, Nodes)
        OutputFile.WriteS(dt / 1000.0, NNodes, dS_avg, SAvg, Nodes)
        OutputFile.WriteT(dt / 1000.0, NNodes, dT_avg, TAvg, Nodes)
        OutputFile.WriteNa(dt / 1000.0, NNodes, dNa_avg, NaAvg, Nodes)
        OutputFile.WriteCl(dt / 1000.0, NNodes, dCl_avg, ClAvg, Nodes)
        OutputFile.WriteK(dt / 1000.0, NNodes, dK_avg, KAvg, Nodes)
        OutputFile.WriteOH(dt / 1000.0, NNodes, dOH_avg, OHAvg, Nodes)
        OutputFile.WriteCa(dt / 1000.0, NNodes, dCa_avg, CaAvg, Nodes)
        OutputFile.WriteSO4(dt / 1000.0, NNodes, dSO4_avg, SO4Avg, Nodes)
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
        'Parameter definition
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
    Public Sub MultiIonic(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef NElements As Integer, ByRef Elements() As ElementTrans, ByRef ti As Integer)
        ''Elemental and global matrix constructions and resolution  Xuande Chen. 2021.09.03 latest modifications
        'Parameter definition
        Dim wr = 100 'masse water content
        Dim R As Double = 8.3145 '(J/mol.K)
        Dim Mw As Double = 0.018 'molecular mass of water (kg/mol)
        Dim F As Double = 96484.6 'Farady constant
        Dim T = 298.15 'K
        Dim grad_logGamma = 0 'chemical activity coefficient
        Dim E As Double = 1400 'electric potential V/m
        Dim z_Na As Double = 1 'Na + valence number
        Dim z_Cl As Double = -1 'Cl - ...
        Dim z_K As Double = 1 'K + ...
        Dim z_OH As Double = -1 'OH - ...
        Dim z_Ca As Double = 2 'Ca 2+ ...
        Dim z_SO4 As Double = -2 'SO4 2- ...
        Dim D0_Na As Double = 0.00000000133 ' Na + diffusivity in free water,1.33e-9 m2/s
        Dim D0_Cl As Double = 0.00000000203 ' Cl - diffusivity in free water,2.03e-9 m2/s
        Dim D0_K As Double = 0.00000000196 ' K + diffusivity in free water,1.96e-9 m2/s
        Dim D0_OH As Double = 0.00000000527 ' OH - diffusivity in free water,5.27e-9 m2/s
        Dim D0_Ca As Double = 0.00000000079 ' Ca 2+ diffusivity in free water,0.79e-9 m2/s
        Dim D0_SO4 As Double = 0.00000000107 ' SO4 2- diffusivity in free water,0.79e-9 m2/s

        Dim tor As Double = 0.00049261 ' Material tortuosity

        Dim LHS1(,) As Double ' Na + 
        Dim R1(,) As Double
        Dim RHS1() As Double
        Dim bg1(NNodes - 1, NNodes - 1) As Double 'Global b matrix
        Dim Ag1(NNodes - 1, NNodes - 1) As Double 'Global A matrix
        Dim LHS2(,) As Double ' Cl - 
        Dim R2(,) As Double
        Dim RHS2() As Double
        Dim bg2(NNodes - 1, NNodes - 1) As Double 'Global b matrix
        Dim Ag2(NNodes - 1, NNodes - 1) As Double 'Global A matrix
        Dim LHS3(,) As Double ' K+
        Dim R3(,) As Double
        Dim RHS3() As Double
        Dim bg3(NNodes - 1, NNodes - 1) As Double 'Global b matrix
        Dim Ag3(NNodes - 1, NNodes - 1) As Double 'Global A matrix
        Dim LHS4(,) As Double
        Dim R4(,) As Double
        Dim RHS4() As Double
        Dim bg4(NNodes - 1, NNodes - 1) As Double 'Global b matrix
        Dim Ag4(NNodes - 1, NNodes - 1) As Double 'Global A matrix
        Dim LHS5(,) As Double
        Dim R5(,) As Double
        Dim RHS5() As Double
        Dim bg5(NNodes - 1, NNodes - 1) As Double 'Global b matrix
        Dim Ag5(NNodes - 1, NNodes - 1) As Double 'Global A matrix
        Dim LHS6(,) As Double
        Dim R6(,) As Double
        Dim RHS6() As Double
        Dim bg6(NNodes - 1, NNodes - 1) As Double 'Global b matrix
        Dim Ag6(NNodes - 1, NNodes - 1) As Double 'Global A matrix
        Dim J1X(NNodes - 1) As Double 'Global x flux vector of Na +
        Dim J1Y(NNodes - 1) As Double 'Global y flux vector Na +
        Dim J2X(NNodes - 1) As Double 'Global x flux vector of Cl -
        Dim J2Y(NNodes - 1) As Double 'Global y flux vector Cl -
        Dim J3X(NNodes - 1) As Double 'Global x flux vector of K + 
        Dim J3Y(NNodes - 1) As Double 'Global y flux vector K + 
        Dim J4X(NNodes - 1) As Double 'Global x flux vector of OH -
        Dim J4Y(NNodes - 1) As Double 'Global y flux vector OH -
        Dim J5X(NNodes - 1) As Double 'Global x flux vector of Ca 2+
        Dim J5Y(NNodes - 1) As Double 'Global y flux vector Ca 2+
        Dim J6X(NNodes - 1) As Double 'Global x flux vector of SO4 2-
        Dim J6Y(NNodes - 1) As Double 'Global y flux vector SO4 2-

        Dim cieNew1 As CIETrans_MI 'class Na+ concentration
        Dim cieNew2 As CIETrans_MI
        Dim cieNew3 As CIETrans_MI
        Dim cieNew4 As CIETrans_MI
        Dim cieNew5 As CIETrans_MI
        Dim cieNew6 As CIETrans_MI

        Dim Ce_1 As CETrans ' Na + concentration values at four nodes
        Dim Ce_2 As CETrans ' Cl - ...
        Dim Ce_3 As CETrans ' K + ...
        Dim Ce_4 As CETrans ' OH - ...
        Dim Ce_5 As CETrans ' Ca 2+ ...
        Dim Ce_6 As CETrans ' SO4 2- ...
        Dim C1_ele() As Double ' Na + concentration value over the element 
        Dim C2_ele() As Double ' Cl - ...
        Dim C3_ele() As Double ' K + ...
        Dim C4_ele() As Double ' OH - ...
        Dim C5_ele() As Double ' Ca 2+ ...
        Dim C6_ele() As Double ' SO4 2- ...
        Dim C1Old(NNodes - 1) As Double ' Old Na + concentration value over the domain
        Dim C1New(NNodes - 1) As Double ' New Na + concentration value over the domain
        Dim C2Old(NNodes - 1) As Double ' Old Cl - concentration value over the domain
        Dim C2New(NNodes - 1) As Double ' New Cl - concentration value over the domain
        Dim C3Old(NNodes - 1) As Double ' Old K + concentration value over the domain
        Dim C3New(NNodes - 1) As Double ' New K + concentration value over the domain.
        Dim C4Old(NNodes - 1) As Double ' Old OH - concentration value over the domain
        Dim C4New(NNodes - 1) As Double ' New OH - concentration value over the domain
        Dim C5Old(NNodes - 1) As Double ' Old Ca 2+ concentration value over the domain
        Dim C5New(NNodes - 1) As Double ' New Ca 2+ concentration value over the domain
        Dim C6Old(NNodes - 1) As Double ' Old SO4 2- concentration value over the domain
        Dim C6New(NNodes - 1) As Double ' New SO4 2- concentration value over the domain

        ''this is a test for crack coordinate input
        'Dim x_c1 As Double = -40
        'Dim y_c1 As Double = -8
        'Dim x_c2 As Double = -5
        'Dim y_c2 As Double = 0

        ''this is a test for non-crack coordinate input
        'Dim x_c1 As Double = -1000.0
        'Dim y_c1 As Double = -1000.0
        'Dim x_c2 As Double = -10000.0
        'Dim y_c2 As Double = -10000.0

        ''these are crack coordinates for UHPFRC Beam1-Vicky, test
        'Dim x_c1 As Double = -50
        'Dim y_c1 As Double = -0.2
        'Dim x_c2 As Double = -37
        'Dim y_c2 As Double = 0.2

        ''these are crack coordinates for UHPFRC Beam1-Vicky, for real simulation
        'Dim CR(10)(,) As Double
        'Dim mat_C1(1, 1) As Double
        'Dim mat_C2(1, 1) As Double
        'Dim mat_C3(1, 1) As Double
        'Dim mat_C4(1, 1) As Double
        'Dim mat_C5(1, 1) As Double
        'mat_C1 = {{-10, -1.45}, {-25.5, -26.25}} 'Crack 1 x and y coordinates
        'mat_C2 = {{-10, -3.9}, {-15.65, -15.25}} 'Crack 2 x and y coordinates
        'mat_C3 = {{-10, -4.9}, {-6.1, -6.0}} 'Crack 3 x and y coordinates
        'mat_C4 = {{-10, -1.9}, {18.75, 18.25}} 'Crack 4 x and y coordinates
        'mat_C5 = {{-10, -5.75}, {21.9, 21.85}} 'Crack 5 x and y coordinates

        'these are crack coordinates for UHPFRC Beam2-Vicky, for real simulation
        Dim CR(10)(,) As Double
        Dim mat_C1(1, 2) As Double
        Dim mat_C2(1, 1) As Double
        Dim mat_C3(1, 1) As Double
        Dim mat_C4(1, 3) As Double
        Dim mat_C5(1, 1) As Double
        Dim mat_C6(1, 1) As Double
        mat_C1 = {{-17.5, -5.8, 1.6}, {-26.5, -28.0, -27.26}} 'Crack 1 x and y coordinates
        mat_C2 = {{-17.5, -5.9}, {-22.2, -21.2}} 'Crack 2 x and y coordinates
        mat_C3 = {{-17.5, -7.0}, {-5.95, -6.45}} 'Crack 3 x and y coordinates
        mat_C4 = {{-17.5, -12.75, -10.0, -6.4}, {2.05, 1.3, 2.3, 1.92}} 'Crack 4 x and y coordinates
        mat_C5 = {{-17.5, -4.45}, {17.75, 16.25}} 'Crack 5 x and y coordinates
        mat_C6 = {{-17.5, -4.2}, {26.5, 25.3}} 'Crack 6 x and y coordinates

        'these are crack coordinates For UHPFRC Beam3-Vicky, for real simulation
        'Dim CR(10)(,) As Double
        'Dim mat_C1(1, 1) As Double
        'Dim mat_C2(1, 2) As Double
        'Dim mat_C3(1, 1) As Double
        'Dim mat_C4(1, 2) As Double
        'Dim mat_C5(1, 2) As Double
        'Dim mat_C6(1, 1) As Double
        'Dim mat_C7(1, 2) As Double
        'Dim mat_C8(1, 2) As Double
        'mat_C1 = {{-12.5, 3.5}, {-20.0, -21.4}} 'Crack 1 x and y coordinates
        'mat_C2 = {{-12.5, -3.9, 3.4}, {-14.6, -14.1, -15.8}} 'Crack 2 x and y coordinates
        'mat_C3 = {{-12.5, -3.9}, {-12.6, -14.12}} 'Crack 3 x and y coordinates
        'mat_C4 = {{-12.5, -6.5, 0.3}, {-5.1, -4.0, -4.0}} 'Crack 4 x and y coordinates
        'mat_C5 = {{-12.5, -4.75, 0.5}, {-2.25, -2.5, -1.75}} 'Crack 5 x and y coordinates
        'mat_C6 = {{-12.5, 3.0}, {2.6, 2.28}} 'Crack 6 x and y coordinates
        'mat_C7 = {{-12.5, -5.5, 2.8}, {5.8, 6.5, 5.0}} 'Crack 7 x and y coordinates
        'mat_C8 = {{-12.5, -5.5, -0.8}, {18.0, 18.0, 17.5}} 'Crack 8 x and y coordinates

        ''these are crack coordinates for UHPFRC Beam4-Vicky, for real simulation
        'Dim CR(10)(,) As Double
        'Dim mat_C1(1, 1) As Double
        'Dim mat_C2(1, 2) As Double
        'Dim mat_C3(1, 1) As Double
        'Dim mat_C4(1, 2) As Double
        'Dim mat_C5(1, 1) As Double
        'Dim mat_C6(1, 2) As Double
        'Dim mat_C7(1, 2) As Double
        'Dim mat_C8(1, 2) As Double
        'Dim mat_C9(1, 3) As Double
        'Dim mat_C10(1, 1) As Double
        'Dim mat_C11(1, 2) As Double
        'mat_C1 = {{-11.0, -0.05}, {-23.7, -23.75}} 'Crack 1 x and y coordinates
        'mat_C2 = {{-11.0, -4.2, 2.1}, {-19.7, -20.2, -20.2}} 'Crack 2 x and y coordinates
        'mat_C3 = {{-11.0, 1.6}, {-16.7, -16.7}} 'Crack 3 x and y coordinates
        'mat_C4 = {{-11.0, -4.0, 1.8}, {-12.0, -12.4, -13.6}} 'Crack 4 x and y coordinates
        'mat_C5 = {{-3.9, 2.8}, {-12.55, -11.05}} 'Crack 5 x and y coordinates
        'mat_C6 = {{-11.0, -6.5, 0.0}, {-9.55, -10.05, -8.85}} 'Crack 1 x and y coordinates
        'mat_C7 = {{-11.0, -2.5, 6.3}, {-5.05, -4.45, -2.45}} 'Crack 2 x and y coordinates
        'mat_C8 = {{1.1, -0.3, -0.05}, {-4.35, -3.05, -1.4}} 'Crack 3 x and y coordinates
        'mat_C9 = {{-11.0, -0.85, 3.65, 5.75}, {-0.65, -0.95, -0.05, -0.7}} 'Crack 4 x and y coordinates
        'mat_C10 = {{-11.0, 4.3}, {6.65, 8.25}} 'Crack 5 x and y coordinates
        'mat_C11 = {{-11.0, 0.3, 7.0}, {9.8, 9.9, 9.8}} 'Crack 5 x and y coordinates

        'store crack data information
        CR(0) = mat_C1
        CR(1) = mat_C2
        CR(2) = mat_C3
        CR(3) = mat_C4
        CR(4) = mat_C5
        CR(5) = mat_C6
        'CR(6) = mat_C7
        'CR(7) = mat_C8
        'CR(8) = mat_C9
        'CR(9) = mat_C10
        'CR(10) = mat_C11

        Dim tor_loc1 As Double
        Dim tor_loc2 As Double
        Dim tor_loc3 As Double
        Dim tor_loc4 As Double
        Dim x_c1 As Double
        Dim y_c1 As Double
        Dim x_c2 As Double
        Dim y_c2 As Double
        Dim f_cr As Double = 10 ' diffusivity multiplicator

        'Matrix assembling
        For i As Integer = 0 To NElements - 1
            Ce_1 = New CETrans(Nodes(Elements(i).Node1 - 1).GetNaOld(), Nodes(Elements(i).Node2 - 1).GetNaOld(), Nodes(Elements(i).Node3 - 1).GetNaOld(), Nodes(Elements(i).Node4 - 1).GetNaOld()) 'Na+ concentration
            Ce_2 = New CETrans(Nodes(Elements(i).Node1 - 1).GetClOld(), Nodes(Elements(i).Node2 - 1).GetClOld(), Nodes(Elements(i).Node3 - 1).GetClOld(), Nodes(Elements(i).Node4 - 1).GetClOld()) 'Cl -
            Ce_3 = New CETrans(Nodes(Elements(i).Node1 - 1).GetKOld(), Nodes(Elements(i).Node2 - 1).GetKOld(), Nodes(Elements(i).Node3 - 1).GetKOld(), Nodes(Elements(i).Node4 - 1).GetKOld()) 'K +
            Ce_4 = New CETrans(Nodes(Elements(i).Node1 - 1).GetOHOld(), Nodes(Elements(i).Node2 - 1).GetOHOld(), Nodes(Elements(i).Node3 - 1).GetOHOld(), Nodes(Elements(i).Node4 - 1).GetOHOld()) 'OH -
            Ce_5 = New CETrans(Nodes(Elements(i).Node1 - 1).GetCaOld(), Nodes(Elements(i).Node2 - 1).GetCaOld(), Nodes(Elements(i).Node3 - 1).GetCaOld(), Nodes(Elements(i).Node4 - 1).GetCaOld()) 'Ca 2+
            Ce_6 = New CETrans(Nodes(Elements(i).Node1 - 1).GetSO4Old(), Nodes(Elements(i).Node2 - 1).GetSO4Old(), Nodes(Elements(i).Node3 - 1).GetSO4Old(), Nodes(Elements(i).Node4 - 1).GetSO4Old()) 'SO4 2-
            C1_ele = Ce_1.getCe
            C2_ele = Ce_2.getCe
            C3_ele = Ce_3.getCe
            C4_ele = Ce_4.getCe
            C5_ele = Ce_5.getCe
            C6_ele = Ce_6.getCe

            'Damage detection program. Xuande, 2021.09.10
            '1) Get node coordinates and crack coordiantes
            Dim x1 As Double = Nodes(Elements(i).Node1 - 1).x
            Dim y1 As Double = Nodes(Elements(i).Node1 - 1).y
            Dim x2 As Double = Nodes(Elements(i).Node2 - 1).x
            Dim y2 As Double = Nodes(Elements(i).Node2 - 1).y
            Dim x3 As Double = Nodes(Elements(i).Node3 - 1).x
            Dim y3 As Double = Nodes(Elements(i).Node3 - 1).y
            Dim x4 As Double = Nodes(Elements(i).Node4 - 1).x
            Dim y4 As Double = Nodes(Elements(i).Node4 - 1).y

            Dim xmin As Double = Math.Min(x1, x2)
            xmin = Math.Min(xmin, x3)
            xmin = Math.Min(xmin, x4)
            Dim xmax As Double = Math.Max(x1, x2)
            xmax = Math.Max(xmax, x3)
            xmax = Math.Max(xmax, x4)
            Dim ymin As Double = Math.Min(y1, y2)
            ymin = Math.Min(ymin, y3)
            ymin = Math.Min(ymin, y4)
            Dim ymax As Double = Math.Max(y1, y2)
            ymax = Math.Max(ymax, y3)
            ymax = Math.Max(ymax, y4)

            'Dim Ind_cr As Integer ' crack detection indicator

            Dim Bool1 As Boolean
            Dim Bool2 As Boolean
            Dim Bool3 As Boolean
            Dim Bool4 As Boolean
            Dim Bool_cr1 As Boolean
            Dim Bool_cr2 As Boolean
            Dim Bool_cr3 As Boolean
            Dim Bool_cr4 As Boolean
            Dim cr_node1 As Integer ' node marker for cracks
            Dim cr_node2 As Integer
            Dim cr_node3 As Integer
            Dim cr_node4 As Integer

            '2) Cycle through all cracks and all element nodes
            For k_cr As Integer = 0 To 5 'No.crack 
                Dim poly_count = CR(k_cr).GetLength(1) 'find number of colummns
                For i_cd As Integer = 0 To poly_count - 2 'Polyline count
                    x_c1 = CR(k_cr)(0, i_cd)
                    y_c1 = CR(k_cr)(1, i_cd)
                    x_c2 = CR(k_cr)(0, i_cd + 1)
                    y_c2 = CR(k_cr)(1, i_cd + 1)
                    Dim a_cr As Double = Get_Crline_a(x_c1, x_c2, y_c1, y_c2)
                    Dim b_cr As Double = Get_Crline_b(x_c1, x_c2, y_c1, y_c2)
                    Dim m_p1 As Double = Get_Pline_m(a_cr)
                    Dim n_p1 As Double = Get_Pline_n(x1, y1, m_p1)
                    Dim m_p2 As Double = Get_Pline_m(a_cr)
                    Dim n_p2 As Double = Get_Pline_n(x2, y2, m_p2)
                    Dim m_p3 As Double = Get_Pline_m(a_cr)
                    Dim n_p3 As Double = Get_Pline_n(x3, y3, m_p3)
                    Dim m_p4 As Double = Get_Pline_m(a_cr)
                    Dim n_p4 As Double = Get_Pline_n(x4, y4, m_p4)

                    Dim xG1 As Double = Get_xG(a_cr, b_cr, m_p1, n_p1)
                    Dim yG1 As Double = Get_yG(a_cr, b_cr, m_p1, n_p1)
                    Dim xG2 As Double = Get_xG(a_cr, b_cr, m_p2, n_p2)
                    Dim yG2 As Double = Get_yG(a_cr, b_cr, m_p2, n_p2)
                    Dim xG3 As Double = Get_xG(a_cr, b_cr, m_p3, n_p3)
                    Dim yG3 As Double = Get_yG(a_cr, b_cr, m_p3, n_p3)
                    Dim xG4 As Double = Get_xG(a_cr, b_cr, m_p4, n_p4)
                    Dim yG4 As Double = Get_yG(a_cr, b_cr, m_p4, n_p4)

                    'First verification, is the cross point inside the element?
                    Bool1 = Loc_Detect(xmin, xmax, ymin, ymax, xG1, yG1)
                    'Second verification, is the cross point also on the crack/?
                    Bool_cr1 = Point_Detect(x_c1, y_c1, x_c2, y_c2, xG1, yG1)
                    'Bool_cr1 = True
                    Bool1 = Bool1 And Bool_cr1
                    If (Bool1 = True) And (cr_node1 <> 1) Then
                        cr_node1 = 1
                    End If

                    Bool2 = Loc_Detect(xmin, xmax, ymin, ymax, xG2, yG2)
                    Bool_cr2 = Point_Detect(x_c1, y_c1, x_c2, y_c2, xG2, yG2)
                    'Bool_cr2 = True
                    Bool2 = Bool2 And Bool_cr2
                    If (Bool2 = True) And (cr_node2 <> 1) Then
                        cr_node2 = 1
                    End If

                    Bool3 = Loc_Detect(xmin, xmax, ymin, ymax, xG3, yG3)
                    Bool_cr3 = Point_Detect(x_c1, y_c1, x_c2, y_c2, xG3, yG3)
                    'Bool_cr3 = True
                    Bool3 = Bool3 And Bool_cr3
                    If (Bool3 = True) And (cr_node3 <> 1) Then
                        cr_node3 = 1
                    End If

                    Bool4 = Loc_Detect(xmin, xmax, ymin, ymax, xG4, yG4)
                    Bool_cr4 = Point_Detect(x_c1, y_c1, x_c2, y_c2, xG4, yG4)
                    'Bool_cr4 = True
                    Bool4 = Bool4 And Bool_cr4
                    If (Bool4 = True) And (cr_node4 <> 1) Then
                        cr_node4 = 1
                    End If
                Next
            Next
            '2.5) Apply diffusivity on crack (each node)
            If cr_node1 = 1 Then
                tor_loc1 = tor * f_cr
            Else
                tor_loc1 = tor
            End If

            If cr_node2 = 1 Then
                tor_loc2 = tor * f_cr
            Else
                tor_loc2 = tor
            End If

            If cr_node3 = 1 Then
                tor_loc3 = tor * f_cr
            Else
                tor_loc3 = tor
            End If

            If cr_node4 = 1 Then
                tor_loc4 = tor * f_cr
            Else
                tor_loc4 = tor
            End If

            'new program using nodal interpolations instead of mean value on elements to calculate diffusion coefficient 2021.09.03 Xuande
            Dim d_C1_1 As Double = GetD_MI(D0_Na, tor_loc1) ' Xuande, 2021.09.03 nodal Na + concentrations
            Dim d_C1_2 As Double = GetD_MI(D0_Na, tor_loc2)
            Dim d_C1_3 As Double = GetD_MI(D0_Na, tor_loc3)
            Dim d_C1_4 As Double = GetD_MI(D0_Na, tor_loc4)
            cieNew1 = New CIETrans_MI(
                              Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
                              Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
                              Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
                              Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
                              d_C1_1, d_C1_2, d_C1_3, d_C1_4, wr, F, z_Na, E, R, T, grad_logGamma)

            Dim d_C2_1 As Double = GetD_MI(D0_Cl, tor_loc1) ' Xuande, 2021.09.03 nodal Cl - concentrations
            Dim d_C2_2 As Double = GetD_MI(D0_Cl, tor_loc2)
            Dim d_C2_3 As Double = GetD_MI(D0_Cl, tor_loc3)
            Dim d_C2_4 As Double = GetD_MI(D0_Cl, tor_loc4)
            cieNew2 = New CIETrans_MI(
                              Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
                              Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
                              Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
                              Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
                              d_C2_1, d_C2_2, d_C2_3, d_C2_4, wr, F, z_Cl, E, R, T, grad_logGamma)

            Dim d_C3_1 As Double = GetD_MI(D0_K, tor_loc1) ' Xuande, 2021.09.03 nodal K + concentrations
            Dim d_C3_2 As Double = GetD_MI(D0_K, tor_loc2)
            Dim d_C3_3 As Double = GetD_MI(D0_K, tor_loc3)
            Dim d_C3_4 As Double = GetD_MI(D0_K, tor_loc4)
            cieNew3 = New CIETrans_MI(
                              Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
                              Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
                              Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
                              Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
                              d_C3_1, d_C3_2, d_C3_3, d_C3_4, wr, F, z_K, E, R, T, grad_logGamma)

            Dim d_C4_1 As Double = GetD_MI(D0_OH, tor_loc1) ' Xuande, 2021.09.03 nodal OH - concentrations
            Dim d_C4_2 As Double = GetD_MI(D0_OH, tor_loc2)
            Dim d_C4_3 As Double = GetD_MI(D0_OH, tor_loc3)
            Dim d_C4_4 As Double = GetD_MI(D0_OH, tor_loc4)
            cieNew4 = New CIETrans_MI(
                              Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
                              Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
                              Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
                              Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
                              d_C4_1, d_C4_2, d_C4_3, d_C4_4, wr, F, z_OH, E, R, T, grad_logGamma)

            Dim d_C5_1 As Double = GetD_MI(D0_Ca, tor_loc1) ' Xuande, 2021.09.03 nodal Ca 2+ concentrations
            Dim d_C5_2 As Double = GetD_MI(D0_Ca, tor_loc2)
            Dim d_C5_3 As Double = GetD_MI(D0_Ca, tor_loc3)
            Dim d_C5_4 As Double = GetD_MI(D0_Ca, tor_loc4)
            cieNew5 = New CIETrans_MI(
                              Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
                              Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
                              Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
                              Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
                              d_C5_1, d_C5_2, d_C5_3, d_C5_4, wr, F, z_Ca, E, R, T, grad_logGamma)

            Dim d_C6_1 As Double = GetD_MI(D0_SO4, tor_loc1) ' Xuande, 2021.09.03 nodal SO4 2- concentrations
            Dim d_C6_2 As Double = GetD_MI(D0_SO4, tor_loc2)
            Dim d_C6_3 As Double = GetD_MI(D0_SO4, tor_loc3)
            Dim d_C6_4 As Double = GetD_MI(D0_SO4, tor_loc4)
            cieNew6 = New CIETrans_MI(
                              Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
                              Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
                              Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
                              Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
                              d_C6_1, d_C6_2, d_C6_3, d_C6_4, wr, F, z_SO4, E, R, T, grad_logGamma)

            'flux Na + and matrix assembling, xuande 2021.09.03
            Dim J1_C1_inv As Double(,) = cieNew1.GetInversedJac(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J2_C1_inv As Double(,) = cieNew1.GetInversedJac(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J3_C1_inv As Double(,) = cieNew1.GetInversedJac(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim J4_C1_inv As Double(,) = cieNew1.GetInversedJac(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim D_C1_mat1 As Double(,) = cieNew1.getDmat(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim D_C1_mat2 As Double(,) = cieNew1.getDmat(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim D_C1_mat3 As Double(,) = cieNew1.getDmat(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim D_C1_mat4 As Double(,) = cieNew1.getDmat(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim flux_C1_x1 As Double = cieNew1.getXFlux(D_C1_mat1(0, 0), C1_ele, J1_C1_inv, cieNew1.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C1_x2 As Double = cieNew1.getXFlux(D_C1_mat2(0, 0), C1_ele, J2_C1_inv, cieNew1.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C1_x3 As Double = cieNew1.getXFlux(D_C1_mat3(0, 0), C1_ele, J3_C1_inv, cieNew1.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C1_x4 As Double = cieNew1.getXFlux(D_C1_mat4(0, 0), C1_ele, J4_C1_inv, cieNew1.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C1_y1 As Double = cieNew1.getYFlux(D_C1_mat1(1, 1), C1_ele, J1_C1_inv, cieNew1.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C1_y2 As Double = cieNew1.getYFlux(D_C1_mat2(1, 1), C1_ele, J2_C1_inv, cieNew1.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C1_y3 As Double = cieNew1.getYFlux(D_C1_mat3(1, 1), C1_ele, J3_C1_inv, cieNew1.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C1_y4 As Double = cieNew1.getYFlux(D_C1_mat4(1, 1), C1_ele, J4_C1_inv, cieNew1.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim vec_flux_C1X As Double() = getve(flux_C1_x1, flux_C1_x2, flux_C1_x3, flux_C1_x4)
            Dim vec_flux_C1Y As Double() = getve(flux_C1_y1, flux_C1_y2, flux_C1_y3, flux_C1_y4)
            AssembleVg(vec_flux_C1X, J1X, Elements, i)
            AssembleVg(vec_flux_C1Y, J1Y, Elements, i)
            AssembleKg(cieNew1.getbe_MI, bg1, Elements, i)
            AssembleKg(cieNew1.getAe_MI, Ag1, Elements, i)
            'flux Cl - and matrix assembling, xuande 2021.09.03
            Dim J1_C2_inv As Double(,) = cieNew2.GetInversedJac(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J2_C2_inv As Double(,) = cieNew2.GetInversedJac(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J3_C2_inv As Double(,) = cieNew2.GetInversedJac(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim J4_C2_inv As Double(,) = cieNew2.GetInversedJac(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim D_C2_mat1 As Double(,) = cieNew2.getDmat(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim D_C2_mat2 As Double(,) = cieNew2.getDmat(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim D_C2_mat3 As Double(,) = cieNew2.getDmat(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim D_C2_mat4 As Double(,) = cieNew2.getDmat(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim flux_C2_x1 As Double = cieNew2.getXFlux(D_C2_mat1(0, 0), C2_ele, J1_C2_inv, cieNew2.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C2_x2 As Double = cieNew2.getXFlux(D_C2_mat2(0, 0), C2_ele, J2_C2_inv, cieNew2.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C2_x3 As Double = cieNew2.getXFlux(D_C2_mat3(0, 0), C2_ele, J3_C2_inv, cieNew2.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C2_x4 As Double = cieNew2.getXFlux(D_C2_mat4(0, 0), C2_ele, J4_C2_inv, cieNew2.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C2_y1 As Double = cieNew2.getYFlux(D_C2_mat1(1, 1), C2_ele, J1_C2_inv, cieNew2.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C2_y2 As Double = cieNew2.getYFlux(D_C2_mat2(1, 1), C2_ele, J2_C2_inv, cieNew2.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C2_y3 As Double = cieNew2.getYFlux(D_C2_mat3(1, 1), C2_ele, J3_C2_inv, cieNew2.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C2_y4 As Double = cieNew2.getYFlux(D_C2_mat4(1, 1), C2_ele, J4_C2_inv, cieNew2.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim vec_flux_C2X As Double() = getve(flux_C2_x1, flux_C2_x2, flux_C2_x3, flux_C2_x4)
            Dim vec_flux_C2Y As Double() = getve(flux_C2_y1, flux_C2_y2, flux_C2_y3, flux_C2_y4)
            AssembleVg(vec_flux_C2X, J2X, Elements, i)
            AssembleVg(vec_flux_C2Y, J2Y, Elements, i)
            AssembleKg(cieNew2.getbe_MI, bg2, Elements, i)
            AssembleKg(cieNew2.getAe_MI, Ag2, Elements, i)
            'flux K + and matrix assembling, xuande 2021.09.03
            Dim J1_C3_inv As Double(,) = cieNew3.GetInversedJac(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J2_C3_inv As Double(,) = cieNew3.GetInversedJac(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J3_C3_inv As Double(,) = cieNew3.GetInversedJac(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim J4_C3_inv As Double(,) = cieNew3.GetInversedJac(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim D_C3_mat1 As Double(,) = cieNew3.getDmat(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim D_C3_mat2 As Double(,) = cieNew3.getDmat(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim D_C3_mat3 As Double(,) = cieNew3.getDmat(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim D_C3_mat4 As Double(,) = cieNew3.getDmat(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim flux_C3_x1 As Double = cieNew3.getXFlux(D_C3_mat1(0, 0), C3_ele, J1_C3_inv, cieNew3.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C3_x2 As Double = cieNew3.getXFlux(D_C3_mat2(0, 0), C3_ele, J2_C3_inv, cieNew3.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C3_x3 As Double = cieNew3.getXFlux(D_C3_mat3(0, 0), C3_ele, J3_C3_inv, cieNew3.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C3_x4 As Double = cieNew3.getXFlux(D_C3_mat4(0, 0), C3_ele, J4_C3_inv, cieNew3.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C3_y1 As Double = cieNew3.getYFlux(D_C3_mat1(1, 1), C3_ele, J1_C3_inv, cieNew3.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C3_y2 As Double = cieNew3.getYFlux(D_C3_mat2(1, 1), C3_ele, J2_C3_inv, cieNew3.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C3_y3 As Double = cieNew3.getYFlux(D_C3_mat3(1, 1), C3_ele, J3_C3_inv, cieNew3.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C3_y4 As Double = cieNew3.getYFlux(D_C3_mat4(1, 1), C3_ele, J4_C3_inv, cieNew3.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim vec_flux_C3X As Double() = getve(flux_C3_x1, flux_C3_x2, flux_C3_x3, flux_C3_x4)
            Dim vec_flux_C3Y As Double() = getve(flux_C3_y1, flux_C3_y2, flux_C3_y3, flux_C3_y4)
            AssembleVg(vec_flux_C3X, J3X, Elements, i)
            AssembleVg(vec_flux_C3Y, J3Y, Elements, i)
            AssembleKg(cieNew3.getbe_MI, bg3, Elements, i)
            AssembleKg(cieNew3.getAe_MI, Ag3, Elements, i)
            'flux OH - and matrix assembling, xuande 2021.09.03
            Dim J1_C4_inv As Double(,) = cieNew4.GetInversedJac(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J2_C4_inv As Double(,) = cieNew4.GetInversedJac(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J3_C4_inv As Double(,) = cieNew4.GetInversedJac(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim J4_C4_inv As Double(,) = cieNew4.GetInversedJac(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim D_C4_mat1 As Double(,) = cieNew4.getDmat(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim D_C4_mat2 As Double(,) = cieNew4.getDmat(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim D_C4_mat3 As Double(,) = cieNew4.getDmat(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim D_C4_mat4 As Double(,) = cieNew4.getDmat(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim flux_C4_x1 As Double = cieNew4.getXFlux(D_C4_mat1(0, 0), C4_ele, J1_C4_inv, cieNew4.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C4_x2 As Double = cieNew4.getXFlux(D_C4_mat2(0, 0), C4_ele, J2_C4_inv, cieNew4.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C4_x3 As Double = cieNew4.getXFlux(D_C4_mat3(0, 0), C4_ele, J3_C4_inv, cieNew4.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C4_x4 As Double = cieNew4.getXFlux(D_C4_mat4(0, 0), C4_ele, J4_C4_inv, cieNew4.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C4_y1 As Double = cieNew4.getYFlux(D_C4_mat1(1, 1), C4_ele, J1_C4_inv, cieNew4.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C4_y2 As Double = cieNew4.getYFlux(D_C4_mat2(1, 1), C4_ele, J2_C4_inv, cieNew4.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C4_y3 As Double = cieNew4.getYFlux(D_C4_mat3(1, 1), C4_ele, J3_C4_inv, cieNew4.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C4_y4 As Double = cieNew4.getYFlux(D_C4_mat4(1, 1), C4_ele, J4_C4_inv, cieNew4.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim vec_flux_C4X As Double() = getve(flux_C4_x1, flux_C4_x2, flux_C4_x3, flux_C4_x4)
            Dim vec_flux_C4Y As Double() = getve(flux_C4_y1, flux_C4_y2, flux_C4_y3, flux_C4_y4)
            AssembleVg(vec_flux_C4X, J4X, Elements, i)
            AssembleVg(vec_flux_C4Y, J4Y, Elements, i)
            AssembleKg(cieNew4.getbe_MI, bg4, Elements, i)
            AssembleKg(cieNew4.getAe_MI, Ag4, Elements, i)
            'flux Ca 2+ and matrix assembling, xuande 2021.09.03
            Dim J1_C5_inv As Double(,) = cieNew5.GetInversedJac(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J2_C5_inv As Double(,) = cieNew5.GetInversedJac(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J3_C5_inv As Double(,) = cieNew5.GetInversedJac(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim J4_C5_inv As Double(,) = cieNew5.GetInversedJac(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim D_C5_mat1 As Double(,) = cieNew5.getDmat(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim D_C5_mat2 As Double(,) = cieNew5.getDmat(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim D_C5_mat3 As Double(,) = cieNew5.getDmat(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim D_C5_mat4 As Double(,) = cieNew5.getDmat(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim flux_C5_x1 As Double = cieNew5.getXFlux(D_C5_mat1(0, 0), C5_ele, J1_C5_inv, cieNew5.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C5_x2 As Double = cieNew5.getXFlux(D_C5_mat2(0, 0), C5_ele, J2_C5_inv, cieNew5.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C5_x3 As Double = cieNew5.getXFlux(D_C5_mat3(0, 0), C5_ele, J3_C5_inv, cieNew5.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C5_x4 As Double = cieNew5.getXFlux(D_C5_mat4(0, 0), C5_ele, J4_C5_inv, cieNew5.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C5_y1 As Double = cieNew5.getYFlux(D_C5_mat1(1, 1), C5_ele, J1_C5_inv, cieNew5.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C5_y2 As Double = cieNew5.getYFlux(D_C5_mat2(1, 1), C5_ele, J2_C5_inv, cieNew5.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C5_y3 As Double = cieNew5.getYFlux(D_C5_mat3(1, 1), C5_ele, J3_C5_inv, cieNew5.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C5_y4 As Double = cieNew5.getYFlux(D_C5_mat4(1, 1), C5_ele, J4_C5_inv, cieNew5.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim vec_flux_C5X As Double() = getve(flux_C5_x1, flux_C5_x2, flux_C5_x3, flux_C5_x4)
            Dim vec_flux_C5Y As Double() = getve(flux_C5_y1, flux_C5_y2, flux_C5_y3, flux_C5_y4)
            AssembleVg(vec_flux_C5X, J5X, Elements, i)
            AssembleVg(vec_flux_C5Y, J5Y, Elements, i)
            AssembleKg(cieNew5.getbe_MI, bg5, Elements, i)
            AssembleKg(cieNew5.getAe_MI, Ag5, Elements, i)
            'flux SO4 2- and matrix assembling, xuande 2021.09.03
            Dim J1_C6_inv As Double(,) = cieNew6.GetInversedJac(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J2_C6_inv As Double(,) = cieNew6.GetInversedJac(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim J3_C6_inv As Double(,) = cieNew6.GetInversedJac(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim J4_C6_inv As Double(,) = cieNew6.GetInversedJac(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim D_C6_mat1 As Double(,) = cieNew6.getDmat(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim D_C6_mat2 As Double(,) = cieNew6.getDmat(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
            Dim D_C6_mat3 As Double(,) = cieNew6.getDmat(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim D_C6_mat4 As Double(,) = cieNew6.getDmat(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
            Dim flux_C6_x1 As Double = cieNew6.getXFlux(D_C6_mat1(0, 0), C6_ele, J1_C6_inv, cieNew6.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C6_x2 As Double = cieNew6.getXFlux(D_C6_mat2(0, 0), C6_ele, J2_C6_inv, cieNew6.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C6_x3 As Double = cieNew6.getXFlux(D_C6_mat3(0, 0), C6_ele, J3_C6_inv, cieNew6.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C6_x4 As Double = cieNew6.getXFlux(D_C6_mat4(0, 0), C6_ele, J4_C6_inv, cieNew6.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C6_y1 As Double = cieNew6.getYFlux(D_C6_mat1(1, 1), C6_ele, J1_C6_inv, cieNew6.getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C6_y2 As Double = cieNew6.getYFlux(D_C6_mat2(1, 1), C6_ele, J2_C6_inv, cieNew6.getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3)))
            Dim flux_C6_y3 As Double = cieNew6.getYFlux(D_C6_mat3(1, 1), C6_ele, J3_C6_inv, cieNew6.getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim flux_C6_y4 As Double = cieNew6.getYFlux(D_C6_mat4(1, 1), C6_ele, J4_C6_inv, cieNew6.getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)))
            Dim vec_flux_C6X As Double() = getve(flux_C6_x1, flux_C6_x2, flux_C6_x3, flux_C6_x4)
            Dim vec_flux_C6Y As Double() = getve(flux_C6_y1, flux_C6_y2, flux_C6_y3, flux_C6_y4)
            AssembleVg(vec_flux_C6X, J6X, Elements, i)
            AssembleVg(vec_flux_C6Y, J6Y, Elements, i)
            AssembleKg(cieNew6.getbe_MI, bg6, Elements, i)
            AssembleKg(cieNew6.getAe_MI, Ag6, Elements, i)
        Next
        ' Now, we have assembled C1-C6, Ag1-Ag6 and bg1-bg6, get LHS1-LHS and RHS1-RHS6 and resolve the linear matrix system.
        getLHS_MI(LHS1, NNodes, Ag1, bg1, dt)
        getLHS_MI(LHS2, NNodes, Ag2, bg2, dt)
        getLHS_MI(LHS3, NNodes, Ag3, bg3, dt)
        getLHS_MI(LHS4, NNodes, Ag4, bg4, dt)
        getLHS_MI(LHS5, NNodes, Ag5, bg5, dt)
        getLHS_MI(LHS6, NNodes, Ag6, bg6, dt)
        getR_MI(R1, NNodes, Ag1, bg1, dt)
        getR_MI(R2, NNodes, Ag2, bg2, dt)
        getR_MI(R3, NNodes, Ag3, bg3, dt)
        getR_MI(R4, NNodes, Ag4, bg4, dt)
        getR_MI(R5, NNodes, Ag5, bg5, dt)
        getR_MI(R6, NNodes, Ag6, bg6, dt)
        For i As Integer = 0 To NNodes - 1
            C1Old(i) = Nodes(i).GetNaOld()
            C2Old(i) = Nodes(i).GetClOld()
            C3Old(i) = Nodes(i).GetKOld()
            C4Old(i) = Nodes(i).GetOHOld()
            C5Old(i) = Nodes(i).GetCaOld()
            C6Old(i) = Nodes(i).GetSO4Old()
        Next
        RHS1 = MultiplyMatrixWithVector(R1, C1Old)
        RHS2 = MultiplyMatrixWithVector(R2, C2Old)
        RHS3 = MultiplyMatrixWithVector(R3, C3Old)
        RHS4 = MultiplyMatrixWithVector(R4, C4Old)
        RHS5 = MultiplyMatrixWithVector(R5, C5Old)
        RHS6 = MultiplyMatrixWithVector(R6, C6Old)
        ' Solve the matrixes
        GetX(C1New, LHS1, RHS1)
        GetX(C2New, LHS2, RHS2)
        GetX(C3New, LHS3, RHS3)
        GetX(C4New, LHS4, RHS4)
        GetX(C5New, LHS5, RHS5)
        GetX(C6New, LHS6, RHS6)
        ' Result check and update
        updateVariableC(Expo, NNodes, Nodes, C1New, C2New, C3New, C4New, C5New, C6New, ti)
        updateNaFlux(NNodes, Nodes, J1X, J1Y)
        updateClFlux(NNodes, Nodes, J2X, J2Y)
        updateKFlux(NNodes, Nodes, J3X, J3Y)
        updateOHFlux(NNodes, Nodes, J4X, J4Y)
        updateCaFlux(NNodes, Nodes, J5X, J5Y)
        updateSO4Flux(NNodes, Nodes, J6X, J6Y)

    End Sub
    Public Sub setVariables(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans)
        For i_node As Integer = 0 To NNodes - 1
            Nodes(i_node).SetFieldsNewToOld()
        Next
    End Sub
    'set initial flux , xuande 2020.08.28
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
    Public Sub setNaFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans)
        For i_node As Integer = 0 To NNodes - 1
            Nodes(i_node).SetNaFluxNewToOld()
        Next
    End Sub
    Public Sub setClFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans)
        For i_node As Integer = 0 To NNodes - 1
            Nodes(i_node).SetClFluxNewToOld()
        Next
    End Sub
    Public Sub setKFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans)
        For i_node As Integer = 0 To NNodes - 1
            Nodes(i_node).SetKFluxNewToOld()
        Next
    End Sub
    Public Sub setOHFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans)
        For i_node As Integer = 0 To NNodes - 1
            Nodes(i_node).SetOHFluxNewToOld()
        Next
    End Sub
    Public Sub setCaFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans)
        For i_node As Integer = 0 To NNodes - 1
            Nodes(i_node).SetCaFluxNewToOld()
        Next
    End Sub
    Public Sub setSO4Flux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans)
        For i_node As Integer = 0 To NNodes - 1
            Nodes(i_node).SetSO4FluxNewToOld()
        Next
    End Sub
    Public Sub updateVariableT(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef TNew() As Double, ByRef ti As Integer)
        Dim NbExpo As Integer
        Dim SNew As Double
        Dim HNew As Double
        Dim NaNew As Double
        Dim ClNew As Double
        Dim KNew As Double
        Dim OHNew As Double
        Dim CaNew As Double
        Dim SO4New As Double
        For j As Integer = 0 To NNodes - 1
            NbExpo = Nodes(j).NumExpo
            SNew = Nodes(j).GetSNew()
            HNew = Nodes(j).GetHRNew()
            NaNew = Nodes(j).GetNaNew()
            ClNew = Nodes(j).GetClNew()
            KNew = Nodes(j).GetKNew()
            OHNew = Nodes(j).GetOHNew()
            CaNew = Nodes(j).GetCaNew()
            SO4New = Nodes(j).GetSO4New()
            If Nodes(j).NumExpo <> 0 Then
                If Nodes(j).TypeExpo.Contains("Dirichlet") = True Then
                    TNew(j) = Expo(NbExpo).Temperature(CInt(ti))  ' check whether the current boundary is exposed to a boundary condition
                End If
            End If
            Nodes(j).SetFieldsNew(HNew, SNew, wsat * SNew, TNew(j), NaNew, ClNew, KNew, OHNew, CaNew, SO4New)
        Next
    End Sub
    Public Sub updateVariableH(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef HOld() As Double, ByRef HNew() As Double, ByRef ti As Integer)
        Dim NbExpo As Integer
        Dim SNew As Double
        Dim TNew As Double
        Dim NaNew As Double
        Dim ClNew As Double
        Dim KNew As Double
        Dim OHNew As Double
        Dim CaNew As Double
        Dim SO4New As Double
        For j As Integer = 0 To NNodes - 1
            NbExpo = Nodes(j).NumExpo
            SNew = GetHtoS(HNew(j), type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
            TNew = Nodes(j).GetTNew()
            NaNew = Nodes(j).GetNaNew()
            ClNew = Nodes(j).GetClNew()
            KNew = Nodes(j).GetKNew()
            OHNew = Nodes(j).GetOHNew()
            CaNew = Nodes(j).GetCaNew()
            SO4New = Nodes(j).GetSO4New()
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
            Nodes(j).SetFieldsNew(HNew(j), SNew, wsat * SNew, TNew, NaNew, ClNew, KNew, OHNew, CaNew, SO4New)
        Next
    End Sub
    Public Sub updateVariableS(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef SOld() As Double, ByRef SNew() As Double, ByRef Node_w() As Integer, ByRef ti As Integer)
        Dim NbExpo As Integer
        Dim HNew As Double
        Dim TNew As Double
        Dim NaNew As Double
        Dim ClNew As Double
        Dim KNew As Double
        Dim OHNew As Double
        Dim CaNew As Double
        Dim SO4New As Double
        For j As Integer = 0 To NNodes - 1
            NbExpo = Nodes(j).NumExpo
            HNew = Nodes(j).GetHRNew()
            TNew = Nodes(j).GetTNew()
            NaNew = Nodes(j).GetNaNew()
            ClNew = Nodes(j).GetClNew()
            KNew = Nodes(j).GetKNew()
            OHNew = Nodes(j).GetOHNew()
            CaNew = Nodes(j).GetCaNew()
            SO4New = Nodes(j).GetSO4New()
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
            Nodes(j).SetFieldsNew(HNew, SNew(j), wsat * SNew(j), TNew, NaNew, ClNew, KNew, OHNew, CaNew, SO4New)
        Next
    End Sub
    ' Update concentrations Xuande,2021.09.04
    Public Sub updateVariableC(ByRef Expo() As Exposition, ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef C1New() As Double, ByRef C2New() As Double, ByRef C3New() As Double, ByRef C4New() As Double, ByRef C5New() As Double, ByRef C6New() As Double, ByRef ti As Integer)
        Dim NbExpo As Integer
        Dim TNew As Double
        Dim HNew As Double
        Dim SNew As Double

        For j As Integer = 0 To NNodes - 1
            NbExpo = Nodes(j).NumExpo

            If Nodes(j).NumExpo <> 0 Then
                If Nodes(j).TypeExpo.Contains("Dirichlet") = True Then
                    C1New(j) = Expo(NbExpo).Conc_Na(CInt(ti))  ' Xuande, 2021.09.03
                    C2New(j) = Expo(NbExpo).Conc_Cl(CInt(ti))
                    C3New(j) = Expo(NbExpo).Conc_K(CInt(ti))
                    C4New(j) = Expo(NbExpo).Conc_OH(CInt(ti))
                    C5New(j) = Expo(NbExpo).Conc_Ca(CInt(ti))
                    C6New(j) = Expo(NbExpo).Conc_SO4(CInt(ti))
                End If
            End If
            If C1New(j) <= 0 Then ' Computational error debug, Xuande 2021.09.06
                C1New(j) = 0
            End If
            If C2New(j) <= 0 Then
                C2New(j) = 0
            End If
            If C3New(j) <= 0 Then
                C3New(j) = 0
            End If
            If C4New(j) <= 0 Then
                C4New(j) = 0
            End If
            If C5New(j) <= 0 Then
                C5New(j) = 0
            End If
            If C6New(j) <= 0 Then
                C6New(j) = 0
            End If
            Nodes(j).SetFieldsNew(HNew, SNew, wsat * SNew, TNew, C1New(j), C2New(j), C3New(j), C4New(j), C5New(j), C6New(j))
        Next
    End Sub
    'update flux , xuande 2021.09.03
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
    Public Sub updateNaFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef Jx_New() As Double, ByRef Jy_New() As Double)

        For j As Integer = 0 To NNodes - 1
            Nodes(j).SetNaFluxNew(Jx_New(j), Jy_New(j))
        Next

    End Sub
    Public Sub updateClFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef Jx_New() As Double, ByRef Jy_New() As Double)

        For j As Integer = 0 To NNodes - 1
            Nodes(j).SetClFluxNew(Jx_New(j), Jy_New(j))
        Next

    End Sub
    Public Sub updateKFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef Jx_New() As Double, ByRef Jy_New() As Double)

        For j As Integer = 0 To NNodes - 1
            Nodes(j).SetKFluxNew(Jx_New(j), Jy_New(j))
        Next

    End Sub
    Public Sub updateOHFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef Jx_New() As Double, ByRef Jy_New() As Double)

        For j As Integer = 0 To NNodes - 1
            Nodes(j).SetOHFluxNew(Jx_New(j), Jy_New(j))
        Next

    End Sub
    Public Sub updateCaFlux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef Jx_New() As Double, ByRef Jy_New() As Double)

        For j As Integer = 0 To NNodes - 1
            Nodes(j).SetCaFluxNew(Jx_New(j), Jy_New(j))
        Next

    End Sub
    Public Sub updateSO4Flux(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef Jx_New() As Double, ByRef Jy_New() As Double)

        For j As Integer = 0 To NNodes - 1
            Nodes(j).SetSO4FluxNew(Jx_New(j), Jy_New(j))
        Next

    End Sub
    Public Sub Postprocess(ByRef NNodes As Integer, ByRef Nodes() As NodeTrans, ByRef NElements As Integer, ByRef Elements() As ElementTrans, ByRef ti As Integer, ByRef Time() As Double)
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
            OutputFile.WriteNa(ti * dt, NNodes, dNa_avg, NaAvg, Nodes)
            OutputFile.WriteCl(ti * dt, NNodes, dCl_avg, ClAvg, Nodes)
            OutputFile.WriteK(ti * dt, NNodes, dK_avg, KAvg, Nodes)
            OutputFile.WriteOH(ti * dt, NNodes, dOH_avg, OHAvg, Nodes)
            OutputFile.WriteCa(ti * dt, NNodes, dCa_avg, CaAvg, Nodes)
            OutputFile.WriteSO4(ti * dt, NNodes, dSO4_avg, SO4Avg, Nodes)
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