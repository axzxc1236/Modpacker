Imports System.Net
Public Class Install
    Dim Modname(), ModDownloadLink() As String


    Private Sub Install_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub
    Sub Receive_Mod_List(ByVal a As String, ByVal b As String, ByVal c As Integer)
        Modname(c) = a
        ModDownloadLink(c) = b
        ListBox1.Items.Add(a)
    End Sub

    Sub RedimVar(ByVal a As Integer)
        ReDim Modname(a)
        ReDim ModDownloadLink(a)
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.CurrentDirectory & "\Modpacker\tmp") Then My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.CurrentDirectory & "\Modpacker\tmp", FileIO.DeleteDirectoryOption.DeleteAllContents)
        My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.CurrentDirectory & "\Modpacker\tmp")
        Dim filename() As String
        Dim download As New WebClient
        Install.CheckForIllegalCrossThreadCalls = False

        For i = 0 To ListBox1.Items.Count - 1
            TextBox1.Text = TextBox1.Text & vbCrLf & "Started to Download Mod " & Modname(i)
            filename = Split(ModDownloadLink(i), "/")
            'My.Computer.Network.DownloadFile(ModDownloadLink(i), My.Computer.FileSystem.CurrentDirectory & "\Modpacker\tmp\" & filename(filename.Length - 1))
            'DownloadFile(ModDownloadLink(i), filename(filename.Length - 1))
            download.DownloadDataAsync(New Uri(ModDownloadLink(i)), My.Computer.FileSystem.CurrentDirectory & "\Modpacker\tmp\" & filename(filename.Length - 1))
            TextBox1.Text = TextBox1.Text & vbCrLf & "O Mod " & Modname(i) & " Downloaded successful."
        Next
    End Sub

    Private Sub Install_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBox1.Text = TextBox1.Text & vbCrLf & "Mod downloader is started."
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    'Sub DownloadFile(ByVal a As String, ByVal b As String)
    '    'AddHandler download.DownloadProgressChanged, AddressOf download_DownloadProgressChanged
    '    download.DownloadDataAsync(New Uri(a), My.Computer.FileSystem.CurrentDirectory & "\Modpacker\tmp\" & b)
    'End Sub
    'Private Sub download_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles download.DownloadProgressChanged
    '    'If e.ProgressPercentage = 10 Then MsgBox("1")
    '    ProgressBar1.Value = e.ProgressPercentage
    'End Sub
End Class