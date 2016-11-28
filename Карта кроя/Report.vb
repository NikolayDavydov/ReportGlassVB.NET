Imports System.Linq
Imports System.Collections.ObjectModel
Public Class Report
    Public path As String
    Public portions As List(Of PORTION)





    Sub New(ByVal _path As String)
        path = _path
        'Dim path_tmp As String
        'path_tmp = Form1.FolderPath + "\" + path
        Dim portions = From fold In System.IO.Directory.EnumerateDirectories(path, "?", System.IO.SearchOption.TopDirectoryOnly)
        For Each folder In portions
            Dim number As Integer
            Dim result As Boolean = Int32.TryParse(My.Computer.FileSystem.GetName(folder), number)
            If result Then
                Me.portions.Add(New PORTION(folder))
            End If
        Next
        

        'numGlass = 0

        'If result Then
        '    ReDim Preserve PORTION(numPortion)
        '    ReDim Preserve prf(numPortion)
        '    With PORTION(numPortion)
        '        .numPortion = CInt(My.Computer.FileSystem.GetName(folder))
        '        Dim glassesPath As String
        '        glassesPath = path_tmp + "\" + .numPortion.ToString + "\1\"
        '        Dim glasses = From fold2 In _
        '                      Directory.EnumerateDirectories(glassesPath, "*", SearchOption.TopDirectoryOnly)
        '        For Each glass In glasses
        '            ReDim Preserve .glass(numGlass)
        '            ReDim Preserve prf(numPortion).GlassInPrf(numGlass)
        '            .glass(numGlass).glassName = My.Computer.FileSystem.GetName(glass)
        '            files = My.Computer.FileSystem.GetFiles(glass, FileIO.SearchOption.SearchAllSubDirectories, "*.fil")
        '            'Glak.fil
        '            file = SelectFile(files, "GLAK.FIL")
        '            ReadGlakFil(file, numPortion, numGlass)
        '            'Tra1_neu.fil
        '            file = SelectFile(files, "TRA1_NEU.FIL")
        '            ReadTraFil(file, numPortion, numGlass)
        '            'Tra2_neu.fil
        '            file = SelectFile(files, "TRA2_NEU.FIL")
        '            ReadTraFil(file, numPortion, numGlass)
        '            'Tra3_neu.fil
        '            file = SelectFile(files, "TRA3_NEU.FIL")
        '            ReadTraFil(file, numPortion, numGlass)
        '            'Tra4.fil
        '            file = SelectFile(files, "TRA4.FIL")
        '            ReadTraFil(file, numPortion, numGlass)
        '            'Обработка optio.dat
        '            files = My.Computer.FileSystem.GetFiles(glass, FileIO.SearchOption.SearchAllSubDirectories, "optio.dat")
        '            file = SelectFile(files, "OPTIO.DAT")
        '            'ReadOptioDat(file, numPortion, numGlass)
        '            'обработка ANZ файлов
        '            files = My.Computer.FileSystem.GetFiles(glass, FileIO.SearchOption.SearchAllSubDirectories, "*.anz")
        '            For Each file In files
        '                ReadAnz(file, numPortion, numGlass)
        '            Next
        '            numGlass = numGlass + 1
        '        Next
        '    End With
        'End If
        'numPortion = numPortion + 1


    End Sub
End Class
