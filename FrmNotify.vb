Public Class FrmNotify
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Timer2.Enabled = True
        'Close()

    End Sub

    Private Sub FrmNotify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Me.Top = 200
        '  Me.Visible = False
        Me.Top = (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.WorkingArea.Width - Me.Width) / 2

        Me.TopMost = True
        Me.TopMost = False

        Timer1.Enabled = True
        ' Me.Visible = True
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Me.Opacity > 0.1 Then
            Me.Opacity = Me.Opacity - 0.05
        Else
            Timer2.Enabled = False

            Me.Close()

        End If
    End Sub

End Class