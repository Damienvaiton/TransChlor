Module Meteo

    Dim DataLength As Integer = 440000
    Dim arrPanne(DataLength) As StrctPanne 'matrice d'analyse des pannes, conçu pour 50ans mesure chaque heure
    Dim arrMatrice(DataLength) As StrctCalc 'matrice de calcul, conçu pour 50ans mesure chaque heure
    Dim arrDaten(DataLength) As StrctMeteo 'matrice input météo, conçu pour 50ans mesure chaque heure
    Dim frmTempSeuil As frmMeteo
    Dim iAnzahl As Integer 'nombre de ligne
    Dim NbrAns As Double
    Dim Export As String
    Dim CasInput As Short

    Structure StrctMeteo 'colonnes de la matrice à partir du fichier METEO_*.txt
        Public datum As Integer 'date YYYYMMDD
        Public heure As Integer 'heure HH
        Public moy6 As Single 'température [0.1°C]
        Public moy13 As Single 'humidité relative [0/00]
        Public moy17 As Long 'h pluie [0.1mm]
        Public moy22 As Single 'rayonnement globale [Wh/m2]
        Public moy80 As Single 'h neige neuve [mm]
        Public neige As Single  'h neige calculé
    End Structure

    Structure StrctCalc 'colonnes de la matrice de calcul
        Public year1 As Integer 'année YYYY
        Public month As Integer 'mois MM
        Public day As Integer 'jour DD
        Public hour As Integer 'heure HH
        Public year2 As Single 'année en décimale YYYY,....
        Public HR_brouillard As Single 'exposition brouillard [%]
        Public HR_eclaboussures As Single 'exposition eclaboussures [%]
        Public HR_direct As Single 'exposition directe [%]
        Public HR_ext As Single 'exposition à l'extérieur à l'abri des précipitations [%]
        Public HR_caisson As Single 'exposition dans les caissons [%]
        Public HR_bitume As Single 'exposition dans les caissons [%]
        Public salage1 As String 'salage mécanique
        Public salage2 As String 'salage automatique
        Public T As Single 'température air ventilée [°C]
        Public Ts As Single ' température de surface équivalente [°C]
        Public Tcaisson As Single   'température à l'intérieur caisson [°C]
        Public Text As Single   'température extérieure, à l'abri des précipitations [°C]
    End Structure

    Structure StrctPanne 'colonnes de la matrice des pannes
        Public PanneStart As Integer 'colonnes début des pannes
        Public PanneEnd As Integer 'colonnes fin des pannes
        Public PanneMesure As String ' colonnes des types de pannes
    End Structure

    Structure File 'fichier INPUT
        Public HR As Single 'colonnes HR
        Public Sel As Single 'colonnes salage
        Public Tsurf As Single ' colonnes Température de surface (T ou Ts)
    End Structure

    Public Sub SetExport(ByRef Value As String)

        Export = Value

    End Sub

    Public Sub ReadMeteoFile(ByRef OutFile As String, ByRef PostFile As String, ByRef txtFile As String, ByRef Canc As Boolean)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'lecture fichier METEO_*.txt
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim Filtre As String = "Text files (METEO_*.txt)|METEO_*.txt"
        Dim Index As Short = 1
        Dim Directoire As Boolean = True
        Dim Titre As String = "Sélectionner le fichier météo"

        OpenDialog(OutFile, Canc, Filtre, Index, Directoire, Titre)
        If Canc = True Then End

        Dim nFic As Integer = Microsoft.VisualBasic.FileSystem.FreeFile()

        FileOpen(nFic, OutFile, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
        FilePost(OutFile, PostFile)
        FileOnly(OutFile)
        Dim posTxt As Integer
        posTxt = Len(OutFile) - 10
        txtFile = Mid(OutFile, 7, posTxt)

        Dim line As String
        Input(nFic, line) 'ligne 1 fait rien. Nom d

        Input(nFic, line) 'ligne 2 donne le nombre de lignes

        Try
            DataLength = CInt(line)
            ReDim arrPanne(DataLength)
            ReDim arrMatrice(DataLength)
            ReDim arrDaten(DataLength)
        Catch
        End Try

        Input(nFic, line) 'lire linge 3

        Dim MyPos6 As Integer = InStr(1, line, "6") 'recherche des titre des colonnes 
        Dim MyPos13 As Integer = InStr(1, line, "13")
        Dim MyPos17 As Integer = InStr(1, line, "17")
        Dim MyPos22 As Integer = InStr(1, line, "22")
        Dim MyPos80 As Integer = InStr(1, line, "80")

        If MyPos80 <> 0 Then
            CasInput = 1 'matriceStrctMeteo avec les colonnes 6,13,17,22,80
        End If
        If MyPos80 = 0 Then
            CasInput = 2 'matriceStrctMeteo avec les colonnes 6,13,17,22 (sans neige)
        End If

        Dim bFertig As Boolean = False
        Dim i As Integer = 0
        Do While Not bFertig

            Try 'test s'il y a du text ou pas
                Input(nFic, arrDaten(i).datum)
            Catch
                bFertig = True
            End Try

            If Not bFertig Then
                ' les quatre cas:
                If CasInput = 1 Then
                    Input(nFic, arrDaten(i).heure)
                    Input(nFic, arrDaten(i).moy6)
                    Input(nFic, arrDaten(i).moy13)
                    Input(nFic, arrDaten(i).moy17)
                    Input(nFic, arrDaten(i).moy22)
                    Input(nFic, arrDaten(i).moy80)
                ElseIf CasInput = 2 Then 'sans arrDaten(i).moy80
                    Input(nFic, arrDaten(i).heure)
                    Input(nFic, arrDaten(i).moy6)
                    Input(nFic, arrDaten(i).moy13)
                    Input(nFic, arrDaten(i).moy17)
                    Input(nFic, arrDaten(i).moy22)
                End If

                If (arrDaten(i).datum - ((Fix(arrDaten(i).datum / 10000)) * 10000) <> 229) Then
                    i = i + 1 'élimination du 29. février
                End If
            End If

        Loop

        iAnzahl = i
        FileClose(nFic)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'calcul des dates dans la matrice
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        For i = 0 To (iAnzahl - 1)
            arrMatrice(i).year1 = Fix(arrDaten(i).datum / 10000)
            arrMatrice(i).month = Fix((arrDaten(i).datum - 10000 * arrMatrice(i).year1) / 100)
            arrMatrice(i).day = arrDaten(i).datum - arrMatrice(i).year1 * 10000 - arrMatrice(i).month * 100
            arrMatrice(i).hour = arrDaten(i).heure
            arrMatrice(i).year2 = arrMatrice(i).year1 + arrMatrice(i).month / 12 + arrMatrice(i).day / 366 + arrMatrice(i).hour / (24 * 366)
        Next

    End Sub

    Public Sub Troubleshoot()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'détection des pannes
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim Panne As Boolean = False
        Dim NbrPanne As Integer = 0
        Dim i As Integer = 0

        For i = 0 To (iAnzahl - 1)
            If arrDaten(i).moy6 = 32767 And Not Panne Then
                Panne = True
                arrPanne(NbrPanne).PanneStart = i
                arrPanne(NbrPanne).PanneMesure = "mm de pluie"
            End If
            If i = iAnzahl - 1 And Panne = True Then
                Panne = False
                arrPanne(NbrPanne).PanneEnd = i
                NbrPanne = NbrPanne + 1
            End If
            If arrDaten(i).moy6 <> 32767 And Panne Then
                Panne = False
                arrPanne(NbrPanne).PanneEnd = i - 1
                NbrPanne = NbrPanne + 1
            End If
        Next

        For i = 0 To (iAnzahl - 1)
            If arrDaten(i).moy13 = 32767 And Not Panne Then
                Panne = True
                arrPanne(NbrPanne).PanneStart = i
                arrPanne(NbrPanne).PanneMesure = "Température"
            End If
            If i = iAnzahl - 1 And Panne = True Then
                Panne = False
                arrPanne(NbrPanne).PanneEnd = i
                NbrPanne = NbrPanne + 1
            End If
            If arrDaten(i).moy13 <> 32767 And Panne Then
                Panne = False
                arrPanne(NbrPanne).PanneEnd = i - 1
                NbrPanne = NbrPanne + 1
            End If
        Next

        For i = 0 To (iAnzahl - 1)
            If arrDaten(i).moy17 = 32767 And Not Panne Then
                Panne = True
                arrPanne(NbrPanne).PanneStart = i
                arrPanne(NbrPanne).PanneMesure = "Humidité relaltive"
            End If
            If i = iAnzahl - 1 And Panne = True Then
                Panne = False
                arrPanne(NbrPanne).PanneEnd = i
                NbrPanne = NbrPanne + 1
            End If
            If arrDaten(i).moy17 <> 32767 And Panne Then
                Panne = False
                arrPanne(NbrPanne).PanneEnd = i - 1
                NbrPanne = NbrPanne + 1
            End If
        Next

        For i = 0 To (iAnzahl - 1)
            If arrDaten(i).moy22 = 32767 And Not Panne Then
                Panne = True
                arrPanne(NbrPanne).PanneStart = i
                arrPanne(NbrPanne).PanneMesure = "Rayonnement globale"
            End If
            If i = iAnzahl - 1 And Panne = True Then
                Panne = False
                arrPanne(NbrPanne).PanneEnd = i
                NbrPanne = NbrPanne + 1
            End If
            If arrDaten(i).moy22 <> 32767 And Panne Then
                Panne = False
                arrPanne(NbrPanne).PanneEnd = i - 1
                NbrPanne = NbrPanne + 1
            End If
        Next

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'afficher les pannes
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim MessagePanne As String
        Dim strDebut As String
        Dim strFin As String

        For i = 0 To NbrPanne - 1
            strDebut = arrMatrice(arrPanne(i).PanneStart).day & "." & arrMatrice(arrPanne(i).PanneStart).month & "." & arrMatrice(arrPanne(i).PanneStart).year1 & " à " & arrMatrice(arrPanne(i).PanneStart).hour & "H  "
            strFin = arrMatrice(arrPanne(i).PanneEnd).day & ". " & arrMatrice(arrPanne(i).PanneEnd).month & "." & arrMatrice(arrPanne(i).PanneEnd).year1 & " à " & arrMatrice(arrPanne(i).PanneEnd).hour & "H  "
            MessagePanne = MessagePanne + "Panne " + CStr(i + 1) + "  du  " + strDebut + "  au  " + strFin + arrPanne(i).PanneMesure + (vbCrLf)
        Next

        If NbrPanne = 0 Then
            MessagePanne = "Il n'y a pas de panne dans la série!"
        End If
        MsgBox(MessagePanne, , "Détéction des pannes")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'recherche de l'intervalle le plus long sans pannes
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim Start As Integer
        Dim Fin As Integer
        Dim startmax As Integer
        Dim finmax As Integer
        Dim IntLong As Integer
        Dim IntrStart As Integer

        Start = 0
        Fin = 0
        startmax = 0
        finmax = 0
        Panne = False
        For i = 0 To iAnzahl - 1 'i correspond à une heure
            If arrDaten(i).moy6 = 32767 Or arrDaten(i).moy13 = 32767 Or arrDaten(i).moy17 = 32767 Or arrDaten(i).moy22 = 32767 Then
                If Panne = False Then
                    Fin = i - 1
                    If Fin - Start > finmax - startmax Then
                        finmax = Fin
                        startmax = Start
                    End If
                    Panne = True
                End If
            Else
                If Panne = True Then
                    Start = i
                    Panne = False
                End If
            End If
        Next

        If Panne = False Then 'contrôle du dernier intervalle
            Fin = i - 1
            If Fin - Start > finmax - startmax Then
                finmax = Fin
                startmax = Start
            End If
        End If

        IntLong = finmax - startmax
        'IntLong = Fix(IntLong / 8760)
        'iAnzahl = CInt(8760 * IntLong)
        iAnzahl = CInt(IntLong)

        strDebut = arrMatrice(startmax).day & "." & arrMatrice(startmax).month & "." & arrMatrice(startmax).year1 & " à " & arrMatrice(startmax).hour & "H  "
        strFin = arrMatrice(startmax + iAnzahl - 1).day & "." & arrMatrice(startmax + iAnzahl - 1).month & "." & arrMatrice(startmax + iAnzahl - 1).year1 & " à " & arrMatrice(startmax + iAnzahl - 1).hour & "H  "
        MsgBox(" du  " & strDebut & " au  " & strFin, , "Interval maximal sans pannes ")

        NbrAns = iAnzahl / 8760

        For i = 0 To iAnzahl - 1
            arrMatrice(i) = arrMatrice(i + startmax)
        Next
        ReDim Preserve arrMatrice(iAnzahl - 1)
        For i = 0 To iAnzahl - 1
            arrDaten(i) = arrDaten(i + startmax)
        Next
        ReDim Preserve arrDaten(iAnzahl - 1)

    End Sub

    Public Sub InputDeicingSalt()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Calcul du nbre d'interventions et de la quantité de sel épandu
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim Hiv As Boolean = True
        Dim Cpt As Short = 0
        Dim NDH As Single = 0


        'Calcul du nombre de jours hivernaux
        For i As Integer = 0 To iAnzahl - 1
            If arrDaten(i).moy6 / 10 > 0 Then Hiv = False
            If Cpt = 24 Then
                If Hiv = True Then NDH = NDH + 1
                Hiv = True
                Cpt = 0
            End If
            Cpt = Cpt + 1
        Next

        frmTempSeuil = New frmMeteo
        frmTempSeuil.Label12.Text = NbrAns

        If Math.Round(NbrAns, 1) > Math.Round(NbrAns, 0) Then
            NbrAns = Math.Round(NbrAns, 0) + 1
        Else
            NbrAns = Math.Round(NbrAns, 0)
        End If
        NDH = NDH / NbrAns  'nombre de jours hivernaux par ans

        Dim qNaCl1 As Single = 20.83519974 * NDH + 211.3117439   'quantité par an en g/m2 de sel déversé sur la chaussée
        Dim qNaCl2 As Single = 20.83519974 * NDH - 72.9892168  'quantité par an en g/m2 de sel déversé sur la chaussée

        frmTempSeuil.Label3.Text = CInt(qNaCl1)
        frmTempSeuil.Label74.Text = CInt(qNaCl2)
        frmTempSeuil.NumericUpDown1.Text = 10

        frmTempSeuil.ButtonExportFile.Hide()
        frmTempSeuil.ButtonExportDB.Hide()
        frmTempSeuil.LabelOR.Hide()
        frmTempSeuil.ShowDialog()
        frmTempSeuil.Hide()

        'calcul de la concentration en NaCl dans l'eau
        Dim DureeInt As Short = frmTempSeuil.NumericUpDown2.Text
        Dim QNa1 As Single = frmTempSeuil.NumericUpDown1.Text
        Dim QNa2 As Single = frmTempSeuil.NumericUpDown24.Text * frmTempSeuil.NumericUpDown25.Text
        Dim Tseuil1 As Single = frmTempSeuil.Label22.Text
        Dim Tseuil2 As Single = frmTempSeuil.Label66.Text
        Dim HRseuil As Single = frmTempSeuil.NumericUpDown3.Text
        Dim EpNa1 As Single = frmTempSeuil.NumericUpDown4.Text / 100
        Dim EpNa2 As Single = frmTempSeuil.NumericUpDown23.Text / 100
        Dim Feau As Single = frmTempSeuil.NumericUpDown5.Text

        Dim Dint1 As Short = 0
        Dim Dint2 As Short = 0
        Dim PluieOld As Boolean = False

        For i As Integer = 0 To iAnzahl - 1
            If Dint1 <> 0 Then Dint1 = Dint1 + 1
            If Dint2 <> 0 Then Dint2 = Dint2 + 1
            If Dint1 >= DureeInt Then Dint1 = 0
            If Dint1 = 0 And arrDaten(i).moy6 / 10 < Tseuil1 And (arrDaten(i).moy13 / 10 >= HRseuil Or arrDaten(i).moy17 / 10 > 0) Then 'why or
                If arrDaten(i).moy17 / 10 = 0 Then 'we don't have rain now
                    arrMatrice(i).salage1 = EpNa1
                Else 'we have rain now
                    If PluieOld = False Then 'we didn't have rain the step before
                        arrMatrice(i).salage1 = QNa1 / (1000 * arrDaten(i).moy17 / 10)
                    Else ' we had rain the step before
                        If i <> 0 Then arrMatrice(i).salage1 = (arrMatrice(i - 1).salage1 * 1000 * Feau + QNa1) / ((Feau + arrDaten(i).moy17 / 10) * 1000)
                    End If
                End If
                Dint1 = Dint1 + 1
            End If
            If Dint2 = 0 And arrDaten(i).moy6 / 10 < Tseuil2 And (arrDaten(i).moy13 / 10 >= HRseuil Or arrDaten(i).moy17 / 10 > 0) Then
                If arrDaten(i).moy17 / 10 = 0 Then
                    arrMatrice(i).salage2 = EpNa2
                Else
                    If PluieOld = False Then
                        arrMatrice(i).salage2 = QNa2 / (1000 * arrDaten(i).moy17 / 10)
                    Else
                        If i <> 0 Then arrMatrice(i).salage2 = (arrMatrice(i - 1).salage2 * 1000 * Feau + QNa2) / ((Feau + arrDaten(i).moy17 / 10) * 1000)
                    End If

                End If
                Dint2 = Dint2 + 1
            End If
            If arrDaten(i).moy17 / 10 <> 0 Then
                PluieOld = True
            Else
                PluieOld = False
            End If
            If Dint1 <> 1 Then
                If PluieOld = True Then
                    If i <> 0 Then arrMatrice(i).salage1 = arrMatrice(i - 1).salage1 * 1000 * Feau / ((Feau + arrDaten(i).moy17 / 10) * 1000)
                Else 'PluieOld = False
                    If i <> 0 Then arrMatrice(i).salage1 = arrMatrice(i - 1).salage1
                End If
                If i = 0 Then arrMatrice(i).salage1 = frmTempSeuil.NumericUpDown6.Value / 100
            End If
            If Dint2 <> 1 Then
                If PluieOld = True Then
                    If i > 0 Then arrMatrice(i).salage2 = arrMatrice(i - 1).salage2 * 1000 * Feau / ((Feau + arrDaten(i).moy17 / 10) * 1000)
                Else
                    If i > 0 Then arrMatrice(i).salage2 = arrMatrice(i - 1).salage2
                End If
                If i = 0 Then arrMatrice(i).salage2 = frmTempSeuil.NumericUpDown24.Value * frmTempSeuil.NumericUpDown25.Text / 100
                If arrMatrice(i).salage2 <= 0.1 * EpNa2 Then Dint2 = 0 '???
            End If
            If arrMatrice(i).salage1 > EpNa1 Then arrMatrice(i).salage1 = EpNa1 'keep the maximal value
            If arrMatrice(i).salage2 > EpNa2 Then arrMatrice(i).salage2 = EpNa2
        Next



    End Sub

    Public Sub CalculTHS()

        Dim InputMatrice(DataLength) As Single
        Dim OutputMatrice(DataLength) As Single

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'calcul  T et Ts
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim a As Single = 0.7
        Dim hy As Single = 20

        For i As Integer = 0 To iAnzahl - 1
            arrMatrice(i).T = arrDaten(i).moy6 / 10
            If arrDaten(i).moy22 < 0 Then
                arrDaten(i).moy22 = 0
            End If
            arrMatrice(i).Ts = arrMatrice(i).T + (a / hy) * arrDaten(i).moy22
        Next

        For i As Integer = 0 To iAnzahl - 1    'calcul de Text
            InputMatrice(i) = arrMatrice(i).T
        Next

        AttenBruit(CSng(frmTempSeuil.NumericUpDown8.Value), CSng(frmTempSeuil.NumericUpDown7.Value), CSng(frmTempSeuil.NumericUpDown9.Value), CSng(frmTempSeuil.NumericUpDown10.Value), InputMatrice, OutputMatrice, CSng(frmTempSeuil.TextBox1.Text))
        For i As Integer = 0 To iAnzahl - 1
            arrMatrice(i).Text = OutputMatrice(i)
        Next

        arrMatrice(iAnzahl - 1).Text = InputMatrice(iAnzahl - 1)

        For i As Integer = 0 To iAnzahl - 1    'calcul de Tcaisson
            InputMatrice(i) = arrMatrice(i).T
        Next

        AttenBruit(CSng(frmTempSeuil.NumericUpDown21.Value), CSng(frmTempSeuil.NumericUpDown22.Value), CSng(frmTempSeuil.NumericUpDown19.Value), CSng(frmTempSeuil.NumericUpDown20.Value), InputMatrice, OutputMatrice, CSng(frmTempSeuil.TextBox4.Text))

        For i As Integer = 0 To iAnzahl - 1
            arrMatrice(i).Tcaisson = OutputMatrice(i)
        Next
        arrMatrice(iAnzahl - 1).Tcaisson = InputMatrice(iAnzahl - 1)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'calculs d'exposition HR
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''
        Dim NbPluie As Short = 0 'Ajout Bitume TSANCHEZ
        Dim NbPluieMax As Short = InputBox("Bitume delay for Humidity (Default: 50 [Salam Bah])", "Bitume Property", 50)

        For i As Integer = 0 To (iAnzahl - 1)

            If arrDaten(i).moy13 >= 1000 Then 'exposition brouillard, pas de pluie
                arrMatrice(i).HR_brouillard = 99.99
                arrMatrice(i).HR_bitume = arrMatrice(i).HR_brouillard 'Ajout Bitume TSANCHEZ
            Else
                arrMatrice(i).HR_brouillard = arrDaten(i).moy13 / 10
                arrMatrice(i).HR_bitume = arrMatrice(i).HR_brouillard 'Ajout Bitume TSANCHEZ
            End If

            If i > 0 Then 'exposition eclaboussures
                If arrDaten(i).moy17 <> 0 And arrDaten(i - 1).moy17 <> 0 Then 'pluie avant une heure
                    arrMatrice(i).HR_eclaboussures = 100
                Else
                    If arrDaten(i).moy13 >= 1000 Then 'pas de pluie
                        arrMatrice(i).HR_eclaboussures = 99.99
                    Else
                        arrMatrice(i).HR_eclaboussures = arrDaten(i).moy13 / 10
                    End If
                End If
            End If

            If arrMatrice(i).hour > 17 Or arrMatrice(i).hour < 6 Then 'exposition stagnation (direct)
                'pendant la nuit (de 18h00 à 6h00)
                If arrDaten(i).moy17 <> 0 Then 'pluie
                    arrMatrice(i).HR_direct = 100
                    NbPluie += 1
                    If NbPluie = NbPluieMax Then                'Ajout Bitume TSANCHEZ
                        arrMatrice(i).HR_bitume = 100
                        NbPluie = 0
                    End If
                Else
                    If arrDaten(i).moy13 >= 1000 Then 'pas de pluie
                        arrMatrice(i).HR_direct = 99.99
                    Else
                        arrMatrice(i).HR_direct = arrDaten(i).moy13 / 10
                    End If
                End If
            Else
                If arrDaten(i).moy17 <> 0 Then 'pluie
                    arrMatrice(i).HR_direct = 100
                Else
                    If arrDaten(i).moy13 >= 1000 Then 'pas de pluie
                        arrMatrice(i).HR_direct = 99.99
                    Else
                        arrMatrice(i).HR_direct = arrDaten(i).moy13 / 10
                    End If
                End If
            End If
        Next

        For i As Integer = 0 To iAnzahl - 1    'calcul de HRext
            InputMatrice(i) = arrMatrice(i).HR_brouillard
        Next
        AttenBruit(CSng(frmTempSeuil.NumericUpDown13.Value), CSng(frmTempSeuil.NumericUpDown14.Value), CSng(frmTempSeuil.NumericUpDown11.Value), CSng(frmTempSeuil.NumericUpDown12.Value), InputMatrice, OutputMatrice, CSng(frmTempSeuil.TextBox2.Text))
        For i As Integer = 0 To iAnzahl - 1
            arrMatrice(i).HR_ext = OutputMatrice(i)
        Next
        arrMatrice(iAnzahl - 1).HR_ext = InputMatrice(iAnzahl - 1)

        For i As Integer = 0 To iAnzahl - 1    'calcul de HRcaisson
            InputMatrice(i) = arrMatrice(i).HR_brouillard
        Next
        AttenBruit(CSng(frmTempSeuil.NumericUpDown17.Value), CSng(frmTempSeuil.NumericUpDown18.Value), CSng(frmTempSeuil.NumericUpDown15.Value), CSng(frmTempSeuil.NumericUpDown16.Value), InputMatrice, OutputMatrice, CSng(frmTempSeuil.TextBox3.Text))
        For i As Integer = 0 To iAnzahl - 1
            arrMatrice(i).HR_caisson = OutputMatrice(i)
        Next
        arrMatrice(iAnzahl - 1).HR_caisson = InputMatrice(iAnzahl - 1)

    End Sub

    Public Sub WriteExpoFile(ByRef OutFile As String, ByRef PostFile As String, ByRef txtFile As String, ByRef Canc As Boolean)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'création des fichiers INPUT
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim INFile1, INFile2, INFile3, INFile4, INFile5, INFile6, INFile7, INFile8, INFile9, INFile10, INFile11, INFile12, INFile13, INFile14, INFile15, INFile16, INFile17, INFile18 As System.IO.TextWriter

        OutFile = PostFile & "EXPO_M_E_E_" & txtFile & ".txt"
        INFile1 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_M_E_O_" & txtFile & ".txt"
        INFile2 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_M_B_E_" & txtFile & ".txt"
        INFile3 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_M_B_O_" & txtFile & ".txt"
        INFile4 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_M_D_E_" & txtFile & ".txt"
        INFile5 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_M_D_O_" & txtFile & ".txt"
        INFile6 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_M_EXT_" & txtFile & ".txt"
        INFile7 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_M_CAI_" & txtFile & ".txt"
        INFile8 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_M_CAC_" & txtFile & ".txt"
        INFile9 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_A_E_E_" & txtFile & ".txt"
        INFile10 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_A_E_O_" & txtFile & ".txt"
        INFile11 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_A_B_E_" & txtFile & ".txt"
        INFile12 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_A_B_O_" & txtFile & ".txt"
        INFile13 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_A_D_E_" & txtFile & ".txt"
        INFile14 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_A_D_O_" & txtFile & ".txt"
        INFile15 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_A_EXT_" & txtFile & ".txt"
        INFile16 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_A_CAC_" & txtFile & ".txt"
        INFile17 = System.IO.File.CreateText(OutFile)
        OutFile = PostFile & "EXPO_M_BIT_" & txtFile & ".txt"
        INFile18 = System.IO.File.CreateText(OutFile)

        Dim arrINPUT_M_E_E(iAnzahl - 1) As File
        Dim arrINPUT_M_E_O(iAnzahl - 1) As File
        Dim arrINPUT_M_B_E(iAnzahl - 1) As File
        Dim arrINPUT_M_B_O(iAnzahl - 1) As File
        Dim arrINPUT_M_D_E(iAnzahl - 1) As File
        Dim arrINPUT_M_D_O(iAnzahl - 1) As File
        Dim arrINPUT_M_EXT(iAnzahl - 1) As File
        Dim arrINPUT_M_CAI(iAnzahl - 1) As File
        Dim arrINPUT_M_CAC(iAnzahl - 1) As File
        Dim arrINPUT_A_E_E(iAnzahl - 1) As File
        Dim arrINPUT_A_E_O(iAnzahl - 1) As File
        Dim arrINPUT_A_B_E(iAnzahl - 1) As File
        Dim arrINPUT_A_B_O(iAnzahl - 1) As File
        Dim arrINPUT_A_D_E(iAnzahl - 1) As File
        Dim arrINPUT_A_D_O(iAnzahl - 1) As File
        Dim arrINPUT_A_EXT(iAnzahl - 1) As File
        Dim arrINPUT_A_CAC(iAnzahl - 1) As File
        Dim arrINPUT_M_BIT(iAnzahl - 1) As File

        For i As Integer = 0 To iAnzahl - 1
            'eclaboussure et ensoleillement
            arrINPUT_M_E_E(i).HR = arrMatrice(i).HR_eclaboussures
            arrINPUT_M_E_E(i).Sel = arrMatrice(i).salage1
            arrINPUT_M_E_E(i).Tsurf = arrMatrice(i).Ts
            'eclaboussure et ombrée
            arrINPUT_M_E_O(i).HR = arrMatrice(i).HR_eclaboussures
            arrINPUT_M_E_O(i).Sel = arrMatrice(i).salage1
            arrINPUT_M_E_O(i).Tsurf = arrMatrice(i).T
            'brouillard et ensoleillement
            arrINPUT_M_B_E(i).HR = arrMatrice(i).HR_brouillard
            arrINPUT_M_B_E(i).Sel = arrMatrice(i).salage1
            arrINPUT_M_B_E(i).Tsurf = arrMatrice(i).Ts
            'brouillard et ombrée
            arrINPUT_M_B_O(i).HR = arrMatrice(i).HR_brouillard
            arrINPUT_M_B_O(i).Sel = arrMatrice(i).salage1
            arrINPUT_M_B_O(i).Tsurf = arrMatrice(i).T
            'direct et ensoleillement
            arrINPUT_M_D_E(i).HR = arrMatrice(i).HR_direct
            arrINPUT_M_D_E(i).Sel = arrMatrice(i).salage1
            arrINPUT_M_D_E(i).Tsurf = arrMatrice(i).Ts
            'direct et ombrée
            arrINPUT_M_D_O(i).HR = arrMatrice(i).HR_direct
            arrINPUT_M_D_O(i).Sel = arrMatrice(i).salage1
            arrINPUT_M_D_O(i).Tsurf = arrMatrice(i).T
            'extérieur et à l'abris des intempéries
            arrINPUT_M_EXT(i).HR = arrMatrice(i).HR_ext
            arrINPUT_M_EXT(i).Sel = arrMatrice(i).salage1
            arrINPUT_M_EXT(i).Tsurf = arrMatrice(i).Text
            'intérieur du caisson et sans sel
            arrINPUT_M_CAI(i).HR = arrMatrice(i).HR_caisson
            arrINPUT_M_CAI(i).Sel = 0
            arrINPUT_M_CAI(i).Tsurf = arrMatrice(i).Tcaisson
            'intérieur du caisson et avec présence de sel
            arrINPUT_M_CAC(i).HR = arrMatrice(i).HR_caisson
            arrINPUT_M_CAC(i).Sel = arrMatrice(i).salage1
            arrINPUT_M_CAC(i).Tsurf = arrMatrice(i).Tcaisson
            'Statgnant avec Bitume TSANCHEZ
            arrINPUT_M_BIT(i).HR = arrMatrice(i).HR_bitume
            arrINPUT_M_BIT(i).Sel = arrMatrice(i).salage1
            arrINPUT_M_BIT(i).Tsurf = arrMatrice(i).T

            'eclaboussure et ensoleillement
            arrINPUT_A_E_E(i).HR = arrMatrice(i).HR_eclaboussures
            arrINPUT_A_E_E(i).Sel = arrMatrice(i).salage2
            arrINPUT_A_E_E(i).Tsurf = arrMatrice(i).Ts
            'eclaboussure et ombrée
            arrINPUT_A_E_O(i).HR = arrMatrice(i).HR_eclaboussures
            arrINPUT_A_E_O(i).Sel = arrMatrice(i).salage2
            arrINPUT_A_E_O(i).Tsurf = arrMatrice(i).T
            'brouillard et ensoleillement
            arrINPUT_A_B_E(i).HR = arrMatrice(i).HR_brouillard
            arrINPUT_A_B_E(i).Sel = arrMatrice(i).salage2
            arrINPUT_A_B_E(i).Tsurf = arrMatrice(i).Ts
            'brouillard et ombrée
            arrINPUT_A_B_O(i).HR = arrMatrice(i).HR_brouillard
            arrINPUT_A_B_O(i).Sel = arrMatrice(i).salage2
            arrINPUT_A_B_O(i).Tsurf = arrMatrice(i).T
            'direct et ensoleillement
            arrINPUT_A_D_E(i).HR = arrMatrice(i).HR_direct
            arrINPUT_A_D_E(i).Sel = arrMatrice(i).salage2
            arrINPUT_A_D_E(i).Tsurf = arrMatrice(i).Ts
            'direct et ombrée
            arrINPUT_A_D_O(i).HR = arrMatrice(i).HR_direct
            arrINPUT_A_D_O(i).Sel = arrMatrice(i).salage2
            arrINPUT_A_D_O(i).Tsurf = arrMatrice(i).T
            'extérieur et à l'abris des intempéries
            arrINPUT_A_EXT(i).HR = arrMatrice(i).HR_ext
            arrINPUT_A_EXT(i).Sel = arrMatrice(i).salage2
            arrINPUT_A_EXT(i).Tsurf = arrMatrice(i).Text
            'intérieur du caisson et avec présence de sel
            arrINPUT_A_CAC(i).HR = arrMatrice(i).HR_caisson
            arrINPUT_A_CAC(i).Sel = arrMatrice(i).salage2
            arrINPUT_A_CAC(i).Tsurf = arrMatrice(i).Tcaisson
        Next

        'écriture dans les fichiers
        INFile1.WriteLine(iAnzahl)
        INFile1.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile1.WriteLine(arrINPUT_M_E_E(i).HR & vbTab & vbTab & arrINPUT_M_E_E(i).Sel & vbTab & vbTab & arrINPUT_M_E_E(i).Tsurf, i)
        Next
        INFile1.Close()

        INFile2.WriteLine(iAnzahl)
        INFile2.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile2.WriteLine(arrINPUT_M_E_O(i).HR & vbTab & vbTab & arrINPUT_M_E_O(i).Sel & vbTab & vbTab & arrINPUT_M_E_O(i).Tsurf, i)
        Next
        INFile2.Close()

        INFile3.WriteLine(iAnzahl)
        INFile3.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile3.WriteLine(arrINPUT_M_B_E(i).HR & vbTab & vbTab & arrINPUT_M_B_E(i).Sel & vbTab & vbTab & arrINPUT_M_B_E(i).Tsurf, i)
        Next
        INFile3.Close()

        INFile4.WriteLine(iAnzahl)
        INFile4.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile4.WriteLine(arrINPUT_M_B_O(i).HR & vbTab & vbTab & arrINPUT_M_B_O(i).Sel & vbTab & vbTab & arrINPUT_M_B_O(i).Tsurf, i)
        Next
        INFile4.Close()

        INFile5.WriteLine(iAnzahl)
        INFile5.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile5.WriteLine(arrINPUT_M_D_E(i).HR & vbTab & vbTab & arrINPUT_M_D_E(i).Sel & vbTab & vbTab & arrINPUT_M_D_E(i).Tsurf, i)
        Next
        INFile5.Close()

        INFile6.WriteLine(iAnzahl)
        INFile6.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile6.WriteLine(arrINPUT_M_D_O(i).HR & vbTab & vbTab & arrINPUT_M_D_O(i).Sel & vbTab & vbTab & arrINPUT_M_D_O(i).Tsurf, i)
        Next
        INFile6.Close()

        INFile7.WriteLine(iAnzahl)
        INFile7.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile7.WriteLine(arrINPUT_M_EXT(i).HR & vbTab & vbTab & arrINPUT_M_EXT(i).Sel & vbTab & vbTab & arrINPUT_M_EXT(i).Tsurf, i)
        Next
        INFile7.Close()

        INFile8.WriteLine(iAnzahl)
        INFile8.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile8.WriteLine(arrINPUT_M_CAI(i).HR & vbTab & vbTab & arrINPUT_M_CAI(i).Sel & vbTab & vbTab & arrINPUT_M_CAI(i).Tsurf, i)
        Next
        INFile8.Close()

        INFile9.WriteLine(iAnzahl)
        INFile9.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile9.WriteLine(arrINPUT_M_CAC(i).HR & vbTab & vbTab & arrINPUT_M_CAC(i).Sel & vbTab & vbTab & arrINPUT_M_CAC(i).Tsurf, i)
        Next
        INFile9.Close()

        INFile10.WriteLine(iAnzahl)
        INFile10.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile10.WriteLine(arrINPUT_A_E_E(i).HR & vbTab & vbTab & arrINPUT_A_E_E(i).Sel & vbTab & vbTab & arrINPUT_A_E_E(i).Tsurf, i)
        Next
        INFile10.Close()

        INFile11.WriteLine(iAnzahl)
        INFile11.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile11.WriteLine(arrINPUT_A_E_O(i).HR & vbTab & vbTab & arrINPUT_A_E_O(i).Sel & vbTab & vbTab & arrINPUT_A_E_O(i).Tsurf, i)
        Next
        INFile11.Close()

        INFile12.WriteLine(iAnzahl)
        INFile12.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile12.WriteLine(arrINPUT_A_B_E(i).HR & vbTab & vbTab & arrINPUT_A_B_E(i).Sel & vbTab & vbTab & arrINPUT_A_B_E(i).Tsurf, i)
        Next
        INFile12.Close()

        INFile13.WriteLine(iAnzahl)
        INFile13.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile13.WriteLine(arrINPUT_A_B_O(i).HR & vbTab & vbTab & arrINPUT_A_B_O(i).Sel & vbTab & vbTab & arrINPUT_A_B_O(i).Tsurf, i)
        Next
        INFile13.Close()

        INFile14.WriteLine(iAnzahl)
        INFile14.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile14.WriteLine(arrINPUT_A_D_E(i).HR & vbTab & vbTab & arrINPUT_A_D_E(i).Sel & vbTab & vbTab & arrINPUT_A_D_E(i).Tsurf, i)
        Next
        INFile14.Close()

        INFile15.WriteLine(iAnzahl)
        INFile15.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile15.WriteLine(arrINPUT_A_D_O(i).HR & vbTab & vbTab & arrINPUT_A_D_O(i).Sel & vbTab & vbTab & arrINPUT_A_D_O(i).Tsurf, i)
        Next
        INFile15.Close()

        INFile16.WriteLine(iAnzahl)
        INFile16.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile16.WriteLine(arrINPUT_A_EXT(i).HR & vbTab & vbTab & arrINPUT_A_EXT(i).Sel & vbTab & vbTab & arrINPUT_A_EXT(i).Tsurf, i)
        Next
        INFile16.Close()

        INFile17.WriteLine(iAnzahl)
        INFile17.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile17.WriteLine(arrINPUT_A_CAC(i).HR & vbTab & vbTab & arrINPUT_A_CAC(i).Sel & vbTab & vbTab & arrINPUT_A_CAC(i).Tsurf, i)
        Next
        INFile17.Close()

        INFile18.WriteLine(iAnzahl)
        INFile18.WriteLine("3600")
        For i As Integer = 0 To iAnzahl - 1
            INFile18.WriteLine(arrINPUT_M_BIT(i).HR & vbTab & vbTab & arrINPUT_M_BIT(i).Sel & vbTab & vbTab & arrINPUT_M_BIT(i).Tsurf, i)
        Next
        INFile18.Close()

        MsgBox("Files written successfully !")

    End Sub

    Public Sub WriteExpoDatabase()

        'écriture dans la database

        Dim Name As String = InputBox("Name of the localisation", "New Exposition in the database", "Davos")
        Dim Description As String = InputBox("Description of the localisation", "New Exposition in the database", "Swiss Mountain")
        Description = Name + ", " + Description

        Dim DBCon As New DBconnexion

        WriteExpoToDB(DBCon, Name, Description, "EXPO_M_E_E_", "Manuel", "Eclaboussure", "Ensoleillé")
        WriteExpoToDB(DBCon, Name, Description, "EXPO_M_E_O_", "Manuel", "Eclaboussure", "Ombré")

        WriteExpoToDB(DBCon, Name, Description, "EXPO_M_B_E_", "Manuel", "Brouillard", "Ensoleillé")
        WriteExpoToDB(DBCon, Name, Description, "EXPO_M_B_O_", "Manuel", "Brouillard", "Ombré")

        WriteExpoToDB(DBCon, Name, Description, "EXPO_M_D_E_", "Manuel", "Direct", "Ensoleillé")
        WriteExpoToDB(DBCon, Name, Description, "EXPO_M_D_O_", "Manuel", "Direct", "Ombré")

        WriteExpoToDB(DBCon, Name, Description, "EXPO_M_EXT_", "Manuel", "AbriPrecipitation", "")
        WriteExpoToDB(DBCon, Name, Description, "EXPO_M_CAI_", "Manuel", "Caisson", "")
        WriteExpoToDB(DBCon, Name, Description, "EXPO_M_CAC_", "Manuel", "CaissonAvecChlore", "")
        WriteExpoToDB(DBCon, Name, Description, "EXPO_M_BIT_", "Manuel", "Bitume", "")


        WriteExpoToDB(DBCon, Name, Description, "EXPO_A_E_E_", "Automatique", "Eclaboussure", "Ensoleillé")
        WriteExpoToDB(DBCon, Name, Description, "EXPO_A_E_O_", "Automatique", "Eclaboussure", "Ombré")

        WriteExpoToDB(DBCon, Name, Description, "EXPO_A_B_E_", "Automatique", "Brouillard", "Ensoleillé")
        WriteExpoToDB(DBCon, Name, Description, "EXPO_A_B_O_", "Automatique", "Brouillard", "Ombré")

        WriteExpoToDB(DBCon, Name, Description, "EXPO_A_D_E_", "Automatique", "Direct", "Ensoleillé")
        WriteExpoToDB(DBCon, Name, Description, "EXPO_A_D_O_", "Automatique", "Direct", "Ombré")

        WriteExpoToDB(DBCon, Name, Description, "EXPO_A_EXT_", "Automatique", "AbriPrecipitation", "")
        WriteExpoToDB(DBCon, Name, Description, "EXPO_A_CAI_", "Automatique", "Caisson", "")
        WriteExpoToDB(DBCon, Name, Description, "EXPO_A_CAC_", "Automatique", "CaissonAvecChlore", "")
        WriteExpoToDB(DBCon, Name, Description, "EXPO_A_BIT_", "Automatique", "Bitume", "")

        MsgBox("Database updated successfully !")

    End Sub

    Private Sub WriteExpoToDB(ByRef DBCon As DBconnexion, ByRef Name As String, ByRef Description As String, ByRef PrefixName As String,
                              ByRef Epandage As String, ByRef ExpositionCond As String, ByRef Zone As String)

        Dim cmd As String = "INSERT INTO ExpositionList (Name, Description, Epandage, ExpositionCond, Zone, Hours) VALUES ('" + PrefixName + Name + "', '" + Description + "', '" + Epandage + "', '" + ExpositionCond + "', '" + Zone + "', " + CStr(iAnzahl) + ")"
        DBCon.DBRequest(cmd)
        cmd = "CREATE TABLE [dbo].[" + PrefixName + Name + "] ([Id] INT IDENTITY (1, 1) NOT NULL, [HR] FLOAT (53) NULL, [NaCl] FLOAT (53) NOT NULL, [T] FLOAT (53) NOT NULL, [Year] FLOAT (53), PRIMARY KEY CLUSTERED ([Id] ASC))"
        DBCon.DBRequest(cmd)

        'Dim Expo As New MaterialsData
        'Expo.Tables.Add(PrefixName + Name)
        DBCon.DBRequest("SELECT * FROM " + PrefixName + Name)
        'DBCon.MatFill(Expo, PrefixName + Name)

        Dim HR, NaCl, T, Year As Double

        For i As Integer = 0 To iAnzahl - 1

            'Dim newRow As DataRow = Expo.Tables(PrefixName + Name).NewRow()

            If ExpositionCond = "Eclaboussure" Then
                'newRow("HR") = arrMatrice(i).HR_eclaboussures
            ElseIf ExpositionCond = "Brouillard" Then
                'newRow("HR") = arrMatrice(i).HR_brouillard
            ElseIf ExpositionCond = "Direct" Then
                'newRow("HR") = arrMatrice(i).HR_direct
            ElseIf ExpositionCond = "Bitume" Then
                'newRow("HR") = arrMatrice(i).HR_bitume
            ElseIf ExpositionCond = "AbriPrecipitation" Then
                'newRow("HR") = arrMatrice(i).HR_ext
            Else
                'newRow("HR") = arrMatrice(i).HR_caisson
            End If

            If Epandage = "Manuel" Then
                'newRow("NaCl") = arrMatrice(i).salage1
            Else
                'newRow("NaCl") = arrMatrice(i).salage2
            End If

            If Zone = "Ensoleillé" Then
                'newRow("T") = arrMatrice(i).Ts
            ElseIf Zone = "Ombré" Or ExpositionCond = "Bitume" Then
                'newRow("T") = arrMatrice(i).T
            ElseIf ExpositionCond = "AbriPrecipitation" Then
                'newRow("T") = arrMatrice(i).Text
            ElseIf ExpositionCond = "Caisson" Or ExpositionCond = "CaissonAvecChlore" Then
                'newRow("T") = arrMatrice(i).Tcaisson
            Else
                'newRow("T") = arrMatrice(i).T
            End If

            'newRow("Year") = arrMatrice(i).year2

            'Expo.Tables(PrefixName + Name).Rows.Add(newRow)

        Next

        'DBCon.DBUpdate(Expo, PrefixName + Name)

    End Sub

    Public Sub MeteoTreatment()

        Dim outfile As String
        Dim PostFile As String
        Dim txtfile As String
        Dim Canc As Boolean = False

        ReadMeteoFile(outfile, PostFile, txtfile, Canc)

        If Canc = True Then End

        ' Écrire les données dans un fichier texte



        Troubleshoot()

        InputDeicingSalt()

        CalculTHS()



        If Export = "File" Then
            WriteExpoFile(outfile, PostFile, txtfile, Canc)

        ElseIf Export = "DB" Then
            WriteExpoDatabase()

        Else MsgBox("Error: Don't understand file or Database ??")

        End If

    End Sub

    Public Sub WCal()
        Dim NbrAns As Double '[-]
        Dim i As Integer '[-]
        Dim DureeIntrvent As Integer '[h]
        Dim nbrInt1 As Long = 0
        Dim nbrInt2 As Long = 0
        Dim Tseuil1 As Single = -9  '°C
        Dim Tseuil2 As Single = -9  '°C
        Dim HRseuil As Single = 0
        Dim Nint1 As Long = 0
        Dim Nint2 As Long = 0
        Dim Dint As Short = 0
        Dim PluieOld As Boolean = False
        Dim QNa As Single = 0
        Dim EpNa As Single = 0
        Dim Feau As Single
        Dim Na As String

        CalNeige()

        DureeIntrvent = frmTempSeuil.NumericUpDown2.Value
        nbrInt1 = CInt(frmTempSeuil.Label3.Text / frmTempSeuil.NumericUpDown1.Value)
        nbrInt2 = CInt(frmTempSeuil.Label74.Text / (frmTempSeuil.NumericUpDown24.Value * frmTempSeuil.NumericUpDown25.Value))
        frmTempSeuil.Label6.Text = nbrInt1
        frmTempSeuil.Label76.Text = nbrInt2
        NbrAns = frmTempSeuil.Label12.Text
        nbrInt1 = CInt(nbrInt1 * NbrAns)
        nbrInt2 = CInt(nbrInt2 * NbrAns)
        HRseuil = frmTempSeuil.NumericUpDown3.Value
        Do While Nint1 < nbrInt1
            Nint1 = 0
            Dint = 0
            For i = 0 To iAnzahl - 1
                If Dint <> 0 Then Dint = Dint + 1
                If Dint >= DureeIntrvent Then Dint = 0
                If Dint = 0 And arrDaten(i).moy6 / 10 < Tseuil1 And (arrDaten(i).moy13 / 10 >= HRseuil Or arrDaten(i).moy17 / 10 > 0) Then
                    Nint1 += 1
                    Dint += 1
                End If
            Next
            Tseuil1 += 0.1
        Loop
        frmTempSeuil.Label22.Text = CInt(Tseuil1 * 10) / 10
        Do While Nint2 < nbrInt2
            Nint2 = 0
            Dint = 0
            Na = 0
            EpNa = frmTempSeuil.NumericUpDown23.Text / 100
            QNa = frmTempSeuil.NumericUpDown24.Text * frmTempSeuil.NumericUpDown25.Text
            PluieOld = False
            Feau = frmTempSeuil.NumericUpDown5.Text
            For i = 0 To iAnzahl - 1
                If Dint <> 0 Then Dint = Dint + 1
                If Dint = 0 And arrDaten(i).moy6 / 10 < Tseuil2 And (arrDaten(i).moy13 / 10 >= HRseuil Or arrDaten(i).moy17 / 10 > 0) Then
                    If arrDaten(i).moy17 / 10 = 0 Then
                        Na = EpNa
                    Else
                        If PluieOld = False Then
                            Na = QNa / (1000 * arrDaten(i).moy17 / 10)
                        Else
                            If i <> 0 Then Na = (Na * 1000 * Feau + QNa) / ((Feau + arrDaten(i).moy17 / 10) * 1000)
                        End If
                    End If
                    Dint = Dint + 1
                    Nint2 = Nint2 + 1
                End If
                If arrDaten(i).moy17 / 10 <> 0 Then
                    PluieOld = True
                Else
                    PluieOld = False
                End If
                If Dint <> 1 Then
                    If PluieOld = True Then
                        If i > 0 Then Na = Na * 1000 * Feau / ((Feau + arrDaten(i).moy17 / 10) * 1000)
                    End If
                    If i = 0 Then Na = frmTempSeuil.NumericUpDown24.Value * frmTempSeuil.NumericUpDown25.Text / 100
                    If Na <= 0.1 * EpNa Then Dint = 0
                End If
                If Na > EpNa Then Na = EpNa
            Next
            Tseuil2 = Tseuil2 + 0.1
        Loop
        frmTempSeuil.Label66.Text = CInt(Tseuil2 * 10) / 10

        frmTempSeuil.ButtonExportFile.Show()
        frmTempSeuil.ButtonExportDB.Show()
        frmTempSeuil.LabelOR.Show()

        Dim textFilePath As String = "C:\Users\flori\Documents\Cours\A3\SAE\out\meteo_output.txt"
        WriteMeteoToTextFile(textFilePath)

    End Sub

    Private Sub CalNeige()
        Dim i As Integer '[-]
        Dim SeuilNeige As Single '°C

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'répartition de la neige
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim k As Integer
        Dim roh As Single 'densité de neige [kg/m3]
        Dim cum As Single = 0
        SeuilNeige = 4
        If CasInput = 1 Then 'avec données de neige moy80
            For i = 0 To iAnzahl - 1
                If arrDaten(i).moy80 = 32767 Or arrDaten(i).moy80 = 0 Then
                    k = k + 1
                    If k > 15 Then
                        k = 15
                    End If
                End If
                If arrDaten(i).moy80 <> 0 And arrDaten(i).moy80 <> 32767 Then 'il neige
                    For k = 0 To k - 1
                        If arrDaten(i - k).moy6 / 10 >= SeuilNeige Then
                            arrDaten(i - k).neige = 0
                        Else
                            If (arrDaten(i - k).moy6 / 10) <= -1 Then
                                roh = 3 * arrDaten(i - k).moy6 / 10 + 110
                            Else
                                roh = 23 * arrDaten(i - k).moy6 / 10 + 130
                            End If
                            arrDaten(i - k).neige = (arrDaten(i - k).moy17 / 10) * 1000 / roh  '1000 densité de l'eau=cte
                        End If
                    Next k
                End If
            Next i
        Else 'sans données de neige moy80
            For i = 0 To iAnzahl - 1
                If arrDaten(i).moy6 / 10 >= SeuilNeige Then
                    arrDaten(i).neige = 0
                Else
                    If (arrDaten(i).moy6 / 10) <= -1 Then
                        roh = 3 * arrDaten(i).moy6 / 10 + 110
                    Else
                        roh = 23 * arrDaten(i).moy6 / 10 + 130
                    End If
                    arrDaten(i).neige = (arrDaten(i).moy17 / 10) * 1000 / roh    '1000 densité de l'eau=cte
                End If
                cum = cum + arrDaten(i).neige
                If cum < 2 Then
                    arrDaten(i).neige = 0
                End If
                If arrDaten(i).moy80 = 0 Then
                    cum = 0
                End If
            Next i
        End If
    End Sub



    Private Sub AttenBruit(ByRef A As Single, ByRef B As Single, ByRef C As Single, ByRef D As Single, ByRef tempInput() As Single, ByRef tempOutput() As Single, ByRef tlim As Single)
        Dim dT1 As Single
        Dim dT2 As Single
        Dim bT1 As Single
        Dim bT2 As Single
        Dim T1 As Single
        Dim T2 As Single
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim l As Integer
        Dim PentePos As Boolean

        For i = 0 To iAnzahl - 1
            k = l
            For j = k To iAnzahl - 3 'trouve le min et le max température 
                dT1 = tempInput(j + 1) - tempInput(j)
                dT2 = tempInput(j + 2) - tempInput(j + 1)
                If j = k Then bT1 = tempInput(j)
                If dT1 > 0 And j = k Then
                    PentePos = True
                ElseIf dT1 < 0 And j = k Then
                    PentePos = False
                ElseIf dT1 = 0 And j = k Then
                    bT1 = tempInput(j + 1)
                End If
                If PentePos = True And dT2 < 0 Then
                    bT2 = tempInput(j + 1)
                    Exit For
                ElseIf PentePos = False And dT2 > 0 Then
                    bT2 = tempInput(j + 1)
                    Exit For
                End If
            Next
            bT1 = A * (bT2 - bT1) / B + bT1  'calcul de la moyenne
            For l = k To j
                dT1 = tempInput(l + 1) - tempInput(l)
                If dT1 <> 0 Then
                    dT2 = C / (D * dT1)
                Else
                    dT2 = 0
                End If
                If System.Math.Abs(dT2) > tlim Then dT2 = 0
                dT1 = dT1 * dT2
                If l = 0 Then
                    T1 = tempInput(l) - dT1
                    T2 = tempInput(l) + dT1
                Else
                    T1 = tempOutput(l - 1) - dT1
                    T2 = tempOutput(l - 1) + dT1
                End If
                If System.Math.Abs(bT1 - T2) < System.Math.Abs(bT1 - T1) Then
                    tempOutput(l) = T2
                Else
                    tempOutput(l) = T1
                End If
            Next
            If l = iAnzahl - 1 Then Exit For
        Next

    End Sub

    Public Sub WriteMeteoToTextFile(ByRef outFilePath As String)
        ' Ouvrir le fichier texte en mode écriture
        Dim nFic As Integer = FreeFile()
        FileOpen(nFic, outFilePath, OpenMode.Output)

        ' Écrire l'en-tête du fichier
        PrintLine(nFic, frmTempSeuil.Label12.Text)
        PrintLine(nFic, frmTempSeuil.NumericUpDown6.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown5.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown3.Value)

        PrintLine(nFic, frmTempSeuil.Label3.Text)
        PrintLine(nFic, frmTempSeuil.NumericUpDown1.Value)
        PrintLine(nFic, frmTempSeuil.Label6.Text)
        PrintLine(nFic, frmTempSeuil.NumericUpDown2.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown4.Value)
        PrintLine(nFic, frmTempSeuil.Label22.Text)

        PrintLine(nFic, frmTempSeuil.Label74.Text)
        PrintLine(nFic, frmTempSeuil.NumericUpDown24.Value)
        PrintLine(nFic, frmTempSeuil.Label76.Text)
        PrintLine(nFic, frmTempSeuil.NumericUpDown25.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown23.Value)
        PrintLine(nFic, frmTempSeuil.Label66.Text)

        PrintLine(nFic, frmTempSeuil.NumericUpDown8.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown7.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown9.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown10.Value)
        PrintLine(nFic, frmTempSeuil.TextBox1.Text)
        PrintLine(nFic, frmTempSeuil.NumericUpDown13.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown14.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown11.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown12.Value)
        PrintLine(nFic, frmTempSeuil.TextBox2.Text)

        PrintLine(nFic, frmTempSeuil.NumericUpDown21.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown22.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown19.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown20.Value)
        PrintLine(nFic, frmTempSeuil.TextBox4.Text)
        PrintLine(nFic, frmTempSeuil.NumericUpDown17.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown18.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown15.Value)
        PrintLine(nFic, frmTempSeuil.NumericUpDown16.Value)
        PrintLine(nFic, frmTempSeuil.TextBox3.Text)


        ' Fermer le fichier
        FileClose(nFic)
    End Sub


End Module

