Imports System.Linq
Imports System.Collections.ObjectModel
Public Class PORTION
    Public GlassList As List(Of GLASS_FORMAT)
    Private path As String
    Public ItemList As System.Collections.Generic.List(Of ITEM)
    Public Header As HEADER
    Public OptParametr As OPT_PARAMETER
    Public OptResultHeader As OPT_RESULT_HEADER
    Public OptResultStoockSheetList As System.Collections.Generic.List(Of OPT_RESULT_STOCK_SHEET)
    Public OptResultXAreaList As System.Collections.Generic.List(Of OPT_RESULT_X_AREA)
    Public OptResultYAreaList As System.Collections.Generic.List(Of OPT_RESULT_Y_AREA)

    Sub New(ByVal _path As String)
        path = _path
        'Dim path_tmp As String
        'path_tmp = Form1.FolderPath + "\" + path
        Dim glass = From fold In System.IO.Directory.EnumerateDirectories(path, "?", System.IO.SearchOption.TopDirectoryOnly)
        For Each folder In glass
            Me.GlassList.Add(New GLASS(folder))
        Next
    End Sub
End Class
