Imports System.IO
Imports System.Net

Public Class FrmAbout
    Dim Klist As New List(Of String)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()

    End Sub

    Private Sub FrmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Klist.Add("BKEZWVGRUFJBCCDL")
        Klist.Add("CRGIGOOXMTSPYNLN")
        Klist.Add("DPWNLUSLOVMVAXZS")
        Klist.Add("FEQYEYICZKNFBOSO")
        Klist.Add("JSFPRAWDYGCUIJUH")
        Klist.Add("IFNCZWJYQDOKPIEB")
        Klist.Add("EWYCKZRBBMLPTIAZ")
        Klist.Add("BJODRWOFKCKZXAZU")
        Klist.Add("YCSLAFLLSJKUUULM")
        Klist.Add("MXPHMEZRRMJIFGXR")

        Klist.Add("TNHUMRQLAPIJTRWN")
        Klist.Add("KLWRZTJGRLSUJKTX")
        Klist.Add("GECDNOSXSMZXBKDV")
        Klist.Add("OQUIFPXKTIYNJSUP")
        Klist.Add("CZJTVDWUCVQMAPJD")
        Klist.Add("IVWNMKQQSPJRDXRF")
        Klist.Add("KIESUVPJZDPMKFHJ")
        Klist.Add("JEIKUYJXAVMCXXJR")
        Klist.Add("EVVZEMAFDYOIBMAC")
        Klist.Add("SYFRZDQCOOPOOZZU")

        Klist.Add("KAKKKCEDSDTKWVVI")
        Klist.Add("NYPOPOZWIGKITFZA")
        Klist.Add("ZNSQFPWISGVNBHDZ")
        Klist.Add("CHIYAMAOMVJNIHKS")
        Klist.Add("GNBJGJPXDFUPMSDA")
        Klist.Add("UEWPGHZXXWJEVLMQ")
        Klist.Add("ZGGQAIJISTPTARWN")
        Klist.Add("LZDQZVENKDMIJFKB")
        Klist.Add("TDMRBEBRMSZUIRBI")
        Klist.Add("PNMVZWZTONIOVBHD")

        Klist.Add("USDCPQVSSAYUITVC")
        Klist.Add("FFZNWJQEKRPDCNDL")
        Klist.Add("OWLWJGVIIRCDHAYE")
        Klist.Add("WWPNWDQARXNTBUEV")
        Klist.Add("JQKIHCLYDYSBALOW")
        Klist.Add("QIIFQQVDXCRTGYNW")
        Klist.Add("TOLBORRMVRDKNXWX")
        Klist.Add("RCTSEEVADEYTYUQ")
        Klist.Add("WDUMMXQTPJGNEFED")
        Klist.Add("ZVXGGQKKYYKBOJKE")



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


        If Klist.Contains(TextBox1.Text) Then

            SaveSetting("KeysPal", "GeneralSettings", "StDN", True)
            FrmMain.PictureBox8.Visible = False
            Beep()
        End If



    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim remotefilenm = "https://raw.githubusercontent.com/limbo666/KeyzPal/master/latest_version/version.txt"
        Dim filenm = Application.StartupPath & "\version.txt"
        Using WClient As New WebClient()
            WClient.DownloadFile(remotefilenm, filenm)
        End Using
        If File.Exists(filenm) Then
            Dim filetext = File.ReadAllText(filenm)
            MsgBox(filetext)

        End If

    End Sub
End Class