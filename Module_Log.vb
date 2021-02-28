Imports System.IO

Module Module_Log
    Public Log As Boolean
    Public Debug As Boolean

    Public Sub Logit(ByVal LogData As String)
        If Log = True Then
            Try
                Using w As StreamWriter = File.AppendText("KeyzPal_activity.log")
                    w.WriteLine(LogData)
                    w.Close()
                End Using
            Catch ex As Exception

            End Try

        Else
            Exit Sub
        End If
    End Sub
    Public Sub Debuglog(ByVal LogData As String)
        If Debug = True Then
            Using w As StreamWriter = File.AppendText("KeyzPal_debug.log")
                w.WriteLine(LogData)
                w.Close()
            End Using
        Else
            Exit Sub
        End If
    End Sub



End Module