' Xuande 10/27/2020 new class to register boundary conditions info
Public Class TableTrans
    Public Property PhysicalGroup As Integer
    Public Property ExpoFile As String

    Public Sub New(n As Integer, f As String)

        _PhysicalGroup = n
        _ExpoFile = f

    End Sub
    Public Function GetGroupExpo(ByRef i As Integer) As String
        Dim GroupExpo As String
        GroupExpo = ExpoFile(i)
        Return GroupExpo
    End Function
End Class
