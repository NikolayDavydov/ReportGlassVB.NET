Imports System.Linq
Imports System.IO
Imports System.Collections.ObjectModel
Public Class Report
    Public Shared path As String
    Public Shared portions As List(Of PORTION)

    Sub New(ByVal _path As String)
        path = _path
        Dim path_tmp As String

        path_tmp = IIf(Form1.FolderPath = String.Empty, path, Form1.FolderPath + "\" + path)
        Dim portions = From fold In Directory.EnumerateDirectories(path_tmp, "?", System.IO.SearchOption.TopDirectoryOnly)
        For Each folder In portions
            Dim number As Integer
            Dim result As Boolean = Int32.TryParse(My.Computer.FileSystem.GetName(folder), number)
            If result Then
                Report.portions.Add(New PORTION(folder))
            End If
        Next
    End Sub


End Class
