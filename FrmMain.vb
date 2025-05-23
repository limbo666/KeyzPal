﻿Imports System.ComponentModel
Imports System.IO
Imports System.Net.Sockets
Imports System.Text

Imports System.Windows.Forms
Imports System.Runtime.InteropServices


Public Class FrmMain
    Dim IsFirstTimeRun As Boolean = True
    Dim StDN As Boolean = False

    Dim CommandClose = False
    Dim TotalIndicators As Integer = 0
    Dim Cap As Integer
    Dim Num As Integer
    Dim Scr As Integer
    '  Dim Debug As Boolean = False
    ' ShowPop As Boolean

    Dim OldCap As Integer = -1
    Dim OldNum As Integer = -1
    Dim OldScr As Integer = -1


    Dim EnableCapPop As Boolean = False
    Dim EnableNumPop As Boolean = False
    Dim EnableScrPop As Boolean = False

    Dim PreviousWindowTitle As String = ""



    Dim ImageSet As Integer = 1
    ' Keyboard hook variable below
    Dim WithEvents K As New Module_Keyboard
    'Keyboard command below
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)

    Dim makel As String

    Dim SkipNormalSounding As Boolean = False


    Dim IsTimeToAllowNotifications As Boolean = False


    Dim periodicSend As Integer = -1



    Sub SaveSettings()
        Try
            SaveSetting("KeysPal", "GeneralSettings", "frmmaintop", Me.Top)
            SaveSetting("KeysPal", "GeneralSettings", "frmmainleft", Me.Left)
        Catch ex As Exception

        End Try
        '  SaveSetting("KeysPal", "General", "MainTop", Top)
        '  SaveSetting("KeysPal", "General", "Main", Left)

    End Sub

    Sub LoadSettings()
        StDN = GetSetting("KeysPal", "GeneralSettings", "StDN", False)
        ImageSet = GetSetting("KeysPal", "GeneralSettings", "ImageSet", 1)
        Dim deftop As Integer = (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2
        Dim defleft As Integer = (My.Computer.Screen.WorkingArea.Width - Me.Width) / 2
        EnableCap = GetSetting("KeysPal", "GeneralSettings", "CapsLock", True)
        EnableNum = GetSetting("KeysPal", "GeneralSettings", "NumLock", True)
        EnableScroll = GetSetting("KeysPal", "GeneralSettings", "ScrollLock", False)
        EnableNormalize = GetSetting("KeysPal", "GeneralSettings", "EnableNormalize", False)
        TimeToNormalize = GetSetting("KeysPal", "GeneralSettings", "TimeToNormalize", 60)
        ShowPop = GetSetting("KeysPal", "GeneralSettings", "ShowPop", False)

        MakeSoundOnNormalize = GetSetting("KeysPal", "GeneralSettings", "MakeSoundOnNormalize", False)
        SelectedNormalizationSound = GetSetting("KeysPal", "GeneralSettings", "SelectedNormalizationSound", 0)



        CapsLockNormalValue = GetSetting("KeysPal", "GeneralSettings", "CapsLockNormalValue", False)
        NumLockNormalValue = GetSetting("KeysPal", "GeneralSettings", "NumLockNormalValue", True)
        ScrollLockNormalValue = GetSetting("KeysPal", "GeneralSettings", "ScrollLockNormalValue", False)

        SoundOnNormalChange = GetSetting("KeysPal", "GeneralSettings", "SoundOnNormalChange", False)
        WhichSound = GetSetting("KeysPal", "GeneralSettings", "WhichSound", 1)


        Me.Top = GetSetting("KeysPal", "GeneralSettings", "frmmaintop", deftop)
        Me.Left = GetSetting("KeysPal", "GeneralSettings", "frmmainleft", defleft)

        IsFirstTimeRun = GetSetting("KeysPal", "GeneralSettings", "IsFirstTimeRun", True)
        EnableHardwareIntegration = GetSetting("KeysPal", "GeneralSettings", "EnableHardwareIntegration", False)

        StDN = GetSetting("KeysPal", "GeneralSettings", "StDN", False)
        If Me.Left < 0 Then
            Me.Left = defleft
        End If
        If Me.Top < 0 Then
            Me.Top = deftop
        End If


        EnableLanguageNotifications = GetSetting("KeysPal", "GeneralSettings", "EnableLanguageNotifications", True)

    End Sub


    Sub CountActiveIndicators()

        If EnableCap = True Then
            TotalIndicators += 1
            NotifyIcon1.Visible = True
        End If
        If EnableNum = True Then
            TotalIndicators += 1
            NotifyIcon2.Visible = True
        End If
        If EnableScroll = True Then
            TotalIndicators += 1
            NotifyIcon3.Visible = True
        End If

    End Sub



    Private Sub K_UP(ByVal Key As String) Handles K.Up
        Dim LastKey = Key
        If Debug = True Then
            FrmDiagnostics.Label1.Text = LastKey
        End If


        If LastKey <> "<Capital>" Then

            CountToNormal = 0 ' reset the timer counter 
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FullyLoaded = False
        '  Debug = True 'used only for diagnostics window and log
        If Debug = True Then
            FrmDiagnostics.Show()
        End If
        TmrIsTimeToAllowNotifications.Enabled = True
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        NumericUpDown1.ReadOnly = True
        NumericUpDown1.BackColor = Color.White

        K.CreateHook()
        SaveSetting("KeysPal", "GeneralSettings", "IsFirstTimeRun", False)

        LoadSettings()

        Dim RunTimes = GetSetting("KeysPal", "Stats", "RunTimes", 0)
        RunTimes = RunTimes + 1
        SaveSetting("KeysPal", "Stats", "RunTimes", RunTimes)

        If StDN = False And RunTimes / 5 = Int(RunTimes / 5) Then
            FrmDonate.Show()
        End If
        If StDN = True Then
            PictureBox8.Visible = False
            Me.Height = 324
        End If

        Me.Visible = False

        CountActiveIndicators()
        If IsFirstTimeRun = True Then
            'show settings
            Me.ShowInTaskbar = True
            Me.Visible = True
        Else
            If TotalIndicators > 0 Then
                'start normally
                Me.ShowInTaskbar = False
                Me.Visible = False
            Else
                'show settings
                Me.ShowInTaskbar = True
                Me.Visible = True
            End If

        End If

        If EnableNormalize = True Then
            Timer2.Enabled = True
        Else
            Timer2.Enabled = False
        End If
        Timer1.Enabled = True
        Timer1_Tick(Nothing, Nothing)

        '   TmrPopUp.Enabled = True
        EnableDisableIcons()




        NumericUpDown1.Value = ImageSet

        UpdateImageSet()
        OldCap = -1
        OldNum = -1
        OldScr = -1
        UpdateIcons()


        TmrPopEnabler.Enabled = True


        Call LoadForceToPrograms()

        TmrGetFocusedWindow.Enabled = True
        '  lblDevDiagnostics.Visible = True

        '   lblDevDiagnostics2.Visible = True
        FullyLoaded = True ' THIS CAME BACK TO FIX THEME CHANGING BUG




    End Sub


    Public Sub EnableDisableIcons()
        If EnableCap = True Then
            NotifyIcon1.Visible = True
        Else
            NotifyIcon1.Visible = False
        End If

        If EnableNum = True Then
            NotifyIcon2.Visible = True
        Else
            NotifyIcon2.Visible = False
        End If
        If EnableScroll = True Then
            NotifyIcon3.Visible = True
        Else
            NotifyIcon3.Visible = False
        End If
        Call Timer1_Tick(Nothing, Nothing)

    End Sub


    Sub SoundOnNormalChange_PlayThatSound()
        If IsTimeToAllowNotifications = True Then
            If SoundOnNormalChange = True Then
                If WhichSound = 1 Then
                    My.Computer.Audio.Play(My.Resources.wav_ding01a, AudioPlayMode.Background)
                ElseIf WhichSound = 2 Then
                    My.Computer.Audio.Play(My.Resources.wav_ding01b, AudioPlayMode.Background)
                ElseIf WhichSound = 3 Then
                    My.Computer.Audio.Play(My.Resources.wav_ding02, AudioPlayMode.Background)
                ElseIf WhichSound = 4 Then
                    My.Computer.Audio.Play(My.Resources.wav_ding03, AudioPlayMode.Background)
                ElseIf WhichSound = 5 Then
                    My.Computer.Audio.Play(My.Resources.wav_ding04, AudioPlayMode.Background)
                ElseIf WhichSound = 6 Then
                    My.Computer.Audio.Play(My.Resources.wav_ding05, AudioPlayMode.Background)
                ElseIf WhichSound = 7 Then
                    My.Computer.Audio.Play(My.Resources.wav_ding06, AudioPlayMode.Background)
                ElseIf WhichSound = 8 Then
                    My.Computer.Audio.Play(My.Resources.wav_ding07, AudioPlayMode.Background)
                ElseIf WhichSound = 9 Then
                    My.Computer.Audio.Play(My.Resources.wav_ding08, AudioPlayMode.Background)
                ElseIf WhichSound = 10 Then
                    My.Computer.Audio.Play(My.Resources.wav_ding09, AudioPlayMode.Background)
                End If


            End If
        End If

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If My.Computer.Keyboard.CapsLock = True Then
            Cap = 1
            Label1.Text = "Caps Lock ON"

            If Cap <> OldCap Then
                Dim img As Image = PictureBox1.Image
                Dim bm As Bitmap = img
                Dim hIcon As IntPtr = bm.GetHicon
                Dim TheIcon As Icon = Icon.FromHandle(hIcon)
                NotifyIcon1.Icon = TheIcon
                CountToNormal = 0
                OldCap = Cap
                NotifyIcon1.Text = "Caps Lock ON"
                If ShowPop = True And EnableCapPop = True Then
                    FrmNotify.Label1.Text = "CAPS"
                    FrmNotify.Label2.Text = "ΟΝ"
                    FrmNotify.Show()
                End If
                SoundOnNormalChange_PlayThatSound()
                If EnableHardwareIntegration = True Then
                    SendUDPCommand("capsON", 22689, "255.255.255.255")
                End If
                '       EnableCapPop = True
            End If
            Panel1.BackColor = Color.DimGray
        Else
            Cap = 0
            Label1.Text = "Caps Lock OFF"
            If Cap <> OldCap Then
                Dim img As Image = PictureBox4.Image
                Dim bm As Bitmap = img
                Dim hIcon As IntPtr = bm.GetHicon
                Dim TheIcon As Icon = Icon.FromHandle(hIcon)
                NotifyIcon1.Icon = TheIcon
                CountToNormal = 0
                OldCap = Cap
                NotifyIcon1.Text = "Caps Lock OFF"
                If ShowPop = True And EnableCapPop = True Then
                    FrmNotify.Label1.Text = "CAPS"
                    FrmNotify.Label2.Text = "OFF"
                    FrmNotify.Show()
                End If
                SoundOnNormalChange_PlayThatSound()
                If EnableHardwareIntegration = True Then
                    SendUDPCommand("capsOFF", 22689, "255.255.255.255")
                End If
                '    EnableCapPop = True
            End If
            Panel1.BackColor = Color.Red
        End If

        If My.Computer.Keyboard.NumLock = True Then
            Num = 1
            Label2.Text = "Num Lock ON"
            If Num <> OldNum Then
                Dim img As Image = PictureBox2.Image
                Dim bm As Bitmap = img
                Dim hIcon As IntPtr = bm.GetHicon
                Dim TheIcon As Icon = Icon.FromHandle(hIcon)
                NotifyIcon2.Icon = TheIcon
                CountToNormal = 0
                OldNum = Num
                NotifyIcon2.Text = "Num Lock ON"
                If ShowPop = True And EnableNumPop = True Then
                    FrmNotify.Label1.Text = "NUM"
                    FrmNotify.Label2.Text = "ON"
                    FrmNotify.Show()
                End If
                SoundOnNormalChange_PlayThatSound()
                If EnableHardwareIntegration = True Then
                    SendUDPCommand("numON", 22689, "255.255.255.255")
                End If
                '   EnableNumPop = True
            End If
            Panel2.BackColor = Color.DimGray
        Else
            Num = 0
            Label2.Text = "Num Lock OFF"
            If Num <> OldNum Then
                Dim img As Image = PictureBox5.Image
                Dim bm As Bitmap = img
                Dim hIcon As IntPtr = bm.GetHicon
                Dim TheIcon As Icon = Icon.FromHandle(hIcon)
                NotifyIcon2.Icon = TheIcon
                CountToNormal = 0
                OldNum = Num
                NotifyIcon2.Text = "Num Lock OFF"

                If ShowPop = True And EnableNumPop = True Then
                    FrmNotify.Label1.Text = "NUM"
                    FrmNotify.Label2.Text = "OFF"
                    FrmNotify.Show()
                End If
                SoundOnNormalChange_PlayThatSound()
                If EnableHardwareIntegration = True Then
                    SendUDPCommand("numOFF", 22689, "255.255.255.255")
                End If

                '   EnableNumPop = True
            End If
            Panel2.BackColor = Color.Red
        End If

        If My.Computer.Keyboard.ScrollLock = True Then

            Scr = 1
            Label3.Text = "Scroll Lock ON"
            If Scr <> OldScr Then
                Dim img As Image = PictureBox3.Image
                Dim bm As Bitmap = img
                Dim hIcon As IntPtr = bm.GetHicon
                Dim TheIcon As Icon = Icon.FromHandle(hIcon)
                NotifyIcon3.Icon = TheIcon
                CountToNormal = 0
                OldScr = Scr
                NotifyIcon3.Text = "Scroll Lock ON"
                If ShowPop = True And EnableScrPop = True Then
                    FrmNotify.Label1.Text = "SCRL"
                    FrmNotify.Label2.Text = "ON"
                    FrmNotify.Show()
                End If
                SoundOnNormalChange_PlayThatSound()
                If EnableHardwareIntegration = True Then
                    SendUDPCommand("scrollON", 22689, "255.255.255.255")
                End If
                '    EnableScrPop = True
            End If
            Panel3.BackColor = Color.DimGray
        Else

            Scr = 0
            Label3.Text = "Scroll Lock OFF"
            If Scr <> OldScr Then
                Dim img As Image = PictureBox6.Image
                Dim bm As Bitmap = img
                Dim hIcon As IntPtr = bm.GetHicon
                Dim TheIcon As Icon = Icon.FromHandle(hIcon)
                NotifyIcon3.Icon = TheIcon
                CountToNormal = 0
                OldScr = Scr
                NotifyIcon3.Text = "Scroll Lock OFF"
                If ShowPop = True And EnableScrPop = True Then
                    FrmNotify.Label1.Text = "SCRL"
                    FrmNotify.Label2.Text = "OFF"
                    FrmNotify.Show()
                End If
                SoundOnNormalChange_PlayThatSound()
                If EnableHardwareIntegration = True Then
                    SendUDPCommand("scrollOFF", 22689, "255.255.255.255")
                End If
                '  EnableScrPop = True
            End If
            Panel3.BackColor = Color.Red
        End If


        Call UpdateIcons()
        If EnableLanguageNotifications = True Then
            CheckKeyboardLanguage(Nothing, Nothing)

        End If


        If EnableHardwareIntegration = True Then
            If periodicSend = -1 Then
                sendallleds()
            ElseIf periodicSend >= 25 Then
                sendallleds()
                periodicSend = 0
            End If
            periodicSend += 1
        End If


    End Sub
    'Sub sendAllLeds()
    '    If My.Computer.Keyboard.CapsLock = True Then
    '        SendUDPCommand("capsON", 22689, "255.255.255.255")
    '    Else
    '        SendUDPCommand("capsOFF", 22689, "255.255.255.255")
    '    End If
    '    If My.Computer.Keyboard.NumLock = True Then
    '        SendUDPCommand("numON", 22689, "255.255.255.255")
    '    Else
    '        SendUDPCommand("numOFF", 22689, "255.255.255.255")
    '    End If
    '    If My.Computer.Keyboard.ScrollLock = True Then
    '        SendUDPCommand("scrollON", 22689, "255.255.255.255")
    '    Else
    '        SendUDPCommand("scrollOFF", 22689, "255.255.255.255")
    '    End If
    'End Sub
    Async Sub sendAllLeds()
        If Not EnableHardwareIntegration Then Return

        Dim commands As New List(Of Task(Of Boolean))

        commands.Add(SendUDPCommand(If(My.Computer.Keyboard.CapsLock, "capsON", "capsOFF"), 22689, "255.255.255.255"))
        commands.Add(SendUDPCommand(If(My.Computer.Keyboard.NumLock, "numON", "numOFF"), 22689, "255.255.255.255"))
        commands.Add(SendUDPCommand(If(My.Computer.Keyboard.ScrollLock, "scrollON", "scrollOFF"), 22689, "255.255.255.255"))

        Await Task.WhenAll(commands)
    End Sub

    'example calling function:
    'Dim success As Boolean = Await SendUDPCommand(text, port, ip)

    'If success Then
    '    Console.WriteLine("UDP command sent successfully.")
    'Else
    '    Console.WriteLine("Failed to send UDP command.")
    'End If

    '    ' Turn on Caps Lock with red color
    'Await SendUDPCommand("capsRed", 22689, "255.255.255.255")
    'Await SendUDPCommand("capsON", 22689, "255.255.255.255")

    '' Turn off Num Lock
    'Await SendUDPCommand("numOFF", 22689, "255.255.255.255")

    '' Change Scroll Lock to blue
    'Await SendUDPCommand("scrollBlue", 22689, "255.255.255.255")

    '' Reboot the device
    'Await SendUDPCommand("Reboot", 22689, "255.255.255.255")


    '    Toggle States : 
    '"capsON" - Turns on Caps Lock LED
    '"capsOFF" - Turns off Caps Lock LED
    '"numON" - Turns on Num Lock LED
    '"numOFF" - Turns off Num Lock LED
    '"scrollON" - Turns on Scroll Lock LED
    '"scrollOFF" - Turns off Scroll Lock LED
    'Color Change Commands:
    '"capsRed" - Sets Caps Lock to red
    '"capsGreen" - Sets Caps Lock to green
    '"capsBlue" - Sets Caps Lock to blue
    '"capsPurple" - Sets Caps Lock to purple
    '"capsWhite" - Sets Caps Lock to white
    '"capsYellow" - Sets Caps Lock to yellow
    '"capsAqua" - Sets Caps Lock to aqua
    '"capsOrange" - Sets Caps Lock to orange
    '"capsPink" - Sets Caps Lock to pink
    '"capsMagenta" - Sets Caps Lock to magenta
    '"capsLime" - Sets Caps Lock to lime
    '(Replace "caps" with "num" Or "scroll" for the other keys)
    'System Commands : 
    '"Reboot" - Restarts the ESP8266
    '"Eeprom" - Reloads colors from EEPROM





    'Public Async Function SendUDPCommand(ByVal text As String, ByVal port As Integer, ByVal ip As String) As Task(Of Boolean)
    '    Try
    '        Await Task.Run(Sub()
    '                           Dim udpClient As New UdpClient()
    '                           Dim bytes As Byte() = Encoding.ASCII.GetBytes(text)
    '                           udpClient.Send(bytes, bytes.Length, ip, port)
    '                           udpClient.Close()
    '                       End Sub)
    '        Return True
    '    Catch ex As Exception
    '        '   Console.WriteLine(ex.Message)
    '        Return False
    '    End Try
    'End Function




    Sub UpdateImageSet()


        If ImageSet = 1 Then
            PictureBox1.Image = My.Resources.capsOn1
            PictureBox2.Image = My.Resources.numOn1
            PictureBox3.Image = My.Resources.scrOn1
            PictureBox4.Image = My.Resources.capsOff1
            PictureBox5.Image = My.Resources.numOff1
            PictureBox6.Image = My.Resources.scrOff1

        ElseIf ImageSet = 2 Then
            PictureBox1.Image = My.Resources.capsOn2
            PictureBox2.Image = My.Resources.numOn2
            PictureBox3.Image = My.Resources.scrOn2
            PictureBox4.Image = My.Resources.capsOff2
            PictureBox5.Image = My.Resources.numOff2
            PictureBox6.Image = My.Resources.scrOff2



        ElseIf ImageSet = 3 Then
            PictureBox1.Image = My.Resources.capsOn3
            PictureBox2.Image = My.Resources.numOn3
            PictureBox3.Image = My.Resources.scrOn3
            PictureBox4.Image = My.Resources.capsOff3
            PictureBox5.Image = My.Resources.numOff3
            PictureBox6.Image = My.Resources.scrOff3

        ElseIf ImageSet = 4 Then
            PictureBox1.Image = My.Resources.capsOn4
            PictureBox2.Image = My.Resources.numOn4
            PictureBox3.Image = My.Resources.scrOn4
            PictureBox4.Image = My.Resources.capsOff4
            PictureBox5.Image = My.Resources.numOff4
            PictureBox6.Image = My.Resources.scrOff4

        End If

    End Sub


    Sub UpdateIcons()


        If Cap = 1 Then
            PictureBox1.Visible = True
            PictureBox4.Visible = False

        Else
            PictureBox1.Visible = False
            PictureBox4.Visible = True
        End If
        If Num = 1 Then
            PictureBox2.Visible = True
            PictureBox5.Visible = False
        Else
            PictureBox2.Visible = False
            PictureBox5.Visible = True
        End If

        If Scr = 1 Then
            PictureBox3.Visible = True
            PictureBox6.Visible = False
        Else
            PictureBox3.Visible = False
            PictureBox6.Visible = True
        End If
    End Sub

    Private Async Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'CountActiveIndicators()
        If EnableHardwareIntegration = True Then

            Dim commands As New List(Of Task(Of Boolean))

            commands.Add(SendUDPCommand("capsOFF", 22689, "255.255.255.255"))
            commands.Add(SendUDPCommand("numOFF", 22689, "255.255.255.255"))
            commands.Add(SendUDPCommand("scrollOFF", 22689, "255.255.255.255"))

            Await (Task.WhenAll(commands))
        End If

        K.DiposeHook()

        If CommandClose = True Then
            Call SaveSettings()

        Else
            If TotalIndicators > 0 Then  ' if indicator selected then send to tray
                Me.Hide()
                Me.ShowInTaskbar = False
                e.Cancel = True
            Else ' in case that no indicators selected close the program
                NotifyIcon1.Visible = False
                NotifyIcon2.Visible = False
                NotifyIcon3.Visible = False
                Call SaveSettings()

            End If

        End If


    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        FrmSettings.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        CommandClose = True
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        FrmAbout.Show()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        FrmAbout.Show()
        If StDN = False Then
            FrmDonate.Show()
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim NeedToSoundSignal = 0
        ' Normalize
        If CountToNormal < TimeToNormalize Then
            CountToNormal = CountToNormal + 1

        Else
            'turn CAPS lock off
            If My.Computer.Keyboard.CapsLock <> CapsLockNormalValue Then
                If UnderSpecificCaseProgram = False Then
                    SkipNormalSounding = True
                    ToggleCapsLock()
                    NeedToSoundSignal = NeedToSoundSignal + 1
                    Debuglog(Now & " Caps normalized")
                    SkipNormalSounding = False

                Else
                    Debuglog(Now & " Caps not normalized because it is under specific window")
                End If


            End If
            'turn NUM lock on
            If My.Computer.Keyboard.NumLock <> NumLockNormalValue Then
                SkipNormalSounding = True
                ToggleNumLock()
                NeedToSoundSignal = NeedToSoundSignal + 1
                Debuglog(Now & " Num normalized")
                SkipNormalSounding = False
            End If
            'turn Scroll lock off
            If My.Computer.Keyboard.ScrollLock <> ScrollLockNormalValue Then
                SkipNormalSounding = True
                ToggleScrollLock()
                NeedToSoundSignal = NeedToSoundSignal + 1
                Debuglog(Now & " Scroll normalized")
                SkipNormalSounding = False
            End If
            CountToNormal = 0



            If NeedToSoundSignal > 0 Then
                If MakeSoundOnNormalize = True Then
                    If SelectedNormalizationSound = 0 Then
                        My.Computer.Audio.Play(My.Resources.DeepBeep, AudioPlayMode.Background)
                    ElseIf SelectedNormalizationSound = 1 Then
                        My.Computer.Audio.Play(My.Resources.HarmonyBeep, AudioPlayMode.Background)
                    ElseIf SelectedNormalizationSound = 2 Then
                        My.Computer.Audio.Play(My.Resources.HappyHarmonyBeep, AudioPlayMode.Background)
                    ElseIf SelectedNormalizationSound = 3 Then
                        My.Computer.Audio.Play(My.Resources.RobotBeep, AudioPlayMode.Background)
                    End If
                    Debuglog(Now & "  normalized Sound")
                End If
                NeedToSoundSignal = 0
            End If
            '  MsgBox("Back to normal")
        End If
    End Sub

    Private Sub ToggleCapsLock()
        Call keybd_event(System.Windows.Forms.Keys.CapsLock, &H14, 1, 0)
        Call keybd_event(System.Windows.Forms.Keys.CapsLock, &H14, 3, 0)
    End Sub


    Private Sub ToggleNumLock()
        Call keybd_event(System.Windows.Forms.Keys.NumLock, &H14, 1, 0)
        Call keybd_event(System.Windows.Forms.Keys.NumLock, &H14, 3, 0)
    End Sub

    Private Sub ToggleScrollLock()
        Call keybd_event(System.Windows.Forms.Keys.Scroll, &H14, 1, 0)
        Call keybd_event(System.Windows.Forms.Keys.Scroll, &H14, 3, 0)
    End Sub

    Private Sub TmrPopUp_Tick(sender As Object, e As EventArgs) Handles TmrPopUp.Tick
        TmrPopUp.Enabled = False
        FrmDonate.Show()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()

        Me.ShowInTaskbar = True
    End Sub

    Private Sub NotifyIcon2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon2.MouseDoubleClick
        Me.Show()

        Me.ShowInTaskbar = True
    End Sub

    Private Sub NotifyIcon3_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon3.MouseDoubleClick
        Me.Show()

        Me.ShowInTaskbar = True
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CommandClose = True
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CountActiveIndicators()

        If TotalIndicators > 0 Then
            Me.Hide()
            Me.ShowInTaskbar = False
        Else
            Label4.Visible = True
            TmrResetLabel.Enabled = True

        End If

    End Sub

    Private Sub HideToTrayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideToTrayToolStripMenuItem.Click
        CountActiveIndicators()

        If TotalIndicators > 0 Then
            Me.Hide()
            Me.ShowInTaskbar = False
        Else
            Label4.Visible = True
            TmrResetLabel.Enabled = True

        End If

    End Sub

    Private Sub TmrResetLabel_Tick(sender As Object, e As EventArgs) Handles TmrResetLabel.Tick
        Label4.Visible = False
        TmrResetLabel.Enabled = False

    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        CommandClose = True
        Close()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Me.Show()

        Me.ShowInTaskbar = True
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        FrmAbout.Show()
        If StDN = False Then
            FrmDonate.Show()
        End If

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Process.Start("http://bit.ly/2SZyfsY")
    End Sub

    Private Sub PictureBox8_MouseHover(sender As Object, e As EventArgs) Handles PictureBox8.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox8_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox8.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VersionHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersionHistoryToolStripMenuItem.Click
        FrmVerHistory.Show()
    End Sub


    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        ' IsTimeToAllowNotifications = False
        If FullyLoaded = True Then
            ImageSet = NumericUpDown1.Value
            SaveSetting("KeysPal", "GeneralSettings", "ImageSet", ImageSet)
            UpdateImageSet()
            OldCap = -1
            OldNum = -1
            OldScr = -1
            UpdateIcons()

        End If
        '  IsTimeToAllowNotifications = True
    End Sub


    Private Sub TmrPopEnabler_Tick(sender As Object, e As EventArgs) Handles TmrPopEnabler.Tick
        TmrPopEnabler.Enabled = False
        EnableCapPop = True
        EnableNumPop = True
        EnableScrPop = True
    End Sub

    Private Sub TmrGetFocusedWindow_Tick(sender As Object, e As EventArgs) Handles TmrGetFocusedWindow.Tick
        Dim CapTxt As String = GetCaption()
        If makel <> CapTxt Then
            makel = CapTxt
            ' stop timer before showing msgbox so it is not detected!
            TmrGetFocusedWindow.Stop()

            CurrentFocusedWindow = CapTxt
            lblDevDiagnostics.Text = CurrentFocusedWindow
            ' MsgBox(CapTxt)
            ' resume timer 
            TmrGetFocusedWindow.Start()
        End If

        If PreviousWindowTitle <> CurrentFocusedWindow Then
            PreviousWindowTitle = CurrentFocusedWindow
            Call CompareWindowNames()
        End If

    End Sub


    Private Sub CompareWindowNames()
        Dim NumberOfListedPrograms As Integer = 0

        Try
            For i As Integer = 0 To UpperCaseProgramList.Count
                If Trim(UpperCaseProgramList(i)) <> "" Then
                    If CurrentFocusedWindow.IndexOf(UpperCaseProgramList(i)) > -1 Then
                        lblDevDiagnostics.ForeColor = Color.Red
                        ' UnderSpecificCaseProgram = True
                        NumberOfListedPrograms += 1
                        If My.Computer.Keyboard.CapsLock <> True Then
                            ToggleCapsLock()
                            '   NeedToSoundSignal = NeedToSoundSignal + 1
                            Debuglog(Now & " Caps switched to UpperCase by program " & i)
                            If SoundOnConditionalChange = True Then
                                '    My.Computer.Audio.Play(My.Resources.DeepBeep, AudioPlayMode.Background)
                            End If
                        End If
                    Else

                        '    UnderSpecificCaseProgram = False
                    End If
                End If

            Next

        Catch ex As Exception

        End Try

        Try
            For i As Integer = 0 To LowerCaseProgramList.Count
                If Trim(LowerCaseProgramList(i)) <> "" Then
                    If CurrentFocusedWindow.IndexOf(LowerCaseProgramList(i)) > -1 Then
                        lblDevDiagnostics.ForeColor = Color.Blue
                        '     UnderSpecificCaseProgram = True
                        NumberOfListedPrograms += 1
                        If My.Computer.Keyboard.CapsLock <> False Then
                            ToggleCapsLock()
                            '   NeedToSoundSignal = NeedToSoundSignal + 1
                            Debuglog(Now & " Caps switched to LowerCase by program " & i)
                            If SoundOnConditionalChange = True Then
                                '    My.Computer.Audio.Play(My.Resources.DeepBeep, AudioPlayMode.Background)
                            End If

                        End If
                    Else
                        '    UnderSpecificCaseProgram = False
                    End If
                End If

            Next
        Catch ex As Exception

        End Try


        If NumberOfListedPrograms > 0 Then
            PBoxYield.Visible = True
            UnderSpecificCaseProgram = True
        Else
            UnderSpecificCaseProgram = 0
            PBoxYield.Visible = False
            CountToNormal = 0
        End If
        lblDevDiagnostics2.Text = UnderSpecificCaseProgram



    End Sub

    Private Sub TmrIsTimeToAllowNotifications_Tick(sender As Object, e As EventArgs) Handles TmrIsTimeToAllowNotifications.Tick
        TmrIsTimeToAllowNotifications.Enabled = False
        IsTimeToAllowNotifications = True
    End Sub

    Private Sub ProjectOnGithubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectOnGithubToolStripMenuItem.Click
        Process.Start("https://github.com/limbo666/KeyzPal#keyzpal")
    End Sub




    ' Declare API functions to get keyboard layout
    <DllImport("user32.dll")>
    Private Shared Function GetKeyboardLayout(idThread As UInteger) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Function GetWindowThreadProcessId(hwnd As IntPtr, ByRef lpdwProcessId As UInteger) As UInteger
    End Function

    <DllImport("user32.dll")>
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function
    Private previousLanguageId As Integer = -1
    Private isFirstCheck As Boolean = True

    Private Sub CheckKeyboardLanguage(sender As Object, e As EventArgs)
        Try
            ' Get the current foreground window
            Dim foregroundWindow As IntPtr = GetForegroundWindow()

            ' Get the thread ID of the foreground window
            Dim threadId As UInteger = GetWindowThreadProcessId(foregroundWindow, Nothing)

            ' Get the keyboard layout for the current thread
            Dim keyboardLayout As IntPtr = GetKeyboardLayout(threadId)

            ' Extract language ID (low word of keyboard layout)
            Dim languageId As Integer = (keyboardLayout.ToInt32() And &HFFFF)

            ' Skip the first check to initialize previousLanguageId
            If isFirstCheck Then
                previousLanguageId = languageId
                isFirstCheck = False
                Return
            End If

            ' Check if language has changed
            If languageId <> previousLanguageId Then

                previousLanguageId = languageId
                ' Convert to culture info for language code
                Dim cultureInfo As New System.Globalization.CultureInfo(languageId)
                Dim languageCode As String = cultureInfo.TwoLetterISOLanguageName.ToUpper()

                'MessageBox.Show($"Keyboard language changed to: {languageCode}",
                '               "Language Change",
                '               MessageBoxButtons.OK,
                '               MessageBoxIcon.Information)

                frmLanguage.Label1.Text = languageCode
                ' Show the form
                If languageCode = "EN" Then

                    frmLanguage.BackColor = Color.Red
                ElseIf languageCode = "EL" Then
                    frmLanguage.BackColor = Color.Blue
                ElseIf languageCode = "DE" Then
                    frmLanguage.BackColor = Color.Maroon
                ElseIf languageCode = "ES" Then
                    frmLanguage.BackColor = Color.DarkGreen
                ElseIf languageCode = "FR" Then
                    frmLanguage.BackColor = Color.MidnightBlue
                ElseIf languageCode = "IT" Then
                    frmLanguage.BackColor = Color.DarkTurquoise
                Else
                    frmLanguage.BackColor = Color.Green

                End If


                    frmLanguage.Show()




                End If

        Catch ex As Exception
            ' Handle potential errors silently
            ' Could log to a file if needed
        End Try
    End Sub


End Class
