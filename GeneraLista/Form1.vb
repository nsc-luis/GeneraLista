Imports System
Imports System.IO
Imports System.Text
Public Class Form1

    Dim diractual As String = Directory.GetCurrentDirectory()
    Dim dirlista = diractual + "\lista.txt"
    Dim dirbat = diractual + "\copiaNvaVersion.bat"
    Dim dirlog = diractual + "\makelog.bat"
    Dim dir = "192.168.123.12\act_alv_paqmex"
    Dim dir1 = "\\" + dir
    Dim var()
    Dim confip = diractual + "\ip.conf"
    Dim confsis = diractual + "\sis.conf"

    Dim fconfigip
    Dim vsucursales

    Dim fconfigsis = My.Computer.FileSystem.ReadAllText(confsis)
    Dim vsistemas = Split(fconfigsis, vbCrLf)

    Dim iniALV = "ini\ALV|*.ini"
    Dim iniPQ = "ini\PAQMEX|*.ini"
    Dim lnkALV32 = "lnk\32bits\ALV|*.lnk"
    Dim lnkALV64 = "lnk\64bits\ALV|*.lnk"
    Dim lnkPQ32 = "lnk\32bits\PAQMEX|*.lnk"
    Dim lnkPQ64 = "lnk\64bits\PAQMEX|*.lnk"

    Dim vcbsucursales() As Boolean
    Dim vcbsistemas() As Boolean

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(confip) Then
        Else
            MsgBox("No se ha encontrado el archivo ip.conf en el directorio actual", vbCritical, "Error")
            Me.Close()
        End If
        If My.Computer.FileSystem.FileExists(diractual + "\logs") Then
        Else
            My.Computer.FileSystem.CreateDirectory(diractual + "\logs")
        End If
        If My.Computer.FileSystem.FileExists(dirlista) Then
        Else
            Dim path As String = dirlista
            Dim fs As FileStream = File.Create(path)
            fs.Close()
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles cbALL.CheckedChanged
        If cbALL.Checked = True Then

            bALV.Enabled = False
            bPaqMex.Enabled = False
            bClear.Enabled = False

            For Each chk As CheckBox In PanelALV.Controls.OfType(Of CheckBox)
                chk.Checked = True
                chk.Enabled = False
            Next
            For Each chk As CheckBox In PanelPaqMex.Controls.OfType(Of CheckBox)
                chk.Checked = True
                chk.Enabled = False
            Next
        Else

            bALV.Enabled = True
            bPaqMex.Enabled = True
            bClear.Enabled = True

            For Each chk As CheckBox In PanelALV.Controls.OfType(Of CheckBox)
                chk.Checked = False
                chk.Enabled = True

            Next
            For Each chk As CheckBox In PanelPaqMex.Controls.OfType(Of CheckBox)
                chk.Checked = False
                chk.Enabled = True

            Next
        End If
        cbALL.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cbGG.CheckedChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_genera.Click
        Dim path As String = dirlista
        Dim fs As FileStream = File.Create(path)
        fs.Close()
        Button4_Click_1(sender, e)
    End Sub

    Private Sub CheckBox30_CheckedChanged(sender As Object, e As EventArgs) Handles cbMANUAL.CheckedChanged
        If cbMANUAL.Checked = True Then
            tbDIR.Enabled = True
            Button9.Enabled = True
            Button11.Enabled = True
        Else
            tbDIR.Enabled = False
            Button9.Enabled = False
            Button11.Enabled = False
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btn_ver.Click
        System.Diagnostics.Process.Start("notepad.exe", dirlista)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_eje.Click
        If My.Computer.FileSystem.FileExists(dirbat) Then
            If cblog.Checked = True Then
                If My.Computer.FileSystem.FileExists(dirlog) Then
                    Shell(dirlog, AppWinStyle.NormalFocus, True)
                    If MsgBox("Proceso Finalizado" + vbCrLf + "¿Desea abrir la carpeta de logs?", vbYesNo, "Completado") = vbYes Then
                        Process.Start("explorer.exe", diractual + "\logs")
                    End If
                Else
                    MsgBox("No se ha encontrado el archivo makelog.bat en el directorio actual", vbCritical, "Error")
                End If
            Else
                Shell(dirbat, AppWinStyle.NormalFocus, True)
                MsgBox("Proceso Finalizado", vbOKOnly, "Completado")
            End If
        Else
            MsgBox("No se ha encontrado el archivo copiaNvaVersion.bat en el directorio actual", vbCritical, "Error")
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles btn_agrega.Click
        fconfigip = My.Computer.FileSystem.ReadAllText(confip)
        vsucursales = Split(fconfigip, vbCrLf)

        vcbsucursales = {cbTA.Checked, cbVALL.Checked, cbTH.Checked, cbGG.Checked, cbRM.Checked, cbTAM.Checked, cbQRO.Checked, cbPUE.Checked, cbSL.Checked, cbMOC.Checked, cbLEON.Checked, cbTEP.Checked, cbMAZ.Checked, cbCLN.Checked, cbHER.Checked, cbOBR.Checked, cbAGU.Checked, cbIZT.Checked, cbTOL.Checked, cbTOR.Checked}
        vcbsistemas = {cbPAQELEC.Checked, cbPAQ.Checked, cbCONTAB.Checked, cbTRAFICO.Checked, cbTALLER.Checked, cbPAQELECPQ.Checked, cbPAQPQ.Checked, cbCONTABPQ.Checked, cbTRAFICOPQ.Checked, cbTALLERPQ.Checked, cbISO.Checked, cbCONTROLD.Checked, cbDIG.Checked, cbDIGPQ.Checked, cbini.Checked, cblnk.Checked, cbMANUAL.Checked}
        Dim sucursal = ""
        Dim sistema = ""
        Dim linea = ""
        Dim tvsucursales = vsucursales.Length - 1
        Dim tvsistemas = vsistemas.Length - 1
        Dim archivosplit
        Dim tarchivosplit
        Dim contador = 0

        For isempty = 0 To tvsucursales
            If vcbsucursales(isempty) = True Then
                contador = contador + 1
            End If
        Next
        If contador = 0 Then
            MsgBox("Debe seleccionar almenos una sucursal", vbExclamation, "Error")
            Exit Sub
        End If
        contador = 0
        For isempty = 0 To tvsistemas
            If vcbsistemas(isempty) = True Then
                contador = contador + 1
            End If
        Next
        If contador = 0 Then
            MsgBox("Debe seleccionar sistema(s) o archivo a copiar", vbExclamation, "Error")
            Exit Sub
        End If
        For countsuc = 0 To tvsucursales
            If vcbsucursales(countsuc) = True Then
                sucursal = vsucursales(countsuc)
                For countsis = 0 To tvsistemas - 3
                    If vcbsistemas(countsis) = True Then
                        sistema = vsistemas(countsis)
                        linea = sucursal + sistema + vbCrLf
                        My.Computer.FileSystem.WriteAllText(dirlista, linea, True)
                    End If
                Next
                If cbini.Checked = True Then
                    My.Computer.FileSystem.WriteAllText(dirlista, sucursal + iniALV + vbCrLf, True)
                    My.Computer.FileSystem.WriteAllText(dirlista, sucursal + iniPQ + vbCrLf, True)
                End If
                If cblnk.Checked = True Then
                    My.Computer.FileSystem.WriteAllText(dirlista, sucursal + lnkALV32 + vbCrLf, True)
                    My.Computer.FileSystem.WriteAllText(dirlista, sucursal + lnkALV64 + vbCrLf, True)
                    My.Computer.FileSystem.WriteAllText(dirlista, sucursal + lnkPQ32 + vbCrLf, True)
                    My.Computer.FileSystem.WriteAllText(dirlista, sucursal + lnkPQ64 + vbCrLf, True)
                End If
                If vcbsistemas(tvsistemas) = True Then
                    sistema = ""
                    archivosplit = Split(tbDIR.Text, "\")
                    tarchivosplit = archivosplit.Length - 1
                    For countsplit = 0 To tarchivosplit - 1
                        sistema = sistema + archivosplit(countsplit)
                        If countsplit <> archivosplit.Length - 2 Then
                            sistema = sistema + "\"
                        End If
                    Next
                    sistema = sistema + "|" + archivosplit(tarchivosplit)
                    linea = sucursal + sistema + vbCrLf
                    My.Computer.FileSystem.WriteAllText(dirlista, linea, True)
                End If
            End If
        Next
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbDIR.Text = ""
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim path As String = dirlista
        Dim fs As FileStream = File.Create(path)
        fs.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        For Each chk As CheckBox In pALV.Controls.OfType(Of CheckBox)
            chk.Checked = True
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        For Each chk As CheckBox In pPaqMex.Controls.OfType(Of CheckBox)
            chk.Checked = True
        Next
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        For Each chk As CheckBox In pALV.Controls.OfType(Of CheckBox)
            chk.Checked = False
        Next
        For Each chk As CheckBox In pPaqMex.Controls.OfType(Of CheckBox)
            chk.Checked = False
        Next
        For Each chk As CheckBox In pOtro.Controls.OfType(Of CheckBox)
            chk.Checked = False
        Next
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim archivo = ""
        Dim archivosplit
        Dim tarchivosplit
        Dim sistema = ""

        OpenFileDialog1.InitialDirectory = dir1
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ' List files in the folder.
            archivo = (OpenFileDialog1.FileName)
        End If
        archivosplit = Split(archivo, "\")
        tarchivosplit = archivosplit.Length - 1
        For countsplit = 0 To tarchivosplit
            sistema = sistema + archivosplit(countsplit)
            If sistema = dir Then
                sistema = ""
            End If
            If countsplit <> tarchivosplit And sistema <> "" Then
                sistema = sistema + "\"
            End If
        Next
        tbDIR.Text = sistema
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btn_gen_ejec.Click
        Button1_Click(sender, e)
        Button2_Click(sender, e)
    End Sub

    Private Sub bALV_Click(sender As Object, e As EventArgs) Handles bALV.Click
        For Each chk As CheckBox In PanelALV.Controls.OfType(Of CheckBox)
            chk.Checked = True
        Next
    End Sub

    Private Sub bClear_Click(sender As Object, e As EventArgs) Handles bClear.Click
        For Each chk As CheckBox In PanelPaqMex.Controls.OfType(Of CheckBox)
            chk.Checked = False
        Next
        For Each chk As CheckBox In PanelALV.Controls.OfType(Of CheckBox)
            chk.Checked = False
        Next
    End Sub

    Private Sub bPaqMex_Click(sender As Object, e As EventArgs) Handles bPaqMex.Click
        For Each chk As CheckBox In PanelPaqMex.Controls.OfType(Of CheckBox)
            chk.Checked = True
        Next
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        config.ShowDialog()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles cbAGU.CheckedChanged

    End Sub

    Private Sub cbLEON_CheckedChanged(sender As Object, e As EventArgs) Handles cbLEON.CheckedChanged

    End Sub

    Private Sub cbIztapalapa_CheckedChanged(sender As Object, e As EventArgs) Handles cbIZT.CheckedChanged

    End Sub
End Class
