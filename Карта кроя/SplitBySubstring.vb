Public Class SplitBySubstring
    Public Function GetList(ByVal str As String, ByVal separator As String) As List(Of String)
        Dim list As New List(Of String)
        Dim str1 As String
        Dim i As Integer
        Dim index1, index2 As Integer
        i = 0
        Do
            index1 = str.IndexOf(separator, i)
            If index1 <> -1 Then
                index2 = str.IndexOf(separator, index1 + 1)
                If index2 <> -1 Then
                    i = index2
                    str1 = Mid(str, index1 + 1, index2 - index1)
                    list.Add(str1)
                Else
                    str1 = Mid(str, index1)
                    list.Add(str1)
                    i = index1 + 1
                End If
            Else
                Return list
            End If
        Loop While str.IndexOf(separator, i) <> -1
        Return list
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
    Private Function getValueStr(ByVal _str)
        Dim getTag As String = Mid(_str, 1, _str.indexof("]"))
        'Dim str_tmp As String
        getValueStr = ""
        'getTag() = Mid(str, 1, str.indexof("]"))
        If Right(getTag, 1) = "@" Then
            getValueStr = Microsoft.VisualBasic.Right(_str, Len(_str) - _str.indexof("]") - 1)
        End If
    End Function
    Public Function getValueDouble(ByVal _str) As Double
        Dim str As String = _str
        Dim str_tmp As String
        Dim getTag As String = Mid(Str, 1, Str.indexof("]"))
        'str_tmp = Microsoft.VisualBasic.Right(str, Len(str) - str.indexof("]") - 2)
        If Right(getTag, 1) = "#" Then
            str_tmp = Right(Str, Len(Str) - Str.indexof("]") - 2)
            getValueDouble = Convert.ToDouble(str_tmp)
        ElseIf Right(getTag, 2) = "#." Then
            str_tmp = Right(Str, Len(Str) - Str.indexof("]") - 2)
            str_tmp = Left(str_tmp, str_tmp.IndexOf("."))
            getValueDouble = Convert.ToDouble(str_tmp)
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
