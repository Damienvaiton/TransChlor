Public Class frmGraph1D : Inherits System.Windows.Forms.Form

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
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(855, 400)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(89, 25)
        Me.Command1.TabIndex = 19
        Me.Command1.Text = "Store"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(642, 216)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(300, 178)
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(336, 32)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(300, 178)
        Me.PictureBox2.TabIndex = 21
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.White
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(644, 32)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(300, 178)
        Me.PictureBox3.TabIndex = 22
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.White
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Location = New System.Drawing.Point(30, 32)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(300, 178)
        Me.PictureBox4.TabIndex = 23
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.White
        Me.PictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox5.Location = New System.Drawing.Point(30, 216)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(300, 178)
        Me.PictureBox5.TabIndex = 24
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.White
        Me.PictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox6.Location = New System.Drawing.Point(336, 216)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(300, 178)
        Me.PictureBox6.TabIndex = 25
        Me.PictureBox6.TabStop = False
        '
        'frmGraph1D
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(984, 436)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.PictureBox6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmGraph1D"
        Me.Text = "Transport 1D"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim a As Single
    Dim Picture_Number As Short = 0

    'lors du chargement de la fenêtre
    Private Sub frmChlor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        a = Me.Width / 34
        Dim x As Short = a
        Dim y As Short = 18 * a
        Me.Command1.Location = New System.Drawing.Point(x, y)

    End Sub

    'dessin des graphiques durant l'exécution du calcul
    Public Sub design(ByRef wsat As Single, ByRef H_old() As Decimal, ByRef W() As Decimal, ByRef T_old() As Decimal, ByRef C_new() As Decimal, ByRef CT() As Decimal, ByRef tempmin As Single, ByRef tempmax As Single, ByRef Length As Single, ByRef PosProf() As Decimal, ByRef hMin As Single, ByRef hEcart As Single, ByRef wMin As Single, ByRef wEcart As Single, ByRef CTmin As Single, ByRef CTecart As Single, ByRef CTmax As Integer, ByRef CLmin As Single, ByRef CLecart As Single, ByRef CLmax As Integer, ByRef Tecart As Single, ByRef Dofs As Short, ByRef Tijd As Decimal, ByRef Gxc As Single, ByRef Dxc As Single, ByRef Ph() As Decimal)
        ' Get a Graphics object from the current form and clear its background.
        Dim x1 As Single
        Dim x2 As Single
        Dim h1 As Single
        Dim h2 As Single
        Dim i As Short
        Dim EctX As Single
        Dim EctY As Single
        Dim Tmax As Single
        Dim m_Longueur As Single
        Dim m_Hauteur As Single

        Dim position As Point
        Dim couleur As Color
        Dim Message0 As String
        Dim Message1 As String
        Dim Message2 As String
        Dim Message3 As String

        a = Me.Width / 34

        ''''''''''''''''''''''''''''''''''''
        ' Construction du premier graphique
        ''''''''''''''''''''''''''''''''''''
        position = New Point(a, a)
        m_Longueur = a * 10             'ne change pas pour les autres graphiques
        m_Hauteur = a * 7.5             'ne change pas pour les autres graphiques

        couleur = System.Drawing.Color.Red
        Message0 = ""                       'ne change pas pour les autres graphiques
        Message1 = "Temperature Potential [°C]"
        Message2 = "Depth [mm]"             'ne change pas pour les autres grapiques
        Message3 = "Temperature Potential Distribution at " & Format(Tijd, "0.00") & " Days"
        x1 = 0                              'ne change pas pour les autres graphiques
        x2 = Length                         'ne change pas pour les autres graphiques
        h1 = (Int(tempmin / 10)) * 10
        If Int(tempmax / 10) - tempmax / 10 = 0 Then
            Tmax = tempmax
        Else
            Tmax = (Int(tempmax / 10) + 1) * 10
        End If
        h2 = Tmax
        EctX = Int(Length / 10)             'ne change pas pour les autres graphiques
        EctY = Tecart
        'Dim gr01 As CGraph = New CGraph(Me, PictureBox1, position, m_Longueur, m_Hauteur, couleur, Message0, Message1, Message2, Message3, x1, x2, h1, h2, EctX, EctY, PosProf, T_old, Dofs, -1, -1)
        PlotGraph1(position, m_Longueur, m_Hauteur, couleur, Message0, Message1, Message2, Message3, x1, x2, h1, h2, EctX, EctY, PosProf, T_old, Dofs, -1, -1)
        ''''''''''''''''''''''''''''''''''''
        ' Construction du deuxième graphique
        ''''''''''''''''''''''''''''''''''''
        position = New Point(12 * a, a)
        couleur = System.Drawing.Color.BlueViolet
        Message1 = "Moisture Potential [P/Ps]"
        Message3 = "Moisture Potential Distribution at " & Format(Tijd, "0.00") & " Days"
        h1 = hMin
        h2 = 1
        EctY = 0.1
        'Dim gr02 As CGraph = New CGraph(Me, PictureBox2, position, m_Longueur, m_Hauteur, couleur, Message0, Message1, Message2, Message3, x1, x2, h1, h2, EctX, EctY, PosProf, H_old, Dofs, -1, -1)
        PlotGraph2(position, m_Longueur, m_Hauteur, couleur, Message0, Message1, Message2, Message3, x1, x2, h1, h2, EctX, EctY, PosProf, H_old, Dofs, -1, -1)

        ''''''''''''''''''''''''''''''''''''
        ' Construction du troisième graphique
        ''''''''''''''''''''''''''''''''''''
        position = New Point(12 * a, 10 * a)
        couleur = System.Drawing.Color.Blue
        Message1 = "Moisture Content [kg/m3]"
        Message3 = "Moisture Content Distribution at " & Format(Tijd, "0.00") & " Days"
        h1 = wMin
        i = CShort(wsat / 10.0#)
        If wsat > CSng(i) * CSng(10) Then
            i = i + CShort(1)
        End If
        h2 = i * 10
        EctY = wEcart
        'Dim gr03 As CGraph = New CGraph(Me, PictureBox3, position, m_Longueur, m_Hauteur, couleur, Message0, Message1, Message2, Message3, x1, x2, h1, h2, EctX, EctY, PosProf, W, Dofs, -1, -1)
        PlotGraph3(position, m_Longueur, m_Hauteur, couleur, Message0, Message1, Message2, Message3, x1, x2, h1, h2, EctX, EctY, PosProf, W, Dofs, -1, -1)

        ''''''''''''''''''''''''''''''''''''
        ' Construction du quatrième graphique
        ''''''''''''''''''''''''''''''''''''
        position = New Point(23 * a, a)
        couleur = System.Drawing.Color.GreenYellow
        Message1 = "Total Chloride Ion Content [kg/m3]"
        Message3 = "Total Chloride Ion Distribution at " & Format(Tijd, "0.00") & " Days"
        h1 = CTmin
        h2 = CTmax
        If (h2 - h1) / CTecart > 14 Or (h2 - h1) / CTecart < 2 Then
            EctY = (h2 - h1) / 10
        Else
            EctY = CTecart
        End If
        'Dim gr04 As CGraph = New CGraph(Me, PictureBox4, position, m_Longueur, m_Hauteur, couleur, Message0, Message1, Message2, Message3, x1, x2, h1, h2, EctX, EctY, PosProf, CT, Dofs, -1, -1)
        PlotGraph4(position, m_Longueur, m_Hauteur, couleur, Message0, Message1, Message2, Message3, x1, x2, h1, h2, EctX, EctY, PosProf, CT, Dofs, -1, -1)

        ''''''''''''''''''''''''''''''''''''
        ' Construction du cinquième graphique
        ''''''''''''''''''''''''''''''''''''
        position = New Point(23 * a, 10 * a)
        couleur = System.Drawing.Color.Green
        Message1 = "Free Chloride Ion Content [kg/m3]"
        Message3 = "Free Chloride Ion Distribution at " & Format(Tijd, "0.00") & " Days"
        h1 = CLmin
        h2 = CLmax
        If (h2 - h1) / CLecart > 14 Or (h2 - h1) / CLecart < 2 Then
            EctY = (h2 - h1) / 10
        Else
            EctY = CLecart
        End If
        Dim DTot(Dofs) As Decimal
        For i = 1 To Dofs
            DTot(i) = C_new(i) * W(i) / 1000.0#
        Next i
        'Dim gr05 As CGraph = New CGraph(Me, PictureBox5, position, m_Longueur, m_Hauteur, couleur, Message0, Message1, Message2, Message3, x1, x2, h1, h2, EctX, EctY, PosProf, DTot, Dofs, -1, -1)
        PlotGraph5(position, m_Longueur, m_Hauteur, couleur, Message0, Message1, Message2, Message3, x1, x2, h1, h2, EctX, EctY, PosProf, DTot, Dofs, -1, -1)

        ''''''''''''''''''''''''''''''''''''
        ' Constuction du sixième graphique
        ''''''''''''''''''''''''''''''''''''
        position = New Point(a, 10 * a)

        couleur = System.Drawing.Color.DarkCyan
        Message1 = "PH"
        Message3 = "PH Distribution at " & Format(Tijd, "0.00") & " Days"
        h1 = 0
        h2 = 14
        EctY = 1
        'Dim gr06 As CGraph = New CGraph(Me, PictureBox6, position, m_Longueur, m_Hauteur, couleur, Message0, Message1, Message2, Message3, x1, x2, h1, h2, EctX, EctY, PosProf, Ph, Dofs, Gxc, Dxc)
        PlotGraph6(position, m_Longueur, m_Hauteur, couleur, Message0, Message1, Message2, Message3, x1, x2, h1, h2, EctX, EctY, PosProf, Ph, Dofs, Gxc, Dxc)

    End Sub

    'Click sur le bouton store
    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click

        Picture_Number = Picture_Number + 1

        Dim outfile As String

        outfile = MDIChlor.Prefile & "Graph_1_" & Convert.ToString(Picture_Number) & ".bmp"
        PictureBox1.Image.Save(outfile)
        outfile = MDIChlor.Prefile & "Graph_2_" & Convert.ToString(Picture_Number) & ".bmp"
        PictureBox2.Image.Save(outfile)
        outfile = MDIChlor.Prefile & "Graph_3_" & Convert.ToString(Picture_Number) & ".bmp"
        PictureBox3.Image.Save(outfile)
        outfile = MDIChlor.Prefile & "Graph_4_" & Convert.ToString(Picture_Number) & ".bmp"
        PictureBox4.Image.Save(outfile)
        outfile = MDIChlor.Prefile & "Graph_5_" & Convert.ToString(Picture_Number) & ".bmp"
        PictureBox5.Image.Save(outfile)
        outfile = MDIChlor.Prefile & "Graph_6_" & Convert.ToString(Picture_Number) & ".bmp"
        PictureBox6.Image.Save(outfile)

    End Sub

    Public Sub ModifyTitle(ByVal Title As String)
        Invoke(Sub() Me.Text = Title)
    End Sub

    Public Sub PlotGraph1(ByVal position As Point, ByVal m_Longueur As Single, ByVal m_Hauteur As Single, ByVal couleur As Color, ByVal message0 As String, ByVal message1 As String, ByVal message2 As String, ByVal message3 As String, ByVal x1 As Single, ByVal x2 As Single, ByVal h1 As Single, ByVal h2 As Single, ByVal EctX As Single, ByVal EctY As Single, ByRef PosProf() As Decimal, ByRef Result() As Decimal, ByVal Dofs As Short, ByRef Gxc As Single, ByRef Dxc As Single)
        Dim m_Image As Bitmap
        Dim m_Position As Point
        Dim m_Gr As Graphics
        Dim m_Pen As Pen
        Const m_Epaisseur As Integer = 4

        Dim m_X1 As Single
        Dim m_X2 As Single
        Dim m_Y2 As Single
        Dim m_Y1 As Single

        Dim i As Short
        Dim x As Single
        Dim y As Single
        Dim msg As String

        Dim m_Facteur As Single

        Try
            m_Facteur = Me.Width / 34

            Me.Invoke(Sub()
                          PictureBox1.Width = m_Longueur
                          PictureBox1.Height = m_Hauteur
                          PictureBox1.Location = position
                      End Sub)

            'pcBox.Width = m_Longueur
            'pcBox.Height = m_Hauteur
            'pcBox.Location = position

            m_Image = New Bitmap(PictureBox1.Width, PictureBox1.Height)
            m_Gr = Graphics.FromImage(m_Image)
            m_Pen = New Pen(couleur, m_Epaisseur)

            m_X1 = m_Facteur
            m_Y1 = PictureBox1.Height - m_Facteur * 1.5
            m_X2 = PictureBox1.Width - 0.5 * m_Facteur
            m_Y2 = m_Facteur

            Dim sh As Single = (m_Y1 - m_Y2) / (h2 - h1)
            Dim ih As Integer = CInt((h2 - h1) / EctY)

            Dim sx As Single = (m_X2 - m_X1) / (x2 - x1)
            Dim ix As Integer = CInt((x2 - x1) / EctX)

            'Construction des lignes d'axes
            Dim H8ft As Single = 0.2118 * CSng(m_Facteur)
            Dim H10ft As Single = 0.2648 * CSng(m_Facteur)
            Dim H12ft As Single = 0.3178 * CSng(m_Facteur)
            Dim fnt8Arial As New Font("Arial", H8ft)
            Dim fnt10Arial As New Font("Arial", H10ft)
            Dim fnt12Arial As New Font("Arial", H12ft)
            Dim pen01 As New Drawing.Pen(System.Drawing.Color.Gray, 1)
            Dim Drawformat0 As New StringFormat
            Dim Drawformat1 As New StringFormat
            Dim Drawformat2 As New StringFormat
            Drawformat0.Alignment = StringAlignment.Near
            Drawformat1.Alignment = StringAlignment.Far
            Drawformat2.Alignment = StringAlignment.Center

            Dim drawPoint04 As New PointF(5 * m_Facteur, 0)
            m_Gr.DrawString(message0, fnt12Arial, Brushes.Black, drawPoint04, Drawformat2)

            Dim drawPoint01 As New PointF(m_X1 - m_Facteur / 6, m_Y2 - 0.5 * m_Facteur)
            m_Gr.DrawString(message1, fnt10Arial, Brushes.Black, drawPoint01, Drawformat0)

            Dim drawPoint03 As New PointF(m_X2, m_Y1 + 0.3 * m_Facteur)
            m_Gr.DrawString(message2, fnt10Arial, Brushes.Black, drawPoint03, Drawformat1)

            Dim drawPoint00 As New PointF(m_Facteur * 5, PictureBox1.Height - 2 * H12ft)
            m_Gr.DrawString(message3, fnt12Arial, Brushes.Black, drawPoint00, Drawformat2)

            For i = 0 To ih
                y = m_Y1 - i * sh * EctY
                Dim drawPoint As New PointF(m_X1, y - 0.5 * H8ft)
                ' Create a Pen object
                m_Gr.DrawLine(pen01, m_X1, y, m_X2, y)
                msg = Format(h1 + CSng(i) * EctY, "0.00")
                m_Gr.DrawString(msg, fnt8Arial, Brushes.Black, drawPoint, Drawformat1)
            Next i

            For i = 0 To ix
                x = m_X1 + i * EctX * sx
                ' Create a Pen object.
                Dim drawPoint02 As New PointF(x, m_Y1)
                m_Gr.DrawLine(pen01, x, m_Y1, x, m_Y2)
                msg = i * EctX + x1
                m_Gr.DrawString(msg, fnt8Arial, Brushes.Black, drawPoint02, Drawformat2)
            Next i

            'dessin des résultats
            Dim x_old As Single
            Dim y_old As Single

            y = m_Y1 - sh * (Result(1) - h1)
            m_Gr.DrawLine(m_Pen, m_X1, y, m_X1, y)
            x_old = m_X1
            y_old = y
            For i = 2 To Dofs
                y = m_Y1 - sh * (Result(i) - h1)
                x = m_X1 + sx * PosProf(i)
                m_Gr.DrawLine(m_Pen, x_old, y_old, x, y)
                x_old = x
                y_old = y
            Next i
            If Gxc >= 0 And Dxc >= 0 Then       'dessin des positions de xc pour la carbonatation
                m_Pen = New Pen(System.Drawing.Color.Cyan, m_Epaisseur)
                m_Gr.DrawLine(m_Pen, m_X1 + sx * Gxc, m_Y1 - sh * (h1 - h1), m_X1 + sx * Gxc, m_Y1 - sh * (h2 - h1))
                m_Gr.DrawLine(m_Pen, m_X1 + sx * (PosProf(Dofs) - Dxc), m_Y1 - sh * (h1 - h1), m_X1 + sx * (PosProf(Dofs) - Dxc), m_Y1 - sh * (h2 - h1))
            End If
        Catch e As Exception
        End Try
        PictureBox1.Image = m_Image
    End Sub

    Public Sub PlotGraph2(ByVal position As Point, ByVal m_Longueur As Single, ByVal m_Hauteur As Single, ByVal couleur As Color, ByVal message0 As String, ByVal message1 As String, ByVal message2 As String, ByVal message3 As String, ByVal x1 As Single, ByVal x2 As Single, ByVal h1 As Single, ByVal h2 As Single, ByVal EctX As Single, ByVal EctY As Single, ByRef PosProf() As Decimal, ByRef Result() As Decimal, ByVal Dofs As Short, ByRef Gxc As Single, ByRef Dxc As Single)
        Dim m_Image As Bitmap
        Dim m_Position As Point
        Dim m_Gr As Graphics
        Dim m_Pen As Pen
        Const m_Epaisseur As Integer = 4

        Dim m_X1 As Single
        Dim m_X2 As Single
        Dim m_Y2 As Single
        Dim m_Y1 As Single

        Dim i As Short
        Dim x As Single
        Dim y As Single
        Dim msg As String

        Dim m_Facteur As Single

        Try
            m_Facteur = Me.Width / 34

            Me.Invoke(Sub()
                          PictureBox2.Width = m_Longueur
                          PictureBox2.Height = m_Hauteur
                          PictureBox2.Location = position
                      End Sub)

            'pcBox.Width = m_Longueur
            'pcBox.Height = m_Hauteur
            'pcBox.Location = position

            m_Image = New Bitmap(PictureBox2.Width, PictureBox2.Height)
            m_Gr = Graphics.FromImage(m_Image)
            m_Pen = New Pen(couleur, m_Epaisseur)

            m_X1 = m_Facteur
            m_Y1 = PictureBox2.Height - m_Facteur * 1.5
            m_X2 = PictureBox2.Width - 0.5 * m_Facteur
            m_Y2 = m_Facteur

            Dim sh As Single = (m_Y1 - m_Y2) / (h2 - h1)
            Dim ih As Integer = CInt((h2 - h1) / EctY)

            Dim sx As Single = (m_X2 - m_X1) / (x2 - x1)
            Dim ix As Integer = CInt((x2 - x1) / EctX)

            'Construction des lignes d'axes
            Dim H8ft As Single = 0.2118 * CSng(m_Facteur)
            Dim H10ft As Single = 0.2648 * CSng(m_Facteur)
            Dim H12ft As Single = 0.3178 * CSng(m_Facteur)
            Dim fnt8Arial As New Font("Arial", H8ft)
            Dim fnt10Arial As New Font("Arial", H10ft)
            Dim fnt12Arial As New Font("Arial", H12ft)
            Dim pen01 As New Drawing.Pen(System.Drawing.Color.Gray, 1)
            Dim Drawformat0 As New StringFormat
            Dim Drawformat1 As New StringFormat
            Dim Drawformat2 As New StringFormat
            Drawformat0.Alignment = StringAlignment.Near
            Drawformat1.Alignment = StringAlignment.Far
            Drawformat2.Alignment = StringAlignment.Center

            Dim drawPoint04 As New PointF(5 * m_Facteur, 0)
            m_Gr.DrawString(message0, fnt12Arial, Brushes.Black, drawPoint04, Drawformat2)

            Dim drawPoint01 As New PointF(m_X1 - m_Facteur / 6, m_Y2 - 0.5 * m_Facteur)
            m_Gr.DrawString(message1, fnt10Arial, Brushes.Black, drawPoint01, Drawformat0)

            Dim drawPoint03 As New PointF(m_X2, m_Y1 + 0.3 * m_Facteur)
            m_Gr.DrawString(message2, fnt10Arial, Brushes.Black, drawPoint03, Drawformat1)

            Dim drawPoint00 As New PointF(m_Facteur * 5, PictureBox2.Height - 2 * H12ft)
            m_Gr.DrawString(message3, fnt12Arial, Brushes.Black, drawPoint00, Drawformat2)

            For i = 0 To ih
                y = m_Y1 - i * sh * EctY
                Dim drawPoint As New PointF(m_X1, y - 0.5 * H8ft)
                ' Create a Pen object
                m_Gr.DrawLine(pen01, m_X1, y, m_X2, y)
                msg = Format(h1 + CSng(i) * EctY, "0.00")
                m_Gr.DrawString(msg, fnt8Arial, Brushes.Black, drawPoint, Drawformat1)
            Next i

            For i = 0 To ix
                x = m_X1 + i * EctX * sx
                ' Create a Pen object.
                Dim drawPoint02 As New PointF(x, m_Y1)
                m_Gr.DrawLine(pen01, x, m_Y1, x, m_Y2)
                msg = i * EctX + x1
                m_Gr.DrawString(msg, fnt8Arial, Brushes.Black, drawPoint02, Drawformat2)
            Next i

            'dessin des résultats
            Dim x_old As Single
            Dim y_old As Single

            y = m_Y1 - sh * (Result(1) - h1)
            m_Gr.DrawLine(m_Pen, m_X1, y, m_X1, y)
            x_old = m_X1
            y_old = y
            For i = 2 To Dofs
                y = m_Y1 - sh * (Result(i) - h1)
                x = m_X1 + sx * PosProf(i)
                m_Gr.DrawLine(m_Pen, x_old, y_old, x, y)
                x_old = x
                y_old = y
            Next i
            If Gxc >= 0 And Dxc >= 0 Then       'dessin des positions de xc pour la carbonatation
                m_Pen = New Pen(System.Drawing.Color.Cyan, m_Epaisseur)
                m_Gr.DrawLine(m_Pen, m_X1 + sx * Gxc, m_Y1 - sh * (h1 - h1), m_X1 + sx * Gxc, m_Y1 - sh * (h2 - h1))
                m_Gr.DrawLine(m_Pen, m_X1 + sx * (PosProf(Dofs) - Dxc), m_Y1 - sh * (h1 - h1), m_X1 + sx * (PosProf(Dofs) - Dxc), m_Y1 - sh * (h2 - h1))
            End If
        Catch e As Exception
        End Try
        PictureBox2.Image = m_Image
    End Sub

    Public Sub PlotGraph3(ByVal position As Point, ByVal m_Longueur As Single, ByVal m_Hauteur As Single, ByVal couleur As Color, ByVal message0 As String, ByVal message1 As String, ByVal message2 As String, ByVal message3 As String, ByVal x1 As Single, ByVal x2 As Single, ByVal h1 As Single, ByVal h2 As Single, ByVal EctX As Single, ByVal EctY As Single, ByRef PosProf() As Decimal, ByRef Result() As Decimal, ByVal Dofs As Short, ByRef Gxc As Single, ByRef Dxc As Single)
        Dim m_Image As Bitmap
        Dim m_Position As Point
        Dim m_Gr As Graphics
        Dim m_Pen As Pen
        Const m_Epaisseur As Integer = 4

        Dim m_X1 As Single
        Dim m_X2 As Single
        Dim m_Y2 As Single
        Dim m_Y1 As Single

        Dim i As Short
        Dim x As Single
        Dim y As Single
        Dim msg As String

        Dim m_Facteur As Single

        Try
            m_Facteur = Me.Width / 34

            Me.Invoke(Sub()
                          PictureBox3.Width = m_Longueur
                          PictureBox3.Height = m_Hauteur
                          PictureBox3.Location = position
                      End Sub)

            'pcBox.Width = m_Longueur
            'pcBox.Height = m_Hauteur
            'pcBox.Location = position

            m_Image = New Bitmap(PictureBox3.Width, PictureBox3.Height)
            m_Gr = Graphics.FromImage(m_Image)
            m_Pen = New Pen(couleur, m_Epaisseur)

            m_X1 = m_Facteur
            m_Y1 = PictureBox3.Height - m_Facteur * 1.5
            m_X2 = PictureBox3.Width - 0.5 * m_Facteur
            m_Y2 = m_Facteur

            Dim sh As Single = (m_Y1 - m_Y2) / (h2 - h1)
            Dim ih As Integer = CInt((h2 - h1) / EctY)

            Dim sx As Single = (m_X2 - m_X1) / (x2 - x1)
            Dim ix As Integer = CInt((x2 - x1) / EctX)

            'Construction des lignes d'axes
            Dim H8ft As Single = 0.2118 * CSng(m_Facteur)
            Dim H10ft As Single = 0.2648 * CSng(m_Facteur)
            Dim H12ft As Single = 0.3178 * CSng(m_Facteur)
            Dim fnt8Arial As New Font("Arial", H8ft)
            Dim fnt10Arial As New Font("Arial", H10ft)
            Dim fnt12Arial As New Font("Arial", H12ft)
            Dim pen01 As New Drawing.Pen(System.Drawing.Color.Gray, 1)
            Dim Drawformat0 As New StringFormat
            Dim Drawformat1 As New StringFormat
            Dim Drawformat2 As New StringFormat
            Drawformat0.Alignment = StringAlignment.Near
            Drawformat1.Alignment = StringAlignment.Far
            Drawformat2.Alignment = StringAlignment.Center

            Dim drawPoint04 As New PointF(5 * m_Facteur, 0)
            m_Gr.DrawString(message0, fnt12Arial, Brushes.Black, drawPoint04, Drawformat2)

            Dim drawPoint01 As New PointF(m_X1 - m_Facteur / 6, m_Y2 - 0.5 * m_Facteur)
            m_Gr.DrawString(message1, fnt10Arial, Brushes.Black, drawPoint01, Drawformat0)

            Dim drawPoint03 As New PointF(m_X2, m_Y1 + 0.3 * m_Facteur)
            m_Gr.DrawString(message2, fnt10Arial, Brushes.Black, drawPoint03, Drawformat1)

            Dim drawPoint00 As New PointF(m_Facteur * 5, PictureBox3.Height - 2 * H12ft)
            m_Gr.DrawString(message3, fnt12Arial, Brushes.Black, drawPoint00, Drawformat2)

            For i = 0 To ih
                y = m_Y1 - i * sh * EctY
                Dim drawPoint As New PointF(m_X1, y - 0.5 * H8ft)
                ' Create a Pen object
                m_Gr.DrawLine(pen01, m_X1, y, m_X2, y)
                msg = Format(h1 + CSng(i) * EctY, "0.00")
                m_Gr.DrawString(msg, fnt8Arial, Brushes.Black, drawPoint, Drawformat1)
            Next i

            For i = 0 To ix
                x = m_X1 + i * EctX * sx
                ' Create a Pen object.
                Dim drawPoint02 As New PointF(x, m_Y1)
                m_Gr.DrawLine(pen01, x, m_Y1, x, m_Y2)
                msg = i * EctX + x1
                m_Gr.DrawString(msg, fnt8Arial, Brushes.Black, drawPoint02, Drawformat2)
            Next i

            'dessin des résultats
            Dim x_old As Single
            Dim y_old As Single

            y = m_Y1 - sh * (Result(1) - h1)
            m_Gr.DrawLine(m_Pen, m_X1, y, m_X1, y)
            x_old = m_X1
            y_old = y
            For i = 2 To Dofs
                y = m_Y1 - sh * (Result(i) - h1)
                x = m_X1 + sx * PosProf(i)
                m_Gr.DrawLine(m_Pen, x_old, y_old, x, y)
                x_old = x
                y_old = y
            Next i
            If Gxc >= 0 And Dxc >= 0 Then       'dessin des positions de xc pour la carbonatation
                m_Pen = New Pen(System.Drawing.Color.Cyan, m_Epaisseur)
                m_Gr.DrawLine(m_Pen, m_X1 + sx * Gxc, m_Y1 - sh * (h1 - h1), m_X1 + sx * Gxc, m_Y1 - sh * (h2 - h1))
                m_Gr.DrawLine(m_Pen, m_X1 + sx * (PosProf(Dofs) - Dxc), m_Y1 - sh * (h1 - h1), m_X1 + sx * (PosProf(Dofs) - Dxc), m_Y1 - sh * (h2 - h1))
            End If
        Catch e As Exception
        End Try
        PictureBox3.Image = m_Image
    End Sub

    Public Sub PlotGraph4(ByVal position As Point, ByVal m_Longueur As Single, ByVal m_Hauteur As Single, ByVal couleur As Color, ByVal message0 As String, ByVal message1 As String, ByVal message2 As String, ByVal message3 As String, ByVal x1 As Single, ByVal x2 As Single, ByVal h1 As Single, ByVal h2 As Single, ByVal EctX As Single, ByVal EctY As Single, ByRef PosProf() As Decimal, ByRef Result() As Decimal, ByVal Dofs As Short, ByRef Gxc As Single, ByRef Dxc As Single)
        Dim m_Image As Bitmap
        Dim m_Position As Point
        Dim m_Gr As Graphics
        Dim m_Pen As Pen
        Const m_Epaisseur As Integer = 4

        Dim m_X1 As Single
        Dim m_X2 As Single
        Dim m_Y2 As Single
        Dim m_Y1 As Single

        Dim i As Short
        Dim x As Single
        Dim y As Single
        Dim msg As String

        Dim m_Facteur As Single

        Try
            m_Facteur = Me.Width / 34

            Me.Invoke(Sub()
                          PictureBox4.Width = m_Longueur
                          PictureBox4.Height = m_Hauteur
                          PictureBox4.Location = position
                      End Sub)

            'pcBox.Width = m_Longueur
            'pcBox.Height = m_Hauteur
            'pcBox.Location = position

            m_Image = New Bitmap(PictureBox4.Width, PictureBox4.Height)
            m_Gr = Graphics.FromImage(m_Image)
            m_Pen = New Pen(couleur, m_Epaisseur)

            m_X1 = m_Facteur
            m_Y1 = PictureBox4.Height - m_Facteur * 1.5
            m_X2 = PictureBox4.Width - 0.5 * m_Facteur
            m_Y2 = m_Facteur

            Dim sh As Single = (m_Y1 - m_Y2) / (h2 - h1)
            Dim ih As Integer = CInt((h2 - h1) / EctY)

            Dim sx As Single = (m_X2 - m_X1) / (x2 - x1)
            Dim ix As Integer = CInt((x2 - x1) / EctX)

            'Construction des lignes d'axes
            Dim H8ft As Single = 0.2118 * CSng(m_Facteur)
            Dim H10ft As Single = 0.2648 * CSng(m_Facteur)
            Dim H12ft As Single = 0.3178 * CSng(m_Facteur)
            Dim fnt8Arial As New Font("Arial", H8ft)
            Dim fnt10Arial As New Font("Arial", H10ft)
            Dim fnt12Arial As New Font("Arial", H12ft)
            Dim pen01 As New Drawing.Pen(System.Drawing.Color.Gray, 1)
            Dim Drawformat0 As New StringFormat
            Dim Drawformat1 As New StringFormat
            Dim Drawformat2 As New StringFormat
            Drawformat0.Alignment = StringAlignment.Near
            Drawformat1.Alignment = StringAlignment.Far
            Drawformat2.Alignment = StringAlignment.Center

            Dim drawPoint04 As New PointF(5 * m_Facteur, 0)
            m_Gr.DrawString(message0, fnt12Arial, Brushes.Black, drawPoint04, Drawformat2)

            Dim drawPoint01 As New PointF(m_X1 - m_Facteur / 6, m_Y2 - 0.5 * m_Facteur)
            m_Gr.DrawString(message1, fnt10Arial, Brushes.Black, drawPoint01, Drawformat0)

            Dim drawPoint03 As New PointF(m_X2, m_Y1 + 0.3 * m_Facteur)
            m_Gr.DrawString(message2, fnt10Arial, Brushes.Black, drawPoint03, Drawformat1)

            Dim drawPoint00 As New PointF(m_Facteur * 5, PictureBox4.Height - 2 * H12ft)
            m_Gr.DrawString(message3, fnt12Arial, Brushes.Black, drawPoint00, Drawformat2)

            For i = 0 To ih
                y = m_Y1 - i * sh * EctY
                Dim drawPoint As New PointF(m_X1, y - 0.5 * H8ft)
                ' Create a Pen object
                m_Gr.DrawLine(pen01, m_X1, y, m_X2, y)
                msg = Format(h1 + CSng(i) * EctY, "0.00")
                m_Gr.DrawString(msg, fnt8Arial, Brushes.Black, drawPoint, Drawformat1)
            Next i

            For i = 0 To ix
                x = m_X1 + i * EctX * sx
                ' Create a Pen object.
                Dim drawPoint02 As New PointF(x, m_Y1)
                m_Gr.DrawLine(pen01, x, m_Y1, x, m_Y2)
                msg = i * EctX + x1
                m_Gr.DrawString(msg, fnt8Arial, Brushes.Black, drawPoint02, Drawformat2)
            Next i

            'dessin des résultats
            Dim x_old As Single
            Dim y_old As Single

            y = m_Y1 - sh * (Result(1) - h1)
            m_Gr.DrawLine(m_Pen, m_X1, y, m_X1, y)
            x_old = m_X1
            y_old = y
            For i = 2 To Dofs
                y = m_Y1 - sh * (Result(i) - h1)
                x = m_X1 + sx * PosProf(i)
                m_Gr.DrawLine(m_Pen, x_old, y_old, x, y)
                x_old = x
                y_old = y
            Next i
            If Gxc >= 0 And Dxc >= 0 Then       'dessin des positions de xc pour la carbonatation
                m_Pen = New Pen(System.Drawing.Color.Cyan, m_Epaisseur)
                m_Gr.DrawLine(m_Pen, m_X1 + sx * Gxc, m_Y1 - sh * (h1 - h1), m_X1 + sx * Gxc, m_Y1 - sh * (h2 - h1))
                m_Gr.DrawLine(m_Pen, m_X1 + sx * (PosProf(Dofs) - Dxc), m_Y1 - sh * (h1 - h1), m_X1 + sx * (PosProf(Dofs) - Dxc), m_Y1 - sh * (h2 - h1))
            End If
        Catch e As Exception
        End Try
        PictureBox4.Image = m_Image
    End Sub

    Public Sub PlotGraph5(ByVal position As Point, ByVal m_Longueur As Single, ByVal m_Hauteur As Single, ByVal couleur As Color, ByVal message0 As String, ByVal message1 As String, ByVal message2 As String, ByVal message3 As String, ByVal x1 As Single, ByVal x2 As Single, ByVal h1 As Single, ByVal h2 As Single, ByVal EctX As Single, ByVal EctY As Single, ByRef PosProf() As Decimal, ByRef Result() As Decimal, ByVal Dofs As Short, ByRef Gxc As Single, ByRef Dxc As Single)
        Dim m_Image As Bitmap
        Dim m_Position As Point
        Dim m_Gr As Graphics
        Dim m_Pen As Pen
        Const m_Epaisseur As Integer = 4

        Dim m_X1 As Single
        Dim m_X2 As Single
        Dim m_Y2 As Single
        Dim m_Y1 As Single

        Dim i As Short
        Dim x As Single
        Dim y As Single
        Dim msg As String

        Dim m_Facteur As Single

        Try
            m_Facteur = Me.Width / 34

            Me.Invoke(Sub()
                          PictureBox5.Width = m_Longueur
                          PictureBox5.Height = m_Hauteur
                          PictureBox5.Location = position
                      End Sub)

            'pcBox.Width = m_Longueur
            'pcBox.Height = m_Hauteur
            'pcBox.Location = position

            m_Image = New Bitmap(PictureBox5.Width, PictureBox5.Height)
            m_Gr = Graphics.FromImage(m_Image)
            m_Pen = New Pen(couleur, m_Epaisseur)

            m_X1 = m_Facteur
            m_Y1 = PictureBox5.Height - m_Facteur * 1.5
            m_X2 = PictureBox5.Width - 0.5 * m_Facteur
            m_Y2 = m_Facteur

            Dim sh As Single = (m_Y1 - m_Y2) / (h2 - h1)
            Dim ih As Integer = CInt((h2 - h1) / EctY)

            Dim sx As Single = (m_X2 - m_X1) / (x2 - x1)
            Dim ix As Integer = CInt((x2 - x1) / EctX)

            'Construction des lignes d'axes
            Dim H8ft As Single = 0.2118 * CSng(m_Facteur)
            Dim H10ft As Single = 0.2648 * CSng(m_Facteur)
            Dim H12ft As Single = 0.3178 * CSng(m_Facteur)
            Dim fnt8Arial As New Font("Arial", H8ft)
            Dim fnt10Arial As New Font("Arial", H10ft)
            Dim fnt12Arial As New Font("Arial", H12ft)
            Dim pen01 As New Drawing.Pen(System.Drawing.Color.Gray, 1)
            Dim Drawformat0 As New StringFormat
            Dim Drawformat1 As New StringFormat
            Dim Drawformat2 As New StringFormat
            Drawformat0.Alignment = StringAlignment.Near
            Drawformat1.Alignment = StringAlignment.Far
            Drawformat2.Alignment = StringAlignment.Center

            Dim drawPoint04 As New PointF(5 * m_Facteur, 0)
            m_Gr.DrawString(message0, fnt12Arial, Brushes.Black, drawPoint04, Drawformat2)

            Dim drawPoint01 As New PointF(m_X1 - m_Facteur / 6, m_Y2 - 0.5 * m_Facteur)
            m_Gr.DrawString(message1, fnt10Arial, Brushes.Black, drawPoint01, Drawformat0)

            Dim drawPoint03 As New PointF(m_X2, m_Y1 + 0.3 * m_Facteur)
            m_Gr.DrawString(message2, fnt10Arial, Brushes.Black, drawPoint03, Drawformat1)

            Dim drawPoint00 As New PointF(m_Facteur * 5, PictureBox5.Height - 2 * H12ft)
            m_Gr.DrawString(message3, fnt12Arial, Brushes.Black, drawPoint00, Drawformat2)

            For i = 0 To ih
                y = m_Y1 - i * sh * EctY
                Dim drawPoint As New PointF(m_X1, y - 0.5 * H8ft)
                ' Create a Pen object
                m_Gr.DrawLine(pen01, m_X1, y, m_X2, y)
                msg = Format(h1 + CSng(i) * EctY, "0.00")
                m_Gr.DrawString(msg, fnt8Arial, Brushes.Black, drawPoint, Drawformat1)
            Next i

            For i = 0 To ix
                x = m_X1 + i * EctX * sx
                ' Create a Pen object.
                Dim drawPoint02 As New PointF(x, m_Y1)
                m_Gr.DrawLine(pen01, x, m_Y1, x, m_Y2)
                msg = i * EctX + x1
                m_Gr.DrawString(msg, fnt8Arial, Brushes.Black, drawPoint02, Drawformat2)
            Next i

            'dessin des résultats
            Dim x_old As Single
            Dim y_old As Single

            y = m_Y1 - sh * (Result(1) - h1)
            m_Gr.DrawLine(m_Pen, m_X1, y, m_X1, y)
            x_old = m_X1
            y_old = y
            For i = 2 To Dofs
                y = m_Y1 - sh * (Result(i) - h1)
                x = m_X1 + sx * PosProf(i)
                m_Gr.DrawLine(m_Pen, x_old, y_old, x, y)
                x_old = x
                y_old = y
            Next i
            If Gxc >= 0 And Dxc >= 0 Then       'dessin des positions de xc pour la carbonatation
                m_Pen = New Pen(System.Drawing.Color.Cyan, m_Epaisseur)
                m_Gr.DrawLine(m_Pen, m_X1 + sx * Gxc, m_Y1 - sh * (h1 - h1), m_X1 + sx * Gxc, m_Y1 - sh * (h2 - h1))
                m_Gr.DrawLine(m_Pen, m_X1 + sx * (PosProf(Dofs) - Dxc), m_Y1 - sh * (h1 - h1), m_X1 + sx * (PosProf(Dofs) - Dxc), m_Y1 - sh * (h2 - h1))
            End If
        Catch e As Exception
        End Try
        PictureBox5.Image = m_Image
    End Sub

    Public Sub PlotGraph6(ByVal position As Point, ByVal m_Longueur As Single, ByVal m_Hauteur As Single, ByVal couleur As Color, ByVal message0 As String, ByVal message1 As String, ByVal message2 As String, ByVal message3 As String, ByVal x1 As Single, ByVal x2 As Single, ByVal h1 As Single, ByVal h2 As Single, ByVal EctX As Single, ByVal EctY As Single, ByRef PosProf() As Decimal, ByRef Result() As Decimal, ByVal Dofs As Short, ByRef Gxc As Single, ByRef Dxc As Single)
        Dim m_Image As Bitmap
        Dim m_Position As Point
        Dim m_Gr As Graphics
        Dim m_Pen As Pen
        Const m_Epaisseur As Integer = 4

        Dim m_X1 As Single
        Dim m_X2 As Single
        Dim m_Y2 As Single
        Dim m_Y1 As Single

        Dim i As Short
        Dim x As Single
        Dim y As Single
        Dim msg As String

        Dim m_Facteur As Single

        Try
            m_Facteur = Me.Width / 34

            Me.Invoke(Sub()
                          PictureBox6.Width = m_Longueur
                          PictureBox6.Height = m_Hauteur
                          PictureBox6.Location = position
                      End Sub)

            'pcBox.Width = m_Longueur
            'pcBox.Height = m_Hauteur
            'pcBox.Location = position

            m_Image = New Bitmap(PictureBox6.Width, PictureBox6.Height)
            m_Gr = Graphics.FromImage(m_Image)
            m_Pen = New Pen(couleur, m_Epaisseur)

            m_X1 = m_Facteur
            m_Y1 = PictureBox6.Height - m_Facteur * 1.5
            m_X2 = PictureBox6.Width - 0.5 * m_Facteur
            m_Y2 = m_Facteur

            Dim sh As Single = (m_Y1 - m_Y2) / (h2 - h1)
            Dim ih As Integer = CInt((h2 - h1) / EctY)

            Dim sx As Single = (m_X2 - m_X1) / (x2 - x1)
            Dim ix As Integer = CInt((x2 - x1) / EctX)

            'Construction des lignes d'axes
            Dim H8ft As Single = 0.2118 * CSng(m_Facteur)
            Dim H10ft As Single = 0.2648 * CSng(m_Facteur)
            Dim H12ft As Single = 0.3178 * CSng(m_Facteur)
            Dim fnt8Arial As New Font("Arial", H8ft)
            Dim fnt10Arial As New Font("Arial", H10ft)
            Dim fnt12Arial As New Font("Arial", H12ft)
            Dim pen01 As New Drawing.Pen(System.Drawing.Color.Gray, 1)
            Dim Drawformat0 As New StringFormat
            Dim Drawformat1 As New StringFormat
            Dim Drawformat2 As New StringFormat
            Drawformat0.Alignment = StringAlignment.Near
            Drawformat1.Alignment = StringAlignment.Far
            Drawformat2.Alignment = StringAlignment.Center

            Dim drawPoint04 As New PointF(5 * m_Facteur, 0)
            m_Gr.DrawString(message0, fnt12Arial, Brushes.Black, drawPoint04, Drawformat2)

            Dim drawPoint01 As New PointF(m_X1 - m_Facteur / 6, m_Y2 - 0.5 * m_Facteur)
            m_Gr.DrawString(message1, fnt10Arial, Brushes.Black, drawPoint01, Drawformat0)

            Dim drawPoint03 As New PointF(m_X2, m_Y1 + 0.3 * m_Facteur)
            m_Gr.DrawString(message2, fnt10Arial, Brushes.Black, drawPoint03, Drawformat1)

            Dim drawPoint00 As New PointF(m_Facteur * 5, PictureBox6.Height - 2 * H12ft)
            m_Gr.DrawString(message3, fnt12Arial, Brushes.Black, drawPoint00, Drawformat2)

            For i = 0 To ih
                y = m_Y1 - i * sh * EctY
                Dim drawPoint As New PointF(m_X1, y - 0.5 * H8ft)
                ' Create a Pen object
                m_Gr.DrawLine(pen01, m_X1, y, m_X2, y)
                msg = Format(h1 + CSng(i) * EctY, "0.00")
                m_Gr.DrawString(msg, fnt8Arial, Brushes.Black, drawPoint, Drawformat1)
            Next i

            For i = 0 To ix
                x = m_X1 + i * EctX * sx
                ' Create a Pen object.
                Dim drawPoint02 As New PointF(x, m_Y1)
                m_Gr.DrawLine(pen01, x, m_Y1, x, m_Y2)
                msg = i * EctX + x1
                m_Gr.DrawString(msg, fnt8Arial, Brushes.Black, drawPoint02, Drawformat2)
            Next i

            'dessin des résultats
            Dim x_old As Single
            Dim y_old As Single

            y = m_Y1 - sh * (Result(1) - h1)
            m_Gr.DrawLine(m_Pen, m_X1, y, m_X1, y)
            x_old = m_X1
            y_old = y
            For i = 2 To Dofs
                y = m_Y1 - sh * (Result(i) - h1)
                x = m_X1 + sx * PosProf(i)
                m_Gr.DrawLine(m_Pen, x_old, y_old, x, y)
                x_old = x
                y_old = y
            Next i
            If Gxc >= 0 And Dxc >= 0 Then       'dessin des positions de xc pour la carbonatation
                m_Pen = New Pen(System.Drawing.Color.Cyan, m_Epaisseur)
                m_Gr.DrawLine(m_Pen, m_X1 + sx * Gxc, m_Y1 - sh * (h1 - h1), m_X1 + sx * Gxc, m_Y1 - sh * (h2 - h1))
                m_Gr.DrawLine(m_Pen, m_X1 + sx * (PosProf(Dofs) - Dxc), m_Y1 - sh * (h1 - h1), m_X1 + sx * (PosProf(Dofs) - Dxc), m_Y1 - sh * (h2 - h1))
            End If
        Catch e As Exception
        End Try
        PictureBox6.Image = m_Image
    End Sub

    Public Sub ModifyCommand1(ByVal Val As Boolean)
        Invoke(Sub() Me.Command1.Enabled = Val)
    End Sub

End Class
