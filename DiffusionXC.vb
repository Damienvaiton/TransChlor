'Option Explicit On
'Imports System
'Imports System.ComponentModel
'Imports System.IO
'Imports System.Linq

'' Developper's note. Module de calcul diffusion 2D Xuande.2020.07.20
'Public Class DiffusionXC
'    Private NNodes, NElements As Integer
'    Private Nodes() As NodeTrans
'    Private Elements() As ElementTrans
'    Public Sub Analyse(Directory)
''    'Material parameters, can be converted from user defined input
''    Dim pg As Double = 101325 'atmosphere pressure(pa)
''    Dim rho_v As Double = 1 'density of vapor (kg/m3)
''    Dim rho_l As Double = 1000 'density of liquid (kg/m3)
''    Dim rho_c As Double = 2500 'density of concrete (kg/m3)
''    Dim pc_0 As Double = 18.6237 ' parameter for ordinary concrete (Mpa)
''    Dim m As Double = 0.461 ' parameter for ordinary concrete / for cement paste 37.5479
''    Dim beta As Double = 2.2748 ' parameter for ordinary concrete / for cement paste 2.1684
''    Dim KK As Double = 0.000000000000355 'intrinsic permeability (m2)
''    Dim yita_l As Double = 0.00089 'viscosity of water (kg/m.s)
''    Dim phi As Double = 0.12 'porosity (-)
''    Dim type As Integer = 1 'cement type (-)
''    Dim W_C_ratio As Double = 0.4 'porosity (-)
''    Dim C As Double = 400 'density of cement (kg/m3)
''    Dim Water_tot As Double = W_C_ratio * C 'density of cement (kg/m3)
''    Dim day As Double
''    Dim D0 As Double = 0.00006  ' mm2/s
''    Dim alpha_0 As Double = 0.05
''    Dim Hc As Double = 0.75
''    Dim w As Double = 0 'indicator for isotherm curve, judge if we choose to use desorption (w = 1) or adsorption curve (w = 0) 
''    Dim alpha As Double = 0.85 'hydration degree (-)
''    Dim Tk As Double = 293 'temperature in (K), attention, faudrait l'inserer dans le boucle parce que cela va varier en fonction de temps et espace, XC 2020.07.30
''    Dim Tc As Double = Tk - 273 'temperature in (C)
''    Dim wsat As Double = GetWsat(Water_tot, C, alpha) 'saturated water mass (kg/m3)

''    'Geometry parameters for boundary check program
''    Dim X_upper As Double = 75 '200'mm, upper bound of X coordinate
''    Dim X_lower As Double = -75 '200'mm, upper bound of X coordinate
''    Dim Y_upper As Double = 75 '100'mm, upper bound of Y coordinate
''    Dim Y_lower As Double = -75 '100'mm, upper bound of Y coordinate
''    Dim Expo_X_upper As Boolean = False 'exposure on right most side
''    Dim Expo_X_lower As Boolean = True 'exposure on left most side
''    Dim Expo_Y_upper As Boolean = False 'exposure on top most side
''    Dim Expo_Y_lower As Boolean = False 'exposure on bottom most side
''    Dim X_node As Double
''    Dim Y_node As Double

''    'Computation parameters
''    Dim nDof As Integer = NNodes
''    Dim H_int As Double = 0.75 'initial relative humidity
''    Dim S_int As Double = GetHtoS(H_int, type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w) 'initial saturation field
''    Dim H_bound1 As Double = 1 - 1.0E-22 'boundary relative humidity
''    Dim H_bound2 As Double = 1 - 1.0E-22 'boundary relative humidity
''    Dim H_bound3 As Double = 1 - 1.0E-22 'boundary relative humidity
''    Dim H_bound4 As Double = 1 - 1.0E-22 'boundary relative humidity
''    Dim dt As Double = 3600   'time interval (s)
''    Dim tmax As Double = 3600 * 24 * 3 'end time (s) 100 day / 72h
''    Dim nFic1 As Short
''    Dim nFic2 As Short
''    Dim nfic3 As Short
''    Dim outfile(3) As String
''    Dim ti As Integer
''    Dim ind As Integer = CInt(tmax / dt)
''    Dim T_sauv As Double = 14400
''    Dim H_old(nDof - 1) As Double
''    Dim H_new(nDof - 1) As Double
''    Dim S_old(nDof - 1) As Double
''    Dim S_new(nDof - 1) As Double
''    Dim w_old(nDof - 1) As Double
''    Dim w_new(nDof - 1) As Double
''    Dim fieldHnew_average As Double
''    Dim fieldHold_average As Double
''    Dim fieldSnew_average As Double
''    Dim fieldSold_average As Double
''    Dim fieldwnew_average As Double
''    Dim fieldwold_average As Double
''    Dim dH_avg As Double
''    Dim dw_avg As Double
''    Dim dS_avg As Double
''    Dim LHS(,) As Double
''    Dim R(,) As Double
''    Dim RHS() As Double
''    Dim bg(nDof - 1, nDof - 1) As Double 'Global b matrix
''    Dim Ag(nDof - 1, nDof - 1) As Double 'Global A matrix
''    Dim cieNew As CIETransNew
''    Dim he As HETrans
''    Dim H_ele() As Double
''    Dim i, j As Integer

''    ''Creating output .txt computation result file 2020-07-17 Xuande 
''    outfile(1) = Directory & "\" & "R_H_DiffusionModel" & ".txt"
''    outfile(2) = Directory & "\" & "R_W_DiffusionModel" & ".txt"
''    outfile(3) = Directory & "\" & "R_S_DiffusionModel" & ".txt"
''    nFic1 = CShort(FreeFile())
''    FileOpen(CInt(nFic1), outfile(1), OpenMode.Output)
''    nFic2 = CShort(FreeFile())
''    FileOpen(CInt(nFic2), outfile(2), OpenMode.Output)
''    nfic3 = CShort(FreeFile())
''    FileOpen(CInt(nfic3), outfile(3), OpenMode.Output)
''    Print(nFic1, "RH", ",", nDof, ",", "Average RH", ",", "dH", ",", TAB)
''    For jj As Integer = 0 To nDof - 1
''        Print(CInt(nFic1), jj + CShort(1), ",", TAB)
''    Next jj
''    PrintLine(CInt(nFic1), " ")
''    Print(nFic2, "W", ",", nDof, ",", "Average W", ",", "dW", ",", TAB)
''    For jj As Integer = 0 To nDof - 1
''        Print(CInt(nFic2), jj + CShort(1), ",", TAB)
''    Next jj
''    PrintLine(CInt(nFic2), " ")
''    Print(nfic3, "S", ",", nDof, ",", "Average S", ",", "dS", ",", TAB)
''    For jj As Integer = 0 To nDof - 1
''        Print(CInt(nfic3), jj + CShort(1), ",", TAB)
''    Next jj
''    PrintLine(CInt(nfic3), " ")
''    HRRange = New Range
''    SlRange = New Range
''    ReDim Time(ind + 2)
''    Time(0) = 0
''    Me.Invoke(Sub()
''                  LabelProgress.Visible = True
''              End Sub)
''    For i = 0 To NElements - 1
''        ReDim Elements(i).HR(ind + 1)
''        Elements(i).HR(0) = H_int * 100
''        HRRange.AddValue(Elements(i).HR(0))
''    Next

''    'Globlal time loop
''    For ti = 0 To ind
''        Me.Invoke(Sub()
''                      LabelProgress.Text = CStr(ti) + " / " + CStr(ind)
''                      Me.Refresh()
''                  End Sub)

''        ' step 1: initialisation and boundary check 
''        If ti = 0 Then
''            Print(CInt(nFic1), "0", ",", "0", ",", TAB)
''            Print(CInt(nFic2), "0", ",", "0", ",", TAB)
''            Print(CInt(nfic3), "0", ",", "0", ",", TAB)
''            For i = 0 To nDof - 1
''                H_old(i) = H_int
''                S_old(i) = GetHtoS(H_old(i), type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
''                w_old(i) = wsat * S_old(i)
''                H_new(i) = H_old(i)
''                S_new(i) = S_old(i)
''                w_new(i) = w_old(i)
''            Next
''            Dim w_avg_0 As Double = w_old.Average()
''            Dim H_avg_0 As Double = H_old.Average()
''            Dim S_avg_0 As Double = S_old.Average()
''            Print(CInt(nFic1), H_avg_0, ",", "0", ",", TAB)
''            Print(CInt(nFic2), w_avg_0, ",", "0", ",", TAB)
''            Print(CInt(nfic3), S_avg_0, ",", "0", ",", TAB)
''            'plot initial state
''            For i = 0 To NElements - 1
''                ReDim Elements(i).HR(ind + 2)
''                ReDim Elements(i).Sl(ind + 2)
''                Elements(i).HR(0) = H_new(i) * 100
''                Elements(i).Sl(0) = S_new(i) * 100
''                HRRange.AddValue(Elements(i).HR(0))
''                SlRange.AddValue(Elements(i).Sl(0))
''            Next
''            'apply BC
''            For i = 0 To nDof - 1
''                Print(CInt(nFic1), H_old(i), ",", TAB)
''                Print(CInt(nFic2), w_old(i), ",", TAB)
''                Print(CInt(nfic3), S_old(i), ",", TAB)
''                If Nodes(i).NumExpo <> 0 Then
''                    X_node = Nodes(i).x
''                    Y_node = Nodes(i).y
''                    If Math.Abs(X_node - X_lower) <= 0.00001 And Expo_X_lower = True Then
''                        H_old(i) = H_bound1
''                    ElseIf Math.Abs(X_node - X_upper) <= 0.00001 And Expo_X_upper = True Then
''                        H_old(i) = H_bound2
''                    ElseIf Math.Abs(Y_node - Y_lower) <= 0.00001 And Expo_Y_lower = True Then
''                        H_old(i) = H_bound3
''                    ElseIf Math.Abs(Y_node - Y_upper) <= 0.00001 And Expo_Y_upper = True Then
''                        H_old(i) = H_bound4
''                    End If
''                Else
''                    H_new(i) = H_old(i)
''                End If
''                'isotherm state check 
''                If w = 0 And H_new(i) > H_old(i) Then 'state change from desorption to adsorption
''                    w = 1
''                ElseIf w = 1 And H_new(i) < H_old(i) Then 'adsorption to desorption
''                    w = 0
''                End If
''                S_new(i) = GetHtoS(H_new(i), type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
''                w_new(i) = wsat * S_new(i) * phi
''            Next
''            PrintLine(CInt(nFic1), " ")
''            PrintLine(CInt(nFic2), " ")
''            PrintLine(CInt(nfic3), " ")
''            'plot intital state after BC applied
''            For i = 0 To NElements - 1
''                Elements(i).HR(1) = (H_new(Elements(i).Node1 - 1) + H_new(Elements(i).Node2 - 1) + H_new(Elements(i).Node3 - 1) + H_new(Elements(i).Node4 - 1)) * 100 / 4
''                Elements(i).Sl(1) = (S_new(Elements(i).Node1 - 1) + S_new(Elements(i).Node2 - 1) + S_new(Elements(i).Node3 - 1) + S_new(Elements(i).Node4 - 1)) * 100 / 4
''                HRRange.AddValue(Elements(i).HR(1))
''                SlRange.AddValue(Elements(i).Sl(1))
''            Next
''            Time(1) = dt / 1000 / 3600 ' Time in hour
''            'compute variation
''            fieldHnew_average = H_new.Average
''            fieldHold_average = H_old.Average
''            fieldSnew_average = S_new.Average
''            fieldSold_average = S_old.Average
''            fieldwnew_average = w_new.Average
''            fieldwold_average = w_old.Average
''            dH_avg = fieldHnew_average - fieldHold_average + dH_avg
''            dw_avg = fieldwnew_average - fieldwold_average + dw_avg
''            dS_avg = fieldSnew_average - fieldSold_average + dS_avg
''            'imagine BC is applied in very short time (dt/1000), then output the field variables with BC applied on it
''            RegisterField(nFic1, dt / 1000.0, nDof, dH_avg, H_new)
''            PrintLine(CInt(nFic1), " ")
''            RegisterField(nFic2, dt / 1000.0, nDof, dw_avg, w_new)
''            PrintLine(CInt(nFic2), " ")
''            RegisterField(nfic3, dt / 1000.0, nDof, dS_avg, S_new)
''            PrintLine(CInt(nfic3), " ")
''        Else
''            For i = 0 To nDof - 1                 ''regular loop
''                H_old(i) = H_new(i)
''                S_old(i) = S_new(i)
''                w_old(i) = w_new(i)
''            Next

''            'step 2: elemental and global Matrix constructions
''            'Matrix assembling
''            For i = 0 To NElements - 1
''                he = New HETrans(
''                          H_old(Elements(i).Node1 - 1), H_old(Elements(i).Node2 - 1),
''                          H_old(Elements(i).Node3 - 1), H_old(Elements(i).Node4 - 1)
''                          )
''                H_ele = he.getHe
''                '' new program using nodal interpolations instead of mean value on elements to calculate diffusion coefficient 2020.08.15 Xuande
''                Dim d1 As Double = GetDh(D0, alpha_0, Hc, Tc, H_ele(0))
''                Dim d2 As Double = GetDh(D0, alpha_0, Hc, Tc, H_ele(1))
''                Dim d3 As Double = GetDh(D0, alpha_0, Hc, Tc, H_ele(2))
''                Dim d4 As Double = GetDh(D0, alpha_0, Hc, Tc, H_ele(3))
''                cieNew = New CIETransNew(
''                      Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
''                      Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
''                      Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
''                      Nodes(Elements(i).Node4 - 1).x, Nodes(Elements(i).Node4 - 1).y,
''                      d1, d2, d3, d4)
''                AssembleKg(cieNew.getbe, bg, i)
''                AssembleKg(cieNew.getAe, Ag, i)
''            Next

''            'step 3: now, we have assembled Hg_old, Ag and bg , to get LHS and RHS
''            getLHS(LHS, NNodes, Ag, bg, dt)
''            getRHS(R, NNodes, Ag, bg, dt)
''            RHS = MultiplyMatrixWithVector(R, H_old)
''            GetX(H_new, LHS, RHS)

''            'step 5: result check
''            For j = 0 To NNodes - 1
''                If H_new(j) >= 1 Then
''                    H_new(j) = 1
''                ElseIf H_new(j) <= 0 Then
''                    H_new(j) = 0
''                End If
''                If Nodes(j).NumExpo <> 0 Then
''                    ' check whether the current boundary is exposed to a boundary condition
''                    X_node = Nodes(j).x
''                    Y_node = Nodes(j).y
''                    If Math.Abs(X_node - X_lower) <= 0.00001 And Expo_X_lower = True Then
''                        H_new(j) = H_bound1
''                    ElseIf Math.Abs(X_node - X_upper) <= 0.00001 And Expo_X_upper = True Then
''                        H_new(j) = H_bound2
''                    ElseIf Math.Abs(Y_node - Y_lower) <= 0.00001 And Expo_Y_lower = True Then
''                        H_new(j) = H_bound3
''                    ElseIf Math.Abs(Y_node - Y_upper) <= 0.00001 And Expo_Y_upper = True Then
''                        H_new(j) = H_bound4
''                    End If
''                End If
''                ''isotherm state check 
''                If w = 0 And H_new(j) > H_old(j) Then 'state change from desorption to adsorption
''                    w = 1
''                ElseIf w = 1 And H_new(j) < H_old(j) Then 'adsorption to desorption
''                    w = 0
''                End If
''                S_new(j) = GetHtoS(H_new(j), type, C, W_C_ratio, Tk, day, rho_l, rho_c, alpha, w)
''                w_new(j) = wsat * S_new(j)
''            Next

''            'step 6: Post-process : plot 2D image and export result .txt file  
''            For i = 0 To NElements - 1
''                Elements(i).HR(ti + 1) = (H_new(Elements(i).Node1 - 1) + H_new(Elements(i).Node2 - 1) + H_new(Elements(i).Node3 - 1) + H_new(Elements(i).Node4 - 1)) * 100 / 4
''                Elements(i).Sl(ti + 1) = (S_new(Elements(i).Node1 - 1) + S_new(Elements(i).Node2 - 1) + S_new(Elements(i).Node3 - 1) + S_new(Elements(i).Node4 - 1)) * 100 / 4
''                HRRange.AddValue(Elements(i).HR(ti + 1))
''                SlRange.AddValue(Elements(i).Sl(ti + 1))
''            Next
''            Time(ti + 1) = ti * dt / 3600 ' Time in hour
''            'compute variation
''            fieldHnew_average = H_new.Average
''            fieldHold_average = H_old.Average
''            fieldSnew_average = S_new.Average
''            fieldSold_average = S_old.Average
''            fieldwnew_average = w_new.Average
''            fieldwold_average = w_old.Average
''            dH_avg = fieldHnew_average - fieldHold_average + dH_avg
''            dw_avg = fieldwnew_average - fieldwold_average + dw_avg
''            dS_avg = fieldSnew_average - fieldSold_average + dS_avg
''            If (ti * dt / T_sauv) = Int(ti * dt / T_sauv) And Int(ti * dt / T_sauv) > 0 Then ' check register time
''                RegisterField(nFic1, ti * dt, nDof, dH_avg, H_new)
''                PrintLine(CInt(nFic1), " ")
''                RegisterField(nFic2, ti * dt, nDof, dw_avg, w_new)
''                PrintLine(CInt(nFic2), " ")
''                RegisterField(nfic3, ti * dt, nDof, dS_avg, S_new)
''                PrintLine(CInt(nfic3), " ")
''            End If
''        End If
''    Next
''    FileClose(CInt(nFic1))
''    FileClose(CInt(nFic2))
''    FileClose(CInt(nfic3))

''    MsgBox("End of 2D diffusion", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "End")
''    Analysed = True

''    Me.Invoke(Sub()
''                  LabelProgress.Visible = False
''              End Sub)
''End Sub
'End Class
