Imports System.Linq
Imports System.Collections.ObjectModel
Imports System.IO
Imports Report.GlobalSub

Public Class PORTION
    Public GlassList As List(Of GLASS_FOLDER)
    Private path As String
    Private files As ReadOnlyCollection(Of String)
    Private file As String
    Public ItemList As System.Collections.Generic.List(Of ITEM)
    Public Header As HEADER
    Public OptParametr As OPT_PARAMETER
    Public OptResultHeader As OPT_RESULT_HEADER
    Public OptResultStoockSheetList As System.Collections.Generic.List(Of OPT_RESULT_STOCK_SHEET)
    Public OptResultXAreaList As System.Collections.Generic.List(Of OPT_RESULT_X_AREA)
    Public OptResultYAreaList As System.Collections.Generic.List(Of OPT_RESULT_Y_AREA)

    Sub New(ByVal _path As String)
        path = _path
        Dim glassesPath As String
        glassesPath = path + "\1\"
        Dim glasses = From fold2 In Directory.EnumerateDirectories(glassesPath, "*", SearchOption.TopDirectoryOnly)
        For Each glass In glasses
            files = My.Computer.FileSystem.GetFiles(glass, FileIO.SearchOption.SearchAllSubDirectories, "*.fil")
            file = SelectFile(files, "OPTIO.DAT")
            'Me.GlassList.Add(New GLASS_FOLDER(file))
        Next
    End Sub
End Class
