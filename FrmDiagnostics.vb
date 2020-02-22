Public Class FrmDiagnostics
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Clear()
    End Sub

    Private Sub FrmDiagnostics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.AppendText("Read MainTop" & ": " & GetSetting("KeysPal", "GeneralSettings", "frmmaintop", 100) & vbNewLine)
        RichTextBox1.AppendText("Read MainLeft" & ": " & GetSetting("KeysPal", "GeneralSettings", "frmmainleft", 100) & vbNewLine)
        RichTextBox1.AppendText("Read SettingsTop" & ": " & GetSetting("KeysPal", "GeneralSettings", "frmSettingstop", 1) & vbNewLine)
        RichTextBox1.AppendText("Read SettingsLeft" & ": " & GetSetting("KeysPal", "GeneralSettings", "frmSettingsleft", 1) & vbNewLine)
    End Sub
End Class