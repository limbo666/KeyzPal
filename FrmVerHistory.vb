Public Class FrmVerHistory
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()

    End Sub

    Private Sub FrmVerHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'RichTextBox1.Text = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\versionhistory.docx")
            RichTextBox1.LoadFile(My.Application.Info.DirectoryPath & "\versionhistory.docx")
        Catch ex As Exception

        End Try
    End Sub
End Class