Public Class CIETrans_MI
    ' Xuande 2021.08.15 Multiionic model FEM framework*
    'Implementation of the 4*4 Rectangular Elemental Matrix for integration 
    Private x1, y1, x2, y2, x3, y3, x4, y4, d1, d2, d3, d4, wr, F, z, E, R, T, grad_logGamma As Double

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
    ''' <param name="d1"></param>
    ''' <param name="d2"></param>
    ''' <param name="d3"></param>
    ''' <param name="d4"></param>
    ''' <param name="wr"></param>
    ''' <param name="F"></param>
    ''' <param name="z"></param>
    ''' <param name="E"></param>
    ''' <param name="R"></param>
    ''' <param name="T"></param>
    ''' <param name="grad_logGamma"></param>
    Public Sub New(x1 As Double, y1 As Double,
                   x2 As Double, y2 As Double,
                   x3 As Double, y3 As Double,
                   x4 As Double, y4 As Double,
                         d1 As Double, d2 As Double, d3 As Double, d4 As Double, wr As Double, F As Double, z As Double, E As Double, R As Double, T As Double, grad_logGamma As Double)
        Me.x1 = x1 : Me.y1 = y1
        Me.x2 = x2 : Me.y2 = y2
        Me.x3 = x3 : Me.y3 = y3
        Me.x4 = x4 : Me.y4 = y4
        Me.d1 = d1
        Me.d2 = d2
        Me.d3 = d3
        Me.d4 = d4
        Me.wr = wr
        Me.F = F
        Me.z = z
        Me.E = E
        Me.R = R
        Me.T = T
        Me.grad_logGamma = grad_logGamma

    End Sub

    ''' Returns the integrated [be_MI] matrix by Gauss sommation method
    Public Function getbe_MI() As Double(,)
        Dim be_MI(3, 3) As Double 'initialize a 4x4 vector
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
                be_MI(i, j) = wr * (NTN1(i, j) * DetJ1 + NTN2(i, j) * DetJ2 + NTN3(i, j) * DetJ3 + NTN4(i, j) * DetJ4)
            Next
        Next
        Return be_MI
    End Function

    ''' Returns the integrated [Ae_MI] matrix by Gauss sommation method
    Public Function getAe_MI() As Double(,)

        Dim B1(,) As Double = getB(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim B2(,) As Double = getB(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim B3(,) As Double = getB(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
        Dim B4(,) As Double = getB(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
        Dim DetJ1 As Double = getDetJ(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim DetJ2 As Double = getDetJ(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim DetJ3 As Double = getDetJ(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
        Dim DetJ4 As Double = getDetJ(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))

        'Dim D(,) As Double*
        Dim D1(,) As Double = getDmat(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim D2(,) As Double = getDmat(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim D3(,) As Double = getDmat(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
        Dim D4(,) As Double = getDmat(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))

        'Xuande 2021.08.15 electric diffusivity
        Dim Dv1(,) As Double = getDvec(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim Dv2(,) As Double = getDvec(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim Dv3(,) As Double = getDvec(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
        Dim Dv4(,) As Double = getDvec(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))

        Dim N1(,) As Double = getN(-1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim N2(,) As Double = getN(1 / Math.Sqrt(3), -1 / Math.Sqrt(3))
        Dim N3(,) As Double = getN(1 / Math.Sqrt(3), 1 / Math.Sqrt(3))
        Dim N4(,) As Double = getN(-1 / Math.Sqrt(3), 1 / Math.Sqrt(3))

        Dim BT1(,) As Double = getBT(B1)
        Dim BT2(,) As Double = getBT(B2)
        Dim BT3(,) As Double = getBT(B3)
        Dim BT4(,) As Double = getBT(B4)

        'Calculate diffusion part
        Dim A_e1(,) As Double = MultiplyMatrices(BT1, D1)
        A_e1 = MultiplyMatrices(A_e1, B1)

        Dim A_e2(,) As Double = MultiplyMatrices(BT2, D2)
        A_e2 = MultiplyMatrices(A_e2, B2)

        Dim A_e3(,) As Double = MultiplyMatrices(BT3, D3)
        A_e3 = MultiplyMatrices(A_e3, B3)

        Dim A_e4(,) As Double = MultiplyMatrices(BT4, D4)
        A_e4 = MultiplyMatrices(A_e4, B4)

        'Calculate electric & chemical activity part*
        Dim AE_e1(,) As Double = MultiplyMatrices(BT1, Dv1)
        AE_e1 = MultiplyMatrices(AE_e1, N1)

        Dim AE_e2(,) As Double = MultiplyMatrices(BT2, Dv2)
        AE_e2 = MultiplyMatrices(AE_e2, N2)

        Dim AE_e3(,) As Double = MultiplyMatrices(BT3, Dv3)
        AE_e3 = MultiplyMatrices(AE_e3, N3)

        Dim AE_e4(,) As Double = MultiplyMatrices(BT4, Dv4)
        AE_e4 = MultiplyMatrices(AE_e4, N4)

        Dim Ae_MI(3, 3) As Double
        Dim i, j As Integer
        For i = 0 To 3
            For j = 0 To 3          ' include calculation of electric & chemical activity part*
                Ae_MI(i, j) = wr * ((A_e1(i, j) + (F * z / R / T + grad_logGamma) * AE_e1(i, j)) * DetJ1 + (A_e2(i, j) + (F * z / R / T + grad_logGamma) * AE_e2(i, j)) * DetJ2 + (A_e3(i, j) + (F * z / R / T + grad_logGamma) * AE_e3(i, j)) * DetJ3 + (A_e4(i, j) + (F * z / R / T + grad_logGamma) * AE_e4(i, j)) * DetJ4)
            Next
        Next
        Return Ae_MI
    End Function
    Public Function getDmat(ByRef epsi As Double, yita As Double) As Double(,)
        Dim Dmat(1, 1) As Double
        Dmat(0, 0) = getDi(epsi, yita)
        Dmat(0, 1) = 0
        Dmat(1, 0) = 0
        Dmat(1, 1) = getDi(epsi, yita)
        Return Dmat
    End Function
    Public Function getDvec(ByRef epsi As Double, yita As Double) As Double(,) 'construct electric diffusivity vector
        Dim Dvec(1, 0) As Double
        Dvec(0, 0) = E * getDi(epsi, yita) 'electric effect on x direction
        Dvec(1, 0) = E * getDi(epsi, yita) 'electric effect on y direction
        Return Dvec
    End Function
    Public Function getB(ByRef aa As Double, ByRef bb As Double) As Double(,)
        Dim B(1, 3) As Double
        Dim epsi As Double = aa
        Dim yita As Double = bb

        B(0, 0) = 1 / 4 * (-(1 - yita))
        B(0, 1) = 1 / 4 * (1 - yita)
        B(0, 2) = 1 / 4 * (1 + yita)
        B(0, 3) = 1 / 4 * (-(1 + yita))

        B(1, 0) = 1 / 4 * (-(1 - epsi))
        B(1, 1) = 1 / 4 * (-(1 + epsi))
        B(1, 2) = 1 / 4 * (1 + epsi)
        B(1, 3) = 1 / 4 * (1 - epsi)

        Return B
    End Function
    Private Function getDi(ByRef epsi As Double, yita As Double) As Double ' get interpolated average diffusivity on nodes.
        Dim Di As Double = 1 / 4 * ((1 - epsi) * (1 - yita) * d1 + (1 + epsi) * (1 - yita) * d2 + (1 + epsi) * (1 + yita) * d3 + (1 - epsi) * (1 + yita) * d4)
        Return Di
    End Function
    Private Function getN(ByRef epsi As Double, yita As Double) As Double(,) ' get interpolated average diffusivity on nodes.
        Dim N(0, 3) As Double
        N(0, 0) = 1 / 4 * (1 - epsi) * (1 - yita)
        N(0, 1) = 1 / 4 * (1 + epsi) * (1 - yita)
        N(0, 2) = 1 / 4 * (1 + epsi) * (1 + yita)
        N(0, 3) = 1 / 4 * (1 - epsi) * (1 + yita)
        Return N
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

    ''Jacobien functions
    'Get Jacobien matrix
    Private Function getJac(ByRef coorx As Double, ByRef coory As Double) As Double(,)
        Dim Jac(1, 1) As Double
        Dim zeta As Double = coorx
        Dim yita As Double = coory
        Jac(0, 0) = 1 / 4 * (-(1 - yita) * x1 + (1 - yita) * x2 + (1 + yita) * x3 - (1 + yita) * x4)
        Jac(1, 0) = 1 / 4 * (-(1 - zeta) * x1 - (1 + zeta) * x2 + (1 + zeta) * x3 + (1 - zeta) * x4)
        Jac(0, 1) = 1 / 4 * (-(1 - yita) * y1 + (1 - yita) * y2 + (1 + yita) * y3 - (1 + yita) * y4)
        Jac(1, 1) = 1 / 4 * (-(1 - zeta) * y1 - (1 + zeta) * y2 + (1 + zeta) * y3 + (1 - zeta) * y4)
        Return Jac
    End Function
    'Get determinant of Jacobien matrix
    Private Function getDetJ(ByRef coorx As Double, ByRef coory As Double) As Double
        Dim Jac(1, 1) As Double
        Dim DetJ As Double
        Dim zeta As Double = coorx
        Dim yita As Double = coory
        Jac(0, 0) = 1 / 4 * (-(1 - yita) * x1 + (1 - yita) * x2 + (1 + yita) * x3 - (1 + yita) * x4)
        Jac(1, 0) = 1 / 4 * (-(1 - zeta) * x1 - (1 + zeta) * x2 + (1 + zeta) * x3 + (1 - zeta) * x4)
        Jac(0, 1) = 1 / 4 * (-(1 - yita) * y1 + (1 - yita) * y2 + (1 + yita) * y3 - (1 + yita) * y4)
        Jac(1, 1) = 1 / 4 * (-(1 - zeta) * y1 - (1 + zeta) * y2 + (1 + zeta) * y3 + (1 - zeta) * y4)
        DetJ = Jac(0, 0) * Jac(1, 1) - Jac(1, 0) * Jac(0, 1)
        Return DetJ
    End Function
    'Get inverse of Jacobien matrix
    Public Function GetInversedJac(ByRef coorx As Double, ByRef coory As Double) As Double(,)
        Dim Jac_inv(1, 1) As Double
        Dim zeta As Double = coorx
        Dim yita As Double = coory
        Dim DetJ As Double
        Jac_inv(0, 0) = 1 / 4 * (-(1 - yita) * x1 + (1 - yita) * x2 + (1 + yita) * x3 - (1 + yita) * x4)
        Jac_inv(1, 0) = 1 / 4 * (-(1 - zeta) * x1 - (1 + zeta) * x2 + (1 + zeta) * x3 + (1 - zeta) * x4)
        Jac_inv(0, 1) = 1 / 4 * (-(1 - yita) * y1 + (1 - yita) * y2 + (1 + yita) * y3 - (1 + yita) * y4)
        Jac_inv(1, 1) = 1 / 4 * (-(1 - zeta) * y1 - (1 + zeta) * y2 + (1 + zeta) * y3 + (1 - zeta) * y4)
        DetJ = Jac_inv(0, 0) * Jac_inv(1, 1) - Jac_inv(1, 0) * Jac_inv(0, 1)
        Jac_inv(0, 0) = Jac_inv(1, 1) / DetJ
        Jac_inv(0, 1) = -Jac_inv(0, 1) / DetJ
        Jac_inv(1, 0) = -Jac_inv(1, 0) / DetJ
        Jac_inv(1, 1) = Jac_inv(0, 0) / DetJ
        Return Jac_inv
    End Function
    'flux functions
    Public Function getXFlux(ByRef coef As Double, ByRef Var As Double(), ByRef Jac_inv As Double(,), ByRef B As Double(,)) As Double
        Dim JFlux As Double
        Dim dN1dx As Double = Jac_inv(0, 0) * B(0, 0) + Jac_inv(0, 1) * B(1, 0)
        Dim dN2dx As Double = Jac_inv(0, 0) * B(0, 1) + Jac_inv(0, 1) * B(1, 1)
        Dim dN3dx As Double = Jac_inv(0, 0) * B(0, 2) + Jac_inv(0, 1) * B(1, 2)
        Dim dN4dx As Double = Jac_inv(0, 0) * B(0, 3) + Jac_inv(0, 1) * B(1, 3)
        JFlux = coef * (dN1dx * Var(0) + dN2dx * Var(1) + dN3dx * Var(2) + dN4dx * Var(3))
        Return JFlux
    End Function
    Public Function getYFlux(ByRef coef As Double, ByRef Var As Double(), ByRef Jac_inv As Double(,), ByRef B As Double(,)) As Double
        Dim JFlux As Double
        Dim dN1dy As Double = Jac_inv(1, 0) * B(0, 0) + Jac_inv(1, 1) * B(1, 0)
        Dim dN2dy As Double = Jac_inv(1, 0) * B(0, 1) + Jac_inv(1, 1) * B(1, 1)
        Dim dN3dy As Double = Jac_inv(1, 0) * B(0, 2) + Jac_inv(1, 1) * B(1, 2)
        Dim dN4dy As Double = Jac_inv(1, 0) * B(0, 3) + Jac_inv(1, 1) * B(1, 3)
        JFlux = coef * (dN1dy * Var(0) + dN2dy * Var(1) + dN3dy * Var(2) + dN4dy * Var(3))
        Return JFlux
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
