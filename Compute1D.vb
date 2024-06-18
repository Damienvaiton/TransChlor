
Imports System.Linq

Public Class Compute1D

    Public LgLim As Integer = 40
    Public pPH As Double = 12.6
    Public mPh As Double = 6.5
    Public RoW As Integer = 1000        'kg/m3
    Public R As Double = 8.3145        'J/mol.K

    Public frm As frmGraph1D

    ' Moisture Parameters 
    Dim aa As Single ' Function coefficient
    Dim Hc As Single ' Function coefficient
    Dim ab As Single ' Function coefficient
    Dim tc As Single ' Function coefficient
    Dim ImpHydr As Boolean
    ' chloride
    Dim LambdaT(1) As Single
    Dim LambdaH(1) As Single
    Dim aOH As Single
    Dim EbG As Single
    Dim toG As Single
    Dim faG As Single
    ' Moisture variables
    Dim hMin As Single
    Dim hEcart As Single
    Dim wMin As Single
    Dim wEcart As Single
    Dim CTmin As Single
    Dim CTecart As Single
    Dim CLmin As Single
    Dim CLecart As Single
    Dim Tecart As Single
    Dim H_snap As Single
    Dim Retard As Single
    ' Structural data
    Dim TimeMax As Single
    Dim Length As Single 'length of the layer [mm]
    Dim Ne As Short 'Number of finite elements
    Dim Le(1) As Decimal 'element length
    Dim PosProf(1) As Decimal
    'Computational data
    Dim Dofs As Short
    'computationals values
    Dim DeltaT As Single
    'boundary conditions
    Dim NEXPO As Short
    Dim NQUAL As Short
    Dim taff As Single
    Dim Hsauv As Single
    Dim Wsauv As Single
    Dim CTsauv As Single
    Dim CLsauv As Single
    Dim Tsauv As Single
    Dim Carbsauv As Single
    Dim Filebeton(1) As String
    Dim Fileres(1) As String
    Dim PD(1) As Single
    Dim qGran(1) As Single
    Dim Dcl(1) As Single
    Dim SAT(1) As Single
    Dim ciment(1) As Single
    Dim FileGexpo(1) As String
    Dim FileDexpo(1) As String
    Dim proba(1, 1) As Single
    Dim ChoixRep As Short
    Dim nChmt As Short
    Dim Nbreel(1) As Short
    Dim LenApp(1) As Single
    Dim EC(1) As Single
    Dim EsC(1) As Single
    Dim tProt(1) As Single
    Dim Vct(1) As Single
    Dim Nct(1) As Single
    Dim capCal As Single
    Dim Hydr(1) As Single
    Dim ED(1) As Single
    Dim ToHydr(1) As Single
    Dim Ecl(1) As Single
    Dim ToCl(1) As Single
    Dim Ctherm(1) As Double
    Dim Chydr(1) As Double
    Dim Cion(1) As Double
    Dim PostFile As String
    Dim GyCO2 As Single
    Dim DyCO2 As Single
    Dim RoA(1) As Single
    Dim RoC(1) As Single

    Dim PintermManual As Integer = 0

    Public Sub ReadFile(ByRef Nbre1 As Short, ByRef Nbre2 As Short, ByRef Nbre3 As Short,
                        ByRef Creadtherm(,) As Double, ByRef Creadhydr(,) As Double, ByRef Creadion(,) As Double)

        ''''''''''''''''''''''''''''''''''''''''''''
        Dim Filtre As String = "Text files (INPUT_*.txt)|INPUT_*.txt"
        Dim Index As Short = 1
        Dim Directoire As Boolean = True
        Dim Titre As String = "Sélectionner le fichier d'exposition"
        Dim OutFile As String
        Dim Canc As Boolean = False
        Dim nFic As Integer = FreeFile()
        Dim i, j As Short

        OpenDialog(OutFile, Canc, Filtre, Index, Directoire, Titre)
        If Canc = True Then End
        ''''''''''''''''''''''''''''''''''''''''''''

        FileOpen(nFic, OutFile, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
        FilePost(OutFile, PostFile)

        Dim Para1 As Single
        Dim Para2 As Single
        Dim Para3 As Single
        Dim Para4 As Single
        Dim test As Single

        Input(nFic, Length)
        Input(nFic, Ne)
        Input(nFic, ChoixRep)
        ReDim Le(Ne + CShort(1))
        ReDim PosProf(Ne + CShort(2))

        PosProf(1) = 0
        Select Case ChoixRep
            Case CShort(1)
                For i = CShort(1) To Ne
                    Le(i) = CDec(Length) / CDec(Ne)
                    PosProf(i + CShort(1)) = PosProf(i) + Le(i)
                Next i
            Case CShort(2)
                Input(nFic, Le(1))
                Para1 = CSng(0)
                Para2 = CSng(0)
                For i = CShort(1) To CShort(Ne / 2 - 1)
                    Para1 = Para1 + CSng(1)
                    Para2 = Para2 + Para1
                Next i
                If Le(1) > CDec(Length) Then End
                Para1 = (Length / CSng(2) - CSng(Ne) / CSng(2) * CSng(Le(1))) / Para2
                PosProf(2) = Le(1)
                PosProf(Ne + CShort(1)) = CDec(Length)
                PosProf(Ne) = CDec(Length) - Le(1)
                For i = CShort(2) To CShort(Ne / 2)
                    Le(i) = Le(1) + (CDec(i) - CDec(1)) * CDec(Para1)
                    PosProf(i + CShort(1)) = PosProf(i) + Le(i)
                    Le(Ne - i) = Le(i)
                    PosProf(Ne + CShort(1) - i) = PosProf(Ne + CShort(2) - i) - Le(i)
                Next i
            Case 3
                Input(nFic, Le(1))
                Para3 = CSng(Le(1))
                test = CSng(10)
                If Le(1) > CDec(Length) Then End
                Do While System.Math.Abs(test) > 0.0001
                    Para1 = CSng(1) - Length / (CSng(2) * CSng(Le(1)))
                    Para2 = CSng(1)
                    For i = CShort(1) To CShort(Ne / 2 - 1)
                        Para1 += CSng(Para3 ^ i)
                        If i < Ne / CShort(2) - CShort(1) Then Para2 += CSng((i + 1) * Para3 ^ i)
                    Next i
                    Para4 = Para3 - Para1 / Para2
                    test = Para4 - Para3
                    Para3 = Para4
                Loop
                PosProf(2) = Le(1)
                PosProf(Ne + CShort(1)) = CDec(Length)
                PosProf(Ne) = CDec(Length) - Le(1)
                For i = CShort(2) To CShort(Ne / 2)
                    Le(i) = CDec(Le(1) * Para4 ^ (i - 1))
                    PosProf(i + CShort(1)) = PosProf(i) + Le(i)
                    Le(Ne - i) = Le(i)
                    PosProf(Ne + CShort(1) - i) = PosProf(Ne + CShort(2) - i) - Le(i)
                Next i
            Case 4
                Input(nFic, nChmt)
                ReDim Nbreel(nChmt - CShort(1))
                ReDim LenApp(nChmt - CShort(1))
                PosProf(Ne + CShort(1)) = CDec(Length)
                Para1 = CSng(0)
                Para2 = CSng(0)
                For i = CShort(1) To nChmt - CShort(1)
                    Input(nFic, Nbreel(i))
                    Input(nFic, LenApp(i))
                    For j = CShort(1) To Nbreel(i)
                        Le(j + CShort(Para1)) = CDec(LenApp(i)) / CDec(Nbreel(i))
                        PosProf(j + CShort(1) + CShort(Para1)) = PosProf(j + CShort(Para1)) + Le(j + CShort(Para1))
                        Le(Ne + CShort(1) - j - CShort(Para1)) = Le(j + CShort(Para1))
                        PosProf(Ne + CShort(1) - j - CShort(Para1)) = PosProf(Ne + CShort(2) - j - CShort(Para1)) - Le(j + CShort(Para1))
                    Next j
                    Para1 = Para1 + CSng(Nbreel(i))
                    Para2 = Para2 + LenApp(i)
                Next i
                Para3 = CSng(Ne) - CSng(2) * Para1
                Para2 = Length - CSng(2) * Para2
                For i = CShort(Para1) + CShort(1) To CShort(Para1) + CShort(Para3)
                    Le(i) = CDec(Para2) / CDec(Para3)
                    PosProf(i + CShort(1)) = PosProf(i) + Le(i)
                Next i
            Case 5
                Input(nFic, nChmt)
                ReDim Nbreel(nChmt - CShort(1))
                ReDim LenApp(nChmt - CShort(1))
                PosProf(Ne + CShort(1)) = CDec(Length)
                Para1 = CSng(0)
                Para2 = CSng(0)
                For i = CShort(1) To nChmt - CShort(1)
                    Input(nFic, Nbreel(i))
                    Input(nFic, LenApp(i))
                    For j = CShort(1) To Nbreel(i)
                        Le(j + CShort(Para1)) = CDec(LenApp(i)) / CDec(Nbreel(i))
                        PosProf(j + CShort(1) + CShort(Para1)) = PosProf(j + CShort(Para1)) + Le(j + CShort(Para1))
                    Next j
                    Para1 = Para1 + CSng(Nbreel(i))
                    Para2 = Para2 + LenApp(i)
                Next i
                Para3 = CSng(Ne) - Para1
                Para2 = Length - Para2
                For i = CShort(Para1) + CShort(1) To CShort(Para1) + CShort(Para3)
                    Le(i) = CDec(Para2) / CDec(Para3)
                    PosProf(i + CShort(1)) = PosProf(i) + Le(i)
                Next i
        End Select

        Input(nFic, TimeMax)
        Input(nFic, DeltaT)
        Input(nFic, taff)
        Input(nFic, Hsauv)
        Input(nFic, Wsauv)
        Input(nFic, CTsauv)
        Input(nFic, CLsauv)
        Input(nFic, Tsauv)
        Input(nFic, Carbsauv)
        Input(nFic, hMin)
        Input(nFic, hEcart)
        Input(nFic, wMin)
        Input(nFic, wEcart)
        Input(nFic, CLmin)
        Input(nFic, CLecart)
        Input(nFic, CTmin)
        Input(nFic, CTecart)
        Input(nFic, Tecart)
        Input(nFic, aa)
        Input(nFic, Hc)
        Input(nFic, ab)
        Input(nFic, tc)
        Input(nFic, ImpHydr)
        Input(nFic, H_snap)
        Input(nFic, Retard)
        Input(nFic, aOH)
        Input(nFic, EbG)
        Input(nFic, toG)
        Input(nFic, faG)
        Input(nFic, capCal)
        Input(nFic, GyCO2)
        Input(nFic, DyCO2)

        Input(nFic, NEXPO)
        ReDim FileGexpo(NEXPO)
        ReDim FileDexpo(NEXPO)
        For i = CShort(1) To NEXPO
            Input(nFic, FileGexpo(i))
            Input(nFic, FileDexpo(i))
        Next i

        Input(nFic, NQUAL)
        ReDim Filebeton(NQUAL)
        ReDim Fileres(NQUAL)
        ReDim PD(NQUAL)
        ReDim Dcl(NQUAL)
        ReDim qGran(NQUAL)
        ReDim LambdaH(NQUAL)
        ReDim LambdaT(NQUAL)
        ReDim SAT(NQUAL)
        ReDim ciment(NQUAL)
        ReDim EC(NQUAL)
        ReDim tProt(NQUAL)
        ReDim Vct(NQUAL)
        ReDim Nct(NQUAL)
        ReDim Hydr(NQUAL)
        ReDim ED(NQUAL)
        ReDim ToHydr(NQUAL)
        ReDim Ecl(NQUAL)
        ReDim ToCl(NQUAL)
        ReDim RoA(NQUAL)
        ReDim RoC(NQUAL)
        ReDim proba(NQUAL, 19)
        ReDim EsC(NQUAL)
        For i = CShort(1) To NQUAL
            Input(nFic, Filebeton(i))
            Input(nFic, Fileres(i))
            Input(nFic, PD(i))
            Input(nFic, Dcl(i))
            Input(nFic, qGran(i))
            Input(nFic, LambdaH(i))
            Input(nFic, LambdaT(i))
            Input(nFic, SAT(i))
            Input(nFic, ciment(i))
            Input(nFic, EC(i))
            Input(nFic, tProt(i))
            Input(nFic, Hydr(i))
            Input(nFic, Vct(i))
            Input(nFic, Nct(i))
            Input(nFic, ED(i))
            Input(nFic, ToHydr(i))
            Input(nFic, Ecl(i))
            Input(nFic, ToCl(i))
            Input(nFic, RoA(i))
            Input(nFic, RoC(i))
            For j = 0 To 19
                Input(nFic, proba(i, j))
            Next
            Input(nFic, EsC(i))
        Next i

        ReDim Creadtherm(1, 1)
        ReDim Creadhydr(1, 1)
        ReDim Creadion(1, 1)

        Input(nFic, Nbre1)
        ReDim Creadtherm(1, Nbre1)
        For i = 1 To Nbre1
            Input(nFic, Creadtherm(0, i))
            Input(nFic, Creadtherm(1, i))
        Next

        Input(nFic, Nbre2)
        ReDim Creadhydr(1, Nbre2)
        For i = 1 To Nbre2
            Input(nFic, Creadhydr(0, i))
            Input(nFic, Creadhydr(1, i))
            Creadhydr(1, i) = Creadhydr(1, i) / 100
        Next

        Input(nFic, Nbre3)
        ReDim Creadion(1, Nbre3)
        For i = 1 To Nbre3
            Input(nFic, Creadion(0, i))
            Input(nFic, Creadion(1, i))
        Next

        Try
            Input(nFic, PintermManual)
            MsgBox("Le nombre de points est de" & CStr(PintermManual), MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "Information Points de discretisation")
        Catch
            MsgBox("Attention aucun points pris en compte manuellement", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "Information Points de discretisation")
        End Try

        FileClose(nFic)

    End Sub

    Public Sub InitialConditions(ByRef Nbre1 As Short, ByRef Nbre2 As Short, ByRef Nbre3 As Short,
                                 ByRef Creadtherm(,) As Double, ByRef Creadhydr(,) As Double, ByRef Creadion(,) As Double)

        Dofs = Ne + CShort(1)

        'calcul des conditions initiales
        Dim i As Short
        Dim j As Short = 0
        ReDim Ctherm(Dofs + 1)
        Dim Var, Var1 As Double

        For i = 1 To Nbre1 - 1
            Var = (Creadtherm(1, i + 1) - Creadtherm(1, i)) / (Creadtherm(0, i + 1) - Creadtherm(0, i))
            Var1 = Creadtherm(1, i) - Var * Creadtherm(0, i)
            If j <= Dofs Then
                Do While PosProf(j) <= Creadtherm(0, i + 1)
                    Ctherm(j) = Var * PosProf(j) + Var1
                    j = j + 1
                    If j > Dofs Then Exit Do
                Loop
            End If
            Ctherm(Dofs + 1) = Ctherm(Dofs)
        Next
        j = 0

        ReDim Chydr(Dofs + 1)
        For i = 1 To Nbre2 - 1
            Var = (Creadhydr(1, i + 1) - Creadhydr(1, i)) / (Creadhydr(0, i + 1) - Creadhydr(0, i))
            Var1 = Creadhydr(1, i) - Var * Creadhydr(0, i)
            If j <= Dofs Then
                Do While PosProf(j) <= Creadhydr(0, i + 1)
                    Chydr(j) = Var * PosProf(j) + Var1
                    j = j + 1
                    If j > Dofs Then Exit Do
                Loop
            End If
            Chydr(Dofs + 1) = Chydr(Dofs)
            If j > Dofs + 1 Then Exit For
        Next
        j = 0

        ReDim Cion(Dofs + 1)
        For i = 1 To Nbre3 - 1
            Var = (Creadion(1, i + 1) - Creadion(1, i)) / (Creadion(0, i + 1) - Creadion(0, i))
            Var1 = Creadion(1, i) - Var * Creadion(0, i)
            If j <= Dofs Then
                Do While PosProf(j) <= Creadion(0, i + 1)
                    Cion(j) = Var * PosProf(j) + Var1
                    j = j + 1
                    If j > Dofs Then Exit Do
                Loop
            End If
            Cion(Dofs + 1) = Cion(Dofs)
        Next

        Le(0) = CDec(1)       'couche limite
        Le(Dofs) = CDec(1)    'couche limite

    End Sub

    Public Sub InitFrmGraph()

        frm = New frmGraph1D
        frm.MdiParent = MDIChlor
        frm.Left = 0
        frm.Top = 0
        frm.Height = (MDIChlor.Height)
        frm.Width = (MDIChlor.Width)

        frm.Show()

    End Sub

    Public Function ReadExpo(ByRef INFile As String, ByRef NbreEn As Integer, ByRef Fit As Single, ByRef Temperature() As Decimal, ByRef Humidite() As Single, ByRef Sel() As Single,
                             ByRef Msel As Decimal, ByRef SAT() As Single, ByRef TempMin As Decimal, ByRef TempMax As Single, ByRef TempEcart As Single, ByRef nCouches As Integer, ByRef NQUAL As Integer, ByRef bordG As Boolean) As Boolean

        Dim nFic As Short = CShort(FreeFile())
        Dim wsat As Single

        If INFile.Contains(".txt") = True Then

            Try
                FileOpen(CInt(nFic), INFile, OpenMode.Input, OpenAccess.Read)
                Input(CInt(nFic), NbreEn)
                Input(CInt(nFic), Fit)

                ReDim Humidite(NbreEn)
                ReDim Sel(NbreEn)
                ReDim Temperature(NbreEn)
                If nCouches > 1 Then '03.10.2023 début
                    If bordG = True Then
                        wsat = SAT(1)
                    Else
                        wsat = SAT(nCouches)
                    End If
                End If  '03.10.2023 fin

                For j As Integer = 1 To NbreEn
                    Input(CInt(nFic), Humidite(j))
                    Input(CInt(nFic), Sel(j))
                    Input(CInt(nFic), Temperature(j))
                    If Temperature(j) > TempMax Then TempMax = Temperature(j)
                    If Temperature(j) < TempMin Then TempMin = Temperature(j)
                    Sel(j) *= CSng(35.453 / 58.443)    'calcul de cT à partir de co à multiplier par w(0) ou (dofs)
                    If Msel < Sel(j) * wsat Then Msel = CDec(Sel(j) * wsat)
                Next
                FileClose(CInt(nFic))

            Catch ex As Exception
                Return False
            End Try

        Else

            Try

                Dim DBCon As New DBconnexion
                'Dim Expo As New MaterialsData

                DBCon.DBRequest("SELECT * FROM [" + INFile + "]")
                'DBCon.MatFill(Expo, INFile)

                'Dim ExpoTable()() As Object = Expo.Tables(INFile).Rows.Cast(Of DataRow).Select(Function(dr) dr.ItemArray).ToArray

                'NbreEn = ExpoTable.Count()
                Fit = 3600

                ReDim Humidite(NbreEn)
                ReDim Sel(NbreEn)
                ReDim Temperature(NbreEn)

                For j As Integer = 0 To NbreEn - 1
                    'Humidite(j) = CSng(ExpoTable(j)(1))
                    'Sel(j) = CSng(ExpoTable(j)(2))
                    'Temperature(j) = CDec(ExpoTable(j)(3))
                    If Temperature(j) > TempMax Then TempMax = Temperature(j)
                    If Temperature(j) < TempMin Then TempMin = Temperature(j)
                    Sel(j) *= CSng(35.453 / 58.443) 'calcul de cT à partir de co à multiplier par w(0) ou (dofs)
                    If Msel < Sel(j) * wsat Then Msel = CDec(Sel(j) * wsat)
                Next j

            Catch ex As Exception
                Return False
            End Try

        End If

        Return True

    End Function

    'Coeur du calcul
    Public Sub Compute_All()

        ' Moisture variables
        Dim H_old(1) As Decimal ' Moisture potential at beginning interval[-]  (p/ps)
        Dim H_new(1) As Decimal ' Moisture potential at end of interval
        Dim H_trial(1) As Decimal ' Trial moisture potential during iteration
        Dim Hold(1) As Decimal ' H limit on desorption line [-]
        Dim W(1) As Decimal ' water content [kg/m3]
        Dim T_old(1) As Decimal
        Dim T_new(1) As Decimal
        Dim T_trial(1) As Decimal
        Dim C_old(1) As Decimal
        Dim C_new(1) As Decimal
        Dim C_trial(1) As Decimal
        Dim CBo(1) As Decimal
        Dim GCboundary As Decimal
        Dim DCboundary As Decimal
        Dim CT(1) As Decimal
        Dim LHS(2, 1) As Decimal
        Dim RHS(1) As Decimal
        Dim Speed(1) As Decimal

        Dim i As Long
        Dim i_day As Long
        Dim iG As Long
        Dim iD As Long
        Dim j As Long
        Dim jj As Short
        Dim jjj As Short
        Dim k As Long
        Dim Boucle1 As Short
        Dim Boucle2 As Short
        Dim Bou2 As Short
        Dim Boucle3 As Short
        Dim Boucle4 As Short
        Dim Boucle5 As Short
        Dim Boucle6 As Short
        Dim Ha As Decimal
        Dim Mcap As Decimal
        Dim f1 As Decimal
        Dim f2 As Decimal
        Dim f3 As Decimal
        Dim f5 As Decimal
        Dim C11 As Decimal
        Dim C12 As Decimal
        Dim test As Decimal
        Dim testOld As Decimal
        Dim ExB As Boolean = False
        Dim Position As Decimal
        Dim Cond01 As Short
        Dim Hteller As Double
        Dim Wteller As Double
        Dim CTteller As Double
        Dim CLteller As Double
        Dim Tteller As Double
        Dim Carbteller As Double
        Dim affiche As Double
        Dim GTemperature(1) As Decimal
        Dim GHumidite(1) As Single
        Dim GSel(1) As Single
        Dim DTemperature(1) As Decimal
        Dim DHumidite(1) As Single
        Dim DSel(1) As Single
        Dim GINFile As String
        Dim DINFile As String
        Dim OutFile(7) As String
        Dim DelT As Single
        Dim FiT As Single
        Dim GFiT As Single
        Dim DFiT As Single
        Dim NbreEn As Long
        Dim GNbreEn As Long
        Dim DNbreEn As Long
        Dim Dim1 As Short
        Dim Dim2 As Short
        Dim t1 As Single
        Dim t2 As Single
        Dim nFic As Short
        Dim nFic1 As Short
        Dim nFic2 As Short
        Dim nFic3 As Short
        Dim nFic4 As Short
        Dim nFic5 As Short
        Dim nFic6 As Short
        Dim nFic7 As Short

        ' Dim nFic8 As Short      'prov
        Dim XdHmax As Single
        Dim XdCTmax As Single
        Dim XdTmax As Single
        Dim Tsec As Long
        Dim Num As Short
        Dim GSTa As String
        Dim DSTa As String
        Dim Pinterm As Short
        Dim Interm(8) As Single
        Dim dHmax As Single
        Dim dTmax As Single
        Dim dCTmax As Single
        Dim GdelTemp As Single
        Dim GdelH As Single
        Dim GdelCF As Single
        Dim DdelTemp As Single
        Dim DdelH As Single
        Dim DdelCF As Single
        Dim GTextold As Single
        Dim GHextold As Single
        Dim GCFextold As Single
        Dim GCTextold As Single
        Dim DTextold As Single
        Dim DHextold As Single
        Dim DCFextold As Single
        Dim DCTextold As Single
        Dim GTextern As Single
        Dim GHextern As Single
        Dim GCFextern As Single
        Dim GCTextern As Single
        Dim DTextern As Single
        Dim DHextern As Single
        Dim DCFextern As Single
        Dim DCTextern As Single
        Dim Tijd As Decimal
        Dim tijdOld As Decimal
        Dim testing1 As Single
        Dim testing2 As Single
        Dim testing3 As Single
        'Dim Compteur(5) As Short
        Dim TempMin As Single = 40
        Dim TempMax As Single = -30
        Dim TempEcart As Single = 0
        Dim NprobHr As Short
        Dim NprobCap As Short
        Dim NprobCl As Short
        Dim NprobCa As Short
        Dim PdTot As Double
        Dim PdHr(2) As Double
        Dim PdCap(2) As Double
        Dim PdCl(2) As Double
        Dim PdCa(2) As Double
        Dim CoefHr(2) As Double
        Dim CoefCap(2) As Double
        Dim CoefCl(2) As Double
        Dim CoefCa(2) As Double
        Dim FileProb As String
        Dim FprobHr(2) As String
        Dim FprobCap(2) As String
        Dim FprobCl(2) As String
        Dim FprobCa(2) As String
        'Dim Di As Single ' diffusion suppression 3.10.2023
        Dim CumW As Decimal ' water content cumulé [kg/m3]
        Dim CumH As Decimal ' humidité relative moyen
        'Dim CumClT As Decimal ' total chloride ions cumulé [kg/m3]
        Dim Wsat As Single ' Saturated moisture content [kg/m3]   suppression 3.10.2023
        Dim BDlibre As Boolean
        Dim Gcptj As Long
        Dim Dcptj As Long
        Dim Gctj As Long
        Dim Dctj As Long
        Dim Nbn As Short = 0
        Dim Ltot As Decimal = 0
        Dim HAncien(Dofs + 1) As Decimal
        Dim W_old(Dofs + 1) As Decimal
        Dim Ae(Dofs + 1) As Decimal
        Dim Be(Dofs + 1) As Decimal
        Dim ClNeg As Decimal = 0
        Dim c_int As Decimal
        Dim Ph(Dofs) As Decimal
        Dim Gamma(Dofs + 1) As Single
        Dim TW As Boolean
        Dim tPrec As Single = 0
        Dim Wol As Boolean = False
        Dim DRHe As Single
        Dim GRHe As Single
        Dim CumTemps As Single
        Dim iGco As Long = 1
        Dim iDco As Long = 1
        Dim Gxc As Double
        Dim Dxc As Double
        Dim Gxcold As Double
        Dim Dxcold As Double
        Dim GPH As Single
        Dim DPH As Single
        Dim Msel As Decimal = 0
        Dim CB As Short = 1
        Dim DB As Short = 1
        Dim jEnd As Short = 0
        Dim jStart As Short = 0
        Dim bSup As Single = 0
        Dim bInf As Single = 0
        Dim SingVal As Boolean = False
        Dim PenteA As Single = 0
        Dim valB As Single = 0
        Dim parA As Decimal     'paramètre pour le calcul du coefficient de capillarité
        Dim parB As Decimal
        Dim parA1 As Decimal
        Dim parB1 As Decimal
        Dim parC1 As Decimal
        Dim Hleft As Decimal
        Dim Hright As Decimal
        Dim Tleft As Decimal
        Dim Tright As Decimal
        Dim DcapLeft As Decimal
        Dim DcapRight As Decimal
        Dim ptest As Boolean
        Dim Ctest As Decimal
        Dim CTmax As Double
        Dim CLmax As Double
        Dim CTmold As Integer
        Dim CLmold As Integer
        Dim Hsym As Boolean
        Dim Ssym As Boolean
        Dim Tsym As Boolean
        Dim nCouches As Integer
        Dim EpCouches(1) As Double
        Dim Can As Short

        ' redimension variables
        ReDim T_new(Dofs + CShort(1))
        ReDim T_old(Dofs + CShort(1))
        ReDim T_trial(Dofs + CShort(1))
        ReDim H_new(Dofs + CShort(1))
        ReDim H_old(Dofs + CShort(1))
        ReDim H_trial(Dofs + CShort(1))
        ReDim Hold(Dofs + CShort(1))
        ReDim W(Dofs + CShort(1))
        ReDim LHS(2, Dofs + CShort(1))
        ReDim RHS(Dofs + CShort(1))
        ReDim C_old(Dofs + CShort(1))
        ReDim C_new(Dofs + CShort(1))
        ReDim C_trial(Dofs + CShort(1))
        ReDim CBo(Dofs + CShort(1))
        ReDim CT(Dofs + CShort(1))
        ReDim Speed(Dofs + CShort(1))

        ' version sept 15th 2002
        ' First initialize all variables

        MDIChlor.Prefile = PostFile

        Hteller = CDbl(Hsauv)
        Wteller = CDbl(Wsauv)
        CTteller = CDbl(CTsauv)
        CLteller = CDbl(CLsauv)
        Tteller = CDbl(Tsauv)
        Carbteller = CDbl(Carbsauv)
        affiche = CDbl(taff)

        dHmax = CSng(0.1) 'convergence conditions limites (humidité relative)
        testing1 = CSng(0.0001) 'convergence itération (humidité relative)
        dCTmax = CSng(0.1) * 8 'convergence conditions limites (ions chlorures)
        testing2 = CSng(0.000025) * 8 'convergence itération (ions chlorures)
        XdHmax = CSng(0.2) 'grand saut du aux CL
        XdCTmax = 8 / CSng(3) 'grand saut du aux CL
        DelT = DeltaT
        TempMin = CSng(-10)
        TempMax = CSng(40)
        'For j = CShort(1) To CShort(5)
        '    Compteur(j) = CShort(0)
        'Next j
        'programmation pour obtenir des fichiers de comparaison (provisoire)
        'Dim nFile As Integer = FreeFile()
        'Dim HRCUMUL(1000, 20) As Decimal
        'Dim cpt1 As Integer
        'Dim cpt2 As Integer
        'FileOpen(CInt(nFile), "R_HR_cumul.txt", OpenMode.Output)

        For Boucle1 = CShort(1) To NEXPO 'exposition direct, éclaboussures, brouillard
            If NQUAL > 1 Then Can = MsgBox("Y a-t-il plusieurs couches ?", MsgBoxStyle.YesNo, "Avertissment") '03.10.2023 début
            If Can = MsgBoxResult.Yes Then
                nCouches = NQUAL
            Else nCouches = 1
            End If
            If nCouches > 1 Then
                ReDim EpCouches(nCouches - 1)
                NQUAL = 1
                EpCouches(0) = 0
                For i = 1 To nCouches - 1
                    EpCouches(i) = InputBox("Épaisseur de la couche no" & i & "? (max " & Length & " mm)", "Question", Length) + EpCouches(i - 1)
                Next i
            End If          '03.10.2023 fin
            For Boucle2 = CShort(1) To NQUAL 'qualité du béton bonne, moyenne, mauvaise
                Bou2 = Boucle2
                If proba(Boucle2, 0) = 0 Then
                    NprobHr = 1
                    PdHr(1) = 1
                    CoefHr(1) = 1
                    FprobHr(1) = "0"
                Else
                    NprobHr = 2
                    CoefHr(1) = proba(Boucle2, 1)
                    CoefHr(2) = proba(Boucle2, 2)
                    PdHr(1) = proba(Boucle2, 3)
                    PdHr(2) = proba(Boucle2, 4)
                    FprobHr(1) = "1"
                    FprobHr(2) = "2"
                End If
                If proba(Boucle2, 5) = 0 Then
                    NprobCap = 1
                    PdCap(1) = 1
                    CoefCap(1) = 1
                    FprobCap(1) = "0"
                Else
                    NprobCap = 2
                    CoefCap(1) = proba(Boucle2, 6)
                    CoefCap(2) = proba(Boucle2, 7)
                    PdCap(1) = proba(Boucle2, 8)
                    PdCap(2) = proba(Boucle2, 9)
                    FprobCap(1) = "1"
                    FprobCap(2) = "2"
                End If
                If proba(Boucle2, 10) = 0 Then
                    NprobCl = 1
                    PdCl(1) = 1
                    CoefCl(1) = 1
                    FprobCl(1) = "0"
                Else
                    NprobCl = 2
                    CoefCl(1) = proba(Boucle2, 11)
                    CoefCl(2) = proba(Boucle2, 12)
                    PdCl(1) = proba(Boucle2, 13)
                    PdCl(2) = proba(Boucle2, 14)
                    FprobCl(1) = "1"
                    FprobCl(2) = "2"
                End If
                If proba(Boucle2, 15) = 0 Then
                    NprobCa = 1
                    PdCa(1) = 1
                    CoefCa(1) = 1
                    FprobCa(1) = "0"
                Else
                    NprobCa = 2
                    CoefCa(1) = proba(Boucle2, 16)
                    CoefCa(2) = proba(Boucle2, 17)
                    PdCa(1) = proba(Boucle2, 18)
                    PdCa(2) = proba(Boucle2, 19)
                    FprobCa(1) = "1"
                    FprobCa(2) = "2"
                End If
                For Boucle3 = CShort(1) To NprobHr 'approche probabiliste sur humidité relative
                    For Boucle4 = CShort(1) To NprobCap 'approche probabiliste sur l'eau liquide
                        For Boucle5 = CShort(1) To NprobCl 'approche probabiliste sur humidité relative
                            For Boucle6 = CShort(1) To NprobCa 'approche probabiliste sur humidité relative
                                PdTot = PdHr(Boucle3) * PdCap(Boucle4) * PdCl(Boucle5) * PdCa(Boucle6)
                                FileProb = FprobHr(Boucle3) & FprobCap(Boucle4) & FprobCl(Boucle5) & FprobCa(Boucle6)
                                'cpt1 = cpt1 + 1
                                'cpt2 = 0
                                CB = 1
                                DB = 1
                                iG = 1
                                iD = 1
                                iGco = 1
                                iDco = 1
                                tPrec = 0
                                DRHe = 0
                                GRHe = 0
                                Gxcold = 0
                                Dxcold = 0
                                CumTemps = 0
                                Msel = 0
                                BDlibre = False
                                CLmax = 1
                                CTmax = 1

                                'coefficient de diffusion des ions de cl- + teneur en eau saturé
                                'Di = Dcl(Boucle2) 'mm2/s 3.10.2023 suppression
                                Wsat = SAT(Boucle2) 'kg/m3 bon béton 
                                If nCouches > 1 Then '03.10.2023 début
                                    For j = 1 To nCouches
                                        If Wsat < SAT(j) Then Wsat = SAT(j)
                                    Next j
                                End If     '03.10.2023 fin
                                Tijd = CDec(0)
                                For i = CLng(0) To CLng(Dofs)  'conditions aux limites sur les noeuds
                                    'Cion(i) = Cion(i) * Wsat * 35.453 / 58.443
                                    H_old(i) = CDec(Chydr(i))
                                    H_new(i) = CDec(Chydr(i))
                                    H_trial(i) = CDec(Chydr(i))
                                    Hold(i) = CDec(Chydr(i))
                                    HAncien(i) = CDec(Chydr(i))
                                    T_old(i) = CDec(Ctherm(i))
                                    T_new(i) = CDec(Ctherm(i))
                                    T_trial(i) = CDec(Ctherm(i))
                                    If nCouches > 1 Then '03.10.2023 début
                                        For j = 1 To nCouches - 1
                                            If PosProf(i) < EpCouches(j) Then
                                                W(i) = Water(CDec(Chydr(i)), HAncien(i), T_new(i), Tijd, tProt(j), Vct(j), Nct(j), EC(j), SAT(j), Hydr(j), ciment(j), Wol)
                                                Ph(i) = pPH
                                                Gamma(i) = System.Math.Exp(aOH * (1 - 10 ^ (Ph(i) - pPH))) * System.Math.Exp(EbG / R * (1 / (273.16 + T_new(i)) - 1 / toG)) * ciment(j) * Hydr(j) * faG / 1000
                                                Exit For
                                            ElseIf j = nCouches - 1 Then
                                                W(i) = Water(CDec(Chydr(i)), HAncien(i), T_new(i), Tijd, tProt(nCouches), Vct(nCouches), Nct(nCouches), EC(nCouches), SAT(nCouches), Hydr(nCouches), ciment(nCouches), Wol)
                                                Ph(i) = pPH
                                                Gamma(i) = System.Math.Exp(aOH * (1 - 10 ^ (Ph(i) - pPH))) * System.Math.Exp(EbG / R * (1 / (273.16 + T_new(i)) - 1 / toG)) * ciment(nCouches) * Hydr(nCouches) * faG / 1000
                                                Exit For
                                            End If
                                        Next j
                                    Else
                                        W(i) = Water(CDec(Chydr(i)), HAncien(i), T_new(i), Tijd, tProt(Boucle2), Vct(Boucle2), Nct(Boucle2), EC(Boucle2), SAT(Boucle2), Hydr(Boucle2), ciment(Boucle2), Wol)
                                        Ph(i) = pPH
                                        Gamma(i) = System.Math.Exp(aOH * (1 - 10 ^ (Ph(i) - pPH))) * System.Math.Exp(EbG / R * (1 / (273.16 + T_new(i)) - 1 / toG)) * ciment(Boucle2) * Hydr(Boucle2) * faG / 1000
                                    End If  '03.10.2023 fin


                                Next i
                                'Cion(Dofs + 1) = Cion(Dofs + 1) * Wsat * 35.453 / 58.443
                                H_old(Dofs + 1) = CDec(Chydr(i))
                                H_new(Dofs + 1) = CDec(Chydr(Dofs))
                                H_trial(Dofs + 1) = CDec(Chydr(Dofs))
                                Hold(Dofs + 1) = CDec(Chydr(Dofs))
                                HAncien(Dofs + 1) = CDec(Chydr(Dofs))
                                T_old(Dofs + 1) = CDec(Ctherm(Dofs))
                                T_new(Dofs + 1) = CDec(Ctherm(Dofs))
                                T_trial(Dofs + 1) = CDec(Ctherm(Dofs))
                                If nCouches > 1 Then '03.10.2023 début
                                    W(Dofs + 1) = Water(CDec(Chydr(Dofs)), HAncien(Dofs), T_new(Dofs), Tijd, tProt(nCouches), Vct(nCouches), Nct(nCouches), EC(nCouches), SAT(nCouches), Hydr(nCouches), ciment(nCouches), Wol)
                                Else
                                    W(Dofs + 1) = Water(CDec(Chydr(Dofs)), HAncien(Dofs), T_new(Dofs), Tijd, tProt(Boucle2), Vct(Boucle2), Nct(Boucle2), EC(Boucle2), SAT(Boucle2), Hydr(Boucle2), ciment(Boucle2), Wol)
                                End If     '03.10.2023 fin

                                Hleft = 0
                                Hright = 0
                                ptest = False

                                For i = CLng(1) To CLng(Dofs) 'conditions aux limites sur les noeuds
                                    C_old(i) = Cfree(CDec(Cion(i)), CDec(Gamma(i)), W(i))
                                    C_new(i) = C_old(i)
                                    C_trial(i) = C_old(i)
                                    CT(i) = Cion(i)
                                    If PosProf(i) < LgLim And i <> 0 Then
                                        Hleft = Hleft + H_new(i) * Le(i)
                                        If PosProf(i + 1) >= LgLim Then Hleft = Hleft + H_new(i + 1) * (LgLim - PosProf(i))
                                    End If
                                    If PosProf(i) > Length - LgLim And i <> Dofs + 1 And BDlibre = False Then
                                        If ptest = False Then
                                            Hright = H_new(i) * (PosProf(i) - Length + LgLim)
                                            ptest = True
                                        Else
                                            Hright = Hright + H_new(i) * Le(i - 1)
                                        End If
                                    End If
                                Next i

                                Hright = Hright / LgLim 'Regle pb de Dcap des 2 cotés
                                Hleft = Hleft / LgLim 'Regle pb de Dcap des 2 cotés

                                frm.design(Wsat, H_old, W, T_old, C_new, CT, TempMin, TempMax, Length, PosProf, hMin, hEcart, wMin, wEcart, CTmin, CTecart, CTmax, CLmin, CLecart, CLmax, Tecart, Dofs, Tijd, Gxc, Dxc, Ph)

                                ' -------------------------------
                                ' start of computations
                                affiche = CDbl(0)
                                Hteller = CDbl(0)
                                Wteller = CDbl(0)
                                CTteller = CDbl(0)
                                CLteller = CDbl(0)
                                Tteller = CDbl(0)
                                Carbteller = CDbl(0)

                                If ReadExpo(FileGexpo(Boucle1), GNbreEn, GFiT, GTemperature, GHumidite, GSel, Msel, SAT, TempMin, TempMax, TempEcart, nCouches, NQUAL, True) = False Then '03.10.2023 ajout nCouches + NQUAL + 0 + changer wsat en SAT()
                                    MsgBox("ERROR: Exposition File not found!")
                                    GoTo BreakBoucle1
                                End If

                                FiT = GFiT
                                NbreEn = GNbreEn

                                If FileDexpo(Boucle1) = "noFile" Then BDlibre = True

                                If BDlibre = False Then

                                    If ReadExpo(FileDexpo(Boucle1), DNbreEn, DFiT, DTemperature, DHumidite, DSel, Msel, SAT, TempMin, TempMax, TempEcart, nCouches, NQUAL, False) = True Then   '03.10.2023 ajout nCouches + NQUAL + 0 + changer wsat en SAT()

                                        If GFiT <> DFiT Then MsgBox("fichier d'exposition incompatible", MsgBoxStyle.Information, "Avertissement")
                                        FiT = GFiT

                                        If GNbreEn >= DNbreEn Then
                                            NbreEn = GNbreEn
                                        Else
                                            NbreEn = DNbreEn
                                        End If

                                        Hsym = True
                                        Ssym = True
                                        Tsym = True

                                        For j = 1 To DNbreEn

                                            If Msel < DSel(j) Then Msel = DSel(j)
                                            If DHumidite(j) <> GHumidite(j) Then Hsym = False
                                            If DSel(j) <> GSel(j) Then Ssym = False
                                            If DTemperature(j) <> GTemperature(j) Then Tsym = False
                                        Next j

                                    Else

                                        MsgBox("ERROR: Exposition File at Rigth not considered!")
                                        BDlibre = True

                                    End If

                                End If

                                TempEcart = TempMax - TempMin

                                If TempEcart = 0 Then       'cas d'essai isotherme
                                    TempEcart = 0.1
                                    TempMax = 30
                                    TempMin = -10
                                End If

                                dTmax = CSng(0.02) * TempEcart 'convergence conditions limites (température)
                                testing3 = CSng(0.0002) * TempEcart 'convergence itération (température)
                                XdTmax = TempEcart / CSng(3) 'grand saut du aux CL

                                CumW = CDec(0)
                                CumH = CDec(0)
                                'CumClT = CDec(0)
                                For j = CShort(1) To Dofs - CShort(1)       'calcul de la cumulée de W
                                    CumH = CumH + (H_new(j) + H_new(j + 1)) * Le(j) / 2
                                    CumW = CumW + Le(j) * (W(j) + W(j + CShort(1))) / CDec(2)
                                    'CumClT = CumClT + Le(j) * (CT(j) + CT(j + CShort(1))) / CDec(2)
                                Next j
                                CumH = CumH / CDec(Length)
                                CumW = CumW / CDec(Length)
                                'CumClT = CumClT / CDec(Length)

                                GSTa = FileGexpo(Boucle1)
                                DSTa = FileDexpo(Boucle1)

                                FileOnly(GSTa)
                                FileOnly(DSTa)
                                GSTa = Mid(GSTa, 6)
                                DSTa = Mid(DSTa, 6)
                                Num = CShort(GSTa.Length)
                                GSTa = Left(GSTa, Num - 4)
                                Num = CShort(DSTa.Length)
                                If BDlibre = False Then DSTa = Left(DSTa, Num - 4)

                                Dim TitreGraph As String = "Panel with computed results, " & GSTa & ", " & DSTa & ", " & Filebeton(Boucle2) & ", " & FileProb
                                frm.ModifyTitle(TitreGraph)

                                'frm02.Text = "Panel with computed results, " & GSTa & ", " & DSTa & ", " & Filebeton(Boucle2) & ", " & FileProb 'Erreur VS2019 2020-04-24
                                OutFile(1) = PostFile & "R_H_" & GSTa & "_" & DSTa & "_" & Fileres(Boucle2) & "_" & FileProb & ".txt"
                                OutFile(2) = PostFile & "R_W_" & GSTa & "_" & DSTa & "_" & Fileres(Boucle2) & "_" & FileProb & ".txt"
                                OutFile(3) = PostFile & "R_CT_" & GSTa & "_" & DSTa & "_" & Fileres(Boucle2) & "_" & FileProb & ".txt"
                                OutFile(4) = PostFile & "R_CL_" & GSTa & "_" & DSTa & "_" & Fileres(Boucle2) & "_" & FileProb & ".txt"
                                OutFile(5) = PostFile & "R_T_" & GSTa & "_" & DSTa & "_" & Fileres(Boucle2) & "_" & FileProb & ".txt"
                                OutFile(6) = PostFile & "R_Carb_" & GSTa & "_" & DSTa & "_" & Fileres(Boucle2) & "_" & FileProb & ".txt"
                                OutFile(7) = PostFile & "R_PH_" & GSTa & "_" & DSTa & "_" & Fileres(Boucle2) & "_" & FileProb & ".txt"
                                nFic1 = CShort(FreeFile())
                                FileOpen(CInt(nFic1), OutFile(1), OpenMode.Output)
                                nFic2 = CShort(FreeFile())
                                FileOpen(CInt(nFic2), OutFile(2), OpenMode.Output)
                                nFic3 = CShort(FreeFile())
                                FileOpen(CInt(nFic3), OutFile(3), OpenMode.Output)
                                nFic4 = CShort(FreeFile())
                                FileOpen(CInt(nFic4), OutFile(4), OpenMode.Output)
                                nFic5 = CShort(FreeFile())
                                FileOpen(CInt(nFic5), OutFile(5), OpenMode.Output)
                                nFic6 = CShort(FreeFile())
                                FileOpen(CInt(nFic6), OutFile(6), OpenMode.Output)
                                nFic7 = CShort(FreeFile())
                                FileOpen(CInt(nFic7), OutFile(7), OpenMode.Output)
                                'nFic8 = CShort(FreeFile())      'prov
                                'Dim File As String = "E:\Dotnet_TransChlor\bin\provisoire.txt"      'prov
                                'FileOpen(CInt(nFic8), File, OpenMode.Output)  'prov
                                'titre des fichiers résultats
                                Print(nFic1, "Humidite_relative_pourcent,", Int(TimeMax * CSng(24) / Hsauv), "_", Dofs + CShort(4), "_", PdTot, ",", TAB)
                                For j = CShort(1) To Dofs
                                    Print(CInt(nFic1), PosProf(j), ",", TAB)
                                Next j
                                PrintLine(CInt(nFic1), "cumul", ",", " ")
                                Print(CInt(nFic1), "0", ",", "0", ",", TAB)
                                For j = CShort(1) To Dofs
                                    Print(CInt(nFic1), H_new(j), ",", TAB)
                                Next j
                                PrintLine(CInt(nFic1), CumH, ", ")
                                Print(CInt(nFic2), "Teneur_en_eau_kg/m3_beton,", Int(TimeMax * CSng(24) / Wsauv), "_", Dofs + CShort(4), "_", PdTot, ",", TAB)
                                'HRCUMUL(cpt2, cpt1) = CumH
                                For j = CShort(1) To Dofs
                                    Print(CInt(nFic2), PosProf(j), ",", TAB)
                                Next j
                                PrintLine(CInt(nFic2), "cumul,", " ")
                                Print(CInt(nFic2), "0", ",", "0", ",", TAB)
                                For j = CShort(1) To Dofs
                                    Print(CInt(nFic2), W(j), ",", TAB)
                                Next j
                                PrintLine(CInt(nFic2), CumW, ", ")
                                Print(CInt(nFic3), "Chlorures_totaux_kg/m3_beton,", Int(TimeMax * CSng(24) / CTsauv), "_", Dofs + CShort(3), "_", PdTot, ",", TAB)
                                For j = CShort(1) To Dofs
                                    Print(CInt(nFic3), PosProf(j), ",", TAB)
                                Next j
                                PrintLine(CInt(nFic3), " ")
                                Print(CInt(nFic3), "0", ",", "0", ",", TAB)
                                For j = CShort(1) To Dofs
                                    Print(CInt(nFic3), CT(j), ",", TAB)
                                Next j
                                PrintLine(CInt(nFic3), " ")
                                If NprobHr = 1 And NprobCap = 1 And NprobCl = 1 Then
                                    Print(CInt(nFic4), "Chlorures_libres_kg/m3_beton,", Int(TimeMax * CSng(24) / CLsauv), "_", Dofs + CShort(3), "_", PdTot, ",", TAB)
                                Else    'avec approche probabiliste
                                    Print(CInt(nFic4), "Chlorures_libres_%masseCiment_beton,", Int(TimeMax * CSng(24) / CLsauv), "_", Dofs + CShort(3), "_", PdTot, ",", TAB)
                                End If
                                For j = CShort(1) To Dofs
                                    Print(CInt(nFic4), PosProf(j), ",", TAB)
                                Next j
                                PrintLine(CInt(nFic4), " ")
                                Print(CInt(nFic4), "0", ",", "0", ",", TAB)
                                If NprobHr = 1 And NprobCap = 1 And NprobCl = 1 Then
                                    For j = CShort(1) To Dofs
                                        Print(CInt(nFic4), C_new(j) * W(j) / 1000, ",", TAB)
                                    Next j
                                Else    'avec approche probabiliste
                                    For j = CShort(1) To Dofs
                                        If nCouches > 1 Then '03.10.2023 début
                                            For k = 1 To nCouches - 1
                                                If PosProf(j) < EpCouches(k) Then
                                                    Print(CInt(nFic4), C_new(j) * W(j) / (10 * ciment(k)), ",", TAB)
                                                    Exit For
                                                ElseIf k = nCouches - 1 Then
                                                    Print(CInt(nFic4), C_new(j) * W(j) / (10 * ciment(nCouches)), ",", TAB)
                                                    Exit For
                                                End If
                                            Next k
                                        Else
                                            Print(CInt(nFic4), C_new(j) * W(j) / (10 * ciment(Boucle2)), ",", TAB)
                                        End If '03.10.2023 fin
                                    Next j
                                End If
                                PrintLine(CInt(nFic4), " ")
                                If NprobHr = 1 And NprobCap = 1 And NprobCl = 1 Then
                                    Print(CInt(nFic5), "Temperature_degre_C,", Int(TimeMax * CSng(24) / Tsauv), "_", Dofs + CShort(3), "_", PdTot, ",", TAB)
                                Else    'avec approche probabiliste
                                    Print(CInt(nFic5), "Temperature_degre_K,", Int(TimeMax * CSng(24) / Tsauv), "_", Dofs + CShort(3), "_", PdTot, ",", TAB)
                                End If
                                For j = CShort(1) To Dofs
                                    Print(CInt(nFic5), PosProf(j), ",", TAB)
                                Next j
                                PrintLine(CInt(nFic5), " ")
                                Print(CInt(nFic5), "0", ",", "0", ",", TAB)
                                If NprobHr = 1 And NprobCap = 1 And NprobCl = 1 Then
                                    For j = CShort(1) To Dofs
                                        Print(CInt(nFic5), T_new(j), ",", TAB)
                                    Next j
                                Else    'avec approche probabiliste
                                    For j = CShort(1) To Dofs
                                        Print(CInt(nFic5), T_new(j) + 273.16, ",", TAB)
                                    Next j
                                End If
                                PrintLine(CInt(nFic5), " ")
                                Print(CInt(nFic6), "Profondeur de carbonatation,", Int(TimeMax * CSng(24) / Carbsauv), "_     5", "_", PdTot, ", 1 , 2", ",", TAB)
                                PrintLine(CInt(nFic6), " ")
                                Print(CInt(nFic6), "0", ",", "0", ",", TAB)
                                Print(CInt(nFic6), "0", ",", "0", ",", TAB)
                                PrintLine(CInt(nFic6), " ")
                                Print(nFic7, "PH,", Int(TimeMax * CSng(24) / Hsauv), "_", Dofs + CShort(3), "_", PdTot, ",", TAB)
                                For j = CShort(1) To Dofs
                                    Print(CInt(nFic7), PosProf(j), ",", TAB)
                                Next j
                                PrintLine(CInt(nFic7), " ")
                                Print(CInt(nFic7), "0", ",", "0", ",", TAB)
                                For j = CShort(1) To Dofs
                                    Print(CInt(nFic7), pPH, ",", TAB)
                                Next j
                                PrintLine(CInt(nFic7), " ")
                                i = CLng(0)
                                Tsec = CLng(0)
                                i_day = 1

                                '''''''''''''''''''''''''''''''''' Résolution par éléments finis - boucle principale
                                Do While i_day >= 0
                                    If i_day > iGco * GNbreEn Then
                                        iG = 1
                                        iGco = iGco + 1
                                    End If
                                    If i_day > iDco * DNbreEn Then
                                        iD = 1
                                        iDco = iDco + 1
                                    End If

                                    If i_day = CShort(1) Then
                                        GTextold = Ctherm(0)
                                        GHextold = Chydr(0)
                                        GCFextold = Cfree(CDec(Cion(0)), CDec(Gamma(0)), W(0))
                                        DTextold = Ctherm(0)
                                        DHextold = Chydr(0)
                                        DCFextold = Cfree(CDec(Cion(0)), CDec(Gamma(0)), W(0))
                                        GTextern = GTemperature(1)
                                        GHextern = GHumidite(1) / CSng(100)
                                        GCFextern = GSel(1) * W(0)
                                        If BDlibre = True Then
                                            DTextern = Ctherm(Dofs)
                                            DHextern = Chydr(Dofs)
                                            DCFextern = Cfree(CDec(Cion(Dofs)), CDec(Gamma(Dofs + 1)), W(Dofs + 1))
                                        Else
                                            DTextern = DTemperature(1)
                                            DHextern = DHumidite(1) / CSng(100)
                                            DCFextern = DSel(1) * W(Dofs + 1)
                                        End If
                                    Else
                                        GTextold = GTextern
                                        GHextold = GHextern
                                        GCFextold = GCFextern
                                        GTextern = GTemperature(iG)
                                        GHextern = GHumidite(iG) / 100  '[%]
                                        GCFextern = GSel(iG) * W(0) 'cF kg/m3 de béton
                                        DTextold = DTextern
                                        DHextold = DHextern
                                        DCFextold = DCFextern
                                        If BDlibre = True Then
                                            DTextern = T_new(Dofs)
                                            DHextern = H_new(Dofs) / 100  '[%]      
                                            DCFextern = C_trial(Dofs) * W(Dofs) / 1000 'kg/m3 de béton
                                            DTextold = DTextern
                                            DHextold = DHextern
                                            DCFextold = DCFextern
                                        Else
                                            DTextern = DTemperature(iD)
                                            DHextern = DHumidite(iD) / 100  '[%]      
                                            DCFextern = DSel(iD) * W(Dofs + 1) 'kg/m3 de béton
                                        End If
                                    End If
                                    If DHextern >= 0.99 And BDlibre = True Then DHextern = 0.9
                                    GCTextern = Cfree(GCFextern, CDec(Gamma(0)), W(0))
                                    GCTextold = Cfree(GCFextold, CDec(Gamma(0)), W(0))
                                    DCTextern = Cfree(DCFextern, CDec(Gamma(Dofs + 1)), W(Dofs + 1))
                                    DCTextold = Cfree(DCFextold, CDec(Gamma(Dofs + 1)), W(Dofs + 1))

                                    ' boundary conditions
Again3:                             If System.Math.Abs(GHextern - GHextold) > dHmax Or System.Math.Abs(DHextern - DHextold) > dHmax Or System.Math.Abs(GTextern - GTextold) > dTmax Or System.Math.Abs(DTextern - DTextold) > dTmax Or System.Math.Abs(GCTextern - GCTextold) > dCTmax Or System.Math.Abs(DCTextern - DCTextold) > dCTmax Or Cond01 > CShort(0) Or System.Math.Abs(GHextern - CSng(H_new(1))) > XdHmax Or System.Math.Abs(DHextern - CSng(H_new(Dofs))) > XdHmax Or System.Math.Abs(GTextern - CSng(T_new(1))) > XdTmax Or System.Math.Abs(DTextern - CSng(T_new(Dofs))) > XdTmax Or System.Math.Abs(GCTextern - CSng(CT(2))) > XdCTmax Or System.Math.Abs(DCTextern - CSng(CT(Dofs - 1))) > XdCTmax Or DeltaT <> FiT Then   ' contrôle le delta h ou si le calcul est déjà dans la boucle
                                        If Cond01 = CShort(0) Then
                                            Cond01 = CShort(1)
                                            Interm(0) = (GHextern - GHextold) / dHmax
                                            Interm(1) = (DHextern - DHextold) / dHmax
                                            Interm(2) = (GTextern - GTextold) / dTmax
                                            Interm(3) = (DTextern - DTextold) / dTmax
                                            Interm(4) = (GCTextern - GCTextold) / dCTmax
                                            Interm(5) = (DCTextern - DCTextold) / dCTmax
                                            Interm(6) = CSng(0)
                                            If System.Math.Abs(GHextern - H_new(1)) > XdHmax Or System.Math.Abs(DHextern - H_new(Dofs)) > XdHmax Or System.Math.Abs(GTextern - CSng(T_new(1))) > XdTmax Or System.Math.Abs(DTextern - CSng(T_new(Dofs))) > XdTmax Or System.Math.Abs(GCTextern - CSng(CT(2))) > XdCTmax Or System.Math.Abs(DCTextern - CSng(CT(Dofs - 1))) > XdCTmax Then Interm(6) = CSng(1)
                                            Interm(7) = FiT / DeltaT
                                            If GHextern > 0.999 Or DHextern > 0.999 Then Interm(8) = 1 ' en cas de capillarité
                                            For j = CShort(0) To CShort(8)
                                                If Interm(j) - Int(Interm(j)) = CSng(0) Then 'calcul le nombre de points intermédiaires
                                                    Interm(j) = System.Math.Abs(Interm(j))
                                                Else
                                                    Interm(j) = Int(System.Math.Abs(Interm(j))) + CSng(1)
                                                End If
                                            Next j
                                            Pinterm = CShort(0)
                                            For j = CShort(0) To CShort(8)
                                                If Interm(j) > CSng(Pinterm) Then Pinterm = CShort(Interm(j))
                                            Next j

                                            If PintermManual > 0 Then Pinterm = PintermManual
                                            'If (GHextern > 0.999 And GHextold < 0.999) Or (DHextern > 0.999 And DHextold < 0.999) Then Pinterm = 1 ' en cas de capillarité

                                            GdelTemp = (GTextern - GTextold) / CSng(Pinterm) 'calcul de delta T
                                            GdelH = (GHextern - GHextold) / CSng(Pinterm) 'calcul de delta H
                                            GdelCF = (GCFextern - GCFextold) / CSng(Pinterm) 'calcul de delta CF
                                            DdelTemp = (DTextern - DTextold) / CSng(Pinterm) 'calcul de delta T
                                            DdelH = (DHextern - DHextold) / CSng(Pinterm) 'calcul de delta H
                                            DdelCF = (DCFextern - DCFextold) / CSng(Pinterm) 'calcul de delta CF
                                            DeltaT = FiT / CSng(Pinterm) 'calcul de delta T
                                        End If
                                        GTextern = GTextold + GdelTemp * CSng(Cond01)
                                        GHextern = GHextold + GdelH * CSng(Cond01)
                                        GCFextern = GCFextold + GdelCF * CSng(Cond01)
                                        DTextern = DTextold + DdelTemp * CSng(Cond01)
                                        DHextern = DHextold + DdelH * CSng(Cond01)
                                        DCFextern = DCFextold + DdelCF * CSng(Cond01)
                                        Tijd = (CDec(i) + CDec(DeltaT) * CDec(Cond01) / CDec(3600)) / CDec(24) 'tijd in days
                                        Cond01 = Cond01 + CShort(1)
                                        If Cond01 > Pinterm Then
                                            Pinterm = CShort(0)
                                            Cond01 = CShort(0)
                                            DeltaT = DelT
                                            'i_hour = i_hour + 1
                                        End If
                                    End If

                                    If Cond01 = CShort(0) Then
                                        Tsec = Tsec + CLng(FiT)
                                        i = Tsec / CLng(3600) ' heures
                                        Tijd = CDec(i) / CDec(24) ' tijd in days
                                    End If

                                    f2 = CDec(DeltaT) / CDec(2.0) ' time integration constant

                                    'transport thermique
                                    ' compose lhs and rhs
                                    'If Tijd > 221.78 Then Stop
Again4:                             For j = CShort(0) To Dofs + CShort(1) ' initialisation
                                        LHS(1, j) = CDec(0.0)
                                        LHS(2, j) = CDec(0.0)
                                        RHS(j) = CDec(0.0)
                                    Next j
                                    For j = CShort(0) To Dofs ' construction de la matrice LHS . h = RHS
                                        f1 = Le(j) / CDec(3.0)
                                        If nCouches > 1 Then '03.10.2023 début
                                            For k = 1 To nCouches - 1
                                                If PosProf(j) < EpCouches(k) Then
                                                    f3 = f2 * MT(qGran(k), capCal, W(j), ciment(k), Hydr(k), T_old(j)) / Le(j)
                                                    If j = CShort(0) Or j = Dofs Then f3 = f3 * CDec(LambdaT(k))
                                                    Exit For
                                                ElseIf k = nCouches - 1 Then
                                                    f3 = f2 * MT(qGran(nCouches), capCal, W(j), ciment(nCouches), Hydr(nCouches), T_old(j)) / Le(j)
                                                    If j = CShort(0) Or j = Dofs Then f3 = f3 * CDec(LambdaT(nCouches))
                                                    Exit For
                                                End If
                                            Next k
                                        Else
                                            f3 = f2 * MT(qGran(Boucle2), capCal, W(j), ciment(Boucle2), Hydr(Boucle2), T_old(j)) / Le(j)
                                            If j = CShort(0) Or j = Dofs Then f3 = f3 * CDec(LambdaT(Boucle2))
                                        End If     '03.10.2023 fin
                                        LHS(1, j) = LHS(1, j) + f1 + f3
                                        LHS(2, j) = LHS(2, j) + f1 / CDec(2.0) - f3
                                        LHS(1, j + CShort(1)) = LHS(1, j + CShort(1)) + f1 + f3
                                        C11 = f1 - f3
                                        C12 = f1 / CDec(2.0) + f3
                                        RHS(j) = RHS(j) + C11 * T_old(j) + C12 * T_old(j + CShort(1))
                                        RHS(j + CShort(1)) = RHS(j + CShort(1)) + C12 * T_old(j) + C11 * T_old(j + CShort(1))
                                    Next j

                                    RHS(0) = CDec(GTextern) 'condition aux limites
                                    LHS(1, 0) = CDec(1.0)
                                    RHS(1) = RHS(1) - LHS(2, 0) * CDec(GTextern)
                                    LHS(2, 0) = CDec(0.0)
                                    'bord 2
                                    If BDlibre = False Then
                                        RHS(Dofs + CShort(1)) = CDec(DTextern)
                                        LHS(1, Dofs + CShort(1)) = CDec(1.0)
                                        RHS(Dofs) = RHS(Dofs) - LHS(2, Dofs) * CDec(DTextern)
                                        LHS(2, Dofs) = CDec(0.0)
                                    End If

                                    ' solve system of equations
                                    For j = CShort(1) To Dofs + CShort(1)
                                        LHS(1, j) = LHS(1, j) - (LHS(2, j - CShort(1)) * LHS(2, j - CShort(1))) / LHS(1, j - CShort(1))
                                        RHS(j) = RHS(j) - RHS(j - CShort(1)) * LHS(2, j - CShort(1)) / LHS(1, j - CShort(1))
                                    Next j
                                    T_trial(Dofs + CShort(1)) = RHS(Dofs + CShort(1)) / LHS(1, Dofs + CShort(1))
                                    For j = Dofs To CShort(0) Step CShort(-1)
                                        T_trial(j) = (RHS(j) - LHS(2, j) * T_trial(j + CShort(1))) / LHS(1, j)
                                    Next j
                                    'check on convergence
                                    test = CDec(0.0)
                                    For j = CShort(0) To Dofs + CShort(1)
                                        If System.Math.Abs(T_trial(j) - T_new(j)) > test Then
                                            test = System.Math.Abs(T_trial(j) - T_new(j))
                                        End If
                                        T_trial(j) = CDec(0.6) * T_new(j) + CDec(0.4) * T_trial(j)
                                        T_new(j) = T_trial(j)
                                    Next j
                                    If test > CDec(testing3) Then GoTo Again4
                                    'update variables
                                    Tleft = 0
                                    Tright = 0
                                    ptest = False

                                    For j = CShort(0) To Dofs + CShort(1)
                                        If j <> Dofs + 1 Then
                                            If System.Math.Abs(T_new(j + 1) - T_new(j)) >= 2 Then
                                                T_new(j) = CDec(GTextern)
                                                T_new(j + 1) = CDec(GTextern)
                                            End If
                                        End If
                                        T_old(j) = T_new(j)
                                        If PosProf(j) < LgLim And j <> 0 And j <> Dofs + 1 Then
                                            Tleft = Tleft + T_new(j) * Le(j)
                                            If PosProf(j + 1) >= LgLim Then Tleft = Tleft + T_new(j + 1) * (LgLim - PosProf(j))
                                        End If
                                        If PosProf(j) > Length - LgLim And j <> Dofs + 1 And BDlibre = False Then
                                            If ptest = False Then
                                                Tright = T_new(j) * (PosProf(j) - Length + LgLim)
                                                ptest = True
                                            Else
                                                Tright = Tright + T_new(j) * Le(j - 1)
                                            End If
                                        End If
                                    Next j
                                    If Tsym = True Then
                                        For j = CShort(0) To CShort((Dofs + 1) / 2)
                                            T_new(j) = (T_new(j) + T_new(Dofs + 1 - j)) / 2
                                            T_new(Dofs + 1 - j) = T_new(j)
                                            T_old(j) = T_new(j)
                                            T_old(Dofs + 1 - j) = T_old(j)
                                        Next j
                                    End If
                                    Tright = Tright / LgLim
                                    Tleft = Tleft / LgLim

                                    'Tranport hydrique
                                    ' compose lhs and rhs
Again1:                             For j = CShort(0) To Dofs + CShort(1) ' initialisation
                                        LHS(0, j) = CDec(0.0)
                                        LHS(1, j) = CDec(0.0)
                                        LHS(2, j) = CDec(0.0)
                                        RHS(j) = CDec(0.0)
                                    Next j
                                    Gcptj = 0
                                    Dcptj = Dofs + 1
                                    For j = 1 To Dofs
                                        If H_trial(j) < H_snap Or Gcptj <> 0 Then
                                            If Gcptj = 0 Then Gcptj = j
                                            If PosProf(j) > PosProf(Gcptj) + 5 Then
                                                Gcptj = j - 1
                                                Exit For
                                            End If
                                        End If
                                        If j = Dofs Then Gcptj = Dofs + 1
                                    Next
                                    If BDlibre = False Then
                                        For j = Dofs To 1 Step -1
                                            If H_trial(j) < H_snap Or Dcptj <> Dofs + 1 Then
                                                If Dcptj = Dofs + 1 Then Dcptj = j
                                                If PosProf(j) < PosProf(Dcptj) - 5 Then
                                                    Dcptj = j + 1
                                                    Exit For
                                                End If
                                            End If
                                            If j = 1 Then Dcptj = 0
                                        Next
                                    End If
                                    'calcul du coefficient de capillarité
                                    If nCouches = 1 Then '03.10.2023 début
                                        parA = 0.0000624775 * EsC(Boucle2) ^ 2 - 0.00010384 * EsC(Boucle2) + 0.0000300346
                                        parA1 = 0.000000278804 * Tleft ^ 3 - 0.00000735523 * Tleft ^ 2 - 0.000278074 * Tleft - 0.012309435
                                        parB1 = -0.000000303977 * Tleft ^ 3 + 0.00000797499 * Tleft ^ 2 + 0.00033679 * Tleft + 0.017793224
                                        parC1 = 0.0000000800226 * Tleft ^ 3 - 0.00000226181 * Tleft ^ 2 - 0.0000897841 * Tleft - 0.004607865
                                        parB = parA1 * EsC(Boucle2) ^ 2 + parB1 * EsC(Boucle2) + parC1
                                        DcapLeft = parA * Hleft * 100 + parB
                                        If DcapLeft < 0.000025 Then DcapLeft = 0.000025
                                        If DcapLeft > 0.009 Then DcapLeft = 0.009
                                        If BDlibre = False Then
                                            parA1 = 0.000000278804 * Tright ^ 3 - 0.00000735523 * Tright ^ 2 - 0.000278074 * Tright - 0.012309435
                                            parB1 = -0.000000303977 * Tright ^ 3 + 0.00000797499 * Tright ^ 2 + 0.00033679 * Tright + 0.017793224
                                            parC1 = 0.0000000800226 * Tright ^ 3 - 0.00000226181 * Tright ^ 2 - 0.0000897841 * Tright - 0.004607865
                                            parB = parA1 * EsC(Boucle2) ^ 2 + parB1 * EsC(Boucle2) + parC1
                                            DcapRight = parA * Hright * 100 + parB
                                            If DcapRight < 0.000025 Then DcapRight = 0.000025
                                            If DcapRight > 0.009 Then DcapRight = 0.009
                                        End If
                                    End If    '03.10.2023 fin

                                    For j = CShort(0) To Dofs ' construction de la matrice LHS . h = RHS
                                        If nCouches > 1 Then '03.10.2023 début
                                            For k = 1 To nCouches - 1
                                                If PosProf(j) < EpCouches(k) Then
                                                    parA = 0.0000624775 * EsC(k) ^ 2 - 0.00010384 * EsC(k) + 0.0000300346
                                                    parA1 = 0.000000278804 * Tleft ^ 3 - 0.00000735523 * Tleft ^ 2 - 0.000278074 * Tleft - 0.012309435
                                                    parB1 = -0.000000303977 * Tleft ^ 3 + 0.00000797499 * Tleft ^ 2 + 0.00033679 * Tleft + 0.017793224
                                                    parC1 = 0.0000000800226 * Tleft ^ 3 - 0.00000226181 * Tleft ^ 2 - 0.0000897841 * Tleft - 0.004607865
                                                    parB = parA1 * EsC(k) ^ 2 + parB1 * EsC(k) + parC1
                                                    DcapLeft = parA * Hleft * 100 + parB
                                                    If DcapLeft < 0.000025 Then DcapLeft = 0.000025
                                                    If DcapLeft > 0.009 Then DcapLeft = 0.009
                                                    If BDlibre = False Then
                                                        parA1 = 0.000000278804 * Tright ^ 3 - 0.00000735523 * Tright ^ 2 - 0.000278074 * Tright - 0.012309435
                                                        parB1 = -0.000000303977 * Tright ^ 3 + 0.00000797499 * Tright ^ 2 + 0.00033679 * Tright + 0.017793224
                                                        parC1 = 0.0000000800226 * Tright ^ 3 - 0.00000226181 * Tright ^ 2 - 0.0000897841 * Tright - 0.004607865
                                                        parB = parA1 * EsC(k) ^ 2 + parB1 * EsC(k) + parC1
                                                        DcapRight = parA * Hright * 100 + parB
                                                        If DcapRight < 0.000025 Then DcapRight = 0.000025
                                                        If DcapRight > 0.009 Then DcapRight = 0.009
                                                    End If
                                                    Ha = (H_old(j) + H_old(j + CShort(1)) + H_trial(j) + H_trial(j + CShort(1))) / CDec(4.0)
                                                    f1 = Le(j) / CDec(3.0)
                                                    f3 = f2 * MDCdiff(Ha, CoefHr(Boucle3), PD(k), Hc, aa, ED(k), ToHydr(k), T_old(j)) / Le(j)
                                                    Exit For
                                                ElseIf k = nCouches - 1 Then
                                                    parA = 0.0000624775 * EsC(nCouches) ^ 2 - 0.00010384 * EsC(nCouches) + 0.0000300346
                                                    parA1 = 0.000000278804 * Tleft ^ 3 - 0.00000735523 * Tleft ^ 2 - 0.000278074 * Tleft - 0.012309435
                                                    parB1 = -0.000000303977 * Tleft ^ 3 + 0.00000797499 * Tleft ^ 2 + 0.00033679 * Tleft + 0.017793224
                                                    parC1 = 0.0000000800226 * Tleft ^ 3 - 0.00000226181 * Tleft ^ 2 - 0.0000897841 * Tleft - 0.004607865
                                                    parB = parA1 * EsC(nCouches) ^ 2 + parB1 * EsC(nCouches) + parC1
                                                    DcapLeft = parA * Hleft * 100 + parB
                                                    If DcapLeft < 0.000025 Then DcapLeft = 0.000025
                                                    If DcapLeft > 0.009 Then DcapLeft = 0.009
                                                    If BDlibre = False Then
                                                        parA1 = 0.000000278804 * Tright ^ 3 - 0.00000735523 * Tright ^ 2 - 0.000278074 * Tright - 0.012309435
                                                        parB1 = -0.000000303977 * Tright ^ 3 + 0.00000797499 * Tright ^ 2 + 0.00033679 * Tright + 0.017793224
                                                        parC1 = 0.0000000800226 * Tright ^ 3 - 0.00000226181 * Tright ^ 2 - 0.0000897841 * Tright - 0.004607865
                                                        parB = parA1 * EsC(nCouches) ^ 2 + parB1 * EsC(nCouches) + parC1
                                                        DcapRight = parA * Hright * 100 + parB
                                                        If DcapRight < 0.000025 Then DcapRight = 0.000025
                                                        If DcapRight > 0.009 Then DcapRight = 0.009
                                                    End If
                                                    Ha = (H_old(j) + H_old(j + CShort(1)) + H_trial(j) + H_trial(j + CShort(1))) / CDec(4.0)
                                                    f1 = Le(j) / CDec(3.0)
                                                    f3 = f2 * MDCdiff(Ha, CoefHr(Boucle3), PD(nCouches), Hc, aa, ED(nCouches), ToHydr(nCouches), T_old(j)) / Le(j)
                                                    Exit For
                                                End If
                                            Next k
                                        End If
                                        If nCouches = 1 Then
                                            Ha = (H_old(j) + H_old(j + CShort(1)) + H_trial(j) + H_trial(j + CShort(1))) / CDec(4.0)
                                            f1 = Le(j) / CDec(3.0)
                                            f3 = f2 * MDCdiff(Ha, CoefHr(Boucle3), PD(Bou2), Hc, aa, ED(Bou2), ToHydr(Bou2), T_old(j)) / Le(j)
                                        End If  '03.10.2023 fin
                                        If j < Gcptj Or j > Dcptj Then
                                            f5 = MDCcap(GHextern, DHextern, CoefCap(Boucle4), DeltaT, tPrec, j, Tijd, tijdOld, True, ab, tc, DcapLeft, DcapRight, BDlibre, PosProf(j), Length, LgLim, ImpHydr) * f2 / CDec(2)
                                        Else
                                            f5 = 0
                                        End If
                                        If j = CShort(0) Or j = Dofs Then
                                            If nCouches > 1 Then '03.10.2023 début
                                                For k = 1 To nCouches - 1
                                                    If PosProf(j) < EpCouches(k) Then
                                                        f3 = f3 * CDec(LambdaH(k))
                                                        f5 = f5 * CDec(LambdaH(k))
                                                        Exit For
                                                    ElseIf k = nCouches - 1 Then
                                                        f3 = f3 * CDec(LambdaH(nCouches))
                                                        f5 = f5 * CDec(LambdaH(nCouches))
                                                        Exit For
                                                    End If
                                                Next k
                                            Else
                                                f3 = f3 * CDec(LambdaH(Boucle2))
                                                f5 = f5 * CDec(LambdaH(Boucle2))
                                            End If     '03.10.2023 fin
                                        End If
                                        LHS(0, j) = LHS(0, j) + f1 / CDec(2.0) - f3 + f5
                                        LHS(1, j) = LHS(1, j) + f1 + f3 - f5
                                        LHS(2, j) = LHS(2, j) + f1 / CDec(2.0) - f3 - f5
                                        LHS(1, j + CShort(1)) = LHS(1, j + CShort(1)) + f1 + f3 + f5
                                        C11 = f1 - f3 + f5
                                        C12 = f1 / CDec(2.0) + f3 - f5
                                        RHS(j) = RHS(j) + C11 * H_old(j) + C12 * H_old(j + CShort(1))
                                        C11 = f1 - f3 - f5
                                        C12 = f1 / CDec(2.0) + f3 + f5
                                        RHS(j + CShort(1)) = RHS(j + CShort(1)) + C12 * H_old(j) + C11 * H_old(j + CShort(1))
                                    Next j

                                    RHS(0) = GHextern 'condition aux limites
                                    LHS(1, 0) = CDec(1.0)
                                    RHS(1) = RHS(1) - LHS(2, 0) * GHextern
                                    LHS(2, 0) = CDec(0.0)
                                    LHS(0, 0) = CDec(0.0)
                                    'bord 2
                                    If BDlibre = False Then
                                        RHS(Dofs + CShort(1)) = CDec(DHextern)
                                        LHS(1, Dofs + CShort(1)) = CDec(1)
                                        RHS(Dofs) = RHS(Dofs) - LHS(0, Dofs) * CDec(DHextern)
                                        LHS(0, Dofs) = CDec(0)
                                        LHS(2, Dofs) = CDec(0)
                                    End If

                                    ' solve system of equations
                                    For j = CShort(1) To Dofs + CShort(1)
                                        LHS(1, j) = LHS(1, j) - (LHS(2, j - CShort(1)) * LHS(0, j - CShort(1))) / LHS(1, j - CShort(1))
                                        RHS(j) = RHS(j) - RHS(j - CShort(1)) * LHS(2, j - CShort(1)) / LHS(1, j - CShort(1))
                                    Next j
                                    H_trial(Dofs + CShort(1)) = RHS(Dofs + CShort(1)) / LHS(1, Dofs + CShort(1))
                                    For j = Dofs To CShort(0) Step CShort(-1)
                                        H_trial(j) = (RHS(j) - LHS(0, j) * H_trial(j + CShort(1))) / LHS(1, j)
                                    Next j
                                    H_trial(0) = CDec(GHextern)
                                    If GHextern > CSng(0.999) Then H_trial(1) = CDec(1) 'court-circuit en cas capillarité
                                    If BDlibre = False Then
                                        H_trial(Dofs + CShort(1)) = CDec(DHextern)
                                        If DHextern > CSng(0.999) Then H_trial(Dofs) = CDec(1)
                                    End If
                                    'check on convergence
                                    test = CDec(0.0)
                                    For j = 0 To Dofs + CShort(1)
                                        If System.Math.Abs(H_trial(j) - H_new(j)) > test Then
                                            test = System.Math.Abs(H_trial(j) - H_new(j))
                                        End If
                                        H_trial(j) = CDec(0.6) * H_new(j) + CDec(0.4) * H_trial(j)
                                        H_new(j) = H_trial(j)
                                    Next j
                                    H_new(0) = CDec(GHextern)
                                    If BDlibre = False Then H_new(Dofs + CShort(1)) = CDec(DHextern)
                                    If GHextern > CSng(0.999) Then H_new(1) = CDec(1) 'court-circuit en cas capillarité
                                    If BDlibre = False Then If DHextern > CSng(0.999) Then H_new(Dofs) = CDec(1)
                                    If testOld <= test Then test = testing1 / 10 'en cas de non convergence
                                    testOld = test
                                    If test > CDec(testing1) Then GoTo Again1
                                    'update variables
                                    TW = True
                                    Hleft = 0
                                    Hright = 0
                                    ptest = False
                                    For j = CShort(0) To Dofs + CShort(1)
                                        If H_new(j) > CDec(1) Then H_new(j) = CDec(1) 'problème numérique
                                        If H_new(j) < CDec(0) Then H_new(j) = CDec(0)
                                        If i_day = 1 Then W_old(j) = W(j)
                                        If nCouches > 1 Then '03.10.2023 début
                                            For k = 1 To nCouches - 1
                                                If PosProf(j) < EpCouches(k) Then
                                                    W(j) = Water(H_new(j), HAncien(j), T_new(j), Tijd, tProt(k), Vct(k), Nct(k), EC(k), SAT(k), Hydr(k), ciment(k), Wol)
                                                    If W(j) < 0 Or W(j) > SAT(k) Then W(j) = SAT(k) * H_new(j)
                                                    Exit For
                                                ElseIf k = nCouches - 1 Then
                                                    W(j) = Water(H_new(j), HAncien(j), T_new(j), Tijd, tProt(nCouches), Vct(nCouches), Nct(nCouches), EC(nCouches), SAT(nCouches), Hydr(nCouches), ciment(nCouches), Wol)
                                                    If W(j) < 0 Or W(j) > SAT(nCouches) Then W(j) = SAT(nCouches) * H_new(j)
                                                    Exit For
                                                End If
                                            Next k
                                        Else
                                            W(j) = Water(H_new(j), HAncien(j), T_new(j), Tijd, tProt(Boucle2), Vct(Boucle2), Nct(Boucle2), EC(Boucle2), SAT(Boucle2), Hydr(Boucle2), ciment(Boucle2), Wol)
                                            If W(j) < 0 Or W(j) > SAT(Boucle2) Then W(j) = SAT(Boucle2) * H_new(j)
                                        End If          '03.10.2023 fin
                                        If j >= Dofs / 3 And j <= 2 * Dofs / 3 And System.Math.Abs(W_old(j) - W(j)) < 5 Then TW = False
                                        If Cond01 = 0 Then HAncien(j) = H_new(j)
                                        If PosProf(j) < LgLim And j <> 0 And j <> Dofs + 1 Then
                                            Hleft = Hleft + H_new(j) * Le(j)
                                            If PosProf(j + 1) >= LgLim Then Hleft = Hleft + H_new(j + 1) * (LgLim - PosProf(j))
                                        End If
                                        If PosProf(j) > Length - LgLim And j <> Dofs + 1 And BDlibre = False Then
                                            If ptest = False Then
                                                Hright = H_new(j) * (PosProf(j) - Length + LgLim)
                                                ptest = True
                                            Else
                                                Hright = Hright + H_new(j) * Le(j - 1)
                                            End If
                                        End If
                                    Next j

                                    Hright = Hright / LgLim
                                    Hleft = Hleft / LgLim

                                    If Hsym = True Then
                                        For j = CShort(0) To CShort((Dofs + 1) / 2)
                                            H_new(j) = (H_new(j) + H_new(Dofs + 1 - j)) / 2
                                            H_new(Dofs + 1 - j) = H_new(j)
                                            H_old(j) = H_new(j)
                                            H_old(Dofs + 1 - j) = H_old(j)
                                        Next j
                                    End If
                                    If TW = True Then
                                        For j = CShort(2) To Dofs - CShort(1)
                                            W(j) = W_old(j) + (W(j) - W_old(j)) / (DeltaT / 36)
                                            If nCouches > 1 Then '03.10.2023 début
                                                For k = 1 To nCouches - 1
                                                    If PosProf(j) < EpCouches(k) Then
                                                        If W(j) < 0 Or W(j) > SAT(k) Then W(j) = SAT(k) * H_new(j)
                                                        Exit For
                                                    ElseIf k = nCouches - 1 Then
                                                        If W(j) < 0 Or W(j) > SAT(nCouches) Then W(j) = SAT(nCouches) * H_new(j)
                                                        Exit For
                                                    End If
                                                Next k
                                            Else
                                                If W(j) < 0 Or W(j) > SAT(Boucle2) Then W(j) = SAT(Boucle2) * H_new(j)
                                            End If    '03.10.2023 fin
                                        Next
                                    End If
                                    CumW = CDec(0)
                                    CumH = CDec(0)
                                    For j = CShort(1) To Dofs - CShort(1)
                                        CumH = CumH + (H_new(j) + H_new(j + 1)) * Le(j) / 2
                                        CumW = CumW + Le(j) * (W(j) + W(j + 1)) / CDec(2)
                                        W_old(j) = W(j)
                                    Next j
                                    W_old(0) = W(0)
                                    W_old(Dofs) = W(Dofs)
                                    W_old(Dofs + 1) = W(Dofs + 1)
                                    CumH = CumH / CDec(Length)
                                    CumW = CumW / CDec(Length)

                                    'carbonatation----------------------------------------------- 03.10.2023 on ne prend pas en considération le multicouche dans la carbonatation
                                    GRHe = GRHe + GHextern * (DeltaT / (3600 * 24))
                                    If BDlibre = False Then DRHe = DRHe + DHextern * (DeltaT / (3600 * 24))
                                    CumTemps = CumTemps + (DeltaT / (3600 * 24))
                                    If BDlibre = True Then
                                        Dxc = 0
                                    Else
                                        Dxc = 2.8 * ((RoC(Boucle2) / RoW) * ((EC(Boucle2) - 0.3) / (1 + (RoC(Boucle2) / RoW) * EC(Boucle2))) * (1 - DRHe / CumTemps)) ^ 2 * CoefCa(Boucle2)
                                        Dxc = ((1 + (RoC(Boucle2) / RoW) * EC(Boucle2) + RoC(Boucle2) * qGran(Boucle2) / (RoA(Boucle2) * ciment(Boucle2))) * DyCO2 * Tijd * Dxc * 24 * 3600 / 100) ^ 0.5 / 28
                                    End If
                                    Gxc = 2.8 * ((RoC(Boucle2) / RoW) * ((EC(Boucle2) - 0.3) / (1 + (RoC(Boucle2) / RoW) * EC(Boucle2))) * (1 - GRHe / CumTemps)) ^ 2 * CoefCa(Boucle2)
                                    Gxc = ((1 + (RoC(Boucle2) / RoW) * EC(Boucle2) + RoC(Boucle2) * qGran(Boucle2) / (RoA(Boucle2) * ciment(Boucle2))) * GyCO2 * Tijd * Gxc * 24 * 3600 / 100) ^ 0.5 / 28
                                    If Gxc < Gxcold Then Gxc = Gxcold
                                    If Dxc < Dxcold Then Dxc = Dxcold
                                    Gxcold = Gxc
                                    Dxcold = Dxc
                                    'Gxc = Gxc * 1000
                                    'Dxc = Dxc * 1000
                                    For j = CShort(1) To Dofs
                                        If PosProf(j) <= 1.12 + Gxc Then
                                            GPH = pPH * (mPh / pPH + (1 - mPh / pPH) / (1 + ((1 - (PosProf(j) - Gxc + 2.88) / 4) / (1 - 0.5)) ^ 4))
                                        Else
                                            GPH = pPH
                                        End If
                                        If BDlibre = True Then
                                            DPH = pPH
                                        Else
                                            If Length - PosProf(j) <= 1.12 + Dxc Then
                                                DPH = pPH * (mPh / pPH + (1 - mPh / pPH) / (1 + ((1 - (Length - PosProf(j) - Dxc + 2.88) / 4) / (1 - 0.5)) ^ 4))
                                            Else
                                                DPH = pPH
                                            End If
                                        End If
                                        Ph(j) = GPH
                                        If GPH > DPH Then Ph(j) = DPH
                                        Gamma(j) = System.Math.Exp(aOH * (1 - 10 ^ (Ph(j) - pPH))) * System.Math.Exp(EbG / R * (1 / (273.16 + T_new(j)) - 1 / toG)) * ciment(Boucle2) * Hydr(Boucle2) * faG / 1000
                                    Next

                                    'next the chlorides ------------------------------------------
                                    ' first the convection part (flow)
                                    ' water flow
                                    testOld = 100
                                    For j = CShort(0) To Dofs + 1
                                        Speed(j) = CDec(0.0) 'initialisation
                                    Next j
                                    If GHextern > 0.9999 Or DHextern > 0.9999 Then
                                        Gctj = Dofs
                                        For j = 1 To Dofs
                                            If H_new(j + 1) >= H_new(j) And Gctj = Dofs Then Gctj = j
                                            If PosProf(j) > PosProf(Gcptj) + 5 Then
                                                Gctj = j - 1
                                                Exit For
                                            End If
                                        Next
                                        If Gctj < Gcptj Then Gcptj = Gctj
                                        If BDlibre = False Then
                                            Dctj = 1
                                            For j = Dofs To 1 Step -1
                                                If H_new(j - 1) >= H_new(j) And Dcptj = 1 Then Dctj = j
                                                If PosProf(j) < PosProf(Dctj) - 5 Then
                                                    Dctj = j + 1
                                                    Exit For
                                                End If
                                            Next
                                            If Dctj > Dcptj Then Dcptj = Dctj
                                        End If
                                    End If
                                    For j = CShort(0) To Dofs       'vitesse par la diffusion de vapeur d'eau seule
                                        If nCouches > 1 Then '03.10.2023 début
                                            For k = 1 To nCouches - 1
                                                If PosProf(j) < EpCouches(k) Then
                                                    Ae(j) = -MDCdiff(H_old(j), CoefHr(Boucle3), PD(k), Hc, aa, ED(k), ToHydr(k), T_old(j)) * (H_old(j + CShort(1)) - H_old(j)) / CDec(2.0)
                                                    Exit For
                                                ElseIf k = nCouches - 1 Then
                                                    Ae(j) = -MDCdiff(H_old(j), CoefHr(Boucle3), PD(nCouches), Hc, aa, ED(nCouches), ToHydr(nCouches), T_old(j)) * (H_old(j + CShort(1)) - H_old(j)) / CDec(2.0)
                                                    Exit For
                                                End If
                                            Next k
                                        Else
                                            Ae(j) = -MDCdiff(H_old(j), CoefHr(Boucle3), PD(Bou2), Hc, aa, ED(Bou2), ToHydr(Bou2), T_old(j)) * (H_old(j + CShort(1)) - H_old(j)) / CDec(2.0)
                                        End If    '03.10.2023 fin
                                    Next
                                    For j = CShort(0) To Dofs
                                        If Ae(j) > 0 And (j < Gcptj Or j > Dcptj) Then      'prise en compte de la capillarité
                                            Be(j) = MDCcap(GHextern, DHextern, CoefCap(Boucle4), DeltaT, tPrec, j, Tijd, tijdOld, False, ab, tc, DcapLeft, DcapRight, BDlibre, PosProf(j), Length, LgLim, ImpHydr)
                                        ElseIf Ae(j) < 0 And (j < Gcptj Or j > Dcptj) Then
                                            Be(j) = -MDCcap(GHextern, DHextern, CoefCap(Boucle4), DeltaT, tPrec, j, Tijd, tijdOld, False, ab, tc, DcapLeft, DcapRight, BDlibre, PosProf(j), Length, LgLim, ImpHydr)
                                        Else
                                            Be(j) = 0
                                        End If
                                        If Ae(j) = 0 Then Be(j) = 0
                                    Next j
                                    Speed(0) = Ae(0) + Be(0)
                                    Speed(Dofs + 1) = Ae(Dofs) + Be(Dofs)
                                    For j = CShort(1) To Dofs   'assemblage, vitesse sur chaque noeud
                                        Speed(j) = Ae(j - 1) + Ae(j) + Be(j - 1) + Be(j)
                                    Next

                                    'use speed to compute the fictive position of the nodes
                                    PosProf(Dofs + 1) = Length
                                    For j = CShort(0) To Dofs + 1
                                        H_old(j) = H_new(j)
                                        Speed(j) = PosProf(j) + CDec(Retard) * Speed(j) * CDec(DeltaT) 'déplacement des noeuds transformation de la vitesse en distance
                                        If Speed(j) <= 0.0# Then Speed(j) = 0.0# 'les cl- ne peuvent pas sortir
                                        If Speed(j) >= Length Then Speed(j) = Length 'les cl- ne peuvent pas sortir
                                    Next j

                                    ' compute the convective state
                                    ' boundary
                                    Gamma(0) = Gamma(1)
                                    Gamma(Dofs + 1) = Gamma(Dofs)
                                    CT(0) = 0
                                    CT(Dofs + 1) = 0
                                    For j = 0 To Dofs + 1
                                        Ae(j) = 0
                                        Be(j) = 0
                                    Next
                                    For j = 0 To Dofs   'calcul des surfaces trapézoidales
                                        Ae(j) = Ae(j) + (C_trial(j) * 3 + C_trial(j + 1)) * Le(j) / 8
                                        Ae(j + 1) = (C_trial(j) + C_trial(j + 1) * 3) * Le(j) / 8
                                    Next

                                    Ae(1) = Ae(1) + Ae(0)
                                    Ae(Dofs) = Ae(Dofs) + Ae(Dofs + 1)
                                    SingVal = False
                                    For j = 0 To Dofs + CShort(1)     'calcul des réactions d'appui sur les noeuds
                                        Nbn = 0
                                        Ltot = 0
                                        If PosProf(j) > Speed(j) Then
                                            For jj = 0 To Dofs + 1
                                                If PosProf(jj) >= Speed(j) And jj <> 0 Then
                                                    Nbn = Nbn + 1
                                                    Ltot = Ltot + Le(jj - 1)
                                                    If PosProf(jj) = PosProf(j) Then Exit For
                                                End If
                                            Next
                                            Be(j - Nbn) = Be(j - Nbn) + (PosProf(j - Nbn + 1) - Speed(j)) * Ae(j) / Ltot
                                            Be(j - Nbn + 1) = Be(j - Nbn + 1) + (Speed(j) - PosProf(j - Nbn)) * Ae(j) / Ltot
                                            For jj = j - Nbn + 1 To j - 1
                                                Be(jj) = Be(jj) + Ae(j) * Le(jj) / (Ltot * 2)
                                                Be(jj + 1) = Be(jj + 1) + Ae(j) * Le(jj) / (Ltot * 2)
                                            Next
                                        ElseIf PosProf(j) < Speed(j) Then
                                            For jj = 0 To Dofs + 1
                                                If PosProf(jj) > PosProf(j) Then
                                                    Nbn = Nbn + 1
                                                    Ltot = Ltot + Le(jj - 1)
                                                    If PosProf(jj) > Speed(j) Then Exit For
                                                End If
                                            Next
                                            For jj = j To j + Nbn - 2
                                                Be(jj) = Be(jj) + Ae(j) * Le(jj) / (Ltot * 2)
                                                Be(jj + 1) = Be(jj + 1) + Ae(j) * Le(jj) / (Ltot * 2)
                                            Next
                                            Be(j + Nbn - 1) = Be(j + Nbn - 1) + (PosProf(j + Nbn) - Speed(j)) * Ae(j) / Ltot
                                            Be(j + Nbn) = Be(j + Nbn) + (Speed(j) - PosProf(j + Nbn - 1)) * Ae(j) / Ltot
                                        Else
                                            Be(j) = Be(j) + Ae(j)
                                        End If
                                        If j <> 0 Then
                                            If Be(j - 1) <> Be(j) And SingVal = False Then SingVal = True
                                        End If
                                    Next

                                    'next the diffusion part
                                    If SingVal = False Then
                                        Nbn = 2
                                    Else
                                        Nbn = 1
                                    End If
                                    For jj = Nbn To 2
Again2:                                 If jj = 1 Then
                                            DB = 0
                                            CB = 1
                                        End If
                                        If jj = 2 Then
                                            DB = 1
                                            CB = 0
                                        End If
                                        For j = CShort(0) To Dofs + CShort(1) 'initialisation
                                            LHS(1, j) = CDec(0.0)
                                            LHS(2, j) = CDec(0.0)
                                            RHS(j) = CDec(0.0)
                                        Next j
                                        For j = CShort(1) To Dofs - CShort(1)
                                            Ha = (W(j) + W(j + CShort(1))) / CDec(2000.0)
                                            If C_trial(j) < 0.01 Then
                                                Mcap = Ha + CDec(Gamma(j) * 0.01 ^ (-0.621))
                                            Else
                                                Mcap = Ha + CDec(Gamma(j) * C_trial(j) ^ (-0.621))
                                            End If
                                            f1 = Mcap * Le(j) / CDec(3.0)
                                            If nCouches > 1 Then '03.10.2023 début
                                                For k = 1 To nCouches - 1
                                                    If PosProf(j) < EpCouches(k) Then
                                                        f3 = f2 * Ha * MDCl(Dcl(k), Ecl(k), ToCl(k), T_old(j), CoefCl(Boucle5)) / Le(j)
                                                        Exit For
                                                    ElseIf k = nCouches - 1 Then
                                                        f3 = f2 * Ha * MDCl(Dcl(nCouches), Ecl(nCouches), ToCl(nCouches), T_old(j), CoefCl(Boucle5)) / Le(j)
                                                        Exit For
                                                    End If
                                                Next k
                                            Else
                                                f3 = f2 * Ha * MDCl(Dcl(Bou2), Ecl(Bou2), ToCl(Bou2), T_old(j), CoefCl(Boucle5)) / Le(j)
                                            End If
                                            LHS(1, j) = LHS(1, j) + (f1 + f3) * DB + 3 * Le(j) * CB
                                            LHS(2, j) = LHS(2, j) + (f1 / CDec(2.0) - f3) * DB + Le(j) * CB
                                            LHS(1, j + CShort(1)) = LHS(1, j + CShort(1)) + (f1 + f3) * DB + 3 * Le(j) * CB
                                            C11 = f1 - f3
                                            C12 = f1 / CDec(2.0) + f3
                                            RHS(j) = RHS(j) + (C11 * C_old(j) + C12 * C_old(j + CShort(1))) * DB + 8 * Be(j) * CB
                                            RHS(j + CShort(1)) = RHS(j + CShort(1)) + (C12 * C_old(j) + C11 * C_old(j + CShort(1))) * DB
                                        Next j

                                        ' IMPOSE boundary condition
                                        If W(0) = 0 Then W(0) = W(1)
                                        GCboundary = GCFextern * 1000 / W(0)
                                        If BDlibre = False Then
                                            If W(Dofs + 1) = 0 Then W(Dofs + 1) = W(Dofs)
                                            DCboundary = DCFextern * 1000 / W(Dofs + 1)
                                        End If

                                        RHS(1) = GCboundary
                                        LHS(1, 1) = CDec(1.0)
                                        RHS(2) = RHS(2) - LHS(2, 1) * RHS(1)
                                        LHS(2, 1) = CDec(0.0)

                                        If BDlibre = False Then
                                            RHS(Dofs) = DCboundary
                                            LHS(1, Dofs) = CDec(1.0)
                                            RHS(Dofs - CShort(1)) = RHS(Dofs - CShort(1)) - LHS(2, Dofs - CShort(1)) * RHS(Dofs)
                                            LHS(2, Dofs - CShort(1)) = CDec(0.0)
                                        End If

                                        ' solve system of equations
                                        For j = CShort(2) To Dofs
                                            LHS(1, j) = LHS(1, j) - (LHS(2, j - CShort(1)) * LHS(2, j - CShort(1))) / LHS(1, j - CShort(1))
                                            RHS(j) = RHS(j) - RHS(j - CShort(1)) * LHS(2, j - CShort(1)) / LHS(1, j - CShort(1))
                                        Next j
                                        C_trial(Dofs) = RHS(Dofs) / LHS(1, Dofs)
                                        For j = Dofs - CShort(1) To CShort(1) Step CShort(-1)
                                            C_trial(j) = (RHS(j) - LHS(2, j) * C_trial(j + CShort(1))) / LHS(1, j)
                                        Next j
                                        For j = 0 To Dofs + 1
                                            If C_trial(j) < 0 Then C_trial(j) = 0
                                            If C_trial(j) > Msel * 1000 / W(j) Then C_trial(j) = Msel * 1000 / W(j)
                                        Next
                                        'check on convergence
                                        test = 0
                                        For j = CShort(0) To Dofs + CShort(1)
                                            If System.Math.Abs(C_trial(j) - C_new(j)) > test Then test = System.Math.Abs(C_trial(j) - C_new(j))
                                            C_trial(j) = 0.6 * C_new(j) + 0.4 * C_trial(j)
                                            C_new(j) = C_trial(j)
                                        Next j
                                        If testOld <= test Then test = testing2 / 10 'en cas de non convergence
                                        testOld = test
                                        If test > testing2 Then GoTo Again2
                                        testOld = 100
                                        If jj = 1 Then      'calcul des ions chlorures liées après l'entraînement des ions par l'eau
                                            For j = CShort(0) To Dofs + CShort(1)
                                                If C_trial(j) < 0 Then C_trial(j) = (C_trial(j - 1) + C_trial(j + 1)) / 2 'correction pour des problèmes numériques
                                                If C_trial(j) < 0 Then C_trial(j) = 0
                                                CBo(j) = Gamma(j) * C_trial(j) ^ 0.379
                                                If CT(j) = 0 Then
                                                    CT(j) = C_trial(j) * W(j) / 1000
                                                    C_trial(j) = CT(j) - CBo(j)
                                                    If C_trial(j) < 0 Then C_trial(j) = 0
                                                Else
                                                    CT(j) = C_trial(j) * W(j) / 1000 + Gamma(j) * C_trial(j) ^ 0.379
                                                End If
                                                C_new(j) = C_trial(j)
                                                C_old(j) = C_trial(j)
                                            Next
                                        End If
                                    Next
                                    'update variables
                                    SingVal = False         'traitement des valeurs singulières
                                    For j = CShort(1) To Dofs
                                        If C_new(j) < 0 Then C_new(j) = (C_new(j - 1) + C_new(j + 1)) / 2
                                        If C_new(j) > Msel * 1000 / W(j) Then C_new(j) = Msel * 1000 / W(j)
                                        If C_new(j) < 0 Then C_new(j) = 0
                                        C_trial(j) = C_new(j)
                                        CT(j) = C_new(j) * W(j) / 1000 + Gamma(j) * C_new(j) ^ 0.379 'kg/m3 de béton 
                                        If CTmax < CT(j) Then CTmax = CT(j)
                                        If CLmax < C_new(j) * W(j) / 1000.0# Then CLmax = C_new(j) * W(j) / 1000.0#
                                    Next j
                                    If CDbl(CTmold) < CTmax Then
                                        CTmax = CInt(CTmax) + 1
                                        CTmold = CTmax
                                    End If
                                    If CLmold < CLmax Then
                                        CLmax = CInt(CLmax) + 1
                                        CLmold = CLmax
                                    End If
                                    If Ssym = True Then
                                        For j = CShort(0) To CShort((Dofs + 1) / 2)
                                            C_new(j) = (C_new(j) + C_new(Dofs + 1 - j)) / 2
                                            C_new(Dofs + 1 - j) = C_new(j)
                                            C_old(j) = C_new(j)
                                            C_old(Dofs + 1 - j) = C_old(j)
                                        Next j
                                    End If
                                    If BDlibre = True Then  'problème numérique sur le deuxième bord
                                        Ctest = Msel * 1000 / W(1)
                                        For j = Dofs To CShort(1) Step -1
                                            If System.Math.Abs(C_new(j) - C_new(j - 1)) >= Ctest / 4 Then
                                                Ctest = System.Math.Abs(C_new(j) - C_new(j - 1))
                                                C_new(j) = C_new(j + 1)
                                                CT(j) = C_new(j) * W(j) / 1000 + Gamma(j) * C_new(j) ^ 0.379 'kg/m3 de béton
                                            Else
                                                Exit For
                                            End If
                                        Next
                                    End If

                                    ''______________________ 'pour le programme 

                                    'If Tijd = 0.25 Then '1 an ou 365 jours
                                    '    Hteller = Hteller + CDbl(Hsauv)
                                    '    Register(nFic1, Tijd, Dofs, H_new)
                                    '    PrintLine(nFic1, " ")
                                    '    Wteller = Wteller + CDbl(Wsauv)
                                    '    Register(nFic2, Tijd, Dofs, W)
                                    '    PrintLine(nFic2, CumW, ", ")
                                    '    CTteller = CTteller + CDbl(CTsauv)
                                    '    Register(nFic3, Tijd, Dofs, CT)
                                    '    PrintLine(nFic3, " ")
                                    '    CLteller = CLteller + CDbl(CLsauv)
                                    '    Regist01(nFic4, Tijd, Dofs, C_new, W)
                                    '    PrintLine(nFic4, " ")
                                    '    Tteller = Tteller + CDbl(Tsauv)
                                    '    Register(nFic5, Tijd, Dofs, T_new)
                                    '    PrintLine(nFic5, " ")
                                    '    Carbteller = Carbteller + CDbl(Carbsauv)
                                    '    Print(CInt(nFic6), Tijd / 365, ",", Tijd, ",", Gxc, ",", Dxc, ",", TAB)
                                    '    PrintLine(nFic6, " ")
                                    '    Register(nFic7, Tijd, Dofs, Ph)
                                    '    PrintLine(nFic7, " ")
                                    'End If
                                    ''______________________

                                    t1 = CSng(0.00001)
                                    t2 = CSng(Tijd) + DeltaT / CSng(3600) / CSng(24)
                                    If Cond01 > CShort(0) Then GoTo Again3 'delta T intermédiaire

                                    If i >= CLng(affiche) Then  '1 mois ou 30 jours
                                        affiche = affiche + CDbl(taff)
                                        'Update the pictures
                                        frm.design(Wsat, H_old, W, T_old, C_new, CT, TempMin, TempMax, Length, PosProf, hMin, hEcart, wMin, wEcart, CTmin, CTecart, CTmax, CLmin, CLecart, CLmax, Tecart, Dofs, Tijd, Gxc, Dxc, Ph)
                                    End If
                                    If i >= CLng(Hteller) Then '1 an ou 365 jours
                                        Hteller = Hteller + CDbl(Hsauv)
                                        Register(nFic1, Tijd, Dofs, H_new, 0)
                                        PrintLine(nFic1, CumH, ", ")
                                        'HRCUMUL(cpt2, cpt1) = CumH
                                        'cpt2 = cpt2 + 1
                                    End If
                                    If i >= CLng(Wteller) Then '1 an ou 365 jours
                                        Wteller = Wteller + CDbl(Wsauv)
                                        Register(nFic2, Tijd, Dofs, W, 0)
                                        PrintLine(nFic2, CumW, ", ")
                                    End If
                                    If i >= CLng(CTteller) Then '1 an ou 365 jours
                                        CTteller = CTteller + CDbl(CTsauv)
                                        Register(nFic3, Tijd, Dofs, CT, 0)
                                        PrintLine(nFic3, " ")
                                        'PrintLine(nFic8, CumClT)        'prov
                                    End If
                                    If i >= CLng(CLteller) Then '1 an ou 365 jours
                                        CLteller = CLteller + CDbl(CLsauv)
                                        Regist01(nFic4, Tijd, Dofs, C_new, W, ciment, NprobHr + NprobCap + NprobCl, nCouches, EpCouches, Boucle2)   '03.10.2023 changement ciment(Boucle2) par ciment
                                        PrintLine(nFic4, " ")
                                    End If
                                    If i >= CLng(Tteller) Then '1 an ou 365 jours
                                        Tteller = Tteller + CDbl(Tsauv)
                                        If NprobHr = 1 And NprobCap = 1 And NprobCl = 1 Then
                                            Register(nFic5, Tijd, Dofs, T_new, 0)
                                        Else        'si approche probabiliste
                                            Register(nFic5, Tijd, Dofs, T_new, 273.16)
                                        End If
                                        PrintLine(nFic5, " ")
                                    End If
                                    If i >= CLng(Carbteller) Then '1 an ou 365 jours
                                        Carbteller = Carbteller + CDbl(Carbsauv)
                                        Print(CInt(nFic6), Tijd / 365, ",", Tijd, ",", Gxc, ",", Dxc, ",", TAB)
                                        PrintLine(nFic6, " ")
                                        Register(nFic7, Tijd, Dofs, Ph, 0)
                                        PrintLine(nFic7, " ")
                                    End If
                                    System.Windows.Forms.Application.DoEvents()
                                    If Tijd >= CDec(TimeMax) Then Exit Do
                                    iG = iG + 1
                                    iD = iD + 1
                                    i_day = i_day + 1
                                Loop

                                FileClose(CInt(nFic1))
                                FileClose(CInt(nFic2))
                                FileClose(CInt(nFic3))
                                FileClose(CInt(nFic4))
                                FileClose(CInt(nFic5))
                                FileClose(CInt(nFic6))
                                FileClose(CInt(nFic7))
                                'FileClose(CInt(nFic8))      'prov
                            Next Boucle6
                        Next Boucle5
                    Next Boucle4
                Next Boucle3
            Next Boucle2
BreakBoucle1:
        Next Boucle1

        'programmation pour obtenir des fichiers de comparaison (provisoire)
        'For j = 0 To cpt2 - 1
        '    If j = 0 Then
        '        For i = 1 To cpt1
        '            Print(CInt(nFile), i, ",", TAB)
        '        Next
        '        PrintLine(CInt(nFile), "")
        '    End If
        '    For i = 1 To cpt1
        '        Print(CInt(nFile), HRCUMUL(j, i), ",", TAB)
        '    Next
        '    PrintLine(CInt(nFile), "")
        'Next
        'FileClose(CInt(nFile))

        MsgBox("Fin du calcul", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "Fin")

        frm.ModifyCommand1(False)
        'frm02.Command1..Enabled = False

    End Sub

    'Enregistrement des données dans les fichiers d'output
    Private Sub Register(ByRef nFic1 As Short, ByRef Tijd As Decimal, ByRef Dofs As Short, ByRef H_new() As Decimal, ByRef para As Single)

        Dim j As Short
        'Register values
        Print(CInt(nFic1), Tijd / 365, ",", Tijd, ",", TAB)
        For j = CShort(1) To Dofs
            Print(CInt(nFic1), H_new(j) + para, ",", TAB) '% humidité relative dans le béton
        Next j

    End Sub

    'Enregistrement des données dans le fichier d'output pour l'humidité relative
    Private Sub Regist01(ByRef nFic1 As Short, ByRef Tijd As Decimal, ByRef Dofs As Short, ByRef CL_new() As Decimal, ByRef W() As Decimal, ByRef Ciment() As Single, ByRef Para As Short, ByRef nCouches As Integer, ByRef EpCouches() As Double, ByRef Boucle2 As Short)

        Dim j As Short
        Dim k As Short
        Dim Cim As Single

        'Register values
        Print(CInt(nFic1), Tijd / 365, ",", Tijd, ",", TAB)
        For j = CShort(1) To Dofs
            If nCouches > 1 Then '03.10.2023 début
                For k = 1 To nCouches - 1
                    If PosProf(j) < EpCouches(k) Then
                        Cim = Ciment(k)
                        Exit For
                    ElseIf k = nCouches - 1 Then
                        Cim = Ciment(nCouches)
                        Exit For
                    End If
                Next k
            Else
                Cim = Ciment(Boucle2)
            End If          '03.10.2023 fin
            If Para = 3 Then
                Print(CInt(nFic1), CL_new(j) * W(j) / 1000, ",", TAB)
            Else        'avec traitement probabiliste
                Print(CInt(nFic1), CL_new(j) * W(j) / (10 * Cim), ",", TAB)
            End If
        Next j

    End Sub

End Class
