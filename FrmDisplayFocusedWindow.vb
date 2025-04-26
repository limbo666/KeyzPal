Imports System.ComponentModel


Public Class FrmDisplayFormostWindow

    Dim hideLabelcounter As Integer = 0

    Private Sub FrmDisplayFormostWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Me.Top = 0
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim CapTxt As String = GetCaption()
        Label1.Text = CapTxt

        If hideLabelcounter < 30 Then
            hideLabelcounter += 1
        Else
            Label3.Visible = False
            hideLabelcounter = 0

        End If

    End Sub

    Private Sub FrmDisplayFormostWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Timer1.Enabled = True
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label1_MouseHover(sender As Object, e As EventArgs) Handles Label1.MouseHover
        Try
            Clipboard.SetText(Label1.Text)
            Label3.Visible = True
        Catch ex As Exception

        End Try
    End Sub
End Class