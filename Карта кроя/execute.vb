Imports System.IO

Public Class execute
    Public Sub Load(ByVal fileName As String)
        Dim stream As New FileStream(fileName, FileMode.Open)
        Me.Load(stream)
        stream.Close()
    End Sub

    Private Sub Load(stream As FileStream)
        Throw New NotImplementedException
    End Sub

End Class
