'Option Explicit On
'Imports System
'Imports System.ComponentModel
'Imports System.IO
'Imports System.Linq

Public Class CETrans
    'Implementation of the 4*1 Elemental vector for concentration
    Private c1, c2, c3, c4 As Double
    ''' <summary>
    ''' Initializes a new instance of HE element
    ''' </summary>
    ''' <param name="c1"></param>
    ''' <param name="c2"></param>
    ''' <param name="c3"></param>
    ''' <param name="c4"></param>
    Public Sub New(
               c1 As Double, c2 As Double,
               c3 As Double, c4 As Double)
        Me.c1 = c1 : Me.c2 = c2
        Me.c3 = c3 : Me.c4 = c4
    End Sub
    'Construct the elemental vector
    Public Function getCe() As Double()
        Dim Ce(3) As Double
        Ce(0) = c1
        Ce(1) = c2
        Ce(2) = c3
        Ce(3) = c4
        Return Ce
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim trans = TryCast(obj, CETrans)
        Return trans IsNot Nothing AndAlso
               c1 = trans.c1 AndAlso
               c2 = trans.c2 AndAlso
               c3 = trans.c3 AndAlso
               c4 = trans.c4
    End Function
End Class
