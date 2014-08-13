

Module Codes

    Sub CheckConfig()
        If Not My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\Modpacker\Settings") Then
            MsgBox("Fatal Error (Not really but I want 'Settings')")
            End
        Else
            LoadSettings()
        End If
    End Sub

    Sub LoadSettings()
        Dim AllSetting As String() = System.IO.File.ReadAllLines(My.Computer.FileSystem.CurrentDirectory & "\Modpacker\Settings")
        Dim tmp As String()
        For i = 0 To AllSetting.Length - 1
            tmp = Split(AllSetting(i), "=")
            If tmp(0) = "!MinecraftPath" Then
                If tmp(1) = "" Then tmp(1) = Environment.ExpandEnvironmentVariables("%AppData%\minecraft")
                Main.SetVariable("MinecraftPath", tmp(1))
                Configs.TextBox1.Text = tmp(1)
            End If
            If tmp(0) = "!Lang" Then
                If tmp(1) = "" Then tmp(1) = "en-US"
                Main.SetVariable("Lang", tmp(1))
            End If
            If tmp(0) = "!SelectedModpack" Then
                If Not tmp(1) = Nothing Then
                    Main.SetVariable("SelectedModpack", tmp(1))
                End If
            End If
        Next
    End Sub

    Sub LoadModpackSetting(ByVal a As String)
        Dim AllSetting As String() = System.IO.File.ReadAllLines(My.Computer.FileSystem.CurrentDirectory & "\Modpacker\Modpacks\" & a)
        Dim tmp As String()
        For i = 0 To 3
            tmp = Split(AllSetting(i), "=")
            If tmp(0) = "!ModpackTitle" Then
                Main.Text = tmp(1)
                Main.SetVariable("ModpackTitle", tmp(1))
            End If
            If tmp(0) = "!MCVersion" Then Main.SetVariable("MCVersion", tmp(1))
            If tmp(0) = "!ForgeVer" Then Main.SetVariable("ForgeVer", tmp(1))
            If tmp(0) = "!Modpack_Description" Then
                If tmp(1).Contains("	") Then
                    Dim tmp2 As String(), tmp3 As String = ""
                    tmp2 = Split(tmp(1), "	")
                    For j = 0 To tmp2.Length - 1
                        tmp3 = tmp3 & tmp2(j) & vbCrLf
                    Next
                    Main.TextBox1.Text = tmp3
                Else
                    Main.TextBox1.Text = tmp(1)
                End If
            End If
        Next
        Main.RedimVAR(AllSetting.Length - 4)
        For i = 4 To AllSetting.Length - 1
            tmp = Split(AllSetting(i), "|")
            If tmp(5).Contains("	") Then
                Dim tmp2 As String(), tmp3 As String = ""
                tmp2 = Split(tmp(5), "	")
                For j = 0 To tmp2.Length - 1
                    tmp3 = tmp3 & tmp2(j) & vbCrLf
                Next
                tmp(5) = tmp3
            End If
            Main.ModRegister(tmp(0), tmp(1), tmp(2), tmp(3), tmp(4), tmp(5), tmp(6), tmp(7), i - 4)
        Next
        Main.SetVariable("CurrentModname", "")
        Main.SetVariable("CurrentModAuthers", "")
        Main.SetVariable("CurrentModVer", "")
    End Sub
    Sub SaveConfig(ByVal a As String, ByVal b As String, ByVal c As String)
        My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.CurrentDirectory & "\Modpacker\Settings", "!MinecraftPath=" & a & vbCrLf & "!Lang=" & b & vbCrLf & "!SelectedModpack=" & c, False)
    End Sub
    Sub LoadLang(a As String)
        Dim alllang As String() = System.IO.File.ReadAllLines(My.Computer.FileSystem.CurrentDirectory & "\Modpacker\Lang\" & a)
        Dim tmp As String()
        For i = 0 To alllang.Length - 1
            tmp = Split(alllang(i), "=")
            If tmp(0) = "Configs.Button1" Then Configs.Button1.Text = tmp(1)
            If tmp(0) = "Configs.Button2" Then Configs.Button2.Text = tmp(1)
            If tmp(0) = "Configs.Button3" Then Configs.Button3.Text = tmp(1)
            If tmp(0) = "Configs.Button4" Then Configs.Button4.Text = tmp(1)
            If tmp(0) = "Configs.Label1" Then Configs.Label1.Text = tmp(1)
            If tmp(0) = "Configs.Label2" Then Configs.Label2.Text = tmp(1)
            If tmp(0) = "Configs" Then Configs.Text = tmp(1)
            If tmp(0) = "Configs.Message1" Then Configs.SetVariable("Message1", tmp(1))
            If tmp(0) = "Configs.Message2" Then Configs.SetVariable("Message2", tmp(1))
            If tmp(0) = "Main.TabPage1" Then Main.TabPage1.Text = tmp(1)
            If tmp(0) = "Main.TabPage2" Then Main.TabPage2.Text = tmp(1)
            If tmp(0) = "Main.Button1" Then Main.Button1.Text = tmp(1)
            If tmp(0) = "Main.Button2" Then Main.Button2.Text = tmp(1)
            If tmp(0) = "Main.Button3.Enable" Then Main.SetVariable("Button3_Enable", tmp(1))
            If tmp(0) = "Main.Button3.Disable" Then Main.SetVariable("Button3_Disable", tmp(1))
            If tmp(0) = "Main.Button4" Then Main.Button4.Text = tmp(1)
            If tmp(0) = "Main.Label1" Then Main.Label1.Text = tmp(1)
            If tmp(0) = "Main.Label2" Then Main.Label2.Text = tmp(1)
            If tmp(0) = "Main.Label3" Then Main.Label3.Text = tmp(1)
            If tmp(0) = "Main.Label4" Then Main.Label4.Text = tmp(1)
            If tmp(0) = "Main.Label5" Then Main.Label5.Text = tmp(1)
            If tmp(0) = "Main.Label6" Then Main.Label6.Text = tmp(1)
            If tmp(0) = "Main.LinkLabel1" Then Main.LinkLabel1.Text = tmp(1)
            If tmp(0) = "Main.LinkLabel2" Then Main.LinkLabel2.Text = tmp(1)
            If tmp(0) = "Main.Message1" Then Main.SetVariable("Message1", tmp(1))
        Next
    End Sub
    Sub CreateLangList()
        Dim di As New IO.DirectoryInfo(My.Computer.FileSystem.CurrentDirectory & "\Modpacker\Lang")
        Dim aryFi As IO.FileInfo() = di.GetFiles()
        For Each fi In aryFi
            Configs.ComboBox1.Items.Add(fi.Name)
        Next
    End Sub

    Sub CreateModpackList()
        Dim di As New IO.DirectoryInfo(My.Computer.FileSystem.CurrentDirectory & "\Modpacker\Modpacks")
        Dim aryFi As IO.FileInfo() = di.GetFiles()
        For Each fi In aryFi
            Configs.ListBox1.Items.Add(fi.Name)
        Next
    End Sub
    Sub reset()
        Main.Button3.Visible = False
        Main.LinkLabel1.Visible = False
        Main.LinkLabel2.Visible = False
        Main.Label4.Visible = False
        Main.Label5.Visible = False
        Main.Label6.Visible = False
        Main.TextBox2.Visible = False
        Main.ListBox1.Items.Clear()
        Main.ListBox2.Items.Clear()
    End Sub

    
End Module
