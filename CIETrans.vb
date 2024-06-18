Public Class CIETrans

    'Implementation of the 4*4 Rectangular Elemental Matrix for the chronological integration part
    Private ReadOnly x1, y1, x2, y2, x3, y3, x4, y4, DiffCoeff As Double

    ''' <summary>
    ''' Initializes a new instance of CIE element
    ''' </summary>
    ''' <param name="x1"></param>
    ''' <param name="y1"></param>
    ''' <param name="x2"></param>
    ''' <param name="y2"></param>
    ''' <param name="x3"></param>
    ''' <param name="y3"></param>
    ''' <param name="x4"></param>
    ''' <param name="y4"></param>
    ''' <param name="DiffCoeff"></param>
    Public Sub New(x1 As Double, y1 As Double,
                   x2 As Double, y2 As Double,
                   x3 As Double, y3 As Double,
                   x4 As Double, y4 As Double,
                          DiffCoeff As Double)
        Me.x1 = x1 : Me.y1 = y1
        Me.x2 = x2 : Me.y2 = y2
        Me.x3 = x3 : Me.y3 = y3
        Me.x4 = x4 : Me.y4 = y4
        Me.DiffCoeff = DiffCoeff
    End Sub

    ''' Returns the integrated [be] matrix by Gauss sommation method
    Public Function Getbe() As Double(,)
        Dim be(3, 3) As Double 'initialize a 4x4 vector
        'Compute be now
        Dim DetJ1 As Double = getDetJ(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim DetJ2 As Double = getDetJ(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim DetJ3 As Double = getDetJ(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
        Dim DetJ4 As Double = getDetJ(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
        Dim NTN1(,) As Double = getNTN(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim NTN2(,) As Double = getNTN(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim NTN3(,) As Double = getNTN(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
        Dim NTN4(,) As Double = getNTN(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))

        Dim i, j As Integer
        For i = 0 To 3
            For j = 0 To 3
                be(i, j) = NTN1(i, j) * DetJ1 + NTN2(i, j) * DetJ2 + NTN3(i, j) * DetJ3 + NTN4(i, j) * DetJ4
            Next
        Next
        Return be
    End Function
    ''' Returns the integrated [Ae] matrix by Gauss sommation method
    Public Function getAe() As Double(,)

        Dim B1(,) As Double = getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim B2(,) As Double = getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim B3(,) As Double = getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
        Dim B4(,) As Double = getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
        Dim DetJ1 As Double = getDetJ(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim DetJ2 As Double = getDetJ(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim DetJ3 As Double = getDetJ(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
        Dim DetJ4 As Double = getDetJ(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))

        Dim D As Double = DiffCoeff

        Dim BT1(,) As Double = getBT(B1)
        Dim BT2(,) As Double = getBT(B2)
        Dim BT3(,) As Double = getBT(B3)
        Dim BT4(,) As Double = getBT(B4)
        'Compute Ke now
        Dim Ae1(,) As Double = MultiplyMatrices(BT1, B1)
        Dim Ae2(,) As Double = MultiplyMatrices(BT2, B2)
        Dim Ae3(,) As Double = MultiplyMatrices(BT3, B3)
        Dim Ae4(,) As Double = MultiplyMatrices(BT4, B4)
        Dim Ae(3, 3) As Double
        Dim i, j As Integer
        For i = 0 To 3
            For j = 0 To 3
                Ae(i, j) = Ae1(i, j) * D * DetJ1 + Ae2(i, j) * D * DetJ2 + Ae3(i, j) * D * DetJ3 + Ae4(i, j) * D * DetJ4
            Next
        Next
        Return Ae
    End Function
    Private Function getB(ByRef aa As Double, ByRef bb As Double) As Double(,)
        Dim B(1, 3) As Double
        Dim zeta As Double = aa
        Dim yita As Double = bb

        B(0, 0) = 1 / 4 * (-(1 - yita))
        B(0, 1) = 1 / 4 * (1 - yita)
        B(0, 2) = 1 / 4 * (1 + yita)
        B(0, 3) = 1 / 4 * (-(1 + yita))

        B(1, 0) = 1 / 4 * (-(1 - zeta))
        B(1, 1) = 1 / 4 * (-(1 + zeta))
        B(1, 2) = 1 / 4 * (1 + zeta)
        B(1, 3) = 1 / 4 * (1 - zeta)

        Return B
    End Function
    Private Function getNTN(ByRef aa As Double, ByRef bb As Double) As Double(,)
        Dim NTN(3, 3) As Double
        Dim zeta As Double = aa
        Dim yita As Double = bb

        NTN(0, 0) = 1 / 16 * (1 - zeta) ^ 2 * (1 - yita) ^ 2
        NTN(0, 1) = 1 / 16 * (1 - zeta ^ 2) * (1 - yita) ^ 2
        NTN(0, 2) = 1 / 16 * (1 - zeta ^ 2) * (1 - yita ^ 2)
        NTN(0, 3) = 1 / 16 * (1 - zeta) ^ 2 * (1 - yita ^ 2)

        NTN(1, 0) = 1 / 16 * (1 - zeta ^ 2) * (1 - yita) ^ 2
        NTN(1, 1) = 1 / 16 * (1 + zeta) ^ 2 * (1 - yita) ^ 2
        NTN(1, 2) = 1 / 16 * (1 + zeta) ^ 2 * (1 - yita ^ 2)
        NTN(1, 3) = 1 / 16 * (1 - zeta ^ 2) * (1 - yita ^ 2)

        NTN(2, 0) = 1 / 16 * (1 - zeta ^ 2) * (1 - yita ^ 2)
        NTN(2, 1) = 1 / 16 * (1 + zeta) ^ 2 * (1 - yita ^ 2)
        NTN(2, 2) = 1 / 16 * (1 + zeta) ^ 2 * (1 + yita) ^ 2
        NTN(2, 3) = 1 / 16 * (1 - zeta ^ 2) * (1 + yita) ^ 2

        NTN(3, 0) = 1 / 16 * (1 - zeta) ^ 2 * (1 - yita ^ 2)
        NTN(3, 1) = 1 / 16 * (1 - zeta ^ 2) * (1 - yita ^ 2)
        NTN(3, 2) = 1 / 16 * (1 - zeta ^ 2) * (1 + yita) ^ 2
        NTN(3, 3) = 1 / 16 * (1 - zeta) ^ 2 * (1 + yita) ^ 2

        Return NTN
    End Function
    ' get determinant of Jacobien
    Private Function getDetJ(ByRef coorx As Double, ByRef coory As Double) As Double
        Dim J(1, 1) As Double
        Dim DetJ As Double
        Dim zeta As Double = coorx
        Dim yita As Double = coory

        J(0, 0) = 1 / 4 * (-(1 - yita) * x1 + (1 - yita) * x2 + (1 + yita) * x3 - (1 + yita) * x4)
        J(1, 0) = 1 / 4 * (-(1 - zeta) * x1 - (1 + zeta) * x2 + (1 + zeta) * x3 + (1 - zeta) * x4)
        J(0, 1) = 1 / 4 * (-(1 - yita) * y1 + (1 - yita) * y2 + (1 + yita) * y3 - (1 + yita) * y4)
        J(1, 1) = 1 / 4 * (-(1 - zeta) * y1 - (1 + zeta) * y2 + (1 + zeta) * y3 + (1 - zeta) * y4)
        DetJ = J(0, 0) * J(1, 1) - J(1, 0) * J(0, 1)
        Return DetJ
    End Function
    Private Function getBT(ByRef B(,) As Double) As Double(,)
        'returns the transpose of [B]
        Dim BT(3, 1) As Double
        Dim i, j As Integer
        For i = 0 To 3
            For j = 0 To 1
                BT(i, j) = B(j, i)
            Next
        Next
        Return BT
    End Function
    Private Function MultiplyMatrices(ByRef a(,) As Double, ByRef b(,) As Double) As Double(,)

        Dim aCols As Integer = a.GetLength(1)
        Dim bCols As Integer = b.GetLength(1)
        Dim aRows As Integer = a.GetLength(0)
        Dim ab(aRows - 1, bCols - 1) As Double
        Dim sum As Double
        For i As Integer = 0 To aRows - 1
            For j As Integer = 0 To bCols - 1
                sum = 0.0
                For k As Integer = 0 To aCols - 1
                    sum += a(i, k) * b(k, j)
                Next
                ab(i, j) += sum
            Next
        Next
        Return ab
    End Function

End Class

