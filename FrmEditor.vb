
Imports System.IO

Public Class FrmEditor

    Private filePath As String = Application.StartupPath & "\lists.ini"
    Private defaultText As String = "[UpperCase]" & vbCrLf &
        "Program1 = ""Set your UPPER CASE programs here""" & vbCrLf &
        "Program2 = ""a part of title is normally enough""" & vbCrLf &
        "Program3 = ""but please try to use unique values to avoid misbehavior""" & vbCrLf &
        "Program4 = ""set program4 here""" & vbCrLf &
        "Program5 = ""set program5 here""" & vbCrLf &
        "Program6 = ""set program6 here""" & vbCrLf &
        "Program7 = ""set program7 here""" & vbCrLf &
        "Program8 = ""set program8 here""" & vbCrLf &
        "Program9 = ""set program9 here""" & vbCrLf &
        "Program10 = ""Upper""" & vbCrLf &
        "[Lowercase]" & vbCrLf &
        "Program1 = ""SET YOUR lower case PROGRAMS HERE""" & vbCrLf &
        "Program2 = ""a part of title is normally enough""" & vbCrLf &
        "Program3 = ""but please try to use unique values to avoid misbehavior""" & vbCrLf &
        "Program4 = ""set program4 here""" & vbCrLf &
        "Program5 = ""set program5 here""" & vbCrLf &
        "Program6 = ""set program6 here""" & vbCrLf &
        "Program7 = ""set program7 here""" & vbCrLf &
        "Program8 = ""set program8 here""" & vbCrLf &
        "Program9 = ""set program9 here""" & vbCrLf &
        "Program10 = ""lower"""

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = FrmMain.Icon
        Dim deftop As Integer
        Dim defleft As Integer
        If FrmSettings.Visible = True Then
            deftop = FrmSettings.Top + ((FrmSettings.Height - Me.Height) / 2)
            defleft = FrmSettings.Left + ((FrmSettings.Width - Me.Width) / 2)
        Else
            deftop = (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2
            defleft = (My.Computer.Screen.WorkingArea.Width - Me.Width) / 2

        End If
        Me.Top = deftop
        Me.Left = defleft


        If File.Exists(filePath) Then
            RichTextBox1.Text = File.ReadAllText(filePath)
            Label1.Text = "Edit lists below to add your programs"
        Else
            RichTextBox1.Text = defaultText
            Label1.Text = "Default data - Edit lists below to add your programs"
        End If
    End Sub



    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub

    Private Sub SaveButton_Click_1(sender As Object, e As EventArgs) Handles SaveButton.Click
        If File.Exists(filePath) Then
            Dim existingLines As String() = File.ReadAllLines(filePath)
            Dim newLines As String() = RichTextBox1.Text.Split({vbCrLf}, StringSplitOptions.None)
            Dim updatedLines As New List(Of String)

            For i As Integer = 0 To existingLines.Length - 1
                If i >= newLines.Length Then
                    Exit For
                End If

                If existingLines(i) <> newLines(i) Then
                    updatedLines.Add(newLines(i))
                Else
                    updatedLines.Add(existingLines(i))
                End If
            Next
            File.WriteAllLines(filePath, updatedLines)
        Else
            File.WriteAllText(filePath, RichTextBox1.Text)
        End If

        Call FrmSettings.LinkLabel2_LinkClicked(Nothing, Nothing)
        Me.Close()

    End Sub




End Class