Public Class Configs
    Dim SelectedModpack, Lang, Message1, Message2 As String
    Private Sub Config_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        MsgBox(Message1)
        e.Cancel = True
    End Sub

    Private Sub Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Codes.CreateLangList()
        Codes.CreateModpackList()
        ListBox1.Text = SelectedModpack
        ComboBox1.Text = Lang
        ListBox1_SelectedIndexChanged()
    End Sub

    Sub SetVariable(ByVal a As String, ByVal b As String)
        If a = "SelectedModpack" Then SelectedModpack = b
        If a = "Lang" Then Lang = b
        If a = "Message1" Then Message1 = b
        If a = "Message2" Then Message2 = b
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Main.SetVariable("Lang", ComboBox1.Text)
        Codes.LoadLang(ComboBox1.Text)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged() Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex = -1 Then
            Button1.Enabled = False
            Button2.Enabled = False
        Else
            Button1.Enabled = True
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Codes.reset()
        Main.SetVariable("SelectedModpack", ListBox1.Text)
        Codes.LoadModpackSetting(ListBox1.Text)
        Main.UpdateLabel3()
        Me.Hide()
        Main.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tmp As String = Message2
        tmp = tmp.Replace("<Selected_Modpack>", ListBox1.Text)
        Dim selection As UShort = MsgBox(tmp, MsgBoxStyle.YesNo)
        If selection = 6 Then
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.CurrentDirectory & "\Modpacker\Modpacks\" & ListBox1.Text)
            ListBox1.Items.Remove(ListBox1.Text)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim a As UShort = FolderBrowserDialog1.ShowDialog
        If a = 1 Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
            Main.SetVariable("MinecraftPath", FolderBrowserDialog1.SelectedPath)
        End If
    End Sub
End Class