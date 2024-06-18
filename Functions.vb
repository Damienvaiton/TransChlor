Module Functions

    'calcul du coefficient de diffusion thermique
    Public Function MT(ByRef qGran As Single, ByRef capCal As Single, ByRef W As Decimal, ByRef ciment As Single, ByRef Hg As Single, ByRef T_old As Decimal) As Decimal
        Dim cT As Decimal
        Const cW As Single = 4.2
        Const cZ As Single = 0.84
        Dim Temper As Decimal = 0
        Dim TT(4) As Decimal
        Dim Para(4) As Decimal
        Dim A(4, 4) As Double
        Dim tempo As Decimal
        Dim Lambda As Decimal
        Dim i As Short
        Dim k As Short
        'Dim Wc As Decimal
        'Wc = W
        'If Wc < 0 Then Wc = 0
        'If Wc > 500 Then Wc = 100
        A(0, 0) = 1.89890482236446
        A(1, 0) = 0.0150204938034272
        A(2, 0) = -0.00199503283634373
        A(3, 0) = 0.000933636457388569
        A(4, 0) = -0.000036168677689976
        A(0, 1) = 0.00336784223942822
        A(1, 1) = -0.00108514866715481
        A(2, 1) = 0.00717045610756123
        A(3, 1) = -0.000838746806026253
        A(4, 1) = 0.0000225795479813709
        A(0, 2) = -0.000177541199440964
        A(1, 2) = 0.0000048925253459615
        A(2, 2) = -0.000266164523769935
        A(3, 2) = 0.0000309974453424371
        A(4, 2) = -0.000000808707665874939
        A(0, 3) = 0.00000319492127255241
        A(1, 3) = 0.000000313219805503464
        A(2, 3) = 0.00000363355856819264
        A(3, 3) = -0.000000418290254241918
        A(4, 3) = 0.0000000104601101566469
        A(0, 4) = -0.0000000186580757693275
        A(1, 4) = -0.00000000266810509407622
        A(2, 4) = -0.0000000174502096308597
        A(3, 4) = 0.00000000197825353025406
        A(4, 4) = -0.0000000000472449653832042

        cT = CDec(qGran) * CDec(capCal) + W * CDec(cW) + CDec(ciment) * CDec(cZ) - CDec(0.2) * CDec(ciment) * CDec(Hg) * CDec(cW)
        If T_old < CDec(0) Then
            Temper = CDec(0)
        Else
            Temper = T_old
        End If
        For i = CShort(0) To CShort(4)
            TT(i) = CDec(Temper ^ i)
        Next
        For i = CShort(0) To CShort(4)
            tempo = CDec(0)
            For k = CShort(0) To CShort(4)
                tempo = tempo + CDec(A(i, k)) * TT(k)
            Next
            Para(i) = tempo
        Next
        Lambda = CDec(0)
        For i = CShort(0) To CShort(4)
            TT(i) = CDec((W / 10) ^ i)
            Lambda = Lambda + Para(i) * TT(i)
        Next
        MT = CDec(1000) * Lambda / cT
    End Function

    'calcul du coefficient de diffusion hydrique capillarité
    Public Function MDCcap(ByRef Bord1 As Single, ByRef Bord2 As Single, ByRef coef As Single, ByRef deltaT As Single, ByRef tPrec As Single, ByRef j As Long, ByRef Tijd As Decimal, ByRef TijdOld As Decimal, ByRef Quest As Boolean, ByRef aa As Single, ByRef Hc As Single, ByRef Dcapleft As Decimal, ByVal Dcapright As Decimal, ByRef BDlibre As Boolean, ByRef PosProf As Decimal, ByRef Length As Decimal, ByRef LgLim As Decimal, ByRef ImpHydr As Boolean) As Decimal
        Dim Factor As Single
        ' MDC = moisture diffusion coefficient
        ' Classical formulea of Bazant

        If aa = 0 And Hc = 0 Then
            MDCcap = 0
        Else
            If ImpHydr = False Then
                If BDlibre = False Then
                    If PosProf <= LgLim Then
                        MDCcap = Dcapleft
                    ElseIf PosProf >= Length - LgLim Then
                        MDCcap = Dcapright
                    Else
                        MDCcap = ((Dcapright - Dcapleft) * PosProf + Dcapleft * Length - LgLim * (Dcapright + Dcapleft)) / (Length - 2 * LgLim)
                    End If
                Else
                    MDCcap = Dcapleft
                End If
            Else
                MDCcap = 0.000129
            End If
            If Bord1 > CSng(0.9999) Or Bord2 > CSng(0.9999) Then 'si pluie
                If j = 0 And Tijd <> TijdOld And Quest = True Then tPrec = tPrec + deltaT / (3600 * 24)
                If tPrec > 10 Then
                    Factor = CDec(((1) / (CDec(1.0) - CDec(Hc))) ^ 4)
                Else
                    Factor = CDec(((tPrec / 10) / (CDec(1.0) - CDec(Hc))) ^ 4)
                End If
                MDCcap = MDCcap * (CDec(aa) + (CDec(1.0) - CDec(aa)) / (CDec(1.0) + Factor))
            Else
                MDCcap = 0
                If j = 0 And Tijd <> TijdOld And Quest = True Then tPrec = 0
            End If
        End If

        'prise en compte de la température
        MDCcap = MDCcap * CDec(coef)
        TijdOld = Tijd
    End Function

    'calcul du coefficient de diffusion hydrique diffusion de vapeur d'eau
    Public Function MDCdiff(ByRef H As Decimal, ByRef coef As Single, ByRef PD As Single, ByRef Hc As Single, ByRef aa As Single, ByRef ED As Single, ByRef ToHydr As Single, ByRef Temperature As Decimal) As Decimal
        Dim Factor As Decimal
        Const RR As Single = 8.3144     'J/(°K.mol) constante des gaz parfaits

        If H > CDec(1.0) Then
            MDCdiff = PD
        Else
            If H < CDec(0.0) Then
                MDCdiff = CDec(aa) * PD
            Else
                Factor = CDec(((CDec(1.0) - H) / (CDec(1.0) - CDec(Hc))) ^ 4)
                MDCdiff = PD * (CDec(aa) + (CDec(1.0) - CDec(aa)) / (CDec(1.0) + Factor))
            End If
        End If
        'prise en compte de la température
        MDCdiff = MDCdiff * System.Math.Exp(-ED * (1 / ToHydr - 1 / (Temperature + 273.16)) / RR)
        MDCdiff = MDCdiff * CDec(coef)
    End Function

    'calcul du coefficient de diffusion des ions chlorures
    Public Function MDCl(ByRef Di As Single, ByRef Ecl As Single, ByRef ToCl As Single, ByRef Temperature As Decimal, ByRef coef As Single) As Decimal
        'Const RR As Single = 8.3144     'J/(°K.mol) constante des gaz parfaits
        MDCl = Di * System.Math.Exp(Ecl * (Temperature - ToCl))
        MDCl = MDCl * CDec(coef)
    End Function

    'courbe d'adsorption et de désorption
    Public Function Water(ByVal H As Decimal, ByVal Hol As Decimal, ByRef T As Decimal, ByRef Tijd As Decimal, ByRef tPro As Single, ByRef Vct As Single, ByRef Nct As Single, ByRef EsC As Single, ByRef Wsat As Single, ByRef Hydr As Single, ByRef ciment As Single, ByRef Wol As Boolean) As Decimal
        Dim Time As Decimal
        Dim f1 As Decimal
        Dim f2 As Decimal
        Dim f3 As Decimal
        Dim f4 As Decimal
        Dim f5 As Decimal
        Dim f6 As Decimal
        Dim f7 As Decimal
        Dim f8 As Decimal
        Dim f9 As Decimal
        Dim f10 As Decimal
        Dim f11 As Decimal
        Dim f12 As Decimal
        Dim f13 As Decimal
        Dim Para(3, 3) As Decimal
        Dim b(3) As Decimal
        Dim a(3) As Decimal
        Dim wcOld, wcNew, wNew As Decimal
        Dim i As Short
        Dim j As Short
        Dim tst01 As Boolean = False
        Dim VH As Single
        Dim VHol As Single
        Time = Tijd + CDec(tPro)
        VH = CInt(H * 1000) / 1000
        VHol = CInt(Hol * 1000) / 1000
        H = CInt(H * 100) / 100
        Hol = CInt(Hol * 100) / 100
        If T < -100 Then T = -100
        If T > 100 Then T = 100
        If System.Math.Abs(H - Hol) = 0.01 And System.Math.Abs(VH - VHol) < 0.02 Then Hol = H 'court-circuite les petites valeurs proche 0.05
        If H = Hol Then
            If Wol = True Then
                H = H - 0.1
            Else
                H = H + 0.1
            End If
            tst01 = True
        End If
        If H <= Hol Then
            If tst01 = True Then
                H = H + 0.1
                tst01 = False
            End If
            Wol = True
            ' On the desorption branch
            f1 = 0.125                                                          'c1
            f2 = 0.173 - 0.431 * ((T - 20) / 25)                                'c2
            f3 = 0.06 + 0.392 * ((T - 20) / 25)                                 'c3
            f4 = 0.17 + (0.035 + 0.029 * (EsC - 0.4) / 0.15) * ((T - 20) / 25)  'c4

            f5 = 0.389 - 26 * EsC / 15 + 4.4 * EsC ^ 2 - 8 * EsC ^ 3 / 3        'we
            f6 = 1 - 0.161 * Hydr                                               'ht

            Para(1, 1) = f6 ^ 2             'para1
            Para(1, 2) = 1 - 2 * f6         'para2
            Para(1, 3) = Para(1, 1) - f6    'para3
            Para(2, 1) = -2 * f6            'para4
            Para(2, 2) = -Para(2, 1)        'para5
            Para(2, 3) = 1 - Para(1, 1)     'para6
            Para(3, 1) = 1                  'para7
            Para(3, 2) = -1                 'para8
            Para(3, 3) = f6 - 1             'para9

            b(1) = EsC - f4 * Hydr                          'b1
            b(2) = (f1 + f2 * f6 + f3 * f6 ^ 2) * Hydr      'b2
            b(3) = (f2 + 2 * f3 * f6) * Hydr                'b3

            For i = 1 To 3
                a(i) = 0
            Next

            For i = 1 To 3
                For j = 1 To 3
                    a(i) = a(i) + Para(i, j) * b(j)
                Next
            Next

            f7 = 1 / (1 - f6) ^ 2
            For i = 1 To 3
                a(i) = a(i) * f7         'a, b, c
            Next
            f8 = 0                                                  'A
            f9 = Hydr / 0.35 * (-f1 / 0.35 + 0.35 * f3)             'C
            f10 = (f2 + 0.7 * f3) * Hydr - 0.7 * f9                 'B
            f11 = (a(1) + a(2) * 1.0 + a(3) * 1.0 ^ 2) * ciment     'wm
            f11 = ciment * Wsat / f11

            Select Case Hol
                Case Is <= 0.35
                    wcOld = (f8 + f10 * Hol + f9 * Hol ^ 2) * f11
                Case Is < f6
                    wcOld = (f1 + f2 * Hol + f3 * Hol ^ 2) * Hydr * f11
                Case Else
                    wcOld = (a(1) + a(2) * Hol + a(3) * Hol ^ 2) * f11
            End Select
            Select Case H
                Case Is <= 0.35
                    wcNew = (f8 + f10 * H + f9 * H ^ 2) * f11
                Case Is < f6
                    wcNew = (f1 + f2 * H + f3 * H ^ 2) * Hydr * f11
                Case Else
                    wcNew = (a(1) + a(2) * H + a(3) * H ^ 2) * f11
            End Select

            If wcOld > Wsat Then wcOld = Wsat
            If wcNew > Wsat Then wcNew = Wsat
            If wcOld < 0 Then wcOld = 0
            If wcNew < 0 Then wcNew = 0

            Water = wcNew

        Else
            If tst01 = True Then
                H = H - 0.1
                tst01 = False
            End If
            Wol = False
            ' On the sorption branche
            If Time < CDec(5) Then      'calcul de Vt(t) correstpondant à f2 et Nt(t) = f3
                f2 = CDec(0.024)
                f3 = CDec(5.5)
            Else
                f2 = CDec(0.068) - CDec(0.22) / Time
                f3 = CDec(2.5) + CDec(15) / Time
            End If
            f2 = f2 * CDec(Vct) * (CDec(0.85) + CDec(0.45) * CDec(EsC)) * CDec(1.0) ' calcul de vm
            f3 = f3 * (CDec(0.33) + CDec(2.2) * CDec(EsC)) * CDec(Nct) * CDec(1.0) ' calcul de n
            f4 = CDec(System.Math.Exp(855 / (273.16 + T))) ' calcul de C
            f5 = ((CDec(1) - CDec(1) / f3) * f4 - CDec(1)) / (f4 - CDec(1)) ' calcul de k
            f6 = ciment * (1 + EsC)
            f9 = f6 * f4 * f5 * f2 * CDec(1.0) / ((CDec(1) - f5 * CDec(1.0)) * (CDec(1) + (f4 - CDec(1)) * f5 * CDec(1.0))) 'calcul de wmax
            wcOld = f6 * f4 * f5 * f2 * Hol / ((CDec(1) - f5 * Hol) * (CDec(1) + (f4 - CDec(1)) * f5 * Hol))
            wcNew = f6 * f4 * f5 * f2 * H / ((CDec(1) - f5 * H) * (CDec(1) + (f4 - CDec(1)) * f5 * H))
            wcOld = wcOld * Wsat / f9
            wcNew = wcNew * Wsat / f9

            If wcOld > Wsat Then wcOld = Wsat
            If wcNew > Wsat Then wcNew = Wsat
            If wcOld < 0 Then wcOld = 0
            If wcNew < 0 Then wcNew = 0

            Water = wcNew

        End If

        'If CDbl(H * 1000) <= CDbl(Hol * 1000) Then Water = Wol
        If Water > Wsat Then Water = Wsat
        If Water < 0 Then Water = 0
        Hol = H
    End Function

    'calcul par itération le passage de cT à cf
    Public Function Cfree(ByVal cT As Decimal, ByVal gamma As Decimal, ByVal w As Decimal) As Decimal
        Dim Deltacf As Single
        Dim SensPos As Boolean = True
        Dim ItcT As Decimal
        Dim test As Decimal = 10
        Deltacf = 1
        Cfree = 0.0000001 - 1
        Do While System.Math.Abs(test) > cT * 0.0001
            Cfree = Cfree + Deltacf
            If Cfree < 0.00000001 Or cT = 0 Then
                Cfree = 0
                Exit Do
            End If
            ItcT = w * Cfree / 1000 + gamma * Cfree ^ 0.379
            test = cT - ItcT
            If test > 0 Then
                If SensPos = False Then
                    Deltacf = -Deltacf / 10
                    SensPos = True
                End If
            ElseIf test < 0 Then
                If SensPos = True Then
                    Deltacf = -Deltacf / 10
                    SensPos = False
                End If
            End If
        Loop
    End Function


    ''Inversion de matrice pour le transport par convection des cl-
    'Public Sub InvMaBa(ByRef L() As Decimal, ByRef b() As Decimal, ByRef Ne As Short)
    '    Dim i As Long
    '    Dim j As Long
    '    Dim k As Long
    '    Dim n As Long = 2 * Ne - 2
    '    Const m = 4
    '    Dim b01 As Long
    '    Dim b02 As Long
    '    Dim a(n, 2 * m + 1) As Decimal

    '    'Construction de la matrice a
    '    For i = 2 To n Step 2
    '        If i <> 2 Then a(i, 1) = -1 / L(i / 2 - 1)
    '        If i <> 2 Then a(i, 2) = 3 / L(i / 2 - 1)
    '        a(i, 3) = 1 / L(i / 2)
    '        a(i, 4) = 7 / L(i / 2)
    '        a(i, 5) = 5 / L(i / 2 + 1)
    '        a(i, 6) = a(i, 5)
    '        If i <> n Then a(i, 7) = 3 / L(i / 2 + 2)
    '        If i <> n Then a(i, 8) = 1 / L(i / 2 + 2)
    '    Next
    '    For i = 1 To n Step 2
    '        If i <> 2 Then a(i, 2) = -L((i + 1) / 2) / L((i + 1) / 2 - 1)
    '        If i <> 2 Then a(i, 3) = 3 * L((i + 1) / 2) / L((i + 1) / 2 - 1)
    '        a(i, 4) = -3
    '        a(i, 5) = -1
    '        a(i, 6) = 3 * L((i + 1) / 2) / L((i + 1) / 2 + 1)
    '        a(i, 7) = a(i, 6) / 3
    '    Next
    '    For i = 1 To 4
    '        For j = 1 To 5 - i
    '            a(i, j) = 0
    '            a(n + 1 - i, 2 * m + 2 - j) = 0
    '        Next
    '    Next

    '    For i = 2 To m + 1
    '        a(1, m + i) = a(1, m + i) / a(1, m + 1)
    '    Next
    '    For k = 2 To n - 1
    '        b01 = k - m
    '        If b01 < 1 Then b01 = 1
    '        For j = b01 To k - 1
    '            a(k, m + 1) = a(k, m + 1) - a(k, m + j - k + 1) * a(j, m + k - j + 1)
    '        Next
    '        b01 = m + k
    '        If b01 > n Then b01 = n
    '        For i = k + 1 To b01
    '            b02 = k - m
    '            If b02 < 1 Then b02 = 1
    '            For j = b02 To k - 1
    '                If m + j - i + 1 >= 1 Then a(i, m + k - i + 1) = a(i, m + k - i + 1) - a(i, m + j - i + 1) * a(j, m + k - j + 1)
    '            Next
    '            For j = b02 To k - 1
    '                If m + i - j + 1 <= 2 * m + 1 Then a(k, m + i - k + 1) = (a(k, m + i - k + 1) - a(k, m + j - k + 1) * a(j, m + i - j + 1))
    '            Next
    '            a(k, m + i - k + 1) = a(k, m + i - k + 1) / a(k, m + 1)
    '        Next
    '    Next
    '    For j = n - m To n - 1
    '        a(n, m + 1) = a(n, m + 1) - a(n, m + j - n + 1) * a(j, m + n - j + 1)
    '    Next

    '    b(1) = b(1) / a(1, m + 1)
    '    For i = 2 To n
    '        b02 = i - m
    '        If b02 < 1 Then b02 = 1
    '        For j = b02 To i - 1
    '            b(i) = b(i) - a(i, m + j - i + 1) * b(j)
    '        Next
    '        b(i) = b(i) / a(i, m + 1)
    '    Next
    '    For i = n - 1 To 1 Step -1
    '        b01 = m + i
    '        If b01 > n Then b01 = n
    '        For j = i + 1 To b01
    '            b(i) = b(i) - a(i, m + j - i + 1) * b(j)
    '        Next
    '    Next
    'End Sub

End Module
