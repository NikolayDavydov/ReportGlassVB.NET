Public Class SplitBySubstring
    'Public Function GetArray(ByVal _str As String, ByVal _separator As String) As String()
    '    Dim str As String
    '    Dim separator As String
    '    Dim array() As String
    '    Dim lenstr As Integer
    '    Dim lenseparator As Integer
    '    'убираем перевод строки
    '    str = _str
    '    separator = _separator
    '    lenstr = Len(str)
    '    lenseparator = Len(separator)
    '    str = StringPreprocess(str) 'Убираем переводы строк
    '    Dim mid1 As String
    '    Dim mid2 As String
    '    Dim k As Integer = 0
    '    ReDim Preserve array(k)
    '    For i = 1 To lenstr - lenseparator
    '        mid1 = Mid(str, i, lenseparator).ToUpper
    '        If mid1 = separator.ToUpper Then
    '            For j = i + lenseparator To lenstr - lenseparator
    '                mid2 = Mid(str, j, lenseparator).ToUpper
    '                If mid2 = separator.ToUpper Or j = lenstr - lenseparator Then
    '                    If k > UBound(array, 1) Then
    '                        ReDim Preserve array(k)
    '                    End If
    '                    array(k) = Mid(str, i, j - i)
    '                    k = k + 1
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Next
    '    Return array
    'End Function
    Public Function GetList(ByVal _str As String, ByVal _separator As String) As List(Of String)
        Dim str As String
        Dim separator As String
        Dim listString As New List(Of String)
        Dim lenstr As Integer
        Dim lenseparator As Integer
        'убираем перевод строки
        str = _str
        separator = _separator
        lenstr = Len(str)
        lenseparator = Len(separator)
        str = StringPreprocess(str) 'Убираем переводы строк

        Dim mid1 As String
        Dim mid2 As String
        For i = 1 To lenstr - lenseparator
            mid1 = Mid(str, i, lenseparator).ToUpper
            If mid1 = separator.ToUpper Then
                For j = i + lenseparator To lenstr - lenseparator
                    mid2 = Mid(str, j, lenseparator).ToUpper
                    If mid2 = separator.ToUpper Or j = lenstr - lenseparator Then
                        listString.Add(Mid(str, i, j - i))
                        Exit For
                    End If
                Next
            End If
        Next
        Return listString
    End Function


    Private Function StringPreprocess(ByVal _str As String) As String
        Replace(_str, "\r", String.Empty)
        Replace(_str, "\n", String.Empty)
        Replace(_str, "\r\n", String.Empty)
        Return _str
    End Function

    Public Function getHeadTag(ByVal str As String) As String
        getHeadTag = ""
        If Left(str, 4) = "[---" Then
            getHeadTag = Left(str, str.IndexOf("---]") + 4)
        End If

    End Function
    Public Function getTag(ByVal _str) As String
        Dim str As String
        str = _str
        If Not str.StartsWith("[---") Then
            str = Mid(str, str.IndexOf("["), str.IndexOf("]"))
            If Right(str, 1) = "@" Or Right(str, 1) = "#" Then
                str = Left(str, Len(str) - 1)
            ElseIf Right(str, 2) = "#." Then
                str = Left(str, Len(str) - 2)
            End If
        End If
        Return str
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
