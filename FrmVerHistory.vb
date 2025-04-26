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

        ' Append the new text and a new line
        ' RichTextBox1.AppendText("New Text" & vbNewLine)
        ' Sets the starting point of the selection         
        RichTextBox1.SelectionStart = Len(RichTextBox1.Text)
        ' Scrolls to the caret
        RichTextBox1.ScrollToCaret()
        ' Select the range 
        RichTextBox1.Select()



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

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub RichTextBox1_GotFocus(sender As Object, e As EventArgs) Handles RichTextBox1.GotFocus
        Button1.Focus() ' to hide the richtextbox annoying caret 
    End Sub
End Class