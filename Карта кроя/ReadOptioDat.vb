Public Class ReadOptioDat
    Private file As String 'Имя файла OptioDat
    Private split As String()
    Public header As String
    Public opt_parameter As String
    Public opt_result_header As String
    Public item_array As New List(Of String)
    Public glass_array As New List(Of String)
    Public stock_sheet_array As New List(Of String)
    Public x_area_array As New List(Of String)
    Public y_area_array As New List(Of String)
    Public area_item_ref As New List(Of String)

    Sub New(ByVal _file As String)
        file = _file
        Dim optlines As String = System.IO.File.ReadAllText(file)
        Dim split As New SplitBySubstring()
        Dim lst As New List(Of String)
        lst = split.GetList(optlines, "[---")

        For Each l In lst
            If l.Contains("[---HEADER---]") Then
                header = l
            ElseIf l.Contains("[---ITEM_ARRAY---]") Then
                item_array = split.GetList(l, "[REC#]")
            ElseIf l.Contains("[---GLASS_ARRAY---]") Then
                glass_array = split.GetList(l, "[REC#]")
            ElseIf l.Contains("[---OPT_PARAMETER---]") Then
                opt_parameter = l
            ElseIf l.Contains("[---OPT_RESULT_HEADER---]") Then
                opt_result_header = l
            ElseIf l.Contains("[---OPT_RESULT_STOCK_SHEET_ARRAY---]") Then
                stock_sheet_array = split.GetList(l, "[STOCK_SHEET#]")
            ElseIf l.Contains("[---OPT_RESULT_X_AREA_ARRAY---]") Then
                x_area_array = split.GetList(l, "[X_AREA#]")
            ElseIf l.Contains("[---OPT_RESULT_Y_AREA_ARRAY---]") Then
                y_area_array = split.GetList(l, "[Y_AREA#]")
                Dim item_ref As New List(Of String)
                For Each ref In y_area_array
                    item_ref = split.GetList(ref, "[*U/V/W/Z_AREA_ITEM_REF#]")
                    For Each ref2 In item_ref
                        area_item_ref.Add(ref2)
                    Next
                Next

            End If
            'Dim tag As String = split.getHeadTag(l)
            'Select Case tag
            '    Case "[---HEADER---]"

            '    Case "[---ITEM_ARRAY---]"

            '    Case "[---GLASS_ARRAY---]"

            '    Case "[---OPT_PARAMETER---]"

            '    Case "[---OPT_RESULT_HEADER---]"

            '    Case "[---OPT_RESULT_STOCK_SHEET_ARRAY---]"

            '    Case "[---OPT_RESULT_X_AREA_ARRAY---]"

            '    Case "[---OPT_RESULT_Y_AREA_ARRAY---]"

            'End Select
        Next
    End Sub

   
    Private Function getHeadTag(ByVal str) As String
        getHeadTag = ""
        If Left(str, 3) = "---" Then
            getHeadTag = Left(str, Len(str) - 6)
            getHeadTag = Right(getHeadTag, Len(getHeadTag) - 3)
            'getHeadTag = Mid(str, 2, str.indexof("]"))
        End If
    End Function
    Private Function getTagType(ByVal str) As String
        getTagType = ""
        Dim str_tmp As String = Mid(str, 1, str.indexof("]"))
        If Right(str_tmp, 1) = "@" Then Return "@"
        If Right(str_tmp, 1) = "#" Then Return "#"
        If Right(str_tmp, 2) = "#." Then Return "#."
    End Function
    Private Function getTag(ByVal str) As String
        getTag = Mid(str, 1, str.indexof("]"))
        If Right(getTag, 1) = "@" Or Right(getTag, 1) = "#" Then
            getTag = Left(getTag, Len(getTag) - 1)
        ElseIf Right(getTag, 2) = "#." Then
            getTag = Left(getTag, Len(getTag) - 2)
        End If
    End Function
    Private Function getValueStr(ByVal str)
        Dim getTag As String = Mid(str, 1, str.indexof("]"))
        'Dim str_tmp As String
        getValueStr = ""
        'getTag() = Mid(str, 1, str.indexof("]"))
        If Right(getTag, 1) = "@" Then
            getValueStr = Microsoft.VisualBasic.Right(str, Len(str) - str.indexof("]") - 1)
        End If
    End Function
    Private Function getValueInt(ByVal str) As Integer
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
    Public Function getXAreaRef(ByVal id As Integer) As String
        getXAreaRef = x_area_array(id)
    End Function
    Public Function getYAreaRef(ByVal id As Integer) As String
        getYAreaRef = y_area_array(id)
    End Function
    Public Function getItem(ByVal id As Integer) As String
        getItem = item_array(id)
    End Function
    Private Function getValue(ByVal source As String, ByVal field As String) As String
        Dim strArray As String() = source.Split(New Char() {"["c})
        Dim str2 As String
        For Each str2 In strArray
            If str2.StartsWith(field) Then
                Dim index As Integer = str2.IndexOf("="c)
                Dim str3 As String = str2.Substring((index + 1), (str2.Length - (index + 1)))
                If str2.Contains("#") Then
                    str3 = str3.Replace(".", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator).Replace(",", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                End If
                Return str3
            End If
        Next
        Return String.Empty
    End Function
    Private Function getValue1(ByVal source As String, ByVal field As String) As String
        If Not source.Contains(field) Then
            Return String.Empty
        End If
        Dim num As Integer = (source.IndexOf(field) + field.Length)
        Dim str As String = String.Empty
        Dim i As Integer
        For i = num To source.Length - 1
            If (source.Chars(i) = "["c) Then
                Return str
            End If
            str = (str & source.Chars(i))
        Next i
        Return str
    End Function
End Class
