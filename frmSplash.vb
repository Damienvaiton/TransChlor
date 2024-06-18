Public Class frmSplash : Inherits System.Windows.Forms.Form

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
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents lblCopyright As System.Windows.Forms.Label
    Public WithEvents lblCompany As System.Windows.Forms.Label
    Public WithEvents lblWarning As System.Windows.Forms.Label
    Public WithEvents lblVersion As System.Windows.Forms.Label
    Public WithEvents lblPlatform As System.Windows.Forms.Label
    Public WithEvents lblProductName As System.Windows.Forms.Label
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblPlatform = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Controls.Add(Me.PictureBox1)
        Me.Frame1.Controls.Add(Me.lblCopyright)
        Me.Frame1.Controls.Add(Me.lblCompany)
        Me.Frame1.Controls.Add(Me.lblWarning)
        Me.Frame1.Controls.Add(Me.lblVersion)
        Me.Frame1.Controls.Add(Me.lblPlatform)
        Me.Frame1.Controls.Add(Me.lblProductName)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(736, 528)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 480)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(520, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "ORGANIZATION(S) THAT PREPARED THIS REPORT:"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 424)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(720, 48)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 352)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(720, 64)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 304)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(720, 40)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 280)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(520, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "DISCLAIMER OF WARRANTIES AND LIMITATION OF LIABILITIES"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(248, 232)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'lblCopyright
        '
        Me.lblCopyright.BackColor = System.Drawing.SystemColors.Control
        Me.lblCopyright.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCopyright.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCopyright.Location = New System.Drawing.Point(360, 200)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCopyright.Size = New System.Drawing.Size(120, 17)
        Me.lblCopyright.TabIndex = 3
        Me.lblCopyright.Text = "Copyright  1998-2020"
        '
        'lblCompany
        '
        Me.lblCompany.BackColor = System.Drawing.SystemColors.Control
        Me.lblCompany.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCompany.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCompany.Location = New System.Drawing.Point(360, 224)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCompany.Size = New System.Drawing.Size(222, 17)
        Me.lblCompany.TabIndex = 2
        Me.lblCompany.Text = "Laval University && EPFL"
        '
        'lblWarning
        '
        Me.lblWarning.BackColor = System.Drawing.SystemColors.Control
        Me.lblWarning.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWarning.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWarning.Location = New System.Drawing.Point(8, 256)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWarning.Size = New System.Drawing.Size(457, 13)
        Me.lblWarning.TabIndex = 1
        Me.lblWarning.Text = "Warning:        The use of this computer program is protected by international la" &
    "ws !"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersion.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVersion.Location = New System.Drawing.Point(352, 112)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVersion.Size = New System.Drawing.Size(106, 19)
        Me.lblVersion.TabIndex = 4
        Me.lblVersion.Text = "Version 1.0.0"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPlatform
        '
        Me.lblPlatform.AutoSize = True
        Me.lblPlatform.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlatform.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlatform.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlatform.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlatform.Location = New System.Drawing.Point(352, 80)
        Me.lblPlatform.Name = "lblPlatform"
        Me.lblPlatform.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlatform.Size = New System.Drawing.Size(230, 24)
        Me.lblPlatform.TabIndex = 5
        Me.lblPlatform.Text = "Visual Basic .net 2019"
        Me.lblPlatform.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.BackColor = System.Drawing.SystemColors.Control
        Me.lblProductName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProductName.Font = New System.Drawing.Font("Arial", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProductName.Location = New System.Drawing.Point(304, 16)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProductName.Size = New System.Drawing.Size(379, 51)
        Me.lblProductName.TabIndex = 6
        Me.lblProductName.Text = "TransChlor Alpha"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 504)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(520, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "MCS-IS-ENAC-EPFL"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'frmSplash
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(746, 543)
        Me.ControlBox = False
        Me.Controls.Add(Me.Frame1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplash"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fenêtre d'ouverture"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Lors de l'ouverture de la fenêtre
    Public Sub frmSplash_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        lblVersion.Text = "Version " & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." '& App.Revision
        lblProductName.Text = "TransChlor Alpha"

    End Sub

    'Lorsqu'une touche est frappée
    Public Sub frmSplash_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Close()
    End Sub

    'Lorsqu'un clik est effectué sur la fenêtre
    'Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Click, Frame1.Click, Timer1.Tick
    '    Close()
    'End Sub

    'Gestion de la fenêtre
    Private Sub Run()
        Timer1.Enabled = False
        Me.Close()
    End Sub

End Class
