Imports System.Linq.Expressions
Imports MathNet.Numerics.Distributions

Public Class frmProb : Inherits System.Windows.Forms.Form

    Dim Length As Single
    Dim Labe(1) As Double
    Dim Lambda(1, 1, 1) As Double
    Dim Ksi(1, 1, 1) As Double
    Dim Nline As Short
    Dim Nc As Short

    Dim PreFile(7) As String
    Dim OutFile As String
    Dim Files As Short = 0
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBoxSigmaS As TextBox
    Friend WithEvents TextBoxmuS As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents TextBoxDiameter As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBoxDensity As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents TextBoxCompressiveStrengh As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Labeltp As Label
    Dim Ca As Boolean = False

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxFreeCl As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxTotCl As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxProb As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPosMean As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPosEcart As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxSteelType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ButtonTreatment As System.Windows.Forms.Button
    Friend WithEvents ButtonAnalyse As System.Windows.Forms.Button
    Friend WithEvents TextBoxClMean As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxClEcar As System.Windows.Forms.TextBox
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LabelLambda As System.Windows.Forms.Label
    Friend WithEvents LabelXsi As System.Windows.Forms.Label
    Friend WithEvents CheckBoxCarb As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxPH As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxWater As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRH As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxTemp As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxTotCl = New System.Windows.Forms.CheckBox()
        Me.CheckBoxFreeCl = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCarb = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPH = New System.Windows.Forms.CheckBox()
        Me.CheckBoxWater = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRH = New System.Windows.Forms.CheckBox()
        Me.CheckBoxTemp = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LabelXsi = New System.Windows.Forms.Label()
        Me.LabelLambda = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBoxClEcar = New System.Windows.Forms.TextBox()
        Me.TextBoxClMean = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxSteelType = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBoxCompressiveStrengh = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBoxDensity = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBoxDiameter = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBoxSigmaS = New System.Windows.Forms.TextBox()
        Me.TextBoxmuS = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBoxPosEcart = New System.Windows.Forms.TextBox()
        Me.TextBoxPosMean = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBoxProb = New System.Windows.Forms.CheckBox()
        Me.ButtonTreatment = New System.Windows.Forms.Button()
        Me.ButtonAnalyse = New System.Windows.Forms.Button()
        Me.ButtonExit = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Labeltp = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBoxTotCl)
        Me.GroupBox1.Controls.Add(Me.CheckBoxFreeCl)
        Me.GroupBox1.Controls.Add(Me.CheckBoxCarb)
        Me.GroupBox1.Controls.Add(Me.CheckBoxPH)
        Me.GroupBox1.Controls.Add(Me.CheckBoxWater)
        Me.GroupBox1.Controls.Add(Me.CheckBoxRH)
        Me.GroupBox1.Controls.Add(Me.CheckBoxTemp)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(136, 248)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Traitement probabiliste"
        '
        'CheckBoxTotCl
        '
        Me.CheckBoxTotCl.Checked = True
        Me.CheckBoxTotCl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxTotCl.Location = New System.Drawing.Point(8, 216)
        Me.CheckBoxTotCl.Name = "CheckBoxTotCl"
        Me.CheckBoxTotCl.Size = New System.Drawing.Size(112, 24)
        Me.CheckBoxTotCl.TabIndex = 6
        Me.CheckBoxTotCl.Text = "Chlorures totaux"
        '
        'CheckBoxFreeCl
        '
        Me.CheckBoxFreeCl.Checked = True
        Me.CheckBoxFreeCl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxFreeCl.Location = New System.Drawing.Point(8, 184)
        Me.CheckBoxFreeCl.Name = "CheckBoxFreeCl"
        Me.CheckBoxFreeCl.Size = New System.Drawing.Size(104, 24)
        Me.CheckBoxFreeCl.TabIndex = 5
        Me.CheckBoxFreeCl.Text = "Chlorures libres"
        '
        'CheckBoxCarb
        '
        Me.CheckBoxCarb.Checked = True
        Me.CheckBoxCarb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCarb.Location = New System.Drawing.Point(8, 142)
        Me.CheckBoxCarb.Name = "CheckBoxCarb"
        Me.CheckBoxCarb.Size = New System.Drawing.Size(104, 40)
        Me.CheckBoxCarb.TabIndex = 4
        Me.CheckBoxCarb.Text = "Profondeur de carbonatation"
        '
        'CheckBoxPH
        '
        Me.CheckBoxPH.Checked = True
        Me.CheckBoxPH.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxPH.Location = New System.Drawing.Point(8, 120)
        Me.CheckBoxPH.Name = "CheckBoxPH"
        Me.CheckBoxPH.Size = New System.Drawing.Size(104, 24)
        Me.CheckBoxPH.TabIndex = 3
        Me.CheckBoxPH.Text = "PH"
        '
        'CheckBoxWater
        '
        Me.CheckBoxWater.Checked = True
        Me.CheckBoxWater.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxWater.Location = New System.Drawing.Point(8, 88)
        Me.CheckBoxWater.Name = "CheckBoxWater"
        Me.CheckBoxWater.Size = New System.Drawing.Size(104, 24)
        Me.CheckBoxWater.TabIndex = 2
        Me.CheckBoxWater.Text = "Teneur en eau"
        '
        'CheckBoxRH
        '
        Me.CheckBoxRH.Checked = True
        Me.CheckBoxRH.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxRH.Location = New System.Drawing.Point(8, 56)
        Me.CheckBoxRH.Name = "CheckBoxRH"
        Me.CheckBoxRH.Size = New System.Drawing.Size(112, 24)
        Me.CheckBoxRH.TabIndex = 1
        Me.CheckBoxRH.Text = "Humidité relative"
        '
        'CheckBoxTemp
        '
        Me.CheckBoxTemp.Checked = True
        Me.CheckBoxTemp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxTemp.Location = New System.Drawing.Point(8, 24)
        Me.CheckBoxTemp.Name = "CheckBoxTemp"
        Me.CheckBoxTemp.Size = New System.Drawing.Size(104, 24)
        Me.CheckBoxTemp.TabIndex = 0
        Me.CheckBoxTemp.Text = "Température"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LabelXsi)
        Me.GroupBox3.Controls.Add(Me.LabelLambda)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.TextBoxClEcar)
        Me.GroupBox3.Controls.Add(Me.TextBoxClMean)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.ComboBoxSteelType)
        Me.GroupBox3.Location = New System.Drawing.Point(150, 136)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(490, 120)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Résistance des aciers aux ions chlorures"
        '
        'LabelXsi
        '
        Me.LabelXsi.Location = New System.Drawing.Point(32, 96)
        Me.LabelXsi.Name = "LabelXsi"
        Me.LabelXsi.Size = New System.Drawing.Size(152, 16)
        Me.LabelXsi.TabIndex = 11
        Me.LabelXsi.Text = "LabelXsi"
        '
        'LabelLambda
        '
        Me.LabelLambda.Location = New System.Drawing.Point(32, 72)
        Me.LabelLambda.Name = "LabelLambda"
        Me.LabelLambda.Size = New System.Drawing.Size(152, 16)
        Me.LabelLambda.TabIndex = 10
        Me.LabelLambda.Text = "LabelLambda"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 16)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "x ="
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 16)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "l ="
        '
        'TextBoxClEcar
        '
        Me.TextBoxClEcar.Location = New System.Drawing.Point(216, 48)
        Me.TextBoxClEcar.Name = "TextBoxClEcar"
        Me.TextBoxClEcar.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxClEcar.TabIndex = 7
        '
        'TextBoxClMean
        '
        Me.TextBoxClMean.Location = New System.Drawing.Point(216, 24)
        Me.TextBoxClMean.Name = "TextBoxClMean"
        Me.TextBoxClMean.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxClMean.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(320, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 16)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "% masse de ciment"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(320, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 16)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "% masse de ciment"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(224, 16)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Teneur en ions chlorures libres (écart-type)"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(216, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Teneur en ions chlorures libres (moyenne)"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(267, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Catégorie d'acier"
        '
        'ComboBoxSteelType
        '
        Me.ComboBoxSteelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSteelType.Items.AddRange(New Object() {"Acier MTQ 50 ans (A.S. Bah)", "Acier Usuel (D. Conciatori)", "Ordinary Steel (G. Roelfstra)", "Acier Top12 (D. Conciatori)", "Steel ICR (grade 1.4003)", "Acier Inox (D. Conciatori)", "Stainless Steel (grade 1.4031)", "Autres Acier"})
        Me.ComboBoxSteelType.Location = New System.Drawing.Point(270, 96)
        Me.ComboBoxSteelType.Name = "ComboBoxSteelType"
        Me.ComboBoxSteelType.Size = New System.Drawing.Size(170, 21)
        Me.ComboBoxSteelType.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxCompressiveStrengh)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.TextBoxDensity)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.TextBoxDiameter)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.TextBoxSigmaS)
        Me.GroupBox2.Controls.Add(Me.TextBoxmuS)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TextBoxPosEcart)
        Me.GroupBox2.Controls.Add(Me.TextBoxPosMean)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.CheckBoxProb)
        Me.GroupBox2.Location = New System.Drawing.Point(150, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(490, 112)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Enrobage des aciers"
        '
        'TextBoxCompressiveStrengh
        '
        Me.TextBoxCompressiveStrengh.Location = New System.Drawing.Point(409, 86)
        Me.TextBoxCompressiveStrengh.Name = "TextBoxCompressiveStrengh"
        Me.TextBoxCompressiveStrengh.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxCompressiveStrengh.TabIndex = 21
        Me.TextBoxCompressiveStrengh.Text = "45.5"
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(452, 89)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 23)
        Me.Label20.TabIndex = 20
        Me.Label20.Text = "MPa"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(332, 88)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(152, 16)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Compression :"
        '
        'TextBoxDensity
        '
        Me.TextBoxDensity.Location = New System.Drawing.Point(219, 86)
        Me.TextBoxDensity.Name = "TextBoxDensity"
        Me.TextBoxDensity.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxDensity.TabIndex = 18
        Me.TextBoxDensity.Text = "7860"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(265, 88)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 23)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "kg/m3"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(164, 88)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(152, 16)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "Densité : "
        '
        'TextBoxDiameter
        '
        Me.TextBoxDiameter.Location = New System.Drawing.Point(65, 85)
        Me.TextBoxDiameter.Name = "TextBoxDiameter"
        Me.TextBoxDiameter.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxDiameter.TabIndex = 15
        Me.TextBoxDiameter.Text = "16"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(107, 88)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(24, 23)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "mm"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(8, 88)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(152, 16)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Diamètre : "
        '
        'TextBoxSigmaS
        '
        Me.TextBoxSigmaS.Location = New System.Drawing.Point(323, 57)
        Me.TextBoxSigmaS.Name = "TextBoxSigmaS"
        Me.TextBoxSigmaS.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxSigmaS.TabIndex = 12
        Me.TextBoxSigmaS.Text = "7.5"
        '
        'TextBoxmuS
        '
        Me.TextBoxmuS.Location = New System.Drawing.Point(170, 57)
        Me.TextBoxmuS.Name = "TextBoxmuS"
        Me.TextBoxmuS.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxmuS.TabIndex = 11
        Me.TextBoxmuS.Text = "150"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(369, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 16)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "mm"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(216, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 23)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "mm"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(246, 61)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(152, 16)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "+ - (écart-type)"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(152, 16)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Espacement Acier : (moyenne)"
        '
        'TextBoxPosEcart
        '
        Me.TextBoxPosEcart.Location = New System.Drawing.Point(323, 29)
        Me.TextBoxPosEcart.Name = "TextBoxPosEcart"
        Me.TextBoxPosEcart.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxPosEcart.TabIndex = 6
        Me.TextBoxPosEcart.Text = "23"
        '
        'TextBoxPosMean
        '
        Me.TextBoxPosMean.Location = New System.Drawing.Point(170, 29)
        Me.TextBoxPosMean.Name = "TextBoxPosMean"
        Me.TextBoxPosMean.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxPosMean.TabIndex = 5
        Me.TextBoxPosMean.Text = "35"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(369, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "mm"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(216, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "mm"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(246, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "+ - (écart-type)"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Position Acier : (moyenne)"
        '
        'CheckBoxProb
        '
        Me.CheckBoxProb.Checked = True
        Me.CheckBoxProb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxProb.Location = New System.Drawing.Point(351, -4)
        Me.CheckBoxProb.Name = "CheckBoxProb"
        Me.CheckBoxProb.Size = New System.Drawing.Size(133, 24)
        Me.CheckBoxProb.TabIndex = 0
        Me.CheckBoxProb.Text = "Traitement probabiliste"
        '
        'ButtonTreatment
        '
        Me.ButtonTreatment.Location = New System.Drawing.Point(8, 264)
        Me.ButtonTreatment.Name = "ButtonTreatment"
        Me.ButtonTreatment.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTreatment.TabIndex = 3
        Me.ButtonTreatment.Text = "Traitement"
        '
        'ButtonAnalyse
        '
        Me.ButtonAnalyse.Location = New System.Drawing.Point(200, 264)
        Me.ButtonAnalyse.Name = "ButtonAnalyse"
        Me.ButtonAnalyse.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAnalyse.TabIndex = 4
        Me.ButtonAnalyse.Text = "Analyse"
        '
        'ButtonExit
        '
        Me.ButtonExit.Location = New System.Drawing.Point(568, 264)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExit.TabIndex = 5
        Me.ButtonExit.Text = "Sortir"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(305, 269)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(29, 13)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "Tp ="
        '
        'Labeltp
        '
        Me.Labeltp.AutoSize = True
        Me.Labeltp.Location = New System.Drawing.Point(340, 269)
        Me.Labeltp.Name = "Labeltp"
        Me.Labeltp.Size = New System.Drawing.Size(13, 13)
        Me.Labeltp.TabIndex = 8
        Me.Labeltp.Text = "0"
        '
        'frmProb
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(648, 296)
        Me.Controls.Add(Me.Labeltp)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ButtonAnalyse)
        Me.Controls.Add(Me.ButtonTreatment)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmProb"
        Me.Text = "Approche probabiliste"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    'chargement de la fenêtre
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ComboBoxSteelType.SelectedIndex = 3
        ButtonAnalyse.Visible = False

    End Sub

    'click sur traitement
    Private Sub ButtonTreatment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTreatment.Click

        Dim La(1, 1, 1, 1, 1, 1) As Double
        Dim Cpd(2, 2, 2, 2) As Double

        Dim Tprob1, Tprob2, Tprob3, Tprob4 As Short
        Dim Canc As Boolean = False
        Dim prefFile As String

        Dim cpt1 As Short = 0
        ManageRFiles(cpt1, Tprob1, Tprob2, Tprob3, Tprob4, prefFile, Canc)
        If Canc = True Then
            End
        End If

        Dim cpt2 As Short = 0
        Dim pd_cont As Double = 0
        Dim p As Short
        Dim Ncol As Short

        MDIChlor.ChangeProgressBar(0)

        For o As Short = 1 To Files
            pd_cont = 0
            cpt2 = 0
            MDIChlor.ChangeProgressBar(100 * o / Files)

            For n As Short = 1 To Tprob4
                For i As Short = 1 To Tprob3
                    For j As Short = 1 To Tprob2
                        For k As Short = 1 To Tprob1

                            cpt2 += CShort(1)

                            If Tprob1 = 1 Then k = 0
                            If Tprob2 = 1 Then j = 0
                            If Tprob3 = 1 Then i = 0
                            If Tprob4 = 1 Then n = 0

                            Dim OutF As String = prefFile & PreFile(o) & OutFile & k & j & i & n & ".txt"

                            If k = 0 Then k += CShort(1)
                            If j = 0 Then j += CShort(1)
                            If i = 0 Then i += CShort(1)
                            If n = 0 Then n += CShort(1)

                            ReadRFile(OutF, cpt1, cpt2, o, p, La, i, j, k, n, pd_cont, Cpd, Ncol)

                        Next k
                    Next j
                Next i
            Next n

            For n As Short = 1 To Tprob4
                For i As Short = 1 To Tprob3
                    For j As Short = 1 To Tprob2
                        For k As Short = 1 To Tprob1
                            For l As Short = 1 To Nline + CShort(2)
                                For m As Short = 2 To Ncol - p
                                    Ksi(l, m, o) = Ksi(l, m, o) + Cpd(k, j, i, n) * (System.Math.Log(CDbl(La(l, m, k, j, i, n))) - Lambda(l, m, o)) ^ 2
                                Next m
                            Next l
                        Next k
                    Next j
                Next i
            Next n
        Next o

    End Sub

    Private Sub ManageRFiles(ByRef cpt1 As Short, ByRef Tprob1 As Short, ByRef Tprob2 As Short, ByRef Tprob3 As Short, ByRef Tprob4 As Short, ByRef prefFile As String, ByRef Canc As Boolean)

        'Dim Filtre As String = "txt files (R_*.txt)|R_*.txt|All files (*.*)|*.*"
        'Dim Index As Short = CShort(1)
        'Dim Directoire As Boolean = True
        'Dim Titre As String = "Sélectionner un fichier résultat à traiter"

        'OpenDialog(OutFile, Canc, Filtre, Index, Directoire, Titre)
        'If Canc = True Then End

        Dim OFDia As New OpenFileDialog
        OFDia.Filter = "txt files (R_*.txt)|R_*.txt|All files (*.*)|*.*"
        OFDia.Title = "Sélectionner un fichier résultat à traiter"
        If MDIChlor.MainLabel.Text <> "Work Folder ?" Then OFDia.InitialDirectory = MDIChlor.MainLabel.Text
        If (OFDia.ShowDialog() = DialogResult.OK) Then OutFile = OFDia.FileName Else End

        prefFile = OutFile
        FileOnly(OutFile)
        prefFile = Microsoft.VisualBasic.Left(prefFile, CInt(Len(prefFile) - Len(OutFile)))
        MDIChlor.MainLabel.Text = prefFile
        OutFile = Microsoft.VisualBasic.Left(OutFile, Len(OutFile) - 4)

        Dim TProb As String = Microsoft.VisualBasic.Right(OutFile, 4)
        OutFile = Microsoft.VisualBasic.Left(OutFile, Len(OutFile) - 4)
        OutFile = Microsoft.VisualBasic.Right(OutFile, Len(OutFile) - 2)

        Dim Dim1 As String = "_"
        Dim iPos As Short = CShort(InStr(1, OutFile, Dim1, CompareMethod.Text)) 'position de "_"

        OutFile = Microsoft.VisualBasic.Right(OutFile, Len(OutFile) - iPos)
        Tprob1 = CShort(Microsoft.VisualBasic.Left(TProb, 1))
        Tprob4 = CShort(Microsoft.VisualBasic.Right(TProb, 1))
        Tprob2 = CShort((CShort(TProb) - 1000 * Tprob1 - Tprob4) / 10)
        Tprob3 = CShort(Microsoft.VisualBasic.Right(CStr(Tprob2), 1))
        Tprob2 = CShort(Microsoft.VisualBasic.Left(CStr(Tprob2), 1))

        Dim cpt2 As Short = 0

        If Tprob1 = 0 Then
            Tprob1 = 1
        Else
            Tprob1 = 2
            cpt1 = 2
        End If
        If Tprob2 = 0 Then
            Tprob2 = 1
        Else
            Tprob2 = 2
            cpt1 = cpt1 * CShort(2)
            If cpt1 = 0 Then cpt1 = 2
        End If
        If Tprob3 = 0 Then
            Tprob3 = 1
        Else
            Tprob3 = 2
            cpt1 = cpt1 * CShort(2)
            If cpt1 = 0 Then cpt1 = 2
        End If
        If Tprob4 = 0 Then
            Tprob4 = 1
        Else
            Tprob4 = 2
            cpt1 = cpt1 * CShort(2)
            If cpt1 = 0 Then cpt1 = 2
        End If

        Files = 0
        If CheckBoxTemp.Checked = True Then
            Files += CShort(1)
            PreFile(Files) = "R_T_"
        End If
        If CheckBoxRH.Checked = True Then
            Files += CShort(1)
            PreFile(Files) = "R_H_"
        End If
        If CheckBoxWater.Checked = True Then
            Files = Files + CShort(1)
            PreFile(Files) = "R_W_"
        End If
        If CheckBoxPH.Checked = True Then
            Files = Files + CShort(1)
            PreFile(Files) = "R_PH_"
        End If
        If CheckBoxFreeCl.Checked = True Then
            Files = Files + CShort(1)
            PreFile(Files) = "R_CL_"
        End If
        If CheckBoxTotCl.Checked = True Then
            Files = Files + CShort(1)
            PreFile(Files) = "R_CT_"
        End If
        If CheckBoxCarb.Checked = True Then
            Files = Files + CShort(1)
            PreFile(Files) = "R_Carb_"
        End If

    End Sub

    Private Sub ReadRFile(ByRef OutF As String, ByRef cpt1 As Short, ByRef cpt2 As Short, ByRef o As Short, ByRef p As Short, ByRef La(,,,,,) As Double,
                               ByRef i As Short, ByRef j As Short, ByRef k As Short, ByRef n As Short, ByRef pd_cont As Double, ByRef Cpd(,,,) As Double, ByRef Ncol As Short)

        Dim Data As String
        Dim nFic As Short = CShort(FreeFile())
        FileOpen(nFic, OutF, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)

        Dim Dim1, Dim2 As String
        Input(nFic, Dim1) 'nbre de ligne
        Input(nFic, Dim2) 'nbre de colonnes
        Dim1 = "_"
        Dim iPos As Short = CShort(InStr(1, Dim2, Dim1, CompareMethod.Text)) 'position de "_"

        If cpt2 = 1 Then Nline = CShort(Mid(Dim2, 1, iPos - 1))
        Dim2 = CStr(Mid(Dim2, iPos + 1))
        Dim1 = " "
        iPos = 1

        Do While iPos = 1
            iPos = CShort(InStr(1, Dim2, Dim1, CompareMethod.Text))
            Dim2 = CStr(Mid(Dim2, iPos + 1))
            iPos = CShort(InStr(1, Dim2, Dim1, CompareMethod.Text))
        Loop

        If cpt2 = 1 Then Ncol = CShort(Mid(Dim2, 1, iPos + 1))

        If cpt2 = 1 And o = 1 Then   'lecture de la première ligne

            ReDim Labe(Ncol - 2)
            ReDim Lambda(Nline + 2, Ncol - 2, Files)
            ReDim Ksi(Nline + 2, Ncol - 2, Files)
            ReDim La(Nline + 2, Ncol - 2, 2, 2, 2, 2)
            Nc = Ncol - CShort(2)

            If PreFile(o) = "R_H_" Or PreFile(o) = "R_W_" Then
                ReDim Lambda(Nline + 2, Ncol - 3, Files)
                ReDim Ksi(Nline + 2, Ncol - 3, Files)
                ReDim La(Nline + 2, Ncol - 3, 2, 2, 2, 2)
                ReDim Labe(Ncol - 3)
                Nc = Ncol - CShort(3)
            End If

            If PreFile(o) = "R_Carb_" Then
                ReDim Lambda(Nline + 2, 4, Files)
                ReDim Ksi(Nline + 2, 4, Files)
                ReDim Labe(4)
                Nc = 4
            End If

            If PreFile(o) = "R_T_" Or PreFile(o) = "R_PH_" Or PreFile(o) = "R_Carb_" Or PreFile(o) = "R_CL_" Or PreFile(o) = "R_CT_" Then p = 2

            If PreFile(o) = "R_H_" Or PreFile(o) = "R_W_" Then p = 3

            If PreFile(o) = "R_Carb_" Then
                Ncol = 5
                p = 2
            End If

            For l As Short = 2 To Ncol - CShort(1)
                Input(nFic, Data)
                If l <= Ncol - p Then
                    Length = CSng(Data)
                    Labe(l) = CDbl(Data)
                End If
            Next l

        Else

            If PreFile(o) = "R_Carb_" Then Ncol = 5

            Dim Poub As String
            For l As Short = 2 To Ncol - CShort(1)
                Input(nFic, Poub)
            Next l

        End If

        Dim1 = "_"  'poids des fonctions probabilistes
        iPos = CShort(InStr(1, Dim2, Dim1, CompareMethod.Text)) 'position de "_"
        Dim2 = Microsoft.VisualBasic.Right(Dim2, Len(Dim2) - iPos)
        Dim1 = " "
        iPos = 1

        Do While iPos = 1
            iPos = CShort(InStr(1, Dim2, Dim1, CompareMethod.Text))
            Dim2 = CStr(Mid(Dim2, iPos + 1))
            iPos = CShort(InStr(1, Dim2, Dim1, CompareMethod.Text))
        Loop

        Dim pd As Double = CDbl(Dim2)
        Dim Test01 As String = ""

        pd_cont = pd_cont + pd  'contrôle
        Cpd(k, j, i, n) = pd

        If cpt2 = cpt1 And o = 1 Then Test01 = "La somme des poids des fonctions probabilistes vaut :" & pd_cont
        If cpt2 = cpt1 And CSng(pd_cont) = 1 And o = 1 Then Test01 = "Réussite du contrôle la somme des poids des fonctions probabilistes"
        If cpt2 = cpt1 And o <> 1 Then
            If CSng(pd_cont) = 1 Then
                Test01 = Test01 & " ok"
            Else
                Test01 = Test01 & " " & pd_cont
            End If
        End If

        If PreFile(o) = "R_T_" Or PreFile(o) = "R_PH_" Or PreFile(o) = "R_Carb_" Or PreFile(o) = "R_CL_" Or PreFile(o) = "R_CT_" Then p = 2
        If PreFile(o) = "R_H_" Or PreFile(o) = "R_W_" Then p = 3
        If PreFile(o) = "R_Carb_" Then
            Ncol = 5
            p = 2
        End If

        MDIChlor.ChangeProgressBar(0)

        For l As Short = 1 To Nline + CShort(2)        'lecture du fichier résultat

            MDIChlor.ChangeProgressBar(100 * l / (Nline + 2))

            For m As Short = 0 To Ncol - CShort(1)

                Try
                    Input(nFic, Data)
                Catch ex As Exception When Data = ""
                    Exit For
                    Exit For
                End Try

                If m <= Ncol - p Then
                    If m <= 1 Then
                        Lambda(l, m, o) = CDbl(Data)
                    Else
                        If CDbl(Data) <= 0 Then Data = "1.0E-300" 'annuler les problèmes numériques
                        Lambda(l, m, o) = Lambda(l, m, o) + pd * System.Math.Log(CDbl(Data))
                        La(l, m, k, j, i, n) = CDbl(Data)
                    End If
                End If
            Next m
        Next l

        FileClose(nFic)

        If cpt2 = cpt1 And o = Files Then

            MsgBox(Test01, MsgBoxStyle.Information And MsgBoxStyle.OkOnly, "Avertissement")
            ButtonAnalyse.Visible = True
            GroupBox1.Enabled = False
            ButtonTreatment.Enabled = False

        End If

        MDIChlor.ChangeProgressBar(0)

    End Sub

    'click sur sortir
    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click

        GroupBox1.Enabled = True
        ButtonTreatment.Enabled = True
        Me.Hide()

    End Sub

    'changement du type d'acier
    Private Sub ComboBoxSteelType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxSteelType.SelectedIndexChanged

        Dim a As Decimal
        Dim b As Decimal

        Select Case ComboBoxSteelType.Text
            Case "Acier MTQ 50 ans (A.S. Bah)"
                TextBoxClMean.Text = CStr(0.59)
                TextBoxClEcar.Text = CStr(0.16)
                TextBoxClMean.Enabled = False
                TextBoxClEcar.Enabled = False
            Case "Acier Usuel (D. Conciatori)"
                TextBoxClMean.Text = CStr(0.536239738583839)
                TextBoxClEcar.Text = CStr(0.761717254531377)
                TextBoxClMean.Enabled = False
                TextBoxClEcar.Enabled = False
            Case "Ordinary Steel (G. Roelfstra)"
                TextBoxClMean.Text = CStr(0.4)
                TextBoxClEcar.Text = CStr(0.15)
                TextBoxClMean.Enabled = False
                TextBoxClEcar.Enabled = False
            Case "Acier Top12 (D. Conciatori)"
                TextBoxClMean.Text = CStr(1.3405993464596)
                TextBoxClEcar.Text = CStr(0.761717254531377)
                TextBoxClMean.Enabled = False
                TextBoxClEcar.Enabled = False
            Case "Steel ICR (grade 1.4003)"
                TextBoxClMean.Text = CStr(1.0)
                TextBoxClEcar.Text = CStr(0.15)
                TextBoxClMean.Enabled = False
                TextBoxClEcar.Enabled = False
            Case "Acier Inox (D. Conciatori)"
                TextBoxClMean.Text = CStr(2.68119869291919)
                TextBoxClEcar.Text = CStr(0.761717254531377)
                TextBoxClMean.Enabled = False
                TextBoxClEcar.Enabled = False
            Case "Stainless Steel (grade 1.4031)"
                TextBoxClMean.Text = CStr(2.0)
                TextBoxClEcar.Text = CStr(0.225)
                TextBoxClMean.Enabled = False
                TextBoxClEcar.Enabled = False
            Case "Autres Acier"
                TextBoxClMean.Text = ""
                TextBoxClEcar.Text = ""
                LabelLambda.Text = ""
                LabelXsi.Text = ""
                TextBoxClMean.Enabled = True
                TextBoxClEcar.Enabled = True
        End Select

    End Sub

    'changement de la moyenne et écart-type dans le type d'acier
    Private Sub AcierChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxClMean.TextChanged, TextBoxClEcar.TextChanged

        If TextBoxClMean.Text = "" Or TextBoxClEcar.Text = "" Then Exit Sub
        LabelLambda.Text = CStr(System.Math.Log(CDbl(TextBoxClMean.Text) ^ 2 / (CDbl(TextBoxClMean.Text) ^ 2 + CDbl(TextBoxClEcar.Text) ^ 2) ^ 0.5))
        LabelXsi.Text = CStr((System.Math.Log(CDbl(TextBoxClEcar.Text) ^ 2 / CDbl(TextBoxClMean.Text) ^ 2 + 1)) ^ 0.5)

    End Sub

    'click sur analyse
    Private Sub ButtonAnalyse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAnalyse.Click

        Dim LAen(Nline + 2, Files) As Double
        Dim KSen(Nline + 2, Files) As Double
        Dim Pf(Nline + 2) As Double

        Dim deltaX3 As Single = 0.01
        Dim Request As MsgBoxResult

        Dim PosXi As Single
        Dim PosmX As Single = 0
        Dim Canc As Boolean = False

        MDIChlor.ChangeProgressBar(0)

        If PreFile(1) <> "R_Carb_" Then

            Request = MsgBox("A partir d'un fichier existant LP_ ?", MsgBoxStyle.YesNo, "Question")

            If Request = MsgBoxResult.No Then

                If PreFile(Files) = "R_Carb_" Then Ca = True
                If Ca = True Then Files = Files - CShort(1) 'enlever la partie carbonatation

                If CheckBoxProb.Checked = True Then

                    CalcEnrobProb(PosXi, PosmX, LAen, KSen)

                Else

                    CalcEnrobDeterm(PosXi, LAen, KSen)

                End If

                MDIChlor.ChangeProgressBar(25)
                WriteLPFile(PosXi, LAen, KSen, Canc)
                If Canc = True Then GoTo b
                MDIChlor.ChangeProgressBar(50)

            Else

                ReadLPFile(LAen, KSen, Canc)
                If Canc = True Then GoTo b
                MDIChlor.ChangeProgressBar(50)

            End If

b:
            If TextBoxClMean.Text <> "" And TextBoxClEcar.Text <> "" Then         'calcul de la probabilité d'initiation de la corrosion due à la présence de ions chlorures

                WritePFFile(False, PosmX, Pf, LAen, KSen, Canc)
                If Canc = True Then GoTo d
                MDIChlor.ChangeProgressBar(75)

                WriteABCDFile(True, PosmX, Pf, LAen, KSen, Canc)
                If Canc = True Then GoTo f

                WriteBCFile(False, Pf, LAen, KSen, Canc)
                If Canc = True Then GoTo d
                MDIChlor.ChangeProgressBar(75)
d:
            End If

        Else
            Ca = True

        End If

        If Ca = True And CheckBoxProb.Checked = True Then          'approche probabiliste pour la carbonatation

            WritePFFile(True, PosmX, Pf, LAen, KSen, Canc)
            If Canc = True Then GoTo f

            WriteBCFile(True, Pf, LAen, KSen, Canc)
            If Canc = True Then GoTo f

f:
        End If

    End Sub

    Private Sub CalcEnrobProb(ByRef PosXi As Single, ByRef PosmX As Single, ByRef LAen(,) As Double, ByRef KSen(,) As Double)

        Dim PosX As Single = 0
        Dim Men As Single = CSng(TextBoxPosMean.Text)
        Dim ETen As Single = CSng(TextBoxPosEcart.Text)

        Dim Var1 As Double
        Dim Var2 As Double
        Dim Var3 As Double
        Dim Var4 As Double
        Dim Var5 As Double
        Dim Var6 As Double = 0
        Dim i As Short

        Dim deltaX1 As Single = 0.01

        MDIChlor.ChangeProgressBar(0)

        Do While PosX < Length

            PosX += deltaX1

            If PosX >= Length Then PosX = Length

            deltaX1 = PosX - PosmX
            Var1 = System.Math.Exp(-0.5 * ((PosmX - Men) / ETen) ^ 2) / ((2 * System.Math.PI) ^ 0.5 * ETen)
            Var2 = System.Math.Exp(-0.5 * ((PosX - Men) / ETen) ^ 2) / ((2 * System.Math.PI) ^ 0.5 * ETen)
            Var3 = (Var1 + Var2) * deltaX1 / 2          'Surface par la méthode des trapèzes
            Var6 = Var3 + Var6

            For i = 2 To Nc

                PosXi = (PosX + PosmX) / 2
                If Labe(i) > PosXi Then Exit For

            Next i

            For o As Short = 1 To Files

                MDIChlor.ChangeProgressBar(o * 100 / Files)

                For j As Short = 1 To Nline + CShort(2)
                    Var4 = (Lambda(j, i, o) - Lambda(j, i - 1, o)) * (PosXi - Labe(i)) / (Labe(i) - Labe(i - 1)) + Lambda(j, i, o)
                    Var5 = (Ksi(j, i, o) - Ksi(j, i - 1, o)) * (PosXi - Labe(i)) / (Labe(i) - Labe(i - 1)) + Ksi(j, i, o)
                    LAen(j, o) = LAen(j, o) + Var4 * Var3
                    KSen(j, o) = KSen(j, o) + Var5 * Var3
                    If PosX = Length Then
                        LAen(j, o) = LAen(j, o) / Var6
                        KSen(j, o) = KSen(j, o) / Var6
                    End If
                Next j
            Next o
            PosmX = PosX

        Loop

    End Sub

    Private Sub CalcEnrobDeterm(ByRef PosXi As Single, ByRef LAen(,) As Double, ByRef KSen(,) As Double)

        Dim Userinput2 As String = InputBox("Approche déterministe de l'enrobage, profondeur d'enrobage en [mm], (0," & Length & ") : ", "Profondeur d'enrobage des aciers d'armature", "35")

        Dim Canc As Boolean = False
        Msg_noEntry(Userinput2, Canc)

        If Canc = False Then Msg_noNumeric(Userinput2, Canc)
        If CDbl(Userinput2) < 0 Or CDbl(Userinput2) > Length Then Canc = True
        If Canc = True Then Exit Sub
        PosXi = CShort(Userinput2)

        Dim i As Short

        For i = 2 To Nc
            If Labe(i) > PosXi Then Exit For
        Next i

        MDIChlor.ChangeProgressBar(0)

        For o As Short = 1 To Files

            MDIChlor.ChangeProgressBar(o * 100 / Files)

            For j As Short = 1 To Nline + CShort(2)
                LAen(j, o) = (Lambda(j, i, o) - Lambda(j, i - 1, o)) * (PosXi - Labe(i)) / (Labe(i) - Labe(i - 1)) + Lambda(j, i, o)
                KSen(j, o) = (Ksi(j, i, o) - Ksi(j, i - 1, o)) * (PosXi - Labe(i)) / (Labe(i) - Labe(i - 1)) + Ksi(j, i, o)
            Next j
        Next o

    End Sub

    Private Sub WriteLPFile(ByRef PosXi As Single, ByRef LAen(,) As Double, ByRef KSen(,) As Double, ByRef Canc As Boolean)

        Dim OFDia As New SaveFileDialog
        OFDia.FileName = "LP_" & OutFile
        OFDia.Filter = "txt files (LP_*.txt)|LP_*.txt|All files (*.*)|*.*"
        OFDia.Title = "Paramètres des lois probabilistes"

        'Dim OT As String = "LP_" & OutFile        'enregistrement intermédiaire
        'Dim Filtre As String = "txt files (LP_*.txt)|LP_*.txt|All files (*.*)|*.*"
        'Dim Index As Short = CShort(1)
        'Dim Directoire As Boolean = True
        'Dim Titre As String = "Paramètres des lois probabilistes"

        If MDIChlor.MainLabel.Text <> "Work Folder ?" Then OFDia.InitialDirectory = MDIChlor.MainLabel.Text
        If (OFDia.ShowDialog() <> DialogResult.OK) Then End

        'SaveDialog(OT, Canc, Filtre, Index, Directoire, Titre)
        'If Canc = True Then End
        Dim nfic As Short = CShort(FreeFile())
        FileOpen(CInt(nfic), OFDia.FileName, OpenMode.Output)

        Dim Men As Single = CSng(TextBoxPosMean.Text)
        Dim ETen As Single = CSng(TextBoxPosEcart.Text)

        If CheckBoxProb.Checked = True Then
            PrintLine(CInt(nfic), "Approche probabiliste, enrobage moyen ", Men, " écart-type de l'enrobage ", ETen)
        Else
            PrintLine(CInt(nfic), "Approche déterministe de l'enrobage, valeur ", PosXi)
        End If

        MDIChlor.ChangeProgressBar(0)

        If Ca = True Then

            Print(nfic, "temps, temps,")

            For o As Short = 1 To Files + CShort(1)
                Print(nfic, PreFile(o), ",", PreFile(o), ",")
            Next o

            PrintLine(nfic, PreFile(Files + 1), ",", PreFile(Files + 1), ",")
            Print(nfic, "années, jours,")

            For o As Short = 1 To Files + CShort(2)
                Print(nfic, "lambda, ksi,")
            Next

            PrintLine(nfic, "")

            For j As Short = 1 To Nline + CShort(2)

                MDIChlor.ChangeProgressBar(j * 100 / (Nline + 2))

                Print(nfic, Lambda(j, 0, 1), ",", Lambda(j, 1, 1), ",")
                For o As Short = 1 To Files
                    Print(nfic, LAen(j, o), ",", KSen(j, o), ",")
                Next o
                PrintLine(nfic, Lambda(j, 2, Files + 1), ",", Ksi(j, 2, Files + 1), ",", Lambda(j, 3, Files + 1), ",", Ksi(j, 3, Files + 1), ",")
            Next j

        Else

            Print(nfic, "temps, temps,")

            For o As Short = 1 To Files
                Print(nfic, PreFile(o), ",", PreFile(o), ",")
            Next o

            PrintLine(nfic, "")
            Print(nfic, "années, jours,")

            For o As Short = 1 To Files
                Print(nfic, "lambda, ksi,")
            Next

            PrintLine(nfic, "")

            For j As Short = 1 To Nline + CShort(2)

                MDIChlor.ChangeProgressBar(j * 100 / (Nline + 2))

                Print(nfic, Lambda(j, 0, 1), ",", Lambda(j, 1, 1), ",")
                For o As Short = 1 To Files
                    Print(nfic, LAen(j, o), ",", KSen(j, o), ",")
                Next o
                PrintLine(nfic, "")
            Next j
        End If

        FileClose(nfic)

    End Sub

    Private Sub ReadLPFile(ByRef LAen(,) As Double, ByRef KSen(,) As Double, ByRef Canc As Boolean)

        'Dim Filtre As String = "txt files (LP_*.txt)|LP_*.txt|All files (*.*)|*.*"
        'Dim Index As Short = CShort(1)
        'Dim Directoire As Boolean = True
        'Dim Titre As String = "Sélectionner un fichier résultat à traiter"

        'Dim PlFile As String
        'OpenDialog(PlFile, Canc, Filtre, Index, Directoire, Titre)
        'If Canc = True Then End

        Dim OFDia As New OpenFileDialog
        OFDia.Filter = "txt files (LP_*.txt)|LP_*.txt|All files (*.*)|*.*"
        OFDia.Title = "Sélectionner un fichier résultat à traiter"
        If MDIChlor.MainLabel.Text <> "Work Folder ?" Then OFDia.InitialDirectory = MDIChlor.MainLabel.Text
        If (OFDia.ShowDialog() = DialogResult.OK) Then MDIChlor.MainLabel.Text = OFDia.InitialDirectory Else End

        Dim nfic As Short = CShort(FreeFile())
        FileOpen(nfic, OFDia.FileName, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)

        Dim Userinput2 As String = ""
        Input(nfic, Userinput2)
        Input(nfic, Userinput2)
        Input(nfic, Userinput2)
        Input(nfic, Userinput2)
        Input(nfic, Userinput2)

        Dim cpt As Integer = 1
        Dim val As Short = 0

        Do While Userinput2.Contains("R_")
            Input(nfic, Userinput2)
            If Userinput2 = "R_Carb_" Then
                val = 2
                Ca = True
            End If
            cpt += 1
        Loop

        cpt -= 1
        Files = CShort(cpt / 2 - val)

        If val = 0 Then Ca = False
        If Ca = True Then

            For o As Short = 1 To CShort((Files + 3) * 2 + 3)
                Input(nfic, Userinput2)
            Next o

            Dim j As Short = 0
            Do While Userinput2 <> "-10"
                j += CShort(1)
                Try
                    Input(nfic, Userinput2)
                Catch ex As Exception When Userinput2 = ""
                    Exit Do
                End Try
                Input(nfic, Userinput2)
                For o As Short = 1 To Files
                    Input(nfic, Userinput2)
                    LAen(j, o) = CDbl(Userinput2)
                    Input(nfic, Userinput2)
                    KSen(j, o) = CDbl(Userinput2)
                Next o
                Input(nfic, Userinput2)
                Lambda(j, 2, Files + 1) = CDbl(Userinput2)
                Input(nfic, Userinput2)
                Ksi(j, 2, Files + 1) = CDbl(Userinput2)
                Input(nfic, Userinput2)
                Lambda(j, 3, Files + 1) = CDbl(Userinput2)
                Input(nfic, Userinput2)
                Ksi(j, 3, Files + 1) = CDbl(Userinput2)
                Input(nfic, Userinput2)
            Loop

        Else

            For o As Short = 1 To CShort(Files * 2 + 3)
                Input(nfic, Userinput2)
            Next o

            Dim j As Short = 0
            Do While Userinput2 <> "-10"
                j += CShort(1)
                Try
                    Input(nfic, Userinput2)
                Catch ex As Exception When Userinput2 = ""
                    Exit Do
                End Try
                Input(nfic, Userinput2)
                For o As Short = 1 To Files
                    Try
                        Input(nfic, Userinput2)
                        LAen(j, o) = CDbl(Userinput2)
                        Input(nfic, Userinput2)
                        KSen(j, o) = CDbl(Userinput2)
                    Catch
                        Exit Do
                    End Try
                Next o
                Input(nfic, Userinput2)
            Loop
        End If

        FileClose(nfic)

    End Sub

    Private Sub CalcBC(ByRef Pf() As Double, ByRef KSen(,) As Double)

        Dim Var3 As Double

        For j As Short = 1 To Nline + CShort(2)  'calcul de l'indice de fiabilité bêta

            Dim Var1 As Double = -4           'beta
            Dim Var2 As Double = 4            'delta beta
            Dim Var4 As Double = 10
            Dim Spos As Boolean = False
            Dim Spos_old As Boolean = False

            Do While System.Math.Abs(Var2) > 0.001

                If Var4 <> 10 Then Var1 = Var1 + Var2

                If Var1 >= 0 Then
                    Var3 = 1 / (1 + 0.3275911 * Var1)
                    Var3 = 1 - (0.254829592 * Var3 - 0.284496736 * Var3 ^ 2 + 1.421413741 * Var3 ^ 3 - 1.453152027 * Var3 ^ 4 + 1.061405429 * Var3 ^ 5) * System.Math.Exp(-Var1 ^ 2)
                    Var3 = 0.5 * (1 - Var3)         'pf approximé
                Else
                    Var3 = 1 / (1 + 0.3275911 * (-Var1))
                    Var3 = 1 - (0.254829592 * Var3 - 0.284496736 * Var3 ^ 2 + 1.421413741 * Var3 ^ 3 - 1.453152027 * Var3 ^ 4 + 1.061405429 * Var3 ^ 5) * System.Math.Exp(-Var1 ^ 2)
                    Var3 = 0.5 * (1 + Var3)         'pf approximé
                End If

                Var4 = Pf(j) - Var3
                If Var4 < 0 Then
                    Spos = False
                Else
                    Spos = True
                End If
                If Spos <> Spos_old Then
                    Var2 = -Var2 / 10
                End If
                Spos_old = Spos
                If Pf(j) = 0 Then
                    Var1 = 20
                    Exit Do
                End If
                If Var1 < -20 Then
                    Var1 = -20
                    Exit Do
                End If
            Loop

            KSen(j, 0) = Var1           'indice de fiabilité bêta

        Next j

    End Sub

    Private Sub CalcProbInit(ByRef Carb As Boolean, ByRef PosmX As Single, ByRef Pf() As Double, ByRef LAen(,) As Double, ByRef KSen(,) As Double, ByRef Canc As Boolean)

        Dim deltaCL2 As Single = 0.005
        If Ca = True And CheckBoxProb.Checked = True Then
            deltaCL2 = 0.1
        End If

        Dim PosX As Single = 0
        Dim o As Short

        If Carb = True Then
            If PreFile(1) = "R_Carb_" Then Files = Files - CShort(1)
        End If

        For o = 1 To Files
            If PreFile(o) = "R_CL_" Then
                PosX = 0
                Exit For
            Else
                PosX = 1
            End If
        Next o

        If PosX <> 0 Then
            Canc = True
            End
        End If

        Dim Var4 As Double = 0

        ' Garde le max de concentration de Cl pour lisser la courbe de probabilité

        Dim LAenNew(Nline + CShort(2)) As Double
        Dim KSenNew(Nline + CShort(2)) As Double
        Dim itmp As Short = 1
        Dim nbmoyenne As Integer = 24

        ' MOYENNAGE DE LA COURBE DE CHLORE

        For j As Short = 1 To (Nline + CShort(2)) / nbmoyenne

                For i As Short = itmp To itmp + nbmoyenne - 1
                    LAenNew(j) += LAen(i, o)
                    KSenNew(j) += KSen(i, o)
                Next
                LAenNew(j) /= nbmoyenne
                KSenNew(j) /= nbmoyenne
                itmp += nbmoyenne

        Next

        itmp = 1
        For j As Short = 1 To (Nline + CShort(2)) / nbmoyenne

                For i As Short = itmp To itmp + nbmoyenne - 1
                    LAen(i, o) = LAenNew(j)
                    KSen(i, o) = KSenNew(j)
                Next
                itmp += nbmoyenne

        Next

        MDIChlor.ChangeProgressBar(0)

        For j As Short = 1 To Nline + CShort(2)

            MDIChlor.ChangeProgressBar(j * 100 / (Nline + 2))

            If j = 1 Then PosmX = deltaCL2
            deltaCL2 = CSng(PosmX)

            PosX = 0
            Dim Var7 As Double = 1
            Dim Var5 As Double = 1.0E-300
            If Ca = True And CheckBoxProb.Checked = True Then Var5 = 0

            Dim Var1 As Double
            Dim Var2 As Double
            Dim Var3 As Double
            Dim Var6 As Double
            Dim Var8 As Double = 0

            Dim PosMax As Single
            If Carb = True Then
                PosMax = Length
            Else
                PosMax = 2
            End If

            Do While PosX < PosMax Or Var7 >= 0.00001

                If PosX > Length And Carb = True Then
                    deltaCL2 = Length - PosX
                    PosX = Length
                End If

                PosX += deltaCL2
                If Carb = True Then
                    Var1 = System.Math.Exp(-0.5 * ((System.Math.Log(PosX) - Lambda(j, 2, Files + 1)) / Ksi(j, 2, Files + 1)) ^ 2) / ((2 * System.Math.PI) ^ 0.5 * Ksi(j, 2, Files + 1) * PosX)            'fs
                Else
                    Var1 = System.Math.Exp(-0.5 * ((System.Math.Log(PosX) - LAen(j, o)) / KSen(j, o)) ^ 2) / ((2 * System.Math.PI) ^ 0.5 * KSen(j, o) * PosX)            'fs
                End If

                If Carb = True Then
                    Var3 = System.Math.Exp(-0.5 * ((PosX - CDbl(TextBoxPosMean.Text)) / CDbl(TextBoxPosEcart.Text)) ^ 2) / ((2 * System.Math.PI) ^ 0.5 * CDbl(TextBoxPosEcart.Text))
                Else
                    Var3 = System.Math.Exp(-0.5 * ((System.Math.Log(PosX) - CDbl(LabelLambda.Text)) / CDbl(LabelXsi.Text)) ^ 2) / ((2 * System.Math.PI) ^ 0.5 * CDbl(LabelXsi.Text) * PosX)
                End If

                Var6 = System.Math.Exp(-0.5 * ((System.Math.Log(PosX - deltaCL2 / 2) - CDbl(LabelLambda.Text)) / CDbl(LabelXsi.Text)) ^ 2) / ((2 * System.Math.PI) ^ 0.5 * CDbl(LabelXsi.Text) * (PosX - deltaCL2 / 2))

                If Carb = True Then
                    Var2 = System.Math.Exp(-0.5 * ((Var5 - CDbl(TextBoxPosMean.Text)) / CDbl(TextBoxPosEcart.Text)) ^ 2) / ((2 * System.Math.PI) ^ 0.5 * CDbl(TextBoxPosEcart.Text))
                Else
                    Var2 = System.Math.Exp(-0.5 * ((System.Math.Log(Var5) - CDbl(LabelLambda.Text)) / CDbl(LabelXsi.Text)) ^ 2) / ((2 * System.Math.PI) ^ 0.5 * CDbl(LabelXsi.Text) * Var5)
                End If

                Var2 = (Var2 + Var6) * deltaCL2 / 4         'méthode des trapèzes
                Var3 = (Var3 + Var6) * deltaCL2 / 4 + Var2

                Dim Var9 As Double = Var1 * (Var8 + Var3) 'partie de Pf sans l'intégration de xi+1

                Var1 = System.Math.Exp(-0.5 * ((System.Math.Log(PosX - deltaCL2 / 2) - LAen(j, o)) / KSen(j, o)) ^ 2) / ((2 * System.Math.PI) ^ 0.5 * KSen(j, o) * (PosX - deltaCL2 / 2))    'fs
                Var6 = Var1 * (Var8 + Var2) 'partie de Pf sans l'intégration de (xi+1 + xi)/2

                If PosX <> deltaCL2 Then        'formule de simpson
                    Var7 = (PosX - Var5) * (Var9 + 4 * Var6 + Var4) / 6
                    Pf(j) += Var7
                End If

                Var8 += Var3
                Var4 = Var9
                Var5 = PosX

            Loop

            LAen(j, 0) = LAen(j, 0) / Var8  'correction due au troncage de l'épaisseur du mur
            If Pf(j) > 1 Then
                Pf(j) = 1
            End If

        Next j

        ' Rendre Pf monotonique décroissante
        Dim PfNew(Nline + CShort(2)) As Double
        PfNew(0) = -100000

        For j As Short = 1 To Nline + CShort(2)

                If Pf(j) > PfNew(j - 1) Then
                    PfNew(j) = Pf(j)
                Else
                    PfNew(j) = PfNew(j - 1)
                End If

            Next

            For j As Short = 1 To Nline + CShort(2)
                Pf(j) = PfNew(j)
            Next

    End Sub

    Private Sub CalcProbCorr(ByRef Pf() As Double, ByRef Pini() As Double, ByRef Pcracks() As Double, ByRef Pdelam() As Double, ByRef Pdestruct() As Double, ByRef LAen(,) As Double, ByRef Canc As Boolean)

        ' Constant for corrosion properties
        Dim jrr2 As Double = 0.8
        Dim jr As Double
        Dim pr As Integer = 3600
        Dim alpha As Double = 0.52
        Dim v As Double

        Dim fc As Double = CDbl(TextBoxCompressiveStrengh.Text)
        Dim fct As Double = 0.53 * fc ^ 0.5
        Dim Ec As Double = 4600 * fc ^ 0.5

alpha:

        Dim PosXTemp As Single = 0
        Dim o As Short

        For o = 1 To Files
            If PreFile(o) = "R_T_" Then
                PosXTemp = 0
                Exit For
            Else
                PosXTemp = 1
            End If
        Next o

        Dim Temphis(Nline + 2) As Double
        If PosXTemp = 0 Then
            For j As Short = 1 To Nline + CShort(2)
                Temphis(j) = LAen(j, o)
            Next
        Else
            For j As Short = 1 To Nline + CShort(2)
                Temphis(j) = 20
            Next
        End If

        ' Rebar Spacing
        Dim muS As Double = CDbl(TextBoxmuS.Text)
        Dim sigmaS As Double = CDbl(TextBoxSigmaS.Text)
        Dim c2 As Double = CDbl(TextBoxPosMean.Text)

        ' Rebar Diameter
        Dim d As Double = CDbl(TextBoxDiameter.Text)
        ' Rebar density
        Dim ps As Double = CDbl(TextBoxDensity.Text)

        Dim kc As Double
        Dim tp(Nline + 2) As Double 'Delamination
        Dim tp_2(Nline + 2) As Double 'First Cracks

        ' Corrosion propagation
        For j As Short = 1 To Nline + CShort(2)

            If PosXTemp = 0 Then
                If Temphis(j) < 20 Then
                    kc = 0.025
                    v = 0.2
                Else
                    kc = 0.073
                    v = 0.4
                End If

                jr = jrr2 * (1 + kc * (Temphis(j) - 20))

            Else

                jr = jrr2

            End If

            tp(j) = System.Math.PI / (2 * muS * jr * (1 / pr - alpha / ps)) * (1 + v + d ^ 2 / (2 * c2 * (c2 + d))) * (2 * c2 * d + d ^ 2) * fct / Ec

            Labeltp.Text = tp(j)
            tp(j) *= 24
            tp_2(j) = tp(j) / 2.0

            If tp(j) < 0 Then tp(j) = 10000
            If tp_2(j) < 0 Then tp(j) = 10000

        Next

        Dim tmphis_2, tmphis As Integer
        Dim PDF_tp_2(Nline + CShort(2)) As Double
        Dim PDF_tp(Nline + CShort(2)) As Double

        For i As Short = 1 To Nline + CShort(2)

            tmphis_2 = 0
            tmphis = 0

            For j As Short = 1 To Nline + CShort(2)
                If tp_2(j) < (i - 0.5) And tp_2(j) > (i - 1.5) Then
                    tmphis_2 += 1
                End If
                If tp(j) < (i - 0.5) And tp(j) > (i - 1.5) Then
                    tmphis += 1
                End If
            Next

            PDF_tp_2(i) = tmphis_2 / (Nline + CShort(2))
            PDF_tp(i) = tmphis / (Nline + CShort(2))

        Next

        Dim Ft_2(Nline + CShort(2)), Ft(Nline + CShort(2)) As Double

        For itt As Integer = 1 To Nline + CShort(2)
            For itp As Integer = 1 To itt
                If itt <> itp Then
                    Ft_2(itt) += PDF_tp_2(itp) * Pf(itt - itp)
                    Ft(itt) += PDF_tp(itp) * Pf(itt - itp)
                End If
            Next
        Next

        For j As Short = 1 To Nline + CShort(2)

            Pini(j) = 1 - Pf(j)
            Pcracks(j) = Pf(j) - Ft_2(j)  'Pf(j) - Ft_2(j)
            Pdelam(j) = Ft_2(j) - Ft(j)    'Ft_2(j) - Ft(j)
            Pdestruct(j) = Ft(j)   'Ft(j)

        Next

    End Sub

    Private Sub WritePFFile(ByRef Carb As Boolean, ByRef PosmX As Single, ByRef Pf() As Double, ByRef LAen(,) As Double, ByRef KSen(,) As Double, ByRef Canc As Boolean)

        'Dim OT As String
        'Dim Filtre As String
        'Dim Index As Short
        'Dim Directoire As Boolean
        'Dim Titre As String
        Dim OFDia As New SaveFileDialog

        If Carb = True Then          'approche probabiliste pour la carbonatation

            'OT = "PFCa_" & OutFile        'enregistrement des probabilité d'initiation de la corrosion due à la carbonatation
            'Filtre = "txt files (PFCa_*.txt)|PFCa_*.txt|All files (*.*)|*.*"
            'Index = CShort(1)
            'Directoire = True
            'Titre = "Probabilités d'initiation de la corrosion (carb)"
            OFDia.FileName = "PFCa_" & OutFile
            OFDia.Filter = "txt files (PFCa_*.txt)|PFCa_*.txt|All files (*.*)|*.*"
            OFDia.Title = "Probabilités d'initiation de la corrosion (carb)"

        Else

            'OT = "PFCL_" & OutFile        'enregistrement des probabilité d'initiation de la corrosion due à la présence des ions chlorures
            'Filtre = "txt files (PFCL_*.txt)|PFCL_*.txt|All files (*.*)|*.*"
            'Index = CShort(1)
            'Directoire = True
            'Titre = "Probabilités d'initiation de la corrosion (Cl-)"
            OFDia.FileName = "PFCL_" & OutFile
            OFDia.Filter = "txt files (PFCL_*.txt)|PFCL_*.txt|All files (*.*)|*.*"
            OFDia.Title = "Probabilités d'initiation de la corrosion (Cl-)"

        End If

        If MDIChlor.MainLabel.Text <> "Work Folder ?" Then OFDia.InitialDirectory = MDIChlor.MainLabel.Text
        If (OFDia.ShowDialog() <> DialogResult.OK) Then End

        'SaveDialog(OT, Canc, Filtre, Index, Directoire, Titre)
        'If Canc = True Then End

        CalcProbInit(Carb, PosmX, Pf, LAen, KSen, Canc)
        If Canc = True Then End

        Dim nfic As Short = CShort(FreeFile())
        FileOpen(CInt(nfic), OFDia.FileName, OpenMode.Output)
        PrintLine(CInt(nfic), "Probabilité d'initiation de la corrosion due à la présence de ions chlorures,")
        PrintLine(nfic, "temps, temps, Pf,")
        PrintLine(nfic, "années, jours,")

        For j As Short = 1 To Nline + CShort(2)
            PrintLine(nfic, Lambda(j, 0, 1), ",", Lambda(j, 1, 1), ",", Pf(j), ",")
        Next j

        FileClose(nfic)

    End Sub

    Private Sub WriteABCDFile(ByRef Carb As Boolean, ByRef PosmX As Single, ByRef Pf() As Double, ByRef LAen(,) As Double, ByRef KSen(,) As Double, ByRef Canc As Boolean)

        'Dim OT As String
        'Dim Filtre As String
        'Dim Index As Short
        'Dim Directoire As Boolean
        'Dim Titre As String
        Dim OFDia As New SaveFileDialog

        'OT = "PABCD_" & OutFile        'enregistrement des probabilité d'initiation de la corrosion due à la présence des ions chlorures
        'Filtre = "txt files (PABCD_*.txt)|PABCD_*.txt|All files (*.*)|*.*"
        'Index = CShort(1)
        'Directoire = True
        'Titre = "Probabilités d'états A, B, C, D"
        OFDia.FileName = "PABCD_" & OutFile
        OFDia.Filter = "txt files (PABCD_*.txt)|PABCD_*.txt|All files (*.*)|*.*"
        OFDia.Title = "Probabilités d'états A, B, C, D"

        'SaveDialog(OT, Canc, Filtre, Index, Directoire, Titre)
        'If Canc = True Then End

        If MDIChlor.MainLabel.Text <> "Work Folder ?" Then OFDia.InitialDirectory = MDIChlor.MainLabel.Text
        If (OFDia.ShowDialog() <> DialogResult.OK) Then End

        Dim Pini(Nline + 2) As Double
        Dim Pcracks(Nline + 2) As Double
        Dim Pdelam(Nline + 2) As Double
        Dim Pdestroy(Nline + 2) As Double

        CalcProbCorr(Pf, Pini, Pcracks, Pdelam, Pdestroy, LAen, Canc)
        If Canc = True Then End

        Dim nfic As Short = CShort(FreeFile())
        FileOpen(CInt(nfic), OFDia.FileName, OpenMode.Output)
        PrintLine(CInt(nfic), "Pourcentage d'états A B C D")
        PrintLine(nfic, "temps, temps, A, B, C, D")
        PrintLine(nfic, "années, jours,")

        For j As Short = 1 To Nline + CShort(2)
            PrintLine(nfic, Lambda(j, 0, 1), ",", Lambda(j, 1, 1), ",", Pini(j), ",", Pcracks(j), ",", Pdelam(j), ",", Pdestroy(j), ",")
        Next j

        FileClose(nfic)

    End Sub

    Private Sub WriteBCFile(ByRef Carb As Boolean, ByRef Pf() As Double, ByRef LAen(,) As Double, ByRef KSen(,) As Double, ByRef Canc As Boolean)

        'Dim OT As String
        'Dim Filtre As String
        'Dim Index As Short
        'Dim Directoire As Boolean
        'Dim Titre As String
        Dim OFDia As New SaveFileDialog

        If Carb = True Then          'approche probabiliste pour la carbonatation

            'OT = "BCa_" & OutFile        'enregistrement de l'indice de fiabilité pour la corrosion par les chlorures
            'Filtre = "txt files (BCa_*.txt)|BCa_*.txt|All files (*.*)|*.*"
            'Index = CShort(1)
            'Directoire = True
            'Titre = "Indice de fiabilité (carb)"
            OFDia.FileName = "BCa_" & OutFile
            OFDia.Filter = "txt files (BCa_*.txt)|BCa_*.txt|All files (*.*)|*.*"
            OFDia.Title = "Indice de fiabilité (carb)"

        Else

            'OT = "BCL_" & OutFile        'enregistrement de l'indice de fiabilité pour la corrosion par les chlorures
            'Filtre = "txt files (BCL_*.txt)|BCL_*.txt|All files (*.*)|*.*"
            'Index = CShort(1)
            'Directoire = True
            'Titre = "Indice de fiabilité (Cl-)"
            OFDia.FileName = "BCL_" & OutFile
            OFDia.Filter = "txt files (BCL_*.txt)|BCL_*.txt|All files (*.*)|*.*"
            OFDia.Title = "Indice de fiabilité (Cl-)"

        End If

        If MDIChlor.MainLabel.Text <> "Work Folder ?" Then OFDia.InitialDirectory = MDIChlor.MainLabel.Text
        If (OFDia.ShowDialog() <> DialogResult.OK) Then End

        'SaveDialog(OT, Canc, Filtre, Index, Directoire, Titre)
        'If Canc = True Then End

        CalcBC(Pf, KSen)

        Dim nfic As Short = CShort(FreeFile())
        FileOpen(CInt(nfic), OFDia.FileName, OpenMode.Output)
        PrintLine(CInt(nfic), "Indice de fiabilité pour la corrosion due à la présence de ions chlorures")
        PrintLine(nfic, "temps, temps, Bêta,")
        PrintLine(nfic, "années, jours,")

        For j As Short = 1 To Nline + CShort(2)
            PrintLine(nfic, Lambda(j, 0, 1), ",", Lambda(j, 1, 1), ",", KSen(j, 0), ",")
            LAen(j, 0) = 0
            LAen(j, 1) = 0
        Next j

        FileClose(nfic)

    End Sub

    'activation de l'approche probabiliste pour l'enrobage
    Private Sub CheckBoxProb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxProb.CheckedChanged

        If CheckBoxProb.Checked = True Then
            TextBoxPosMean.Text = CStr(35)
            TextBoxPosMean.Enabled = True
            TextBoxPosEcart.Text = CStr(23)
            TextBoxPosEcart.Enabled = True
        Else
            TextBoxPosMean.Text = ""
            TextBoxPosMean.Enabled = False
            TextBoxPosEcart.Text = ""
            TextBoxPosEcart.Enabled = False
        End If

    End Sub

End Class
