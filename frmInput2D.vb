Public Class frmInput2D : Inherits System.Windows.Forms.Form

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
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents SSTab1 As System.Windows.Forms.TabControl
    Public WithEvents _SSTab1_TabPage0 As System.Windows.Forms.TabPage
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Combo5 As System.Windows.Forms.ComboBox
    Public WithEvents Text45 As System.Windows.Forms.TextBox
    Public WithEvents Text44 As System.Windows.Forms.TextBox
    Public WithEvents TextC As System.Windows.Forms.TextBox
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Public WithEvents Label86 As System.Windows.Forms.Label
    Public WithEvents Label85 As System.Windows.Forms.Label
    Public WithEvents Label84 As System.Windows.Forms.Label
    Public WithEvents Label83 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents Text4 As System.Windows.Forms.TextBox
    Public WithEvents Text3 As System.Windows.Forms.TextBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents _SSTab1_TabPage2 As System.Windows.Forms.TabPage
    Public WithEvents Frame7 As System.Windows.Forms.GroupBox
    Public WithEvents Label28 As System.Windows.Forms.Label
    Public WithEvents Frame8 As System.Windows.Forms.GroupBox
    Public WithEvents Text26 As System.Windows.Forms.TextBox
    Public WithEvents Label46 As System.Windows.Forms.Label
    Public WithEvents _SSTab1_TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Public WithEvents Text6 As System.Windows.Forms.TextBox
    Public WithEvents Text5 As System.Windows.Forms.TextBox
    Public WithEvents Label30 As System.Windows.Forms.Label
    Public WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Frame5 As System.Windows.Forms.GroupBox
    Public WithEvents Text24 As System.Windows.Forms.TextBox
    Public WithEvents Text23 As System.Windows.Forms.TextBox
    Public WithEvents Text22 As System.Windows.Forms.TextBox
    Public WithEvents Text21 As System.Windows.Forms.TextBox
    Public WithEvents Text20 As System.Windows.Forms.TextBox
    Public WithEvents Text19 As System.Windows.Forms.TextBox
    Public WithEvents Text18 As System.Windows.Forms.TextBox
    Public WithEvents Text17 As System.Windows.Forms.TextBox
    Public WithEvents Text16 As System.Windows.Forms.TextBox
    Public WithEvents Text15 As System.Windows.Forms.TextBox
    Public WithEvents Label45 As System.Windows.Forms.Label
    Public WithEvents Label44 As System.Windows.Forms.Label
    Public WithEvents Label43 As System.Windows.Forms.Label
    Public WithEvents Label42 As System.Windows.Forms.Label
    Public WithEvents Label41 As System.Windows.Forms.Label
    Public WithEvents Label40 As System.Windows.Forms.Label
    Public WithEvents Label39 As System.Windows.Forms.Label
    Public WithEvents Label38 As System.Windows.Forms.Label
    Public WithEvents Line7 As System.Windows.Forms.Label
    Public WithEvents Line6 As System.Windows.Forms.Label
    Public WithEvents Line5 As System.Windows.Forms.Label
    Public WithEvents Line4 As System.Windows.Forms.Label
    Public WithEvents Line1 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Frame6 As System.Windows.Forms.GroupBox
    Public WithEvents Text14 As System.Windows.Forms.TextBox
    Public WithEvents Text13 As System.Windows.Forms.TextBox
    Public WithEvents Text12 As System.Windows.Forms.TextBox
    Public WithEvents Text11 As System.Windows.Forms.TextBox
    Public WithEvents Text10 As System.Windows.Forms.TextBox
    Public WithEvents Label37 As System.Windows.Forms.Label
    Public WithEvents Label36 As System.Windows.Forms.Label
    Public WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents Label34 As System.Windows.Forms.Label
    Public WithEvents Label33 As System.Windows.Forms.Label
    Public WithEvents Label27 As System.Windows.Forms.Label
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents _SSTab1_TabPage3 As System.Windows.Forms.TabPage
    Public WithEvents Frame12 As System.Windows.Forms.GroupBox
    Public WithEvents Picture1 As System.Windows.Forms.PictureBox
    Public WithEvents Text32 As System.Windows.Forms.TextBox
    Public WithEvents Text31 As System.Windows.Forms.TextBox
    Public WithEvents Text30 As System.Windows.Forms.TextBox
    Public WithEvents Label54 As System.Windows.Forms.Label
    Public WithEvents Label53 As System.Windows.Forms.Label
    Public WithEvents Label52 As System.Windows.Forms.Label
    Public WithEvents Label51 As System.Windows.Forms.Label
    Public WithEvents Frame13 As System.Windows.Forms.GroupBox
    Public WithEvents Frame16 As System.Windows.Forms.GroupBox
    Public WithEvents Text39 As System.Windows.Forms.TextBox
    Public WithEvents Label66 As System.Windows.Forms.Label
    Public WithEvents _SSTab1_TabPage4 As System.Windows.Forms.TabPage
    Public WithEvents Frame17 As System.Windows.Forms.GroupBox
    Public WithEvents Text40 As System.Windows.Forms.TextBox
    Public WithEvents Label67 As System.Windows.Forms.Label
    Public WithEvents Frame20 As System.Windows.Forms.GroupBox
    Public WithEvents Text46 As System.Windows.Forms.TextBox
    Public WithEvents Label78 As System.Windows.Forms.Label
    Public WithEvents Label74 As System.Windows.Forms.Label
    Public WithEvents Frame21 As System.Windows.Forms.GroupBox
    Public WithEvents Text49 As System.Windows.Forms.TextBox
    Public WithEvents Text48 As System.Windows.Forms.TextBox
    Public WithEvents Label82 As System.Windows.Forms.Label
    Public WithEvents Label81 As System.Windows.Forms.Label
    Public WithEvents _SSTab1_TabPage5 As System.Windows.Forms.TabPage
    Public WithEvents Frame22 As System.Windows.Forms.GroupBox
    Public WithEvents Label73 As System.Windows.Forms.Label
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents Label89 As System.Windows.Forms.Label
    Public WithEvents TextBoxRho_c As System.Windows.Forms.TextBox
    Public WithEvents Label90 As System.Windows.Forms.Label
    Public WithEvents Label91 As System.Windows.Forms.Label
    Public WithEvents Label92 As System.Windows.Forms.Label
    Public WithEvents Label93 As System.Windows.Forms.Label
    Public WithEvents TextBox2 As System.Windows.Forms.TextBox
    Public WithEvents Label94 As System.Windows.Forms.Label
    Public WithEvents Label95 As System.Windows.Forms.Label
    Public WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents Option4 As System.Windows.Forms.RadioButton
    Public WithEvents Option3 As System.Windows.Forms.RadioButton
    Public WithEvents Option2 As System.Windows.Forms.RadioButton
    Public WithEvents Option1 As System.Windows.Forms.RadioButton
    Public WithEvents Text25 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Public WithEvents Label99 As System.Windows.Forms.Label
    Public WithEvents Label100 As System.Windows.Forms.Label
    Public WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Public WithEvents Command3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Public WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Public WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Public WithEvents Label111 As System.Windows.Forms.Label
    Public WithEvents Label75 As System.Windows.Forms.Label
    Public WithEvents Label76 As System.Windows.Forms.Label
    Public WithEvents TextBox10 As System.Windows.Forms.TextBox
    Public WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Public WithEvents TextBox15 As System.Windows.Forms.TextBox
    Public WithEvents Label77 As System.Windows.Forms.Label
    Public WithEvents Label79 As System.Windows.Forms.Label
    Public WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Public WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Public WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Public WithEvents TextBox19 As System.Windows.Forms.TextBox
    Public WithEvents Label119 As System.Windows.Forms.Label
    Public WithEvents Label120 As System.Windows.Forms.Label
    Public WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Public WithEvents Label122 As System.Windows.Forms.Label
    Public WithEvents Label48 As System.Windows.Forms.Label
    Public WithEvents Label69 As System.Windows.Forms.Label
    Public WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Public WithEvents TextBox21 As System.Windows.Forms.TextBox
    Public WithEvents TextBox22 As System.Windows.Forms.TextBox
    Public WithEvents Label49 As System.Windows.Forms.Label
    Public WithEvents Label50 As System.Windows.Forms.Label
    Public WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox24 As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents ComboBox8 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents ComboBox10 As System.Windows.Forms.ComboBox
    Public WithEvents TextBox27 As System.Windows.Forms.TextBox
    Public WithEvents Label123 As System.Windows.Forms.Label
    Public WithEvents Label124 As System.Windows.Forms.Label
    Public WithEvents TextBox28 As System.Windows.Forms.TextBox
    Public WithEvents Label125 As System.Windows.Forms.Label
    Public WithEvents TextBox29 As System.Windows.Forms.TextBox
    Public WithEvents Label126 As System.Windows.Forms.Label
    Public WithEvents TextBox30 As System.Windows.Forms.TextBox
    Public WithEvents Label127 As System.Windows.Forms.Label
    Public WithEvents Label128 As System.Windows.Forms.Label
    Public WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Public WithEvents Label55 As System.Windows.Forms.Label
    Public WithEvents Label59 As System.Windows.Forms.Label
    Public WithEvents Label104 As System.Windows.Forms.Label
    Public WithEvents Label105 As System.Windows.Forms.Label
    Public WithEvents Label107 As System.Windows.Forms.Label
    Public WithEvents Label130 As System.Windows.Forms.Label
    Public WithEvents Label131 As System.Windows.Forms.Label
    Public WithEvents Label132 As System.Windows.Forms.Label
    Public WithEvents Label133 As System.Windows.Forms.Label
    Public WithEvents Label134 As System.Windows.Forms.Label
    Friend WithEvents Label135 As System.Windows.Forms.Label
    Friend WithEvents Label136 As System.Windows.Forms.Label
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Label137 As System.Windows.Forms.Label
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents Label140 As System.Windows.Forms.Label
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Public WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label141 As System.Windows.Forms.Label
    Friend WithEvents Label142 As System.Windows.Forms.Label
    Friend WithEvents Label143 As System.Windows.Forms.Label
    Friend WithEvents Label144 As System.Windows.Forms.Label
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Public WithEvents Label145 As System.Windows.Forms.Label
    Public WithEvents Label146 As System.Windows.Forms.Label
    Public WithEvents Label147 As System.Windows.Forms.Label
    Public WithEvents TextBox6 As System.Windows.Forms.TextBox
    Public WithEvents Label148 As System.Windows.Forms.Label
    Friend WithEvents ComboBox11 As System.Windows.Forms.ComboBox
    Public WithEvents Label149 As System.Windows.Forms.Label
    Public WithEvents Label150 As System.Windows.Forms.Label
    Public WithEvents Label151 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox9 As PictureBox
    Public WithEvents Label7 As Label
    Public WithEvents Label8 As Label
    Public WithEvents Label9 As Label
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents NumClInt As NumericUpDown
    Friend WithEvents NumTempInt As NumericUpDown
    Friend WithEvents NumHRInt As NumericUpDown
    Friend WithEvents NumClExt As NumericUpDown
    Friend WithEvents NumTempExt As NumericUpDown
    Friend WithEvents NumHRExt As NumericUpDown
    Public WithEvents Label10 As Label
    Public WithEvents Label31 As Label
    Public WithEvents Label32 As Label
    Friend WithEvents PictureBox11 As PictureBox
    Public WithEvents Label152 As Label
    Public WithEvents Label70 As Label
    Public WithEvents Label63 As Label
    Public WithEvents Label47 As Label
    Public WithEvents TextBoxb As TextBox
    Public WithEvents TextBoxa As TextBox
    Public WithEvents TextBoxKl As TextBox
    Public WithEvents TextBoxKg As TextBox
    Friend WithEvents Button10 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInput2D))
        Me.Command2 = New System.Windows.Forms.Button()
        Me.SSTab1 = New System.Windows.Forms.TabControl()
        Me._SSTab1_TabPage0 = New System.Windows.Forms.TabPage()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.TextBoxRho_c = New System.Windows.Forms.TextBox()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Combo5 = New System.Windows.Forms.ComboBox()
        Me.Text45 = New System.Windows.Forms.TextBox()
        Me.Text44 = New System.Windows.Forms.TextBox()
        Me.TextC = New System.Windows.Forms.TextBox()
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.NumClInt = New System.Windows.Forms.NumericUpDown()
        Me.NumTempInt = New System.Windows.Forms.NumericUpDown()
        Me.NumHRInt = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Option4 = New System.Windows.Forms.RadioButton()
        Me.Option3 = New System.Windows.Forms.RadioButton()
        Me.Option2 = New System.Windows.Forms.RadioButton()
        Me.Option1 = New System.Windows.Forms.RadioButton()
        Me.Text4 = New System.Windows.Forms.TextBox()
        Me.Text3 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me._SSTab1_TabPage1 = New System.Windows.Forms.TabPage()
        Me.Frame4 = New System.Windows.Forms.GroupBox()
        Me.Text6 = New System.Windows.Forms.TextBox()
        Me.Text5 = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Frame5 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Text24 = New System.Windows.Forms.TextBox()
        Me.Text23 = New System.Windows.Forms.TextBox()
        Me.Text22 = New System.Windows.Forms.TextBox()
        Me.Text21 = New System.Windows.Forms.TextBox()
        Me.Text20 = New System.Windows.Forms.TextBox()
        Me.Text19 = New System.Windows.Forms.TextBox()
        Me.Text18 = New System.Windows.Forms.TextBox()
        Me.Text17 = New System.Windows.Forms.TextBox()
        Me.Text16 = New System.Windows.Forms.TextBox()
        Me.Text15 = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Line7 = New System.Windows.Forms.Label()
        Me.Line6 = New System.Windows.Forms.Label()
        Me.Line5 = New System.Windows.Forms.Label()
        Me.Line4 = New System.Windows.Forms.Label()
        Me.Line1 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Frame6 = New System.Windows.Forms.GroupBox()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.Text14 = New System.Windows.Forms.TextBox()
        Me.Text13 = New System.Windows.Forms.TextBox()
        Me.Text12 = New System.Windows.Forms.TextBox()
        Me.Text11 = New System.Windows.Forms.TextBox()
        Me.Text10 = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me._SSTab1_TabPage2 = New System.Windows.Forms.TabPage()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Frame7 = New System.Windows.Forms.GroupBox()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Text25 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Frame8 = New System.Windows.Forms.GroupBox()
        Me.Text26 = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me._SSTab1_TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label152 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.TextBoxb = New System.Windows.Forms.TextBox()
        Me.TextBoxa = New System.Windows.Forms.TextBox()
        Me.TextBoxKl = New System.Windows.Forms.TextBox()
        Me.TextBoxKg = New System.Windows.Forms.TextBox()
        Me.Frame12 = New System.Windows.Forms.GroupBox()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Picture1 = New System.Windows.Forms.PictureBox()
        Me.Text32 = New System.Windows.Forms.TextBox()
        Me.Text31 = New System.Windows.Forms.TextBox()
        Me.Text30 = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Frame13 = New System.Windows.Forms.GroupBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Frame16 = New System.Windows.Forms.GroupBox()
        Me.Text39 = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.ComboBox8 = New System.Windows.Forms.ComboBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ComboBox10 = New System.Windows.Forms.ComboBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me._SSTab1_TabPage4 = New System.Windows.Forms.TabPage()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.Frame17 = New System.Windows.Forms.GroupBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label129 = New System.Windows.Forms.Label()
        Me.Label128 = New System.Windows.Forms.Label()
        Me.TextBox30 = New System.Windows.Forms.TextBox()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.TextBox29 = New System.Windows.Forms.TextBox()
        Me.Label126 = New System.Windows.Forms.Label()
        Me.TextBox28 = New System.Windows.Forms.TextBox()
        Me.Label125 = New System.Windows.Forms.Label()
        Me.Text40 = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Frame20 = New System.Windows.Forms.GroupBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Text46 = New System.Windows.Forms.TextBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Frame21 = New System.Windows.Forms.GroupBox()
        Me.Text49 = New System.Windows.Forms.TextBox()
        Me.Text48 = New System.Windows.Forms.TextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.NumClExt = New System.Windows.Forms.NumericUpDown()
        Me.NumTempExt = New System.Windows.Forms.NumericUpDown()
        Me.NumHRExt = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me._SSTab1_TabPage5 = New System.Windows.Forms.TabPage()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label141 = New System.Windows.Forms.Label()
        Me.Label142 = New System.Windows.Forms.Label()
        Me.Label143 = New System.Windows.Forms.Label()
        Me.Label144 = New System.Windows.Forms.Label()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.Label145 = New System.Windows.Forms.Label()
        Me.Label146 = New System.Windows.Forms.Label()
        Me.Label147 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label148 = New System.Windows.Forms.Label()
        Me.ComboBox11 = New System.Windows.Forms.ComboBox()
        Me.Label149 = New System.Windows.Forms.Label()
        Me.Label150 = New System.Windows.Forms.Label()
        Me.Label151 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label137 = New System.Windows.Forms.Label()
        Me.Label138 = New System.Windows.Forms.Label()
        Me.Label139 = New System.Windows.Forms.Label()
        Me.Label140 = New System.Windows.Forms.Label()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.Label133 = New System.Windows.Forms.Label()
        Me.Label132 = New System.Windows.Forms.Label()
        Me.Label131 = New System.Windows.Forms.Label()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.Label120 = New System.Windows.Forms.Label()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.Label122 = New System.Windows.Forms.Label()
        Me.Label119 = New System.Windows.Forms.Label()
        Me.Label121 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label115 = New System.Windows.Forms.Label()
        Me.Label116 = New System.Windows.Forms.Label()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Label134 = New System.Windows.Forms.Label()
        Me.Label130 = New System.Windows.Forms.Label()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Frame22 = New System.Windows.Forms.GroupBox()
        Me.Label135 = New System.Windows.Forms.Label()
        Me.Label136 = New System.Windows.Forms.Label()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Command3 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SSTab1.SuspendLayout()
        Me._SSTab1_TabPage0.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        CType(Me.NumClInt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumTempInt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumHRInt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me._SSTab1_TabPage1.SuspendLayout()
        Me.Frame4.SuspendLayout()
        Me.Frame5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame6.SuspendLayout()
        Me._SSTab1_TabPage2.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame7.SuspendLayout()
        Me.Frame8.SuspendLayout()
        Me._SSTab1_TabPage3.SuspendLayout()
        Me.Frame12.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame13.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame16.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me._SSTab1_TabPage4.SuspendLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame17.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame20.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame21.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.NumClExt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumTempExt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumHRExt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._SSTab1_TabPage5.SuspendLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Frame22.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(896, 512)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(81, 33)
        Me.Command2.TabIndex = 6
        Me.Command2.Text = "&Cancel"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'SSTab1
        '
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage0)
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage1)
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage2)
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage3)
        Me.SSTab1.Controls.Add(Me.TabPage2)
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage4)
        Me.SSTab1.Controls.Add(Me.TabPage1)
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage5)
        Me.SSTab1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSTab1.ItemSize = New System.Drawing.Size(42, 18)
        Me.SSTab1.Location = New System.Drawing.Point(8, 8)
        Me.SSTab1.Name = "SSTab1"
        Me.SSTab1.SelectedIndex = 0
        Me.SSTab1.Size = New System.Drawing.Size(968, 440)
        Me.SSTab1.TabIndex = 4
        '
        '_SSTab1_TabPage0
        '
        Me._SSTab1_TabPage0.Controls.Add(Me.Frame1)
        Me._SSTab1_TabPage0.Controls.Add(Me.Frame2)
        Me._SSTab1_TabPage0.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage0.Name = "_SSTab1_TabPage0"
        Me._SSTab1_TabPage0.Size = New System.Drawing.Size(960, 414)
        Me._SSTab1_TabPage0.TabIndex = 0
        Me._SSTab1_TabPage0.Text = "Matériaux"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.TextBox3)
        Me.Frame1.Controls.Add(Me.Label100)
        Me.Frame1.Controls.Add(Me.Label98)
        Me.Frame1.Controls.Add(Me.Button1)
        Me.Frame1.Controls.Add(Me.Label97)
        Me.Frame1.Controls.Add(Me.TextBox2)
        Me.Frame1.Controls.Add(Me.Label94)
        Me.Frame1.Controls.Add(Me.Label95)
        Me.Frame1.Controls.Add(Me.Label93)
        Me.Frame1.Controls.Add(Me.Label92)
        Me.Frame1.Controls.Add(Me.Label91)
        Me.Frame1.Controls.Add(Me.Label90)
        Me.Frame1.Controls.Add(Me.TextBoxRho_c)
        Me.Frame1.Controls.Add(Me.Label89)
        Me.Frame1.Controls.Add(Me.Combo5)
        Me.Frame1.Controls.Add(Me.Text45)
        Me.Frame1.Controls.Add(Me.Text44)
        Me.Frame1.Controls.Add(Me.TextC)
        Me.Frame1.Controls.Add(Me.Text1)
        Me.Frame1.Controls.Add(Me.Label86)
        Me.Frame1.Controls.Add(Me.Label85)
        Me.Frame1.Controls.Add(Me.Label84)
        Me.Frame1.Controls.Add(Me.Label83)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 32)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(441, 368)
        Me.Frame1.TabIndex = 4
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Béton :"
        '
        'TextBox3
        '
        Me.TextBox3.AcceptsReturn = True
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox3.Location = New System.Drawing.Point(128, 192)
        Me.TextBox3.MaxLength = 0
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox3.Size = New System.Drawing.Size(73, 20)
        Me.TextBox3.TabIndex = 189
        Me.TextBox3.Text = "0"
        '
        'Label100
        '
        Me.Label100.BackColor = System.Drawing.SystemColors.Control
        Me.Label100.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label100.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label100.Location = New System.Drawing.Point(128, 336)
        Me.Label100.Name = "Label100"
        Me.Label100.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label100.Size = New System.Drawing.Size(288, 17)
        Me.Label100.TabIndex = 188
        Me.Label100.Text = "Ciment Portland"
        '
        'Label98
        '
        Me.Label98.BackColor = System.Drawing.SystemColors.Control
        Me.Label98.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label98.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label98.Location = New System.Drawing.Point(280, 272)
        Me.Label98.Name = "Label98"
        Me.Label98.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label98.Size = New System.Drawing.Size(112, 16)
        Me.Label98.TabIndex = 187
        Me.Label98.Text = "valeur de P. Roelfstra"
        Me.Label98.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(216, 272)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(48, 24)
        Me.Button1.TabIndex = 186
        Me.Button1.Text = "&défaut"
        '
        'Label97
        '
        Me.Label97.BackColor = System.Drawing.SystemColors.Control
        Me.Label97.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label97.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label97.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label97.Location = New System.Drawing.Point(8, 272)
        Me.Label97.Name = "Label97"
        Me.Label97.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label97.Size = New System.Drawing.Size(104, 17)
        Me.Label97.TabIndex = 185
        Me.Label97.Text = "taux d'hydratation"
        '
        'TextBox2
        '
        Me.TextBox2.AcceptsReturn = True
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox2.Location = New System.Drawing.Point(128, 155)
        Me.TextBox2.MaxLength = 0
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox2.Size = New System.Drawing.Size(73, 20)
        Me.TextBox2.TabIndex = 182
        Me.TextBox2.Text = "0"
        '
        'Label94
        '
        Me.Label94.BackColor = System.Drawing.SystemColors.Control
        Me.Label94.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label94.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label94.Location = New System.Drawing.Point(216, 155)
        Me.Label94.Name = "Label94"
        Me.Label94.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label94.Size = New System.Drawing.Size(89, 17)
        Me.Label94.TabIndex = 183
        Me.Label94.Text = "% de béton"
        '
        'Label95
        '
        Me.Label95.BackColor = System.Drawing.SystemColors.Control
        Me.Label95.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label95.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label95.Location = New System.Drawing.Point(8, 155)
        Me.Label95.Name = "Label95"
        Me.Label95.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label95.Size = New System.Drawing.Size(113, 17)
        Me.Label95.TabIndex = 181
        Me.Label95.Text = "teneur en air"
        '
        'Label93
        '
        Me.Label93.BackColor = System.Drawing.SystemColors.Control
        Me.Label93.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label93.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label93.Location = New System.Drawing.Point(216, 56)
        Me.Label93.Name = "Label93"
        Me.Label93.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label93.Size = New System.Drawing.Size(89, 17)
        Me.Label93.TabIndex = 180
        Me.Label93.Text = "kg/m3 de béton"
        '
        'Label92
        '
        Me.Label92.BackColor = System.Drawing.SystemColors.Control
        Me.Label92.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label92.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label92.Location = New System.Drawing.Point(128, 56)
        Me.Label92.Name = "Label92"
        Me.Label92.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label92.Size = New System.Drawing.Size(89, 17)
        Me.Label92.TabIndex = 179
        Me.Label92.Text = "0"
        '
        'Label91
        '
        Me.Label91.BackColor = System.Drawing.SystemColors.Control
        Me.Label91.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label91.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label91.Location = New System.Drawing.Point(8, 56)
        Me.Label91.Name = "Label91"
        Me.Label91.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label91.Size = New System.Drawing.Size(113, 17)
        Me.Label91.TabIndex = 178
        Me.Label91.Text = "teneur en granulat"
        '
        'Label90
        '
        Me.Label90.BackColor = System.Drawing.SystemColors.Control
        Me.Label90.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label90.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label90.Location = New System.Drawing.Point(256, 24)
        Me.Label90.Name = "Label90"
        Me.Label90.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label90.Size = New System.Drawing.Size(89, 17)
        Me.Label90.TabIndex = 177
        Me.Label90.Text = "kg/m3 de béton"
        '
        'TextBoxRho_c
        '
        Me.TextBoxRho_c.AcceptsReturn = True
        Me.TextBoxRho_c.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxRho_c.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxRho_c.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxRho_c.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBoxRho_c.Location = New System.Drawing.Point(176, 24)
        Me.TextBoxRho_c.MaxLength = 0
        Me.TextBoxRho_c.Name = "TextBoxRho_c"
        Me.TextBoxRho_c.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBoxRho_c.Size = New System.Drawing.Size(73, 20)
        Me.TextBoxRho_c.TabIndex = 176
        Me.TextBoxRho_c.Text = "0"
        '
        'Label89
        '
        Me.Label89.BackColor = System.Drawing.SystemColors.Control
        Me.Label89.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label89.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label89.Location = New System.Drawing.Point(8, 24)
        Me.Label89.Name = "Label89"
        Me.Label89.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label89.Size = New System.Drawing.Size(168, 17)
        Me.Label89.TabIndex = 175
        Me.Label89.Text = "masse volumique du béton frais"
        '
        'Combo5
        '
        Me.Combo5.BackColor = System.Drawing.SystemColors.Window
        Me.Combo5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo5.Items.AddRange(New Object() {"Type 1", "Type 2", "Type 3", "Type 4"})
        Me.Combo5.Location = New System.Drawing.Point(128, 312)
        Me.Combo5.Name = "Combo5"
        Me.Combo5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Combo5.Size = New System.Drawing.Size(193, 22)
        Me.Combo5.TabIndex = 174
        '
        'Text45
        '
        Me.Text45.AcceptsReturn = True
        Me.Text45.BackColor = System.Drawing.SystemColors.Window
        Me.Text45.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text45.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text45.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text45.Location = New System.Drawing.Point(128, 224)
        Me.Text45.MaxLength = 0
        Me.Text45.Name = "Text45"
        Me.Text45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text45.Size = New System.Drawing.Size(73, 20)
        Me.Text45.TabIndex = 171
        Me.Text45.Text = "0"
        '
        'Text44
        '
        Me.Text44.AcceptsReturn = True
        Me.Text44.BackColor = System.Drawing.SystemColors.Window
        Me.Text44.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text44.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text44.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text44.Location = New System.Drawing.Point(128, 272)
        Me.Text44.MaxLength = 0
        Me.Text44.Name = "Text44"
        Me.Text44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text44.Size = New System.Drawing.Size(73, 20)
        Me.Text44.TabIndex = 169
        Me.Text44.Text = "0"
        '
        'TextC
        '
        Me.TextC.AcceptsReturn = True
        Me.TextC.BackColor = System.Drawing.SystemColors.Window
        Me.TextC.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextC.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextC.Location = New System.Drawing.Point(128, 88)
        Me.TextC.MaxLength = 0
        Me.TextC.Name = "TextC"
        Me.TextC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextC.Size = New System.Drawing.Size(73, 20)
        Me.TextC.TabIndex = 9
        Me.TextC.Text = "0"
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(128, 120)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(73, 20)
        Me.Text1.TabIndex = 6
        Me.Text1.Text = "0"
        '
        'Label86
        '
        Me.Label86.BackColor = System.Drawing.SystemColors.Control
        Me.Label86.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label86.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label86.Location = New System.Drawing.Point(8, 312)
        Me.Label86.Name = "Label86"
        Me.Label86.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label86.Size = New System.Drawing.Size(89, 17)
        Me.Label86.TabIndex = 173
        Me.Label86.Text = "Type de ciment"
        '
        'Label85
        '
        Me.Label85.BackColor = System.Drawing.SystemColors.Control
        Me.Label85.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label85.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label85.Location = New System.Drawing.Point(216, 232)
        Me.Label85.Name = "Label85"
        Me.Label85.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label85.Size = New System.Drawing.Size(177, 33)
        Me.Label85.TabIndex = 172
        Me.Label85.Text = "jours (au moment de l'application des conditions aux limites)"
        Me.Label85.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label84
        '
        Me.Label84.BackColor = System.Drawing.SystemColors.Control
        Me.Label84.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label84.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label84.Location = New System.Drawing.Point(8, 232)
        Me.Label84.Name = "Label84"
        Me.Label84.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label84.Size = New System.Drawing.Size(97, 17)
        Me.Label84.TabIndex = 170
        Me.Label84.Text = "âge du béton"
        '
        'Label83
        '
        Me.Label83.BackColor = System.Drawing.SystemColors.Control
        Me.Label83.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label83.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label83.Location = New System.Drawing.Point(8, 192)
        Me.Label83.Name = "Label83"
        Me.Label83.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label83.Size = New System.Drawing.Size(89, 17)
        Me.Label83.TabIndex = 168
        Me.Label83.Text = "rapport E/C"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(216, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(89, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "kg/m3 de béton"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(105, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "teneur en ciment"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(216, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(89, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "kg/m3 de béton"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(113, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "teneur en eau saturé "
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.NumClInt)
        Me.Frame2.Controls.Add(Me.NumTempInt)
        Me.Frame2.Controls.Add(Me.NumHRInt)
        Me.Frame2.Controls.Add(Me.Label7)
        Me.Frame2.Controls.Add(Me.Label8)
        Me.Frame2.Controls.Add(Me.Label9)
        Me.Frame2.Controls.Add(Me.GroupBox1)
        Me.Frame2.Controls.Add(Me.Text4)
        Me.Frame2.Controls.Add(Me.Text3)
        Me.Frame2.Controls.Add(Me.Label6)
        Me.Frame2.Controls.Add(Me.Label5)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(464, 32)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(489, 368)
        Me.Frame2.TabIndex = 15
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Nom :"
        '
        'NumClInt
        '
        Me.NumClInt.Location = New System.Drawing.Point(107, 328)
        Me.NumClInt.Name = "NumClInt"
        Me.NumClInt.Size = New System.Drawing.Size(120, 20)
        Me.NumClInt.TabIndex = 159
        '
        'NumTempInt
        '
        Me.NumTempInt.Location = New System.Drawing.Point(107, 259)
        Me.NumTempInt.Name = "NumTempInt"
        Me.NumTempInt.Size = New System.Drawing.Size(120, 20)
        Me.NumTempInt.TabIndex = 158
        '
        'NumHRInt
        '
        Me.NumHRInt.Location = New System.Drawing.Point(107, 294)
        Me.NumHRInt.Name = "NumHRInt"
        Me.NumHRInt.Size = New System.Drawing.Size(120, 20)
        Me.NumHRInt.TabIndex = 157
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(1, 331)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(160, 17)
        Me.Label7.TabIndex = 153
        Me.Label7.Text = "Conc Cl- Interne"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(1, 297)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(153, 17)
        Me.Label8.TabIndex = 152
        Me.Label8.Text = "Humidité Interne"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(-3, 261)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(104, 17)
        Me.Label9.TabIndex = 151
        Me.Label9.Text = "Temperature Interne"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Option4)
        Me.GroupBox1.Controls.Add(Me.Option3)
        Me.GroupBox1.Controls.Add(Me.Option2)
        Me.GroupBox1.Controls.Add(Me.Option1)
        Me.GroupBox1.Location = New System.Drawing.Point(384, 184)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(88, 176)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Perméabilité"
        '
        'Option4
        '
        Me.Option4.BackColor = System.Drawing.SystemColors.Control
        Me.Option4.Checked = True
        Me.Option4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option4.Location = New System.Drawing.Point(12, 128)
        Me.Option4.Name = "Option4"
        Me.Option4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option4.Size = New System.Drawing.Size(52, 17)
        Me.Option4.TabIndex = 27
        Me.Option4.TabStop = True
        Me.Option4.Text = "autre"
        Me.Option4.UseVisualStyleBackColor = False
        '
        'Option3
        '
        Me.Option3.BackColor = System.Drawing.SystemColors.Control
        Me.Option3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option3.Location = New System.Drawing.Point(12, 96)
        Me.Option3.Name = "Option3"
        Me.Option3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option3.Size = New System.Drawing.Size(60, 17)
        Me.Option3.TabIndex = 26
        Me.Option3.TabStop = True
        Me.Option3.Text = "grande"
        Me.Option3.UseVisualStyleBackColor = False
        '
        'Option2
        '
        Me.Option2.BackColor = System.Drawing.SystemColors.Control
        Me.Option2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2.Location = New System.Drawing.Point(12, 64)
        Me.Option2.Name = "Option2"
        Me.Option2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option2.Size = New System.Drawing.Size(68, 17)
        Me.Option2.TabIndex = 25
        Me.Option2.TabStop = True
        Me.Option2.Text = "moyenne"
        Me.Option2.UseVisualStyleBackColor = False
        '
        'Option1
        '
        Me.Option1.BackColor = System.Drawing.SystemColors.Control
        Me.Option1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Location = New System.Drawing.Point(12, 32)
        Me.Option1.Name = "Option1"
        Me.Option1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option1.Size = New System.Drawing.Size(60, 17)
        Me.Option1.TabIndex = 24
        Me.Option1.TabStop = True
        Me.Option1.Text = "faible"
        Me.Option1.UseVisualStyleBackColor = False
        '
        'Text4
        '
        Me.Text4.AcceptsReturn = True
        Me.Text4.BackColor = System.Drawing.SystemColors.Window
        Me.Text4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text4.Location = New System.Drawing.Point(184, 64)
        Me.Text4.MaxLength = 0
        Me.Text4.Name = "Text4"
        Me.Text4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text4.Size = New System.Drawing.Size(297, 20)
        Me.Text4.TabIndex = 19
        '
        'Text3
        '
        Me.Text3.AcceptsReturn = True
        Me.Text3.BackColor = System.Drawing.SystemColors.Window
        Me.Text3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text3.Location = New System.Drawing.Point(160, 32)
        Me.Text3.MaxLength = 0
        Me.Text3.Name = "Text3"
        Me.Text3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text3.Size = New System.Drawing.Size(321, 20)
        Me.Text3.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(168, 17)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "nom d'affichage  durant le calcul"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(144, 24)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "nom dans le fichier résultat"
        '
        '_SSTab1_TabPage1
        '
        Me._SSTab1_TabPage1.Controls.Add(Me.Frame4)
        Me._SSTab1_TabPage1.Controls.Add(Me.Frame5)
        Me._SSTab1_TabPage1.Controls.Add(Me.Frame6)
        Me._SSTab1_TabPage1.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage1.Name = "_SSTab1_TabPage1"
        Me._SSTab1_TabPage1.Size = New System.Drawing.Size(960, 414)
        Me._SSTab1_TabPage1.TabIndex = 1
        Me._SSTab1_TabPage1.Text = "Paramètres du programme"
        Me._SSTab1_TabPage1.Visible = False
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me.Text6)
        Me.Frame4.Controls.Add(Me.Text5)
        Me.Frame4.Controls.Add(Me.Label30)
        Me.Frame4.Controls.Add(Me.Label29)
        Me.Frame4.Controls.Add(Me.Label12)
        Me.Frame4.Controls.Add(Me.Label11)
        Me.Frame4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(8, 8)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(465, 72)
        Me.Frame4.TabIndex = 25
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Temps :"
        '
        'Text6
        '
        Me.Text6.AcceptsReturn = True
        Me.Text6.BackColor = System.Drawing.SystemColors.Window
        Me.Text6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text6.Location = New System.Drawing.Point(192, 48)
        Me.Text6.MaxLength = 0
        Me.Text6.Name = "Text6"
        Me.Text6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text6.Size = New System.Drawing.Size(129, 20)
        Me.Text6.TabIndex = 46
        Me.Text6.Text = "3600"
        '
        'Text5
        '
        Me.Text5.AcceptsReturn = True
        Me.Text5.BackColor = System.Drawing.SystemColors.Window
        Me.Text5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text5.Location = New System.Drawing.Point(192, 24)
        Me.Text5.MaxLength = 0
        Me.Text5.Name = "Text5"
        Me.Text5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text5.Size = New System.Drawing.Size(129, 20)
        Me.Text5.TabIndex = 45
        Me.Text5.Text = "73000"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(328, 48)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(81, 17)
        Me.Label30.TabIndex = 69
        Me.Label30.Text = "secondes"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(328, 24)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(89, 17)
        Me.Label29.TabIndex = 68
        Me.Label29.Text = "jours"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(8, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(136, 17)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "pas de temps de calcul"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(137, 17)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "temps maximal de calcul"
        '
        'Frame5
        '
        Me.Frame5.BackColor = System.Drawing.SystemColors.Control
        Me.Frame5.Controls.Add(Me.PictureBox1)
        Me.Frame5.Controls.Add(Me.Text24)
        Me.Frame5.Controls.Add(Me.Text23)
        Me.Frame5.Controls.Add(Me.Text22)
        Me.Frame5.Controls.Add(Me.Text21)
        Me.Frame5.Controls.Add(Me.Text20)
        Me.Frame5.Controls.Add(Me.Text19)
        Me.Frame5.Controls.Add(Me.Text18)
        Me.Frame5.Controls.Add(Me.Text17)
        Me.Frame5.Controls.Add(Me.Text16)
        Me.Frame5.Controls.Add(Me.Text15)
        Me.Frame5.Controls.Add(Me.Label45)
        Me.Frame5.Controls.Add(Me.Label44)
        Me.Frame5.Controls.Add(Me.Label43)
        Me.Frame5.Controls.Add(Me.Label42)
        Me.Frame5.Controls.Add(Me.Label41)
        Me.Frame5.Controls.Add(Me.Label40)
        Me.Frame5.Controls.Add(Me.Label39)
        Me.Frame5.Controls.Add(Me.Label38)
        Me.Frame5.Controls.Add(Me.Line7)
        Me.Frame5.Controls.Add(Me.Line6)
        Me.Frame5.Controls.Add(Me.Line5)
        Me.Frame5.Controls.Add(Me.Line4)
        Me.Frame5.Controls.Add(Me.Line1)
        Me.Frame5.Controls.Add(Me.Label22)
        Me.Frame5.Controls.Add(Me.Label21)
        Me.Frame5.Controls.Add(Me.Label20)
        Me.Frame5.Controls.Add(Me.Label19)
        Me.Frame5.Controls.Add(Me.Label18)
        Me.Frame5.Controls.Add(Me.Label17)
        Me.Frame5.Controls.Add(Me.Label16)
        Me.Frame5.Controls.Add(Me.Label15)
        Me.Frame5.Controls.Add(Me.Label14)
        Me.Frame5.Controls.Add(Me.Label13)
        Me.Frame5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame5.Location = New System.Drawing.Point(488, 8)
        Me.Frame5.Name = "Frame5"
        Me.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame5.Size = New System.Drawing.Size(465, 392)
        Me.Frame5.TabIndex = 28
        Me.Frame5.TabStop = False
        Me.Frame5.Text = "Affichage :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox1.Location = New System.Drawing.Point(0, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(465, 392)
        Me.PictureBox1.TabIndex = 90
        Me.PictureBox1.TabStop = False
        '
        'Text24
        '
        Me.Text24.AcceptsReturn = True
        Me.Text24.BackColor = System.Drawing.SystemColors.Window
        Me.Text24.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text24.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text24.Location = New System.Drawing.Point(176, 352)
        Me.Text24.MaxLength = 0
        Me.Text24.Name = "Text24"
        Me.Text24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text24.Size = New System.Drawing.Size(113, 20)
        Me.Text24.TabIndex = 65
        Me.Text24.Text = "5"
        '
        'Text23
        '
        Me.Text23.AcceptsReturn = True
        Me.Text23.BackColor = System.Drawing.SystemColors.Window
        Me.Text23.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text23.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text23.Location = New System.Drawing.Point(176, 328)
        Me.Text23.MaxLength = 0
        Me.Text23.Name = "Text23"
        Me.Text23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text23.Size = New System.Drawing.Size(113, 20)
        Me.Text23.TabIndex = 64
        Me.Text23.Text = "0"
        '
        'Text22
        '
        Me.Text22.AcceptsReturn = True
        Me.Text22.BackColor = System.Drawing.SystemColors.Window
        Me.Text22.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text22.Location = New System.Drawing.Point(176, 280)
        Me.Text22.MaxLength = 0
        Me.Text22.Name = "Text22"
        Me.Text22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text22.Size = New System.Drawing.Size(113, 20)
        Me.Text22.TabIndex = 63
        Me.Text22.Text = "1"
        '
        'Text21
        '
        Me.Text21.AcceptsReturn = True
        Me.Text21.BackColor = System.Drawing.SystemColors.Window
        Me.Text21.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text21.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text21.Location = New System.Drawing.Point(176, 256)
        Me.Text21.MaxLength = 0
        Me.Text21.Name = "Text21"
        Me.Text21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text21.Size = New System.Drawing.Size(113, 20)
        Me.Text21.TabIndex = 62
        Me.Text21.Text = "0"
        '
        'Text20
        '
        Me.Text20.AcceptsReturn = True
        Me.Text20.BackColor = System.Drawing.SystemColors.Window
        Me.Text20.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text20.Location = New System.Drawing.Point(176, 208)
        Me.Text20.MaxLength = 0
        Me.Text20.Name = "Text20"
        Me.Text20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text20.Size = New System.Drawing.Size(113, 20)
        Me.Text20.TabIndex = 61
        Me.Text20.Text = "10"
        '
        'Text19
        '
        Me.Text19.AcceptsReturn = True
        Me.Text19.BackColor = System.Drawing.SystemColors.Window
        Me.Text19.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text19.Location = New System.Drawing.Point(176, 184)
        Me.Text19.MaxLength = 0
        Me.Text19.Name = "Text19"
        Me.Text19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text19.Size = New System.Drawing.Size(113, 20)
        Me.Text19.TabIndex = 60
        Me.Text19.Text = "50"
        '
        'Text18
        '
        Me.Text18.AcceptsReturn = True
        Me.Text18.BackColor = System.Drawing.SystemColors.Window
        Me.Text18.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text18.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text18.Location = New System.Drawing.Point(176, 136)
        Me.Text18.MaxLength = 0
        Me.Text18.Name = "Text18"
        Me.Text18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text18.Size = New System.Drawing.Size(113, 20)
        Me.Text18.TabIndex = 59
        Me.Text18.Text = "0.1"
        '
        'Text17
        '
        Me.Text17.AcceptsReturn = True
        Me.Text17.BackColor = System.Drawing.SystemColors.Window
        Me.Text17.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text17.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text17.Location = New System.Drawing.Point(176, 112)
        Me.Text17.MaxLength = 0
        Me.Text17.Name = "Text17"
        Me.Text17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text17.Size = New System.Drawing.Size(113, 20)
        Me.Text17.TabIndex = 58
        Me.Text17.Text = "0.4"
        '
        'Text16
        '
        Me.Text16.AcceptsReturn = True
        Me.Text16.BackColor = System.Drawing.SystemColors.Window
        Me.Text16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text16.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text16.Location = New System.Drawing.Point(176, 64)
        Me.Text16.MaxLength = 0
        Me.Text16.Name = "Text16"
        Me.Text16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text16.Size = New System.Drawing.Size(113, 20)
        Me.Text16.TabIndex = 57
        Me.Text16.Text = "5"
        '
        'Text15
        '
        Me.Text15.AcceptsReturn = True
        Me.Text15.BackColor = System.Drawing.SystemColors.Window
        Me.Text15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text15.Location = New System.Drawing.Point(176, 24)
        Me.Text15.MaxLength = 0
        Me.Text15.Name = "Text15"
        Me.Text15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text15.Size = New System.Drawing.Size(113, 20)
        Me.Text15.TabIndex = 56
        Me.Text15.Text = "720"
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.SystemColors.Control
        Me.Label45.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label45.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(296, 352)
        Me.Label45.Name = "Label45"
        Me.Label45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label45.Size = New System.Drawing.Size(89, 17)
        Me.Label45.TabIndex = 84
        Me.Label45.Text = "kg/m3 de béton"
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label44.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(296, 328)
        Me.Label44.Name = "Label44"
        Me.Label44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label44.Size = New System.Drawing.Size(81, 17)
        Me.Label44.TabIndex = 83
        Me.Label44.Text = "kg/m3 de béton"
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.SystemColors.Control
        Me.Label43.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label43.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(296, 280)
        Me.Label43.Name = "Label43"
        Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label43.Size = New System.Drawing.Size(81, 17)
        Me.Label43.TabIndex = 82
        Me.Label43.Text = "kg/m3 de béton"
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.SystemColors.Control
        Me.Label42.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label42.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(296, 256)
        Me.Label42.Name = "Label42"
        Me.Label42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label42.Size = New System.Drawing.Size(81, 17)
        Me.Label42.TabIndex = 81
        Me.Label42.Text = "kg/m3 de béton"
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.SystemColors.Control
        Me.Label41.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label41.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label41.Location = New System.Drawing.Point(296, 208)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label41.Size = New System.Drawing.Size(81, 17)
        Me.Label41.TabIndex = 80
        Me.Label41.Text = "kg/m3 de béton"
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.SystemColors.Control
        Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label40.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(296, 184)
        Me.Label40.Name = "Label40"
        Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label40.Size = New System.Drawing.Size(89, 17)
        Me.Label40.TabIndex = 79
        Me.Label40.Text = "kg/m3 de béton"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.Control
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(304, 64)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(65, 17)
        Me.Label39.TabIndex = 78
        Me.Label39.Text = "°C"
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.Control
        Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(304, 24)
        Me.Label38.Name = "Label38"
        Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label38.Size = New System.Drawing.Size(81, 17)
        Me.Label38.TabIndex = 77
        Me.Label38.Text = "heures"
        '
        'Line7
        '
        Me.Line7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Line7.Location = New System.Drawing.Point(8, 56)
        Me.Line7.Name = "Line7"
        Me.Line7.Size = New System.Drawing.Size(440, 1)
        Me.Line7.TabIndex = 85
        '
        'Line6
        '
        Me.Line6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Line6.Location = New System.Drawing.Point(8, 104)
        Me.Line6.Name = "Line6"
        Me.Line6.Size = New System.Drawing.Size(440, 1)
        Me.Line6.TabIndex = 86
        '
        'Line5
        '
        Me.Line5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Line5.Location = New System.Drawing.Point(8, 176)
        Me.Line5.Name = "Line5"
        Me.Line5.Size = New System.Drawing.Size(440, 1)
        Me.Line5.TabIndex = 87
        '
        'Line4
        '
        Me.Line4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Line4.Location = New System.Drawing.Point(8, 248)
        Me.Line4.Name = "Line4"
        Me.Line4.Size = New System.Drawing.Size(440, 1)
        Me.Line4.TabIndex = 88
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Line1.Location = New System.Drawing.Point(8, 320)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(440, 1)
        Me.Line1.TabIndex = 89
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(8, 360)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(145, 17)
        Me.Label22.TabIndex = 38
        Me.Label22.Text = "chlorures totaux, écart"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(8, 336)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(176, 17)
        Me.Label21.TabIndex = 37
        Me.Label21.Text = "chlorures totaux, valeur minimale"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(8, 288)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(128, 17)
        Me.Label20.TabIndex = 36
        Me.Label20.Text = "chlorures libres, écart"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(8, 264)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(169, 17)
        Me.Label19.TabIndex = 35
        Me.Label19.Text = "chlorures libres, valeur minimale"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(8, 216)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(153, 17)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "teneur en eau, écart"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(8, 192)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(168, 17)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "teneur en eau, valeur minimale"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(8, 144)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(169, 17)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "humidité relative, écart"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(8, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(184, 17)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "humidité relative, valeur minimale"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(8, 72)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(145, 17)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "température, écart"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(8, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(161, 17)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "temps d'affichage des résultats"
        '
        'Frame6
        '
        Me.Frame6.BackColor = System.Drawing.SystemColors.Control
        Me.Frame6.Controls.Add(Me.TextBox27)
        Me.Frame6.Controls.Add(Me.Label123)
        Me.Frame6.Controls.Add(Me.Label124)
        Me.Frame6.Controls.Add(Me.Text14)
        Me.Frame6.Controls.Add(Me.Text13)
        Me.Frame6.Controls.Add(Me.Text12)
        Me.Frame6.Controls.Add(Me.Text11)
        Me.Frame6.Controls.Add(Me.Text10)
        Me.Frame6.Controls.Add(Me.Label37)
        Me.Frame6.Controls.Add(Me.Label36)
        Me.Frame6.Controls.Add(Me.Label35)
        Me.Frame6.Controls.Add(Me.Label34)
        Me.Frame6.Controls.Add(Me.Label33)
        Me.Frame6.Controls.Add(Me.Label27)
        Me.Frame6.Controls.Add(Me.Label26)
        Me.Frame6.Controls.Add(Me.Label25)
        Me.Frame6.Controls.Add(Me.Label24)
        Me.Frame6.Controls.Add(Me.Label23)
        Me.Frame6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame6.Location = New System.Drawing.Point(8, 232)
        Me.Frame6.Name = "Frame6"
        Me.Frame6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame6.Size = New System.Drawing.Size(465, 168)
        Me.Frame6.TabIndex = 39
        Me.Frame6.TabStop = False
        Me.Frame6.Text = "Fichier résultat :"
        '
        'TextBox27
        '
        Me.TextBox27.AcceptsReturn = True
        Me.TextBox27.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox27.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox27.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox27.Location = New System.Drawing.Point(224, 88)
        Me.TextBox27.MaxLength = 0
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox27.Size = New System.Drawing.Size(121, 20)
        Me.TextBox27.TabIndex = 78
        Me.TextBox27.Text = "8760"
        '
        'Label123
        '
        Me.Label123.BackColor = System.Drawing.SystemColors.Control
        Me.Label123.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label123.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label123.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label123.Location = New System.Drawing.Point(352, 88)
        Me.Label123.Name = "Label123"
        Me.Label123.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label123.Size = New System.Drawing.Size(57, 17)
        Me.Label123.TabIndex = 79
        Me.Label123.Text = "heures"
        '
        'Label124
        '
        Me.Label124.BackColor = System.Drawing.SystemColors.Control
        Me.Label124.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label124.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label124.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label124.Location = New System.Drawing.Point(8, 96)
        Me.Label124.Name = "Label124"
        Me.Label124.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label124.Size = New System.Drawing.Size(208, 17)
        Me.Label124.TabIndex = 77
        Me.Label124.Text = "temps de sauvegarde (carbonatation)"
        '
        'Text14
        '
        Me.Text14.AcceptsReturn = True
        Me.Text14.BackColor = System.Drawing.SystemColors.Window
        Me.Text14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text14.Location = New System.Drawing.Point(224, 136)
        Me.Text14.MaxLength = 0
        Me.Text14.Name = "Text14"
        Me.Text14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text14.Size = New System.Drawing.Size(121, 20)
        Me.Text14.TabIndex = 55
        Me.Text14.Text = "8760"
        '
        'Text13
        '
        Me.Text13.AcceptsReturn = True
        Me.Text13.BackColor = System.Drawing.SystemColors.Window
        Me.Text13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text13.Location = New System.Drawing.Point(224, 112)
        Me.Text13.MaxLength = 0
        Me.Text13.Name = "Text13"
        Me.Text13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text13.Size = New System.Drawing.Size(121, 20)
        Me.Text13.TabIndex = 54
        Me.Text13.Text = "8760"
        '
        'Text12
        '
        Me.Text12.AcceptsReturn = True
        Me.Text12.BackColor = System.Drawing.SystemColors.Window
        Me.Text12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text12.Location = New System.Drawing.Point(224, 64)
        Me.Text12.MaxLength = 0
        Me.Text12.Name = "Text12"
        Me.Text12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text12.Size = New System.Drawing.Size(121, 20)
        Me.Text12.TabIndex = 53
        Me.Text12.Text = "8760"
        '
        'Text11
        '
        Me.Text11.AcceptsReturn = True
        Me.Text11.BackColor = System.Drawing.SystemColors.Window
        Me.Text11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text11.Location = New System.Drawing.Point(224, 40)
        Me.Text11.MaxLength = 0
        Me.Text11.Name = "Text11"
        Me.Text11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text11.Size = New System.Drawing.Size(121, 20)
        Me.Text11.TabIndex = 52
        Me.Text11.Text = "8760"
        '
        'Text10
        '
        Me.Text10.AcceptsReturn = True
        Me.Text10.BackColor = System.Drawing.SystemColors.Window
        Me.Text10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text10.Location = New System.Drawing.Point(224, 16)
        Me.Text10.MaxLength = 0
        Me.Text10.Name = "Text10"
        Me.Text10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text10.Size = New System.Drawing.Size(121, 20)
        Me.Text10.TabIndex = 51
        Me.Text10.Text = "8760"
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.SystemColors.Control
        Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label37.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(352, 136)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label37.Size = New System.Drawing.Size(57, 17)
        Me.Label37.TabIndex = 76
        Me.Label37.Text = "heures"
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.SystemColors.Control
        Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label36.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(352, 112)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label36.Size = New System.Drawing.Size(49, 17)
        Me.Label36.TabIndex = 75
        Me.Label36.Text = "heures"
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.SystemColors.Control
        Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(352, 64)
        Me.Label35.Name = "Label35"
        Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label35.Size = New System.Drawing.Size(57, 17)
        Me.Label35.TabIndex = 74
        Me.Label35.Text = "heures"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.SystemColors.Control
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(352, 40)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label34.Size = New System.Drawing.Size(65, 17)
        Me.Label34.TabIndex = 73
        Me.Label34.Text = "heures"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.Control
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(352, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(73, 17)
        Me.Label33.TabIndex = 72
        Me.Label33.Text = "heures"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.Control
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(8, 144)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(208, 17)
        Me.Label27.TabIndex = 44
        Me.Label27.Text = "temps de sauvegarde (chlorures totaux)"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(8, 24)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(193, 17)
        Me.Label26.TabIndex = 43
        Me.Label26.Text = "temps de sauvegarde (température)"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(8, 120)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(201, 17)
        Me.Label25.TabIndex = 42
        Me.Label25.Text = "temps de sauvegarde (chlorures libres)"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(8, 72)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(201, 17)
        Me.Label24.TabIndex = 41
        Me.Label24.Text = "temps de sauvegarde (teneur en eau)"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(8, 48)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(208, 17)
        Me.Label23.TabIndex = 40
        Me.Label23.Text = "temps de sauvegarde (humidité relative)"
        '
        '_SSTab1_TabPage2
        '
        Me._SSTab1_TabPage2.Controls.Add(Me.PictureBox7)
        Me._SSTab1_TabPage2.Controls.Add(Me.Frame7)
        Me._SSTab1_TabPage2.Controls.Add(Me.Frame8)
        Me._SSTab1_TabPage2.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage2.Name = "_SSTab1_TabPage2"
        Me._SSTab1_TabPage2.Size = New System.Drawing.Size(960, 414)
        Me._SSTab1_TabPage2.TabIndex = 2
        Me._SSTab1_TabPage2.Text = "Transport thermique"
        Me._SSTab1_TabPage2.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox7.Location = New System.Drawing.Point(10, 18)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(950, 184)
        Me.PictureBox7.TabIndex = 86
        Me.PictureBox7.TabStop = False
        '
        'Frame7
        '
        Me.Frame7.BackColor = System.Drawing.SystemColors.Control
        Me.Frame7.Controls.Add(Me.Label99)
        Me.Frame7.Controls.Add(Me.ComboBox1)
        Me.Frame7.Controls.Add(Me.Text25)
        Me.Frame7.Controls.Add(Me.Label28)
        Me.Frame7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7.Location = New System.Drawing.Point(8, 32)
        Me.Frame7.Name = "Frame7"
        Me.Frame7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7.Size = New System.Drawing.Size(465, 136)
        Me.Frame7.TabIndex = 66
        Me.Frame7.TabStop = False
        Me.Frame7.Text = "Capacité calorifique"
        '
        'Label99
        '
        Me.Label99.BackColor = System.Drawing.SystemColors.Control
        Me.Label99.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label99.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label99.Location = New System.Drawing.Point(160, 96)
        Me.Label99.Name = "Label99"
        Me.Label99.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label99.Size = New System.Drawing.Size(208, 16)
        Me.Label99.TabIndex = 94
        Me.Label99.Text = "kJ / kg °K (valeur comprise entre 0.7-0.9)"
        Me.Label99.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Items.AddRange(New Object() {"siliceux", "calcaire", "chaux + calcaire", "autres"})
        Me.ComboBox1.Location = New System.Drawing.Point(80, 40)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(144, 22)
        Me.ComboBox1.TabIndex = 93
        '
        'Text25
        '
        Me.Text25.AcceptsReturn = True
        Me.Text25.BackColor = System.Drawing.SystemColors.Window
        Me.Text25.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text25.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text25.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text25.Location = New System.Drawing.Point(80, 88)
        Me.Text25.MaxLength = 0
        Me.Text25.Name = "Text25"
        Me.Text25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text25.Size = New System.Drawing.Size(64, 20)
        Me.Text25.TabIndex = 92
        Me.Text25.Text = "0.7"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.SystemColors.Control
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(8, 40)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(177, 17)
        Me.Label28.TabIndex = 67
        Me.Label28.Text = "granulats"
        '
        'Frame8
        '
        Me.Frame8.BackColor = System.Drawing.SystemColors.Control
        Me.Frame8.Controls.Add(Me.Text26)
        Me.Frame8.Controls.Add(Me.Label46)
        Me.Frame8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame8.Location = New System.Drawing.Point(488, 32)
        Me.Frame8.Name = "Frame8"
        Me.Frame8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame8.Size = New System.Drawing.Size(465, 136)
        Me.Frame8.TabIndex = 85
        Me.Frame8.TabStop = False
        Me.Frame8.Text = "Transfert à la surface :"
        '
        'Text26
        '
        Me.Text26.AcceptsReturn = True
        Me.Text26.BackColor = System.Drawing.SystemColors.Window
        Me.Text26.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text26.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text26.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text26.Location = New System.Drawing.Point(184, 16)
        Me.Text26.MaxLength = 0
        Me.Text26.Name = "Text26"
        Me.Text26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text26.Size = New System.Drawing.Size(129, 20)
        Me.Text26.TabIndex = 93
        Me.Text26.Text = "1"
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.SystemColors.Control
        Me.Label46.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label46.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.Location = New System.Drawing.Point(8, 24)
        Me.Label46.Name = "Label46"
        Me.Label46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label46.Size = New System.Drawing.Size(201, 17)
        Me.Label46.TabIndex = 86
        Me.Label46.Text = "coefficient de transfert de surface"
        '
        '_SSTab1_TabPage3
        '
        Me._SSTab1_TabPage3.Controls.Add(Me.Label152)
        Me._SSTab1_TabPage3.Controls.Add(Me.Label70)
        Me._SSTab1_TabPage3.Controls.Add(Me.Label63)
        Me._SSTab1_TabPage3.Controls.Add(Me.Label47)
        Me._SSTab1_TabPage3.Controls.Add(Me.TextBoxb)
        Me._SSTab1_TabPage3.Controls.Add(Me.TextBoxa)
        Me._SSTab1_TabPage3.Controls.Add(Me.TextBoxKl)
        Me._SSTab1_TabPage3.Controls.Add(Me.TextBoxKg)
        Me._SSTab1_TabPage3.Controls.Add(Me.Frame12)
        Me._SSTab1_TabPage3.Controls.Add(Me.Frame13)
        Me._SSTab1_TabPage3.Controls.Add(Me.Frame16)
        Me._SSTab1_TabPage3.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage3.Name = "_SSTab1_TabPage3"
        Me._SSTab1_TabPage3.Size = New System.Drawing.Size(960, 414)
        Me._SSTab1_TabPage3.TabIndex = 3
        Me._SSTab1_TabPage3.Text = "Transport hydrique"
        Me._SSTab1_TabPage3.Visible = False
        '
        'Label152
        '
        Me.Label152.BackColor = System.Drawing.SystemColors.Control
        Me.Label152.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label152.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label152.Location = New System.Drawing.Point(221, 326)
        Me.Label152.Name = "Label152"
        Me.Label152.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label152.Size = New System.Drawing.Size(47, 20)
        Me.Label152.TabIndex = 142
        Me.Label152.Text = "g (.)"
        '
        'Label70
        '
        Me.Label70.BackColor = System.Drawing.SystemColors.Control
        Me.Label70.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label70.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label70.Location = New System.Drawing.Point(221, 297)
        Me.Label70.Name = "Label70"
        Me.Label70.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label70.Size = New System.Drawing.Size(47, 20)
        Me.Label70.TabIndex = 141
        Me.Label70.Text = "a (MPa)"
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.SystemColors.Control
        Me.Label63.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label63.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label63.Location = New System.Drawing.Point(25, 329)
        Me.Label63.Name = "Label63"
        Me.Label63.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label63.Size = New System.Drawing.Size(69, 17)
        Me.Label63.TabIndex = 140
        Me.Label63.Text = "kl (m-2.s-1)"
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.SystemColors.Control
        Me.Label47.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(25, 300)
        Me.Label47.Name = "Label47"
        Me.Label47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label47.Size = New System.Drawing.Size(69, 29)
        Me.Label47.TabIndex = 139
        Me.Label47.Text = "kg (m-2.s-1)"
        '
        'TextBoxb
        '
        Me.TextBoxb.AcceptsReturn = True
        Me.TextBoxb.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxb.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBoxb.Location = New System.Drawing.Point(274, 326)
        Me.TextBoxb.MaxLength = 0
        Me.TextBoxb.Name = "TextBoxb"
        Me.TextBoxb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBoxb.Size = New System.Drawing.Size(97, 20)
        Me.TextBoxb.TabIndex = 138
        '
        'TextBoxa
        '
        Me.TextBoxa.AcceptsReturn = True
        Me.TextBoxa.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxa.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxa.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBoxa.Location = New System.Drawing.Point(274, 297)
        Me.TextBoxa.MaxLength = 0
        Me.TextBoxa.Name = "TextBoxa"
        Me.TextBoxa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBoxa.Size = New System.Drawing.Size(97, 20)
        Me.TextBoxa.TabIndex = 137
        '
        'TextBoxKl
        '
        Me.TextBoxKl.AcceptsReturn = True
        Me.TextBoxKl.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxKl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxKl.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxKl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBoxKl.Location = New System.Drawing.Point(100, 326)
        Me.TextBoxKl.MaxLength = 0
        Me.TextBoxKl.Name = "TextBoxKl"
        Me.TextBoxKl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBoxKl.Size = New System.Drawing.Size(97, 20)
        Me.TextBoxKl.TabIndex = 136
        '
        'TextBoxKg
        '
        Me.TextBoxKg.AcceptsReturn = True
        Me.TextBoxKg.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxKg.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxKg.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxKg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBoxKg.Location = New System.Drawing.Point(100, 297)
        Me.TextBoxKg.MaxLength = 0
        Me.TextBoxKg.Name = "TextBoxKg"
        Me.TextBoxKg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBoxKg.Size = New System.Drawing.Size(97, 20)
        Me.TextBoxKg.TabIndex = 135
        '
        'Frame12
        '
        Me.Frame12.BackColor = System.Drawing.SystemColors.Control
        Me.Frame12.Controls.Add(Me.Label106)
        Me.Frame12.Controls.Add(Me.PictureBox2)
        Me.Frame12.Controls.Add(Me.Label101)
        Me.Frame12.Controls.Add(Me.Label96)
        Me.Frame12.Controls.Add(Me.TextBox5)
        Me.Frame12.Controls.Add(Me.TextBox4)
        Me.Frame12.Controls.Add(Me.Picture1)
        Me.Frame12.Controls.Add(Me.Text32)
        Me.Frame12.Controls.Add(Me.Text31)
        Me.Frame12.Controls.Add(Me.Text30)
        Me.Frame12.Controls.Add(Me.Label54)
        Me.Frame12.Controls.Add(Me.Label53)
        Me.Frame12.Controls.Add(Me.Label52)
        Me.Frame12.Controls.Add(Me.Label51)
        Me.Frame12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame12.Location = New System.Drawing.Point(8, 32)
        Me.Frame12.Name = "Frame12"
        Me.Frame12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame12.Size = New System.Drawing.Size(465, 184)
        Me.Frame12.TabIndex = 97
        Me.Frame12.TabStop = False
        Me.Frame12.Text = "Diffusion hydrique :"
        '
        'Label106
        '
        Me.Label106.BackColor = System.Drawing.SystemColors.Control
        Me.Label106.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label106.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label106.Location = New System.Drawing.Point(160, 160)
        Me.Label106.Name = "Label106"
        Me.Label106.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label106.Size = New System.Drawing.Size(24, 17)
        Me.Label106.TabIndex = 127
        Me.Label106.Text = "°K"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(216, 120)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(240, 56)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 126
        Me.PictureBox2.TabStop = False
        '
        'Label101
        '
        Me.Label101.Location = New System.Drawing.Point(8, 160)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(40, 16)
        Me.Label101.TabIndex = 110
        Me.Label101.Text = "To"
        '
        'Label96
        '
        Me.Label96.Location = New System.Drawing.Point(8, 136)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(48, 16)
        Me.Label96.TabIndex = 109
        Me.Label96.Text = "ED"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(56, 152)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 20)
        Me.TextBox5.TabIndex = 108
        Me.TextBox5.Text = "293.16"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(56, 128)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 107
        Me.TextBox4.Text = "0"
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Image = CType(resources.GetObject("Picture1.Image"), System.Drawing.Image)
        Me.Picture1.Location = New System.Drawing.Point(216, 16)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(240, 96)
        Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture1.TabIndex = 106
        Me.Picture1.TabStop = False
        '
        'Text32
        '
        Me.Text32.AcceptsReturn = True
        Me.Text32.BackColor = System.Drawing.SystemColors.Window
        Me.Text32.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text32.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text32.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text32.Location = New System.Drawing.Point(56, 64)
        Me.Text32.MaxLength = 0
        Me.Text32.Name = "Text32"
        Me.Text32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text32.Size = New System.Drawing.Size(97, 20)
        Me.Text32.TabIndex = 103
        Me.Text32.Text = "0.75"
        '
        'Text31
        '
        Me.Text31.AcceptsReturn = True
        Me.Text31.BackColor = System.Drawing.SystemColors.Window
        Me.Text31.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text31.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text31.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text31.Location = New System.Drawing.Point(56, 40)
        Me.Text31.MaxLength = 0
        Me.Text31.Name = "Text31"
        Me.Text31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text31.Size = New System.Drawing.Size(97, 20)
        Me.Text31.TabIndex = 102
        Me.Text31.Text = "0.05"
        '
        'Text30
        '
        Me.Text30.AcceptsReturn = True
        Me.Text30.BackColor = System.Drawing.SystemColors.Window
        Me.Text30.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text30.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text30.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text30.Location = New System.Drawing.Point(56, 16)
        Me.Text30.MaxLength = 0
        Me.Text30.Name = "Text30"
        Me.Text30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text30.Size = New System.Drawing.Size(97, 20)
        Me.Text30.TabIndex = 101
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.SystemColors.Control
        Me.Label54.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label54.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label54.Location = New System.Drawing.Point(160, 24)
        Me.Label54.Name = "Label54"
        Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label54.Size = New System.Drawing.Size(57, 17)
        Me.Label54.TabIndex = 104
        Me.Label54.Text = "mm2/s"
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.SystemColors.Control
        Me.Label53.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label53.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label53.Location = New System.Drawing.Point(8, 72)
        Me.Label53.Name = "Label53"
        Me.Label53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label53.Size = New System.Drawing.Size(25, 17)
        Me.Label53.TabIndex = 100
        Me.Label53.Text = "hc"
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.SystemColors.Control
        Me.Label52.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(8, 48)
        Me.Label52.Name = "Label52"
        Me.Label52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label52.Size = New System.Drawing.Size(33, 17)
        Me.Label52.TabIndex = 99
        Me.Label52.Text = "ao"
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.SystemColors.Control
        Me.Label51.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label51.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Location = New System.Drawing.Point(8, 24)
        Me.Label51.Name = "Label51"
        Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label51.Size = New System.Drawing.Size(129, 17)
        Me.Label51.TabIndex = 98
        Me.Label51.Text = "D100%"
        '
        'Frame13
        '
        Me.Frame13.BackColor = System.Drawing.SystemColors.Control
        Me.Frame13.Controls.Add(Me.PictureBox8)
        Me.Frame13.Controls.Add(Me.Button10)
        Me.Frame13.Controls.Add(Me.RadioButton3)
        Me.Frame13.Controls.Add(Me.RadioButton2)
        Me.Frame13.Controls.Add(Me.RadioButton1)
        Me.Frame13.Controls.Add(Me.Label56)
        Me.Frame13.Controls.Add(Me.Button9)
        Me.Frame13.Controls.Add(Me.PictureBox4)
        Me.Frame13.Controls.Add(Me.TextBox21)
        Me.Frame13.Controls.Add(Me.TextBox22)
        Me.Frame13.Controls.Add(Me.Label49)
        Me.Frame13.Controls.Add(Me.Label50)
        Me.Frame13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame13.Location = New System.Drawing.Point(488, 32)
        Me.Frame13.Name = "Frame13"
        Me.Frame13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame13.Size = New System.Drawing.Size(465, 248)
        Me.Frame13.TabIndex = 105
        Me.Frame13.TabStop = False
        Me.Frame13.Text = "Capillarité :"
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox8.Location = New System.Drawing.Point(-6, -18)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(478, 322)
        Me.PictureBox8.TabIndex = 135
        Me.PictureBox8.TabStop = False
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(264, 192)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 141
        Me.Button10.Text = "kT => E / C"
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(16, 216)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(160, 24)
        Me.RadioButton3.TabIndex = 140
        Me.RadioButton3.Text = "no capillary succion"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(16, 192)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(164, 24)
        Me.RadioButton2.TabIndex = 139
        Me.RadioButton2.Text = "hydrophobic treatment"
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(16, 168)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(144, 24)
        Me.RadioButton1.TabIndex = 138
        Me.RadioButton1.Text = "usual capillary succion"
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(104, 120)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(104, 16)
        Me.Label56.TabIndex = 135
        Me.Label56.Text = "Lunk"
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(16, 112)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 134
        Me.Button9.Text = "Change"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PictureBox4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(216, 40)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PictureBox4.Size = New System.Drawing.Size(240, 96)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 133
        Me.PictureBox4.TabStop = False
        '
        'TextBox21
        '
        Me.TextBox21.AcceptsReturn = True
        Me.TextBox21.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox21.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox21.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox21.Location = New System.Drawing.Point(72, 64)
        Me.TextBox21.MaxLength = 0
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox21.Size = New System.Drawing.Size(97, 20)
        Me.TextBox21.TabIndex = 132
        Me.TextBox21.Text = "0.95"
        '
        'TextBox22
        '
        Me.TextBox22.AcceptsReturn = True
        Me.TextBox22.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox22.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox22.Location = New System.Drawing.Point(72, 40)
        Me.TextBox22.MaxLength = 0
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox22.Size = New System.Drawing.Size(97, 20)
        Me.TextBox22.TabIndex = 131
        Me.TextBox22.Text = "0.09"
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.SystemColors.Control
        Me.Label49.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label49.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label49.Location = New System.Drawing.Point(24, 72)
        Me.Label49.Name = "Label49"
        Me.Label49.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label49.Size = New System.Drawing.Size(25, 17)
        Me.Label49.TabIndex = 130
        Me.Label49.Text = "tc"
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.SystemColors.Control
        Me.Label50.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label50.Location = New System.Drawing.Point(24, 48)
        Me.Label50.Name = "Label50"
        Me.Label50.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label50.Size = New System.Drawing.Size(33, 17)
        Me.Label50.TabIndex = 129
        Me.Label50.Text = "ao"
        '
        'Frame16
        '
        Me.Frame16.BackColor = System.Drawing.SystemColors.Control
        Me.Frame16.Controls.Add(Me.Text39)
        Me.Frame16.Controls.Add(Me.Label66)
        Me.Frame16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame16.Location = New System.Drawing.Point(8, 224)
        Me.Frame16.Name = "Frame16"
        Me.Frame16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame16.Size = New System.Drawing.Size(465, 56)
        Me.Frame16.TabIndex = 134
        Me.Frame16.TabStop = False
        Me.Frame16.Text = "Transfert à la surface :"
        '
        'Text39
        '
        Me.Text39.AcceptsReturn = True
        Me.Text39.BackColor = System.Drawing.SystemColors.Window
        Me.Text39.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text39.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text39.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text39.Location = New System.Drawing.Point(184, 16)
        Me.Text39.MaxLength = 0
        Me.Text39.Name = "Text39"
        Me.Text39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text39.Size = New System.Drawing.Size(129, 20)
        Me.Text39.TabIndex = 135
        Me.Text39.Text = "1"
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.SystemColors.Control
        Me.Label66.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label66.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label66.Location = New System.Drawing.Point(8, 24)
        Me.Label66.Name = "Label66"
        Me.Label66.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label66.Size = New System.Drawing.Size(201, 17)
        Me.Label66.TabIndex = 136
        Me.Label66.Text = "coefficient de transfert de surface"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PictureBox9)
        Me.TabPage2.Controls.Add(Me.GroupBox7)
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(960, 414)
        Me.TabPage2.TabIndex = 7
        Me.TabPage2.Text = "Carbonatation"
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox9.Location = New System.Drawing.Point(16, 3)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(954, 285)
        Me.PictureBox9.TabIndex = 2
        Me.PictureBox9.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.ComboBox9)
        Me.GroupBox7.Controls.Add(Me.ComboBox8)
        Me.GroupBox7.Controls.Add(Me.Label68)
        Me.GroupBox7.Controls.Add(Me.Label65)
        Me.GroupBox7.Controls.Add(Me.TextBox24)
        Me.GroupBox7.Controls.Add(Me.TextBox23)
        Me.GroupBox7.Controls.Add(Me.Label62)
        Me.GroupBox7.Controls.Add(Me.Label61)
        Me.GroupBox7.Controls.Add(Me.Label60)
        Me.GroupBox7.Location = New System.Drawing.Point(496, 16)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(440, 136)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Atmosphère"
        '
        'ComboBox9
        '
        Me.ComboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox9.Items.AddRange(New Object() {"campagne", "centre ville", "zone industrielle"})
        Me.ComboBox9.Location = New System.Drawing.Point(288, 104)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(121, 22)
        Me.ComboBox9.TabIndex = 8
        '
        'ComboBox8
        '
        Me.ComboBox8.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox8.Items.AddRange(New Object() {"campagne", "centre ville", "zone industrielle"})
        Me.ComboBox8.Location = New System.Drawing.Point(288, 72)
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(121, 22)
        Me.ComboBox8.TabIndex = 7
        '
        'Label68
        '
        Me.Label68.Location = New System.Drawing.Point(232, 80)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(24, 16)
        Me.Label68.TabIndex = 6
        Me.Label68.Text = "%"
        '
        'Label65
        '
        Me.Label65.Location = New System.Drawing.Point(232, 112)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(24, 16)
        Me.Label65.TabIndex = 5
        Me.Label65.Text = "%"
        '
        'TextBox24
        '
        Me.TextBox24.Location = New System.Drawing.Point(128, 72)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(100, 20)
        Me.TextBox24.TabIndex = 4
        '
        'TextBox23
        '
        Me.TextBox23.Location = New System.Drawing.Point(128, 104)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(100, 20)
        Me.TextBox23.TabIndex = 3
        '
        'Label62
        '
        Me.Label62.Location = New System.Drawing.Point(8, 104)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(100, 16)
        Me.Label62.TabIndex = 2
        Me.Label62.Text = "bord droit"
        '
        'Label61
        '
        Me.Label61.Location = New System.Drawing.Point(8, 72)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(100, 16)
        Me.Label61.TabIndex = 1
        Me.Label61.Text = "bord gauche"
        '
        'Label60
        '
        Me.Label60.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(8, 40)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(184, 16)
        Me.Label60.TabIndex = 0
        Me.Label60.Text = "concentration de CO2 dans l'air"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.ComboBox10)
        Me.GroupBox6.Controls.Add(Me.Label88)
        Me.GroupBox6.Controls.Add(Me.Label72)
        Me.GroupBox6.Controls.Add(Me.TextBox26)
        Me.GroupBox6.Controls.Add(Me.TextBox25)
        Me.GroupBox6.Controls.Add(Me.Label58)
        Me.GroupBox6.Controls.Add(Me.Label57)
        Me.GroupBox6.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(456, 136)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Masse volumique des composants du béton"
        '
        'ComboBox10
        '
        Me.ComboBox10.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox10.Items.AddRange(New Object() {"basalte", "silex", "gabbro", "granite", "gravillon", "cornéenne", "calcaire", "porphyre", "quartzite", "schiste"})
        Me.ComboBox10.Location = New System.Drawing.Point(320, 40)
        Me.ComboBox10.Name = "ComboBox10"
        Me.ComboBox10.Size = New System.Drawing.Size(121, 22)
        Me.ComboBox10.TabIndex = 7
        '
        'Label88
        '
        Me.Label88.Location = New System.Drawing.Point(272, 88)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(100, 16)
        Me.Label88.TabIndex = 5
        Me.Label88.Text = "kg/m3"
        '
        'Label72
        '
        Me.Label72.Location = New System.Drawing.Point(272, 40)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(100, 23)
        Me.Label72.TabIndex = 4
        Me.Label72.Text = "kg/m3"
        '
        'TextBox26
        '
        Me.TextBox26.Location = New System.Drawing.Point(168, 88)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(100, 20)
        Me.TextBox26.TabIndex = 3
        Me.TextBox26.Text = "3150"
        '
        'TextBox25
        '
        Me.TextBox25.Location = New System.Drawing.Point(168, 40)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New System.Drawing.Size(100, 20)
        Me.TextBox25.TabIndex = 2
        '
        'Label58
        '
        Me.Label58.Location = New System.Drawing.Point(8, 88)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(152, 23)
        Me.Label58.TabIndex = 1
        Me.Label58.Text = "masse volumique du ciment"
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(8, 40)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(160, 23)
        Me.Label57.TabIndex = 0
        Me.Label57.Text = "masse volumique des granulats"
        '
        '_SSTab1_TabPage4
        '
        Me._SSTab1_TabPage4.Controls.Add(Me.PictureBox10)
        Me._SSTab1_TabPage4.Controls.Add(Me.Frame17)
        Me._SSTab1_TabPage4.Controls.Add(Me.Frame20)
        Me._SSTab1_TabPage4.Controls.Add(Me.Frame21)
        Me._SSTab1_TabPage4.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage4.Name = "_SSTab1_TabPage4"
        Me._SSTab1_TabPage4.Size = New System.Drawing.Size(960, 414)
        Me._SSTab1_TabPage4.TabIndex = 4
        Me._SSTab1_TabPage4.Text = "Tranport ionique des chlorures"
        Me._SSTab1_TabPage4.Visible = False
        '
        'PictureBox10
        '
        Me.PictureBox10.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox10.Location = New System.Drawing.Point(7, 20)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(950, 363)
        Me.PictureBox10.TabIndex = 153
        Me.PictureBox10.TabStop = False
        '
        'Frame17
        '
        Me.Frame17.BackColor = System.Drawing.SystemColors.Control
        Me.Frame17.Controls.Add(Me.PictureBox6)
        Me.Frame17.Controls.Add(Me.PictureBox5)
        Me.Frame17.Controls.Add(Me.Label129)
        Me.Frame17.Controls.Add(Me.Label128)
        Me.Frame17.Controls.Add(Me.TextBox30)
        Me.Frame17.Controls.Add(Me.Label127)
        Me.Frame17.Controls.Add(Me.TextBox29)
        Me.Frame17.Controls.Add(Me.Label126)
        Me.Frame17.Controls.Add(Me.TextBox28)
        Me.Frame17.Controls.Add(Me.Label125)
        Me.Frame17.Controls.Add(Me.Text40)
        Me.Frame17.Controls.Add(Me.Label67)
        Me.Frame17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame17.Location = New System.Drawing.Point(488, 32)
        Me.Frame17.Name = "Frame17"
        Me.Frame17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame17.Size = New System.Drawing.Size(465, 272)
        Me.Frame17.TabIndex = 137
        Me.Frame17.TabStop = False
        Me.Frame17.Text = "Relation entre ions chlorures libres et liées :"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(160, 224)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(256, 32)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 149
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(160, 136)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(240, 72)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 148
        Me.PictureBox5.TabStop = False
        '
        'Label129
        '
        Me.Label129.BackColor = System.Drawing.SystemColors.Control
        Me.Label129.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label129.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label129.Location = New System.Drawing.Point(296, 112)
        Me.Label129.Name = "Label129"
        Me.Label129.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label129.Size = New System.Drawing.Size(32, 17)
        Me.Label129.TabIndex = 147
        Me.Label129.Text = "°K"
        '
        'Label128
        '
        Me.Label128.BackColor = System.Drawing.SystemColors.Control
        Me.Label128.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label128.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label128.Location = New System.Drawing.Point(296, 88)
        Me.Label128.Name = "Label128"
        Me.Label128.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label128.Size = New System.Drawing.Size(32, 17)
        Me.Label128.TabIndex = 146
        Me.Label128.Text = "J/mol"
        '
        'TextBox30
        '
        Me.TextBox30.AcceptsReturn = True
        Me.TextBox30.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox30.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox30.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox30.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox30.Location = New System.Drawing.Point(160, 104)
        Me.TextBox30.MaxLength = 0
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox30.Size = New System.Drawing.Size(129, 20)
        Me.TextBox30.TabIndex = 144
        Me.TextBox30.Text = "293.16"
        '
        'Label127
        '
        Me.Label127.BackColor = System.Drawing.SystemColors.Control
        Me.Label127.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label127.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label127.Location = New System.Drawing.Point(8, 112)
        Me.Label127.Name = "Label127"
        Me.Label127.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label127.Size = New System.Drawing.Size(136, 17)
        Me.Label127.TabIndex = 145
        Me.Label127.Text = "To"
        '
        'TextBox29
        '
        Me.TextBox29.AcceptsReturn = True
        Me.TextBox29.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox29.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox29.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox29.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox29.Location = New System.Drawing.Point(160, 80)
        Me.TextBox29.MaxLength = 0
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox29.Size = New System.Drawing.Size(129, 20)
        Me.TextBox29.TabIndex = 142
        Me.TextBox29.Text = "0"
        '
        'Label126
        '
        Me.Label126.BackColor = System.Drawing.SystemColors.Control
        Me.Label126.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label126.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label126.Location = New System.Drawing.Point(8, 88)
        Me.Label126.Name = "Label126"
        Me.Label126.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label126.Size = New System.Drawing.Size(136, 17)
        Me.Label126.TabIndex = 143
        Me.Label126.Text = "Eb"
        '
        'TextBox28
        '
        Me.TextBox28.AcceptsReturn = True
        Me.TextBox28.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox28.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox28.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox28.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox28.Location = New System.Drawing.Point(160, 56)
        Me.TextBox28.MaxLength = 0
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox28.Size = New System.Drawing.Size(129, 20)
        Me.TextBox28.TabIndex = 140
        Me.TextBox28.Text = "0.56"
        '
        'Label125
        '
        Me.Label125.BackColor = System.Drawing.SystemColors.Control
        Me.Label125.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label125.Font = New System.Drawing.Font("Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label125.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label125.Location = New System.Drawing.Point(8, 64)
        Me.Label125.Name = "Label125"
        Me.Label125.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label125.Size = New System.Drawing.Size(136, 17)
        Me.Label125.TabIndex = 141
        Me.Label125.Text = "aOH"
        '
        'Text40
        '
        Me.Text40.AcceptsReturn = True
        Me.Text40.BackColor = System.Drawing.SystemColors.Window
        Me.Text40.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text40.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text40.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text40.Location = New System.Drawing.Point(160, 32)
        Me.Text40.MaxLength = 0
        Me.Text40.Name = "Text40"
        Me.Text40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text40.Size = New System.Drawing.Size(129, 20)
        Me.Text40.TabIndex = 138
        Me.Text40.Text = "3.57"
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.SystemColors.Control
        Me.Label67.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label67.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label67.Location = New System.Drawing.Point(8, 40)
        Me.Label67.Name = "Label67"
        Me.Label67.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label67.Size = New System.Drawing.Size(136, 17)
        Me.Label67.TabIndex = 139
        Me.Label67.Text = "paramètre d'adsorption, fa"
        '
        'Frame20
        '
        Me.Frame20.BackColor = System.Drawing.SystemColors.Control
        Me.Frame20.Controls.Add(Me.CheckBox6)
        Me.Frame20.Controls.Add(Me.PictureBox3)
        Me.Frame20.Controls.Add(Me.Label110)
        Me.Frame20.Controls.Add(Me.Label109)
        Me.Frame20.Controls.Add(Me.Label108)
        Me.Frame20.Controls.Add(Me.TextBox9)
        Me.Frame20.Controls.Add(Me.TextBox8)
        Me.Frame20.Controls.Add(Me.Text46)
        Me.Frame20.Controls.Add(Me.Label78)
        Me.Frame20.Controls.Add(Me.Label74)
        Me.Frame20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame20.Location = New System.Drawing.Point(8, 32)
        Me.Frame20.Name = "Frame20"
        Me.Frame20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame20.Size = New System.Drawing.Size(465, 144)
        Me.Frame20.TabIndex = 148
        Me.Frame20.TabStop = False
        Me.Frame20.Text = "Diffusion dans l'eau :"
        '
        'CheckBox6
        '
        Me.CheckBox6.Checked = True
        Me.CheckBox6.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox6.Location = New System.Drawing.Point(224, 24)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(152, 24)
        Me.CheckBox6.TabIndex = 158
        Me.CheckBox6.Text = "Valeur en fonction de E/C"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(280, 88)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(176, 40)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 156
        Me.PictureBox3.TabStop = False
        '
        'Label110
        '
        Me.Label110.BackColor = System.Drawing.SystemColors.Control
        Me.Label110.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label110.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label110.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label110.Location = New System.Drawing.Point(160, 112)
        Me.Label110.Name = "Label110"
        Me.Label110.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label110.Size = New System.Drawing.Size(73, 17)
        Me.Label110.TabIndex = 157
        Me.Label110.Text = "°C"
        '
        'Label109
        '
        Me.Label109.Location = New System.Drawing.Point(8, 112)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(24, 16)
        Me.Label109.TabIndex = 155
        Me.Label109.Text = "To"
        '
        'Label108
        '
        Me.Label108.Font = New System.Drawing.Font("Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label108.Location = New System.Drawing.Point(8, 80)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(24, 16)
        Me.Label108.TabIndex = 154
        Me.Label108.Text = "a"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(48, 104)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(100, 20)
        Me.TextBox9.TabIndex = 153
        Me.TextBox9.Text = "20"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(48, 72)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(100, 20)
        Me.TextBox8.TabIndex = 152
        Me.TextBox8.Text = "0.026"
        '
        'Text46
        '
        Me.Text46.AcceptsReturn = True
        Me.Text46.BackColor = System.Drawing.SystemColors.Window
        Me.Text46.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text46.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text46.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text46.Location = New System.Drawing.Point(48, 24)
        Me.Text46.MaxLength = 0
        Me.Text46.Name = "Text46"
        Me.Text46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text46.Size = New System.Drawing.Size(97, 20)
        Me.Text46.TabIndex = 149
        '
        'Label78
        '
        Me.Label78.BackColor = System.Drawing.SystemColors.Control
        Me.Label78.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label78.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label78.Location = New System.Drawing.Point(8, 32)
        Me.Label78.Name = "Label78"
        Me.Label78.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label78.Size = New System.Drawing.Size(129, 17)
        Me.Label78.TabIndex = 151
        Me.Label78.Text = "Dcl,To"
        '
        'Label74
        '
        Me.Label74.BackColor = System.Drawing.SystemColors.Control
        Me.Label74.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label74.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label74.Location = New System.Drawing.Point(160, 32)
        Me.Label74.Name = "Label74"
        Me.Label74.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label74.Size = New System.Drawing.Size(73, 17)
        Me.Label74.TabIndex = 150
        Me.Label74.Text = "mm2/s"
        '
        'Frame21
        '
        Me.Frame21.BackColor = System.Drawing.SystemColors.Control
        Me.Frame21.Controls.Add(Me.Text49)
        Me.Frame21.Controls.Add(Me.Text48)
        Me.Frame21.Controls.Add(Me.Label82)
        Me.Frame21.Controls.Add(Me.Label81)
        Me.Frame21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame21.Location = New System.Drawing.Point(8, 200)
        Me.Frame21.Name = "Frame21"
        Me.Frame21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame21.Size = New System.Drawing.Size(465, 104)
        Me.Frame21.TabIndex = 152
        Me.Frame21.TabStop = False
        Me.Frame21.Text = "Convection par l'eau :"
        '
        'Text49
        '
        Me.Text49.AcceptsReturn = True
        Me.Text49.BackColor = System.Drawing.SystemColors.Window
        Me.Text49.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text49.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text49.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text49.Location = New System.Drawing.Point(128, 24)
        Me.Text49.MaxLength = 0
        Me.Text49.Name = "Text49"
        Me.Text49.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text49.Size = New System.Drawing.Size(97, 20)
        Me.Text49.TabIndex = 154
        Me.Text49.Text = "0.7"
        '
        'Text48
        '
        Me.Text48.AcceptsReturn = True
        Me.Text48.BackColor = System.Drawing.SystemColors.Window
        Me.Text48.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text48.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text48.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text48.Location = New System.Drawing.Point(320, 64)
        Me.Text48.MaxLength = 0
        Me.Text48.Name = "Text48"
        Me.Text48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text48.Size = New System.Drawing.Size(97, 20)
        Me.Text48.TabIndex = 153
        Me.Text48.Text = "0.8"
        '
        'Label82
        '
        Me.Label82.BackColor = System.Drawing.SystemColors.Control
        Me.Label82.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label82.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label82.Location = New System.Drawing.Point(8, 32)
        Me.Label82.Name = "Label82"
        Me.Label82.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label82.Size = New System.Drawing.Size(129, 17)
        Me.Label82.TabIndex = 156
        Me.Label82.Text = "coefficient de retard"
        '
        'Label81
        '
        Me.Label81.BackColor = System.Drawing.SystemColors.Control
        Me.Label81.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label81.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label81.Location = New System.Drawing.Point(8, 72)
        Me.Label81.Name = "Label81"
        Me.Label81.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label81.Size = New System.Drawing.Size(312, 17)
        Me.Label81.TabIndex = 155
        Me.Label81.Text = "teneur limite en eau pour la convection de l'humidité relative"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.NumClExt)
        Me.TabPage1.Controls.Add(Me.NumTempExt)
        Me.TabPage1.Controls.Add(Me.NumHRExt)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label31)
        Me.TabPage1.Controls.Add(Me.Label32)
        Me.TabPage1.Controls.Add(Me.Label64)
        Me.TabPage1.Controls.Add(Me.Label69)
        Me.TabPage1.Controls.Add(Me.Label48)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(960, 414)
        Me.TabPage1.TabIndex = 6
        Me.TabPage1.Text = "Conditions initiales"
        '
        'NumClExt
        '
        Me.NumClExt.Location = New System.Drawing.Point(131, 111)
        Me.NumClExt.Name = "NumClExt"
        Me.NumClExt.Size = New System.Drawing.Size(120, 20)
        Me.NumClExt.TabIndex = 165
        '
        'NumTempExt
        '
        Me.NumTempExt.Location = New System.Drawing.Point(131, 42)
        Me.NumTempExt.Name = "NumTempExt"
        Me.NumTempExt.Size = New System.Drawing.Size(120, 20)
        Me.NumTempExt.TabIndex = 164
        '
        'NumHRExt
        '
        Me.NumHRExt.Location = New System.Drawing.Point(131, 77)
        Me.NumHRExt.Name = "NumHRExt"
        Me.NumHRExt.Size = New System.Drawing.Size(120, 20)
        Me.NumHRExt.TabIndex = 163
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(25, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(160, 17)
        Me.Label10.TabIndex = 162
        Me.Label10.Text = "Conc Cl- Externe"
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.Control
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(25, 80)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(153, 17)
        Me.Label31.TabIndex = 161
        Me.Label31.Text = "Humidité Externe"
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.SystemColors.Control
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(3, 45)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(131, 17)
        Me.Label32.TabIndex = 160
        Me.Label32.Text = "Temperature Externe"
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.SystemColors.Control
        Me.Label64.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label64.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label64.Location = New System.Drawing.Point(256, 72)
        Me.Label64.Name = "Label64"
        Me.Label64.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label64.Size = New System.Drawing.Size(696, 17)
        Me.Label64.TabIndex = 153
        '
        'Label69
        '
        Me.Label69.BackColor = System.Drawing.SystemColors.Control
        Me.Label69.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label69.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label69.Location = New System.Drawing.Point(256, 120)
        Me.Label69.Name = "Label69"
        Me.Label69.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label69.Size = New System.Drawing.Size(696, 24)
        Me.Label69.TabIndex = 152
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.SystemColors.Control
        Me.Label48.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label48.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.Location = New System.Drawing.Point(256, 24)
        Me.Label48.Name = "Label48"
        Me.Label48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label48.Size = New System.Drawing.Size(696, 17)
        Me.Label48.TabIndex = 151
        '
        '_SSTab1_TabPage5
        '
        Me._SSTab1_TabPage5.Controls.Add(Me.PictureBox11)
        Me._SSTab1_TabPage5.Controls.Add(Me.GroupBox8)
        Me._SSTab1_TabPage5.Controls.Add(Me.GroupBox5)
        Me._SSTab1_TabPage5.Controls.Add(Me.GroupBox4)
        Me._SSTab1_TabPage5.Controls.Add(Me.Frame22)
        Me._SSTab1_TabPage5.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage5.Name = "_SSTab1_TabPage5"
        Me._SSTab1_TabPage5.Size = New System.Drawing.Size(960, 414)
        Me._SSTab1_TabPage5.TabIndex = 5
        Me._SSTab1_TabPage5.Text = "Analyse probabiliste"
        Me._SSTab1_TabPage5.Visible = False
        '
        'PictureBox11
        '
        Me.PictureBox11.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox11.Location = New System.Drawing.Point(8, 16)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(944, 395)
        Me.PictureBox11.TabIndex = 163
        Me.PictureBox11.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox8.Controls.Add(Me.Label141)
        Me.GroupBox8.Controls.Add(Me.Label142)
        Me.GroupBox8.Controls.Add(Me.Label143)
        Me.GroupBox8.Controls.Add(Me.Label144)
        Me.GroupBox8.Controls.Add(Me.CheckBox7)
        Me.GroupBox8.Controls.Add(Me.Label145)
        Me.GroupBox8.Controls.Add(Me.Label146)
        Me.GroupBox8.Controls.Add(Me.Label147)
        Me.GroupBox8.Controls.Add(Me.TextBox6)
        Me.GroupBox8.Controls.Add(Me.Label148)
        Me.GroupBox8.Controls.Add(Me.ComboBox11)
        Me.GroupBox8.Controls.Add(Me.Label149)
        Me.GroupBox8.Controls.Add(Me.Label150)
        Me.GroupBox8.Controls.Add(Me.Label151)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox8.Location = New System.Drawing.Point(488, 184)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox8.Size = New System.Drawing.Size(464, 152)
        Me.GroupBox8.TabIndex = 162
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Carbonatation"
        '
        'Label141
        '
        Me.Label141.Location = New System.Drawing.Point(304, 96)
        Me.Label141.Name = "Label141"
        Me.Label141.Size = New System.Drawing.Size(152, 16)
        Me.Label141.TabIndex = 189
        Me.Label141.Text = "X2 ="
        '
        'Label142
        '
        Me.Label142.Location = New System.Drawing.Point(304, 80)
        Me.Label142.Name = "Label142"
        Me.Label142.Size = New System.Drawing.Size(152, 16)
        Me.Label142.TabIndex = 188
        Me.Label142.Text = "X1 ="
        '
        'Label143
        '
        Me.Label143.Location = New System.Drawing.Point(304, 64)
        Me.Label143.Name = "Label143"
        Me.Label143.Size = New System.Drawing.Size(152, 16)
        Me.Label143.TabIndex = 187
        Me.Label143.Text = "P+ ="
        '
        'Label144
        '
        Me.Label144.Location = New System.Drawing.Point(304, 48)
        Me.Label144.Name = "Label144"
        Me.Label144.Size = New System.Drawing.Size(152, 16)
        Me.Label144.TabIndex = 186
        Me.Label144.Text = "P- ="
        '
        'CheckBox7
        '
        Me.CheckBox7.Location = New System.Drawing.Point(336, 120)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(104, 24)
        Me.CheckBox7.TabIndex = 185
        Me.CheckBox7.Text = "Loi probabiliste"
        '
        'Label145
        '
        Me.Label145.BackColor = System.Drawing.SystemColors.Control
        Me.Label145.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label145.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label145.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label145.Location = New System.Drawing.Point(160, 104)
        Me.Label145.Name = "Label145"
        Me.Label145.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label145.Size = New System.Drawing.Size(144, 17)
        Me.Label145.TabIndex = 184
        '
        'Label146
        '
        Me.Label146.BackColor = System.Drawing.SystemColors.Control
        Me.Label146.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label146.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label146.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label146.Location = New System.Drawing.Point(160, 80)
        Me.Label146.Name = "Label146"
        Me.Label146.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label146.Size = New System.Drawing.Size(144, 17)
        Me.Label146.TabIndex = 183
        '
        'Label147
        '
        Me.Label147.BackColor = System.Drawing.SystemColors.Control
        Me.Label147.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label147.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label147.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label147.Location = New System.Drawing.Point(160, 32)
        Me.Label147.Name = "Label147"
        Me.Label147.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label147.Size = New System.Drawing.Size(128, 17)
        Me.Label147.TabIndex = 182
        Me.Label147.Text = "1"
        '
        'TextBox6
        '
        Me.TextBox6.AcceptsReturn = True
        Me.TextBox6.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox6.Location = New System.Drawing.Point(160, 56)
        Me.TextBox6.MaxLength = 0
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox6.Size = New System.Drawing.Size(96, 20)
        Me.TextBox6.TabIndex = 174
        Me.TextBox6.Text = "0.000005772"
        '
        'Label148
        '
        Me.Label148.BackColor = System.Drawing.SystemColors.Control
        Me.Label148.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label148.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label148.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label148.Location = New System.Drawing.Point(8, 104)
        Me.Label148.Name = "Label148"
        Me.Label148.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label148.Size = New System.Drawing.Size(152, 17)
        Me.Label148.TabIndex = 172
        Me.Label148.Text = "paramètre ksi (lognormale) :"
        '
        'ComboBox11
        '
        Me.ComboBox11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox11.Items.AddRange(New Object() {"loi normale", "loi lognormale"})
        Me.ComboBox11.Location = New System.Drawing.Point(328, 16)
        Me.ComboBox11.Name = "ComboBox11"
        Me.ComboBox11.Size = New System.Drawing.Size(121, 22)
        Me.ComboBox11.TabIndex = 170
        '
        'Label149
        '
        Me.Label149.BackColor = System.Drawing.SystemColors.Control
        Me.Label149.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label149.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label149.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label149.Location = New System.Drawing.Point(8, 56)
        Me.Label149.Name = "Label149"
        Me.Label149.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label149.Size = New System.Drawing.Size(129, 17)
        Me.Label149.TabIndex = 160
        Me.Label149.Text = "écat type (loi normale) :"
        '
        'Label150
        '
        Me.Label150.BackColor = System.Drawing.SystemColors.Control
        Me.Label150.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label150.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label150.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label150.Location = New System.Drawing.Point(8, 80)
        Me.Label150.Name = "Label150"
        Me.Label150.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label150.Size = New System.Drawing.Size(168, 17)
        Me.Label150.TabIndex = 173
        Me.Label150.Text = "paramètre lambda (lognormale) :"
        '
        'Label151
        '
        Me.Label151.BackColor = System.Drawing.SystemColors.Control
        Me.Label151.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label151.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label151.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label151.Location = New System.Drawing.Point(8, 32)
        Me.Label151.Name = "Label151"
        Me.Label151.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label151.Size = New System.Drawing.Size(168, 17)
        Me.Label151.TabIndex = 171
        Me.Label151.Text = "valeur moyenne (loi normale) :"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.Label137)
        Me.GroupBox5.Controls.Add(Me.Label138)
        Me.GroupBox5.Controls.Add(Me.Label139)
        Me.GroupBox5.Controls.Add(Me.Label140)
        Me.GroupBox5.Controls.Add(Me.CheckBox4)
        Me.GroupBox5.Controls.Add(Me.Label133)
        Me.GroupBox5.Controls.Add(Me.Label132)
        Me.GroupBox5.Controls.Add(Me.Label131)
        Me.GroupBox5.Controls.Add(Me.TextBox19)
        Me.GroupBox5.Controls.Add(Me.Label120)
        Me.GroupBox5.Controls.Add(Me.ComboBox6)
        Me.GroupBox5.Controls.Add(Me.Label122)
        Me.GroupBox5.Controls.Add(Me.Label119)
        Me.GroupBox5.Controls.Add(Me.Label121)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox5.Location = New System.Drawing.Point(8, 184)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox5.Size = New System.Drawing.Size(464, 152)
        Me.GroupBox5.TabIndex = 161
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Transport ionique des chlorures"
        '
        'Label137
        '
        Me.Label137.Location = New System.Drawing.Point(304, 96)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(152, 16)
        Me.Label137.TabIndex = 189
        Me.Label137.Text = "X2 ="
        '
        'Label138
        '
        Me.Label138.Location = New System.Drawing.Point(304, 80)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(152, 16)
        Me.Label138.TabIndex = 188
        Me.Label138.Text = "X1 ="
        '
        'Label139
        '
        Me.Label139.Location = New System.Drawing.Point(304, 64)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(152, 16)
        Me.Label139.TabIndex = 187
        Me.Label139.Text = "P+ ="
        '
        'Label140
        '
        Me.Label140.Location = New System.Drawing.Point(304, 48)
        Me.Label140.Name = "Label140"
        Me.Label140.Size = New System.Drawing.Size(152, 16)
        Me.Label140.TabIndex = 186
        Me.Label140.Text = "P- ="
        '
        'CheckBox4
        '
        Me.CheckBox4.Location = New System.Drawing.Point(336, 120)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(104, 24)
        Me.CheckBox4.TabIndex = 185
        Me.CheckBox4.Text = "Loi probabiliste"
        '
        'Label133
        '
        Me.Label133.BackColor = System.Drawing.SystemColors.Control
        Me.Label133.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label133.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label133.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label133.Location = New System.Drawing.Point(160, 104)
        Me.Label133.Name = "Label133"
        Me.Label133.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label133.Size = New System.Drawing.Size(144, 17)
        Me.Label133.TabIndex = 184
        '
        'Label132
        '
        Me.Label132.BackColor = System.Drawing.SystemColors.Control
        Me.Label132.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label132.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label132.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label132.Location = New System.Drawing.Point(160, 80)
        Me.Label132.Name = "Label132"
        Me.Label132.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label132.Size = New System.Drawing.Size(144, 17)
        Me.Label132.TabIndex = 183
        '
        'Label131
        '
        Me.Label131.BackColor = System.Drawing.SystemColors.Control
        Me.Label131.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label131.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label131.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label131.Location = New System.Drawing.Point(160, 32)
        Me.Label131.Name = "Label131"
        Me.Label131.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label131.Size = New System.Drawing.Size(128, 17)
        Me.Label131.TabIndex = 182
        Me.Label131.Text = "1"
        '
        'TextBox19
        '
        Me.TextBox19.AcceptsReturn = True
        Me.TextBox19.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox19.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox19.Location = New System.Drawing.Point(160, 56)
        Me.TextBox19.MaxLength = 0
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox19.Size = New System.Drawing.Size(96, 20)
        Me.TextBox19.TabIndex = 174
        Me.TextBox19.Text = "0.000005772"
        '
        'Label120
        '
        Me.Label120.BackColor = System.Drawing.SystemColors.Control
        Me.Label120.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label120.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label120.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label120.Location = New System.Drawing.Point(8, 104)
        Me.Label120.Name = "Label120"
        Me.Label120.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label120.Size = New System.Drawing.Size(152, 17)
        Me.Label120.TabIndex = 172
        Me.Label120.Text = "paramètre ksi (lognormale) :"
        '
        'ComboBox6
        '
        Me.ComboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox6.Items.AddRange(New Object() {"loi normale", "loi lognormale"})
        Me.ComboBox6.Location = New System.Drawing.Point(328, 16)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(121, 22)
        Me.ComboBox6.TabIndex = 170
        '
        'Label122
        '
        Me.Label122.BackColor = System.Drawing.SystemColors.Control
        Me.Label122.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label122.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label122.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label122.Location = New System.Drawing.Point(8, 56)
        Me.Label122.Name = "Label122"
        Me.Label122.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label122.Size = New System.Drawing.Size(129, 17)
        Me.Label122.TabIndex = 160
        Me.Label122.Text = "écat type (loi normale) :"
        '
        'Label119
        '
        Me.Label119.BackColor = System.Drawing.SystemColors.Control
        Me.Label119.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label119.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label119.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label119.Location = New System.Drawing.Point(8, 80)
        Me.Label119.Name = "Label119"
        Me.Label119.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label119.Size = New System.Drawing.Size(168, 17)
        Me.Label119.TabIndex = 173
        Me.Label119.Text = "paramètre lambda (lognormale) :"
        '
        'Label121
        '
        Me.Label121.BackColor = System.Drawing.SystemColors.Control
        Me.Label121.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label121.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label121.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label121.Location = New System.Drawing.Point(8, 32)
        Me.Label121.Name = "Label121"
        Me.Label121.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label121.Size = New System.Drawing.Size(168, 17)
        Me.Label121.TabIndex = 171
        Me.Label121.Text = "valeur moyenne (loi normale) :"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.Label115)
        Me.GroupBox4.Controls.Add(Me.Label116)
        Me.GroupBox4.Controls.Add(Me.Label117)
        Me.GroupBox4.Controls.Add(Me.Label118)
        Me.GroupBox4.Controls.Add(Me.CheckBox3)
        Me.GroupBox4.Controls.Add(Me.Label134)
        Me.GroupBox4.Controls.Add(Me.Label130)
        Me.GroupBox4.Controls.Add(Me.Label107)
        Me.GroupBox4.Controls.Add(Me.Label105)
        Me.GroupBox4.Controls.Add(Me.TextBox15)
        Me.GroupBox4.Controls.Add(Me.Label79)
        Me.GroupBox4.Controls.Add(Me.ComboBox5)
        Me.GroupBox4.Controls.Add(Me.Label112)
        Me.GroupBox4.Controls.Add(Me.Label77)
        Me.GroupBox4.Controls.Add(Me.Label80)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox4.Location = New System.Drawing.Point(488, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox4.Size = New System.Drawing.Size(464, 152)
        Me.GroupBox4.TabIndex = 160
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Transport hydrique d'eau liquide par capillarité"
        '
        'Label115
        '
        Me.Label115.Location = New System.Drawing.Point(304, 96)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(152, 16)
        Me.Label115.TabIndex = 189
        Me.Label115.Text = "X2 ="
        '
        'Label116
        '
        Me.Label116.Location = New System.Drawing.Point(304, 80)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(152, 16)
        Me.Label116.TabIndex = 188
        Me.Label116.Text = "X1 ="
        '
        'Label117
        '
        Me.Label117.Location = New System.Drawing.Point(304, 64)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(152, 16)
        Me.Label117.TabIndex = 187
        Me.Label117.Text = "P+ ="
        '
        'Label118
        '
        Me.Label118.Location = New System.Drawing.Point(304, 48)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(152, 16)
        Me.Label118.TabIndex = 186
        Me.Label118.Text = "P- ="
        '
        'CheckBox3
        '
        Me.CheckBox3.Location = New System.Drawing.Point(336, 120)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(104, 24)
        Me.CheckBox3.TabIndex = 185
        Me.CheckBox3.Text = "Loi probabiliste"
        '
        'Label134
        '
        Me.Label134.BackColor = System.Drawing.SystemColors.Control
        Me.Label134.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label134.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label134.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label134.Location = New System.Drawing.Point(280, 32)
        Me.Label134.Name = "Label134"
        Me.Label134.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label134.Size = New System.Drawing.Size(40, 17)
        Me.Label134.TabIndex = 184
        Me.Label134.Text = "à 10°C"
        '
        'Label130
        '
        Me.Label130.BackColor = System.Drawing.SystemColors.Control
        Me.Label130.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label130.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label130.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label130.Location = New System.Drawing.Point(160, 104)
        Me.Label130.Name = "Label130"
        Me.Label130.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label130.Size = New System.Drawing.Size(144, 17)
        Me.Label130.TabIndex = 183
        '
        'Label107
        '
        Me.Label107.BackColor = System.Drawing.SystemColors.Control
        Me.Label107.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label107.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label107.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label107.Location = New System.Drawing.Point(160, 80)
        Me.Label107.Name = "Label107"
        Me.Label107.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label107.Size = New System.Drawing.Size(144, 17)
        Me.Label107.TabIndex = 182
        '
        'Label105
        '
        Me.Label105.BackColor = System.Drawing.SystemColors.Control
        Me.Label105.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label105.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label105.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label105.Location = New System.Drawing.Point(160, 32)
        Me.Label105.Name = "Label105"
        Me.Label105.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label105.Size = New System.Drawing.Size(128, 17)
        Me.Label105.TabIndex = 181
        Me.Label105.Text = "1"
        '
        'TextBox15
        '
        Me.TextBox15.AcceptsReturn = True
        Me.TextBox15.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox15.Location = New System.Drawing.Point(160, 56)
        Me.TextBox15.MaxLength = 0
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox15.Size = New System.Drawing.Size(104, 20)
        Me.TextBox15.TabIndex = 174
        Me.TextBox15.Text = "0.00005962"
        '
        'Label79
        '
        Me.Label79.BackColor = System.Drawing.SystemColors.Control
        Me.Label79.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label79.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label79.Location = New System.Drawing.Point(8, 104)
        Me.Label79.Name = "Label79"
        Me.Label79.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label79.Size = New System.Drawing.Size(152, 17)
        Me.Label79.TabIndex = 172
        Me.Label79.Text = "paramètre ksi (lognormale) :"
        '
        'ComboBox5
        '
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.Items.AddRange(New Object() {"loi normale", "loi lognormale"})
        Me.ComboBox5.Location = New System.Drawing.Point(328, 16)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(121, 22)
        Me.ComboBox5.TabIndex = 170
        '
        'Label112
        '
        Me.Label112.BackColor = System.Drawing.SystemColors.Control
        Me.Label112.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label112.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label112.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label112.Location = New System.Drawing.Point(8, 56)
        Me.Label112.Name = "Label112"
        Me.Label112.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label112.Size = New System.Drawing.Size(129, 17)
        Me.Label112.TabIndex = 160
        Me.Label112.Text = "écat type (loi normale) :"
        '
        'Label77
        '
        Me.Label77.BackColor = System.Drawing.SystemColors.Control
        Me.Label77.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label77.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label77.Location = New System.Drawing.Point(8, 80)
        Me.Label77.Name = "Label77"
        Me.Label77.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label77.Size = New System.Drawing.Size(168, 17)
        Me.Label77.TabIndex = 173
        Me.Label77.Text = "paramètre lambda (lognormale) :"
        '
        'Label80
        '
        Me.Label80.BackColor = System.Drawing.SystemColors.Control
        Me.Label80.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label80.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label80.Location = New System.Drawing.Point(8, 32)
        Me.Label80.Name = "Label80"
        Me.Label80.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label80.Size = New System.Drawing.Size(168, 17)
        Me.Label80.TabIndex = 171
        Me.Label80.Text = "valeur moyenne (loi normale) :"
        '
        'Frame22
        '
        Me.Frame22.BackColor = System.Drawing.SystemColors.Control
        Me.Frame22.Controls.Add(Me.Label135)
        Me.Frame22.Controls.Add(Me.Label136)
        Me.Frame22.Controls.Add(Me.Label104)
        Me.Frame22.Controls.Add(Me.Label59)
        Me.Frame22.Controls.Add(Me.Label55)
        Me.Frame22.Controls.Add(Me.Label114)
        Me.Frame22.Controls.Add(Me.Label113)
        Me.Frame22.Controls.Add(Me.TextBox10)
        Me.Frame22.Controls.Add(Me.Label76)
        Me.Frame22.Controls.Add(Me.ComboBox4)
        Me.Frame22.Controls.Add(Me.CheckBox2)
        Me.Frame22.Controls.Add(Me.Label73)
        Me.Frame22.Controls.Add(Me.Label75)
        Me.Frame22.Controls.Add(Me.Label111)
        Me.Frame22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame22.Location = New System.Drawing.Point(8, 16)
        Me.Frame22.Name = "Frame22"
        Me.Frame22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame22.Size = New System.Drawing.Size(464, 152)
        Me.Frame22.TabIndex = 159
        Me.Frame22.TabStop = False
        Me.Frame22.Text = "Transport hydrique de vapeur d'eau"
        '
        'Label135
        '
        Me.Label135.Location = New System.Drawing.Point(304, 96)
        Me.Label135.Name = "Label135"
        Me.Label135.Size = New System.Drawing.Size(152, 16)
        Me.Label135.TabIndex = 183
        Me.Label135.Text = "X2 ="
        '
        'Label136
        '
        Me.Label136.Location = New System.Drawing.Point(304, 80)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(152, 16)
        Me.Label136.TabIndex = 182
        Me.Label136.Text = "X1 ="
        '
        'Label104
        '
        Me.Label104.BackColor = System.Drawing.SystemColors.Control
        Me.Label104.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label104.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label104.Location = New System.Drawing.Point(160, 104)
        Me.Label104.Name = "Label104"
        Me.Label104.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label104.Size = New System.Drawing.Size(144, 17)
        Me.Label104.TabIndex = 181
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.SystemColors.Control
        Me.Label59.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label59.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label59.Location = New System.Drawing.Point(160, 80)
        Me.Label59.Name = "Label59"
        Me.Label59.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label59.Size = New System.Drawing.Size(144, 17)
        Me.Label59.TabIndex = 180
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.SystemColors.Control
        Me.Label55.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label55.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label55.Location = New System.Drawing.Point(160, 32)
        Me.Label55.Name = "Label55"
        Me.Label55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label55.Size = New System.Drawing.Size(128, 17)
        Me.Label55.TabIndex = 179
        Me.Label55.Text = "1"
        '
        'Label114
        '
        Me.Label114.Location = New System.Drawing.Point(304, 64)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(152, 16)
        Me.Label114.TabIndex = 178
        Me.Label114.Text = "P+ ="
        '
        'Label113
        '
        Me.Label113.Location = New System.Drawing.Point(304, 48)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(152, 16)
        Me.Label113.TabIndex = 177
        Me.Label113.Text = "P- ="
        '
        'TextBox10
        '
        Me.TextBox10.AcceptsReturn = True
        Me.TextBox10.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox10.Location = New System.Drawing.Point(160, 56)
        Me.TextBox10.MaxLength = 0
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox10.Size = New System.Drawing.Size(112, 20)
        Me.TextBox10.TabIndex = 174
        Me.TextBox10.Text = "0.0002308"
        '
        'Label76
        '
        Me.Label76.BackColor = System.Drawing.SystemColors.Control
        Me.Label76.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label76.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label76.Location = New System.Drawing.Point(8, 104)
        Me.Label76.Name = "Label76"
        Me.Label76.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label76.Size = New System.Drawing.Size(152, 17)
        Me.Label76.TabIndex = 172
        Me.Label76.Text = "paramètre ksi (lognormale) :"
        '
        'ComboBox4
        '
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.Items.AddRange(New Object() {"loi normale", "loi lognormale"})
        Me.ComboBox4.Location = New System.Drawing.Point(328, 16)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(121, 22)
        Me.ComboBox4.TabIndex = 170
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(336, 120)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(104, 24)
        Me.CheckBox2.TabIndex = 169
        Me.CheckBox2.Text = "Loi probabiliste"
        '
        'Label73
        '
        Me.Label73.BackColor = System.Drawing.SystemColors.Control
        Me.Label73.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label73.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label73.Location = New System.Drawing.Point(8, 56)
        Me.Label73.Name = "Label73"
        Me.Label73.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label73.Size = New System.Drawing.Size(129, 17)
        Me.Label73.TabIndex = 160
        Me.Label73.Text = "écat type (loi normale) :"
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.SystemColors.Control
        Me.Label75.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label75.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label75.Location = New System.Drawing.Point(8, 80)
        Me.Label75.Name = "Label75"
        Me.Label75.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label75.Size = New System.Drawing.Size(168, 17)
        Me.Label75.TabIndex = 173
        Me.Label75.Text = "paramètre lambda (lognormale) :"
        '
        'Label111
        '
        Me.Label111.BackColor = System.Drawing.SystemColors.Control
        Me.Label111.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label111.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label111.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label111.Location = New System.Drawing.Point(8, 32)
        Me.Label111.Name = "Label111"
        Me.Label111.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label111.Size = New System.Drawing.Size(160, 17)
        Me.Label111.TabIndex = 171
        Me.Label111.Text = "valeur moyenne (loi normale) :"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Enabled = False
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(800, 512)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(81, 33)
        Me.Command1.TabIndex = 5
        Me.Command1.Text = "&Ok"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(896, 464)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 32)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "O&pen"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label102)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Controls.Add(Me.Command3)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 448)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(184, 100)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Materials"
        '
        'Label102
        '
        Me.Label102.Location = New System.Drawing.Point(8, 80)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(152, 16)
        Me.Label102.TabIndex = 20
        Me.Label102.Text = "Number of material(s) : 0"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(104, 24)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 23)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Delete"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Location = New System.Drawing.Point(8, 56)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(168, 21)
        Me.ComboBox2.TabIndex = 18
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(8, 24)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(72, 24)
        Me.Command3.TabIndex = 17
        Me.Command3.Text = "New"
        Me.Command3.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox5)
        Me.GroupBox3.Controls.Add(Me.Label87)
        Me.GroupBox3.Controls.Add(Me.Label71)
        Me.GroupBox3.Controls.Add(Me.ComboBox7)
        Me.GroupBox3.Controls.Add(Me.Label103)
        Me.GroupBox3.Controls.Add(Me.ComboBox3)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Location = New System.Drawing.Point(208, 448)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(440, 100)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Exposition"
        '
        'CheckBox5
        '
        Me.CheckBox5.Location = New System.Drawing.Point(8, 64)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(144, 24)
        Me.CheckBox5.TabIndex = 25
        Me.CheckBox5.Text = "Exposure on 2 side"
        '
        'Label87
        '
        Me.Label87.Location = New System.Drawing.Point(8, 40)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(72, 16)
        Me.Label87.TabIndex = 24
        Me.Label87.Text = "left side"
        '
        'Label71
        '
        Me.Label71.Location = New System.Drawing.Point(376, 40)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(52, 16)
        Me.Label71.TabIndex = 23
        Me.Label71.Text = "right side"
        '
        'ComboBox7
        '
        Me.ComboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox7.Location = New System.Drawing.Point(248, 16)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(184, 21)
        Me.ComboBox7.TabIndex = 22
        '
        'Label103
        '
        Me.Label103.Location = New System.Drawing.Point(144, 48)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(144, 16)
        Me.Label103.TabIndex = 21
        Me.Label103.Text = "Number of exposition(s) : 0"
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Location = New System.Drawing.Point(8, 16)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(184, 21)
        Me.ComboBox3.TabIndex = 20
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(360, 72)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 19
        Me.Button5.Text = "Delete"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(272, 72)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "New"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(792, 464)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(104, 24)
        Me.CheckBox1.TabIndex = 20
        Me.CheckBox1.Text = "Field activation"
        '
        'frmInput2D
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(984, 551)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.SSTab1)
        Me.Controls.Add(Me.Command1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmInput2D"
        Me.Text = "Input 2D"
        Me.SSTab1.ResumeLayout(False)
        Me._SSTab1_TabPage0.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        CType(Me.NumClInt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumTempInt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumHRInt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me._SSTab1_TabPage1.ResumeLayout(False)
        Me.Frame4.ResumeLayout(False)
        Me.Frame4.PerformLayout()
        Me.Frame5.ResumeLayout(False)
        Me.Frame5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame6.ResumeLayout(False)
        Me.Frame6.PerformLayout()
        Me._SSTab1_TabPage2.ResumeLayout(False)
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame7.ResumeLayout(False)
        Me.Frame7.PerformLayout()
        Me.Frame8.ResumeLayout(False)
        Me.Frame8.PerformLayout()
        Me._SSTab1_TabPage3.ResumeLayout(False)
        Me._SSTab1_TabPage3.PerformLayout()
        Me.Frame12.ResumeLayout(False)
        Me.Frame12.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame13.ResumeLayout(False)
        Me.Frame13.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame16.ResumeLayout(False)
        Me.Frame16.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me._SSTab1_TabPage4.ResumeLayout(False)
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame17.ResumeLayout(False)
        Me.Frame17.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame20.ResumeLayout(False)
        Me.Frame20.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame21.ResumeLayout(False)
        Me.Frame21.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.NumClExt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumTempExt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumHRExt, System.ComponentModel.ISupportInitialize).EndInit()
        Me._SSTab1_TabPage5.ResumeLayout(False)
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Frame22.ResumeLayout(False)
        Me.Frame22.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim Var03 As Short = 0
    Const Mat As Integer = 40
    Dim Bara1(Mat, 10000) As String
    Dim ChoixRep As Short
    Dim nChmt As Short
    Dim Nbreel(1) As Short
    Dim LenApp(1) As Single
    Dim FileGexpo(1) As String
    Dim FileDexpo(1) As String
    Dim i As Short
    Dim j As Short
    Dim NEXPO As Short = 0
    Dim Creadtherm(1, 1) As Double
    Dim Creadhydr(1, 1) As Double
    Dim Creadion(1, 1) As Double

    'Chargement de la feuille
    Private Sub frmOption1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        CheckBox1.Checked = False
        Option4.Checked = True
        Text1.Text = CStr(0)
        TextC.Text = CStr(0)
        Text3.Text = ""
        Text4.Text = ""
        Text44.Text = CStr(0)
        Text45.Text = CStr(0)
        Label92.Text = CStr(2550)
        TextBoxRho_c.Text = CStr(2550)
        TextBox2.Text = CStr(0)
        TextBox3.Text = CStr(0)
        Text5.Text = CStr(73000)
        Text6.Text = CStr(3600)
        Text10.Text = CStr(8760)
        Text11.Text = CStr(8760)
        Text12.Text = CStr(8760)
        TextBox27.Text = CStr(8760)
        Text13.Text = CStr(8760)
        Text14.Text = CStr(8760)
        Text15.Text = CStr(720)
        Text16.Text = CStr(5)
        Text17.Text = CStr(0.4)
        Text18.Text = CStr(0.1)
        Text19.Text = CStr(50)
        Text20.Text = CStr(10)
        Text21.Text = CStr(0)
        Text22.Text = CStr(1)
        Text23.Text = CStr(0)
        Text24.Text = CStr(5)
        Text26.Text = CStr(1)
        Text30.Text = CStr(0)
        Text31.Text = CStr(0.05)
        Text32.Text = CStr(0.75)
        TextBox4.Text = CStr(0)
        TextBox5.Text = CStr(293.16)
        Label56.Text = "Lunk"
        TextBox21.Text = CStr(0.95)
        TextBox22.Text = CStr(0.09)
        TextBox26.Text = CStr(3150)
        TextBox23.Text = CStr(0.036)
        TextBox24.Text = CStr(0.036)
        TextBox8.Text = CStr(0.026)
        TextBox9.Text = CStr(20)
        Text48.Text = CStr(0.8)
        Text49.Text = CStr(0.7)
        Text40.Text = CStr(3.57)
        TextBox28.Text = CStr(0.56)
        TextBox29.Text = CStr(0)
        TextBox30.Text = CStr(293.16)
        Label48.Text = ""
        Label64.Text = ""
        Label69.Text = ""
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox7.Checked = False
        Label102.Text = "Number of material(s) : 0"
        Label103.Text = "Number of exposition(s) : 0"
        CheckBox5.Enabled = True
        Combo5.SelectedIndex = 0
        ComboBox1.SelectedIndex = 3
        Text1.BackColor = Me.BackColor
        Text1.BorderStyle = BorderStyle.None
        Text1.Enabled = False
        TextBoxRho_c.BackColor = Me.BackColor
        TextBoxRho_c.BorderStyle = BorderStyle.None
        TextBoxRho_c.Enabled = False
        Var03 = CShort(1)
        Button3.Enabled = False
        Button5.Enabled = False
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        ComboBox7.Items.Clear()
        ComboBox10.SelectedIndex = 1
        ComboBox9.SelectedIndex = 1
        ComboBox8.SelectedIndex = 1
        ComboBox4.SelectedIndex = 1
        ComboBox5.SelectedIndex = 1
        ComboBox6.SelectedIndex = 1
        ComboBox11.SelectedIndex = 1
        RadioButton1.Checked = True
        CheckBox5.Checked = True
        NEXPO = 0
        ComboBox4.Visible = False
        Label73.Visible = False
        Label75.Visible = False
        Label76.Visible = False
        Label111.Visible = False
        Label55.Visible = False
        Label59.Visible = False
        Label104.Visible = False
        Label113.Visible = False
        Label114.Visible = False
        Label135.Visible = False
        Label136.Visible = False
        TextBox10.Visible = False
        ComboBox5.Visible = False
        Label77.Visible = False
        Label79.Visible = False
        Label80.Visible = False
        Label112.Visible = False
        Label105.Visible = False
        Label107.Visible = False
        Label130.Visible = False
        Label115.Visible = False
        Label116.Visible = False
        Label117.Visible = False
        Label118.Visible = False
        Label134.Visible = False
        TextBox15.Visible = False
        ComboBox6.Visible = False
        Label119.Visible = False
        Label120.Visible = False
        Label121.Visible = False
        Label122.Visible = False
        Label131.Visible = False
        Label132.Visible = False
        Label133.Visible = False
        Label137.Visible = False
        Label138.Visible = False
        Label139.Visible = False
        Label140.Visible = False
        TextBox19.Visible = False
        ComboBox11.Visible = False
        Label150.Visible = False
        Label148.Visible = False
        Label151.Visible = False
        Label149.Visible = False
        Label147.Visible = False
        Label146.Visible = False
        Label145.Visible = False
        Label142.Visible = False
        Label141.Visible = False
        Label143.Visible = False
        Label144.Visible = False
        TextBox6.Visible = False
        CmtTextProb10()

        If CheckBox6.Checked = True Then
            Text46.Text = CStr((0.0943 * System.Math.Exp(CDbl(TextBox3.Text) * 7.899)) * 0.000001)
        End If

    End Sub

    'Click sur Ok
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click

        Dim aa As Single ' Function coefficient
        Dim Hc As Single ' Function coefficient
        Dim ab As Single ' Function coefficient
        Dim tc As Single ' Function coefficient
        Dim aOH As Single
        Dim EbG As Single
        Dim toG As Single
        Dim faG As Single
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
        Dim TimeMax As Single
        Dim Length As Single 'length of the layer [mm]
        Dim Ne As Short 'Number of finite elements
        Dim Le(1) As Decimal 'element length
        Dim DeltaT As Single
        Dim taff As Single
        Dim Hsauv As Single
        Dim Wsauv As Single
        Dim CTsauv As Single
        Dim CLsauv As Single
        Dim Tsauv As Single
        Dim Carbsauv As Single
        Dim capCal As Single
        Dim GyCO2 As Single
        Dim DyCO2 As Single

        Dim nFic As Short
        Dim Filtre As String
        Dim Index As Short
        Dim Directoire As Boolean
        Dim Titre As String
        Dim Canc As Boolean = False
        Dim OutFile As String
        Dim PostFile As String
        Dim Var As Double
        Dim Var1 As Double
        Dim ImpHydr As Boolean

        Dim option2D As Boolean

        ''''''''''''''''''''''''''''''''''
        Filtre = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        Index = CShort(1)
        Directoire = True
        Titre = "Enregistrer le fichier d'input"
        SaveDialog(OutFile, Canc, Filtre, Index, Directoire, Titre)
        If Canc = True Then GoTo b
        ''''''''''''''''''''''''''''''''''

        FilePost(OutFile, PostFile)
        FileOnly(OutFile)
        OutFile = PostFile & "INPUT2D_" & CStr(OutFile)

        Lecture(Length, Ne, TimeMax, DeltaT, taff, Hsauv, Wsauv, CTsauv, CLsauv, Tsauv, hMin, hEcart, wMin, wEcart, CTmin, CTecart, CLmin, CLecart, Tecart, aa, Hc, ab, tc, H_snap, Retard, aOH, EbG, toG, faG, capCal, GyCO2, DyCO2, Carbsauv, ImpHydr)

        'If Creadtherm(0, Nbre1) < Length Or Creadhydr(0, Nbre2) < Length Or Creadion(0, Nbre3) < Length Then
        '    MsgBox("Format de fichier des conditions initiales invalide", MsgBoxStyle.Information, "Avertissement")
        '    Exit Sub
        'End If

        Ecriture(nFic, OutFile, Length, Ne, Le, TimeMax, DeltaT, taff, Hsauv, Wsauv, CTsauv, CLsauv, Tsauv, hMin, hEcart, wMin, wEcart, CTmin, CTecart, CLmin, CLecart, Tecart, aa, Hc, ab, tc, H_snap, Retard, aOH, EbG, toG, faG, NEXPO, capCal, GyCO2, DyCO2, Carbsauv, ImpHydr)

        Me.Hide()
        Me.Close()

b:
    End Sub

    'Click sur Cancel
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click

        Me.Hide()
        Exit Sub

    End Sub

    'Click sur new dans materials
    Private Sub Command3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command3.Click

        Dim Message As String = ""
        If Label48.Text = "" Or Label64.Text = "" Or Label69.Text = "" Then
            MsgBox("Manque les conditions initiales", MsgBoxStyle.Information, "Avertissement")
            Exit Sub
        End If
        CtrlParam(Message)

        If Message <> "0" Then
            Message = "0"
            Exit Sub
        End If

        Var03 = Var03 + CShort(1)

        If Var03 > 0 Then
            DesChamp()
            If NEXPO <> 0 Then Command1.Enabled = True
            CheckBox1.Checked = True
        End If
        StPara(Var03 - 1)

        ComboBox2.Items.Add("Material " & CStr(Var03 - 1))
        ComboBox2.SelectedIndex = Var03 - 2
        Button3.Enabled = True
        Label102.Text = "Number of material(s) : " & Var03 - 1

    End Sub

    'Click sur delete dans materials
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim PosNum As Short
        Dim Can As MsgBoxResult

        PosNum = CShort(ComboBox2.SelectedIndex)

        Can = MsgBox("Voulez-vous vraiment effacer cette exposition ?", MsgBoxStyle.YesNo, "Avertissment")
        If Can = MsgBoxResult.No Then GoTo b

        For i = PosNum + CShort(1) To Var03 'ici ce n'est pas Var03-1, ceci évite de mettre des zéros à la dernière ligne var03
            EffPara(CInt(i))
        Next

        Var03 = Var03 - CShort(1)

        ComboBox2.Items.Clear()
        For i = 1 To Var03 - CShort(1)
            ComboBox2.Items.Add("Material " & i)
        Next
        ComboBox2.SelectedIndex = PosNum - 1
        Label102.Text = "Number of material(s) : " & Var03 - 1
        If Var03 = 1 Then
            Button3.Enabled = False
            DesChamp()
            CheckBox1.Checked = False
            Command1.Enabled = False
        End If
b:
    End Sub

    'Click sur new dans exposition
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim UserInput1 As String
        Dim nFic As Short
        Dim Filtre As String
        Dim Index As Short
        Dim Directoire As Boolean
        Dim Titre As String
        Dim Canc As Boolean = False
        Dim OutFile As String = ""

        CheckBox5.Enabled = False

        NEXPO = NEXPO + CShort(1)
        ReDim Preserve FileGexpo(NEXPO)
        ReDim Preserve FileDexpo(NEXPO)

        ''''''''''''''''''''''''''''''''''''''''''''
        Filtre = "txt files (EXPO_*.txt)|EXPO_*.txt|All files (*.*)|*.*"
        Index = CShort(1)
        Directoire = True
        Titre = "Sélectionner le fichier d'exposition du bord gauche"
        OpenDialog(OutFile, Canc, Filtre, Index, Directoire, Titre)
        If Canc = True Then GoTo b
        '''''''''''''''''''''''''''''''''''''''''''''
        FileGexpo(NEXPO) = OutFile
        FileOnly(OutFile)
        ComboBox3.Items.Add(NEXPO & " " & OutFile)
        Label103.Text = "Number of exposition(s) : " & NEXPO

        If Var03 <> 0 Then Command1.Enabled = True
        Button5.Enabled = True

        If CheckBox5.Checked = False Then
            ComboBox7.Items.Add("noFile")
            FileDexpo(NEXPO) = "noFile"
        Else
            ''''''''''''''''''''''''''''''''''''''''''''
            Filtre = "txt files (EXPO_*.txt)|EXPO_*.txt|All files (*.*)|*.*"
            Index = CShort(1)
            Directoire = True
            Titre = "Sélectionner le fichier d'exposition du bord droit"
            OpenDialog(OutFile, Canc, Filtre, Index, Directoire, Titre)
            If Canc = True Then GoTo b
            '''''''''''''''''''''''''''''''''''''''''''''
            FileDexpo(NEXPO) = OutFile
            FileOnly(OutFile)
            ComboBox7.Items.Add(NEXPO & " " & OutFile)
        End If
        ComboBox3.SelectedIndex = NEXPO - 1
        ComboBox7.SelectedIndex = NEXPO - 1

b:
    End Sub

    'Click sur delete dans exposition
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim PosNum As Short
        Dim Can As MsgBoxResult


        PosNum = CShort(ComboBox3.SelectedIndex)

        Can = MsgBox("Voulez-vous vraiment effacer cette exposition ?", MsgBoxStyle.YesNo, "Avertissment")
        If Can = MsgBoxResult.No Then GoTo b

        For i = PosNum + CShort(1) To NEXPO - CShort(1)
            FileGexpo(i) = FileGexpo(i + 1)
            FileDexpo(i) = FileDexpo(i + 1)
        Next
        NEXPO = NEXPO - CShort(1)
        ReDim Preserve FileDexpo(NEXPO)
        ReDim Preserve FileGexpo(NEXPO)

        ComboBox3.Items.Clear()
        ComboBox7.Items.Clear()
        For i = 1 To NEXPO
            ComboBox3.Items.Add(i & " " & FileGexpo(i))
            ComboBox7.Items.Add(i & " " & FileDexpo(i))
        Next
        If PosNum > NEXPO Then PosNum = NEXPO
        ComboBox3.SelectedIndex = PosNum - 1
        ComboBox7.SelectedIndex = PosNum - 1
        Label103.Text = "Number of exposition(s) : " & NEXPO
        If NEXPO = 0 Then
            Button5.Enabled = False
            Command1.Enabled = False
        End If
        If Label103.Text = "Number of exposition(s) : 0" Then CheckBox5.Enabled = True
b:
    End Sub

    'Click sur Open
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim aa As Single ' Function coefficient
        Dim Hc As Single ' Function coefficient
        Dim ab As Single ' Function coefficient
        Dim tc As Single ' Function coefficient
        Dim aOH As Single
        Dim EbG As Single
        Dim toG As Single
        Dim faG As Single
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
        Dim TimeMax As Single
        Dim Length As Single 'length of the layer [mm]
        Dim Ne As Short 'Number of finite elements
        Dim Le(1) As Decimal 'element length
        Dim DeltaT As Single
        Dim NPROB As Short
        Dim taff As Single
        Dim Hsauv As Single
        Dim Wsauv As Single
        Dim CTsauv As Single
        Dim CLsauv As Single
        Dim Tsauv As Single
        Dim Carbsauv As Single
        Dim capCal As Single
        Dim nFic As Integer = FreeFile()
        Dim OutFile As String = ""
        Dim Filtre As String
        Dim Index As Short
        Dim Directoire As Boolean
        Dim Titre As String
        Dim Canc As Boolean = False
        Dim GyCO2 As Single
        Dim DyCO2 As Single
        Dim ImpHydr As Boolean

        ActChamp()

        ''''''''''''''''''''''''''''''''''''''''''''
        Filtre = "Text files (INPUT2D_*.txt)|INPUT2D_*.txt"
        Index = 1
        Directoire = True
        Titre = "Sélectionner le fichier d'exposition"
        OpenDialog(OutFile, Canc, Filtre, Index, Directoire, Titre)
        If Canc = True Then GoTo b
        '''''''''''''''''''''''''''''''''''''''''''''

        FileOpen(nFic, OutFile, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)

        Input(nFic, Length)
        Input(nFic, Ne)
        Input(nFic, ChoixRep)

        Select Case ChoixRep
            Case CShort(1)
                'pas de changement
            Case CShort(2)
                Input(nFic, Le(1))
            Case 3
                Input(nFic, Le(1))
            Case 4
                Input(nFic, nChmt)
                ReDim Nbreel(nChmt - CShort(1))
                ReDim LenApp(nChmt - CShort(1))
                For i = CShort(1) To nChmt - CShort(1)
                    Input(nFic, Nbreel(i))
                    Input(nFic, LenApp(i))
                Next i
            Case 5
                Input(nFic, nChmt)
                ReDim Nbreel(nChmt - CShort(1))
                ReDim LenApp(nChmt - CShort(1))
                For i = CShort(1) To nChmt - CShort(1)
                    Input(nFic, Nbreel(i))
                    Input(nFic, LenApp(i))
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
        Input(nFic, CTmin)
        Input(nFic, CTecart)
        Input(nFic, CLmin)
        Input(nFic, CLecart)
        Input(nFic, Tecart)
        Input(nFic, aa)
        Input(nFic, Hc)
        Input(nFic, ab)
        Input(nFic, tc)
        If ab = 0 And tc = 0 Then
            RadioButton3.Checked = True
        Else
            RadioButton1.Checked = True
        End If
        Input(nFic, ImpHydr)
        If ImpHydr = True Then RadioButton2.Checked = True
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

        Input(nFic, Var03)

        For i = CShort(1) To Var03
            For j = CShort(1) To Mat
                Input(nFic, Bara1(j, i))
            Next j
        Next i

        Input(nFic, 2)
        'ReDim Creadtherm(1, Nbre1)
        'For i = 1 To Nbre1
        Input(nFic, Creadtherm(0, i))
        Input(nFic, Creadtherm(1, i))
        'Next
        Input(nFic, 2)
        'ReDim Creadhydr(1, Nbre2)
        'For i = 1 To Nbre2
        Input(nFic, Creadhydr(0, i))
        Input(nFic, Creadhydr(1, i))
        'Next
        Input(nFic, 2)
        'ReDim Creadion(1, Nbre3)
        'For i = 1 To Nbre3
        Input(nFic, Creadion(0, i))
        Input(nFic, Creadion(1, i))
        'Next



        FileClose(nFic)

        Text5.Text = CStr(TimeMax)
        Text6.Text = CStr(DeltaT)
        Text15.Text = CStr(taff)
        Text11.Text = CStr(Hsauv)
        Text12.Text = CStr(Wsauv)
        Text14.Text = CStr(CTsauv)
        Text13.Text = CStr(CLsauv)
        Text10.Text = CStr(Tsauv)
        TextBox27.Text = CStr(Carbsauv)
        Text17.Text = CStr(hMin)
        Text18.Text = CStr(hEcart)
        Text19.Text = CStr(wMin)
        Text20.Text = CStr(wEcart)
        Text23.Text = CStr(CTmin)
        Text24.Text = CStr(CTecart)
        Text21.Text = CStr(CLmin)
        Text22.Text = CStr(CLecart)
        Text16.Text = CStr(Tecart)
        Text31.Text = CStr(aa)
        Text32.Text = CStr(Hc)
        TextBox22.Text = CStr(ab)
        TextBox21.Text = CStr(tc)
        Text48.Text = CStr(H_snap)
        Text49.Text = CStr(Retard)
        TextBox28.Text = CStr(aOH)
        TextBox29.Text = CStr(EbG)
        TextBox30.Text = CStr(toG)
        Text40.Text = CStr(faG)
        Text25.Text = CStr(capCal)
        TextBox24.Text = CStr(GyCO2)
        TextBox23.Text = CStr(DyCO2)

        WrPara(Var03)

        If Var03 > 1 Then
            DesChamp()
        End If

        ComboBox3.Items.Clear()
        ComboBox7.Items.Clear()
        For i = 1 To NEXPO
            OutFile = FileGexpo(i)
            FileOnly(OutFile)
            ComboBox3.Items.Add(i & " " & OutFile)
            OutFile = FileDexpo(i)
            FileOnly(OutFile)
            ComboBox7.Items.Add(i & " " & OutFile)
        Next

        ComboBox2.Items.Clear()
        For i = 1 To Var03
            ComboBox2.Items.Add("Material " & i)
        Next i
        Label48.Text = "CIT_.txt"
        Label64.Text = "CIH_.txt"
        Label69.Text = "CII_.txt"
        Label103.Text = "Number of exposition(s) : " & NEXPO
        Label102.Text = "Number of material(s) : " & Var03
        Var03 = Var03 + CShort(1)
        ComboBox2.SelectedIndex = Var03 - 2
        ComboBox3.SelectedIndex = NEXPO - 1
        ComboBox7.SelectedIndex = NEXPO - 1
        Option4.Checked = True
        Button3.Enabled = True
        Button5.Enabled = True
        Command1.Enabled = True
b:
        FileClose(nFic)
    End Sub

    'Click sur défaut
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim omegaE As Double
        omegaE = 0.389 - 26.0 * CDbl(TextBox3.Text) / 15.0 + 4.4 * CDbl(TextBox3.Text) ^ 2.0 - 8.0 * CDbl(TextBox3.Text) ^ 3.0 / 3.0
        Text44.Text = CStr((CDbl(TextBox3.Text) - omegaE) / (0.17 + 0.23 * omegaE))
    End Sub

    'Click sur Change
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        If Label56.Text = "Lunk" Then
            TextBox21.Text = CStr(0.97)
            TextBox22.Text = CStr(0.05)
            Label56.Text = "Mayer"
        ElseIf Label56.Text = "Mayer" Then
            TextBox21.Text = CStr(0.97)
            TextBox22.Text = CStr(0.09)
            Label56.Text = "essai DC"
        ElseIf Label56.Text = "essai DC" Then
            TextBox21.Text = CStr(0.95)
            TextBox22.Text = CStr(0.09)
            Label56.Text = "Lunk"
        End If

    End Sub

    'click sur kT => E / C    -    Valeur du coefficient de Torrent
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim UserInput As String
        Dim canc As Boolean
        Dim Can As MsgBoxResult
        UserInput = InputBox("Paramètre kT [10-16m2] :", "Essai de perméabilité à l'air Torrent, valeur corrigée", CStr(0))
        Msg_noEntry(UserInput, canc)
        If canc = False Then Msg_noNumeric(UserInput, canc)
        If canc = True Then Exit Sub
        UserInput = CStr(0.0866383424571846 * System.Math.Log(CDbl(UserInput)) + 0.72509628011073)
        Can = MsgBox("Voulez-vous changer le rapport massique de l'eau sur le ciment (E / C = " & UserInput & ") ?", MsgBoxStyle.YesNo, "Avertissment ")
        If Can = MsgBoxResult.Yes Then TextBox3.Text = UserInput
    End Sub

    'Changement de matériel, affichage
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim PosNum As Short

        PosNum = CShort(ComboBox2.SelectedIndex + 1)

        WrPara(PosNum)
        Option4.Checked = True
    End Sub

    'Type de maillage
    '    Private Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '        Dim UserInput1 As String
    '        Dim i As Short
    '        Dim Var01 As Single
    '        Dim Var02 As Single
    '        Dim x1Min As Single
    '        Dim x1Max As Single
    '        Dim nFic As Single
    '        Dim Canc As Boolean

    '        Dim frm01 As frmGraph1DScale
    '        frm01 = New frmGraph1DScale

    '        Select Case Combo1.Text
    '            Case "1: écart constant"
    '                Label10.Visible = False
    '                Label32.Visible = False
    '                Text9.Visible = False
    '                ChoixRep = CShort(1)
    '            Case "2: écart proportionnel"
    '                Label10.Visible = True
    '                Label32.Visible = True
    '                Text9.Visible = True
    '                ChoixRep = CShort(2)
    '            Case "3: écart exponentiel"
    '                Label10.Visible = True
    '                Label32.Visible = True
    '                Text9.Visible = True
    '                ChoixRep = CShort(3)
    '            Case "4: plusieurs écarts constants"
    '                Label10.Visible = False
    '                Label32.Visible = False
    '                Text9.Visible = False
    '                ChoixRep = CShort(4)
    '                Canc = False
    '                UserInput1 = InputBox("Entrez le nombre total d'écarts constants :", "Ecarts constants", CStr(0))
    '                Msg_noEntry(UserInput1, Canc)
    '                If Canc = False Then Msg_noNumeric(UserInput1, Canc)

    '                If Canc = True Then Exit Sub

    '                nChmt = CShort(UserInput1)
    '                ReDim Nbreel(nChmt - CShort(1))
    '                ReDim LenApp(nChmt - CShort(1))
    '                Var01 = CSng(Text7.Text) / CSng(2)
    '                Var02 = CSng(Text8.Text) / CSng(2)
    '                For i = CShort(1) To nChmt - CShort(1)
    '                    frm01.Frame1.Visible = False
    '                    frm01.Text6.Visible = False
    '                    frm01.Label6.Visible = False
    '                    frm01.Text = "écart" & CStr(nChmt)
    '                    frm01.Label8.Text = "écart n° " & CStr(i)
    '                    frm01.Label4.Text = "Nombre d'éléments :"
    '                    frm01.Label5.Text = "Longeur de l'intervalle :"
    '                    frm01.Text4.Text = CStr(Var02)
    '                    frm01.Text5.Text = CStr(Var01)
    'a:                  frm01.ShowDialog()
    '                    x1Min = CSng(frm01.Text4.Text) 'min
    '                    x1Max = CSng(frm01.Text5.Text) 'max
    '                    If x1Min > Var02 Or x1Max > Var01 Then GoTo a
    '                    Nbreel(i) = CShort(frm01.Text4.Text)
    '                    LenApp(i) = CSng(frm01.Text5.Text)
    '                    Var02 = Var02 - x1Min
    '                    Var01 = Var01 - x1Max
    '                    frm01.Close()
    '                Next i
    '            Case "5: plusieurs écarts constants, non symétrique"
    '                Label10.Visible = False
    '                Label32.Visible = False
    '                Text9.Visible = False
    '                ChoixRep = CShort(5)
    '                Canc = False
    '                UserInput1 = InputBox("Entrez le nombre total d'écarts constants :", "Ecarts constants", CStr(0))
    '                Msg_noEntry(UserInput1, Canc)
    '                If Canc = False Then Msg_noNumeric(UserInput1, Canc)

    '                If Canc = True Then Exit Sub

    '                nChmt = CShort(UserInput1)
    '                ReDim Nbreel(nChmt - CShort(1))
    '                ReDim LenApp(nChmt - CShort(1))
    '                Var01 = CSng(Text7.Text)
    '                Var02 = CSng(Text8.Text)
    '                For i = CShort(1) To nChmt - CShort(1)
    '                    frm01.Frame1.Visible = False
    '                    frm01.Text6.Visible = False
    '                    frm01.Label6.Visible = False
    '                    frm01.Text = "écart" & CStr(nChmt)
    '                    frm01.Label8.Text = "écart n° " & CStr(i)
    '                    frm01.Label4.Text = "Nombre d'éléments :"
    '                    frm01.Label5.Text = "Longeur de l'intervalle :"
    '                    frm01.Text4.Text = CStr(Var02)
    '                    frm01.Text5.Text = CStr(Var01)
    'b:                  frm01.ShowDialog()
    '                    x1Min = CSng(frm01.Text4.Text) 'min
    '                    x1Max = CSng(frm01.Text5.Text) 'max
    '                    If x1Min > Var02 Or x1Max > Var01 Then GoTo b
    '                    Nbreel(i) = CShort(frm01.Text4.Text)
    '                    LenApp(i) = CSng(frm01.Text5.Text)
    '                    Var02 = Var02 - x1Min
    '                    Var01 = Var01 - x1Max
    '                    frm01.Close()
    '                Next i

    '        End Select
    '    End Sub

    'Sélection d'un autre type de ciment
    Private Sub Combo5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo5.SelectedIndexChanged
        Select Case Combo5.Text
            Case "Type 1"
                Label100.Text = "Ciment Portland"
            Case "Type 2"
                Label100.Text = "Ciment Portland composé"
            Case "Type 3"
                Label100.Text = "Ciment de haut-fourneau"
            Case "Type 4"
                Label100.Text = "Ciment pouzzolanique"
        End Select
    End Sub

    'Sélection d'un autre type de granulat pour la capacité calorifique
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.Text
            Case "siliceux"
                Label99.Text = "kJ / kg °K"
                Text25.BackColor = System.Drawing.Color.LightGray
                Text25.BorderStyle = BorderStyle.None
                Text25.Text = "0.73"
                Text25.Enabled = False
            Case "calcaire"
                Label99.Text = "kJ / kg °K"
                Text25.BackColor = System.Drawing.Color.LightGray
                Text25.BorderStyle = BorderStyle.None
                Text25.Text = "0.84"
                Text25.Enabled = False
            Case "chaux + calcaire"
                Label99.Text = "kJ / kg °K"
                Text25.BackColor = System.Drawing.Color.LightGray
                Text25.BorderStyle = BorderStyle.None
                Text25.Text = "0.89"
                Text25.Enabled = False
            Case "autres"
                Label99.Text = "kJ / kg °K (valeur comprise entre 0.7-0.9"
                Text25.Enabled = True
                Text25.BackColor = System.Drawing.Color.White
                Text25.BorderStyle = BorderStyle.Fixed3D
                Text25.Text = "0.7"
        End Select
    End Sub

    'changement de la liste des conditions de bord gauche
    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim Nbre As Integer
        Nbre = ComboBox3.SelectedIndex
        ComboBox7.SelectedIndex = Nbre
    End Sub

    'changement de la liste des conditions de bord droit
    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox7.SelectedIndexChanged
        Dim Nbre As Integer
        Nbre = ComboBox7.SelectedIndex
        ComboBox3.SelectedIndex = Nbre
    End Sub

    'choix du type de granulat pour la carbonatation
    Private Sub ComboBox10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.SelectedIndexChanged
        Select Case ComboBox10.Text
            Case "basalte"
                TextBox25.Text = CStr(2850)
            Case "silex"
                TextBox25.Text = CStr(2550)
            Case "gabbro"
                TextBox25.Text = CStr(2950)
            Case "granite"
                TextBox25.Text = CStr(2690)
            Case "gravillon"
                TextBox25.Text = CStr(2670)
            Case "cornéenne"
                TextBox25.Text = CStr(2880)
            Case "calcaire"
                TextBox25.Text = CStr(2690)
            Case "porphyre"
                TextBox25.Text = CStr(2660)
            Case "quartzite"
                TextBox25.Text = CStr(2620)
            Case "schiste"
                TextBox25.Text = CStr(2760)
        End Select
    End Sub

    'choix de la région pour la quantité de CO2
    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        Select Case ComboBox8.Text
            Case "campagne"
                TextBox24.Text = CStr(0.015)
            Case "centre ville"
                TextBox24.Text = CStr(0.036)
            Case "zone industrielle"
                TextBox24.Text = CStr(0.045)
        End Select
    End Sub

    'choix de la région pour la quantité de CO2
    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.SelectedIndexChanged
        Select Case ComboBox9.Text
            Case "campagne"
                TextBox23.Text = CStr(0.015)
            Case "centre ville"
                TextBox23.Text = CStr(0.036)
            Case "zone industrielle"
                TextBox23.Text = CStr(0.045)
        End Select
    End Sub

    'Choix des caractéristiques de perméabilité du béton
    Private Sub OptionCheckedChanged(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles Option1.CheckedChanged, Option2.CheckedChanged, Option3.CheckedChanged

        If Option1.Checked = True Then
            Text4.Text = "bon_béton"
            Text3.Text = "bon"
            Text30.Text = CStr(0.00006)   'coefficient de diffusion de vapeur d'eau
            Text46.Text = CStr(0.000006)    'coefficient de diffusion des ions chlorures
            Text25.Text = CStr(0.7)         'capacité calorifique des granulats
            Text39.Text = CStr(1.0#)        'coefficient de transfert de surface hydrique
            Text26.Text = CStr(1.0#)        'coefficient de transfert de surface thermique
            TextC.Text = CStr(375)          'teneur en ciment en kg/m3
            TextBox3.Text = CStr(0.42)      'rapport eau/ciment
            TextBoxRho_c.Text = CStr(2450)      'masse volumique du béton
            Text44.Text = CStr(0.8)         'taux d'hydratation
            TextBox2.Text = CStr(1.5)       'teneur en air
            TextBox4.Text = CStr(0)         'vapeur d'eau : énergie d'activation pour la température
            TextBox5.Text = CStr(293.16)    'vapeur d'eau : température de référence
            TextBox8.Text = CStr(0)         'chlorures : énergie d'activation pour la température
            TextBox9.Text = CStr(293.16)    'chlorures : température de référence
        ElseIf Option2.Checked = True Then
            Text4.Text = "béton_moyen"
            Text3.Text = "moyen"
            Text30.Text = CStr(0.00013)
            Text46.Text = CStr(0.000013)
            Text25.Text = CStr(0.7)
            Text39.Text = CStr(1.0#)
            Text26.Text = CStr(1.0#)
            TextC.Text = CStr(375)
            TextBox3.Text = CStr(0.52)
            TextBoxRho_c.Text = CStr(2384)
            Text44.Text = CStr(0.9)
            TextBox2.Text = CStr(1.5)
            TextBox4.Text = CStr(0)
            TextBox5.Text = CStr(293.16)
            TextBox8.Text = CStr(0)
            TextBox9.Text = CStr(293.16)
        Else
            Text4.Text = "béton_mauvais"
            Text3.Text = "mauvais"
            Text30.Text = CStr(0.0002)
            Text46.Text = CStr(0.00002)
            Text25.Text = CStr(0.7)
            Text39.Text = CStr(1.0#)
            Text26.Text = CStr(1.0#)
            TextC.Text = CStr(250)
            TextBox3.Text = CStr(0.73)
            TextBoxRho_c.Text = CStr(2387)
            Text44.Text = CStr(0.9)
            TextBox2.Text = CStr(1.5)
            TextBox4.Text = CStr(0)
            TextBox5.Text = CStr(293.16)
            TextBox8.Text = CStr(0)
            TextBox9.Text = CStr(293.16)
        End If

        Text4.Enabled = False
        Text3.Enabled = False
        Text30.Enabled = False
        Text46.Enabled = False
        Text25.Enabled = False
        Text39.Enabled = False
        Text26.Enabled = False
        TextC.Enabled = False
        TextBox3.Enabled = False
        TextBoxRho_c.Enabled = False
        Text44.Enabled = False
        TextBox2.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        'calcul de la teneur en granulat et de la teneur en eau
        Text1.Text = CStr(CSng(TextC.Text) * CSng(TextBox3.Text) - CSng(0.17) * CSng(Text44.Text) * CSng(TextC.Text) + CSng(10) * CSng(TextBox2.Text))
        Label92.Text = CStr((1 - CSng(TextC.Text) / CSng(TextBox26.Text) - CSng(TextBox3.Text) * CSng(TextC.Text) / 1000 - CSng(TextBox2.Text) / 100) * CSng(TextBox25.Text))
        TextBoxRho_c.Text = CStr(CSng(TextC.Text) + CSng(Label92.Text) + CSng(TextBox3.Text) * CSng(TextC.Text))
    End Sub

    'Choix des caractéristiques du béton = autres
    Private Sub Option4_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Option4.CheckedChanged

        If Option4.Checked = True Then
            Text4.Enabled = True
            Text3.Enabled = True
            TextBox3.Enabled = True
            Text30.Enabled = True
            Text46.Enabled = True
            Text25.Enabled = True
            Text39.Enabled = True
            Text26.Enabled = True
            Text1.Enabled = True
            TextBoxRho_c.Enabled = True
            TextC.Enabled = True
            TextBox3.Enabled = True
            TextBox2.Enabled = True
            Text44.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            TextBox8.Enabled = True
            TextBox9.Enabled = True
        End If
    End Sub

    'Calcul de la teneur en granulat et de la teneur en eau, approche probabiliste
    Private Sub CmtTextCompBeton(ByVal Sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox26.Validating, TextBox25.Validating, TextC.Validating, TextBox2.Validating, Text44.Validating, TextBox3.Validating
        Dim a As Decimal
        Dim b As Decimal
        Text1.Text = CStr(CSng(TextC.Text) * CSng(TextBox3.Text) - CSng(0.17) * CSng(Text44.Text) * CSng(TextC.Text) + CSng(10) * CSng(TextBox2.Text))
        Label92.Text = CStr((1 - CSng(TextC.Text) / CSng(TextBox26.Text) - CSng(TextBox3.Text) * CSng(TextC.Text) / 1000 - CSng(TextBox2.Text) / 100) * CSng(TextBox25.Text))
        TextBoxRho_c.Text = CStr(CSng(TextC.Text) + CSng(Label92.Text) + CSng(TextBox3.Text) * CSng(TextC.Text))
        a = CDec(0.0000625 * CDec(TextBox3.Text) ^ 2 - 0.000104 * CDec(TextBox3.Text) + 0.00003)
        b = CDec(-0.015547 * CDec(TextBox3.Text) ^ 2 + 0.0216515 * CDec(TextBox3.Text) - 0.005652)
        Label105.Text = CStr(CSng(a * 100 + b))
        If CheckBox6.Checked = True Then
            Text46.Text = CStr(CSng(0.0943 * System.Math.Exp(CDbl(TextBox3.Text) * 7.899) * 0.000001))
        End If
        If CheckBox7.Checked = True Then
            Label147.Text = CStr(2.8 * (CDbl(TextBox26.Text) * (CDbl(TextBox3.Text) - 0.3) * (1 - 0.7) / (1000 * (1 + CDbl(TextBox26.Text) * CDbl(TextBox3.Text) / 1000))) ^ 2)
        End If
    End Sub

    'Calcul des lois probabilistes lors de chmt de paramètres
    Private Sub CmtTextProb01(ByVal Sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox10.Validating, TextBox15.Validating, TextBox19.Validating
        CmtTextProb10()
    End Sub

    'Calcul des lois probabilistes lors de chmt de paramètres
    Private Sub CmtTextProb02(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label55.TextChanged, Label105.TextChanged, Label131.TextChanged, Label147.TextChanged
        If Label55.Text <> "" And TextBox10.Text <> "" Then CmtTextProb10()
    End Sub

    'Calcul des lois probabilistes lors de chmt de paramètres
    Private Sub CmtTextProb03(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged, ComboBox5.SelectedIndexChanged, ComboBox6.SelectedIndexChanged, ComboBox11.SelectedIndexChanged
        CmtTextProb10()
    End Sub

    'Calcul des lois probabilistes lors de chmt de paramètres
    Private Sub CmtTextProb10()
        Dim sm As Double
        Dim sp As Double
        If ComboBox4.Text = "loi normale" Then      'Transport hydrique de vapeur d'eau
            Label59.Text = ""
            Label104.Text = ""
            Label113.Text = "P- = 0.5"
            Label114.Text = "P+ = 0.5"
            Label136.Text = "X1 = " & CStr(CSng(CDbl(Label55.Text) - CDbl(TextBox10.Text)))
            Label135.Text = "X2 = " & CStr(CSng(CDbl(Label55.Text) + CDbl(TextBox10.Text)))
        Else
            Label59.Text = CStr(CSng(System.Math.Log(CDbl(Label55.Text) ^ 2 / (CDbl(Label55.Text) ^ 2 + CDbl(TextBox10.Text) ^ 2) ^ 0.5)))
            Label104.Text = CStr(CSng((System.Math.Log(CDbl(TextBox10.Text) ^ 2 / CDbl(Label55.Text) ^ 2 + 1)) ^ 0.5))
            sm = System.Math.Exp(CDbl(Label59.Text)) * (1 - System.Math.Exp(-CDbl(Label104.Text)))
            sp = System.Math.Exp(CDbl(Label59.Text)) * (System.Math.Exp(CDbl(Label104.Text)) - 1)
            Label113.Text = "P- = " & CStr(CSng(sp / (sp + sm)))
            Label114.Text = "P+ = " & CStr(CSng(sm / (sp + sm)))
            Label136.Text = "X1 = " & CStr(CSng(System.Math.Exp(CDbl(Label59.Text) - CDbl(Label104.Text))))
            Label135.Text = "X2 = " & CStr(CSng(System.Math.Exp(CDbl(Label59.Text) + CDbl(Label104.Text))))
        End If

        If ComboBox5.Text = "loi normale" Then      'Transport hydrique d'eau liquide par capillarité
            Label107.Text = ""
            Label130.Text = ""
            Label118.Text = "P- = 0.5"
            Label117.Text = "P+ = 0.5"
            Label116.Text = "X1 = " & CStr(CSng(CDbl(Label105.Text) - CDbl(TextBox15.Text)))
            Label115.Text = "X2 = " & CStr(CSng(CDbl(Label105.Text) + CDbl(TextBox15.Text)))
        Else
            Label107.Text = CStr(CSng(System.Math.Log(CDbl(Label105.Text) ^ 2 / (CDbl(Label105.Text) ^ 2 + CDbl(TextBox15.Text) ^ 2) ^ 0.5)))
            Label130.Text = CStr(CSng((System.Math.Log(CDbl(TextBox15.Text) ^ 2 / CDbl(Label105.Text) ^ 2 + 1)) ^ 0.5))
            sm = System.Math.Exp(CDbl(Label107.Text)) * (1 - System.Math.Exp(-CDbl(Label130.Text)))
            sp = System.Math.Exp(CDbl(Label107.Text)) * (System.Math.Exp(CDbl(Label130.Text)) - 1)
            Label118.Text = "P- = " & CStr(CSng(sp / (sp + sm)))
            Label117.Text = "P+ = " & CStr(CSng(sm / (sp + sm)))
            Label116.Text = "X1 = " & CStr(CSng(System.Math.Exp(CDbl(Label107.Text) - CDbl(Label130.Text))))
            Label115.Text = "X2 = " & CStr(CSng(System.Math.Exp(CDbl(Label107.Text) + CDbl(Label130.Text))))
        End If

        If ComboBox6.Text = "loi normale" Then      'Transport ionique des chlorures
            Label132.Text = ""
            Label133.Text = ""
            Label140.Text = "P- = 0.5"
            Label139.Text = "P+ = 0.5"
            Label138.Text = "X1 = " & CStr(CSng(CDbl(Label131.Text) - CDbl(TextBox19.Text)))
            Label137.Text = "X2 = " & CStr(CSng(CDbl(Label131.Text) + CDbl(TextBox19.Text)))
        Else
            Label132.Text = CStr(CSng(System.Math.Log(CDbl(Label131.Text) ^ 2 / (CDbl(Label131.Text) ^ 2 + CDbl(TextBox19.Text) ^ 2) ^ 0.5)))
            Label133.Text = CStr(CSng((System.Math.Log(CDbl(TextBox19.Text) ^ 2 / CDbl(Label131.Text) ^ 2 + 1)) ^ 0.5))
            sm = System.Math.Exp(CDbl(Label132.Text)) * (1 - System.Math.Exp(-CDbl(Label133.Text)))
            sp = System.Math.Exp(CDbl(Label132.Text)) * (System.Math.Exp(CDbl(Label133.Text)) - 1)
            Label140.Text = "P- = " & CStr(CSng(sp / (sp + sm)))
            Label139.Text = "P+ = " & CStr(CSng(sm / (sp + sm)))
            Label138.Text = "X1 = " & CStr(CSng(System.Math.Exp(CDbl(Label132.Text) - CDbl(Label133.Text))))
            Label137.Text = "X2 = " & CStr(CSng(System.Math.Exp(CDbl(Label132.Text) + CDbl(Label133.Text))))
        End If

        If ComboBox11.Text = "loi normale" Then      'Carbonatation
            Label146.Text = ""
            Label145.Text = ""
            Label144.Text = "P- = 0.5"
            Label143.Text = "P+ = 0.5"
            Label142.Text = "X1 = " & CStr(CSng(CDbl(Label147.Text) - CDbl(TextBox6.Text)))
            Label141.Text = "X2 = " & CStr(CSng(CDbl(Label147.Text) + CDbl(TextBox6.Text)))
        Else
            Label146.Text = CStr(CSng(System.Math.Log(CDbl(Label147.Text) ^ 2 / (CDbl(Label147.Text) ^ 2 + CDbl(TextBox6.Text) ^ 2) ^ 0.5)))
            Label145.Text = CStr(CSng((System.Math.Log(CDbl(TextBox6.Text) ^ 2 / CDbl(Label147.Text) ^ 2 + 1)) ^ 0.5))
            sm = System.Math.Exp(CDbl(Label59.Text)) * (1 - System.Math.Exp(-CDbl(Label104.Text)))
            sp = System.Math.Exp(CDbl(Label59.Text)) * (System.Math.Exp(CDbl(Label104.Text)) - 1)
            Label144.Text = "P- = " & CStr(CSng(sp / (sp + sm)))
            Label143.Text = "P+ = " & CStr(CSng(sm / (sp + sm)))
            Label142.Text = "X1 = " & CStr(CSng(System.Math.Exp(CDbl(Label59.Text) - CDbl(Label104.Text))))
            Label141.Text = "X2 = " & CStr(CSng(System.Math.Exp(CDbl(Label59.Text) + CDbl(Label104.Text))))
        End If

    End Sub

    'Calcul de la teneur en granulat et de la teneur en eau
    Private Sub TextBox25_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox25.TextChanged
        Text1.Text = CStr(CSng(TextC.Text) * CSng(TextBox3.Text) - CSng(0.17) * CSng(Text44.Text) * CSng(TextC.Text) + CSng(10) * CSng(TextBox2.Text))
        Label92.Text = CStr((1 - CSng(TextC.Text) / CSng(TextBox26.Text) - CSng(TextBox3.Text) * CSng(TextC.Text) / 1000 - CSng(TextBox2.Text) / 100) * CSng(TextBox25.Text))
        TextBoxRho_c.Text = CStr(CSng(TextC.Text) + CSng(Label92.Text) + CSng(TextBox3.Text) * CSng(TextC.Text))
    End Sub

    'Copies du temps de stockage dans d'autres éléments
    Private Sub Text10_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Text10.Validating
        Dim TesGraph As MsgBoxResult
        TesGraph = MsgBox("Valeurs identiques pour les autres fichiers résultats ?", MsgBoxStyle.YesNo, "Données")
        If CInt(TesGraph) = MsgBoxResult.Yes Then
            Text11.Text = Text10.Text
            Text12.Text = Text10.Text
            Text13.Text = Text10.Text
            Text14.Text = Text10.Text
            TextBox27.Text = Text10.Text
        End If
    End Sub

    'Lecture du formulaire
    Private Sub Lecture(ByRef Length As Single, ByRef Ne As Short, ByRef TimeMax As Single, ByRef DeltaT As Single, ByRef taff As Single, ByRef Hsauv As Single, ByRef Wsauv As Single, ByRef CTsauv As Single, ByRef CLsauv As Single, ByRef Tsauv As Single, ByRef hMin As Single, ByRef hEcart As Single, ByRef wMin As Single, ByRef wEcart As Single, ByRef CTmin As Single, ByRef CTecart As Single, ByRef CLmin As Single, ByRef CLecart As Single, ByRef Tecart As Single, ByRef aa As Single, ByRef Hc As Single, ByRef ab As Single, ByRef tc As Single, ByRef H_snap As Single, ByRef Retard As Single, ByRef aOH As Single, ByRef EbG As Single, ByRef toG As Single, ByRef faG As Single, ByRef capCal As Single, ByRef GyCO2 As Single, ByRef DyCO2 As Single, ByRef Carbsauv As Single, ByRef ImpHydr As Boolean)

        TimeMax = CSng(Text5.Text)
        DeltaT = CSng(Text6.Text)
        taff = CSng(Text15.Text)
        Hsauv = CSng(Text11.Text)
        Wsauv = CSng(Text12.Text)
        CTsauv = CSng(Text14.Text)
        CLsauv = CSng(Text13.Text)
        Tsauv = CSng(Text10.Text)
        Carbsauv = CSng(TextBox27.Text)
        hMin = CSng(Text17.Text)
        hEcart = CSng(Text18.Text)
        wMin = CSng(Text19.Text)
        wEcart = CSng(Text20.Text)
        CTmin = CSng(Text23.Text)
        CTecart = CSng(Text24.Text)
        CLmin = CSng(Text21.Text)
        CLecart = CSng(Text22.Text)
        Tecart = CSng(Text16.Text)
        aa = CSng(Text31.Text)
        Hc = CSng(Text32.Text)
        ab = CSng(TextBox22.Text)
        tc = CSng(TextBox21.Text)
        H_snap = CSng(Text48.Text)
        Retard = CSng(Text49.Text)
        aOH = CSng(TextBox28.Text)
        EbG = CSng(TextBox29.Text)
        toG = CSng(TextBox30.Text)
        faG = CSng(Text40.Text)
        capCal = CSng(Text25.Text)
        GyCO2 = CSng(TextBox24.Text)
        DyCO2 = CSng(TextBox23.Text)
        If RadioButton3.Checked = True Then
            ab = 0
            tc = 0
        ElseIf RadioButton2.Checked = True Then
            ImpHydr = True
        Else
            ImpHydr = False
        End If

    End Sub

    'Sauvegarde du formulaire dans un fichier
    Private Sub Ecriture(ByRef nFic As Short, ByRef OutFile As String, ByRef Length As Single, ByRef Ne As Short, ByRef Le() As Decimal, ByRef TimeMax As Single, ByRef DeltaT As Single, ByRef taff As Single, ByRef Hsauv As Single, ByRef Wsauv As Single, ByRef CTsauv As Single, ByRef CLsauv As Single, ByRef Tsauv As Single, ByRef hMin As Single, ByRef hEcart As Single, ByRef wMin As Single, ByRef wEcart As Single, ByRef CTmin As Single, ByRef CTecart As Single, ByRef CLmin As Single, ByRef CLecart As Single, ByRef Tecart As Single, ByRef aa As Single, ByRef Hc As Single, ByRef ab As Single, ByRef tc As Single, ByRef H_snap As Single, ByRef Retard As Single, ByRef aOH As Single, ByRef EbG As Single, ByRef toG As Single, ByRef faG As Single, ByRef NEXPO As Short, ByRef capCal As Single, ByRef GyCO2 As Single, ByRef DyCO2 As Single, ByRef Carbsauv As Single, ByRef ImpHydr As Boolean)
        nFic = CShort(FreeFile())
        FileOpen(CInt(nFic), OutFile, OpenMode.Output)

        PrintLine(CInt(nFic), TimeMax)
        PrintLine(CInt(nFic), DeltaT)
        PrintLine(CInt(nFic), taff)
        PrintLine(CInt(nFic), Hsauv)
        PrintLine(CInt(nFic), Wsauv)
        PrintLine(CInt(nFic), CTsauv)
        PrintLine(CInt(nFic), CLsauv)
        PrintLine(CInt(nFic), Tsauv)
        PrintLine(CInt(nFic), Carbsauv)
        PrintLine(CInt(nFic), hMin)
        PrintLine(CInt(nFic), hEcart)
        PrintLine(CInt(nFic), wMin)
        PrintLine(CInt(nFic), wEcart)
        PrintLine(CInt(nFic), CTmin)
        PrintLine(CInt(nFic), CTecart)
        PrintLine(CInt(nFic), CLmin)
        PrintLine(CInt(nFic), CLecart)
        PrintLine(CInt(nFic), Tecart)
        PrintLine(CInt(nFic), aa)
        PrintLine(CInt(nFic), Hc)
        PrintLine(CInt(nFic), ab)
        PrintLine(CInt(nFic), tc)
        PrintLine(CInt(nFic), ImpHydr)
        PrintLine(CInt(nFic), H_snap)
        PrintLine(CInt(nFic), Retard)
        PrintLine(CInt(nFic), aOH)
        PrintLine(CInt(nFic), EbG)
        PrintLine(CInt(nFic), toG)
        PrintLine(CInt(nFic), faG)
        PrintLine(CInt(nFic), capCal)
        PrintLine(CInt(nFic), GyCO2)
        PrintLine(CInt(nFic), DyCO2)

        PrintLine(CInt(nFic), NEXPO)
        For i = CShort(1) To NEXPO
            PrintLine(CInt(nFic), FileGexpo(i))
            PrintLine(CInt(nFic), FileDexpo(i))
        Next i

        Var03 = Var03 - CShort(1)
        PrintLine(CInt(nFic), Var03)
        For i = CShort(1) To Var03
            For j = CShort(1) To Mat
                PrintLine(CInt(nFic), Bara1(j, i))
            Next j
        Next i

        PrintLine(CInt(nFic), 2)
        'For i = 1 To Nbre1
        PrintLine(CInt(nFic), NumTempInt)
        PrintLine(CInt(nFic), NumTempExt)
        'Next
        PrintLine(CInt(nFic), 2)
        'For i = 1 To Nbre2
        PrintLine(CInt(nFic), NumHRInt)
        PrintLine(CInt(nFic), NumHRExt)
        'Next
        PrintLine(CInt(nFic), 2)
        'For i = 1 To Nbre3
        PrintLine(CInt(nFic), NumClInt)
        PrintLine(CInt(nFic), NumClExt)
        'Next

        FileClose(CInt(nFic))

    End Sub

    'sous routine permettant de garder les caractères à gauche d'un espacement
    Private Sub NumOnly(ByRef Num As String)
        Dim iPos As Short
        Dim Dim1 As String

        Dim1 = " "
        iPos = CShort(InStr(1, Num, Dim1, CompareMethod.Text))
        Num = Microsoft.VisualBasic.Left(Num, iPos - 1)

    End Sub

    'sous routine controlant la validité des paramètres introduits
    Private Sub CtrlParam(ByRef Message As String)

        Dim Canc As Boolean = False
        Dim Dim1 As String
        Try
            'Matériaux ... Béton
            If CDbl(TextBoxRho_c.Text) <= 0 Or Not IsNumeric(TextBoxRho_c.Text) Or TextBoxRho_c.Text = "" Then Message = "La " & Label89.Text & " est non valide !"
            If CDbl(TextC.Text) <= 0 Or Not IsNumeric(TextC.Text) Or TextC.Text = "" Then Message = "La " & Label3.Text & " est non valide !"
            If CDbl(TextBox2.Text) < 0 Or Not IsNumeric(TextBox2.Text) Or TextBox2.Text = "" Then Message = "La " & Label95.Text & " est non valide !"
            If CDbl(TextBox3.Text) <= 0 Or Not IsNumeric(TextBox3.Text) Or TextBox3.Text = "" Then Message = "La " & Label83.Text & " est non valide !"
            If CDbl(Text45.Text) < 0 Or Not IsNumeric(Text45.Text) Or Text45.Text = "" Then Message = "L'" & Label84.Text & " est non valide !"
            If CDbl(Text44.Text) <= 0 Or Not IsNumeric(Text44.Text) Or Text44.Text = "" Then Message = "Le " & Label97.Text & " est non valide !"

            'Matériaux ... Nom
            Dim1 = " "
            If InStr(1, Text3.Text, Dim1, CompareMethod.Text) <> 0 Or Text3.Text = "" Then Message = "Le " & Label5.Text & " contient des espacements !"
            If InStr(1, Text4.Text, Dim1, CompareMethod.Text) <> 0 Or Text4.Text = "" Then Message = "Le " & Label6.Text & " contient des espacements !"

            'Paramètres du programme ... Temps
            If CDbl(Text5.Text) <= 0 Or Not IsNumeric(Text5.Text) Or Text5.Text = "" Then Message = "Le " & Label11.Text & " est non valide !"
            If CDbl(Text6.Text) <= 0 Or Not IsNumeric(Text6.Text) Or Text6.Text = "" Then Message = "Le " & Label12.Text & " est non valide !"
            'If CSng(Text47.Text) * CSng(60) - CSng(Text6.Text) < CSng(0) Then Message = "Le pas de temps des conditions aux limites doit être inférieur au pas de temps de calcul"
            'If Text47.Text <= 0 Or Not IsNumeric(Text47.Text) Or Text47.Text = "" Then Message = "Le " & Label87.Text & " est non valide !"

            'Paramètres du programme ... Fichier résultat
            If CDbl(Text10.Text) < 0 Or Not IsNumeric(Text10.Text) Or Text10.Text = "" Then Message = "Le " & Label26.Text & " est non valide !"
            If CDbl(Text11.Text) < 0 Or Not IsNumeric(Text11.Text) Or Text11.Text = "" Then Message = "Le " & Label23.Text & " est non valide !"
            If CDbl(Text12.Text) < 0 Or Not IsNumeric(Text12.Text) Or Text12.Text = "" Then Message = "Le " & Label24.Text & " est non valide !"
            If CDbl(Text13.Text) < 0 Or Not IsNumeric(Text13.Text) Or Text13.Text = "" Then Message = "Le " & Label25.Text & " est non valide !"
            If CDbl(Text14.Text) < 0 Or Not IsNumeric(Text14.Text) Or Text14.Text = "" Then Message = "Le " & Label27.Text & " est non valide !"
            If CDbl(TextBox27.Text) < 0 Or Not IsNumeric(TextBox27.Text) Or TextBox27.Text = "" Then Message = "Le " & Label124.Text & " est non valide !"

            'Paramètres du programme ... Affichage
            If CDbl(Text15.Text) < 0 Or Not IsNumeric(Text15.Text) Or Text15.Text = "" Then Message = "Le " & Label13.Text & " est non valide !"
            If CDbl(Text16.Text) <= 0 Or Not IsNumeric(Text16.Text) Or Text16.Text = "" Then Message = "Le paramètre d'affichage pour la " & Label14.Text & " est non valide !"
            If CDbl(Text17.Text) < 0 Or Not IsNumeric(Text17.Text) Or Text17.Text = "" Then Message = "Le paramètre d'affichage de l'" & Label15.Text & " est non valide !"
            If CDbl(Text18.Text) <= 0 Or Not IsNumeric(Text18.Text) Or Text18.Text = "" Then Message = "Le paramètre d'affichage pour l'" & Label16.Text & " est non valide !"
            If CDbl(Text19.Text) < 0 Or Not IsNumeric(Text19.Text) Or Text19.Text = "" Then Message = "Le paramètre d'affichage de la " & Label17.Text & " est non valide !"
            If CDbl(Text20.Text) <= 0 Or Not IsNumeric(Text20.Text) Or Text20.Text = "" Then Message = "Le paramètre d'affichage pour la " & Label18.Text & " est non valide !"
            If CDbl(Text21.Text) < 0 Or Not IsNumeric(Text21.Text) Or Text21.Text = "" Then Message = "Le paramètre d'affichage des " & Label19.Text & " est non valide !"
            If CDbl(Text22.Text) <= 0 Or Not IsNumeric(Text22.Text) Or Text22.Text = "" Then Message = "Le paramètre d'affichage pour les " & Label20.Text & " est non valide !"
            If CDbl(Text23.Text) < 0 Or Not IsNumeric(Text23.Text) Or Text23.Text = "" Then Message = "Le paramètre d'affichage des " & Label21.Text & " est non valide !"
            If CDbl(Text24.Text) <= 0 Or Not IsNumeric(Text24.Text) Or Text24.Text = "" Then Message = "Le paramètre d'affichage pour les " & Label22.Text & " est non valide !"

            'Transport thermique ... Capacité calorifique
            If CDbl(Text25.Text) < 0.7 Or CDbl(Text25.Text) > 0.9 Or Not IsNumeric(Text25.Text) Or Text25.Text = "" Then Message = "La capacité calorifique des " & Label28.Text & " est non valide !"
            If CSng(Text25.Text) = CSng(0) Then MsgBox("pas de tranport thermique !", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation, "Avertissement")

            'Transport thermique ... Transfert à la surface
            If CDbl(Text26.Text) < 0 Or CDbl(Text26.Text) > 1 Or Not IsNumeric(Text26.Text) Or Text26.Text = "" Then Message = "La " & Label46.Text & " thermique est non valide !"
            If CSng(Text26.Text) = CSng(0) Then MsgBox("pas de transport thermique (! mettre les conditions aux limites à zéro) !", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation, "Avertissement")

            'Transport hydrique ... Diffusion hydrique
            If CDbl(Text30.Text) < 0 Or Not IsNumeric(Text30.Text) Or Text30.Text = "" Then Message = "Le coefficient de diffusion hydrique, " & Label51.Text & " est non valide !"
            If CSng(Text30.Text) = CSng(0) Then MsgBox("pas de transport de vapeur d'eau !", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation, "Avertissement")
            If Not IsNumeric(Text31.Text) Or Text31.Text = "" Then Message = "Le paramètre de diffusion hydrique, " & Label52.Text & " est non valide !"
            If CDbl(Text32.Text) < 0 Or CDbl(Text32.Text) = 1 Or Not IsNumeric(Text32.Text) Or Text32.Text = "" Then Message = "Le coefficient de diffusion hydrique, " & Label53.Text & " est non valide !"
            If Not IsNumeric(TextBox4.Text) Or TextBox4.Text = "" Then Message = "Le coefficient Ed dans la partie diffusion hydrique"
            If CDbl(TextBox5.Text) < 0 Or Not IsNumeric(TextBox5.Text) Or TextBox5.Text = "" Then Message = "La température To dans la partie diffusion hydrique"

            'Transport hydrique ... Transfert à la surface
            If CDbl(Text39.Text) < 0 Or CDbl(Text39.Text) > 1 Or Not IsNumeric(Text39.Text) Or Text39.Text = "" Then Message = "Le " & Label66.Text & " hydrique est non valide !"
            If CSng(Text39.Text) = CSng(0) Then MsgBox("pas de transport hydrique (! mettre les conditions aux limites à zéro) !", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation, "Avertissement")

            'Carbonatation ...  Masse volumique des composants du béton
            If CDbl(TextBox25.Text) <= 0 Or Not IsNumeric(TextBox25.Text) Or TextBox25.Text = "" Then Message = "La " & Label57.Text & " est non valide !"
            If CDbl(TextBox26.Text) <= 0 Or Not IsNumeric(TextBox26.Text) Or TextBox26.Text = "" Then Message = "La " & Label58.Text & " est non valide !"

            'Carbonatation ...  Atmosphère
            If CDbl(TextBox24.Text) <= 0 Or Not IsNumeric(TextBox24.Text) Or TextBox24.Text = "" Or CDbl(TextBox23.Text) <= 0 Or CDbl(TextBox23.Text) > 1 Or Not IsNumeric(TextBox23.Text) Or TextBox23.Text = "" Then Message = "La " & Label60.Text & " est non valide !"

            'Transport ionique chlorures ... Convection par l'eau
            If CDbl(Text49.Text) < 0 Or Not IsNumeric(Text49.Text) Or Text49.Text = "" Then Message = "Le " & Label82.Text & " est non valide !"
            If CDbl(Text48.Text) < 0 Or CDbl(Text48.Text) > 1 Or Not IsNumeric(Text48.Text) Or Text48.Text = "" Then Message = "La " & Label81.Text & " est non valide !"

            'Transport ionique chlorures ... Diffusion dans l'eau
            If CDbl(Text46.Text) < 0 Or Not IsNumeric(Text46.Text) Or Text46.Text = "" Then Message = "Le " & Label78.Text & " des ions chlorures dans l'eau est non valide !"
            If CSng(Text46.Text) = CSng(0) Then MsgBox("pas de tranport des ions de chlorures par diffusion dans l'eau !", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation, "Avertissement")
            If Not IsNumeric(TextBox8.Text) Or TextBox8.Text = "" Then Message = "Le coefficient Ed dans la partie diffusion hydrique"
            If CDbl(TextBox9.Text) < 0 Or Not IsNumeric(TextBox9.Text) Or TextBox9.Text = "" Then Message = "La température To dans la partie diffusion hydrique"

            'Transport ionique chlorures ... Relation entre chlorures libres et liées
            If CDbl(TextBox28.Text) < 0 Or Not IsNumeric(TextBox28.Text) Or TextBox28.Text = "" Then Message = "La relation entre ions libres et liées, " & Label125.Text & " est non valide !"
            If CDbl(TextBox29.Text) < 0 Or Not IsNumeric(TextBox29.Text) Or TextBox29.Text = "" Then Message = "La relation entre ions libres et liées, " & Label126.Text & " est non valide !"
            If CDbl(Text40.Text) < 0 Or Not IsNumeric(Text40.Text) Or Text40.Text = "" Then Message = "La relation entre ions libres et liées, " & Label67.Text & " est non valide !"
            If CDbl(TextBox30.Text) < 0 Or Not IsNumeric(TextBox30.Text) Or TextBox30.Text = "" Then Message = "La relation entre ions libres et liées, " & Label127.Text & " est non valide !"

            'Analyse probabiliste ... 
            If CDbl(TextBox10.Text) < 0 Or CDbl(TextBox15.Text) < 0 Or CDbl(TextBox19.Text) < 0 Or Not IsNumeric(TextBox10.Text) Or Not IsNumeric(TextBox15.Text) Or Not IsNumeric(TextBox19.Text) Or TextBox10.Text = "" Or TextBox15.Text = "" Or TextBox19.Text = "" Then Message = "Problème dans les écarts types de l'approche probabiliste !"
        Catch e As Exception
            Message = "Manque une donnée !"
        Finally
            If Message <> "0" Then MsgBox(Message, MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation, "Avertissement")
        End Try

    End Sub

    'Désactivation de champ pour l'introduction d'autres matériaux
    Private Sub DesChamp()
        Text5.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text6.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text15.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text11.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text12.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text14.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text13.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text10.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        TextBox27.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text17.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text18.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text19.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text20.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text23.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text24.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text21.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text22.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text16.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text31.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text32.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text48.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text49.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text40.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        TextBox28.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        TextBox29.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        TextBox30.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))
        Text25.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 128))

        Frame4.Enabled = False
        Frame6.Enabled = False
        Frame5.Enabled = False
        Text31.Enabled = False
        Text32.Enabled = False
        Frame21.Enabled = False
        Frame17.Enabled = False
        GroupBox7.Enabled = False
    End Sub

    'Activation de champ pour l'introduction d'autres matériaux
    Private Sub ActChamp()
        Text5.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text6.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text15.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text11.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text12.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text14.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text13.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text10.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        TextBox27.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text17.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text18.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text19.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text20.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text23.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text24.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text21.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text22.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text16.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text31.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text32.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text48.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text49.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text40.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        TextBox28.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        TextBox29.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        TextBox30.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Text25.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

        Command1.Enabled = False
        Frame4.Enabled = True
        Frame6.Enabled = True
        Frame5.Enabled = True
        Text31.Enabled = True
        Text32.Enabled = True
        Frame21.Enabled = True
        Frame17.Enabled = True
        GroupBox7.Enabled = True
    End Sub

    'effacement d'une ligne de paramètres dans une variable bara1
    Private Sub EffPara(ByRef rt As Integer)
        For i = 1 To Mat
            Bara1(i, rt) = Bara1(i, rt + 1)
        Next
    End Sub

    'stockage des paramètres dans une variable bara1
    Private Sub StPara(ByRef rt As Integer)
        Dim sm As Double
        Dim sp As Double
        Dim i As Integer
        Bara1(1, rt) = Text4.Text       'nom d'affichage durant le calcul
        Bara1(2, rt) = Text3.Text       'nom dans le fichier résultat
        Bara1(3, rt) = Text30.Text      'coefficient de diffusion hydrique
        Bara1(4, rt) = Text46.Text      'coefficient de diffusion des ions chlorures dans l'eau
        Bara1(5, rt) = Label92.Text     'teneur en granulat
        Bara1(6, rt) = Text39.Text      'coefficient de transfert de surface pour l'eau
        Bara1(7, rt) = Text26.Text      'coefficient de transfert de surface pour la température
        Bara1(8, rt) = Text1.Text       'teneur en eau saturée
        Bara1(9, rt) = TextC.Text       'quantité de ciment
        Bara1(10, rt) = TextBox3.Text   'eau sur ciment
        Bara1(11, rt) = Text45.Text     'âge du béton 
        Bara1(12, rt) = Text44.Text     'taux d'hydratation
        Bara1(15, rt) = TextBox4.Text   'énergie d'activation pour la vapeur d'eau (température)
        Bara1(16, rt) = TextBox5.Text   'température de référence pour l'énergie d'activation précédente
        Bara1(17, rt) = TextBox8.Text   'énergie d'activation pour l'entraînement des ions cl- par l'eau (température)
        Bara1(18, rt) = TextBox9.Text   'température de référence pour l'énergie d'activation précédente
        Bara1(19, rt) = TextBox25.Text  'masse volumique des granulats 
        Bara1(20, rt) = TextBox26.Text  'masse volumique du ciment

        Select Case Combo5.Text
            Case "Type 1"
                Bara1(13, rt) = CStr(0.9)
                Bara1(14, rt) = CStr(1.1)
            Case "Type 2"
                Bara1(13, rt) = CStr(1.0#)
                Bara1(14, rt) = CStr(1.0#)
            Case "Type 3"
                Bara1(13, rt) = CStr(0.85)
                Bara1(14, rt) = CStr(1.15)
            Case "Type 4"
                Bara1(13, rt) = CStr(0.6)
                Bara1(14, rt) = CStr(1.5)
        End Select

        If CheckBox2.Checked = False Then
            For i = 21 To 25
                Bara1(i, rt) = CStr(0)
            Next
        Else
            If ComboBox4.Text = "loi normale" Then
                Bara1(21, rt) = CStr(1)
                Bara1(22, rt) = CStr(CDbl(Label55.Text) / (CDbl(Label55.Text) - CDbl(TextBox10.Text)))
                Bara1(23, rt) = CStr(CDbl(Label55.Text) / (CDbl(Label55.Text) + CDbl(TextBox10.Text)))
                Bara1(24, rt) = CStr(0.5)
                Bara1(25, rt) = CStr(0.5)
            Else
                Bara1(21, rt) = CStr(2)
                Bara1(22, rt) = CStr(CDbl(Label55.Text) / (System.Math.Exp(CDbl(Label59.Text) - CDbl(Label104.Text))))
                Bara1(23, rt) = CStr(CDbl(Label55.Text) / (System.Math.Exp(CDbl(Label59.Text) + CDbl(Label104.Text))))
                sm = System.Math.Exp(CDbl(Label59.Text)) * (1 - System.Math.Exp(-CDbl(Label104.Text)))
                sp = System.Math.Exp(CDbl(Label59.Text)) * (System.Math.Exp(CDbl(Label104.Text)) - 1)
                Bara1(24, rt) = CStr(sp / (sp + sm))
                Bara1(25, rt) = CStr(sm / (sp + sm))
            End If
        End If
        If CheckBox3.Checked = False Then
            For i = 26 To 30
                Bara1(i, rt) = CStr(0)
            Next
        Else
            If ComboBox5.Text = "loi normale" Then
                Bara1(26, rt) = CStr(1)
                Bara1(27, rt) = CStr(CDbl(Label105.Text) / (CDbl(Label105.Text) - CDbl(TextBox15.Text)))
                Bara1(28, rt) = CStr(CDbl(Label105.Text) / (CDbl(Label105.Text) + CDbl(TextBox15.Text)))
                Bara1(29, rt) = CStr(0.5)
                Bara1(30, rt) = CStr(0.5)
            Else
                Bara1(26, rt) = CStr(2)
                Bara1(27, rt) = CStr(CDbl(Label105.Text) / (System.Math.Exp(CDbl(Label107.Text) - CDbl(Label130.Text))))
                Bara1(28, rt) = CStr(CDbl(Label105.Text) / (System.Math.Exp(CDbl(Label107.Text) + CDbl(Label130.Text))))
                sm = System.Math.Exp(CDbl(Label107.Text)) * (1 - System.Math.Exp(-CDbl(Label130.Text)))
                sp = System.Math.Exp(CDbl(Label107.Text)) * (System.Math.Exp(CDbl(Label130.Text)) - 1)
                Bara1(29, rt) = CStr(sp / (sp + sm))
                Bara1(30, rt) = CStr(sm / (sp + sm))
            End If
        End If
        If CheckBox4.Checked = False Then
            For i = 31 To 35
                Bara1(i, rt) = CStr(0)
            Next
        Else
            If ComboBox6.Text = "loi normale" Then
                Bara1(31, rt) = CStr(1)
                Bara1(32, rt) = CStr(CDbl(Label131.Text) / (CDbl(Label131.Text) - CDbl(TextBox19.Text)))
                Bara1(33, rt) = CStr(CDbl(Label131.Text) / (CDbl(Label131.Text) + CDbl(TextBox19.Text)))
                Bara1(34, rt) = CStr(0.5)
                Bara1(35, rt) = CStr(0.5)
            Else
                Bara1(31, rt) = CStr(2)
                Bara1(32, rt) = CStr(CDbl(Label131.Text) / (System.Math.Exp(CDbl(Label132.Text) - CDbl(Label133.Text))))
                Bara1(33, rt) = CStr(CDbl(Label131.Text) / (System.Math.Exp(CDbl(Label132.Text) + CDbl(Label133.Text))))
                sm = System.Math.Exp(CDbl(Label132.Text)) * (1 - System.Math.Exp(-CDbl(Label133.Text)))
                sp = System.Math.Exp(CDbl(Label132.Text)) * (System.Math.Exp(CDbl(Label133.Text)) - 1)
                Bara1(34, rt) = CStr(sp / (sp + sm))
                Bara1(35, rt) = CStr(sm / (sp + sm))
            End If
        End If
        If CheckBox7.Checked = False Then
            For i = 36 To 40
                Bara1(i, rt) = CStr(0)
            Next
        Else
            If ComboBox11.Text = "loi normale" Then
                Bara1(36, rt) = CStr(1)
                Bara1(37, rt) = CStr(CDbl(Label147.Text) / (CDbl(Label147.Text) - CDbl(TextBox6.Text)))
                Bara1(38, rt) = CStr(CDbl(Label147.Text) / (CDbl(Label147.Text) + CDbl(TextBox6.Text)))
                Bara1(39, rt) = CStr(0.5)
                Bara1(40, rt) = CStr(0.5)
            Else
                Bara1(36, rt) = CStr(2)
                Bara1(37, rt) = CStr(CDbl(Label147.Text) / (System.Math.Exp(CDbl(Label146.Text) - CDbl(Label145.Text))))
                Bara1(38, rt) = CStr(CDbl(Label147.Text) / (System.Math.Exp(CDbl(Label146.Text) + CDbl(Label145.Text))))
                sm = System.Math.Exp(CDbl(Label146.Text)) * (1 - System.Math.Exp(-CDbl(Label145.Text)))
                sp = System.Math.Exp(CDbl(Label146.Text)) * (System.Math.Exp(CDbl(Label145.Text)) - 1)
                Bara1(39, rt) = CStr(sp / (sp + sm))
                Bara1(40, rt) = CStr(sm / (sp + sm))
            End If
        End If

    End Sub

    'écriture des paramètres dans les champ provenant de bara1
    Private Sub WrPara(ByRef rt As Short)
        Dim p As Double
        Dim q As Double
        Text4.Text = Bara1(1, rt)
        Text3.Text = Bara1(2, rt)
        Text30.Text = Bara1(3, rt)
        Text46.Text = Bara1(4, rt)
        Label92.Text = Bara1(5, rt)
        Text39.Text = Bara1(6, rt)
        Text26.Text = Bara1(7, rt)
        Text1.Text = Bara1(8, rt)
        TextC.Text = Bara1(9, rt)
        TextBox3.Text = Bara1(10, rt)
        Text45.Text = Bara1(11, rt)
        Text44.Text = Bara1(12, rt)
        TextBox4.Text = Bara1(15, rt)
        TextBox5.Text = Bara1(16, rt)
        TextBox8.Text = Bara1(17, rt)
        TextBox9.Text = Bara1(18, rt)
        TextBox25.Text = Bara1(19, rt)
        TextBox26.Text = Bara1(20, rt)

        TextBox10.Text = CStr(0.0002308)
        TextBox15.Text = CStr(0.00005962)
        TextBox19.Text = CStr(0.000005772)
        MsgBox("Les écarts-types ont été réinitialisé", MsgBoxStyle.Information And MsgBoxStyle.OkOnly, "Avertissement")
    End Sub

    'activation ou désactivation des champs
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            DesChamp()
        Else
            ActChamp()
        End If
    End Sub

    'si l'approche probabiliste de la vapeur d'eau est cochée
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            ComboBox4.Visible = True
            Label73.Visible = True
            Label75.Visible = True
            Label76.Visible = True
            Label111.Visible = True
            Label55.Visible = True
            Label59.Visible = True
            Label104.Visible = True
            Label113.Visible = True
            Label114.Visible = True
            Label135.Visible = True
            Label136.Visible = True
            TextBox10.Visible = True
        Else
            ComboBox4.Visible = False
            Label73.Visible = False
            Label75.Visible = False
            Label76.Visible = False
            Label111.Visible = False
            Label55.Visible = False
            Label59.Visible = False
            Label104.Visible = False
            Label113.Visible = False
            Label114.Visible = False
            Label135.Visible = False
            Label136.Visible = False
            TextBox10.Visible = False
        End If
    End Sub

    'si l'approche probabiliste de l'eau liquide est cochée
    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            ComboBox5.Visible = True
            Label77.Visible = True
            Label79.Visible = True
            Label80.Visible = True
            Label112.Visible = True
            Label105.Visible = True
            Label107.Visible = True
            Label130.Visible = True
            Label115.Visible = True
            Label116.Visible = True
            Label117.Visible = True
            Label118.Visible = True
            Label134.Visible = True
            TextBox15.Visible = True
        Else
            ComboBox5.Visible = False
            Label77.Visible = False
            Label79.Visible = False
            Label80.Visible = False
            Label112.Visible = False
            Label105.Visible = False
            Label107.Visible = False
            Label130.Visible = False
            Label115.Visible = False
            Label116.Visible = False
            Label117.Visible = False
            Label118.Visible = False
            Label134.Visible = False
            TextBox15.Visible = False
        End If
    End Sub

    'si l'approche probabiliste du chlore est cochée
    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            ComboBox6.Visible = True
            Label119.Visible = True
            Label120.Visible = True
            Label121.Visible = True
            Label122.Visible = True
            Label131.Visible = True
            Label132.Visible = True
            Label133.Visible = True
            Label137.Visible = True
            Label138.Visible = True
            Label139.Visible = True
            Label140.Visible = True
            TextBox19.Visible = True
        Else
            ComboBox6.Visible = False
            Label119.Visible = False
            Label120.Visible = False
            Label121.Visible = False
            Label122.Visible = False
            Label131.Visible = False
            Label132.Visible = False
            Label133.Visible = False
            Label137.Visible = False
            Label138.Visible = False
            Label139.Visible = False
            Label140.Visible = False
            TextBox19.Visible = False
        End If
    End Sub

    'si la carbonatation est cochée
    Private Sub CheckBox7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked = True Then
            ComboBox11.Visible = True
            Label148.Visible = True
            Label149.Visible = True
            Label150.Visible = True
            Label151.Visible = True
            Label145.Visible = True
            Label146.Visible = True
            Label147.Visible = True
            Label141.Visible = True
            Label142.Visible = True
            Label143.Visible = True
            Label144.Visible = True
            TextBox6.Visible = True
            If CheckBox7.Checked = True Then
                Label147.Text = CStr(2.8 * (CDbl(TextBox26.Text) * (CDbl(TextBox3.Text) - 0.3) * (1 - 0.7) / (1000 * (1 + CDbl(TextBox26.Text) * CDbl(TextBox3.Text) / 1000))) ^ 2)
            End If
        Else
            ComboBox11.Visible = False
            Label148.Visible = False
            Label149.Visible = False
            Label150.Visible = False
            Label151.Visible = False
            Label145.Visible = False
            Label146.Visible = False
            Label147.Visible = False
            Label141.Visible = False
            Label142.Visible = False
            Label143.Visible = False
            Label144.Visible = False
            TextBox6.Visible = False
        End If
    End Sub

    'si changement du coefficient de diffusion des ions chlorures
    Private Sub Text46_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Text46.Validating
        Label131.Text = Text46.Text
    End Sub

    'si changement du coefficient de diffusion de vapeur d'eau
    Private Sub Text30_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Text30.Validating
        Label55.Text = Text30.Text
        TextBox10.Text = CStr(CDbl(Label55.Text) / 1.36)
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim a As Decimal
        Dim b As Decimal
        a = CDec(0.0000625 * CDec(TextBox3.Text) ^ 2 - 0.000104 * CDec(TextBox3.Text) + 0.00003)
        b = CDec(-0.015547 * CDec(TextBox3.Text) ^ 2 + 0.021655 * CDec(TextBox3.Text) - 0.005652)
        Label105.Text = CStr(CSng(a * 100 + b))
        If CheckBox6.Checked = True Then
            Text46.Text = CStr(CSng(0.0943 * System.Math.Exp(CDbl(TextBox3.Text) * 7.899) * 0.000001))
        End If
        If CheckBox7.Checked = True Then
            Label147.Text = CStr(2.8 * (CDbl(TextBox26.Text) * (CDbl(TextBox3.Text) - 0.3) * (1 - 0.7) / (1000 * (1 + CDbl(TextBox26.Text) * CDbl(TextBox3.Text) / 1000))) ^ 2)
        End If
    End Sub

    'si changement du coefficient de diffusion de vapeur d'eau
    Private Sub Text30_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Text30.TextChanged
        Label55.Text = Text30.Text
        TextBox10.Text = CStr(CDbl(Label55.Text) / 1.36)
    End Sub

    'si changement du coefficient de diffusion des ions chlorures
    Private Sub Text46_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Text46.TextChanged
        Label131.Text = Text46.Text
    End Sub

    'Dépendance du coefficient de diffuion des ions chlorures avec le rapport E/C
    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            TextBox3_TextChanged(sender, e)
            Label131.Text = Text46.Text
        Else
            If Option4.Checked = False Then
                If Option1.Checked = True Then OptionCheckedChanged(Option1, e)
                If Option2.Checked = True Then OptionCheckedChanged(Option2, e)
                If Option3.Checked = True Then OptionCheckedChanged(Option3, e)
            End If
        End If
        If Label55.Text <> "" And TextBox10.Text <> "" Then CmtTextProb10()
    End Sub

End Class


