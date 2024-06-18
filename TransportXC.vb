'Option Explicit On
'Imports System
'Imports System.ComponentModel
'Imports System.IO
'Imports System.Linq
'' Developper's note. Module pour calcul Transport Hydrique 2D. Xuande.2020.07.15

'' implémentation des équations de capillarité, de perméabilité et d'isotherme de adsorption/désorption
'Public Class TransportXC
'    Private NNodes, NElements As Integer
'    Private Nodes() As NodeTrans
'    Private Elements() As ElementTrans
''Material parameters, can be converted from user defined input
'Dim pg As Double = 101325 'atmosphere pressure(pa)
'    Dim rho_v As Double = 1 'density of vapor (kg/m3)
'    Dim rho_l As Double = 1000 'density of liquid (kg/m3)
'    Dim rho_c As Double = 2500 'density of concrete (kg/m3)

'    'Dim pc_0 As Double = 8.8678 ' parameter for ordinary concrete (Mpa) W/C = 0.73
'    'Dim pc_0 As Double = 10.1017 ' parameter for ordinary concrete (Mpa) W/C = 0.6
'    Dim pc_0 As Double = 12.3553 ' parameter for ordinary concrete (Mpa) W/C = 0.52
'    'Dim pc_0 As Double = 13.3546 ' parameter for ordinary concrete (Mpa) W/C = 0.5
'    'Dim pc_0 As Double = 18.6237 ' parameter for ordinary concrete (Mpa) W/C = 0.44
'    'Dim pc_0 As Double = 25.8592 ' parameter for ordinary concrete (Mpa) W/C = 0.4
'    Dim m As Double = 0.4396 ' parameter for ordinary concrete 
'    Dim beta As Double = 2.2748 ' 

'    'Dim KK As Double = 0.0000000000000055 'given by the user ,5.5e-15 W/C = 0.73 dry to 75%RH
'    'Dim KK As Double = 3.5E-15 'given by the user ,3.5e-15 W/C = 0.52 dry to 75%RH
'    'Dim KK As Double = 0.0000000000000015 'given by the user ,1.5e-15 W/C = 0.44 dry to 75%RH

'    'Dim KK As Double = 0.00000000000000025 'given by the user ,2.5e-16 W/C = 0.73 dry to 50%RH
'    'Dim KK As Double = 8.0E-17 'given by the user ,8e-17 W/C = 0.52 dry to 50%RH
'    'Dim KK As Double = 8.0E-17 'given by the user ,8e-17 W/C = 0.44 dry to 50%RH

'    'Dim KK As Double = 0.0000000000000008 'given by the user ,8e-16 W/C = 0.73 dry to 25%RH
'    'Dim KK As Double = 8.0E-17 'given by the user ,8e-17 W/C = 0.52 dry to 25%RH
'    Dim KK As Double = 0.0000000000000008 'given by the user ,8e-16 W/C = 0.44 dry to 25%RH


'    'Dim KK As Double = 0.0000000000000042 'given by the user ,4.2e-15 W/C = 0.6
'    'Dim KK As Double = 0.0000000000000017 'given by the user ,1.7e-15 W/C = 0.5
'    'Dim KK As Double = 0.00000000000000085 'given by the user ,8.5e-16 W/C = 0.4

'    Dim alpha_int = 0.6
'    Dim yita_l As Double = 0.00089 'viscosity of water (kg/m.s=pa.s)

'    Dim type As Integer = 1 'cement type (-)

'    'Dim W_C_ratio As Double = 0.73 'W/C = 0.73
'    'Dim W_C_ratio As Double = 0.6 'W/C = 0.6
'    Dim W_C_ratio As Double = 0.52 'W/C = 0.52
'    'Dim W_C_ratio As Double = 0.5 'W/C = 0.5
'    'Dim W_C_ratio As Double = 0.44 'W/C = 0.44
'    'Dim W_C_ratio As Double = 0.4 'W/C = 0.4

'    'Dim C As Double = 250 'density of cement (W/C = 0.73)
'    'Dim C As Double = 310 'density of cement (W/C = 0.6)
'    Dim C As Double = 375 'density of cement (W/C = 0.52)
'    'Dim C As Double = 350 'density of cement (W/C = 0.5)
'    'Dim C As Double = 375 'density of cement (W/C = 0.44)
'    'Dim C As Double = 400 'density of cement (W/C = 0.4)

'    Dim phi As Double = (C * W_C_ratio - 0.2 * C * alpha_int) / rho_l
'    'Dim phi As Double = 0.1299 'porosity (W/C = 0.6-0.73)
'    'Dim phi As Double = 0.1289 'porosity (W/C = 0.5-0.52)
'    'Dim phi As Double = 0.12 'porosity (W/C = 0.44)

'    Dim Water_tot As Double = W_C_ratio * C 'density of cement (kg/m3)
'    Dim day As Double

'    'Dim alpha As Double = 0.65 'hydration degree (W/C=0.44, DC to 75%)
'    'Dim alpha As Double = 0.75 'hydration degree (W/C=0.52, DC to 75%)
'    'Dim alpha As Double = 0.82 'hydration degree (W/C=0.73, DC to 75%)

'    'Dim alpha As Double = 0.72 'hydration degree (W/C=0.44, DC to 50%)
'    'Dim alpha As Double = 0.75 'hydration degree (W/C=0.52, DC to 50%)
'    'Dim alpha As Double = 0.6 'hydration degree (W/C=0.73, DC to 50%)

'    Dim alpha As Double = 0.65 'hydration degree (W/C=0.44, DC to 25%)
'    'Dim alpha As Double = 0.75 'hydration degree (W/C=0.52, DC to 25%)
'    'Dim alpha As Double = 0.76 'hydration degree (W/C=0.73, DC to 25%)

'    'Dim alpha As Double = 0.85 'hydration degree (W/C=0.6,LK)
'    'Dim alpha As Double = 0.8 'hydration degree (W/C=0.5,LK)
'    'Dim alpha As Double = 0.72 'hydration degree (W/C=0.4,LK)

'    Dim Tk As Double = 293 'temperature in (K) 20c
'    'Dim Tk As Double = 283 'temperature in (K) 10c
'    'Dim Tk As Double = 273 'temperature in (K) 0c
'    Dim Tc As Double = Tk - 273 'temperature in (C)
'    Dim wsat As Double = GetWsat(Water_tot, C, alpha) 'saturated water mass (kg/m3)
'    Dim St As Double = 0.2 'capillary pressure residual saturation

'    'Geometry parameters for boundary check program
'    ''LUNK
'    'Dim X_upper As Double = 75 'mm, upper bound of X coordinate
'    'Dim X_lower As Double = -75 'mm, upper bound of X coordinate
'    'Dim Y_upper As Double = 75 'mm, upper bound of Y coordinate
'    'Dim Y_lower As Double = -75 'mm, upper bound of Y coordinate

'    'DC A&B
'    Dim X_upper As Double = 15 'mm, upper bound of X coordinate
'    Dim X_lower As Double = -15 'mm, upper bound of X coordinate
'    Dim Y_upper As Double = 25 'mm, upper bound of Y coordinate
'    Dim Y_lower As Double = -25 'mm, upper bound of Y coordinate

'    ''DC C
'    'Dim X_upper As Double = 20 'mm, upper bound of X coordinate
'    'Dim X_lower As Double = -20 'mm, upper bound of X coordinate
'    'Dim Y_upper As Double = 25 'mm, upper bound of Y coordinate
'    'Dim Y_lower As Double = -25 'mm, upper bound of Y coordinate

'    Dim Expo_X_upper As Boolean = True 'exposure on right most side
'    Dim Expo_X_lower As Boolean = True 'exposure on left most side
'    Dim Expo_Y_upper As Boolean = True 'exposure on top most side
'    Dim Expo_Y_lower As Boolean = True 'exposure on bottom most side
'    Dim X_node As Double
'    Dim Y_node As Double

'    'Computation parameters
'    Dim nFic1 As Short
'    Dim nFic2 As Short
'    Dim outfile(2) As String
'    Dim nDof As Integer = NNodes
'    Dim w As Double = 0 'indicator for isotherm curve, judge if we choose to use desorption (w = 0) or adsorption curve (w = 1) 
'    Dim Node_w(nDof - 1) As Double
'    Dim H_int As Double = 1 'initial relative humidity
'    Dim H_bound1 As Double = 0.25 'boundary relative humidity1
'    Dim H_bound2 As Double = 0.25 'boundary relative humidity2
'    Dim H_bound3 As Double = 0.25 'boundary relative humidity3
'    Dim H_bound4 As Double = 0.25 'boundary relative humidity4
'    Dim ti As Integer
'    Dim dt As Double = 3600       'time interval (s)
'    Dim dt_new As Double
'    'Dim tmax As Double = 3600 * 24 * 3 'end time (s)  3Days / Lunk
'    Dim tmax As Double = 3600 * 24 * 450 'end time (s)  7.5days / DC
'    Dim ind As Integer = CInt(tmax / dt)
'    Dim H_old(nDof - 1) As Double
'    Dim H_new(nDof - 1) As Double
'    Dim S_old(nDof - 1) As Double
'    Dim S_new(nDof - 1) As Double
'    Dim w_old(nDof - 1) As Double
'    Dim w_new(nDof - 1) As Double
'    'Dim fieldHnew_average As Double
'    'Dim fieldHold_average As Double
'    Dim fieldSnew_average As Double
'    Dim fieldSold_average As Double
'    Dim fieldwnew_average As Double
'    Dim fieldwold_average As Double
'    'Dim dH_avg As Double
'    Dim dw_avg As Double
'    Dim dS_avg As Double
'    Dim T_sauv As Single = 3600 * 24     'ouput time inteval (s) 4h /10day
'    Dim i, j, jj As Integer
'    Dim NewLHS(,) As Double
'    Dim NewR(,) As Double
'    Dim RHS() As Double
'    Dim bg(nDof - 1, nDof - 1) As Double 'Global b matrix
'    Dim Ag(nDof - 1, nDof - 1) As Double 'Global A matrix
'    Dim cieNew As CIETransNew
'    Dim se As SETrans 'element saturation vector
'    Dim D As Double = GetD(Tk, pg)
'    Dim S_ele() As Double
'    Dim dt_int As Double 'nonlinear iterative process
'    Dim tol As Double = 0.0001 'tolerance of convergence
'    Dim Norm_R As Double  'Normal of residu array
'    Dim R() As Double

'    ''Creating output .txt computation result file 2020-07-27 Xuande 
'    outfile(1) = Directory & "\" & "R_S_CapillaryModel" & ".txt"
'    outfile(2) = Directory & "\" & "R_W_CapillaryModel" & ".txt"
'    nFic1 = CShort(FreeFile())
'    FileOpen(CInt(nFic1), outfile(1), OpenMode.Output)
'    nFic2 = CShort(FreeFile())
'    FileOpen(CInt(nFic2), outfile(2), OpenMode.Output)
'    Print(nFic1, "S", ",", nDof, ",", "Average S", ",", "dS", ",", TAB)
'    For jj = 0 To nDof - 1
'        Print(CInt(nFic1), jj + CShort(1), ",", TAB)
'    Next jj
'    PrintLine(CInt(nFic1), " ")
'    Print(nFic2, "W", ",", nDof, ",", "Average W", ",", "dW", ",", TAB)
'    For jj = 0 To nDof - 1
'        Print(CInt(nFic2), jj + CShort(1), ",", TAB)
'    Next jj
'    PrintLine(CInt(nFic2), " ")
'    SlRange = New Range
'    ReDim Time(ind + 2)
'    Time(0) = 0
'    Me.Invoke(Sub()
'                  LabelProgress.Visible = True
'              End Sub)

'    ''Global time loop
'    For ti = 0 To CInt(ind)
'        Me.Invoke(Sub()
'                      LabelProgress.Text = CStr(ti) + " / " + CStr(ind)
'                      Me.Refresh()
'                  End Sub)

'        ' step 1: initialisation saturation field and boundary check
'        If ti = 0 Then
'            Print(CInt(nFic1), "0", ",", "0", ",", TAB)
'            Print(CInt(nFic2), "0", ",", "0", ",", TAB)
'            For i = 0 To nDof - 1
'                Node_w(i) = w
'                H_old(i) = H_int
'                S_old(i) = GetHtoS(H_old(i), type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, Node_w(i))
'                w_old(i) = wsat * S_old(i)
'                H_new(i) = H_old(i)
'                S_new(i) = S_old(i)
'                w_new(i) = w_old(i)
'            Next
'            Dim w_avg_0 As Double = w_old.Average()
'            Dim S_avg_0 As Double = S_old.Average()
'            Print(CInt(nFic1), S_avg_0, ",", "0", ",", TAB)
'            Print(CInt(nFic2), w_avg_0, ",", "0", ",", TAB)
'            'plot initial state
'            For i = 0 To NElements - 1
'                ReDim Elements(i).HR(ind + 2)
'                ReDim Elements(i).Sl(ind + 2)
'                'Elements(i).HR(0) = H_new(i) * 100
'                Elements(i).Sl(0) = S_new(i) * 100
'                'HRRange.AddValue(Elements(i).HR(0))
'                SlRange.AddValue(Elements(i).Sl(0))
'            Next
'            'apply BC
'            For i = 0 To nDof - 1
'                Print(CInt(nFic1), S_old(i), ",", TAB)
'                Print(CInt(nFic2), w_old(i), ",", TAB)
'                If Nodes(i).NumExpo <> 0 Then ' check whether the current boundary is exposed to a boundary condition
'                    X_node = Nodes(i).x
'                    Y_node = Nodes(i).y
'                    If Math.Abs(X_node - X_lower) <= 0.00001 And Expo_X_lower = True Then
'                        H_new(i) = H_bound1
'                    ElseIf Math.Abs(X_node - X_upper) <= 0.00001 And Expo_X_upper = True Then
'                        H_new(i) = H_bound2
'                    ElseIf Math.Abs(Y_node - Y_lower) <= 0.00001 And Expo_Y_lower = True Then
'                        H_new(i) = H_bound3
'                    ElseIf Math.Abs(Y_node - Y_upper) <= 0.00001 And Expo_Y_upper = True Then
'                        H_new(i) = H_bound4
'                    End If
'                Else
'                    H_new(i) = H_old(i)
'                End If
'                'isotherm state check 
'                If Node_w(i) = 0 And H_new(i) > H_old(i) Then 'state change from desorption to adsorption
'                    w = 1
'                ElseIf Node_w(i) = 1 And H_new(i) < H_old(i) Then 'adsorption to desorption
'                    w = 0
'                End If
'                S_new(i) = GetHtoS(H_new(i), type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, Node_w(i))
'                w_new(i) = wsat * S_new(i)
'            Next
'            PrintLine(CInt(nFic1), " ")
'            PrintLine(CInt(nFic2), " ")
'            'plot intital state after BC applied
'            For i = 0 To NElements - 1
'                'Elements(i).HR(1) = (H_new(Elements(i).Node1 - 1) + H_new(Elements(i).Node2 - 1) + H_new(Elements(i).Node3 - 1) + H_new(Elements(i).Node4 - 1)) * 100 / 4
'                Elements(i).Sl(1) = (S_new(Elements(i).Node1 - 1) + S_new(Elements(i).Node2 - 1) + S_new(Elements(i).Node3 - 1) + S_new(Elements(i).Node4 - 1)) * 100 / 4
'                'HRRange.AddValue(Elements(i).HR(1))
'                SlRange.AddValue(Elements(i).Sl(1))
'            Next
'            Time(1) = dt / 1000 / 3600 ' Time in hour
'            'compute variation
'            fieldSnew_average = S_new.Average
'            fieldSold_average = S_old.Average
'            fieldwnew_average = w_new.Average
'            fieldwold_average = w_old.Average
'            dw_avg = fieldwnew_average - fieldwold_average + dw_avg
'            dS_avg = fieldSnew_average - fieldSold_average + dS_avg
'            'imagine BC is applied in very short time (dt/1e6), then output the field variables with BC applied on it
'            RegisterField(nFic1, dt / 1000000.0, nDof, dS_avg, S_new)
'            PrintLine(CInt(nFic1), " ")
'            RegisterField(nFic2, dt / 1000000.0, nDof, dw_avg, w_new)
'            PrintLine(CInt(nFic2), " ")
'        Else
'            For i = 0 To nDof - 1 'regular loop
'                S_old(i) = S_new(i)
'                w_old(i) = w_new(i)
'                ''isotherm state check 
'                If Node_w(i) = 0 And S_new(i) > S_old(i) Then 'state change from desorption to adsorption
'                    w = 1
'                ElseIf Node_w(i) = 1 And S_new(i) < S_old(i) Then 'adsorption to desorption
'                    w = 0
'                End If
'                If Nodes(i).NumExpo <> 0 Then
'                    X_node = Nodes(i).x
'                    Y_node = Nodes(i).y
'                    If Math.Abs(X_node - X_lower) <= 0.00001 And Expo_X_lower = True Then
'                        S_new(i) = GetHtoS(H_bound1, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, Node_w(i))
'                    ElseIf Math.Abs(X_node - X_upper) <= 0.00001 And Expo_X_upper = True Then
'                        S_new(i) = GetHtoS(H_bound2, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, Node_w(i))
'                    ElseIf Math.Abs(Y_node - Y_lower) <= 0.00001 And Expo_Y_lower = True Then
'                        S_new(i) = GetHtoS(H_bound3, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, Node_w(i))
'                    ElseIf Math.Abs(Y_node - Y_upper) <= 0.00001 And Expo_Y_upper = True Then
'                        S_new(i) = GetHtoS(H_bound4, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, Node_w(i))
'                    End If
'                End If
'            Next

'            'step 2: elemental and global Matrix constructions
'            'Matrix assembling
'            For i = 0 To NElements - 1
'                se = New SETrans(
'             S_old(Elements(i).Node1 - 1), S_old(Elements(i).Node2 - 1),
'             S_old(Elements(i).Node3 - 1), S_old(Elements(i).Node4 - 1)
'             )
'                S_ele = se.getSe
'                '' new program using nodal interpolations instead of mean value on elements to calculate transport coefficient 2020.08.15 Xuande
'                Dim kr1 As Double = Getkr(S_ele(0), m)
'                Dim kr2 As Double = Getkr(S_ele(1), m)
'                Dim kr3 As Double = Getkr(S_ele(2), m)
'                Dim kr4 As Double = Getkr(S_ele(3), m)
'                Dim pc1 As Double = Getpc(S_ele(0), pc_0, beta, St)
'                Dim pc2 As Double = Getpc(S_ele(1), pc_0, beta, St)
'                Dim pc3 As Double = Getpc(S_ele(2), pc_0, beta, St)
'                Dim pc4 As Double = Getpc(S_ele(3), pc_0, beta, St)
'                Dim dpcdS1 As Double = GetdpcdS(S_ele(0), pc_0, beta)
'                Dim dpcdS2 As Double = GetdpcdS(S_ele(1), pc_0, beta)
'                Dim dpcdS3 As Double = GetdpcdS(S_ele(2), pc_0, beta)
'                Dim dpcdS4 As Double = GetdpcdS(S_ele(3), pc_0, beta)
'                Dim Dl1 As Double = GetDl(KK, yita_l, dpcdS1, kr1)
'                Dim Dl2 As Double = GetDl(KK, yita_l, dpcdS2, kr2)
'                Dim Dl3 As Double = GetDl(KK, yita_l, dpcdS3, kr3)
'                Dim Dl4 As Double = GetDl(KK, yita_l, dpcdS4, kr4)
'                Dim f1 As Double = Getf(phi, S_ele(0))
'                Dim f2 As Double = Getf(phi, S_ele(1))
'                Dim f3 As Double = Getf(phi, S_ele(2))
'                Dim f4 As Double = Getf(phi, S_ele(3))
'                Dim Dv1 As Double = GetDv(rho_v, rho_l, dpcdS1, f1, D, pg)
'                Dim Dv2 As Double = GetDv(rho_v, rho_l, dpcdS2, f2, D, pg)
'                Dim Dv3 As Double = GetDv(rho_v, rho_l, dpcdS3, f3, D, pg)
'                Dim Dv4 As Double = GetDv(rho_v, rho_l, dpcdS4, f4, D, pg)
'                Dim d1 As Double = Dl1 + Dv1
'                Dim d2 As Double = Dl2 + Dv2
'                Dim d3 As Double = Dl3 + Dv3
'                Dim d4 As Double = Dl4 + Dv4
'                cieNew = New CIETransNew(
'            Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
'            Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
'            Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
'            Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
'            d1, d2, d3, d4)
'                AssembleKg(cieNew.getbe, bg, i)
'                AssembleKg(cieNew.getAe, Ag, i)
'            Next

'            'step 3: now, we have assembled Sg_old, Ag and bg , to get LHS and RHS and solve it
'            getNewLHS(NewLHS, NNodes, phi, Ag, bg, dt)
'            getNewR(NewR, NNodes, phi, Ag, bg, dt)
'            RHS = MultiplyMatrixWithVector(NewR, S_old)
'            GetX(S_new, NewLHS, RHS)

'            'Do
'            '    'step 4: check residual convergence
'            '    For i = 0 To NElements - 1
'            '        se = New SETrans(
'            '              S_new(Elements(i).Node1 - 1), S_new(Elements(i).Node2 - 1),
'            '              S_new(Elements(i).Node3 - 1), S_new(Elements(i).Node4 - 1)
'            '              )
'            '        S_ele = se.getSe
'            '        Dim kr1 As Double = Getkr(S_ele(0), m)
'            '        Dim kr2 As Double = Getkr(S_ele(1), m)
'            '        Dim kr3 As Double = Getkr(S_ele(2), m)
'            '        Dim kr4 As Double = Getkr(S_ele(3), m)
'            '        Dim pc1 As Double = Getpc(S_ele(0), pc_0, beta, St)
'            '        Dim pc2 As Double = Getpc(S_ele(1), pc_0, beta, St)
'            '        Dim pc3 As Double = Getpc(S_ele(2), pc_0, beta, St)
'            '        Dim pc4 As Double = Getpc(S_ele(3), pc_0, beta, St)
'            '        Dim dpcdS1 As Double = GetdpcdS(S_ele(0), pc_0, beta)
'            '        Dim dpcdS2 As Double = GetdpcdS(S_ele(1), pc_0, beta)
'            '        Dim dpcdS3 As Double = GetdpcdS(S_ele(2), pc_0, beta)
'            '        Dim dpcdS4 As Double = GetdpcdS(S_ele(3), pc_0, beta)
'            '        Dim Dl1 As Double = GetDl(KK, yita_l, dpcdS1, kr1)
'            '        Dim Dl2 As Double = GetDl(KK, yita_l, dpcdS2, kr2)
'            '        Dim Dl3 As Double = GetDl(KK, yita_l, dpcdS3, kr3)
'            '        Dim Dl4 As Double = GetDl(KK, yita_l, dpcdS4, kr4)
'            '        Dim f1 As Double = Getf(phi, S_ele(0))
'            '        Dim f2 As Double = Getf(phi, S_ele(1))
'            '        Dim f3 As Double = Getf(phi, S_ele(2))
'            '        Dim f4 As Double = Getf(phi, S_ele(3))
'            '        Dim Dv1 As Double = GetDv(rho_v, rho_l, dpcdS1, f1, D, pg)
'            '        Dim Dv2 As Double = GetDv(rho_v, rho_l, dpcdS2, f2, D, pg)
'            '        Dim Dv3 As Double = GetDv(rho_v, rho_l, dpcdS3, f3, D, pg)
'            '        Dim Dv4 As Double = GetDv(rho_v, rho_l, dpcdS4, f4, D, pg)
'            '        Dim d1 As Double = Dl1 + Dv1
'            '        Dim d2 As Double = Dl2 + Dv2
'            '        Dim d3 As Double = Dl3 + Dv3
'            '        Dim d4 As Double = Dl4 + Dv4
'            '        cieNew = New CIETransNew(
'            '              Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
'            '              Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
'            '              Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
'            '              Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
'            '              d1, d2, d3, d4)
'            '        AssembleKg(cieNew.getbe, bg, i)
'            '        AssembleKg(cieNew.getAe, Ag, i)
'            '    Next
'            '    getNewLHS(NewLHS, NNodes, phi, Ag, bg, dt)
'            '    getNewR(NewR, NNodes, phi, Ag, bg, dt)
'            '    RHS = MultiplyMatrixWithVector(NewR, S_old)
'            '    Dim RHS_ite = MultiplyMatrixWithVector(NewLHS, S_new)
'            '    For k = 0 To RHS_ite.Length - 1
'            '        R(k) = RHS_ite(k) - RHS(k)
'            '    Next
'            '    Norm_R = GetNorm(R)
'            '    GetX(S_new, NewLHS, RHS_ite)
'            'Loop Until Norm_R <= tol

'            'step 5: data stockage
'            For j = 0 To NNodes - 1
'                If S_new(j) >= 1 Then
'                    S_new(j) = 1
'                ElseIf S_new(j) <= 0 Then
'                    S_new(j) = 0
'                End If
'                ''isotherm state check 
'                If Node_w(j) = 0 And S_new(j) > S_old(j) Then 'state change from desorption to adsorption
'                    Node_w(j) = 1
'                ElseIf Node_w(j) = 1 And S_new(j) < S_old(j) Then 'adsorption to desorption
'                    Node_w(j) = 0
'                End If
'                If Nodes(j).NumExpo <> 0 Then
'                    X_node = Nodes(j).x
'                    Y_node = Nodes(j).y
'                    If Math.Abs(X_node - X_lower) <= 0.00001 And Expo_X_lower = True Then
'                        S_new(j) = GetHtoS(H_bound1, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, Node_w(j))
'                    ElseIf Math.Abs(X_node - X_upper) <= 0.00001 And Expo_X_upper = True Then
'                        S_new(j) = GetHtoS(H_bound2, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, Node_w(j))
'                    ElseIf Math.Abs(Y_node - Y_lower) <= 0.00001 And Expo_Y_lower = True Then
'                        S_new(j) = GetHtoS(H_bound3, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, Node_w(j))
'                    ElseIf Math.Abs(Y_node - Y_upper) <= 0.00001 And Expo_Y_upper = True Then
'                        S_new(j) = GetHtoS(H_bound4, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, Node_w(j))
'                    End If
'                End If
'                w_new(j) = wsat * S_new(j)
'            Next
'            'Next
'            'step 6: Post-process : plot 2D image and export result .txt file 
'            For i = 0 To NElements - 1
'                Elements(i).Sl(ti + 1) = (S_new(Elements(i).Node1 - 1) + S_new(Elements(i).Node2 - 1) + S_new(Elements(i).Node3 - 1) + S_new(Elements(i).Node4 - 1)) * 100 / 4
'                SlRange.AddValue(Elements(i).Sl(ti + 1))
'            Next
'            Time(ti + 1) = ti * dt / 3600 ' Time in hour
'            'compute variation
'            fieldSnew_average = S_new.Average
'            fieldSold_average = S_old.Average
'            fieldwnew_average = w_new.Average
'            fieldwold_average = w_old.Average
'            dS_avg = fieldSnew_average - fieldSold_average + dS_avg
'            dw_avg = fieldwnew_average - fieldwold_average + dw_avg
'            If (ti * dt / T_sauv) = Int(ti * dt / T_sauv) And Int(ti * dt / T_sauv) > 0 Then ' check register time
'                RegisterField(nFic1, ti * dt, nDof, dS_avg, S_new)
'                PrintLine(CInt(nFic1), " ")
'                RegisterField(nFic2, ti * dt, nDof, dw_avg, w_new)
'                PrintLine(CInt(nFic2), " ")
'            End If
'        End If
'    Next

'    FileClose(CInt(nFic1))
'    FileClose(CInt(nFic2))
'    MsgBox("End of 2D transport", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "End")
'    Analysed = True
'    Me.Invoke(Sub()
'                  LabelProgress.Visible = False
'              End Sub)
'End Class

