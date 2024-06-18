' Xuande 10/06/2020 nouvelle class modifié à partir de frmFEM
Public Class ElementTrans
    Public Property ElementNumber As Integer
    Public Property Node1 As Integer
    Public Property Node2 As Integer
    Public Property Node3 As Integer
    Public Property Node4 As Integer

    Private HR() As Double
    Private Sl() As Double
    Private T() As Double 'xuande, temperature
    Private Na() As Double 'xuande, Sodium
    Private Cl() As Double 'xuande, chloride
    Private K() As Double
    Private OH() As Double
    Private Ca() As Double
    Private SO4() As Double
    Private Jx_cap() As Double 'xuande, flux de capillarite direction x
    Private Jy_cap() As Double 'xuande, flux de capillarite direction y
    Private Jx_dif() As Double 'xuande, flux de diffusion hydrique direction x
    Private Jy_dif() As Double 'xuande, flux de diffusion hydrique direction y
    Private Jx_thm() As Double 'xuande, flux de diffusion thermique direction x
    Private Jy_thm() As Double 'xuande, flux de diffusion thermique direction y
    Private Jx_ion() As Double 'xuande, flux ionique direction x
    Private Jy_ion() As Double 'xuande, flux ionique direction y

    'Public Stresses(1) As Double
    'Public Strains(1) As Double
    'field value functions
    Public Sub New(ByRef n As Integer, ByRef n1 As Integer, ByRef n2 As Integer, ByRef n3 As Integer, ByRef n4 As Integer)

        _ElementNumber = n
        _Node1 = n1
        _Node2 = n2
        _Node3 = n3
        _Node4 = n4

    End Sub

    Public Sub ReDimFields(ByRef Dimension As Integer)

        ReDim HR(Dimension - 1)
        ReDim Sl(Dimension - 1)
        ReDim T(Dimension - 1)
        ReDim Na(Dimension - 1)
        ReDim Cl(Dimension - 1)
        ReDim K(Dimension - 1)
        ReDim OH(Dimension - 1)
        ReDim Ca(Dimension - 1)
        ReDim SO4(Dimension - 1)
    End Sub

    Public Sub SetFields(ByRef time As Integer, ByRef HRval As Double, ByRef Slval As Double, ByRef Tval As Double, ByRef Naval As Double, ByRef Clval As Double, ByRef Kval As Double, ByRef OHval As Double, ByRef Caval As Double, ByRef SO4val As Double)

        HR(time) = HRval
        Sl(time) = Slval
        T(time) = Tval
        Na(time) = Naval
        Cl(time) = Clval
        K(time) = Kval
        OH(time) = OHval
        Ca(time) = Caval
        SO4(time) = SO4val
    End Sub
    'flux , xuande 2020.09.28
    Public Sub SetThermoFlux(ByRef time As Integer, ByRef fluxX As Double, ByRef fluxY As Double)
        Jx_thm(time) = fluxX
        Jy_thm(time) = fluxY
    End Sub
    Public Sub SetCapillarityFlux(ByRef time As Integer, ByRef fluxX As Double, ByRef fluxY As Double)
        Jx_cap(time) = fluxX
        Jy_cap(time) = fluxY
    End Sub
    Public Sub SetDiffusionFlux(ByRef time As Integer, ByRef fluxX As Double, ByRef fluxY As Double)
        Jx_dif(time) = fluxX
        Jy_dif(time) = fluxY
    End Sub
    Public Sub SetIonicFlux(ByRef time As Integer, ByRef flux_x As Double, ByRef flux_y As Double)
        Jx_ion(time) = flux_x
        Jy_ion(time) = flux_y
    End Sub

    Public Sub CalcFieldInElement(ByRef time As Integer, ByRef Nodes() As NodeTrans)

        HR(time) = (Nodes(Node1 - 1).GetHRNew() + Nodes(Node2 - 1).GetHRNew() + Nodes(Node3 - 1).GetHRNew() + Nodes(Node4 - 1).GetHRNew()) * 100 / 4
        Sl(time) = (Nodes(Node1 - 1).GetSNew() + Nodes(Node2 - 1).GetSNew() + Nodes(Node3 - 1).GetSNew() + Nodes(Node4 - 1).GetSNew()) * 100 / 4
        T(time) = (Nodes(Node1 - 1).GetTNew() + Nodes(Node2 - 1).GetTNew() + Nodes(Node3 - 1).GetTNew() + Nodes(Node4 - 1).GetTNew()) / 4
        Na(time) = (Nodes(Node1 - 1).GetNaNew() + Nodes(Node2 - 1).GetNaNew() + Nodes(Node3 - 1).GetNaNew() + Nodes(Node4 - 1).GetNaNew()) / 4
        Cl(time) = (Nodes(Node1 - 1).GetClNew() + Nodes(Node2 - 1).GetClNew() + Nodes(Node3 - 1).GetClNew() + Nodes(Node4 - 1).GetClNew()) / 4
        K(time) = (Nodes(Node1 - 1).GetKNew() + Nodes(Node2 - 1).GetKNew() + Nodes(Node3 - 1).GetKNew() + Nodes(Node4 - 1).GetKNew()) / 4
        OH(time) = (Nodes(Node1 - 1).GetOHNew() + Nodes(Node2 - 1).GetOHNew() + Nodes(Node3 - 1).GetOHNew() + Nodes(Node4 - 1).GetOHNew()) / 4
        Ca(time) = (Nodes(Node1 - 1).GetCaNew() + Nodes(Node2 - 1).GetCaNew() + Nodes(Node3 - 1).GetCaNew() + Nodes(Node4 - 1).GetCaNew()) / 4
        SO4(time) = (Nodes(Node1 - 1).GetSO4New() + Nodes(Node2 - 1).GetSO4New() + Nodes(Node3 - 1).GetSO4New() + Nodes(Node4 - 1).GetSO4New()) / 4
    End Sub

    Public Function GetHR(ByRef time As Integer) As Double
        Return HR(time)
    End Function
    Public Function GetS(ByRef time As Integer) As Double
        Return Sl(time)
    End Function
    Public Function GetT(ByRef time As Integer) As Double
        Return T(time)
    End Function
    Public Function GetNa(ByRef time As Integer) As Double
        Return Na(time)
    End Function
    Public Function GetCl(ByRef time As Integer) As Double
        Return Cl(time)
    End Function
    Public Function GetK(ByRef time As Integer) As Double
        Return K(time)
    End Function
    Public Function GetOH(ByRef time As Integer) As Double
        Return OH(time)
    End Function
    Public Function GetCa(ByRef time As Integer) As Double
        Return Ca(time)
    End Function
    Public Function GetSO4(ByRef time As Integer) As Double
        Return SO4(time)
    End Function
    'flux , xuande 2020.09.28
    Public Function GetThermoFluxX(ByRef time As Integer) As Double
        Return Jx_thm(time)
    End Function
    Public Function GetThermoFluxY(ByRef time As Integer) As Double
        Return Jy_thm(time)
    End Function
    Public Function GetCapillaryFluxX(ByRef time As Integer) As Double
        Return Jx_cap(time)
    End Function
    Public Function GetCapillaryFluxY(ByRef time As Integer) As Double
        Return Jy_cap(time)
    End Function
    Public Function GetDiffusionFluxX(ByRef time As Integer) As Double
        Return Jx_dif(time)
    End Function
    Public Function GetDiffusionFluxY(ByRef time As Integer) As Double
        Return Jy_dif(time)
    End Function
    Public Function GetIonicFluxX(ByRef time As Integer) As Double
        Return Jx_ion(time)
    End Function
    Public Function GetIonicFluxY(ByRef time As Integer) As Double
        Return Jy_ion(time)
    End Function
End Class
