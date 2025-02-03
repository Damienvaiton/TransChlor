Public Class frmMeteo : Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents ButtonExportFile As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown6 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown7 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown8 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown9 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown10 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown11 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown12 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown13 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown14 As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown15 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown16 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown17 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown18 As System.Windows.Forms.NumericUpDown
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown19 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown20 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown21 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown22 As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown23 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown24 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown25 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label78 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ButtonExportFile = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown25 = New System.Windows.Forms.NumericUpDown()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.NumericUpDown23 = New System.Windows.Forms.NumericUpDown()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.NumericUpDown24 = New System.Windows.Forms.NumericUpDown()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown6 = New System.Windows.Forms.NumericUpDown()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.NumericUpDown11 = New System.Windows.Forms.NumericUpDown()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.NumericUpDown12 = New System.Windows.Forms.NumericUpDown()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.NumericUpDown13 = New System.Windows.Forms.NumericUpDown()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.NumericUpDown14 = New System.Windows.Forms.NumericUpDown()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.NumericUpDown9 = New System.Windows.Forms.NumericUpDown()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.NumericUpDown10 = New System.Windows.Forms.NumericUpDown()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.NumericUpDown8 = New System.Windows.Forms.NumericUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.NumericUpDown7 = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.NumericUpDown15 = New System.Windows.Forms.NumericUpDown()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.NumericUpDown16 = New System.Windows.Forms.NumericUpDown()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.NumericUpDown17 = New System.Windows.Forms.NumericUpDown()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.NumericUpDown18 = New System.Windows.Forms.NumericUpDown()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.NumericUpDown19 = New System.Windows.Forms.NumericUpDown()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.NumericUpDown20 = New System.Windows.Forms.NumericUpDown()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.NumericUpDown21 = New System.Windows.Forms.NumericUpDown()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.NumericUpDown22 = New System.Windows.Forms.NumericUpDown()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.NumericUpDown25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown24, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumericUpDown11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumericUpDown15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown22, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonExportFile
        '
        Me.ButtonExportFile.Location = New System.Drawing.Point(665, 580)
        Me.ButtonExportFile.Name = "ButtonExportFile"
        Me.ButtonExportFile.Size = New System.Drawing.Size(105, 32)
        Me.ButtonExportFile.TabIndex = 13
        Me.ButtonExportFile.Text = "Export File"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown6)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown5)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 600)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "hypothèses sur l'épandage des chlorures de sodium"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.NumericUpDown25)
        Me.GroupBox5.Controls.Add(Me.Label78)
        Me.GroupBox5.Controls.Add(Me.Label65)
        Me.GroupBox5.Controls.Add(Me.Label66)
        Me.GroupBox5.Controls.Add(Me.NumericUpDown23)
        Me.GroupBox5.Controls.Add(Me.Label67)
        Me.GroupBox5.Controls.Add(Me.Label68)
        Me.GroupBox5.Controls.Add(Me.Label69)
        Me.GroupBox5.Controls.Add(Me.Label70)
        Me.GroupBox5.Controls.Add(Me.Label71)
        Me.GroupBox5.Controls.Add(Me.Label72)
        Me.GroupBox5.Controls.Add(Me.NumericUpDown24)
        Me.GroupBox5.Controls.Add(Me.Label73)
        Me.GroupBox5.Controls.Add(Me.Label74)
        Me.GroupBox5.Controls.Add(Me.Label75)
        Me.GroupBox5.Controls.Add(Me.Label76)
        Me.GroupBox5.Controls.Add(Me.Label77)
        Me.GroupBox5.Location = New System.Drawing.Point(10, 370)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(420, 220)
        Me.GroupBox5.TabIndex = 68
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Epandage automatique"
        '
        'NumericUpDown25
        '
        Me.NumericUpDown25.Location = New System.Drawing.Point(300, 110)
        Me.NumericUpDown25.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown25.Name = "NumericUpDown25"
        Me.NumericUpDown25.Size = New System.Drawing.Size(60, 20)
        Me.NumericUpDown25.TabIndex = 93
        Me.NumericUpDown25.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'Label78
        '
        Me.Label78.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.Location = New System.Drawing.Point(10, 110)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(300, 20)
        Me.Label78.TabIndex = 92
        Me.Label78.Text = "Nombre de giclages sur un intervalle de temps"
        '
        'Label65
        '
        Me.Label65.Location = New System.Drawing.Point(380, 190)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(30, 20)
        Me.Label65.TabIndex = 91
        Me.Label65.Text = "[°C]"
        '
        'Label66
        '
        Me.Label66.Location = New System.Drawing.Point(330, 190)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(40, 20)
        Me.Label66.TabIndex = 90
        '
        'NumericUpDown23
        '
        Me.NumericUpDown23.Location = New System.Drawing.Point(300, 140)
        Me.NumericUpDown23.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown23.Name = "NumericUpDown23"
        Me.NumericUpDown23.Size = New System.Drawing.Size(60, 20)
        Me.NumericUpDown23.TabIndex = 89
        Me.NumericUpDown23.Value = New Decimal(New Integer() {21, 0, 0, 0})
        '
        'Label67
        '
        Me.Label67.Location = New System.Drawing.Point(100, 160)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(140, 20)
        Me.Label67.TabIndex = 88
        Me.Label67.Text = "Si épandage solide (100%)"
        '
        'Label68
        '
        Me.Label68.Location = New System.Drawing.Point(380, 140)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(30, 20)
        Me.Label68.TabIndex = 87
        Me.Label68.Text = "[%]"
        '
        'Label69
        '
        Me.Label69.Location = New System.Drawing.Point(370, 20)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(64, 20)
        Me.Label69.TabIndex = 86
        Me.Label69.Text = " [g/m2]"
        '
        'Label70
        '
        Me.Label70.Location = New System.Drawing.Point(370, 50)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(60, 20)
        Me.Label70.TabIndex = 83
        Me.Label70.Text = " [g/m2]"
        '
        'Label71
        '
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(10, 140)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(300, 30)
        Me.Label71.TabIndex = 85
        Me.Label71.Text = "Concentration de chlorure de sodium dans l'eau (épandage)"
        '
        'Label72
        '
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(10, 50)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(280, 16)
        Me.Label72.TabIndex = 84
        Me.Label72.Text = "Quantité moyenne de chlorure de sodium épandue"
        '
        'NumericUpDown24
        '
        Me.NumericUpDown24.DecimalPlaces = 2
        Me.NumericUpDown24.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDown24.Location = New System.Drawing.Point(300, 50)
        Me.NumericUpDown24.Name = "NumericUpDown24"
        Me.NumericUpDown24.Size = New System.Drawing.Size(60, 20)
        Me.NumericUpDown24.TabIndex = 82
        Me.NumericUpDown24.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'Label73
        '
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.Location = New System.Drawing.Point(10, 190)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(230, 16)
        Me.Label73.TabIndex = 81
        Me.Label73.Text = "Température seuil d'intervention (calculé)"
        '
        'Label74
        '
        Me.Label74.Location = New System.Drawing.Point(320, 20)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(50, 20)
        Me.Label74.TabIndex = 80
        Me.Label74.Text = "0"
        '
        'Label75
        '
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.Location = New System.Drawing.Point(10, 20)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(310, 16)
        Me.Label75.TabIndex = 79
        Me.Label75.Text = "Concentration annuelle en chlorure de sodium équivalent"
        '
        'Label76
        '
        Me.Label76.Location = New System.Drawing.Point(330, 80)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(40, 20)
        Me.Label76.TabIndex = 78
        '
        'Label77
        '
        Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.Location = New System.Drawing.Point(10, 80)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(290, 16)
        Me.Label77.TabIndex = 77
        Me.Label77.Text = "Nombre de giclages annuel"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.NumericUpDown4)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.Label31)
        Me.GroupBox4.Controls.Add(Me.Label30)
        Me.GroupBox4.Controls.Add(Me.Label29)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 150)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(420, 220)
        Me.GroupBox4.TabIndex = 67
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Epandage mécanique"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(380, 190)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 20)
        Me.Label18.TabIndex = 76
        Me.Label18.Text = "[°C]"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(330, 190)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 20)
        Me.Label22.TabIndex = 75
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.Location = New System.Drawing.Point(320, 140)
        Me.NumericUpDown4.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown4.TabIndex = 74
        Me.NumericUpDown4.Value = New Decimal(New Integer() {36, 0, 0, 0})
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(90, 160)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(140, 20)
        Me.Label20.TabIndex = 73
        Me.Label20.Text = "Si épandage solide (100%)"
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(380, 140)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(30, 20)
        Me.Label31.TabIndex = 72
        Me.Label31.Text = "[%]"
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(380, 110)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 20)
        Me.Label30.TabIndex = 71
        Me.Label30.Text = "[h]"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(370, 20)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(74, 20)
        Me.Label29.TabIndex = 70
        Me.Label29.Text = " [g/m2]"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(370, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 20)
        Me.Label14.TabIndex = 67
        Me.Label14.Text = " [g/m2]"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(10, 140)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(300, 30)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "Concentration de chlorure de sodium dans l'eau (épandage)"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(280, 16)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "Quantité moyenne de chlorure de sodium épandue"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.DecimalPlaces = 1
        Me.NumericUpDown1.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown1.Location = New System.Drawing.Point(320, 50)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(48, 20)
        Me.NumericUpDown1.TabIndex = 66
        Me.NumericUpDown1.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(230, 16)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Température seuil d'intervention (calculé)"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(320, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 20)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "0"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(310, 16)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Concentration annuelle en chlorure de sodium équivalent"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(220, 16)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Intervalle minimal entre 2 interventions"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(330, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 20)
        Me.Label6.TabIndex = 61
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(300, 16)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Nombre d'interventions d'épandage de chlorure annuel"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.DecimalPlaces = 1
        Me.NumericUpDown2.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.NumericUpDown2.Location = New System.Drawing.Point(320, 110)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {48, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(48, 20)
        Me.NumericUpDown2.TabIndex = 59
        Me.NumericUpDown2.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'NumericUpDown6
        '
        Me.NumericUpDown6.DecimalPlaces = 3
        Me.NumericUpDown6.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown6.Location = New System.Drawing.Point(330, 50)
        Me.NumericUpDown6.Name = "NumericUpDown6"
        Me.NumericUpDown6.Size = New System.Drawing.Size(60, 20)
        Me.NumericUpDown6.TabIndex = 65
        Me.NumericUpDown6.Value = New Decimal(New Integer() {1, 0, 0, 196608})
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(400, 50)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(30, 20)
        Me.Label24.TabIndex = 63
        Me.Label24.Text = "[%]"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(10, 50)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(280, 16)
        Me.Label25.TabIndex = 62
        Me.Label25.Text = "Concentration de chlorure de sodium au temps t=0"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(400, 80)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 20)
        Me.Label19.TabIndex = 61
        Me.Label19.Text = "[mm]"
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.DecimalPlaces = 1
        Me.NumericUpDown5.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericUpDown5.Location = New System.Drawing.Point(330, 80)
        Me.NumericUpDown5.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown5.TabIndex = 60
        Me.NumericUpDown5.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(10, 80)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(320, 20)
        Me.Label21.TabIndex = 59
        Me.Label21.Text = "Epaisseur du film d'eau sur la chaussée"
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(400, 110)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(30, 20)
        Me.Label32.TabIndex = 56
        Me.Label32.Text = "[%]"
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown3.Location = New System.Drawing.Point(330, 110)
        Me.NumericUpDown3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown3.TabIndex = 52
        Me.NumericUpDown3.Value = New Decimal(New Integer() {95, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(390, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 20)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "[ans]"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(440, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 20)
        Me.Label15.TabIndex = 48
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(440, 80)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 20)
        Me.Label16.TabIndex = 47
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(440, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 20)
        Me.Label10.TabIndex = 43
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(330, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 20)
        Me.Label12.TabIndex = 42
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(320, 30)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Humidité relative seuil d'intervention en cas de basses températures"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(440, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 20)
        Me.Label5.TabIndex = 39
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(180, 16)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Nombre d'années (fichier météo)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.Label38)
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.Label40)
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown11)
        Me.GroupBox2.Controls.Add(Me.Label42)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown12)
        Me.GroupBox2.Controls.Add(Me.Label43)
        Me.GroupBox2.Controls.Add(Me.Label44)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown13)
        Me.GroupBox2.Controls.Add(Me.Label45)
        Me.GroupBox2.Controls.Add(Me.Label46)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown14)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.Label36)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown9)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown10)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown8)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown7)
        Me.GroupBox2.Location = New System.Drawing.Point(460, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(440, 260)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Atténuation du signal (extérieur)"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(190, 230)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(80, 20)
        Me.TextBox2.TabIndex = 74
        Me.TextBox2.Text = "100"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(280, 230)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(30, 20)
        Me.Label38.TabIndex = 73
        Me.Label38.Text = "[1/%]"
        '
        'Label39
        '
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(10, 230)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(180, 16)
        Me.Label39.TabIndex = 72
        Me.Label39.Text = "Différence d'humidité relative limite"
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(200, 200)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(10, 20)
        Me.Label40.TabIndex = 70
        Me.Label40.Text = "/"
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(10, 200)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(130, 16)
        Me.Label41.TabIndex = 71
        Me.Label41.Text = "Atténuation de"
        '
        'NumericUpDown11
        '
        Me.NumericUpDown11.Location = New System.Drawing.Point(150, 200)
        Me.NumericUpDown11.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown11.Name = "NumericUpDown11"
        Me.NumericUpDown11.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown11.TabIndex = 69
        Me.NumericUpDown11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown11.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(280, 200)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(120, 20)
        Me.Label42.TabIndex = 68
        Me.Label42.Text = "de la différence de HR"
        '
        'NumericUpDown12
        '
        Me.NumericUpDown12.Location = New System.Drawing.Point(220, 200)
        Me.NumericUpDown12.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown12.Name = "NumericUpDown12"
        Me.NumericUpDown12.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown12.TabIndex = 67
        Me.NumericUpDown12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown12.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(200, 170)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(10, 20)
        Me.Label43.TabIndex = 65
        Me.Label43.Text = "/"
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(10, 170)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(140, 16)
        Me.Label44.TabIndex = 66
        Me.Label44.Text = "Position de la moyenne au "
        '
        'NumericUpDown13
        '
        Me.NumericUpDown13.Location = New System.Drawing.Point(150, 170)
        Me.NumericUpDown13.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown13.Name = "NumericUpDown13"
        Me.NumericUpDown13.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown13.TabIndex = 64
        Me.NumericUpDown13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown13.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(280, 170)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(100, 20)
        Me.Label45.TabIndex = 62
        Me.Label45.Text = "des 2 extremums"
        '
        'Label46
        '
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(10, 140)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(110, 16)
        Me.Label46.TabIndex = 63
        Me.Label46.Text = "Humidité relative"
        '
        'NumericUpDown14
        '
        Me.NumericUpDown14.Location = New System.Drawing.Point(220, 170)
        Me.NumericUpDown14.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown14.Name = "NumericUpDown14"
        Me.NumericUpDown14.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown14.TabIndex = 61
        Me.NumericUpDown14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown14.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(190, 110)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(80, 20)
        Me.TextBox1.TabIndex = 60
        Me.TextBox1.Text = "100"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(280, 110)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(40, 20)
        Me.Label37.TabIndex = 59
        Me.Label37.Text = "[1/°C]"
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(10, 110)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(170, 16)
        Me.Label36.TabIndex = 58
        Me.Label36.Text = "Différence de température limite"
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(200, 80)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(10, 20)
        Me.Label33.TabIndex = 56
        Me.Label33.Text = "/"
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(10, 80)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(130, 16)
        Me.Label34.TabIndex = 57
        Me.Label34.Text = "Atténuation de"
        '
        'NumericUpDown9
        '
        Me.NumericUpDown9.Location = New System.Drawing.Point(150, 80)
        Me.NumericUpDown9.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown9.Name = "NumericUpDown9"
        Me.NumericUpDown9.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown9.TabIndex = 55
        Me.NumericUpDown9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown9.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(280, 80)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(110, 20)
        Me.Label35.TabIndex = 54
        Me.Label35.Text = "de la différence de T"
        '
        'NumericUpDown10
        '
        Me.NumericUpDown10.Location = New System.Drawing.Point(220, 80)
        Me.NumericUpDown10.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown10.Name = "NumericUpDown10"
        Me.NumericUpDown10.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown10.TabIndex = 53
        Me.NumericUpDown10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown10.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(200, 50)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(10, 20)
        Me.Label27.TabIndex = 51
        Me.Label27.Text = "/"
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(10, 50)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(140, 16)
        Me.Label28.TabIndex = 52
        Me.Label28.Text = "Position de la moyenne au "
        '
        'NumericUpDown8
        '
        Me.NumericUpDown8.Location = New System.Drawing.Point(150, 50)
        Me.NumericUpDown8.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown8.Name = "NumericUpDown8"
        Me.NumericUpDown8.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown8.TabIndex = 50
        Me.NumericUpDown8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown8.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(280, 50)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 20)
        Me.Label23.TabIndex = 48
        Me.Label23.Text = "des 2 extremums"
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(10, 20)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 16)
        Me.Label26.TabIndex = 49
        Me.Label26.Text = "Température"
        '
        'NumericUpDown7
        '
        Me.NumericUpDown7.Location = New System.Drawing.Point(220, 50)
        Me.NumericUpDown7.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown7.Name = "NumericUpDown7"
        Me.NumericUpDown7.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown7.TabIndex = 47
        Me.NumericUpDown7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown7.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.Label47)
        Me.GroupBox3.Controls.Add(Me.Label48)
        Me.GroupBox3.Controls.Add(Me.Label49)
        Me.GroupBox3.Controls.Add(Me.Label50)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown15)
        Me.GroupBox3.Controls.Add(Me.Label51)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown16)
        Me.GroupBox3.Controls.Add(Me.Label52)
        Me.GroupBox3.Controls.Add(Me.Label53)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown17)
        Me.GroupBox3.Controls.Add(Me.Label54)
        Me.GroupBox3.Controls.Add(Me.Label55)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown18)
        Me.GroupBox3.Controls.Add(Me.TextBox4)
        Me.GroupBox3.Controls.Add(Me.Label56)
        Me.GroupBox3.Controls.Add(Me.Label57)
        Me.GroupBox3.Controls.Add(Me.Label58)
        Me.GroupBox3.Controls.Add(Me.Label59)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown19)
        Me.GroupBox3.Controls.Add(Me.Label60)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown20)
        Me.GroupBox3.Controls.Add(Me.Label61)
        Me.GroupBox3.Controls.Add(Me.Label62)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown21)
        Me.GroupBox3.Controls.Add(Me.Label63)
        Me.GroupBox3.Controls.Add(Me.Label64)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown22)
        Me.GroupBox3.Location = New System.Drawing.Point(460, 310)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(440, 260)
        Me.GroupBox3.TabIndex = 49
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Atténuation du signal (intérieur caisson)"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(190, 230)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(80, 20)
        Me.TextBox3.TabIndex = 74
        Me.TextBox3.Text = "100"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(280, 230)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(30, 20)
        Me.Label47.TabIndex = 73
        Me.Label47.Text = "[1/%]"
        '
        'Label48
        '
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(10, 230)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(180, 16)
        Me.Label48.TabIndex = 72
        Me.Label48.Text = "Différence d'humidité relative limite"
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(200, 200)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(10, 20)
        Me.Label49.TabIndex = 70
        Me.Label49.Text = "/"
        '
        'Label50
        '
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(10, 200)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(120, 16)
        Me.Label50.TabIndex = 71
        Me.Label50.Text = "Atténuation de"
        '
        'NumericUpDown15
        '
        Me.NumericUpDown15.Location = New System.Drawing.Point(150, 200)
        Me.NumericUpDown15.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown15.Name = "NumericUpDown15"
        Me.NumericUpDown15.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown15.TabIndex = 69
        Me.NumericUpDown15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown15.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(280, 200)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(120, 20)
        Me.Label51.TabIndex = 68
        Me.Label51.Text = "de la différence de HR"
        '
        'NumericUpDown16
        '
        Me.NumericUpDown16.Location = New System.Drawing.Point(220, 200)
        Me.NumericUpDown16.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown16.Name = "NumericUpDown16"
        Me.NumericUpDown16.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown16.TabIndex = 67
        Me.NumericUpDown16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown16.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label52
        '
        Me.Label52.Location = New System.Drawing.Point(200, 170)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(10, 20)
        Me.Label52.TabIndex = 65
        Me.Label52.Text = "/"
        '
        'Label53
        '
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(10, 170)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(140, 16)
        Me.Label53.TabIndex = 66
        Me.Label53.Text = "Position de la moyenne au "
        '
        'NumericUpDown17
        '
        Me.NumericUpDown17.Location = New System.Drawing.Point(150, 170)
        Me.NumericUpDown17.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown17.Name = "NumericUpDown17"
        Me.NumericUpDown17.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown17.TabIndex = 64
        Me.NumericUpDown17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown17.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(280, 170)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(100, 20)
        Me.Label54.TabIndex = 62
        Me.Label54.Text = "des 2 extremums"
        '
        'Label55
        '
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(10, 140)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(110, 16)
        Me.Label55.TabIndex = 63
        Me.Label55.Text = "Humidité relative"
        '
        'NumericUpDown18
        '
        Me.NumericUpDown18.Location = New System.Drawing.Point(220, 170)
        Me.NumericUpDown18.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown18.Name = "NumericUpDown18"
        Me.NumericUpDown18.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown18.TabIndex = 61
        Me.NumericUpDown18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown18.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(190, 110)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(80, 20)
        Me.TextBox4.TabIndex = 60
        Me.TextBox4.Text = "100"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(280, 110)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(40, 20)
        Me.Label56.TabIndex = 59
        Me.Label56.Text = "[1/°C]"
        '
        'Label57
        '
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(10, 110)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(170, 16)
        Me.Label57.TabIndex = 58
        Me.Label57.Text = "Différence de température limite"
        '
        'Label58
        '
        Me.Label58.Location = New System.Drawing.Point(200, 80)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(10, 20)
        Me.Label58.TabIndex = 56
        Me.Label58.Text = "/"
        '
        'Label59
        '
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(10, 80)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(130, 16)
        Me.Label59.TabIndex = 57
        Me.Label59.Text = "Atténuation de"
        '
        'NumericUpDown19
        '
        Me.NumericUpDown19.Location = New System.Drawing.Point(150, 80)
        Me.NumericUpDown19.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown19.Name = "NumericUpDown19"
        Me.NumericUpDown19.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown19.TabIndex = 55
        Me.NumericUpDown19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown19.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label60
        '
        Me.Label60.Location = New System.Drawing.Point(280, 80)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(110, 20)
        Me.Label60.TabIndex = 54
        Me.Label60.Text = "de la différence de T"
        '
        'NumericUpDown20
        '
        Me.NumericUpDown20.Location = New System.Drawing.Point(220, 80)
        Me.NumericUpDown20.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown20.Name = "NumericUpDown20"
        Me.NumericUpDown20.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown20.TabIndex = 53
        Me.NumericUpDown20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown20.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Label61
        '
        Me.Label61.Location = New System.Drawing.Point(200, 50)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(10, 20)
        Me.Label61.TabIndex = 51
        Me.Label61.Text = "/"
        '
        'Label62
        '
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(10, 50)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(140, 16)
        Me.Label62.TabIndex = 52
        Me.Label62.Text = "Position de la moyenne au "
        '
        'NumericUpDown21
        '
        Me.NumericUpDown21.Location = New System.Drawing.Point(150, 50)
        Me.NumericUpDown21.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown21.Name = "NumericUpDown21"
        Me.NumericUpDown21.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown21.TabIndex = 50
        Me.NumericUpDown21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown21.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label63
        '
        Me.Label63.Location = New System.Drawing.Point(280, 50)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(100, 20)
        Me.Label63.TabIndex = 48
        Me.Label63.Text = "des 2 extremums"
        '
        'Label64
        '
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(10, 20)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(80, 16)
        Me.Label64.TabIndex = 49
        Me.Label64.Text = "Température"
        '
        'NumericUpDown22
        '
        Me.NumericUpDown22.Location = New System.Drawing.Point(220, 50)
        Me.NumericUpDown22.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown22.Name = "NumericUpDown22"
        Me.NumericUpDown22.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown22.TabIndex = 47
        Me.NumericUpDown22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown22.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(460, 580)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 32)
        Me.Button1.TabIndex = 67
        Me.Button1.Text = "Calculer"
        '
        'frmMeteo
        '
        Me.ClientSize = New System.Drawing.Size(912, 616)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonExportFile)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMeteo"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Meteo - treatment"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.NumericUpDown25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown24, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumericUpDown11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NumericUpDown15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown22, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub ButtonExportFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportFile.Click
        If CStr(NumericUpDown3.Value) = "" Then
            MsgBox("Manque une concentration d'épandage de NaCl dans l'eau", MsgBoxStyle.Exclamation And MsgBoxStyle.OkOnly, "Avertissement")
            Exit Sub
        End If

        SetExport("File")

        Me.Hide()
        Me.Close()
    End Sub

    Private Sub ButtonExportDB_Click(sender As Object, e As EventArgs)

        If CStr(NumericUpDown3.Value) = "" Then
            MsgBox("Manque une concentration d'épandage de NaCl dans l'eau", MsgBoxStyle.Exclamation And MsgBoxStyle.OkOnly, "Avertissement")
            Exit Sub
        End If

        SetExport("DB")

        Me.Hide()
        Me.Close()

    End Sub


    Private Sub NumericUpDown1_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbrInt As Integer
        Dim NDH As Single
        Dim Conc As Long
        If Label3.Text <> "" Then
            NDH = Label3.Text
            Conc = NumericUpDown1.Value
            nbrInt = CInt(NDH / Conc)
            Label6.Text = nbrInt
        End If
    End Sub

    Private Sub NumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown3.ValueChanged
        ButtonExportFile.Hide()
    End Sub


    Private Sub NumericUpDown_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown3.LostFocus
        ButtonExportFile.Hide()
    End Sub

    Private Sub NumericUpDown1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbrInt As Integer
        Dim NDH As Single
        Dim Conc As Long
        If Label3.Text <> "" Then
            NDH = Label3.Text
            Conc = NumericUpDown1.Value
            nbrInt = CInt(NDH / Conc)
            Label6.Text = nbrInt
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If NumericUpDown1.Text = "" Or NumericUpDown2.Text = "" Or NumericUpDown1.Value <= 0 Or NumericUpDown2.Value <= 0 Then
            MsgBox("Le nombre d'interventions ou l'intervalle minimale entre 2 interventions est invalide", MsgBoxStyle.Exclamation And MsgBoxStyle.OkOnly, "Avertissement")
            Exit Sub
        End If
        WCal()

    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown4.ValueChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class
