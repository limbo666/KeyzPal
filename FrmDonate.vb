Public Class FrmDonate

    Dim scrollmode As Integer = 0


    Private Sub FrmDonate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Me.Left = My.Computer.Screen.WorkingArea.Width + 20
        TmrScroll.Enabled = True
        Me.Top = My.Computer.Screen.WorkingArea.Height + 20
    End Sub

    Private Sub TmrScroll_Tick(sender As Object, e As EventArgs) Handles TmrScroll.Tick
        'If scrollmode = 0 Then
        '    If Me.Left > My.Computer.Screen.WorkingArea.Width - Me.Width - 20 Then
        '        Me.Left = Me.Left - 10
        '    Else
        '        TmrScroll.Enabled = False
        '        scrollmode = 1
        '        TmrHold.Enabled = True
        '    End If
        'End If
        'If scrollmode = 1 Then
        '    If Me.Left > 0 - Me.Width - 20 Then
        '        Me.Left = Me.Left - 35
        '    Else
        '        TmrScroll.Enabled = False
        '        scrollmode = 0
        '        Me.Left = My.Computer.Screen.WorkingArea.Width + 20
        '        Me.Close()
        '    End If
        'End If

        If scrollmode = 0 Then
            If Me.Top > My.Computer.Screen.WorkingArea.Height - Me.Height - 20 Then
                Me.Top = Me.Top - 5
            Else
                TmrScroll.Enabled = False
                scrollmode = 1
                TmrHold.Enabled = True
            End If
        End If
        If scrollmode = 1 Then
            If Me.Top > 0 - Me.Width - 20 Then
                Me.Top = Me.Top - 30
            Else
                TmrScroll.Enabled = False
                scrollmode = 0
                Me.Top = My.Computer.Screen.WorkingArea.Height + 20
                Me.Close()
            End If
        End If

    End Sub

    Private Sub TmrHold_Tick(sender As Object, e As EventArgs) Handles TmrHold.Tick
        TmrScroll.Enabled = True
    End Sub


    Private Sub GroupBox1_Click(sender As Object, e As EventArgs) Handles GroupBox1.Click
        Process.Start("http://bit.ly/2SZyfsY")
        Close()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Process.Start("http://bit.ly/2SZyfsY")
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Process.Start("http://bit.ly/2SZyfsY")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Process.Start("http://bit.ly/2SZyfsY")
    End Sub
End Class