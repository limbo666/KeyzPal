Imports Microsoft.Win32

Public Class FrmSettings
    Dim formIsLoading As Boolean = True

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        EnableCap = CheckBox1.Checked
        EnableNum = CheckBox2.Checked
        EnableScroll = CheckBox3.Checked
        '<<<<<<< Updated upstream
        EnableNormalize = CheckBox4.Checked
        '=======
        ShowPop = CheckBox5.Checked
        '>>>>>>> Stashed changes
        If CheckBox4.Checked = True Then
            FrmMain.Timer2.Enabled = True
        Else
            FrmMain.Timer2.Enabled = False
        End If

        If RadioButton1.Checked = True Then
            SelectedNormalizationSound = 0
        ElseIf RadioButton2.Checked = True Then
            SelectedNormalizationSound = 1
        ElseIf RadioButton3.Checked = True Then
            SelectedNormalizationSound = 2
        ElseIf RadioButton4.Checked = True Then
            SelectedNormalizationSound = 3
        End If

        MakeSoundOnNormalize = CheckBox6.Checked
        SoundOnNormalChange = CheckBox7.Checked
        WhichSound = NumericUpDown2.Value

        CapsLockNormalValue = ComboBox1.Text
        NumLockNormalValue = ComboBox2.Text
        ScrollLockNormalValue = ComboBox3.Text


        TimeToNormalize = NumericUpDown1.Value
        CountToNormal = 0
        Call Savesettings()
        FrmMain.EnableDisableIcons()
        Me.Close()

    End Sub
    Sub LoadSettings()
        Dim deftop As Integer = (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2
        Dim defleft As Integer = (My.Computer.Screen.WorkingArea.Width - Me.Width) / 2

        Me.Top = GetSetting("KeysPal", "GeneralSettings", "frmSettingstop", deftop)
        Me.Left = GetSetting("KeysPal", "GeneralSettings", "frmSettingsleft", defleft)
        If Me.Left < 0 Then
            Me.Left = defleft
        End If
        If Me.Top < 0 Then
            Me.Top = deftop
        End If

        ChkRunAtStartup.Checked = GetSetting("KeysPal", "GeneralSettings", "StartWithWindows", False)

    End Sub

    Sub Savesettings()
        SaveSetting("KeysPal", "GeneralSettings", "frmSettingstop", Top)
        SaveSetting("KeysPal", "GeneralSettings", "frmSettingsleft", Left)
        SaveSetting("KeysPal", "GeneralSettings", "CapsLock", CheckBox1.Checked)
        SaveSetting("KeysPal", "GeneralSettings", "NumLock", CheckBox2.Checked)
        SaveSetting("KeysPal", "GeneralSettings", "ScrollLock", CheckBox3.Checked)

        SaveSetting("KeysPal", "GeneralSettings", "timetonormalize", NumericUpDown1.Value)
        SaveSetting("KeysPal", "GeneralSettings", "EnableNormalize", CheckBox4.Checked)
        SaveSetting("KeysPal", "GeneralSettings", "ShowPop", CheckBox5.Checked)

        SaveSetting("KeysPal", "GeneralSettings", "MakeSoundOnNormalize", CheckBox6.Checked)

        SaveSetting("KeysPal", "GeneralSettings", "SelectedNormalizationSound", SelectedNormalizationSound)

        SaveSetting("KeysPal", "GeneralSettings", "CapsLockNormalValue", CapsLockNormalValue)
        SaveSetting("KeysPal", "GeneralSettings", "NumLockNormalValue", NumLockNormalValue)
        SaveSetting("KeysPal", "GeneralSettings", "ScrollLockNormalValue", ScrollLockNormalValue)
        SaveSetting("KeysPal", "GeneralSettings", "SoundOnNormalChange", SoundOnNormalChange)

        SaveSetting("KeysPal", "GeneralSettings", "WhichSound", WhichSound)

    End Sub
    Private Declare Function HideCaret Lib "user32" (ByVal hwnd As Integer) As Integer


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formIsLoading = True

        CheckBox1.Checked = EnableCap
        CheckBox2.Checked = EnableNum
        CheckBox3.Checked = EnableScroll
        CheckBox4.Checked = EnableNormalize
        CheckBox5.Checked = ShowPop
        CheckBox7.Checked = SoundOnNormalChange
        NumericUpDown2.Value = WhichSound

        NumericUpDown1.Value = TimeToNormalize

        CheckBox6.Checked = MakeSoundOnNormalize

        If SelectedNormalizationSound = 0 Then
            RadioButton1.Checked = True
        ElseIf SelectedNormalizationSound = 1 Then
            RadioButton2.Checked = True
        ElseIf SelectedNormalizationSound = 2 Then
            RadioButton3.Checked = True
        ElseIf SelectedNormalizationSound = 3 Then
            RadioButton4.Checked = True
        Else
        End If


        Call CheckBox6_CheckedChanged(Nothing, Nothing)


        ComboBox1.Text = CapsLockNormalValue
        ComboBox2.Text = NumLockNormalValue
        ComboBox3.Text = ScrollLockNormalValue

        LoadSettings()

        Dim deftop As Integer
        Dim defleft As Integer
        If FrmMain.Visible = True Then
            deftop = FrmMain.Top + ((FrmMain.Height - Me.Height) / 2)
            defleft = FrmMain.Left + ((FrmMain.Width - Me.Width) / 2)
        Else
            deftop = (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2
            defleft = (My.Computer.Screen.WorkingArea.Width - Me.Width) / 2

        End If

        ListPrograms()

        Me.Top = deftop
        Me.Left = defleft


        NumericUpDown2.ReadOnly = True
        NumericUpDown2.BackColor = Color.White

        HideCaret(NumericUpDown2.Controls(1).Handle)
        formIsLoading = False


    End Sub

    Sub ListPrograms()


        Try
            For i As Integer = 0 To UpperCaseProgramList.Count - 1
                RichTextBox1.AppendText(UpperCaseProgramList(i) & vbNewLine)

            Next

        Catch ex As Exception

        End Try
        Try
            For i As Integer = 0 To LowerCaseProgramList.Count - 1
                RichTextBox2.AppendText(LowerCaseProgramList(i) & vbNewLine)

            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ChkRunAtStartup_CheckedChanged(sender As Object, e As EventArgs) Handles ChkRunAtStartup.CheckedChanged
        If ChkRunAtStartup.Checked = True Then
            SetStartUpValue(Application.ProductName, Application.ExecutablePath)
            SaveSetting("KeysPal", "GeneralSettings", "StartWithWindows", True)
        Else
            RemoveStartUpValue(Application.ProductName)
            SaveSetting("KeysPal", "GeneralSettings", "StartWithWindows", False)
        End If
    End Sub

    'setvalue
    Public Sub SetStartUpValue(ByVal ApplicationName As String, ByVal ApplicationPath As String)
        Dim CU As Microsoft.Win32.RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run")
        With CU
            .OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            .SetValue(ApplicationName, ApplicationPath)
        End With
    End Sub

    'remove value
    Public Sub RemoveStartUpValue(ByVal ApplicationName As String)
        Dim CU As Microsoft.Win32.RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run")
        With CU
            .OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            .DeleteValue(ApplicationName, False)
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RadioButton1.Checked = True Then
            My.Computer.Audio.Play(My.Resources.DeepBeep, AudioPlayMode.Background)
        ElseIf RadioButton2.Checked = True Then
            My.Computer.Audio.Play(My.Resources.HarmonyBeep, AudioPlayMode.Background)
        ElseIf RadioButton3.Checked = True Then
            My.Computer.Audio.Play(My.Resources.HappyHarmonyBeep, AudioPlayMode.Background)
        ElseIf RadioButton4.Checked = True Then
            My.Computer.Audio.Play(My.Resources.RobotBeep, AudioPlayMode.Background)
        End If

    End Sub



    Private Sub RadioButton4_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click
        My.Computer.Audio.Play(My.Resources.RobotBeep, AudioPlayMode.Background)
    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        My.Computer.Audio.Play(My.Resources.HappyHarmonyBeep, AudioPlayMode.Background)
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        My.Computer.Audio.Play(My.Resources.HarmonyBeep, AudioPlayMode.Background)
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        My.Computer.Audio.Play(My.Resources.DeepBeep, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
            RadioButton3.Enabled = True
            RadioButton4.Enabled = True

        Else
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            RadioButton3.Enabled = False
            RadioButton4.Enabled = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        ComboBox1.Enabled = CheckBox4.Checked
        ComboBox2.Enabled = CheckBox4.Checked
        ComboBox3.Enabled = CheckBox4.Checked
        CheckBox6.Enabled = CheckBox4.Checked
        NumericUpDown1.Enabled = CheckBox4.Checked
        ' If CheckBox6.Checked Then

        RadioButton1.Enabled = CheckBox4.Checked
        RadioButton2.Enabled = CheckBox4.Checked
        RadioButton3.Enabled = CheckBox4.Checked
        RadioButton4.Enabled = CheckBox4.Checked
        '   End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        'Dim filepath = Application.StartupPath & "\lists.ini"

        'If System.IO.File.Exists(filepath) = True Then
        '    Try
        '        Process.Start(filepath)
        '    Catch ex As Exception

        '    End Try

        'Else
        '    '  Try
        '    Dim fs As System.IO.FileStream = System.IO.File.Create(filepath)
        '    fs.Close()
        '    Dim file As System.IO.StreamWriter

        '    file = My.Computer.FileSystem.OpenTextFileWriter(filepath, True)
        '    file.WriteLine("")
        '    file.WriteLine("[UpperCase]")
        '    file.WriteLine("Program1 = ""Set your UPPER CASE programs here"" ")
        '    file.WriteLine("Program2 = ""a part of title is normally enough"" ")
        '    file.WriteLine("Program3 = ""but please try to use unique values to avoid misbehavior"" ")
        '    file.WriteLine("Program4 = ""set program4 here"" ")
        '    file.WriteLine("Program5 = ""set program5 here"" ")
        '    file.WriteLine("Program6 = ""set program6 here"" ")
        '    file.WriteLine("Program7 = ""set program7 here"" ")
        '    file.WriteLine("Program8 = ""set program8 here"" ")
        '    file.WriteLine("Program9 = ""set program9 here"" ")
        '    file.WriteLine("Program10 = ""set program10 here"" ")

        '    file.WriteLine("[Lowercase]")
        '    file.WriteLine("Program1 = ""SET YOUR lower case PROGRAMS HERE"" ")
        '    file.WriteLine("Program2 = ""a part of title is normally enough"" ")
        '    file.WriteLine("Program3 = ""but please try to use unique values to avoid misbehavior"" ")
        '    file.WriteLine("Program4 = ""set program4 here"" ")
        '    file.WriteLine("Program5 = ""set program5 here"" ")
        '    file.WriteLine("Program6 = ""set program6 here"" ")
        '    file.WriteLine("Program7 = ""set program7 here"" ")
        '    file.WriteLine("Program8 = ""set program8 here"" ")
        '    file.WriteLine("Program9 = ""set program9 here"" ")
        '    file.WriteLine("Program10 = ""set program10 here"" ")

        '    file.Close()
        '    wait(500)

        '    Process.Start(filepath)
        '    '   Catch ex As Exception

        '    '  End Try
        'End If
        FrmEditor.Show()
    End Sub


    Private Sub wait(ByVal interval As Integer)  ' taken from https://stackoverflow.com/questions/13519274/delaying-in-vb-net/13520695
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()


    End Sub

    Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        RichTextBox1.Clear()
        RichTextBox2.Clear()

        LoadForceToPrograms()
        ListPrograms()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged

    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If formIsLoading = False Then
            If NumericUpDown2.Value = 1 Then
                My.Computer.Audio.Play(My.Resources.wav_ding01a, AudioPlayMode.Background)
            ElseIf NumericUpDown2.Value = 2 Then
                My.Computer.Audio.Play(My.Resources.wav_ding01b, AudioPlayMode.Background)
            ElseIf NumericUpDown2.Value = 3 Then
                My.Computer.Audio.Play(My.Resources.wav_ding02, AudioPlayMode.Background)
            ElseIf NumericUpDown2.Value = 4 Then
                My.Computer.Audio.Play(My.Resources.wav_ding03, AudioPlayMode.Background)
            ElseIf NumericUpDown2.Value = 5 Then
                My.Computer.Audio.Play(My.Resources.wav_ding04, AudioPlayMode.Background)
            ElseIf NumericUpDown2.Value = 6 Then
                My.Computer.Audio.Play(My.Resources.wav_ding05, AudioPlayMode.Background)
            ElseIf NumericUpDown2.Value = 7 Then
                My.Computer.Audio.Play(My.Resources.wav_ding06, AudioPlayMode.Background)
            ElseIf NumericUpDown2.Value = 8 Then
                My.Computer.Audio.Play(My.Resources.wav_ding07, AudioPlayMode.Background)
            ElseIf NumericUpDown2.Value = 9 Then
                My.Computer.Audio.Play(My.Resources.wav_ding08, AudioPlayMode.Background)
            ElseIf NumericUpDown2.Value = 10 Then
                My.Computer.Audio.Play(My.Resources.wav_ding09, AudioPlayMode.Background)
            End If
        End If

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        FrmDisplayFormostWindow.Show()
    End Sub
End Class