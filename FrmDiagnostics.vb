Public Class FrmDiagnostics
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Clear()
    End Sub

    Private Sub FrmDiagnostics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Updatenow()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Timer1.Enabled = CheckBox1.Checked



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Updatenow()
    End Sub


    Sub Updatenow()
        RichTextBox1.Clear()
        RichTextBox1.AppendText("Read MainTop" & ": " & GetSetting("KeysPal", "GeneralSettings", "frmmaintop", 100) & vbNewLine)
        RichTextBox1.AppendText("Read MainLeft" & ": " & GetSetting("KeysPal", "GeneralSettings", "frmmainleft", 100) & vbNewLine)
        RichTextBox1.AppendText("Read SettingsTop" & ": " & GetSetting("KeysPal", "GeneralSettings", "frmSettingstop", 1) & vbNewLine)
        RichTextBox1.AppendText("Read SettingsLeft" & ": " & GetSetting("KeysPal", "GeneralSettings", "frmSettingsleft", 1) & vbNewLine)
        RichTextBox1.AppendText("-----------------------------------" & vbNewLine)
        RichTextBox1.AppendText("Caps normal is " & CapsLockNormalValue & vbNewLine)
        RichTextBox1.AppendText("Num normal is " & NumLockNormalValue & vbNewLine)
        RichTextBox1.AppendText("Scroll normal is " & ScrollLockNormalValue & vbNewLine)
        RichTextBox1.AppendText("-----------------------------------" & vbNewLine)

        RichTextBox1.AppendText("Time to normal " & TimeToNormalize - CountToNormal)


    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub
End Class