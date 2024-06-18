Public Class SETrans
    'Implementation of the 4*1 Elemental vector for saturation degree
    Private s1, s2, s3, s4 As Double
    ''' <summary>
    ''' Initializes a new instance of HE element
    ''' </summary>
    ''' <param name="s1"></param>
    ''' <param name="s2"></param>
    ''' <param name="s3"></param>
    ''' <param name="s4"></param>
    Public Sub New(
               s1 As Double, s2 As Double,
               s3 As Double, s4 As Double)
        Me.s1 = s1 : Me.s2 = s2
        Me.s3 = s3 : Me.s4 = s4
    End Sub
    'Construct the elemental vector
    Public Function getSe() As Double()
        Dim Se(3) As Double
        Se(0) = s1
        Se(1) = s2
        Se(2) = s3
        Se(3) = s4
        Return Se
    End Function
End Class

