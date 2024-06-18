
Imports System
Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Public Class MDIChlor : Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'frm01 = New frmInput1D

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Public WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Public WithEvents mnuTop As System.Windows.Forms.MenuItem
    Public WithEvents _MnuProject_4 As System.Windows.Forms.MenuItem
    Public WithEvents _MnuProject_5 As System.Windows.Forms.MenuItem
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As MenuItem
    Friend WithEvents MenuItem11 As MenuItem
    Friend WithEvents MenuItem12 As MenuItem
    Friend WithEvents MenuItem14 As MenuItem
    Friend WithEvents MenuCalcul1D As MenuItem
    Friend WithEvents Calcul2D As MenuItem
    Friend WithEvents MenuItem17 As MenuItem
    Friend WithEvents MenuItem13 As MenuItem
    Friend WithEvents MenuItem15 As MenuItem
    Friend WithEvents MenuItem7 As MenuItem
    Friend WithEvents MenuItem16 As MenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ProgressBar As ToolStripProgressBar
    Friend WithEvents MainLabel As ToolStripStatusLabel
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuTop = New System.Windows.Forms.MenuItem()
        Me._MnuProject_4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem14 = New System.Windows.Forms.MenuItem()
        Me._MnuProject_5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuCalcul1D = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItem13 = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.Calcul2D = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.MenuItem16 = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.MenuItem12 = New System.Windows.Forms.MenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuItem17 = New System.Windows.Forms.MenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.MainLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
        Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.MainLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
        Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.MainLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuTop, Me.MenuItem1, Me.MenuItem5, Me.MenuItem13, Me.MenuItem3, Me.MenuItem10})
        '
        'mnuTop
        '
        Me.mnuTop.Index = 0
        Me.mnuTop.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._MnuProject_4, Me.MenuItem14, Me._MnuProject_5})
        Me.mnuTop.MergeType = System.Windows.Forms.MenuMerge.Remove
        Me.mnuTop.Text = "Project"
        '
        '_MnuProject_4
        '
        Me._MnuProject_4.Index = 0
        Me._MnuProject_4.MergeType = System.Windows.Forms.MenuMerge.Remove
        Me._MnuProject_4.Text = "-"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 1
        Me.MenuItem14.Text = "PhreeqC"
        '
        '_MnuProject_5
        '
        Me._MnuProject_5.Index = 2
        Me._MnuProject_5.MergeType = System.Windows.Forms.MenuMerge.Remove
        Me._MnuProject_5.Text = "E&xit"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem7})
        Me.MenuItem1.Text = "Climat"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Meteo File"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 1
        Me.MenuItem7.Text = "Expo Database"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 2
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem6, Me.MenuCalcul1D, Me.MenuItem8})
        Me.MenuItem5.Text = "Transport 1D"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 0
        Me.MenuItem6.Text = "Input 1D"
        '
        'MenuCalcul1D
        '
        Me.MenuCalcul1D.Index = 1
        Me.MenuCalcul1D.Text = "Calcul 1D"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 2
        Me.MenuItem8.Text = "Graph 1D"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 3
        Me.MenuItem13.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem15, Me.Calcul2D})
        Me.MenuItem13.Text = "Transport 2D "
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 0
        Me.MenuItem15.Text = "Input 2D"
        '
        'Calcul2D
        '
        Me.Calcul2D.Index = 1
        Me.Calcul2D.Text = "Calcul 2D"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 4
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem4, Me.MenuItem9, Me.MenuItem16})
        Me.MenuItem3.Text = "Probabilistic"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 0
        Me.MenuItem4.Text = "Analyse"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 1
        Me.MenuItem9.Text = "Graph Pf"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 2
        Me.MenuItem16.Text = "Graph A,B,C,D"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 5
        Me.MenuItem10.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem11, Me.MenuItem12})
        Me.MenuItem10.Text = "?"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 0
        Me.MenuItem11.Text = "Manual"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 1
        Me.MenuItem12.Text = "Version"
        '
        'MenuItem17
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 2
        Me.MenuItem16.Text = "Graph A,B,C,D"
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBar, Me.MainLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 423)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(773, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ProgressBar
        '
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'MainLabel
        '
        Me.MainLabel.Name = "MainLabel"
        Me.MainLabel.Size = New System.Drawing.Size(79, 17)
        Me.MainLabel.Text = "Work Folder ?"
        '
        'MDIChlor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(773, 445)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.Location = New System.Drawing.Point(11, 57)
        Me.Menu = Me.MainMenu1
        Me.Name = "MDIChlor"
        Me.Text = "TransChlor - Chloride Ion Penetration Model"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    'Public CPTerase As Short = 0
    Dim Para5 As Short = 0
    Public Prefile As String

    Dim frm2D As New FrmTrans2D

    'Dim diff As New DiffusionXC
    'Dim transport As New HydriqueXC
    'Dim directoryPath As String

    ' Xuande 10/06/2020
    'Private Nodes() As NodeTrans
    'Private Elements() As ElementTrans
    'Private NNodes, NElements, Nbloc As Integer
    'Private MeshFileOk = False

    'Lorsque la fenêtre est activée
    Private Sub MDIChlor_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        My.Application.ChangeCulture("en-US")
        Me.IsMdiContainer = True
        Me.WindowState = FormWindowState.Maximized

        frm2D.Left = 0
        frm2D.Top = 0
        frm2D.Height = (Me.Height)
        frm2D.Width = (Me.Width)
        frm2D.Hide()

    End Sub
    Private Sub _MnuProject_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _MnuProject_5.Click

        Me.Close()
        End

    End Sub

    'Ouverture de Input dans le menu déroulant
    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click

        Using frm As New frmInput1D
            frm.ShowDialog()
        End Using

    End Sub

    'Lancement de Open dans le menu déroulant
    Private Sub MenuCalcul1D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCalcul1D.Click

        Dim Creadtherm(1, 1) As Double
        Dim Creadhydr(1, 1) As Double
        Dim Creadion(1, 1) As Double
        Dim Nbre1 As Short
        Dim Nbre2 As Short
        Dim Nbre3 As Short

        Dim C1D As New Compute1D

        C1D.ReadFile(Nbre1, Nbre2, Nbre3, Creadtherm, Creadhydr, Creadion)

        C1D.InitialConditions(Nbre1, Nbre2, Nbre3, Creadtherm, Creadhydr, Creadion)

        C1D.InitFrmGraph()

        C1D.Compute_All()

        'Dim myThread As New System.Threading.Thread(AddressOf C1D.Compute_All)

        'If Para5 <> CShort(1) Then
        '    myThread.Start()
        'End If

    End Sub

    'construction de graphique
    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click

        Dim frmC As New frmGraph1D
        frmC.Left = 0
        frmC.Top = 0
        frmC.Height = (Me.Height)
        frmC.Width = (Me.Width)

        Using frm03 As New frmGraph1DScale
            frmC.MdiParent = Me
            frmC.Show()
            manage_graph(frmC, frm03)
        End Using

    End Sub

    'traitement des données météorologiques
    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click

        MeteoTreatment()

    End Sub

    'lancement de l'approche probabiliste
    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click

        Using frm03 As New frmProb
            frm03.ShowDialog()
        End Using

    End Sub

    'lancement du traitement graphique des probabilités
    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click

        Dim frmC As New frmGraph1D
        frmC.Left = 0
        frmC.Top = 0
        frmC.Height = (Me.Height)
        frmC.Width = (Me.Width)

        Dim frm03 As New frmGraph1DScale
        frmC.MdiParent = Me
        frmC.Show()
        ProbGraphPf(frmC, frm03)

    End Sub

    Private Sub MenuItem12_Click(sender As Object, e As EventArgs) Handles MenuItem12.Click 'Thomas 28/04/2020

        Using frm04 As New frmSplash
            frm04.ShowDialog()
        End Using

    End Sub

    Private Sub MenuItem11_Click(sender As Object, e As EventArgs) Handles MenuItem11.Click 'Thomas 28/04/2020

        Dim manual As Byte() = My.Resources.ModeEmploi_v4
        Using tmp As New FileStream("ModeEmploi_v4.pdf", FileMode.Create)
            tmp.Write(manual, 0, manual.Length)
        End Using
        Process.Start("ModeEmploi_v4.pdf")

    End Sub

    'Private Sub MenuItem13_Click(sender As Object, e As EventArgs) Handles MenuItem13.Click
    '    Using frm04 As New frmMesh
    '        frm04.ShowDialog()
    '    End Using
    'End Sub
    'Lecture du module PhreeqC
    Private Sub MenuItem14_Click(sender As Object, e As EventArgs) Handles MenuItem14.Click

        Using frm As New frmPhreeqC
            frm.ShowDialog()
        End Using

    End Sub

    'Lecture du module FEM mechical analyse
    'Private Sub MenuItem15_Click(sender As Object, e As EventArgs) Handles MenuItem15.Click
    '    Using frm04 As New frmbtFem
    '        frm04.ShowDialog()
    '    End Using
    'End Sub

    'Operation pour calcul diffusion 2D  'Xuande 30/06/2020
    Private Sub Calcul2DMenuItem_Click(sender As Object, e As EventArgs) Handles Calcul2D.Click

        ''Lecture du fichier Maillage dans le menu 'Xuande 10/06/2020
        'Dim d As New OpenFileDialog
        'Dim directoryPath As String
        'd.Title = "Open Mesh file"
        'd.Filter = "Mesh files (*.msh)|*.msh"

        'If d.ShowDialog = DialogResult.OK Then

        '    If ReadFile(d.FileName) = False Then
        '        MsgBox("Error with Mesh file.", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "Mesh file")
        '        MeshFileOk = False
        '    ElseIf ReadFile(d.FileName) = True Then
        '        MsgBox("Mesh file imported successfully!", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "Mesh file")
        '        MeshFileOk = True
        '    End If
        '    'DrawModel()

        'End If

        'directoryPath = Path.GetDirectoryName(d.FileName) ' Thomas : Ligne pour récuperer le chemin du fichier

        ''check if there is a proper model
        'If NElements <= 0 OrElse NNodes <= 0 Then
        '    'there are no elements defined
        '    MsgBox("Error reading number of elements and nodes, please open a proper mesh file")
        'Else
        '    MsgBox("Mesh file ready for simulation!", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "Mesh file")
        '    'perform analysis using the 2D finite element diffusion module 
        '    diff.Analyse(NNodes, NElements, Nodes, Elements)
        '    Return

        'End If

        frm2D.MdiParent = Me
        frm2D.Show()

        'Using frm04 As New frmbtFem
        'frm04.ShowDialog()
        'End Using

    End Sub

    Private Sub MenuItem15_Click(sender As Object, e As EventArgs) Handles MenuItem15.Click

        Using frm As New frmInput2D
            frm.ShowDialog()
        End Using

    End Sub

    Private Sub MenuItem7_Click(sender As Object, e As EventArgs) Handles MenuItem7.Click

        Using frm As New FrmMeteoDatabase
            frm.ShowDialog()
        End Using

    End Sub

    Private Sub MenuItem16_Click(sender As Object, e As EventArgs) Handles MenuItem16.Click

        Dim frmC As New frmGraph1D
        frmC.Left = 0
        frmC.Top = 0
        frmC.Height = (Me.Height)
        frmC.Width = (Me.Width)
        frmC.MdiParent = Me
        frmC.Show()
        ProbGraphABCD(frmC)

    End Sub

    Public Sub ChangeProgressBar(ByRef value As Double)

        ProgressBar.Value = value
        Me.Refresh()

    End Sub

    Public Sub ChangeMainLabel(ByRef text As String)

        MainLabel.Text = text
        Me.Refresh()

    End Sub

    Private Sub MainLabel_Click(sender As Object, e As EventArgs) Handles MainLabel.Click
        Dim folderDlg As New FolderBrowserDialog With {
            .ShowNewFolderButton = True
        }

        If (folderDlg.ShowDialog() = DialogResult.OK) Then

            Dim WorkFolder As String = folderDlg.SelectedPath + "\"
            ChangeMainLabel(WorkFolder)

            Dim root As Environment.SpecialFolder = folderDlg.RootFolder

        End If
    End Sub

    'Operation pour calcul diffusion 2D  'Xuande 30/06/2020
    'Private Sub Diff2DToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Diff2D.Click
    '    'check if there is a proper model
    '    If NElements <= 0 OrElse NNodes <= 0 Then
    '        'there are no elements defined
    '        MsgBox("Error reading number of elements and nodes, please open a proper mesh file")
    '    Else
    '        MsgBox("Mesh file ready for simulation!", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "Mesh file")
    '        'perform analysis using the 2D finite element diffusion module 
    '        diff.Analyse(NNodes, NElements, Nodes, Elements, directoryPath)
    '        Return

    '    End If
    'End Sub
    'Operation pour transport diffusion 2D  'Xuande 27/07/2020
    'Private Sub MenuItem17_Click(sender As Object, e As EventArgs) Handles MenuItem17.Click
    '    'check if there is a proper model
    '    If NElements <= 0 OrElse NNodes <= 0 Then
    '        'there are no elements defined
    '        MsgBox("Error reading number of elements and nodes, please open a proper mesh file")
    '    Else
    '        MsgBox("Mesh file ready for simulation!", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "Mesh file")
    '        'perform analysis using the 2D finite element transport module 
    '        transport.Analyse(NNodes, NElements, Nodes, Elements, directoryPath)
    '        Return
    '    End If
    'End Sub
    'Lecture de fichier .msh 'Xuande  10/06/2020
    'Public Function ReadFile(f As String) As Boolean
    '    Try

    '        Dim sr As New StreamReader(f)
    '        Dim s As String
    '        Dim Arr(0) As String
    '        Dim Temp As String
    '        Dim i As Integer
    '        Dim j As Integer
    '        Dim jj As Integer
    '        Dim k As Integer
    '        Dim NN(0) As Integer
    '        Dim XX(0), YY(0), ZZ(0) As Double
    '        Dim n0 As Integer
    '        Dim n, n1, n2, n3, n4 As Integer
    '        Dim x, y, z As Double
    '        Dim brd As Boolean
    '        Dim bloc_node As Integer
    '        Dim bloc_type As Integer
    '        Dim bloc_element As Integer

    '        'Skip the version data
    '        Temp = readLine(sr)

    '        'Skip the unnecessary first few lines
    '        Do While Temp <> "$Nodes"
    '            Temp = sr.ReadLine.Trim
    '        Loop

    '        'Read total number of nodes and blocks 
    '        s = readLine(sr)
    '        Arr = Split(s, " "c)
    '        Try
    '            Nbloc = Integer.Parse(Arr(0))
    '            NNodes = Integer.Parse(Arr(1))
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '            Return False
    '        End Try

    '        'Read node coordinates block by block
    '        ReDim Nodes(NNodes - 1)
    '        For i = 0 To Nbloc - 1
    '            'read bloc information for how many nodes should be read inside
    '            s = readLine(sr)
    '            Arr = Split(s, " "c)
    '            bloc_type = Integer.Parse(Arr(0))
    '            bloc_node = Integer.Parse(Arr(3))
    '            ReDim NN(bloc_node - 1)
    '            ReDim XX(bloc_node - 1)
    '            ReDim YY(bloc_node - 1)
    '            ReDim ZZ(bloc_node - 1)
    '            For j = 0 To bloc_node - 1
    '                'read first lines of node number
    '                s = readLine(sr)
    '                Arr = Split(s, " "c)
    '                n = Integer.Parse(Arr(0))
    '                NN(j) = n
    '            Next
    '            'read corresponding lines of coordinates
    '            For k = 0 To bloc_node - 1
    '                'judging wether points of current block belongs to the boundary
    '                If bloc_type <= 1 Then
    '                    brd = True
    '                Else
    '                    brd = False
    '                End If
    '                'read corresponding lines of coordinates
    '                s = readLine(sr)
    '                Arr = Split(s, " "c)
    '                x = Arr(0)
    '                XX(k) = x
    '                y = Arr(1)
    '                YY(k) = y
    '                z = Arr(2)
    '                ZZ(k) = z
    '                Nodes(NN(k) - 1) = New NodeTrans(NN(k), XX(k), YY(k), ZZ(k), brd)
    '            Next
    '        Next

    '        'Read total number of elements and blocks 
    '        s = readLine(sr)
    '        Arr = Split(s, " "c)
    '        Try
    '            Nbloc = Integer.Parse(Arr(0))
    '            NElements = Integer.Parse(Arr(1))
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '            Return False
    '        End Try

    '        'Read element connectivity block by block
    '        For i = 0 To Nbloc - 1
    '            'read bloc information for how many nodes should be read inside
    '            s = readLine(sr)
    '            Arr = Split(s, " "c)
    '            bloc_type = Integer.Parse(Arr(0))
    '            bloc_element = Integer.Parse(Arr(3))
    '            If bloc_type = 0 Then
    '                Temp = readLine(sr)
    '            End If

    '            If bloc_type = 1 Then
    '                For j = 0 To bloc_element - 1
    '                    Temp = readLine(sr)
    '                    Arr = Split(Temp, " "c)
    '                    n0 = Integer.Parse(Arr(0))
    '                Next
    '            End If

    '            If bloc_type = 2 Then
    '                NElements = bloc_element
    '                ReDim Elements(NElements - 1)
    '                For jj = 0 To bloc_element - 1
    '                    s = readLine(sr)
    '                    Arr = Split(s, " "c)
    '                    n = Integer.Parse(Arr(0)) - n0
    '                    n1 = Integer.Parse(Arr(1))
    '                    n2 = Integer.Parse(Arr(2))
    '                    n3 = Integer.Parse(Arr(3))
    '                    n4 = Integer.Parse(Arr(4))
    '                    Elements(jj) = New ElementTrans(n, n1, n2, n3, n4)
    '                Next
    '            End If

    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try
    '    Return True
    'End Function
    ''Fonction readline  'Xuande  10/06/2020
    'Private Function readLine(ByRef sr As StreamReader) As String
    '    Dim s As String
    '    If sr.EndOfStream = True Then Return ""
    '    While sr.EndOfStream = False
    '        s = sr.ReadLine.Trim
    '        If s.Length > 0 Then
    '            If s.Substring(0, 1) <> "$" Then
    '                Return s
    '            End If
    '        End If
    '    End While
    '    Return ""
    'End Function
End Class