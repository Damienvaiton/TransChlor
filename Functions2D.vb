Imports System.Linq
Imports NodesTrans
Module Functions2D
    'get elemental flux vector
    Public Function getve(ByRef f1 As Double, ByRef f2 As Double, ByRef f3 As Double, ByRef f4 As Double) As Double()
        Dim ve(3) As Double
        ve(0) = f1
        ve(1) = f2
        ve(2) = f3
        ve(3) = f4
        Return ve
    End Function
    'get the LHS matrix for Gauss matrix resolution
    Public Sub FieldAverage(ByRef Nodes() As NodeTrans, ByRef HRAverage As Double, ByRef SAverage As Double, ByRef WAverage As Double, ByRef TAverage As Double, ByRef NaAverage As Double, ByRef ClAverage As Double, ByRef KAverage As Double, ByRef OHAverage As Double, ByRef CaAverage As Double, ByRef SO4Average As Double)

        HRAverage = 0
        SAverage = 0
        WAverage = 0
        TAverage = 0
        NaAverage = 0
        ClAverage = 0
        KAverage = 0
        OHAverage = 0
        CaAverage = 0
        SO4Average = 0
        For i As Integer = 0 To Nodes.Length - 1

            HRAverage += Nodes(i).GetHROld()
            SAverage += Nodes(i).GetSOld()
            WAverage += Nodes(i).GetWOld()
            TAverage += Nodes(i).GetTOld()
            NaAverage += Nodes(i).GetNaOld()
            ClAverage += Nodes(i).GetClOld()
            KAverage += Nodes(i).GetKOld()
            OHAverage += Nodes(i).GetOHOld()
            CaAverage += Nodes(i).GetCaOld()
            SO4Average += Nodes(i).GetSO4Old()
        Next
        HRAverage /= Nodes.Length
        SAverage /= Nodes.Length
        WAverage /= Nodes.Length
        TAverage /= Nodes.Length
        NaAverage /= Nodes.Length
        ClAverage /= Nodes.Length
        KAverage /= Nodes.Length
        OHAverage /= Nodes.Length
        CaAverage /= Nodes.Length
        SO4Average /= Nodes.Length

    End Sub
    Public Sub getLHS(ByRef LHS As Double(,), ByRef NNodes As Integer, ByRef A(,) As Double, ByRef b(,) As Double, ByRef dt As Double)
        ReDim LHS(NNodes - 1, NNodes - 1)
        Dim i, j As Integer
        For i = 0 To NNodes - 1
            For j = 0 To NNodes - 1
                LHS(i, j) = A(i, j) / 2 + b(i, j) / dt
            Next
        Next
    End Sub
    Public Function getNewLHS(ByRef NewLHS As Double(,), ByRef NNodes As Integer, ByRef phi As Double, ByRef A(,) As Double, ByRef b(,) As Double, ByRef dt As Double) As Double(,)
        ReDim NewLHS(NNodes - 1, NNodes - 1)
        Dim i, j As Integer
        For i = 0 To NNodes - 1
            For j = 0 To NNodes - 1
                NewLHS(i, j) = phi * b(i, j) / dt + A(i, j)
            Next
        Next
        Return NewLHS
    End Function
    ' Xuande 2021.08.15 Multiionic model*
    Public Function getLHS_MI(ByRef LHS_MI As Double(,), ByRef NNodes As Integer, ByRef A(,) As Double, ByRef b(,) As Double, ByRef dt As Double) As Double(,)
        ReDim LHS_MI(NNodes - 1, NNodes - 1)
        Dim i, j As Integer
        For i = 0 To NNodes - 1
            For j = 0 To NNodes - 1
                LHS_MI(i, j) = A(i, j) / 2 + b(i, j) / dt
            Next
        Next
        Return LHS_MI
    End Function
    'Get the RHS matrix For Gauss matrix resolution
    Public Sub getRHS(ByRef RHS As Double(,), ByRef NNodes As Integer, ByRef A(,) As Double, ByRef b(,) As Double, ByRef dt As Double)
        ReDim RHS(NNodes - 1, NNodes - 1)
        Dim i, j As Integer
        For i = 0 To NNodes - 1
            For j = 0 To NNodes - 1
                RHS(i, j) = b(i, j) / dt - A(i, j) / 2
            Next
        Next
    End Sub
    Public Function getNewR(ByRef NewR As Double(,), ByRef NNodes As Integer, ByRef phi As Double, ByRef A(,) As Double, ByRef b(,) As Double, ByRef dt As Double) As Double(,)
        ReDim NewR(NNodes - 1, NNodes - 1)
        Dim i, j As Integer
        For i = 0 To NNodes - 1
            For j = 0 To NNodes - 1
                NewR(i, j) = phi * b(i, j) / dt
            Next
        Next
        Return NewR
    End Function
    ' Xuande 2021.08.15 Multiionic model*
    Public Function getR_MI(ByRef R_MI As Double(,), ByRef NNodes As Integer, ByRef A(,) As Double, ByRef b(,) As Double, ByRef dt As Double) As Double(,)
        ReDim R_MI(NNodes - 1, NNodes - 1)
        Dim i, j As Integer
        For i = 0 To NNodes - 1
            For j = 0 To NNodes - 1
                R_MI(i, j) = b(i, j) / dt - A(i, j) / 2
            Next
        Next
        Return R_MI
    End Function
    'Compute crack line function factor a, Xuande 2021.09.10
    Public Function Get_Crline_a(ByRef x1 As Double, ByRef x2 As Double, ByRef y1 As Double, ByRef y2 As Double)
        Dim a As Double
        a = (y1 - y2) / (x1 - x2)
        If a = 0 Then
            a = a + 1.0E-20
        End If
        Return a
    End Function
    'Compute crack line function factor b, Xuande 2021.09.10
    Public Function Get_Crline_b(ByRef x1 As Double, ByRef x2 As Double, ByRef y1 As Double, ByRef y2 As Double)
        Dim b As Double
        b = y1 - x1 * (y1 - y2) / (x1 - x2)
        Return b
    End Function
    'Compute perpendicular line function factor m, Xuande 2021.09.10
    Public Function Get_Pline_m(ByRef a As Double)
        Dim m As Double
        m = -1 / a
        Return m
    End Function
    'Compute perpendicular line function factor n, Xuande 2021.09.10
    Public Function Get_Pline_n(ByRef xe As Double, ByRef ye As Double, ByRef m As Double)
        Dim n As Double
        n = ye - xe * m
        Return n
    End Function
    'Compute cross point coordinates
    Public Function Get_xG(ByRef a As Double, ByRef b As Double, ByRef m As Double, ByRef n As Double)
        Dim xG As Double
        xG = (n - b) / (a - m)
        Return xG
    End Function
    Public Function Get_yG(ByRef a As Double, ByRef b As Double, ByRef m As Double, ByRef n As Double)
        Dim yG As Double
        yG = (a * n - b * m) / (a - m)
        Return yG
    End Function
    'Location detection function Xuande 2021.09.10
    Public Function Loc_Detect(ByRef xmin As Double, ByRef xmax As Double, ByRef ymin As Double, ByRef ymax As Double, ByRef xG As Double, ByRef yG As Double)
        Dim Ind_Dcr As Boolean
        If ((xmin <= xG) And (xG <= xmax)) And ((ymin <= yG) And (yG <= ymax)) Then
            Ind_Dcr = True
        Else
            Ind_Dcr = False
        End If
        Return Ind_Dcr
    End Function
    'Determine whether the cross point is also on the crack Xuande 2021.09.14
    Public Function Point_Detect(ByRef xc1 As Double, ByRef yc1 As Double, ByRef xc2 As Double, ByRef yc2 As Double, ByRef xG As Double, ByRef yG As Double)
        Dim Ind_Dp As Boolean
        Dim xc_min = Math.Min(xc1, xc2)
        Dim xc_max = Math.Max(xc1, xc2)
        Dim yc_min = Math.Min(yc1, yc2)
        Dim yc_max = Math.Max(yc1, yc2)

        If ((xc_min <= xG) And (xG <= xc_max)) And ((yc_min <= yG) And (yG <= yc_max)) Then
            Ind_Dp = True
        Else
            Ind_Dp = False
        End If
        Return Ind_Dp
    End Function
    'Get degree Of freedom /water diffusion
    Public Function getDOF(NodeNo As Integer) As Integer
        Dim nDofsPerNode As Integer = 1
        Return (NodeNo) * nDofsPerNode
    End Function

    'matrix multiplying a vector
    Public Function MultiplyMatrixWithVector(ByRef a(,) As Double, ByRef b() As Double) As Double()

        Dim aRows As Integer = a.GetLength(0)
        Dim aCols As Integer = a.GetLength(1)
        Dim ab(aRows - 1) As Double 'output will be a vector
        For i As Integer = 0 To aRows - 1
            ab(i) = 0.0
            For j As Integer = 0 To aCols - 1
                ab(i) += a(i, j) * b(j)
            Next
        Next

        Return ab
    End Function

    'linear matrix system resolution by Gauss elimination
    Public Sub GetX(ByRef X As Double(), ByRef A(,) As Double, ByRef b() As Double)
        Dim aRows As Integer = A.GetLength(0)
        Dim aCols As Integer = A.GetLength(1)
        Dim bRows As Integer = b.GetLength(0)
        Dim m As Double
        Dim i, j, k As Integer
        Dim sum As Double
        Dim s As Integer = bRows
        ReDim X(s - 1)

        For j = 0 To s - 2 Step 1
            For i = s - 1 To j + 1 Step -1
                m = A(i, j) / A(j, j)
                For k = 0 To s - 1 Step 1
                    A(i, k) = A(i, k) - m * A(j, k)
                Next
                'A(i, j) = A(i, j) - m * A(j, j)
                b(i) = b(i) - m * b(j)
            Next
        Next

        X(s - 1) = b(s - 1) / A(s - 1, s - 1)

        For i = s - 2 To 0 Step -1
            sum = 0
            For j = s - 1 To i Step -1
                sum = sum + A(i, j) * X(j)
            Next
            X(i) = (b(i) - sum) / A(i, i)
        Next
    End Sub

    ''liquid water transport functions: (Equation and formula from Marc Mainguy, 2001)
    'relative permeability function (Equation and formula from Marc Mainguy, 2001 & derived from VanGnuchten, 1980) 
    Public Function Getkr(ByRef saturation As Double, ByRef m As Double) As Double
        Dim S As Double = saturation
        'Dim sa_irr As Double = 0.00001
        'Dim sb_irr As Double = 0.00001
        'Dim n As Double = 1 / m
        'Dim s_eff As Double = (S - sb_irr) / (1 - sa_irr - sb_irr)
        'Dim kr_b_max As Double = 1
        'Dim kr As Double = kr_b_max * s_eff ^ n
        Dim kr As Double = Math.Sqrt(S) * (1 - (1 - S ^ (1 / m)) ^ m) ^ 2
        Return kr
    End Function

    'liquid capillary pressure function (Equation and formula from Marc Mainguy, 2001)
    Public Function Getpc(ByRef saturation As Double, ByRef pc_0 As Double, ByRef b As Double, ByRef St As Double) As Double
        Dim S As Double = saturation
        Dim pc As Double
        Dim pa As Double = 0.101325 'Mpa
        'Dim n As Double = 1 / (1 - m)
        'Dim s_pc_irr As Double = 0.00001
        'Dim s_pc_max As Double = 1
        'Dim Sb_pc As Double = (S - s_pc_irr) / (s_pc_max - s_pc_irr)
        Dim Pt As Double = pc_0 * (St ^ (-b) - 1) ^ (1 - 1 / b)
        Dim P As Double = Math.Log(Pt * 1000000.0, 10)
        Dim gamma As Double = -(Math.Log(1000000000.0, 10) - P) / St
        If S >= St Then
            pc = pa - pc_0 * (S ^ (-b) - 1) ^ (1 - 1 / b)
        Else
            pc = pa - (10 ^ (gamma * (S - St) + P)) / 1000000.0
        End If
        Return pc
    End Function
    'derivation of the capillary pressure function 
    Public Function GetdpcdS(ByRef saturation As Double, ByRef pc_0 As Double, ByRef b As Double, ByRef St As Double) As Double
        Dim dpcdS As Double
        Dim S As Double = saturation
        Dim n As Double = 1 / b
        Dim Pt As Double = pc_0 * (St ^ (-b) - 1) ^ (1 - 1 / b)
        Dim P As Double = Math.Log(Pt * 1000000.0, 10)
        Dim gamma As Double = -(Math.Log(1000000000.0, 10) - P) / St
        'dpcdS = (pc_0 * (1 / S ^ (1 / b) - 1) ^ (1 / n)) / (b * n * S * (S ^ (1 / b) - 1))
        If S >= St Then
            dpcdS = -pc_0 * (b - 1) * S ^ (-b - 1) / ((S ^ -b - 1) ^ -b)
        Else
            dpcdS = -10 ^ (-6) * Math.Log(10) * gamma * 10 ^ (gamma * (S - St) + P)
        End If
        Return dpcdS
    End Function

    'liquid-water contribution to the moisture diffusivity [cm2/s] 
    Public Function GetDl(ByRef K As Double, ByRef yita_l As Double, ByRef dpcdS As Double, ByRef kr As Double) As Double
        Dim Dl As Double
        Dl = -dpcdS * K * kr / yita_l * 1000000.0   ' convert unit to mm2/s
        Return Dl
    End Function

    'water vapor transport functions
    'diffusion coefficient of water vapor  [mm2/s] (Equation and formula from Bazant, 2001)
    Public Function GetDh(ByRef DT0 As Double, ByRef alpha_0 As Double, ByRef Hc As Double, ByRef T As Double, ByRef H As Double) As Double
        Dim n As Integer = 4
        Dim Q As Double = 40000 ' [mol/J] energie d'activation du modele Arrhenius
        Dim R As Double = 8.31451
        Dim T_0 As Double = 22 + 273  '[K] temperature de base du beton lors de la determination de Q et de DT_0
        Dim Dh As Double = DT0 * ((alpha_0 + (1 - alpha_0) / (1 + ((1 - H) / (1 - Hc)) ^ n)) * Math.Exp((Q / R * (1 / T_0 - 1 / (T + 273)))))
        Return Dh
    End Function

    'diffusion coefficient of water vapor or dry air in wet air [cm2/s] (Equation and formula from Marc Mainguy, 2001)
    Public Function GetD(ByRef Tc As Double, ByRef pg As Double) As Double
        Dim Dva As Double
        Dim p_atm As Double = 101325 'atmosphere pressure [pa]
        Dim T0 As Double = 273 '0 degree [K]
        Dim D As Double
        Dva = 0.217 * p_atm * (((Tc + 273) / T0) ^ 1.88)
        D = Dva / pg * 0.0001 'convert unit to m2/s
        Return D
    End Function

    'diffusion coefficient of water vapor or dry air in wet air [mm2/s] 
    Public Function GetDv(ByRef rho_v As Double, ByRef rho_l As Double, ByRef dpcdS As Double, ByRef f As Double, ByRef D As Double, ByRef pv As Double) As Double
        Dim Dv As Double
        Dv = D / pv * (rho_v / rho_l) ^ 2 * dpcdS * f * 1000000.0 'convert unit to mm2/s
        Return Dv
    End Function
    ' Xuande 2021.09.09
    Public Function GetD_MI(ByRef D0_i As Double, ByRef tor_i As Double) As Double ' Get the Ionic Diffusion coefficient 
        Dim D_MI As Double = D0_i * tor_i
        Return D_MI
    End Function

    'resistance factor function considering the tortuosity
    Public Function Getf(ByRef phi As Double, ByRef saturation As Double) As Double
        Dim S As Double = saturation
        Dim f As Double
        f = phi ^ (4 / 3) * (1 - S) ^ (10 / 3)
        Return f
    End Function

    'saturated water function 
    Public Function GetWsat(ByRef Water_tot As Double, ByRef C As Double, ByRef alpha As Double) As Double
        Dim Wsat As Double = Water_tot - C * 0.2 * alpha
        Return Wsat
    End Function

    'isotherm functions
    Public Function GetHtoS(ByRef H As Double, ByRef type As Integer, ByRef C As Double, ByRef W_C_ratio As Double, ByRef Tk As Double, ByRef day As Double, ByRef rho_l As Double, ByRef rho_c As Double, ByRef alpha As Double, ByRef w As Double) As Double
        Dim NT As Double = 1
        Dim VT As Double = 1
        Dim C0 As Double = 855
        ' the adsorption curve from [Xi 1994]
        Dim Cbet As Double = Cfunc(C0, Tk)
        Dim Vm As Double = Vmfunc(day, W_C_ratio, type, VT)
        Dim n As Double = nfunc(day, W_C_ratio, type, NT)
        Dim k As Double = kfunc(Cbet, n)
        Dim wc1 As Double = (Cbet * k * Vm * 1) / ((1 - k * 1) * (1 + (Cbet - 1) * k * 1)) 'when H = 100% = 1
        Dim phi As Double = wc1 * (rho_c / rho_l) 'intermediate term
        Dim wc As Double = (Cbet * k * Vm * H) / ((1 - k * H) * (1 + (Cbet - 1) * k * H))
        Dim Sa As Double = wc / wc1
        ' the desorption curve from [Roelfstra 1989]
        'alpha = 0.6
        Dim Tc As Double = Tk - 273 'temperature in [C]
        Dim Ht As Double = 1 - 0.161 * alpha
        Dim c1 As Double = 0.125
        Dim c2 As Double = 0.173 - (0.431 * (Tc - 20) / 25)
        Dim c3 As Double = 0.06 + 0.392 * ((Tc - 20) / 25)
        Dim c4 As Double = 0.17 + (0.035 + 0.029 * (W_C_ratio - 0.4) / 0.15) * ((Tc - 20) / 25)
        Dim Sd As Double
        Dim wr1 As Double
        Dim wr As Double
        Dim Mat1(2, 2) As Double
        Mat1(0, 0) = Ht ^ 2
        Mat1(0, 1) = 1 - 2 * Ht
        Mat1(0, 2) = Ht ^ 2 - Ht
        Mat1(1, 0) = -2 * Ht
        Mat1(1, 1) = 2 * Ht
        Mat1(1, 2) = 1 - Ht ^ 2
        Mat1(2, 0) = 1
        Mat1(2, 1) = -1
        Mat1(2, 2) = Ht - 1
        Dim Vec1(2) As Double
        Vec1(0) = W_C_ratio - c4 * alpha
        Vec1(1) = (c1 + c2 * Ht + c3 * Ht ^ 2) * alpha
        Vec1(2) = (c2 + 2 * c3 * Ht) * alpha
        Dim Vec2() As Double = MultiplyMatrixWithVector(Mat1, Vec1)
        Dim Vec3(2) As Double
        Vec3(0) = 1
        Vec3(1) = H
        Vec3(2) = H ^ 2
        wr1 = C * 1 / ((1 - Ht) ^ 2) * (Vec2(0) * 1 + Vec2(1) * 1 + Vec2(2) * 1)
        If 1 >= H And H >= Ht Then

            wr = C * 1 / ((1 - Ht) ^ 2) * (Vec2(0) * Vec3(0) + Vec2(1) * Vec3(1) + Vec2(2) * Vec3(2))

        ElseIf Ht > H And H >= 0.35 Then

            wr = C * (c1 + c2 * H + c3 * H ^ 2) * alpha

        Else

            wr = C * ((-(400 * c1 / 49) + c3) * H + 40 * c1 / 7 + c2) * alpha * H

        End If
        Sd = wr / wr1
        ' the hysteretic curve
        Dim S As Double
        S = w * Sa + (1 - w) * Sd
        Return S
    End Function
    Public Function nfunc(ByRef day As Double, ByRef W_C_ratio As Double, ByRef type As Integer, ByRef NT As Double) As Double
        Dim N_Ct As Double
        If type = 1 Then
            N_Ct = 1.1
        ElseIf type = 2 Then
            N_Ct = 1
        ElseIf type = 3 Then
            N_Ct = 1.15
        Else
            N_Ct = 1.5
        End If
        Dim N_t As Double
        If day > 5 Then
            N_t = 2.5 - 15 / day
        Else
            N_t = 5.5
        End If
        Dim N_EC As Double = 0.33 + 2.2 * W_C_ratio
        Dim n As Double = NT * N_EC * N_Ct * N_t
        Return n
    End Function
    Public Function kfunc(ByRef C As Double, ByRef n As Double) As Double
        Dim k As Double = ((1 - 1 / n) * C - 1) / (C - 1)
        Return k
    End Function
    Public Function Cfunc(ByRef C0 As Double, ByRef T As Double) As Double
        Dim C As Double = Math.Exp(C0 / T)
        Return C
    End Function
    Public Function Vmfunc(ByRef day As Double, ByRef W_C_ratio As Double, ByRef type As Integer, ByRef VT As Double) As Double
        Dim V_Ct As Double
        If type = 1 Then
            V_Ct = 0.9
        ElseIf type = 2 Then
            V_Ct = 1
        ElseIf type = 3 Then
            V_Ct = 0.85
        Else
            V_Ct = 0.6
        End If
        Dim V_t As Double
        If day > 5 Then
            V_t = 0.068 - 0.22 / day
        Else
            V_t = 0.024
        End If
        Dim V_EC As Double = 0.85 + 0.45 * W_C_ratio
        Dim Vm As Double = VT * V_EC * V_Ct * V_t 'capacite de la monocouche
        Return Vm
    End Function

    'get average of humidity on an element 
    Public Function GetAvgH(ByRef He() As Double) As Double
        Dim H_avg As Double
        H_avg = He.Average()
        Return H_avg
    End Function

    'get norm of a given vector
    Public Function GetNorm(ByRef v() As Double) As Double
        Dim Norm As Double
        For i As Integer = 0 To v.Length - 1
            Norm += v(i) ^ 2
        Next
        Norm = Math.Sqrt(Norm)
        Return Norm
    End Function

    'get field average
    Public Sub GetNewAverage(ByRef Nodes() As NodeTrans, ByRef Havg As Double, ByRef wavg As Double, ByRef Savg As Double, ByRef Tavg As Double, ByRef Naavg As Double, ByRef Clavg As Double, ByRef Kavg As Double, ByRef OHavg As Double, ByRef Caavg As Double, ByRef SO4avg As Double)

        Dim len = Nodes.Length()

        For i As Integer = 0 To len - 1

            Havg += Nodes(i).GetHRNew()
            wavg += Nodes(i).GetWNew()
            Savg += Nodes(i).GetSNew()
            Tavg += Nodes(i).GetTNew()
            Naavg += Nodes(i).GetNaNew() 'Xuande, 2021.09.04
            Clavg += Nodes(i).GetClNew()
            Kavg += Nodes(i).GetKNew()
            OHavg += Nodes(i).GetOHNew()
            Caavg += Nodes(i).GetCaNew()
            SO4avg += Nodes(i).GetSO4New()
        Next

        Havg /= len
        wavg /= len
        Savg /= len
        Tavg /= len
        Naavg /= len
        Clavg /= len
        Kavg /= len
        OHavg /= len
        Caavg /= len
        SO4avg /= len
    End Sub
    Public Sub GetOldAverage(ByRef Nodes() As NodeTrans, ByRef Havg As Double, ByRef wavg As Double, ByRef Savg As Double, ByRef Tavg As Double, ByRef Naavg As Double, ByRef Clavg As Double, ByRef Kavg As Double, ByRef OHavg As Double, ByRef Caavg As Double, ByRef SO4avg As Double)

        Dim len As Integer = Nodes.Length()

        For i As Integer = 0 To len - 1

            Havg += Nodes(i).GetHROld()
            wavg += Nodes(i).GetWOld()
            Savg += Nodes(i).GetSOld()
            Tavg += Nodes(i).GetTOld()
            Naavg += Nodes(i).GetNaOld() 'Xuande, 2021.09.04
            Clavg += Nodes(i).GetClOld()
            Kavg += Nodes(i).GetKOld()
            OHavg += Nodes(i).GetOHOld()
            Caavg += Nodes(i).GetCaOld()
            SO4avg += Nodes(i).GetSO4Old()
        Next

        Havg /= len
        wavg /= len
        Savg /= len
        Tavg /= len
        Naavg /= len
        Clavg /= len
        Kavg /= len
        OHavg /= len
        Caavg /= len
        SO4avg /= len
    End Sub
    Public Sub UpdatediffAverage(ByRef Nodes() As NodeTrans, ByRef dH_avg As Double, ByRef dw_avg As Double, ByRef dS_avg As Double, ByRef dT_avg As Double, ByRef dNa_avg As Double, ByRef dCl_avg As Double, ByRef dK_avg As Double, ByRef dOH_avg As Double, ByRef dCa_avg As Double, ByRef dSO4_avg As Double)

        Dim HRNewAv, HROldAv, WNewAv, WOldAv, SNewAv, SOldAv, TNewAv, TOldAv, NaNewAv, NaOldAv, ClNewAv, ClOldAv, KNewAv, KOldAv, OHNewAv, OHOldAv, CaNewAv, CaOldAv, SO4NewAv, SO4OldAv As Double

        GetNewAverage(Nodes, HRNewAv, WNewAv, SNewAv, TNewAv, NaNewAv, ClNewAv, KNewAv, OHNewAv, CaNewAv, SO4NewAv)
        GetOldAverage(Nodes, HROldAv, WOldAv, SOldAv, TOldAv, NaOldAv, ClOldAv, KOldAv, OHOldAv, CaOldAv, SO4OldAv)

        dH_avg += HRNewAv - HROldAv
        dw_avg += WNewAv - WOldAv
        dS_avg += SNewAv - SOldAv
        dT_avg += TNewAv - TOldAv
        dNa_avg += NaNewAv - NaOldAv
        dCl_avg += ClNewAv - ClOldAv
        dK_avg += KNewAv - KOldAv
        dOH_avg += OHNewAv - OHOldAv
        dCa_avg += CaNewAv - CaOldAv
        dSO4_avg += SO4NewAv - SO4OldAv
    End Sub
    ''thermo transport functions 
    Public Function lambtafunc(ByRef Tc As Double, ByRef phi As Double, ByRef Saturation As Double, ByRef Granulat As Double, ByRef Cement As Double) As Double
        Dim Lambta As Double
        Dim Tk As Double = Tc + 273
        Dim lambta0 As Double = 1.9
        Dim Tk_ref As Double = 293
        Dim rho_liq As Double = 1000.0
        Dim rho_solid As Double = Granulat + Cement
        Lambta = lambta0 * (1 + 0.0005 * (Tk - Tk_ref) * (1 + 4 * phi * rho_liq * Saturation / ((1 - phi) * rho_solid)))
        Return Lambta
    End Function
    Public Function Cpfunc(ByRef Tc As Double, ByRef phi As Double, ByRef Saturation As Double, ByRef Granulat As Double, ByRef Cement As Double) As Double
        Dim rho_Cp As Double
        Dim Tk As Double = Tc + 273
        Dim Ac As Double = 0.0005
        Dim Tk_ref As Double = 293
        Dim rho_liq As Double = 1000.0
        Dim rho_solid As Double = Granulat + Cement
        Dim Cp_liq As Double = 4200
        Dim rho_Cp_s0 As Double = 840 ' J/K.m-3
        rho_Cp = (1 - phi) * rho_solid * rho_Cp_s0 * (1 + Ac * (Tk - Tk_ref)) + phi * Saturation * rho_liq * Cp_liq
        Return rho_Cp
    End Function

    'thermodiffusivity
    Public Function GetDlambta(ByRef Lambta As Double, ByRef rho_Cp As Double) As Double
        Dim Dlambta As Double
        Dlambta = Lambta / rho_Cp * 1000000.0 'convert To J/(mm.s)
        Return Dlambta
    End Function

    'ionic transport functions
    '

End Module