Imports System.IO
Imports System.Net
Module ModuleVariables

    Private Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
    Public Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer

    Public EnableCap As Boolean
    Public EnableNum As Boolean
    Public EnableScroll As Boolean
    Public EnableNormalize As Boolean
    Public TimeToNormalize As Integer = 60
    Public ShowPop As Boolean
    Public StDN As Boolean = False

    Public CapsLockNormalValue As Boolean = False
    Public NumLockNormalValue As Boolean = True
    Public ScrollLockNormalValue As Boolean = False
    Public MakeSoundOnNormalize As Boolean = False
    Public SelectedNormalizationSound As Integer = 0


    Public CountToNormal As Integer = 0 'taken from frmmain

    'Below values for Hardware integration with https://github.com/limbo666/Mimic_For_KeyzPal
    Public EnableHardwareIntegration As Boolean
    Public TargetIpAddress As String = "255.255.255.255"
    Public TargetPort As Integer = 22689

    ' Hardware section end

    Public CurrentFocusedWindow As String

    Public UpperCaseProgramList As New List(Of String)
    Public LowerCaseProgramList As New List(Of String)
    Public UnderSpecificCaseProgram As Boolean = False
    Public SoundOnConditionalChange As Boolean = True


    Public SoundOnNormalChange As Boolean = False
    Public WhichSound As Integer = 1
    Public FullyLoaded As Boolean = False

    Function GetCaption() As String
        Dim Caption As New System.Text.StringBuilder(256)
        Dim hWnd As IntPtr = GetForegroundWindow()
        GetWindowText(hWnd, Caption, Caption.Capacity)
        Return Caption.ToString()
    End Function

    Public Sub LoadForceToPrograms()
        UpperCaseProgramList.Clear()
        UpperCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "UpperCase", "Program1", ""))
        UpperCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "UpperCase", "Program2", ""))
        UpperCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "UpperCase", "Program3", ""))
        UpperCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "UpperCase", "Program4", ""))
        UpperCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "UpperCase", "Program5", ""))
        UpperCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "UpperCase", "Program6", ""))
        UpperCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "UpperCase", "Program7", ""))
        UpperCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "UpperCase", "Program8", ""))
        UpperCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "UpperCase", "Program9", ""))
        UpperCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "UpperCase", "Program10", ""))
        LowerCaseProgramList.Clear()
        LowerCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "LowerCase", "Program1", ""))
        LowerCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "LowerCase", "Program2", ""))
        LowerCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "LowerCase", "Program3", ""))
        LowerCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "LowerCase", "Program4", ""))
        LowerCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "LowerCase", "Program5", ""))
        LowerCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "LowerCase", "Program6", ""))
        LowerCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "LowerCase", "Program7", ""))
        LowerCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "LowerCase", "Program8", ""))
        LowerCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "LowerCase", "Program9", ""))
        LowerCaseProgramList.Add(INIRead(Application.StartupPath & "\lists.ini", "LowerCase", "Program10", ""))
    End Sub



    Public Function CheckForNewVersion()
        Dim LatestVersion As Integer
        Dim RemoteFileNM = "https://raw.githubusercontent.com/limbo666/KeyzPal/master/latest_version/version.txt"
        Dim LocalFileNM = Application.StartupPath & "\version.txt"
        Using WClient As New WebClient()
            Try
                WClient.DownloadFile(RemoteFileNM, LocalFileNM)
            Catch ex As Exception

            End Try

        End Using
        If File.Exists(LocalFileNM) Then
            Dim TextInFile = File.ReadAllText(LocalFileNM)
            TextInFile = Replace(TextInFile, ".", "")
            Try
                LatestVersion = CInt(TextInFile)
            Catch ex As Exception

            End Try
            Dim MyVersion As Integer = CInt(Replace(Application.ProductVersion, ".", ""))

            If LatestVersion - MyVersion > 0 Then
                Return True  ' New version found
            Else
                Return False  ' You are running the latest version
            End If

        End If
    End Function

End Module
