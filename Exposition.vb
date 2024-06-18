Imports System.Linq

Public Class Exposition

    Public Property Humidite() As Double()
    Public Property Sel() As Double()
    Public Property Temperature() As Double()
    ' Xuande, 2021.09.05
    Public Property Conc_Na() As Double() 'Na + concentration
    Public Property Conc_Cl() As Double() 'Na + concentration
    Public Property Conc_K() As Double() 'Na + concentration
    Public Property Conc_OH() As Double() 'Na + concentration
    Public Property Conc_Ca() As Double() 'Na + concentration
    Public Property Conc_SO4() As Double() 'Na + concentration
    'Xuande 2020.10.28
    Public Property JHumidite() As Double() 'Humidity boundary flux
    Public Property JSel() As Double() 'Salt boundary flux
    Public Property JTemperature() As Double() 'Temperature boundary flux
    ' Xuande 2021.09.05
    Public Property JNa() As Double() 'Na + boundary flux
    Public Property JCl() As Double() 'Cl - boundary flux
    Public Property JK() As Double() 'K + boundary flux
    Public Property JOH() As Double() 'OH - boundary flux
    Public Property JCa() As Double() 'Ca 2+ boundary flux
    Public Property JSO4() As Double() 'SO4 2- boundary flux

    Private Dt As Single
    Private Name As String
    Private File As String = ""

    'Public TempMin As Single = 40
    'Public TempMax As Single = -30
    'Public TempEcart As Single = 0
    'Public Msel As Single = 0

    Public Sub New(ByRef FileExpo As String)

        Dim nFic As Short = CShort(FreeFile())
        Dim NbreEn As Integer

        If FileExpo.Contains(".txt") = True Then
            Try
                FileOpen(CInt(nFic), FileExpo, OpenMode.Input, OpenAccess.Read)
                FileClose(CInt(nFic))

                Dim Arr() As String = Split(FileExpo, "\"c)
                Name = Arr.Last()
                File = FileExpo
            Catch ex As Exception
                End
            End Try
        ElseIf FileExpo.Contains("Neumann") = True Then 'Xuande 2020.10.27 case zeroGradient BC applied
            Try
                File = FileExpo
                Name = FileExpo
            Catch ex As Exception
                End
            End Try
        Else
            Try
                Dim DBCon As New DBconnexion
                DBCon.DBRequest("SELECT '" + FileExpo + "' FROM ExpositionList")
                Name = FileExpo

            Catch ex As Exception
                End
            End Try
        End If

    End Sub

    Public Sub WriteExpo(ByRef ind As Integer)

        Dim nFic As Short = CShort(FreeFile())
        Dim NbreEn As Integer

        If File.Contains(".txt") = True Then

            Try

                FileOpen(CInt(nFic), File, OpenMode.Input, OpenAccess.Read)
                Input(CInt(nFic), NbreEn)
                Input(CInt(nFic), Dt)
                ReDim Humidite(ind - 1)
                ReDim Sel(ind - 1)
                ReDim Temperature(ind - 1)
                ReDim Conc_Na(ind - 1) 'Xuande 2021.09.03
                ReDim Conc_Cl(ind - 1)
                ReDim Conc_K(ind - 1)
                ReDim Conc_OH(ind - 1)
                ReDim Conc_Ca(ind - 1)
                ReDim Conc_SO4(ind - 1)
                Dim j As Integer = 0
                Dim nbboucle As Integer = 1
                For i As Integer = 0 To ind - 1

                    If i <= (NbreEn - 1) Then
                        Input(CInt(nFic), Humidite(i))
                        Input(CInt(nFic), Sel(i))
                        Input(CInt(nFic), Temperature(i))
                        Input(CInt(nFic), Conc_Na(i)) 'Xuande 2021.09.03
                        Input(CInt(nFic), Conc_Cl(i))
                        Input(CInt(nFic), Conc_K(i))
                        Input(CInt(nFic), Conc_OH(i))
                        Input(CInt(nFic), Conc_Ca(i))
                        Input(CInt(nFic), Conc_SO4(i))
                        j += 1
                    ElseIf i <= (NbreEn * nbboucle - 1) Then
                        Humidite(i) = Humidite(j)
                        Sel(i) = Sel(j)
                        Temperature(i) = Temperature(j)
                        Conc_Na(i) = Conc_Na(j) 'Xuande 2021.09.03
                        Conc_Cl(i) = Conc_Cl(j)
                        Conc_K(i) = Conc_K(j)
                        Conc_OH(i) = Conc_OH(j)
                        Conc_Ca(i) = Conc_Ca(j)
                        Conc_SO4(i) = Conc_SO4(j)
                        j += 1
                    Else
                        If nbboucle = 1 Then MsgBox("Exposition File too short. Copying the exposition in loop.")
                        j = 0
                        nbboucle += 1
                        Humidite(i) = Humidite(j)
                        Sel(i) = Sel(j)
                        Temperature(i) = Temperature(j)
                        Conc_Na(i) = Conc_Na(j) 'Xuande 2021.09.03
                        Conc_Cl(i) = Conc_Cl(j)
                        Conc_K(i) = Conc_K(j)
                        Conc_OH(i) = Conc_OH(j)
                        Conc_Ca(i) = Conc_Ca(j)
                        Conc_SO4(i) = Conc_SO4(j)
                        j += 1
                    End If
                Next

                FileClose(CInt(nFic))

            Catch ex As Exception
                End
            End Try

        ElseIf File.Contains("Neumann") = True Then 'Xuande 2020.10.27 case zeroGradient BC applied
            Try 'do nothing
                ReDim JHumidite(ind - 1)
                ReDim JSel(ind - 1)
                ReDim JTemperature(ind - 1)
                ReDim JNa(ind - 1) 'Xuande 2021.09.03
                ReDim JCl(ind - 1)
                ReDim JK(ind - 1)
                ReDim JOH(ind - 1)
                ReDim JCa(ind - 1)
                ReDim JSO4(ind - 1)
                For i As Integer = 0 To ind - 1
                    JHumidite(i) = 0
                    JSel(i) = 0
                    JTemperature(i) = 0
                    JNa(i) = 0 'Xuande 2021.09.03
                    JCl(i) = 0
                    JK(i) = 0
                    JOH(i) = 0
                    JCa(i) = 0
                    JSO4(i) = 0
                Next
            Catch ex As Exception
                End
            End Try
        Else

            Try

                Dim DBCon As New DBconnexion
                'Dim Expo As New MaterialsData

                DBCon.DBRequest("SELECT TOP " + CStr(ind) + " * FROM [" + Name + "]")
                'DBCon.MatFill(Expo, Name)

                'Dim ExpoTable()() As Object = Expo.Tables(Name).Rows.Cast(Of DataRow).Select(Function(dr) dr.ItemArray).ToArray

                'NbreEn = ExpoTable.Length()
                Dt = 3600

                ReDim Humidite(ind - 1)
                ReDim Sel(ind - 1)
                ReDim Temperature(ind - 1)
                ReDim Conc_Na(ind - 1) 'Xuande 2021.09.03
                ReDim Conc_Cl(ind - 1)
                ReDim Conc_K(ind - 1)
                ReDim Conc_OH(ind - 1)
                ReDim Conc_Ca(ind - 1)
                ReDim Conc_SO4(ind - 1)
                Dim j As Integer = 0
                Dim nbboucle As Integer = 1
                For i As Integer = 0 To ind - 1

                    If i <= (NbreEn - 1) Then
                        'Humidite(j) = ExpoTable(i)(1)
                        'Sel(j) = ExpoTable(i)(2)
                        'Temperature(j) = ExpoTable(i)(3)
                        'Conc_Na(j) = ExpoTable(i)(4)
                        'Conc_Cl(j) = ExpoTable(i)(5)
                        'Conc_K(j) = ExpoTable(i)(6)
                        'Conc_OH(j) = ExpoTable(i)(7)
                        'Conc_Ca(j) = ExpoTable(i)(8)
                        'Conc_SO4(j) = ExpoTable(i)(9)
                        j += 1
                    ElseIf i <= (NbreEn * nbboucle - 1) Then
                        Humidite(i) = Humidite(j)
                        Sel(i) = Sel(j)
                        Temperature(i) = Temperature(j)
                        Conc_Na(i) = Conc_Na(j)
                        Conc_Cl(i) = Conc_Cl(j)
                        Conc_K(i) = Conc_K(j)
                        Conc_OH(i) = Conc_OH(j)
                        Conc_Ca(i) = Conc_Ca(j)
                        Conc_SO4(i) = Conc_SO4(j)
                        j += 1
                    Else
                        If nbboucle = 1 Then MsgBox("Exposition File too short. Copying the exposition in loop.")
                        j = 0
                        nbboucle += 1
                        Humidite(i) = Humidite(j)
                        Sel(i) = Sel(j)
                        Temperature(i) = Temperature(j)
                        Conc_Na(i) = Conc_Na(j)
                        Conc_Cl(i) = Conc_Cl(j)
                        Conc_K(i) = Conc_K(j)
                        Conc_OH(i) = Conc_OH(j)
                        Conc_Ca(i) = Conc_Ca(j)
                        Conc_SO4(i) = Conc_SO4(j)
                        j += 1
                    End If
                Next

            Catch ex As Exception
                End
            End Try

        End If

    End Sub

End Class
