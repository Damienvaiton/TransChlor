' Xuande 10/06/2020 nouvelle class modifiée à partir de frmFEM
Public Class NodeTrans

    Public Property NodeNumber As Integer
    Public Property x As Double
    Public Property y As Double
    Public Property z As Double

    Public Property NumExpo As Integer
    Public Property TypeExpo As String 'Xuande 2020.10.27

    Private HR(1) As Double
    Private Sl(1) As Double
    Private Wl(1) As Double
    Private T(1) As Double 'temperature
    Private Na(1) As Double 'concentration de Na + 2021.09.03 Xuande Chen
    Private Cl(1) As Double 'concentration de Cl -
    Private K(1) As Double 'concentration de K +
    Private OH(1) As Double 'concentration de OH -
    Private Ca(1) As Double 'concentration de Ca 2+
    Private SO4(1) As Double 'concentration de SO4 2-

    Private Node_w(1) As Double ' isotherm indicator
    Private Jx_cap(1) As Double 'xuande, flux de capillarite direction x
    Private Jy_cap(1) As Double 'xuande, flux de capillarite direction y
    Private Jx_dif(1) As Double 'xuande, flux de diffusion hydrique direction x
    Private Jy_dif(1) As Double 'xuande, flux de diffusion hydrique direction y
    Private Jx_thm(1) As Double 'xuande, flux de diffusion thermique direction x
    Private Jy_thm(1) As Double 'xuande, flux de diffusion thermique direction y
    Private Jx_ion(1) As Double 'xuande, flux ionique direction x
    Private Jy_ion(1) As Double 'xuande, flux ionique direction y
    Private Jx_Na(1) As Double 'xuande, flux Na + direction x 2021.09.03 Xuande Chen
    Private Jy_Na(1) As Double 'xuande, flux Na + direction y
    Private Jx_Cl(1) As Double 'xuande, flux Cl - direction x 2021.09.03 Xuande Chen
    Private Jy_Cl(1) As Double 'xuande, flux Cl - direction y
    Private Jx_K(1) As Double 'xuande, flux K + direction x 2021.09.03 Xuande Chen
    Private Jy_K(1) As Double 'xuande, flux K + direction y
    Private Jx_OH(1) As Double 'xuande, flux OH - direction x 2021.09.03 Xuande Chen
    Private Jy_OH(1) As Double 'xuande, flux OH - direction y
    Private Jx_Ca(1) As Double 'xuande, flux Ca 2+ direction x 2021.09.03 Xuande Chen
    Private Jy_Ca(1) As Double 'xuande, flux CA 2+ direction y
    Private Jx_SO4(1) As Double 'xuande, flux SO4 2- direction x 2021.09.03 Xuande Chen
    Private Jy_SO4(1) As Double 'xuande, flux SO4 2- direction y
    Public Sub New(nn As Integer, x As Double, y As Double, z As Double, NumExpo As Integer, TypeExpo As String)

        _NodeNumber = nn
        _x = x
        _y = y
        _z = z
        _NumExpo = NumExpo
        _TypeExpo = TypeExpo

    End Sub

    Public Sub SetFieldsNew(ByRef HRval As Double, ByRef Slval As Double, ByRef Wlval As Double, ByRef Tval As Double, ByRef Naval As Double, ByRef Clval As Double, ByRef Kval As Double, ByRef OHval As Double, ByRef Caval As Double, ByRef SO4val As Double)

        HR(1) = HRval
        Sl(1) = Slval
        Wl(1) = Wlval
        T(1) = Tval
        Na(1) = Naval
        Cl(1) = Clval
        K(1) = Kval
        OH(1) = OHval
        Ca(1) = Caval
        SO4(1) = SO4val

    End Sub
    'isotherm indicator , xuande 2020.08.28
    Public Sub SetIndicatorNew(ByRef w_val As Double)

        Node_w(1) = w_val

    End Sub
    'flux , xuande 2020.08.28
    Public Sub SetThermoFluxNew(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_thm(1) = Jx_val
        Jy_thm(1) = Jy_val

    End Sub
    Public Sub SetCapillaryFluxNew(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_cap(1) = Jx_val
        Jy_cap(1) = Jy_val

    End Sub
    Public Sub SetDiffusionFluxNew(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_dif(1) = Jx_val
        Jy_dif(1) = Jy_val

    End Sub
    Public Sub SetIonicFluxNew(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_ion(1) = Jx_val
        Jy_ion(1) = Jy_val

    End Sub
    Public Sub SetNaFluxNew(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_Na(1) = Jx_val
        Jy_Na(1) = Jy_val

    End Sub
    Public Sub SetClFluxNew(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_Cl(1) = Jx_val
        Jy_Cl(1) = Jy_val

    End Sub
    Public Sub SetKFluxNew(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_K(1) = Jx_val
        Jy_K(1) = Jy_val

    End Sub
    Public Sub SetOHFluxNew(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_OH(1) = Jx_val
        Jy_OH(1) = Jy_val

    End Sub
    Public Sub SetCaFluxNew(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_Ca(1) = Jx_val
        Jy_Ca(1) = Jy_val

    End Sub
    Public Sub SetSO4FluxNew(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_SO4(1) = Jx_val
        Jy_SO4(1) = Jy_val

    End Sub
    Public Sub SetFieldsOld(ByRef HRval As Double, ByRef Slval As Double, ByRef Wlval As Double, ByRef Tval As Double, ByRef Naval As Double, ByRef Clval As Double, ByRef Kval As Double, ByRef OHval As Double, ByRef Caval As Double, ByRef SO4val As Double)

        HR(0) = HRval
        Sl(0) = Slval
        Wl(0) = Wlval
        T(0) = Tval
        Na(0) = Naval 'Xuande Chen 2021.09.01
        Cl(0) = Clval
        K(0) = Kval
        OH(0) = OHval
        Ca(0) = Caval
        SO4(0) = SO4val

    End Sub
    'isotherm indicator , xuande 2020.08.28
    Public Sub SetIndicatorOld(ByRef w_val As Double)

        Node_w(0) = w_val

    End Sub
    'flux , xuande 2020.08.28
    Public Sub SetThermoFluxOld(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_thm(0) = Jx_val
        Jy_thm(0) = Jy_val

    End Sub
    Public Sub SetCapillaryFluxOld(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_cap(0) = Jx_val
        Jy_cap(0) = Jy_val

    End Sub
    Public Sub SetDiffusionFluxOld(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_dif(0) = Jx_val
        Jy_dif(0) = Jy_val

    End Sub
    Public Sub SetNaFluxOld(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_Na(0) = Jx_val
        Jy_Na(0) = Jy_val

    End Sub
    Public Sub SetClFluxOld(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_Cl(0) = Jx_val
        Jy_Cl(0) = Jy_val

    End Sub
    Public Sub SetKFluxOld(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_K(0) = Jx_val
        Jy_K(0) = Jy_val

    End Sub
    Public Sub SetOHFluxOld(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_OH(0) = Jx_val
        Jy_OH(0) = Jy_val

    End Sub
    Public Sub SetCaFluxOld(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_Ca(0) = Jx_val
        Jy_Ca(0) = Jy_val

    End Sub
    Public Sub SetSO4FluxOld(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_SO4(0) = Jx_val
        Jy_SO4(0) = Jy_val

    End Sub
    Public Sub SetIonicFluxOld(ByRef Jx_val As Double, ByRef Jy_val As Double)

        Jx_ion(0) = Jx_val
        Jy_ion(0) = Jy_val

    End Sub
    Public Sub SetFieldsNewToOld()

        HR(0) = HR(1)
        Sl(0) = Sl(1)
        Wl(0) = Wl(1)
        T(0) = T(1)
        Na(0) = Na(1) 'Xuande, 2021.09.03
        Cl(0) = Cl(1)
        K(0) = K(1)
        OH(0) = OH(1)
        Ca(0) = Ca(1)
        SO4(0) = SO4(1)

    End Sub
    'isotherm indicator , xuande 2020.08.28
    Public Sub SetIndicatorNewToOld()

        Node_w(0) = Node_w(1)

    End Sub

    'flux , xuande 2020.08.28
    Public Sub SetThermoFluxNewToOld()

        Jx_thm(0) = Jx_thm(1)
        Jy_thm(0) = Jy_thm(1)

    End Sub
    Public Sub SetCapillaryFluxNewToOld()

        Jx_cap(0) = Jx_cap(1)
        Jy_cap(0) = Jy_cap(1)

    End Sub
    Public Sub SetDiffusionFluxNewToOld()

        Jx_dif(0) = Jx_dif(1)
        Jy_dif(0) = Jy_dif(1)

    End Sub
    Public Sub SetIonicFluxNewToOld()

        Jx_ion(0) = Jx_ion(1)
        Jy_ion(0) = Jy_ion(1)

    End Sub
    Public Sub SetNaFluxNewToOld()

        Jx_Na(0) = Jx_Na(1)
        Jy_Na(0) = Jy_Na(1)

    End Sub
    Public Sub SetClFluxNewToOld()

        Jx_Cl(0) = Jx_Cl(1)
        Jy_Cl(0) = Jy_Cl(1)

    End Sub
    Public Sub SetKFluxNewToOld()

        Jx_K(0) = Jx_K(1)
        Jy_K(0) = Jy_K(1)

    End Sub
    Public Sub SetOHFluxNewToOld()

        Jx_OH(0) = Jx_OH(1)
        Jy_OH(0) = Jy_OH(1)

    End Sub
    Public Sub SetCaFluxNewToOld()

        Jx_Ca(0) = Jx_Ca(1)
        Jy_Ca(0) = Jy_Ca(1)

    End Sub
    Public Sub SetSO4FluxNewToOld()

        Jx_SO4(0) = Jx_SO4(1)
        Jy_SO4(0) = Jy_SO4(1)

    End Sub
    Public Function GetHROld() As Double

        Return HR(0)

    End Function
    Public Function GetSOld() As Double

        Return Sl(0)

    End Function
    Public Function GetWOld() As Double

        Return Wl(0)

    End Function
    Public Function GetTOld() As Double

        Return T(0)

    End Function
    Public Function GetNaOld() As Double

        Return Na(0)

    End Function
    Public Function GetClOld() As Double

        Return Cl(0)

    End Function
    Public Function GetKOld() As Double

        Return K(0)

    End Function
    Public Function GetOHOld() As Double

        Return OH(0)

    End Function
    Public Function GetCaOld() As Double

        Return Ca(0)

    End Function
    Public Function GetSO4Old() As Double

        Return SO4(0)

    End Function
    'flux , xuande 2020.08.28
    Public Function GetThermoFluxXOld() As Double

        Return Jx_thm(0)

    End Function
    Public Function GetThermoFluxYOld() As Double

        Return Jy_thm(0)

    End Function
    Public Function GetCapillaryFluxXOld() As Double

        Return Jx_cap(0)

    End Function
    Public Function GetCapillaryFluxYOld() As Double

        Return Jy_cap(0)

    End Function
    Public Function GetDiffusionFluxXOld() As Double

        Return Jx_dif(0)

    End Function
    Public Function GetDiffusionFluxYOld() As Double

        Return Jy_dif(0)

    End Function
    Public Function GetIonicFluxXOld() As Double

        Return Jx_ion(0)

    End Function
    Public Function GetIonicFluxYOld() As Double

        Return Jy_ion(0)

    End Function
    Public Function GetNaFluxXOld() As Double

        Return Jx_Na(0)

    End Function
    Public Function GetNaFluxYOld() As Double

        Return Jy_Na(0)

    End Function
    Public Function GetClFluxXOld() As Double

        Return Jx_Cl(0)

    End Function
    Public Function GetClFluxYOld() As Double

        Return Jy_Cl(0)

    End Function
    Public Function GetKFluxXOld() As Double

        Return Jx_K(0)

    End Function
    Public Function GetKFluxYOld() As Double

        Return Jy_K(0)

    End Function
    Public Function GetOHFluxXOld() As Double

        Return Jx_OH(0)

    End Function
    Public Function GetOHFluxYOld() As Double

        Return Jy_OH(0)

    End Function
    Public Function GetCaFluxXOld() As Double

        Return Jx_Ca(0)

    End Function
    Public Function GetCaFluxYOld() As Double

        Return Jy_Ca(0)

    End Function
    Public Function GetSO4FluxXOld() As Double

        Return Jx_SO4(0)

    End Function
    Public Function GetSO4FluxYOld() As Double

        Return Jy_SO4(0)

    End Function
    Public Function GetHRNew() As Double

        Return HR(1)

    End Function
    Public Function GetSNew() As Double

        Return Sl(1)

    End Function
    Public Function GetWNew() As Double

        Return Wl(1)

    End Function
    Public Function GetTNew() As Double

        Return T(1)

    End Function
    Public Function GetNaNew() As Double

        Return Na(1)

    End Function
    Public Function GetClNew() As Double

        Return Cl(1)

    End Function
    Public Function GetKNew() As Double

        Return K(1)

    End Function
    Public Function GetOHNew() As Double

        Return OH(1)

    End Function
    Public Function GetCaNew() As Double

        Return Ca(1)

    End Function
    Public Function GetSO4New() As Double

        Return SO4(1)

    End Function
    'flux , xuande 2020.08.28
    Public Function GetThermoFluxXNew() As Double

        Return Jx_thm(1)

    End Function
    Public Function GetThermoFluxYNew() As Double

        Return Jy_thm(1)

    End Function
    Public Function GetCapillaryFluxXNew() As Double

        Return Jx_cap(1)

    End Function
    Public Function GetCapillaryFluxYNew() As Double

        Return Jy_cap(1)

    End Function
    Public Function GetDiffusionFluxXNew() As Double

        Return Jx_dif(1)

    End Function
    Public Function GetDiffusionFluxYNew() As Double

        Return Jy_dif(1)

    End Function
    Public Function GetIonicFluxXNew() As Double

        Return Jx_ion(1)

    End Function
    Public Function GetIonicFluxYNew() As Double

        Return Jy_ion(1)

    End Function
    Public Function GetNaFluxXNew() As Double

        Return Jx_Na(1)

    End Function
    Public Function GetNaFluxYNew() As Double

        Return Jy_Na(1)

    End Function
    Public Function GetClFluxXNew() As Double

        Return Jx_Cl(1)

    End Function
    Public Function GetClFluxYNew() As Double

        Return Jy_Cl(1)

    End Function
    Public Function GetKFluxXNew() As Double

        Return Jx_K(1)

    End Function
    Public Function GetKFluxYNew() As Double

        Return Jy_K(1)

    End Function
    Public Function GetOHFluxXNew() As Double

        Return Jx_OH(1)

    End Function
    Public Function GetOHFluxYNew() As Double

        Return Jy_OH(1)

    End Function
    Public Function GetCaFluxXNew() As Double

        Return Jx_Ca(1)

    End Function
    Public Function GetCaFluxYNew() As Double

        Return Jy_Ca(1)

    End Function
    Public Function GetSO4FluxXNew() As Double

        Return Jx_SO4(1)

    End Function
    Public Function GetSO4FluxYNew() As Double

        Return Jy_SO4(1)

    End Function
End Class
