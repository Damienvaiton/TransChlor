Public Class TETrans
    'Implementation of the 4*1 Elemental vector for temperature
    Private t1, t2, t3, t4 As Double
    ''' <summary>
    ''' Initializes a new instance of HE element
    ''' </summary>
    ''' <param name="t1"></param>
    ''' <param name="t2"></param>
    ''' <param name="t3"></param>
    ''' <param name="t4"></param>
    Public Sub New(
               t1 As Double, t2 As Double,
               t3 As Double, t4 As Double)
        Me.t1 = t1 : Me.t2 = t2
        Me.t3 = t3 : Me.t4 = t4
    End Sub
    'Construct the elemental vector
    Public Function getTe() As Double()
        Dim Te(3) As Double
        Te(0) = t1
        Te(1) = t2
        Te(2) = t3
        Te(3) = t4
        Return Te
    End Function
End Class
