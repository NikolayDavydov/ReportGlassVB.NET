Imports System.Collections.ObjectModel
Module GlobalSub
    Public Function SelectFile(ByVal files As ReadOnlyCollection(Of String), ByVal name As String) As String
        SelectFile = ""
        For Each f In files
            If System.IO.Path.GetFileName(f).ToUpper = name Then
                Return f
            End If
        Next
    End Function

    Public Function TrfCoordRectangle(ByVal origPoint As System.Drawing.Point, ByVal origSize As System.Drawing.Size, _
                                           ByVal szPlate As System.Drawing.Size) As System.Drawing.Point
        Dim newPoint As System.Drawing.Point
        newPoint.X = szPlate.Width - origPoint.X - origSize.Width
        newPoint.Y = szPlate.Height - origPoint.Y - origSize.Height
        Return newPoint
    End Function
    Public Function TrfCoordPoint(ByVal origPoint As System.Drawing.Point, ByVal szPlate As System.Drawing.Size) As System.Drawing.Point
        Dim newPoint As System.Drawing.Point
        newPoint.X = szPlate.Width - origPoint.X
        newPoint.Y = szPlate.Height - origPoint.Y
        Return newPoint
    End Function
    Public Function ResizeByRatio(ByVal x As Integer, ByVal ratio As Double) As Integer
        ResizeByRatio = CInt(CDbl(x) * ratio)
    End Function
    Public Function ResizePoint(ByVal pt As System.Drawing.Point, ByVal ratio As Single) As System.Drawing.Point
        ResizePoint.X = CInt(CDbl(pt.X) * ratio)
        ResizePoint.Y = CInt(CDbl(pt.Y) * ratio)
    End Function
    Public Function ResizeSize(ByVal sz As Size, ByVal ratio As Single) As Size
        ResizeSize.Width = CInt(CDbl(sz.Width) * ratio)
        ResizeSize.Height = CInt(CDbl(sz.Height) * ratio)
    End Function
    'Public Function CreatePlate(ByVal filename As String) As System.Drawing.Bitmap
    'bmp_tmp = New Bitmap(filename)
    'Return bmp_tmp
    'End Function


End Module
