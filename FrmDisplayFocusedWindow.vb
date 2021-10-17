Imports System.ComponentModel

Public Class FrmDisplayFormostWindow
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
    End Sub

    Private Sub FrmDisplayFormostWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Timer1.Enabled = True
    End Sub
End Class