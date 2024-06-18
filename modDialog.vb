Module modDialog

    Public Sub Msg_noEntry(ByRef UserInput1 As String, ByRef Canc As Boolean)
        If UserInput1 = "" Then
            MsgBox("Vous n'avez rien entré, ou pressé sur annulé", MsgBoxStyle.OKOnly And MsgBoxStyle.Exclamation, "Message")
            Canc = True
        End If
    End Sub

    Public Sub Msg_noNumeric(ByRef UserInput1 As String, ByRef Canc As Boolean)
        If Not IsNumeric(UserInput1) Then
            MsgBox("Nombre non-valide !", MsgBoxStyle.OKOnly And MsgBoxStyle.Exclamation, "Message")
            Canc = True
        End If
    End Sub

    Public Sub OpenDialog(ByRef Outfile As String, ByRef Canc As Boolean, ByRef Filtre As String, ByRef Index As Short, ByRef Directoire As Boolean, ByRef Titre As String)
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = CurDir()
        openFileDialog1.Filter = Filtre
        openFileDialog1.FilterIndex = Index
        openFileDialog1.RestoreDirectory = Directoire
        openFileDialog1.Title = Titre

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            If Not (openFileDialog1.OpenFile() Is Nothing) Then
                Outfile = openFileDialog1.FileName
                Canc = False
                ' Insert code to read the stream here.
                openFileDialog1.OpenFile.Close()
            End If
        Else
            Canc = True
        End If
    End Sub

    Public Sub SaveDialog(ByRef OutFile As String, ByRef Canc As Boolean, ByRef Filtre As String, ByRef Index As Short, ByRef Directoire As Boolean, ByRef Titre As String)
        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = Filtre
        saveFileDialog1.InitialDirectory = CurDir()
        saveFileDialog1.FilterIndex = Index
        saveFileDialog1.RestoreDirectory = Directoire
        saveFileDialog1.Title = Titre
        saveFileDialog1.FileName = OutFile

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Canc = False
            OutFile = saveFileDialog1.FileName
        Else
            Canc = True
        End If

    End Sub

    Public Sub FileOnly(ByRef outfile As String)
        Dim iPos As Short
        Dim Dim1 As String

        iPos = CShort(10)
        Dim1 = "\"
        Do While iPos > CShort(0)
            iPos = InStr(1, outfile, Dim1, CompareMethod.Text)
            If iPos <> CShort(0) Then
                iPos = Len(outfile) - iPos
                outfile = Microsoft.VisualBasic.Right(outfile, iPos)
            End If
        Loop

    End Sub

    Public Sub FilePost(ByRef outfile As String, ByRef PostFile As String)
        Dim iPos As Short
        Dim Dim1 As String
        Dim iPos_old As Short = 1

        iPos = CShort(10)
        Dim1 = "\"
        Do While iPos > CShort(0)
            iPos = InStr(iPos_old, outfile, Dim1, CompareMethod.Text)
            If iPos <> 0 Then iPos_old = iPos + 1
        Loop
        iPos = iPos_old - 1
        PostFile = Microsoft.VisualBasic.Left(outfile, iPos)
        ChDir(PostFile)

    End Sub

End Module
