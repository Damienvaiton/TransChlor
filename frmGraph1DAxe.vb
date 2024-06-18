Public Class frmGraph1DAxe : Inherits System.Windows.Forms.Form

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
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Option1 As System.Windows.Forms.RadioButton
    Public WithEvents Option2 As System.Windows.Forms.RadioButton
    Public WithEvents Option4 As System.Windows.Forms.RadioButton
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Option8 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.Option1 = New System.Windows.Forms.RadioButton()
        Me.Option2 = New System.Windows.Forms.RadioButton()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.Option4 = New System.Windows.Forms.RadioButton()
        Me.Option8 = New System.Windows.Forms.RadioButton()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(448, 40)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(145, 28)
        Me.Text1.TabIndex = 21
        Me.Text1.Text = "0"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.Option1)
        Me.Frame1.Controls.Add(Me.Option2)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 32)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(137, 65)
        Me.Frame1.TabIndex = 19
        Me.Frame1.TabStop = False
        '
        'Option1
        '
        Me.Option1.BackColor = System.Drawing.SystemColors.Control
        Me.Option1.Checked = True
        Me.Option1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Location = New System.Drawing.Point(8, 8)
        Me.Option1.Name = "Option1"
        Me.Option1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option1.Size = New System.Drawing.Size(97, 25)
        Me.Option1.TabIndex = 11
        Me.Option1.TabStop = True
        Me.Option1.Text = "Temps"
        Me.Option1.UseVisualStyleBackColor = False
        '
        'Option2
        '
        Me.Option2.BackColor = System.Drawing.SystemColors.Control
        Me.Option2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2.Location = New System.Drawing.Point(8, 32)
        Me.Option2.Name = "Option2"
        Me.Option2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option2.Size = New System.Drawing.Size(113, 25)
        Me.Option2.TabIndex = 12
        Me.Option2.TabStop = True
        Me.Option2.Text = "Profondeur"
        Me.Option2.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.Option4)
        Me.Frame2.Controls.Add(Me.Option8)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 128)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(273, 65)
        Me.Frame2.TabIndex = 18
        Me.Frame2.TabStop = False
        '
        'Option4
        '
        Me.Option4.BackColor = System.Drawing.SystemColors.Control
        Me.Option4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option4.Location = New System.Drawing.Point(8, 32)
        Me.Option4.Name = "Option4"
        Me.Option4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option4.Size = New System.Drawing.Size(257, 25)
        Me.Option4.TabIndex = 4
        Me.Option4.TabStop = True
        Me.Option4.Text = "teneur en eau cumulée"
        Me.Option4.UseVisualStyleBackColor = False
        Me.Option4.Visible = False
        '
        'Option8
        '
        Me.Option8.BackColor = System.Drawing.SystemColors.Control
        Me.Option8.Checked = True
        Me.Option8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option8.Location = New System.Drawing.Point(8, 8)
        Me.Option8.Name = "Option8"
        Me.Option8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option8.Size = New System.Drawing.Size(257, 25)
        Me.Option8.TabIndex = 5
        Me.Option8.TabStop = True
        Me.Option8.Text = "température"
        Me.Option8.UseVisualStyleBackColor = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(544, 152)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(41, 33)
        Me.Command2.TabIndex = 17
        Me.Command2.Text = "&Ok"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(184, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(225, 17)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "profondeur de la surface en mm :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 13.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(129, 33)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Axe y :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 13.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(129, 33)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Axe x :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(448, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(144, 64)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(8, 32)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(104, 24)
        Me.RadioButton2.TabIndex = 25
        Me.RadioButton2.Text = "Bord droit"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(8, 8)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(104, 24)
        Me.RadioButton1.TabIndex = 24
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Bord gauche"
        '
        'frmAxe
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(608, 197)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Text1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmAxe"
        Me.Text = "frmAxe"
        Me.Frame1.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim i As Short

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        If Me.Text1.Text = "" Then
            If Option4.Checked = False Then
                MsgBox("Coordonnées x manquent", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation, "Message")
            Else
                Text1.Text = CStr(0)
                Me.Hide()
                Exit Sub
            End If
        Else
            Me.Hide()
            Exit Sub
        End If
    End Sub

    Private Sub frmAxe1_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Dim nFic As Short = FreeFile()
        Dim outfile As String = "tttemp.txt"
        Dim NoAxex As Short
        Dim NoAxey As Short
        Dim NCurve As Short
        Dim TesGraph As Short
        Dim TypY As String

        FileOpen(CInt(nFic), outfile, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
        Input(CInt(nFic), NCurve)
        Input(CInt(nFic), TesGraph)
        Input(CInt(nFic), NoAxex)
        Input(CInt(nFic), NoAxey)
        Input(CInt(nFic), TypY)
        FileClose(CInt(nFic))

        Me.Text = "Choix des axes, courbe n° " & CStr(NCurve)
        GroupBox1.Visible = False
        If TesGraph <> CShort(0) Then
            Option1.Visible = False
            Option2.Visible = False
            If NoAxex = CShort(0) Then
                Option1.Visible = True
            Else
                Option1.Checked = True
                Option2.Visible = True
            End If
        End If

        Option4.Visible = False
        Select Case TypY
            Case "H"
                Option8.Text = "humidité relative"
                If TesGraph = CShort(0) Then
                    Option4.Visible = True
                    Option8.Checked = True
                Else
                    If NoAxey = CShort(5) Then Option4.Visible = True
                End If
            Case "W"
                Option8.Text = "teneur en eau"
                If TesGraph = CShort(0) Then
                    Option4.Visible = True
                    Option8.Checked = True
                Else
                    If NoAxey = CShort(5) Then Option4.Visible = True
                End If
            Case "CT"
                Option8.Text = "teneur en ions chlorures totaux"
                Option8.Checked = True
            Case "CL"
                Option8.Text = "teneur en ions chlorures libres"
                Option8.Checked = True
            Case "T"
                Option8.Text = "température"
                Option8.Checked = True
            Case "P"
                Option8.Text = "valeur du PH"
                Option8.Checked = True
            Case "Ca"
                Option8.Text = "profondeur de carbonatation"
                Option8.Checked = True
                GroupBox1.Visible = True
                Option2.Visible = False
                Text1.Enabled = False
        End Select

    End Sub

    Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option1.CheckedChanged
        If Option1.Checked = True Then
            Label2.Text = "profondeur de la surface en mm :"
        Else
            Label2.Text = "temps en jour :"
        End If
    End Sub

    Private Sub Text1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = CShort(13) Then
            If Not IsNumeric(Text1.Text) Then
                MsgBox("Nombre non valide !", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation, "Message")
            Else
                Command2_Click(Command2, New System.EventArgs())
            End If
        End If
        If KeyAscii = CShort(0) Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub Text1_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles Text1.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        If Not IsNumeric(Text1.Text) Then MsgBox("Nombre non valide !", MsgBoxStyle.OkOnly And MsgBoxStyle.Exclamation, "Message")
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub OptionCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Option4.CheckedChanged, Option8.CheckedChanged
        If Option4.Checked = True Then
            Option2.Visible = False
            Option1.Visible = True
            Option1.Checked = True
        End If

        If Option8.Checked = True Then
            Option1.Visible = True
            Option2.Visible = True
            Option1.Checked = True
        End If
    End Sub

    Private Sub frmAxe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
