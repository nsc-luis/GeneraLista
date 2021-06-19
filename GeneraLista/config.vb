Imports System
Imports System.IO
Imports System.Text
Public Class config
    Private Sub config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim diractual As String = Directory.GetCurrentDirectory()
        Dim confip = diractual + "\ip.conf"
        If My.Computer.FileSystem.FileExists(confip) Then
            Dim fconfigip = My.Computer.FileSystem.ReadAllText(confip)
            rtc.Text = fconfigip
        Else
            MsgBox("No se ha encontrado el archivo ip.conf en el directorio actual", vbCritical, "Error")
        End If
    End Sub

    Private Sub Cerrar_Click(sender As Object, e As EventArgs) Handles Cerrar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim diractual As String = Directory.GetCurrentDirectory()
        Dim confip = diractual + "\ip.conf"


        System.Diagnostics.Process.Start("notepad.exe", confip)

        Form1.Refresh()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim diractual As String = Directory.GetCurrentDirectory()
        Dim confip = diractual + "\ip.conf"
        If My.Computer.FileSystem.FileExists(confip) Then
            Dim fconfigip = My.Computer.FileSystem.ReadAllText(confip)
            rtc.Text = fconfigip
        Else
            MsgBox("No se ha encontrado el archivo ip.conf en el directorio actual", vbCritical, "Error")
        End If
    End Sub
End Class