Public Class Main
    Dim ModpackTitle, MCVersion, ForgeVer, MinecraftPath, Lang, SelectedModpack As String
    Dim Modname(), ModAuthers(), ModVer(), Modpage(), ModLicenseLink(), ModDescription(), ModDownloadLink(), Modselected() As String
    Dim Button3_Enable, Button3_Disable As String
    Dim CurrentModname, CurrentModAuthers, CurrentModVer, CurrentModpage, CurrentModLicenseLink As String
    Dim Message1 As String
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Codes.SaveConfig(MinecraftPath, Lang, SelectedModpack)
    End Sub

    Sub SetVariable(ByVal a As String, ByVal b As String)
        If a = "ModpackTitle" Then
            ModpackTitle = b
            Me.Text = b
        End If
        If a = "MCVersion" Then MCVersion = b
        If a = "MinecraftPath" Then MinecraftPath = b
        If a = "ForgeVer" Then ForgeVer = b
        If a = "Lang" Then Lang = b
        If a = "SelectedModpack" Then SelectedModpack = b
        If a = "Button3_Enable" Then Button3_Enable = b
        If a = "Button3_Disable" Then Button3_Disable = b
        If a = "CurrentModname" Then CurrentModname = b
        If a = "CurrentModAuthers" Then CurrentModAuthers = b
        If a = "CurrentModVer" Then CurrentModVer = b
        If a = "Message1" Then Message1 = b
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Modpacker still in development!" & vbCrLf & "It is licensed under GNU GPL V3!")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Button2_Click()
    End Sub
    Private Sub Button2_Click() Handles Button2.Click
        Me.Hide()
        Codes.CheckConfig()
        Configs.SetVariable("SelectedModpack", SelectedModpack)
        Configs.SetVariable("Lang", Lang)
        Codes.LoadLang(Lang)
        Configs.Show()
    End Sub
    Sub ModRegister(ByVal a As String, ByVal b As String, ByVal c As String, ByVal d As String, ByVal e As String, ByRef f As String, ByVal g As String, ByVal h As String, ByVal i As Integer)
        Modname(i) = a
        ModAuthers(i) = b
        ModVer(i) = c
        Modpage(i) = d
        ModLicenseLink(i) = e
        ModDescription(i) = f
        ModDownloadLink(i) = g
        Modselected(i) = h
        If h = "true" Then
            ListBox1.Items.Add(a)
        Else
            ListBox2.Items.Add(a)
        End If
    End Sub
    Sub RedimVAR(ByVal a As Integer)
        ReDim Modname(a)
        ReDim ModAuthers(a)
        ReDim ModVer(a)
        ReDim Modpage(a)
        ReDim ModLicenseLink(a)
        ReDim ModDescription(a)
        ReDim ModDownloadLink(a)
        ReDim Modselected(a)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If Not ListBox1.SelectedIndex = -1 Then
            ListBox2.SelectedIndex = -1
            Button3.Text = Button3_Disable
            Button3.Visible = True
            LinkLabel1.Visible = True
            LinkLabel2.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            TextBox2.Visible = True
            For i = 0 To Modname.Length - 1
                If Modname(i) = ListBox1.Text Then
                    If CurrentModname = "" Then
                        LinkLabel1.Text = LinkLabel1.Text.Replace("<Mod_name>", Modname(i))
                    Else
                        LinkLabel1.Text = LinkLabel1.Text.Replace(CurrentModname, Modname(i))
                    End If

                    If CurrentModVer = "" Then
                        Label4.Text = Label4.Text.Replace("<Mod_Ver>", ModVer(i))
                    Else
                        Label4.Text = Label4.Text.Replace(CurrentModVer, ModVer(i))
                    End If

                    If CurrentModAuthers = "" Then
                        Label5.Text = Label5.Text.Replace("<Mod_Auther(s)>", ModAuthers(i))
                    Else
                        Label5.Text = Label5.Text.Replace(CurrentModAuthers, ModAuthers(i))
                    End If

                    CurrentModname = Modname(i)
                    CurrentModVer = ModVer(i)
                    CurrentModAuthers = ModAuthers(i)
                    TextBox2.Text = ModDescription(i)
                    CurrentModpage = Modpage(i)
                    CurrentModLicenseLink = ModLicenseLink(i)
                End If
            Next
        Else
            Button3.Visible = False
            LinkLabel1.Visible = False
            LinkLabel2.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            TextBox2.Visible = False
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        If Not ListBox2.SelectedIndex = -1 Then
            ListBox1.SelectedIndex = -1
            Button3.Text = Button3_Enable
            Button3.Visible = True
            LinkLabel1.Visible = True
            LinkLabel2.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            TextBox2.Visible = True
            For i = 0 To Modname.Length - 1
                If Modname(i) = ListBox2.Text Then
                    If CurrentModname = "" Then
                        LinkLabel1.Text = LinkLabel1.Text.Replace("<Mod_name>", Modname(i))
                    Else
                        LinkLabel1.Text = LinkLabel1.Text.Replace(CurrentModname, Modname(i))
                    End If

                    If CurrentModVer = "" Then
                        Label4.Text = Label4.Text.Replace("<Mod_Ver>", ModVer(i))
                    Else
                        Label4.Text = Label4.Text.Replace(CurrentModVer, ModVer(i))
                    End If

                    If CurrentModAuthers = "" Then
                        Label5.Text = Label5.Text.Replace("<Mod_Auther(s)>", ModAuthers(i))
                    Else
                        Label5.Text = Label5.Text.Replace(CurrentModAuthers, ModAuthers(i))
                    End If

                    CurrentModname = Modname(i)
                    CurrentModVer = ModVer(i)
                    CurrentModAuthers = ModAuthers(i)
                    TextBox2.Text = ModDescription(i)
                    CurrentModpage = Modpage(i)
                    CurrentModLicenseLink = ModLicenseLink(i)
                End If
            Next
        Else
            Button3.Visible = False
            LinkLabel1.Visible = False
            LinkLabel2.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            TextBox2.Visible = False
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = Button3_Enable Then
            ListBox1.Items.Add(ListBox2.Text)
            ListBox2.Items.Remove(ListBox2.Text)
        Else
            ListBox2.Items.Add(ListBox1.Text)
            ListBox1.Items.Remove(ListBox1.Text)
        End If
        Button3.Visible = False
    End Sub

    Sub UpdateLabel3()
        Label3.Text = Label3.Text.Replace("<MCVersion>", MCVersion)
        Label3.Text = Label3.Text.Replace("<ForgeVer>", ForgeVer)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(CurrentModpage)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start(CurrentModLicenseLink)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ListBox1.Items.Count = 0 Then
            MsgBox(Message1, 16, ModpackTitle)
        Else
            Install.TextBox1.Text = ""
            Install.RedimVar(ListBox1.Items.Count - 1)
            For i = 0 To ListBox1.Items.Count - 1
                For j = 0 To Modname.Length - 1
                    If ListBox1.Items.Item(i) = Modname(j) Then
                        Install.Receive_Mod_List(Modname(j), ModDownloadLink(j), i)
                    End If
                Next
            Next
            Install.TextBox1.Text = "O Mod list loaded successful."
            Me.Hide()
            Install.Show()
        End If
    End Sub
End Class
