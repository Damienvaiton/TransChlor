Public Class FrmMeteoDatabase

    ReadOnly DBCon As New DBconnexion
    'ReadOnly Expo As New MaterialsData
    'Private bindingSource As New BindingSource()

    Dim ExpoName As String
    Dim ExpoNameOld As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        DBCon.DBRequest("SELECT * FROM ExpositionList")
        'DBCon.MatFill(Expo, "ExpositionList")

        'ComboBoxMat.DataSource = Expo.Tables("ExpositionList")
        ComboBoxMat.DisplayMember = "Name"
        ComboBoxMat.ValueMember = "Id"

        Dim oData As DataRowView = CType(ComboBoxMat.SelectedItem, DataRowView)
        ExpoName = oData.Row("Name").ToString()

    End Sub

    Public Sub DiplayData(ByRef ExpoName As String)

        Try

            'DBCon.DBRequest("SELECT * FROM [" + ExpoName + "]")
            'If Expo.Tables.Contains(ExpoName) Then Expo.Tables(ExpoName).Clear()
            'DBCon.MatFill(Expo, ExpoName)
            'bindingSource.DataSource = Expo.Tables(ExpoName)

            'DataGridView.DataSource = bindingSource 'Expo.Tables(ExpoName)
            'DataGridView.Columns("Id").Visible = False
            'DataGridView.AutoResizeColumns()

            'DataGridView2.DataSource = Expo.Tables("ExpositionList")
            DataGridView2.Columns("Id").Visible = False
            DataGridView2.AutoResizeColumns()

            ExpoNameOld = ExpoName

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click


        Dim oData As DataRowView = CType(ComboBoxMat.SelectedItem, DataRowView)
        ExpoName = oData.Row("Name").ToString()

        DBCon.VerifyConnexion()

        Select Case MsgBox("Are you sure to save the localisation: " + ExpoName, MsgBoxStyle.YesNo, ExpoName)
            Case MsgBoxResult.Yes

                DBCon.DBRequest("SELECT * FROM [" + ExpoName + "]")
                'DBCon.DBUpdate(Expo, ExpoName)

                DBCon.DBRequest("SELECT * FROM ExpositionList")
                'DBCon.DBUpdate(Expo, "MaterialsList")

            Case MsgBoxResult.No

                GoTo B

        End Select

B:
    End Sub

    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click


        Dim oData As DataRowView = CType(ComboBoxMat.SelectedItem, DataRowView)
        Dim MatName As String = oData.Row("Name").ToString()

        DBCon.VerifyConnexion()

        Select Case MsgBox("Are you sure to delete the localisation: " + MatName, MsgBoxStyle.YesNo, MatName)
            Case MsgBoxResult.Yes

                DBCon.DBRequest("DELETE FROM ExpositionList WHERE Name = '" + MatName + "'")

                Try
                    DBCon.DBRequest("DROP TABLE [" + MatName + "]")
                    'Expo.Tables.Remove(MatName)
                Catch
                End Try

                DBCon.DBRequest("SELECT * FROM ExpositionList")
                'DBCon.MatFill(Expo, "ExpositionList")

                Me.Refresh()

            Case MsgBoxResult.No

                GoTo B

        End Select

B:
    End Sub

    Private Sub KeyPaste(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView.KeyDown

        If CBool(CType(e.KeyCode = Keys.V, Keys) And Keys.ControlKey) Then
            Paste()
        End If

    End Sub

    Private Sub Paste()

        Dim tArr() As String
        Dim arT() As String
        Dim c, cc, r As Integer

        tArr = Clipboard.GetText().Split(CChar(Environment.NewLine))

        r = DataGridView.SelectedCells(0).RowIndex
        c = DataGridView.SelectedCells(0).ColumnIndex

        For i As Integer = 0 To tArr.Length - 2
            arT = tArr(i).Split(CChar(vbTab))
            cc = c
            For ii As Integer = 0 To arT.Length - 1
                If cc > DataGridView.ColumnCount - 1 Then Exit For
                If r > DataGridView.Rows.Count - 1 Then
                    Dim Row As DataGridViewRow = CType(DataGridView.Rows(0).Clone(), DataGridViewRow)
                    DataGridView.Rows.Add(Row)
                End If

                DataGridView.Item(cc, r).Value = CDbl(arT(ii))

                cc += 1
            Next
            r += 1
        Next

    End Sub

    Private Sub ComboBoxMat_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxMat.SelectedValueChanged

        Dim oData As DataRowView = CType(ComboBoxMat.SelectedItem, DataRowView)
        ExpoName = oData.Row("Name").ToString()

        If ExpoName <> ExpoNameOld Then DiplayData(ExpoName)

    End Sub


    'Private Sub RefreshForm()

    '    Dim Frm As New FrmMeteoDatabase
    '    Frm.ShowDialog()
    '    Me.Close()

    'End Sub


End Class