Imports System.Linq
Imports IPhreeqcCOM

Public Class frmPhreeqC

    Dim a As Single
    'Dim PhrObj As New IPhreeqcCOM.Object
    Dim PhrInput As String = ""
    Dim PhrDatabase As String
    Dim PhrInputFile As String


    Private Sub frmPhreeqC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        a = Me.Width / 34
        Dim x As Short = a
        Dim y As Short = 18 * a

        Chart1.Titles.Add("AFm Solubility")
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add("Default")
        With Chart1.ChartAreas("Default")
            .AxisY.Title = "AFm [mol/kg]"
            .AxisY.MajorGrid.LineColor = Color.SkyBlue
            .AxisX.Title = "NaCl [mmol/kgw]"
            .AxisX.MajorGrid.LineColor = Color.SkyBlue
        End With

        Chart1.Hide()

    End Sub

    Public Sub frmPhreeqC_Plot(ByVal x() As Double, ByVal y() As Double)

        Chart1.Show()

        Chart1.ChartAreas("Default").AxisY.Minimum = y.Min
        Chart1.ChartAreas("Default").AxisY.Maximum = y.Max
        Chart1.ChartAreas("Default").AxisX.Minimum = x.Min
        Chart1.ChartAreas("Default").AxisX.Maximum = x.Max
        Chart1.Series.Clear()
        Chart1.Series.Add("Plot")
        Chart1.Series("Plot").Color = Color.Red
        Chart1.Series("Plot").ChartType = DataVisualization.Charting.SeriesChartType.Line

        For i As Integer = 0 To x.Length - 1
            Chart1.Series("Plot").Points.AddXY(x(i), y(i))
        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim Filtre As String = "PhreeqC Database (*.dat)|*.dat"
        Dim Index As Short = 1
        Dim Directoire As Boolean = True
        Dim Titre As String = "Sélectionner le fichier database de PhreeqC"
        Dim Canc As Boolean = False

        OpenDialog(PhrDatabase, Canc, Filtre, Index, Directoire, Titre)
        If Canc = True Then GoTo b

        Filtre = "PhreeqC files (*.phr)|*.phr"
        Titre = "Sélectionner le fichier d'entrée PhreeqC"

        OpenDialog(PhrInputFile, Canc, Filtre, Index, Directoire, Titre)
        If Canc = True Then GoTo b

        Dim nFic As Integer = Microsoft.VisualBasic.FileSystem.FreeFile()
        FileOpen(nFic, PhrInputFile, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
        'Dim PostFile As String
        'FilePost(PhrInputFile, PostFile)
        'FileOnly(PhrInputFile)

        'Dim posTxt As Integer = Len(PhrInputFile) - 10
        'Dim txtFile As String = Mid(PhrInputFile, 7, posTxt)
        'Dim line As String

        Dim bFertig As Boolean = False
        Dim inPhr As String

        Do While Not bFertig
            Try 'test s'il y a du text ou pas
                Input(nFic, inPhr)
                PhrInput += inPhr + " "
            Catch
                bFertig = True
            End Try
        Loop

        FileClose(nFic)

        Run(PhrInput, PhrDatabase)

b:
    End Sub

    Sub Run(ByVal input As String, ByVal Dbase As String)

        ' Me.PhrObj.ErrorFileOn = True
        'Me.PhrDatabase = Dbase
        'Me.PhrObj.LoadDatabase(PhrDatabase)
        'Me.PhrObj.RunString(input)

        'Me.PhrObj.RunFile(PhrInputFile)

        'Dim OutPhreeqc(,) As Object = Me.PhrObj.GetSelectedOutputArray
        'Dim nbcolumns As Integer = OutPhreeqc.GetLength(1)
        'Dim nbrows As Integer = OutPhreeqc.GetLength(0)
        'Dim OutName(nbcolumns - 1) As String
        'Dim OutValues(nbrows - 2, nbcolumns - 1) As Double


        'For j As Integer = 0 To nbcolumns - 1

        'OutName(j) = OutPhreeqc(0, j)

        'For i As Integer = 0 To nbrows - 2
        'OutValues(i, j) = CDbl(OutPhreeqc(i + 1, j))
        'Next

        'Next

        'define empty array, at the end of the 'for' cycle it will contain requested row's values  
        'Dim x(nbrows - 2), y(nbrows - 2) As Double

        '        For i As Integer = 0 To nbrows - 2
        '       x(i) = OutValues(i, 0) * 1000
        '      y(i) = OutValues(i, 1)
        '     Next
        '
        ' frmPhreeqC_Plot(x, y)

    End Sub

    'Private Declare Sub lfGetDe3Info Lib "C:\mmsprog\Lecfin.dll" (ByVal strde3 As String, ByVal ilen As Long, ByRef max_de3_step As Long, ByRef Lib As Long, ByRef nodmax As Long)

End Class