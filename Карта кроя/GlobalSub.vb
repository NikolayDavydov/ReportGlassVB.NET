Imports System.Collections.ObjectModel
Imports System.Globalization

Module GlobalSub
    Public Function SelectFile(ByVal files As ReadOnlyCollection(Of String), ByVal name As String) As String
        SelectFile = ""
        For Each f In files
            If System.IO.Path.GetFileName(f).ToUpper = name Then
                Return f
            End If
        Next
    End Function
    Public Function getValueInt(ByVal str) As Integer
        Dim str_tmp As String
        Dim getTag As String = Mid(str, 1, str.indexof("]"))
        'str_tmp = Microsoft.VisualBasic.Right(str, Len(str) - str.indexof("]") - 2)
        If Right(getTag, 1) = "#" Then
            str_tmp = Right(str, Len(str) - str.indexof("]") - 2)
            getValueInt = Convert.ToInt32(str_tmp)
        ElseIf Right(getTag, 2) = "#." Then
            str_tmp = Right(str, Len(str) - str.indexof("]") - 2)
            str_tmp = Left(str_tmp, str_tmp.IndexOf("."))
            getValueInt = Convert.ToInt32(str_tmp)
        End If
    End Function
    Public Function AsFloat(ByVal s As String) As Double
        Return Double.Parse(s.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator), (CultureInfo.InvariantCulture))
    End Function
    Public Function getValueDouble(ByVal str) As Double
        Dim str_tmp As String
        Dim getTag As String = Mid(str, 1, str.indexof("]"))
        'str_tmp = Microsoft.VisualBasic.Right(str, Len(str) - str.indexof("]") - 2)
        If Right(getTag, 2) = "#." Then
            str_tmp = Right(str, Len(str) - str.indexof("]") - 2)
            str_tmp = Left(str_tmp, str_tmp.IndexOf("."))
            getValueDouble = AsFloat(str_tmp)
        End If
    End Function
    Public Function getValueStr(ByVal str)
        Dim getTag As String = Mid(str, 1, str.indexof("]"))
        'Dim str_tmp As String
        getValueStr = ""
        'getTag() = Mid(str, 1, str.indexof("]"))
        If Right(getTag, 1) = "@" Then
            getValueStr = Microsoft.VisualBasic.Right(str, Len(str) - str.indexof("]") - 1)
        End If
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
    Public Function GetInt32(ByVal value As Object) As Integer
        Try
            If ((Not value Is DBNull.Value) AndAlso (Not value Is Nothing)) Then
                Return Convert.ToInt32(value)
            End If
            Return 0
        Catch 'obj1 As Object
            Return 0
        End Try
    End Function
    Public Function GetDouble(ByVal value As Object) As Double
        Try
            If ((Not value Is DBNull.Value) AndAlso (Not value Is Nothing)) Then
                Return Convert.ToDouble(DecimalNoramalize(value.ToString))
            End If
            Return 0
        Catch ' obj1 As Object
            Return 0
        End Try
    End Function
    Public Function DecimalNoramalize(ByVal source As String) As String
        source = source.Replace(",", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        source = source.Replace(".", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        Return source
    End Function
    'Public Function CreatePlate(ByVal filename As String) As System.Drawing.Bitmap
    'bmp_tmp = New Bitmap(filename)
    'Return bmp_tmp
    'End Function
End Module
