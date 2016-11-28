Public Class SplitBySubstring
    Public array() As String
    Public Sub GetArray(ByVal _str As String, ByVal _separator As String)
        Dim str As String
        Dim separator As String

        Dim lenstr As Integer
        Dim lenseparator As Integer
        'убираем перевод строки
        str = _str
        separator = _separator
        lenstr = Len(str)
        lenseparator = Len(separator)
        Replace(str, "\r", String.Empty)
        Replace(str, "\n", String.Empty)
        Replace(str, "\r\n", String.Empty)
        Dim mid1 As String
        Dim mid2 As String
        Dim k As Integer = 0
        ReDim Preserve array(k)
        For i = 1 To lenstr - lenseparator
            mid1 = Mid(str, i, lenseparator).ToUpper
            If mid1 = separator.ToUpper Then
                For j = i + lenseparator To lenstr - lenseparator
                    mid2 = Mid(str, j, lenseparator).ToUpper
                    If mid2 = separator.ToUpper Or j = lenstr - lenseparator Then
                        If k > UBound(array, 1) Then
                            ReDim Preserve array(k)
                        End If
                        array(k) = Mid(str, i, j - i)
                        k = k + 1
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub
    Private Function getTag(ByVal str) As String
        getTag = Mid(str, str.indexof("["), str.indexof("]"))
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
