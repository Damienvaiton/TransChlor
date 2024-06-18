Public Class CGraph

    Public Sub New(ByRef frm As frmGraph1D, ByRef pcBox As PictureBox, ByVal position As Point, ByVal m_Longueur As Single, ByVal m_Hauteur As Single, ByVal couleur As Color, ByVal message0 As String, ByVal message1 As String, ByVal message2 As String, ByVal message3 As String, ByVal x1 As Single, ByVal x2 As Single, ByVal h1 As Single, ByVal h2 As Single, ByVal EctX As Single, ByVal EctY As Single, ByRef PosProf() As Decimal, ByRef Result() As Decimal, ByVal Dofs As Short, ByRef Gxc As Single, ByRef Dxc As Single)
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
            m_Facteur = frm.Width / 34

            'pcBox.Width = m_Longueur
            'pcBox.Height = m_Hauteur
            'pcBox.Location = position

            m_Image = New Bitmap(pcBox.Width, pcBox.Height)
            m_Gr = Graphics.FromImage(m_Image)
            m_Pen = New Pen(couleur, m_Epaisseur)

            m_X1 = m_Facteur
            m_Y1 = pcBox.Height - m_Facteur * 1.5
            m_X2 = pcBox.Width - 0.5 * m_Facteur
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

            Dim drawPoint00 As New PointF(m_Facteur * 5, pcBox.Height - 2 * H12ft)
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
        pcBox.Image = m_Image
    End Sub

End Class
