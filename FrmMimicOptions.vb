Public Class FrmMimicOptions
    Dim prevEnableHardwareIntegrationvalue As Boolean

    Private Sub FrmMimicOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size

        prevEnableHardwareIntegrationvalue = EnableHardwareIntegration
        Me.Icon = FrmMain.Icon
        Dim deftop As Integer
        Dim defleft As Integer
        If FrmSettings.Visible = True Then
            deftop = FrmSettings.Top + ((FrmSettings.Height - Me.Height) / 2)
            defleft = FrmSettings.Left + ((FrmSettings.Width - Me.Width) / 2)
        Else
            deftop = (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2
            defleft = (My.Computer.Screen.WorkingArea.Width - Me.Width) / 2

        End If
        Me.Top = deftop
        Me.Left = defleft
        EnableHardwareIntegration = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SendUDPCommand("Eeprom", 22689, "255.255.255.255")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SendUDPCommand("capsON", 22689, "255.255.255.255")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SendUDPCommand("capsOFF", 22689, "255.255.255.255")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SendUDPCommand("numON", 22689, "255.255.255.255")
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SendUDPCommand("numOFF", 22689, "255.255.255.255")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SendUDPCommand("scrollON", 22689, "255.255.255.255")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        SendUDPCommand("scrollOFF", 22689, "255.255.255.255")
    End Sub

    Private Sub FrmMimicOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        EnableHardwareIntegration = prevEnableHardwareIntegrationvalue
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SendUDPCommand("Reboot", 22689, "255.255.255.255")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        SendUDPCommand("caps" & ComboBox1.Text, 22689, "255.255.255.255")

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        SendUDPCommand("num" & ComboBox2.Text, 22689, "255.255.255.255")
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        SendUDPCommand("scroll" & ComboBox3.Text, 22689, "255.255.255.255")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()
    End Sub
End Class