Imports System.Linq

Public Class OutputFile2D

    Dim NbFiles As Single
    Dim outfile() As String
    Dim nFic() As Short

    Public Sub New(ByRef directory As String, ByRef NbFiles As Single, ByRef nDof As Integer, ByRef Model As Integer)

        ReDim outfile(NbFiles - 1)
        ReDim nFic(NbFiles - 1)

        If Model = 0 Then
            ''Creating output .txt computation result file 2020-07-17 Xuande 
            outfile(0) = directory & "\" & "R_H_DiffusionModel" & ".txt"
            outfile(1) = directory & "\" & "R_W_DiffusionModel" & ".txt"
            outfile(2) = directory & "\" & "R_S_DiffusionModel" & ".txt"
            outfile(3) = directory & "\" & "R_T_DiffusionModel" & ".txt"
            outfile(4) = directory & "\" & "R_Na_DiffusionModel" & ".txt" '2021.09.03 Xuande
            outfile(5) = directory & "\" & "R_Cl_DiffusionModel" & ".txt"
            outfile(6) = directory & "\" & "R_K_DiffusionModel" & ".txt"
            outfile(7) = directory & "\" & "R_OH_DiffusionModel" & ".txt"
            outfile(8) = directory & "\" & "R_Ca_DiffusionModel" & ".txt"
            outfile(9) = directory & "\" & "R_SO4_DiffusionModel" & ".txt"
        ElseIf Model = 1 Then
            ''Creating output .txt computation result file 2020-10-23 Xuande 
            outfile(0) = directory & "\" & "R_H_CapillaryModel" & ".txt"
            outfile(1) = directory & "\" & "R_W_CapillaryModel" & ".txt"
            outfile(2) = directory & "\" & "R_S_CapillaryModel" & ".txt"
            outfile(3) = directory & "\" & "R_T_CapillaryModel" & ".txt"
            outfile(4) = directory & "\" & "R_Na_CapillaryModel" & ".txt"
            outfile(5) = directory & "\" & "R_Cl_CapillaryModel" & ".txt"
            outfile(6) = directory & "\" & "R_K_CapillaryModel" & ".txt"
            outfile(7) = directory & "\" & "R_OH_CapillaryModel" & ".txt"
            outfile(8) = directory & "\" & "R_Ca_CapillaryModel" & ".txt"
            outfile(9) = directory & "\" & "R_SO4_CapillaryModel" & ".txt"
        End If

        For i As Integer = 0 To NbFiles - 1
            nFic(i) = CShort(FreeFile())
            FileOpen(CInt(nFic(i)), outfile(i), OpenMode.Output)
        Next

        Print(nFic(0), "RH", ",", nDof, ",", "Average RH", ",", "dH", ",", TAB)
        Print(nFic(1), "W", ",", nDof, ",", "Average W", ",", "dW", ",", TAB)
        Print(nFic(2), "S", ",", nDof, ",", "Average S", ",", "dS", ",", TAB)
        Print(nFic(3), "T", ",", nDof, ",", "Average T", ",", "dT", ",", TAB)
        Print(nFic(4), "Na", ",", nDof, ",", "Average Na", ",", "dNa", ",", TAB)
        Print(nFic(5), "Cl", ",", nDof, ",", "Average Cl", ",", "dCl", ",", TAB)
        Print(nFic(6), "K", ",", nDof, ",", "Average K", ",", "dK", ",", TAB)
        Print(nFic(7), "OH", ",", nDof, ",", "Average OH", ",", "dOH", ",", TAB)
        Print(nFic(8), "Ca", ",", nDof, ",", "Average Ca", ",", "dCa", ",", TAB)
        Print(nFic(9), "SO4", ",", nDof, ",", "Average SO4", ",", "dSO4", ",", TAB)

        For i As Integer = 0 To NbFiles - 1
            For jj As Integer = 0 To nDof - 1
                Print(CInt(nFic(i)), jj + CShort(1), ",", TAB)
            Next jj
            PrintLine(CInt(nFic(i)), " ")
            Print(CInt(nFic(i)), "0", ",", "0", ",", TAB)
        Next

    End Sub

    Public Sub WriteLine(ByRef H As Double, ByRef w As Double, ByRef S As Double, ByRef T As Double, ByRef Na As Double, ByRef Cl As Double, ByRef K As Double, ByRef OH As Double, ByRef Ca As Double, ByRef SO4 As Double)

        Print(CInt(nFic(0)), H, ",", "0", ",", TAB)
        Print(CInt(nFic(1)), w, ",", "0", ",", TAB)
        Print(CInt(nFic(2)), S, ",", "0", ",", TAB)
        Print(CInt(nFic(3)), T, ",", "0", ",", TAB)
        Print(CInt(nFic(4)), Na, ",", "0", ",", TAB)
        Print(CInt(nFic(5)), Cl, ",", "0", ",", TAB)
        Print(CInt(nFic(6)), K, ",", "0", ",", TAB)
        Print(CInt(nFic(7)), OH, ",", "0", ",", TAB)
        Print(CInt(nFic(8)), Ca, ",", "0", ",", TAB)
        Print(CInt(nFic(9)), SO4, ",", "0", ",", TAB)
    End Sub

    Public Sub WriteFirstLine(ByRef H As Double, ByRef w As Double, ByRef S As Double, ByRef T As Double, ByRef Na As Double, ByRef Cl As Double, ByRef K As Double, ByRef OH As Double, ByRef Ca As Double, ByRef SO4 As Double)

        Print(CInt(nFic(0)), H, ",", TAB)
        Print(CInt(nFic(1)), w, ",", TAB)
        Print(CInt(nFic(2)), S, ",", TAB)
        Print(CInt(nFic(3)), T, ",", TAB)
        Print(CInt(nFic(4)), Na, ",", TAB)
        Print(CInt(nFic(5)), Cl, ",", TAB)
        Print(CInt(nFic(6)), K, ",", TAB)
        Print(CInt(nFic(7)), OH, ",", TAB)
        Print(CInt(nFic(8)), Ca, ",", TAB)
        Print(CInt(nFic(9)), SO4, ",", TAB)
    End Sub

    Public Sub WriteBlankLine()

        PrintLine(CInt(nFic(0)), " ", TAB)
        PrintLine(CInt(nFic(1)), " ", TAB)
        PrintLine(CInt(nFic(2)), " ", TAB)
        PrintLine(CInt(nFic(3)), " ", TAB)
        PrintLine(CInt(nFic(4)), " ", TAB)
        PrintLine(CInt(nFic(5)), " ", TAB)
        PrintLine(CInt(nFic(6)), " ", TAB)
        PrintLine(CInt(nFic(7)), " ", TAB)
        PrintLine(CInt(nFic(8)), " ", TAB)
        PrintLine(CInt(nFic(9)), " ", TAB)
    End Sub

    Public Sub WriteFirstHR(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 0

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetHRNew(), ",", TAB) '% humidité relative dans le béton
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub

    Public Sub WriteHR(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 0

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetHRNew(), ",", TAB) '% humidité relative dans le béton
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub

    Public Sub WriteW(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 1

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetWNew(), ",", TAB) '% teneur en eau dans le béton
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub

    Public Sub WriteS(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 2

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetSNew(), ",", TAB) '% saturation de liquid dans le béton
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub

    Public Sub WriteT(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 3

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetTNew(), ",", TAB) '% temperature dans le béton
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub
    Public Sub WriteNa(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 4

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetNaNew(), ",", TAB) '% Write Sodium concentration, Xuande 2021.09.03
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub
    Public Sub WriteCl(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 5

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetClNew(), ",", TAB) '% concentration de chlore dans le béton
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub
    Public Sub WriteK(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 6

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetKNew(), ",", TAB) '% Write Potassium concentration, Xuande 2021.09.03
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub
    Public Sub WriteOH(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 7

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetOHNew(), ",", TAB) '% Write Hydroxide ion concentration, Xuande 2021.09.03
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub
    Public Sub WriteCa(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 8

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetCaNew(), ",", TAB) '% Write Calcium concentration, Xuande 2021.09.03
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub
    Public Sub WriteSO4(ByRef Temps As Double, ByRef Dofs As Integer,
                           ByRef d_avg As Double, ByRef avg As Double, ByRef Nodes() As NodeTrans)

        Dim i As Integer = 9

        'Register field values
        Print(CInt(nFic(i)), Temps / 3600, ",", Temps, ",", TAB)
        Print(CInt(nFic(i)), avg, ",", d_avg, ",", TAB)

        For j As Integer = 0 To Dofs - 1
            Print(CInt(nFic(i)), Nodes(j).GetSO4New(), ",", TAB) '% Write Sulfate ion concentration, Xuande 2021.09.03
        Next j

        PrintLine(CInt(nFic(i)), " ")

    End Sub
    Protected Overrides Sub Finalize()

        For i As Integer = 0 To NbFiles - 1
            FileClose(CInt(nFic(i)))
        Next

        MyBase.Finalize()

    End Sub
End Class
