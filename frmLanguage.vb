Imports System.Drawing.Drawing2D

Public Class frmLanguage
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Me.Close()

    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H8000000 ' WS_EX_NOACTIVATE
            Return cp
        End Get
    End Property

    Private Sub frmLanguage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TopMost = True
        ' Me.TopMost = False
        Me.Height = 16
        Me.Width = 24
        Label1.Width = Me.Width
        Label1.Height = Me.Height


        ' Create a rounded rectangle region
        Dim radius As Integer = 10 ' Adjust this for corner roundness
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
        Dim path As New GraphicsPath()

        ' Add rounded rectangle to the path
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90) ' Top-left corner
        path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90) ' Top-right corner
        path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90) ' Bottom-right corner
        path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90) ' Bottom-left corner
        path.CloseFigure()

        ' Apply the rounded region to the form
        Me.Region = New Region(path)
        Me.DoubleBuffered = True
        Dim mousePosition As Point = Cursor.Position

        ' Set the form's location to the mouse coordinates
        Me.Location = mousePosition + New Size(0, 20)
        Timer1.Enabled = True

    End Sub

End Class