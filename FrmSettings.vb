﻿Imports Microsoft.Win32

Public Class FrmSettings
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

        TimeToNormalize = NumericUpDown1.Value

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

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        CheckBox1.Checked = EnableCap
        CheckBox2.Checked = EnableNum
        CheckBox3.Checked = EnableScroll
        CheckBox4.Checked = EnableNormalize
        CheckBox5.Checked = ShowPop
        NumericUpDown1.Value = TimeToNormalize
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
        Me.Top = deftop
        Me.Left = defleft


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


End Class