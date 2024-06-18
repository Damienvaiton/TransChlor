Public Class HETrans
    'Implementation of the 4*1 Elemental vector for relative humidity
    Private h1, h2, h3, h4 As Double
    ''' <summary>
    ''' Initializes a new instance of HE element
    ''' </summary>
    ''' <param name="h1"></param>
    ''' <param name="h2"></param>
    ''' <param name="h3"></param>
    ''' <param name="h4"></param>
    Public Sub New(
               h1 As Double, h2 As Double,
               h3 As Double, h4 As Double)
        Me.h1 = h1 : Me.h2 = h2
        Me.h3 = h3 : Me.h4 = h4
    End Sub
    'Construct the elemental vector
    Public Function getHe() As Double()
        Dim He(3) As Double
        He(0) = h1
        He(1) = h2
        He(2) = h3
        He(3) = h4
        Return He
    End Function
End Class
