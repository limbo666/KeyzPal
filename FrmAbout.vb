Public Class FrmAbout
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()

    End Sub

    Private Sub FrmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = Application.ProductName
        Label2.Text = Application.ProductVersion

        Dim deftop As Integer = (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2
        Dim defleft As Integer = (My.Computer.Screen.WorkingArea.Width - Me.Width) / 2

        Me.Top = deftop
        Me.Left = defleft
        '    MsgBox(My.Application.Info.DirectoryPath)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        '
        'https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=CPVNKJT498RC6&source=url
        ' Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=CPVNKJT498RC6&source=url")
        Process.Start("http://bit.ly/2SZyfsY")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Process.Start("http://bit.ly/2SZyfsY")
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        PictureBox1.Visible = False

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "TXN" Then
            SaveSetting("KeysPal", "GeneralSettings", "StDN", True)
            FrmMain.PictureBox8.Visible = False

        End If

    End Sub
End Class