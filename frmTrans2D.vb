Option Explicit On
Option Infer On
Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms.DataVisualization.Charting
Imports TransChlor.My

Public Class FrmTrans2D

    'This program shows the complete implementation
    'of a 2D finite element program to analyse coupled 
    'hygro-thermo-chemical multi-ionic transport in concretes .
    'Copyright©2020 by Xuande Chen, Thomas Sanchez and David Conciatori
    'Concrete Durability Group
    'Laval Univeristy
    'Quebec, QC
    'Canada

    Public Para As Short
    Public NNodes, NElements, Nbloc, NPointLoads, NSupports As Integer
    Public ElasticityModulus, Thickness, PoissonRatio As Double
    Public Nodes() As NodeTrans
    Public Elements() As ElementTrans
    Public Table() As TableTrans 'Xuande 2020.10.27
    Public Time() As Double ' heure
    Public Expo(1) As Exposition
    Public PointLoads() As PointLoad
    Public Supports() As Support
    Public Deformations() As Double 'the deformation vector
    Public Analysed As Boolean = False
    Public ShowDeformations As Boolean = True
    Public ShowModel As Boolean = True
    Public ShowNodeNumbers As Boolean = False
    Public ShowExpo As Boolean = False
    Public ShowElementsOnDeformedShape As Boolean = True
    Public colorMap As ColorMap
    Public HRRange As Range
    Public SlRange As Range
    Public TRange As Range
    Public NaRange As Range 'Xuande 2021.09.05
    Public ClRange As Range
    Public KRange As Range
    Public OHRange As Range
    Public CaRange As Range
    Public SO4Range As Range
    Public Directory As String
    'Private EpsilonXRange, EpsilonYRange, GammaXYRange As Range

    Private Enum Results
        None
        HR
        Sl
        T
        Na
        Cl
        K
        OH
        Ca
        SO4
    End Enum

    Private ShowResult As Results = Results.None

    'Graphics
    Private zoom As Double = 1.0
    Private DeformationZoom As Double = 50.0
    Private gr As Graphics
    Private bmp As Bitmap

    Private Sub FrmTrans2D_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bmp = New Bitmap(pbModel.Width, pbModel.Height, pbModel.CreateGraphics)
        gr = Graphics.FromImage(bmp)
        TimeScrollBar.Visible = False
        LabelT1.Visible = False
        LabelTVal.Visible = False
        LabelProgress.Visible = False
    End Sub

    Private Sub ClearAnalysisOutput()

        Erase Deformations 'Clear the earlier analysis output
        TimeScrollBar.Visible = False
        LabelT1.Visible = False
        LabelTVal.Visible = False
        LabelProgress.Visible = False
        Analysed = False

    End Sub

    Private Sub OpenMeshFile_Click(sender As Object, e As EventArgs) Handles OpenMeshFile.Click

        'Xuande 2020.10.27 Lecture table de connectivité groupes physiques et expositions
        Dim c As New OpenFileDialog With {
            .Title = "Open Physical Exposure Connect file",
            .Filter = "Physical Exposure Files (*.txt)|*.txt"
        }

        If c.ShowDialog = DialogResult.OK Then
            If ReadTable(c.FileName) = False Then
                MsgBox("Error with Physical Exposure file.", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "Physical Exposure file")
                Return
            End If
        End If
        'Xuande 2020.10.27 Lecture table de connectivité groupes physiques et expositions

        Dim d As New OpenFileDialog With {
            .Title = "Open Mesh file",
            .Filter = "Mesh Files (*.msh)|*.msh"
        }

        If d.ShowDialog = DialogResult.OK Then
            ClearAnalysisOutput()
            If ReadMeshFile(d.FileName) = False Then
                MsgBox("Error with Mesh file.", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "Mesh file")
                Return
            End If
            Directory = Path.GetDirectoryName(d.FileName) ' Thomas : Ligne pour récuperer le chemin du fichier
            DrawModel()

        End If
    End Sub

    Private Sub AnalyseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnalyseToolStripMenuItem.Click

        'check if there is a proper model
        If NElements <= 0 OrElse NNodes <= 0 Then
            'there are no elements defined
            'MsgBox("Please open a proper finite element model")
            MsgBox("Error reading number of elements and nodes, please open a proper mesh file")
            Return
        End If

        'Dim C2D As New Compute2D
        Dim C2D As New Compute2Dtrial 'Xuande, activate hygro-thermo coupling multi-ionic model
        'perform analysis using the finite elemeent method
        Dim ind As Integer = C2D.Read_InputFile()
        For i As Integer = 1 To Expo.Length - 1
            Expo(i).WriteExpo(ind)
        Next

        PlotInitialization(ind)
        C2D.Compute_All(Me, Expo, NNodes, NElements, Elements, Nodes, Time)
        Analysed = True
        LabelProgress.Visible = False
        AddRangeValue(Time.Length)
        DrawModel()

    End Sub

    Private Function MultiplyMatrixWithVector(ByRef a(,) As Double, ByRef b() As Double) As Double()

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
    Public Function ReadMeshFile(f As String) As Boolean

        Try

            Dim sr As New StreamReader(f)
            Dim s As String
            Dim Arr() As String
            Dim Temp As String
            Dim GroupExpo As String 'Xuande 2020.10.27
            Dim i As Integer
            Dim j As Integer
            Dim jj As Integer
            Dim k As Integer
            Dim NN(0) As Integer
            Dim XX(0), YY(0), ZZ(0) As Double
            Dim n0 As Integer
            Dim n, n1, n2, n3, n4 As Integer
            Dim x, y, z As Double
            Dim NExpo As Integer
            Dim bloc_node As Integer
            Dim bloc_type As Integer
            Dim bloc_index As Integer
            Dim bloc_element As Integer

            'Skip the version data
            Temp = ReadLine(sr)

            Do While Temp <> "$PhysicalNames"
                Temp = sr.ReadLine.Trim
            Loop

            'Dim NbExpo As Integer = ReadLine(sr) 'old code
            'ReDim Expo(NbExpo)
            Dim NPhysGroup As Integer = ReadLine(sr) 'Xuande 2020.10.27 number of physical groups
            ReDim Expo(NPhysGroup)
            For i = 0 To NPhysGroup - 1

                s = ReadLine(sr)
                Arr = Split(s, " "c)
                'Expo(Integer.Parse(Arr(1))) = New Exposition(Arr(2)) 'old code
                GroupExpo = Table(i).ExpoFile 'Xuande 2020.10.27
                Expo(Integer.Parse(Arr(1))) = New Exposition(GroupExpo) 'Xuande 2020.10.27
            Next

            Temp = ReadLine(sr)
            Do While Temp <> "$Entities"
                Temp = sr.ReadLine.Trim
            Loop

            s = ReadLine(sr)
            Arr = Split(s, " "c)
            Dim Npoints As Integer = Integer.Parse(Arr(0))
            'Dim NumExpo(Integer.Parse(Arr(1)) - 1) As Integer 'old code
            Dim Nlines As Integer = Integer.Parse(Arr(1)) 'Xuande 2020.10.27
            Dim Nsurfaces As Integer = Integer.Parse(Arr(2)) 'Xuande 2020.10.27
            Dim Nvolumes As Integer = Integer.Parse(Arr(3)) 'Xuande 2020.10.27
            Dim NumExpo(NPhysGroup - 1) As Integer
            Dim TypeExpo As String
            For i = 0 To Npoints - 1
                s = ReadLine(sr)
                Arr = Split(s, " "c)
                NumExpo(i) = Integer.Parse(Arr(5))
            Next
            For i = 0 To Nlines - 1
                s = ReadLine(sr)
                Arr = Split(s, " "c)
                NumExpo(i + Npoints) = Integer.Parse(Arr(8))
            Next
            For i = 0 To Nsurfaces - 1
                s = ReadLine(sr)
                Arr = Split(s, " "c)
                NumExpo(i + Npoints + Nlines) = Integer.Parse(Arr(8))
            Next
            'Skip the unnecessary first few lines
            Do While Temp <> "$Nodes"
                Temp = sr.ReadLine.Trim
            Loop

            'Read total number of nodes and blocks 
            s = ReadLine(sr)
            Arr = Split(s, " "c)
            Try
                Nbloc = Integer.Parse(Arr(0))
                NNodes = Integer.Parse(Arr(1))
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

            'Read node coordinates block by block
            ReDim Nodes(NNodes - 1)
            Dim NBord As Integer = 0

            For i = 0 To Nbloc - 1
                'read bloc information for how many nodes should be read inside
                s = ReadLine(sr)
                Arr = Split(s, " "c)
                bloc_type = Integer.Parse(Arr(0))
                bloc_index = Integer.Parse(Arr(1))
                bloc_node = Integer.Parse(Arr(3))
                ReDim NN(bloc_node - 1)
                ReDim XX(bloc_node - 1)
                ReDim YY(bloc_node - 1)
                ReDim ZZ(bloc_node - 1)
                For j = 0 To bloc_node - 1
                    'read first lines of node number
                    s = ReadLine(sr)
                    Arr = Split(s, " "c)
                    n = Integer.Parse(Arr(0))
                    NN(j) = n
                Next
                'read corresponding lines of coordinates
                For k = 0 To bloc_node - 1
                    'judging wether points of current block belongs to the boundary
                    If bloc_type = 0 Then
                        NExpo = NumExpo(bloc_index - 1)

                        If Table(NExpo - 1).ExpoFile.Contains("Neumann") Then
                            TypeExpo = "Neumann"
                        Else
                            TypeExpo = "Dirichlet"
                        End If

                    ElseIf bloc_type = 1 Then
                        NExpo = NumExpo(Npoints + bloc_index - 1)

                        If Table(NExpo - 1).ExpoFile.Contains("Neumann") Then
                            TypeExpo = "Neumann"
                        Else
                            TypeExpo = "Dirichlet"
                        End If

                    ElseIf bloc_type = 2 Then
                            NExpo = 0
                        TypeExpo = "Null"
                    End If

                    'read corresponding lines of coordinates
                    s = ReadLine(sr)
                    Arr = Split(s, " "c)
                    x = CDbl(Arr(0))
                    XX(k) = x
                    y = CDbl(Arr(1))
                    YY(k) = y
                    z = CDbl(Arr(2))
                    ZZ(k) = z
                    Nodes(NN(k) - 1) = New NodeTrans(NN(k), XX(k), YY(k), ZZ(k), NExpo, TypeExpo)
                Next

                'If bloc_type = 1 Then NBord += 1 'old code

            Next

            Do While Temp <> "$Elements"
                Temp = sr.ReadLine.Trim
            Loop

            'Read total number of elements and blocks 
            s = ReadLine(sr)
            Arr = Split(s, " "c)
            Try
                Nbloc = Integer.Parse(Arr(0))
                NElements = Integer.Parse(Arr(1))
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

            'Read element connectivity block by block
            For i = 0 To Nbloc - 1
                'read bloc information for how many nodes should be read inside
                s = ReadLine(sr)
                Arr = Split(s, " "c)
                bloc_type = Integer.Parse(Arr(0))
                bloc_index = Integer.Parse(Arr(1))
                bloc_element = Integer.Parse(Arr(3))

                If bloc_type = 0 Then
                    Temp = ReadLine(sr)
                ElseIf bloc_type = 1 Then
                    For j = 0 To bloc_element - 1
                        Temp = ReadLine(sr)
                    Next
                ElseIf bloc_type = 2 Then
                    NElements = bloc_element
                    ReDim Elements(NElements - 1)
                    For jj = 0 To NElements - 1
                        s = ReadLine(sr)
                        Arr = Split(s, " "c)
                        n = Integer.Parse(Arr(0)) - n0
                        n1 = Integer.Parse(Arr(1))
                        n2 = Integer.Parse(Arr(2))
                        n3 = Integer.Parse(Arr(3))
                        n4 = Integer.Parse(Arr(4))
                        Elements(jj) = New ElementTrans(n, n1, n2, n3, n4)
                    Next
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function ReadTable(file As String) As Boolean

        Try
            Dim sr As New StreamReader(file)
            Dim s As String
            Dim num As Integer
            Dim Arr() As String
            Dim n As Integer
            Dim f As String
            s = ReadLine(sr)
            Arr = Split(s, " "c)
            num = Integer.Parse(Arr(0)) 'total number of exposures to be given
            ReDim Table(num - 1)
            For i As Integer = 0 To num - 1
                s = ReadLine(sr)
                Arr = Split(s, " "c)
                n = Integer.Parse(Arr(0))
                f = String.Copy(Arr(1))
                Table(i) = New TableTrans(n, f)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True

    End Function

    Private Sub BtnResetZoom_Click(sender As Object, e As EventArgs) Handles btnResetZoom.Click
        zoom = 1
        hs.Value = 0
        vs.Value = 0
        DrawModel()
    End Sub

    Private Sub Vs_Scroll(sender As Object, e As ScrollEventArgs) Handles vs.Scroll
        DrawModel()
    End Sub

    Private Sub Hs_Scroll(sender As Object, e As ScrollEventArgs) Handles hs.Scroll
        DrawModel()
    End Sub

    Private Function ReadLine(ByRef sr As StreamReader) As String
        Dim s As String
        If sr.EndOfStream = True Then Return ""
        While sr.EndOfStream = False
            s = sr.ReadLine.Trim
            If s.Length > 0 Then
                If s.Substring(0, 1) <> "%" Then
                    Return s
                End If
            End If
        End While
        Return ""
    End Function

    Private Sub DrawModel()
        gr.Clear(Color.White)

        Dim eleColor As Color = Color.Lavender
        Dim eleColorDeformed As Color = Color.Turquoise
        Dim supportColor As Color = Color.Black
        Dim pointLoadColor As Color = Color.Red

        Dim MarginX, MarginY As Integer
        MarginX = 50
        MarginY = 50

        'Draw the triangles.
        Dim shiftx As Integer = MarginX - hs.Value
        Dim shifty As Integer = pbModel.Height - MarginY - vs.Value

        Dim i As Integer
        Dim n1, n2, n3, n4 As Integer
        Dim ptsf(3) As PointF
        'Draw the undeformed model

        If ShowModel = True Then
            'Draw the elements .
            For i = 0 To NElements - 1

                n1 = Elements(i).Node1 - 1
                n2 = Elements(i).Node2 - 1
                n3 = Elements(i).Node3 - 1
                n4 = Elements(i).Node4 - 1

                ptsf(0) = New PointF(CSng(Nodes(n1).x * zoom + shiftx), CSng(-Nodes(n1).y * zoom + shifty))
                ptsf(1) = New PointF(CSng(Nodes(n2).x * zoom + shiftx), CSng(-Nodes(n2).y * zoom + shifty))
                ptsf(2) = New PointF(CSng(Nodes(n3).x * zoom + shiftx), CSng(-Nodes(n3).y * zoom + shifty))
                ptsf(3) = New PointF(CSng(Nodes(n4).x * zoom + shiftx), CSng(-Nodes(n4).y * zoom + shifty))

                'Draw the element
                gr.FillPolygon(New SolidBrush(eleColor), ptsf)
                gr.DrawPolygon(New Pen(Color.Black), ptsf)
            Next

            'Draw the node numbers
            If ShowNodeNumbers = True Then
                Dim p As New Pen(Color.Black)
                Dim nx, ny As Integer
                Dim fnt As New Font("Arial", 8)
                Dim brsh As New SolidBrush(Color.Red)
                For i = 0 To NNodes - 1
                    nx = CInt(Nodes(i).x * zoom + shiftx)
                    ny = CInt(-Nodes(i).y * zoom + shifty)
                    Dim r As New Rectangle(nx - 3, ny - 3, 6, 6)
                    gr.DrawEllipse(p, r)
                    gr.DrawString((i + 1).ToString, fnt, brsh, New PointF(nx + 5, ny + 5))

                Next
            End If

            'Draw the Expositions
            If ShowExpo = True Then
                Dim p As New Pen(Color.Black)
                Dim nx, ny As Integer
                Dim fnt As New Font("Arial", 8)
                Dim brsh As New SolidBrush(Color.Red)
                For i = 0 To NNodes - 1
                    nx = CInt(Nodes(i).x * zoom + shiftx)
                    ny = CInt(-Nodes(i).y * zoom + shifty)
                    Dim r As New Rectangle(nx - 3, ny - 3, 6, 6)
                    gr.DrawEllipse(p, r)

                    'Dim NameExpo As String = C2D.Expo(Nodes(i).NumExpo).NameExpo
                    gr.DrawString(CStr(Nodes(i).NumExpo), fnt, brsh, New PointF(nx + 5, ny + 5))
                Next
            End If

            'Draw the supports
            'we draw squares for supports
            ReDim ptsf(3)
            Dim squareHalfSize As Integer = 5
            For i = 0 To NSupports - 1
                n1 = Supports(i).Node - 1
                ptsf(0) = New PointF(CSng(Nodes(n1).x * zoom + shiftx - squareHalfSize),
                                     CSng(-Nodes(n1).y * zoom + shifty - squareHalfSize))
                ptsf(1) = New PointF(CSng(Nodes(n1).x * zoom + shiftx + squareHalfSize),
                                     CSng(-Nodes(n1).y * zoom + shifty - squareHalfSize))
                ptsf(2) = New PointF(CSng(Nodes(n1).x * zoom + shiftx + squareHalfSize),
                                     CSng(-Nodes(n1).y * zoom + shifty + squareHalfSize))
                ptsf(3) = New PointF(CSng(Nodes(n1).x * zoom + shiftx - squareHalfSize),
                                     CSng(-Nodes(n1).y * zoom + shifty + squareHalfSize))
                gr.FillPolygon(New SolidBrush(supportColor), ptsf)

            Next

            'draw the loads
            Dim px, py As Integer
            For i = 0 To NPointLoads - 1
                n1 = PointLoads(i).Node - 1
                If Math.Abs(PointLoads(i).Fx) > 0.0001 Then
                    'if the pointload is significant
                    'draw the arrow
                    px = CInt(Nodes(n1).x * zoom + shiftx)
                    py = CInt(-Nodes(n1).y * zoom + shifty)
                    If PointLoads(i).Fx > 0 Then
                        DrawHArrow(px, py, pointLoadColor, False)
                    Else
                        DrawHArrow(px, py, pointLoadColor, True)
                    End If
                End If

                If Math.Abs(PointLoads(i).Fy) > 0.0001 Then
                    px = CInt(Nodes(n1).x * zoom + shiftx)
                    py = CInt(-Nodes(n1).y * zoom + shifty)
                    If PointLoads(i).Fy > 0 Then
                        DrawVArrow(px, py, pointLoadColor, False)
                    Else
                        DrawVArrow(px, py, pointLoadColor, True)
                    End If

                End If

            Next
        End If
        'Now, plot results if available
        'If Deformations IsNot Nothing AndAlso Deformations.Length > 0 Then

        If Analysed = True Then

            Dim eColor As Color
            'we can plot now.
            If ShowDeformations = True Then
                ReDim ptsf(3)
                'compute the colormap
                'set the colormap if required
                Select Case ShowResult
                    Case Results.None
                        'create a dummy colormap
                        colorMap = New ColorMap(1, 0)
                    Case Results.HR
                        colorMap = New ColorMap(Math.Round(HRRange.Max, 2), Math.Round(HRRange.Min, 2))
                        'TimeScrollBar
                        TimeScrollBar.Maximum = Time.Length()
                        TimeScrollBar.Visible = True
                        LabelT1.Visible = True
                        LabelTVal.Visible = True
                    Case Results.Sl
                        colorMap = New ColorMap(Math.Round(SlRange.Max, 2), Math.Round(SlRange.Min, 2))
                        'TimeScrollBar
                        TimeScrollBar.Maximum = Time.Length()
                        TimeScrollBar.Visible = True
                        LabelT1.Visible = True
                        LabelTVal.Visible = True
                    Case Results.T
                        colorMap = New ColorMap(Math.Round(TRange.Max, 2), Math.Round(TRange.Min, 2))
                        'TimeScrollBar
                        TimeScrollBar.Maximum = Time.Length()
                        TimeScrollBar.Visible = True
                        LabelT1.Visible = True
                        LabelTVal.Visible = True
                    Case Results.Na 'Xuande 2021.09.03
                        colorMap = New ColorMap(Math.Round(NaRange.Max, 2), Math.Round(NaRange.Min, 2))
                        'TimeScrollBar
                        TimeScrollBar.Maximum = Time.Length()
                        TimeScrollBar.Visible = True
                        LabelT1.Visible = True
                        LabelTVal.Visible = True
                    Case Results.Cl
                        colorMap = New ColorMap(Math.Round(ClRange.Max, 2), Math.Round(ClRange.Min, 2))
                        'TimeScrollBar
                        TimeScrollBar.Maximum = Time.Length()
                        TimeScrollBar.Visible = True
                        LabelT1.Visible = True
                        LabelTVal.Visible = True
                    Case Results.K
                        colorMap = New ColorMap(Math.Round(KRange.Max, 2), Math.Round(KRange.Min, 2))
                        'TimeScrollBar
                        TimeScrollBar.Maximum = Time.Length()
                        TimeScrollBar.Visible = True
                        LabelT1.Visible = True
                        LabelTVal.Visible = True
                    Case Results.OH
                        colorMap = New ColorMap(Math.Round(OHRange.Max, 2), Math.Round(OHRange.Min, 2))
                        'TimeScrollBar
                        TimeScrollBar.Maximum = Time.Length()
                        TimeScrollBar.Visible = True
                        LabelT1.Visible = True
                        LabelTVal.Visible = True
                    Case Results.Ca
                        colorMap = New ColorMap(Math.Round(CaRange.Max, 2), Math.Round(CaRange.Min, 2))
                        'TimeScrollBar
                        TimeScrollBar.Maximum = Time.Length()
                        TimeScrollBar.Visible = True
                        LabelT1.Visible = True
                        LabelTVal.Visible = True
                    Case Results.SO4
                        colorMap = New ColorMap(Math.Round(SO4Range.Max, 2), Math.Round(SO4Range.Min, 2))
                        'TimeScrollBar
                        TimeScrollBar.Maximum = Time.Length()
                        TimeScrollBar.Visible = True
                        LabelT1.Visible = True
                        LabelTVal.Visible = True
                        'Case Results.EpsilonX
                        'colorMap = New ColorMap(EpsilonXRange.Max, EpsilonXRange.Min)
                        'Case Results.EpsilonY
                        'colorMap = New ColorMap(EpsilonYRange.Max, EpsilonYRange.Min)
                        'Case Results.GammaXY
                        'colorMap = New ColorMap(GammaXYRange.Max, GammaXYRange.Min)
                    Case Else
                        'just for completeness.. otherwise this block wont ever execute
                        'create a dummy colormap
                        colorMap = New ColorMap(1, 0)
                End Select

                For i = 0 To NElements - 1

                    'ecolor depends on the value of result to be shown

                    Select Case ShowResult
                        Case Results.None
                            eColor = eleColorDeformed
                        Case Results.HR
                            'eColor = colorMap.getColor(Elements(i).Stresses(0))
                            eColor = colorMap.getColor(Elements(i).GetHR(TimeScrollBar.Value))
                            LabelTVal.Text = CStr(Time(TimeScrollBar.Value))
                        Case Results.Sl
                            eColor = colorMap.getColor(Elements(i).GetS(TimeScrollBar.Value))
                            LabelTVal.Text = CStr(Time(TimeScrollBar.Value))
                        Case Results.T
                            eColor = colorMap.getColor(Elements(i).GetT(TimeScrollBar.Value))
                            LabelTVal.Text = CStr(Time(TimeScrollBar.Value))
                        Case Results.Na
                            eColor = colorMap.getColor(Elements(i).GetNa(TimeScrollBar.Value))
                            LabelTVal.Text = CStr(Time(TimeScrollBar.Value))
                        Case Results.Cl
                            eColor = colorMap.getColor(Elements(i).GetCl(TimeScrollBar.Value))
                            LabelTVal.Text = CStr(Time(TimeScrollBar.Value))
                        Case Results.K
                            eColor = colorMap.getColor(Elements(i).GetK(TimeScrollBar.Value))
                            LabelTVal.Text = CStr(Time(TimeScrollBar.Value))
                        Case Results.OH
                            eColor = colorMap.getColor(Elements(i).GetOH(TimeScrollBar.Value))
                            LabelTVal.Text = CStr(Time(TimeScrollBar.Value))
                        Case Results.Ca
                            eColor = colorMap.getColor(Elements(i).GetCa(TimeScrollBar.Value))
                            LabelTVal.Text = CStr(Time(TimeScrollBar.Value))
                        Case Results.SO4
                            eColor = colorMap.getColor(Elements(i).GetSO4(TimeScrollBar.Value))
                            LabelTVal.Text = CStr(Time(TimeScrollBar.Value))
                            'eColor = colorMap.getColor(Elements(i).Stresses(1))
                            'eColor = colorMap.getColor(Elements(i).HR(1))
                            'Case Results.TauXY
                            'eColor = colorMap.getColor(Elements(i).Stresses(2))
                            'Case Results.EpsilonX
                            'eColor = colorMap.getColor(Elements(i).Strains(0))
                            'Case Results.EpsilonY
                            'eColor = colorMap.getColor(Elements(i).Strains(1))
                            'Case Results.GammaXY
                            'eColor = colorMap.getColor(Elements(i).Strains(2))
                        Case Else
                            eColor = eleColor
                    End Select

                    n1 = Elements(i).Node1 - 1
                    n2 = Elements(i).Node2 - 1
                    n3 = Elements(i).Node3 - 1
                    n4 = Elements(i).Node4 - 1

                    'ptsf(0) = New PointF((CSng(Nodes(n1).x * zoom + getDeformationX(n1) * DeformationZoom) + shiftx), CSng((-Nodes(n1).y * zoom - getDeformationY(n1) * DeformationZoom) + shifty))
                    'ptsf(1) = New PointF((CSng(Nodes(n2).x * zoom + getDeformationX(n2) * DeformationZoom) + shiftx), CSng((-Nodes(n2).y * zoom - getDeformationY(n2) * DeformationZoom) + shifty))
                    'ptsf(2) = New PointF((CSng(Nodes(n3).x * zoom + getDeformationX(n3) * DeformationZoom) + shiftx), CSng((-Nodes(n3).y * zoom - getDeformationY(n3) * DeformationZoom) + shifty))
                    'ptsf(3) = New PointF((CSng(Nodes(n4).x * zoom + getDeformationX(n4) * DeformationZoom) + shiftx), CSng((-Nodes(n4).y * zoom - getDeformationY(n4) * DeformationZoom) + shifty))

                    ptsf(0) = New PointF(CSng(Nodes(n1).x * zoom + shiftx), CSng(-Nodes(n1).y * zoom + shifty))
                    ptsf(1) = New PointF(CSng(Nodes(n2).x * zoom + shiftx), CSng(-Nodes(n2).y * zoom + shifty))
                    ptsf(2) = New PointF(CSng(Nodes(n3).x * zoom + shiftx), CSng(-Nodes(n3).y * zoom + shifty))
                    ptsf(3) = New PointF(CSng(Nodes(n4).x * zoom + shiftx), CSng(-Nodes(n4).y * zoom + shifty))

                    'Draw the element
                    gr.FillPolygon(New SolidBrush(eColor), ptsf)
                    If ShowElementsOnDeformedShape = True Then
                        gr.DrawPolygon(New Pen(Color.Black), ptsf)
                    End If

                Next

                'Draw Colormap at right top of the picturebox
                'only if required
                If ShowResult <> Results.None Then
                    Dim cmap As New ColorMap(256, 0)
                    Dim c As Color
                    Dim x1, x2, y As Integer
                    y = 50
                    x1 = bmp.Width - 100
                    x2 = x1 + 50
                    For i = 250 To 0 Step -1
                        c = cmap.getColor(i)
                        y += 1
                        gr.DrawLine(New Pen(c), New Point(x1, y), New Point(x2, y))
                    Next
                    'write the max, min and mid values
                    'max

                    Dim strWidth As Integer
                    Dim MaxWidth, MinWidth, AvgWidth As Single
                    Dim Max, Min, Avg As String
                    Dim barFont As New Font("Arial", 9)
                    Dim barBrush As New SolidBrush(Color.Black)
                    Max = colorMap.Max.ToString
                    Min = colorMap.Min.ToString
                    Avg = ((colorMap.Max + colorMap.Min) / 2).ToString
                    MaxWidth = gr.MeasureString(Max, barFont).Width
                    MinWidth = gr.MeasureString(Min, barFont).Width
                    AvgWidth = gr.MeasureString(Avg, barFont).Width

                    strWidth = CInt(Math.Max(Math.Max(MaxWidth, MinWidth), AvgWidth)) + 10

                    gr.DrawLine(Pens.Black, x1, 50, x1 - 5, 50)
                    gr.DrawString(Max, barFont, barBrush, New PointF(x1 - strWidth, 30))

                    gr.DrawLine(Pens.Black, x1, 175, x1 - 5, 175)
                    gr.DrawString(Avg, barFont, barBrush, New PointF(x1 - strWidth, 155))

                    gr.DrawLine(Pens.Black, x1, 300, x1 - 5, 300)
                    gr.DrawString(Min, barFont, barBrush, New PointF(x1 - strWidth, 320))
                End If


            End If
        End If
        pbModel.Refresh()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If MsgBox("Are you sure you want to exit?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            End
        End If
    End Sub

    Private Sub DrawHArrow(px As Integer, py As Integer, c As Color, leftward As Boolean)
        Dim p As New Pen(c)
        Dim size As Integer = 15
        If leftward = False Then
            'rightward arrow
            gr.DrawLine(p, New Point(px, py), New Point(px - size, py))
            gr.DrawLine(p, New Point(px, py), New Point(CInt(px - size / 4), CInt(py - size / 4)))
            gr.DrawLine(p, New Point(px, py), New Point(CInt(px - size / 4), CInt(py + size / 4)))
        Else
            'leftward arrow
            gr.DrawLine(p, New Point(px, py), New Point(px + size, py))
            gr.DrawLine(p, New Point(px, py), New Point(CInt(px + size / 4), CInt(py - size / 4)))
            gr.DrawLine(p, New Point(px, py), New Point(CInt(px + size / 4), CInt(py + size / 4)))
        End If
    End Sub

    Private Sub SetDeformationZoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetDeformationZoomToolStripMenuItem.Click
        Dim ret As String = DeformationZoom.ToString

        ret = InputBox("Set Deformation Zoom:", "Deformation Zoom", ret)
        If ret.Length = 0 Then Return
        While IsNumeric(ret) = False
            ret = InputBox("Set Deformation Zoom:", "Deformation Zoom", ret)
            If ret.Length = 0 Then Return
        End While
        DeformationZoom = Double.Parse(ret)
        DrawModel()
    End Sub

    Private Sub ShowNodeNumbersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowNodeNumbersToolStripMenuItem.Click
        ShowNodeNumbers = Not ShowNodeNumbers
        DrawModel()
    End Sub

    Private Sub ShowModelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowModelToolStripMenuItem.Click
        ShowModel = Not ShowModel
        DrawModel()
    End Sub

    Private Sub ShowElementsOnDeformedShapeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowElementsOnDeformedShapeToolStripMenuItem.Click
        ShowElementsOnDeformedShape = Not ShowElementsOnDeformedShape
        DrawModel()
    End Sub

    Private Sub SaveImageAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveImageAsToolStripMenuItem.Click

        Dim d As New SaveFileDialog With {
            .Title = "Save Image As",
            .Filter = "PNG Files|*.png|JPEG Files|*.jpg|BMP Files|*.bmp|TIFF FIles|*.tiff|All Files|*.*"
        }

        If d.ShowDialog = DialogResult.OK Then
            Try

                Select Case d.FilterIndex
                    Case 1 'png
                        bmp.Save(d.FileName, Imaging.ImageFormat.Png)
                    Case 2 'jpg
                        bmp.Save(d.FileName, Imaging.ImageFormat.Jpeg)
                    Case 3 'bmp
                        bmp.Save(d.FileName, Imaging.ImageFormat.Bmp)
                    Case 4 'tiff
                        bmp.Save(d.FileName, Imaging.ImageFormat.Tiff)
                    Case Else
                        bmp.Save(d.FileName, Imaging.ImageFormat.Bmp)
                End Select
                MsgBox("Image saved successfully to" & vbCrLf & d.FileName)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ShowDeformationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowDeformationsToolStripMenuItem.Click
        ShowDeformations = Not ShowDeformations
        DrawModel()
    End Sub

    Private Sub ShowExpositionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowExpositionsToolStripMenuItem.Click
        ShowExpo = Not ShowExpo
        DrawModel()
    End Sub

    Private Sub DrawVArrow(px As Integer, py As Integer, c As Color, downward As Boolean)
        Dim p As New Pen(c)
        Dim size As Integer = 15
        If downward = False Then
            'upward arrow
            gr.DrawLine(p, New Point(px, py), New Point(px, py + size))
            gr.DrawLine(p, New Point(px, py), New Point(CInt(px - size / 4), CInt(py + size / 4)))
            gr.DrawLine(p, New Point(px, py), New Point(CInt(px + size / 4), CInt(py + size / 4)))
        Else
            'downward arrow
            gr.DrawLine(p, New Point(px, py), New Point(px, py - size))
            gr.DrawLine(p, New Point(px, py), New Point(CInt(px - size / 4), CInt(py - size / 4)))
            gr.DrawLine(p, New Point(px, py), New Point(CInt(px + size / 4), CInt(py - size / 4)))
        End If


    End Sub

    Private Sub HandleShowResultClick(sender As Object, e As EventArgs) Handles XToolStripMenuItem.Click,
            HRToolStripMenuItem.Click, SlToolStripMenuItem.Click, TToolStripMenuItem.Click, NaToolStripMenuItem.Click, ClToolStripMenuItem.Click, KToolStripMenuItem.Click, OHToolStripMenuItem.Click, CaToolStripMenuItem.Click, SO4ToolStripMenuItem.Click

        ShowResult = Results.None

        If sender.Equals(XToolStripMenuItem) Then
            ShowResult = Results.None
        ElseIf sender.Equals(HRToolStripMenuItem) Then
            ShowResult = Results.HR
        ElseIf sender.Equals(SlToolStripMenuItem) Then
            ShowResult = Results.Sl
        ElseIf sender.Equals(TToolStripMenuItem) Then
            ShowResult = Results.T
        ElseIf sender.Equals(NaToolStripMenuItem) Then
            ShowResult = Results.Na
        ElseIf sender.Equals(ClToolStripMenuItem) Then
            ShowResult = Results.Cl
        ElseIf sender.Equals(KToolStripMenuItem) Then
            ShowResult = Results.K
        ElseIf sender.Equals(OHToolStripMenuItem) Then
            ShowResult = Results.OH
        ElseIf sender.Equals(CaToolStripMenuItem) Then
            ShowResult = Results.Ca
        ElseIf sender.Equals(SO4ToolStripMenuItem) Then
            ShowResult = Results.SO4
        End If
        DrawModel()

    End Sub

    Private Sub TimeScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles TimeScrollBar.Scroll
        DrawModel()
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Public Sub PlotInitialization(ByRef ind As Integer)

        HRRange = New Range
        SlRange = New Range
        TRange = New Range
        NaRange = New Range
        ClRange = New Range
        KRange = New Range
        OHRange = New Range
        CaRange = New Range
        SO4Range = New Range
        ReDim Time(ind + 1)
        Time(0) = 0
        LabelProgress.Visible = True
        LabelProgress.Text = "0 / " + CStr(ind)

    End Sub

    Public Sub AddRangeValue(ByRef ind As Integer)

        For i As Integer = 0 To NElements - 1
            For Time As Integer = 0 To ind - 1
                HRRange.AddValue(Elements(i).GetHR(Time))
                SlRange.AddValue(Elements(i).GetS(Time))
                TRange.AddValue(Elements(i).GetT(Time))
                NaRange.AddValue(Elements(i).GetNa(Time))
                ClRange.AddValue(Elements(i).GetCl(Time))
                KRange.AddValue(Elements(i).GetK(Time))
                OHRange.AddValue(Elements(i).GetOH(Time))
                CaRange.AddValue(Elements(i).GetCa(Time))
                SO4Range.AddValue(Elements(i).GetSO4(Time))
            Next
        Next

    End Sub

    Public Sub PlotProgressTime(ByRef ind As Integer, ByRef ti As Integer)

        LabelProgress.Text = CStr(ti) + " / " + CStr(ind)
        Refresh()

    End Sub

    Private Sub NaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NaToolStripMenuItem.Click

    End Sub

    Private Sub ClToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClToolStripMenuItem.Click

    End Sub

    Private Sub KToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KToolStripMenuItem.Click

    End Sub

    Private Sub OHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OHToolStripMenuItem.Click

    End Sub

    Private Sub CaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CaToolStripMenuItem.Click

    End Sub

    Private Sub SO4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SO4ToolStripMenuItem.Click

    End Sub

    Private Sub PbModel_Paint(sender As Object, e As PaintEventArgs) Handles pbModel.Paint
        If bmp IsNot Nothing Then
            e.Graphics.DrawImage(bmp, 0, 0)
        End If
    End Sub

    Private Sub PbModel_Resize(sender As Object, e As EventArgs) Handles pbModel.Resize
        If bmp IsNot Nothing Then
            bmp.Dispose()
        End If
        If gr IsNot Nothing Then
            gr.Dispose()
        End If
        bmp = New Bitmap(pbModel.Width, pbModel.Height, pbModel.CreateGraphics)
        gr = Graphics.FromImage(bmp)
        DrawModel()
    End Sub

    Private Sub PbModel_MouseDown(sender As Object, e As MouseEventArgs) Handles pbModel.MouseDown
        If e.Button = MouseButtons.Left Then
            'zoom in
            zoom *= 1.1
        ElseIf e.Button = MouseButtons.Right Then
            zoom /= 1.1
        End If
        DrawModel()
    End Sub

    Private Sub ShowToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.DropDownOpening

        XToolStripMenuItem.Checked = False
        HRToolStripMenuItem.Checked = False
        SlToolStripMenuItem.Checked = False
        TToolStripMenuItem.Checked = False
        NaToolStripMenuItem.Checked = False
        ClToolStripMenuItem.Checked = False
        KToolStripMenuItem.Checked = False
        OHToolStripMenuItem.Checked = False
        CaToolStripMenuItem.Checked = False
        SO4ToolStripMenuItem.Checked = False

        Select Case ShowResult
            Case Results.None
                XToolStripMenuItem.Checked = True
            Case Results.HR
                HRToolStripMenuItem.Checked = True
            Case Results.Sl
                SlToolStripMenuItem.Checked = True
            Case Results.T
                TToolStripMenuItem.Checked = True
            Case Results.Na
                NaToolStripMenuItem.Checked = True
            Case Results.Cl
                ClToolStripMenuItem.Checked = True
            Case Results.K
                KToolStripMenuItem.Checked = True
            Case Results.OH
                OHToolStripMenuItem.Checked = True
            Case Results.Ca
                CaToolStripMenuItem.Checked = True
            Case Results.SO4
                SO4ToolStripMenuItem.Checked = True
        End Select

    End Sub

    Private Sub ModelToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles ModelToolStripMenuItem.DropDownOpening
        ShowModelToolStripMenuItem.Checked = ShowModel
        ShowDeformationsToolStripMenuItem.Checked = ShowDeformations
        ShowNodeNumbersToolStripMenuItem.Checked = ShowNodeNumbers
        ShowElementsOnDeformedShapeToolStripMenuItem.Checked = ShowElementsOnDeformedShape
    End Sub

    Private Sub PbModel_MouseWheel(sender As Object, e As MouseEventArgs) Handles pbModel.MouseWheel

        If e.Delta = 120 Then

            If vs.Value - vs.LargeChange >= 0 Then

                vs.Value -= vs.LargeChange

            ElseIf vs.Value - 1 >= 0 Then

                vs.Value -= 1

            End If

        Else

            If vs.Value + vs.LargeChange <= vs.Maximum Then

                vs.Value += vs.LargeChange

            ElseIf vs.Value + 1 <= vs.Maximum Then

                vs.Value += 1

            End If

        End If

        DrawModel()

    End Sub

    'Private Function getDeformationX(Node As Integer) As Double
    '    Dim dof As Integer = getDOFx(Node)
    '    Return Deformations(dof)
    'End Function
    'Private Function getDeformationY(Node As Integer) As Double
    '    Dim dof As Integer = getDOFy(Node)
    '    Return Deformations(dof)
    'End Function

    'Private Sub ResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResultsToolStripMenuItem.Click
    '    Dim d As New dlgResults
    '    Dim sb As New System.Text.StringBuilder
    '    Dim s As String
    '    Dim dof As Integer
    '    Dim i As Integer


    '    sb.AppendLine("Model Statistics:")
    '    sb.AppendLine("Number of Nodes: " & NNodes.ToString)
    '    sb.AppendLine("Number of Elements: " & NElements.ToString)
    '    sb.AppendLine("Number of Variables: " & (NNodes * 2).ToString)
    '    sb.AppendLine("")

    '    'Deformations
    '    sb.AppendLine("Deformations:")
    '    sb.AppendLine("Node" & vbTab & vbTab & "Ux" & vbTab & vbTab & "Uy")
    '    For i = 0 To NNodes - 1
    '        s = (i + 1).ToString & vbTab & vbTab
    '        dof = getDOFx(i)
    '        s = s & Deformations(dof).ToString & vbTab & vbTab
    '        s = s & Deformations(dof + 1).ToString

    '        sb.AppendLine(s)
    '    Next

    '    'Element Stresses and Strains
    '    sb.AppendLine("Stresses and Strains:")
    '    sb.AppendLine("Element" & vbTab & vbTab & "sx" & vbTab & vbTab & "sy" & vbTab & vbTab & "txy" &
    '    vbTab & vbTab & "ex" & vbTab & vbTab & "ey" & vbTab & vbTab & "gamma_xy")
    '    For i = 0 To NElements - 1
    '        s = (i + 1).ToString & vbTab & vbTab

    '        s = s & Elements(i).HR(0).ToString & vbTab & vbTab
    '        s = s & Elements(i).HR(1).ToString & vbTab & vbTab
    '        s = s & Elements(i).HR(2).ToString & vbTab & vbTab

    '        's = s & Elements(i).Strains(0).ToString & vbTab & vbTab
    '        's = s & Elements(i).Strains(1).ToString & vbTab & vbTab
    '        's = s & Elements(i).Strains(2).ToString

    '        sb.AppendLine(s)
    '    Next

    '    'Write maximum displacements
    '    Dim uxMax As Double = Double.MinValue
    '    Dim uyMax As Double = Double.MinValue
    '    Dim uxMin As Double = Double.MaxValue
    '    Dim uyMin As Double = Double.MaxValue

    '    For i = 0 To Deformations.Length - 1 Step 2
    '        If uxMax < Deformations(i) Then uxMax = Deformations(i)
    '        If uxMin > Deformations(i) Then uxMin = Deformations(i)
    '        If uyMax < Deformations(i + 1) Then uyMax = Deformations(i + 1)
    '        If uyMin > Deformations(i + 1) Then uyMin = Deformations(i + 1)
    '    Next

    '    sb.AppendLine("")
    '    sb.AppendLine("Maximum Displacement in X direction = " & uxMax.ToString)
    '    sb.AppendLine("Minimum Displacement in X direction = " & uxMin.ToString)
    '    sb.AppendLine("Maximum Displacement in Y direction = " & uyMax.ToString)
    '    sb.AppendLine("Minimum Displacement in Y direction = " & uyMin.ToString)

    '    sb.AppendLine("")
    '    sb.AppendLine("Output generated by btFEM at " & DateTime.Now.ToLongDateString)


    '    d.txtResults.Text = sb.ToString


    '    d.ShowDialog()

    'End Sub

    ' mechanical computations
    'Private Sub AnalyseMecha()
    '    'Calculate statistics
    '    Dim nDof As Integer = NNodes * 2


    '    'make global stiffness matrix
    '    'we create elemental stiffness matrix and place it in proper position
    '    'in the global stiffness matrix
    '    'saving as a square matrix would be too taxing on ram.
    '    'hence, we save the stiffness matrix in half band form

    '    Dim HalfBandWidth As Integer = getHalfBandWidth()
    '    Dim Kg(nDof - 1, HalfBandWidth - 1) As Double 'Global stiffness matrix

    '    Dim cst As CST
    '    Dim i As Integer
    '    For i = 0 To NElements - 1
    '        cst = New CST(Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
    '                      Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
    '                      Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
    '                      Thickness, ElasticityModulus, PoissonRatio)


    '        If testKe(cst.getKe) = False Then
    '            MsgBox("ke test failed")
    '        End If

    '        AssembleKg(cst.getKe, Kg, i)

    '    Next
    '    'now, we have assembled Kg in banded form

    '    'make the load vector
    '    Dim r(nDof - 1) As Double
    '    Dim dof As Integer 'dof
    '    For i = 0 To NPointLoads - 1
    '        dof = getDOFx(PointLoads(i).Node - 1)
    '        r(dof) += PointLoads(i).Fx

    '        dof = getDOFy(PointLoads(i).Node - 1)
    '        r(dof) += PointLoads(i).Fy

    '    Next


    '    'Apply boundary conditions by penalty approach
    '    Dim Large As Double
    '    Dim pow As Double = MaxKgiiPower(Kg)
    '    Large = 10 ^ (Math.Ceiling(pow) + 10)
    '    For i = 0 To NSupports - 1
    '        If Supports(i).RestraintX = 1 Then
    '            dof = getDOFx(Supports(i).Node - 1)
    '            Kg(dof, 0) = Kg(dof, 0) * Large
    '        End If
    '        If Supports(i).RestraintY = 1 Then
    '            dof = getDOFy(Supports(i).Node - 1)
    '            Kg(dof, 0) = Kg(dof, 0) * Large
    '        End If

    '    Next


    '    'Solve the set of equations to get displacements.

    '    'Deformations = SolveWithPivoting(Kg, r)


    '    Dim bs As New btGauss(Kg)
    '    bs.SolveSerial(r)
    '    Deformations = r

    '    'Now that we have deformations, lets calculate stresses and strains..
    '    SigmaXRange = New Range : SigmaYRange = New Range : TauXYRange = New Range
    '    EpsilonXRange = New Range : EpsilonYRange = New Range : GammaXYRange = New Range

    '    'first is to calculate strains
    '    'strain = [B] * d.
    '    'since the element is a constant strain triangle, the strain value will be 
    '    'constant for each element

    '    Dim B(2, 5) As Double
    '    Dim n1, n2, n3 As Integer
    '    Dim dofs(5) As Integer
    '    Dim disp(5) As Double
    '    Dim DMatrix(,) As Double
    '    Dim j As Integer
    '    For i = 0 To NElements - 1
    '        cst = New CST(Nodes(Elements(i).Node1 - 1).x, Nodes(Elements(i).Node1 - 1).y,
    '                      Nodes(Elements(i).Node2 - 1).x, Nodes(Elements(i).Node2 - 1).y,
    '                      Nodes(Elements(i).Node3 - 1).x, Nodes(Elements(i).Node3 - 1).y,
    '                      Thickness, ElasticityModulus, PoissonRatio)
    '        B = cst.getB

    '        'extract the connectivity nodes
    '        n1 = Elements(i).Node1 - 1
    '        n2 = Elements(i).Node2 - 1
    '        n3 = Elements(i).Node3 - 1

    '        'find the degree of freedoms associated
    '        dofs(0) = getDOFx(n1) : dofs(1) = getDOFy(n1)
    '        dofs(2) = getDOFx(n2) : dofs(3) = getDOFy(n2)
    '        dofs(4) = getDOFx(n3) : dofs(5) = getDOFy(n3)

    '        'extract the displacements
    '        For j = 0 To 5
    '            disp(j) = Deformations(dofs(j))
    '        Next

    '        'Calculate the strain vector
    '        'epsilon = {ex, ey, gamma xy}T
    '        Elements(i).Strains = MultiplyMatrixWithVector(B, disp)

    '        'Calculate stresses
    '        'Sigma = D * Epsilon
    '        DMatrix = cst.getD

    '        Elements(i).Stresses = MultiplyMatrixWithVector(DMatrix, Elements(i).Strains)
    '        SigmaXRange.AddValue(Elements(i).Stresses(0))
    '        SigmaYRange.AddValue(Elements(i).Stresses(1))
    '        TauXYRange.AddValue(Elements(i).Stresses(2))

    '        EpsilonXRange.AddValue(Elements(i).Strains(0))
    '        EpsilonYRange.AddValue(Elements(i).Strains(1))
    '        GammaXYRange.AddValue(Elements(i).Strains(2))

    '    Next

    '    'now, we have all results
    '    'enjoy! :o)

    'End Sub

End Class
