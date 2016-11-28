Public Class ReadOptioDat
    Private file As String 'Имя файла OptioDat
    Private split As String()


    Sub New(ByVal _file As String)
        file = _file
        Dim optlines As String = System.IO.File.ReadAllText(file)
        Dim headtag As New SplitBySubstring()
        headtag.GetArray(optlines, "[---")
        For i = 0 To UBound(headtag.array, 1)
            If headtag.array(i).StartsWith("[---HEADER---]") Then
                Dim header As New SplitBySubstring()
                header.GetArray(headtag.array(i), "[")
            ElseIf headtag.array(i).StartsWith("[---ITEM_ARRAY---]") Then
                Dim item_array As New SplitBySubstring()
                r.GetArray(headtag.array(i), "[")


            End If
        Next

        'Dim tag As String = ""
        'Dim tagType As String
        'Dim strValue As String
        'Dim intValue As Integer
        'Dim optioLine As Int32
        'optioLine = 0
        'Dim maxLine As Int32 = UBound(split, 1)
        'While optioLine < maxLine
        '    If Left(split(optioLine), 3) = "---" Then
        '        Select Case getHeadTag(split(optioLine))
        '            Case "ITEM_ARRAY"
        '                While getHeadTag(split(optioLine + 1)) <> "GLASS_ARRAY"
        '                    optioLine = optioLine + 1
        '                    While getTag(split(optioLine + 1)) <> "REC#"
        '                        Dim item As ITEM_ARRAY
        '                        With item
        '                            tagType = getTagType(split(optioLine))
        '                            tag = getTag(split(optioLine))
        '                            If tagType = "#" Then
        '                                intValue = getValueInt(split(optioLine))
        '                                Select Case tag
        '                                    Case "REC"
        '                                        .REC = intValue
        '                                    Case "BOX"
        '                                        .BOX = intValue
        '                                    Case "ITEM"
        '                                        .ITEM = intValue
        '                                    Case "OPT_GROUP"
        '                                        .OPT_GROUP = intValue
        '                                End Select
        '                            ElseIf tagType = "@" Then
        '                                strValue = getValueStr(split(optioLine))
        '                                Select Case tag
        '                                    Case "ORDER"
        '                                        .ORDER = strValue
        '                                    Case "CODE"
        '                                        .CODE = strValue
        '                                    Case "*RACK"
        '                                        .RACK = strValue
        '                                    Case "SHAPE_FILE"
        '                                        .SHAPE_FILE = strValue
        '                                End Select
        '                            ElseIf tagType = "#." Then
        '                                intValue = getValueInt(split(optioLine))
        '                                Select Case tag
        '                                    Case "WIDTH"
        '                                        .WIDTH = intValue
        '                                    Case "HEIGHT"
        '                                        .HEIGHT = intValue
        '                                End Select
        '                            End If
        '                        End With
        '                    End While
        '                End While

        '        End Select
        '    End If
        '    optioLine = optioLine + 1
        'End While


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
End Class
