Public Class FrmMain
    Dim IsFirstTimeRun As Boolean = True
    Dim StDN As Boolean = False

    Dim CommandClose = False
    Dim TotalIndicators As Integer = 0
    Dim Cap As Integer
    Dim Num As Integer
    Dim Scr As Integer
    Dim Debug As Boolean = False
    Dim ShowPop As Boolean = False

    Dim FullyLoaded As Boolean

    Dim OldCap As Integer = -1
    Dim OldNum As Integer = -1
    Dim OldScr As Integer = -1

    Dim CountToNormal As Integer = 0
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)

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

        Dim deftop As Integer = (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2
        Dim defleft As Integer = (My.Computer.Screen.WorkingArea.Width - Me.Width) / 2
        EnableCap = GetSetting("KeysPal", "GeneralSettings", "CapsLock", True)
        EnableNum = GetSetting("KeysPal", "GeneralSettings", "NumLock", True)
        EnableScroll = GetSetting("KeysPal", "GeneralSettings", "ScrollLock", False)
        EnableNormalize = GetSetting("KeysPal", "GeneralSettings", "EnableNormalize", False)
        TimeToNormalize = GetSetting("KeysPal", "GeneralSettings", "TimeToNormalize", 60)
        Me.Top = GetSetting("KeysPal", "GeneralSettings", "frmmaintop", deftop)
        Me.Left = GetSetting("KeysPal", "GeneralSettings", "frmmainleft", defleft)

        IsFirstTimeRun = GetSetting("KeysPal", "GeneralSettings", "IsFirstTimeRun", True)

        If Me.Left < 0 Then
            Me.Left = defleft
        End If
        If Me.Top < 0 Then
            Me.Top = deftop
        End If

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
        If EnableNum = True Then
            TotalIndicators += 1
            NotifyIcon3.Visible = True
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Debug = True Then
            FrmDiagnostics.Show()
        End If
        SaveSetting("KeysPal", "GeneralSettings", "IsFirstTimeRun", False)
        FullyLoaded = False
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
        UpdateIcons()
        FullyLoaded = True

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
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If My.Computer.Keyboard.CapsLock = True Then
            Cap = 1
            Label1.Text = "Caps Lock ON"

            If cap <> oldcap Then
                Dim img As Image = PictureBox1.Image
                Dim bm As Bitmap = img
                Dim hIcon As IntPtr = bm.GetHicon
                Dim TheIcon As Icon = Icon.FromHandle(hIcon)
                NotifyIcon1.Icon = TheIcon
                CountToNormal = 0
                OldCap = Cap
                NotifyIcon1.Text = "Caps Lock ON"
                If showpop = True And FullyLoaded = True Then
                    FrmNotify.Label1.Text = "CAPS"
                    FrmNotify.Label2.Text = "ΟΝ"
                    FrmNotify.Show()
                End If

            End If
            Panel1.BackColor = Color.DimGray
        Else
            Cap = 0
            Label1.Text = "Caps Lock OFF"
            If cap <> oldcap Then
                Dim img As Image = PictureBox4.Image
                Dim bm As Bitmap = img
                Dim hIcon As IntPtr = bm.GetHicon
                Dim TheIcon As Icon = Icon.FromHandle(hIcon)
                NotifyIcon1.Icon = TheIcon
                CountToNormal = 0
                OldCap = Cap
                NotifyIcon1.Text = "Caps Lock OFF"
                If showpop = True And FullyLoaded = True Then
                    FrmNotify.Label1.Text = "CAPS"
                    FrmNotify.Label2.Text = "OFF"
                    FrmNotify.Show()
                End If

            End If
            Panel1.BackColor = Color.Red
        End If

        If My.Computer.Keyboard.NumLock = True Then
            Num = 1
            Label2.Text = "Num Lock ON"
            If num <> oldnum Then
                Dim img As Image = PictureBox2.Image
                Dim bm As Bitmap = img
                Dim hIcon As IntPtr = bm.GetHicon
                Dim TheIcon As Icon = Icon.FromHandle(hIcon)
                NotifyIcon2.Icon = TheIcon
                counttonormal = 0
                oldnum = num
                NotifyIcon2.Text = "Num Lock ON"
                If showpop = True And FullyLoaded = True Then
                    FrmNotify.Label1.Text = "NUM"
                    FrmNotify.Label2.Text = "ON"
                    FrmNotify.Show()
                End If

            End If
            Panel2.BackColor = Color.DimGray
        Else
            num = 0
            Label2.Text = "Num Lock OFF"
            If num <> oldnum Then
                Dim img As Image = PictureBox5.Image
                Dim bm As Bitmap = img
                Dim hIcon As IntPtr = bm.GetHicon
                Dim TheIcon As Icon = Icon.FromHandle(hIcon)
                NotifyIcon2.Icon = TheIcon
                counttonormal = 0
                oldnum = num
                NotifyIcon2.Text = "Num Lock OFF"

                If showpop = True And FullyLoaded = True Then
                    FrmNotify.Label1.Text = "NUM"
                    FrmNotify.Label2.Text = "OFF"
                    FrmNotify.Show()
                End If

            End If
            Panel2.BackColor = Color.Red
        End If

        If My.Computer.Keyboard.ScrollLock = True Then

            scr = 1
            Label3.Text = "Scroll Lock ON"
            If scr <> oldscr Then
                Dim img As Image = PictureBox3.Image
                Dim bm As Bitmap = img
                Dim hIcon As IntPtr = bm.GetHicon
                Dim TheIcon As Icon = Icon.FromHandle(hIcon)
                NotifyIcon3.Icon = TheIcon
                counttonormal = 0
                oldscr = scr
                NotifyIcon3.Text = "Scroll Lock ON"
                If showpop = True And FullyLoaded = True Then
                    FrmNotify.Label1.Text = "SCRL"
                    FrmNotify.Label2.Text = "ON"
                    FrmNotify.Show()
                End If

            End If
            Panel3.BackColor = Color.DimGray
        Else

            scr = 0
            Label3.Text = "Scroll Lock OFF"
            If scr <> oldscr Then
                Dim img As Image = PictureBox6.Image
                Dim bm As Bitmap = img
                Dim hIcon As IntPtr = bm.GetHicon
                Dim TheIcon As Icon = Icon.FromHandle(hIcon)
                NotifyIcon3.Icon = TheIcon
                counttonormal = 0
                oldscr = scr
                NotifyIcon3.Text = "Scroll Lock OFF"
                If showpop = True And FullyLoaded = True Then
                    FrmNotify.Label1.Text = "SCRL"
                    FrmNotify.Label2.Text = "OFF"
                    FrmNotify.Show()
                End If

            End If
            Panel3.BackColor = Color.Red
        End If

        Call UpdateIcons()

    End Sub

    Sub UpdateIcons()
        If cap = 1 Then
            PictureBox1.Visible = True
            PictureBox4.Visible = False

        Else
            PictureBox1.Visible = False
            PictureBox4.Visible = True
        End If
        If num = 1 Then
            PictureBox2.Visible = True
            PictureBox5.Visible = False
        Else
            PictureBox2.Visible = False
            PictureBox5.Visible = True
        End If

        If scr = 1 Then
            PictureBox3.Visible = True
            PictureBox6.Visible = False
        Else
            PictureBox3.Visible = False
            PictureBox6.Visible = True
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'CountActiveIndicators()
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
        FrmDonate.Show()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If counttonormal < TimeToNormalize Then
            counttonormal = counttonormal + 1

        Else
            'turn CAPS lock off
            If My.Computer.Keyboard.CapsLock = True Then

                Call keybd_event(System.Windows.Forms.Keys.CapsLock, &H14, 1, 0)
                Call keybd_event(System.Windows.Forms.Keys.CapsLock, &H14, 3, 0)
            End If


            'turn NUM lock on
            If My.Computer.Keyboard.NumLock = False Then
                Call keybd_event(System.Windows.Forms.Keys.NumLock, &H14, 1, 0)
                Call keybd_event(System.Windows.Forms.Keys.NumLock, &H14, 3, 0)
            End If

            'turn Scroll lock off
            If My.Computer.Keyboard.ScrollLock = True Then
                Call keybd_event(System.Windows.Forms.Keys.Scroll, &H14, 1, 0)
                Call keybd_event(System.Windows.Forms.Keys.Scroll, &H14, 3, 0)
            End If


            counttonormal = 0
            '  MsgBox("Back to normal")
        End If
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
        FrmDonate.Show()
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

    Private Sub Button3_Click(sender As Object, e As EventArgs)


    End Sub
End Class
