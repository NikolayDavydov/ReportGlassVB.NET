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

    Sub New(ByVal _file As String)
        file = _file
        Dim optlines As String = System.IO.File.ReadAllText(file)
        Dim split As New SplitBySubstring()
        Dim lst As New List(Of String)
        lst = split.GetList(optlines, "[---")

        For Each l In lst
            Dim tag As String = split.getHeadTag(l)
            Select Case tag
                Case "[---HEADER---]"
                    header = l
                Case "[---ITEM_ARRAY---]"
                    item_array = split.GetList(l, "[REC#]")
                Case "[---GLASS_ARRAY---]"
                    glass_array = split.GetList(l, "[REC#]")
                Case "[---OPT_PARAMETER---]"
                    opt_parameter = l
                Case "[---OPT_RESULT_HEADER---]"
                    opt_result_header = l
                Case "[---OPT_RESULT_STOCK_SHEET_ARRAY---]"
                    stock_sheet_array = split.GetList(l, "[STOCK_SHEET#]")
                Case "[---OPT_RESULT_X_AREA_ARRAY---]"
                    x_area_array = split.GetList(l, "[X_AREA#]")
                Case "[---OPT_RESULT_Y_AREA_ARRAY---]"
                    y_area_array = split.GetList(l, "[Y_AREA#]")
                    Dim item_ref As New List(Of String)
                    For Each ref In y_area_array
                        item_ref = split.GetList(ref, "[*U/V/W/Z/_AREA_ITEM_REF#]")
                    Next

            End Select
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


End Class
