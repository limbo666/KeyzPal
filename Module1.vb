
' USAGE
' Dim WithEvents K As New Module_Keyboard
'     K.DiposeHook()
'       K.CreateHook()


'Private Sub K_UP(ByVal Key As String) Handles K.Up ' this can mess thecode
'Dim LastKey = Key
'Label1.Text = LastKey

'end Sub



Public Class Module_Keyboard
    Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal Hook As Integer, ByVal KeyDelegate As KDel, ByVal HMod As Integer, ByVal ThreadId As Integer) As Integer
    Private Declare Function CallNextHookEx Lib "user32" (ByVal Hook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KeyStructure) As Integer
    Private Declare Function UnhookWindowsHookEx Lib "user32" Alias "UnhookWindowsHookEx" (ByVal Hook As Integer) As Integer
    Private Delegate Function KDel(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KeyStructure) As Integer
    Public Shared Event Down(ByVal Key As String)
    Public Shared Event Up(ByVal Key As String)
    Private Shared Key As Integer
    Private Shared KHD As KDel
    Private Structure KeyStructure : Public Code As Integer : Public ScanCode As Integer : Public Flags As Integer : Public Time As Integer : Public ExtraInfo As Integer : End Structure
    Public Sub CreateHook()
        ' Logit(Date.Now & "  " & "Creating Keyboard Hook")
        '    Debuglog(Date.Now & " Creating hook")
        KHD = New KDel(AddressOf Proc)
        Key = SetWindowsHookEx(13, KHD, System.Runtime.InteropServices.Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0)).ToInt32, 0)
    End Sub

    Private Function Proc(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KeyStructure) As Integer
        If (Code = 0) Then
            Select Case wParam
                Case &H100, &H104 : RaiseEvent Down(Feed(CType(lParam.Code, Keys)))
                Case &H101, &H105 : RaiseEvent Up(Feed(CType(lParam.Code, Keys)))
            End Select
        End If
        Return CallNextHookEx(Key, Code, wParam, lParam)
    End Function
    Public Sub DiposeHook()
        '     Logit(Date.Now & "  " & "Destroying Keyboard Hook")
        '   Debuglog(Date.Now & " Destroyning hook")
        UnhookWindowsHookEx(Key)
        MyBase.Finalize()
    End Sub
    Private Function Feed(ByVal e As Keys) As String
        '   Debuglog(e.ToString)
        Select Case e
            Case 65 To 90
                If Control.IsKeyLocked(Keys.CapsLock) Or (Control.ModifierKeys And Keys.Shift) <> 0 Then
                    Return e.ToString
                Else
                    Return e.ToString.ToLower
                End If
            Case 48 To 57
                If (Control.ModifierKeys And Keys.Shift) <> 0 Then
                    Select Case e.ToString
                        Case "D1" : Return "!"
                        Case "D2" : Return "@"
                        Case "D3" : Return "#"
                        Case "D4" : Return "$"
                        Case "D5" : Return "%"
                        Case "D6" : Return "^"
                        Case "D7" : Return "&"
                        Case "D8" : Return "*"
                        Case "D9" : Return "("
                        Case "D0" : Return ")"
                    End Select
                Else
                    Return e.ToString.Replace("D", Nothing)
                End If
            Case 96 To 105
                Return e.ToString.Replace("NumPad", Nothing)
            Case 106 To 111
                Select Case e.ToString
                    Case "Divide" : Return "/"
                    Case "Multiply" : Return "*"
                    Case "Subtract" : Return "-"
                    Case "Add" : Return "+"
                    Case "Decimal" : Return "."
                End Select
            Case 32
                Return " "
            Case 186 To 222
                If (Control.ModifierKeys And Keys.Shift) <> 0 Then
                    Select Case e.ToString
                        Case "OemMinus" : Return "_"
                        Case "Oemplus" : Return "+"
                        Case "OemOpenBrackets" : Return "{"
                        Case "Oem6" : Return "}"
                        Case "Oem5" : Return "|"
                        Case "Oem1" : Return ":"
                        Case "Oem7" : Return """"
                        Case "Oemcomma" : Return "<"
                        Case "OemPeriod" : Return ">"
                        Case "OemQuestion" : Return "?"
                        Case "Oemtilde" : Return "~"
                    End Select
                Else
                    Select Case e.ToString
                        Case "OemMinus" : Return "-"
                        Case "Oemplus" : Return "="
                        Case "OemOpenBrackets" : Return "["
                        Case "Oem6" : Return "]"
                        Case "Oem5" : Return "\"
                        Case "Oem1" : Return ";"
                        Case "Oem7" : Return "'"
                        Case "Oemcomma" : Return ","
                        Case "OemPeriod" : Return "."
                        Case "OemQuestion" : Return "/"
                        Case "Oemtilde" : Return "`"
                    End Select
                End If
            Case Keys.Return
                ' LastKey = "<Enter>"
                ' Return Environment.NewLine
                Return "<Enter>"
            Case Else
                Return "<" + e.ToString + ">"
        End Select
        Return Nothing
    End Function
End Class
