Imports Report.GlobalSub
Public Class HEADER
    Public OWNER As String
    Public RELEASE As Integer
    Private str As String
    Sub New(ByVal _str As String)
        str = _str
        'For i = 0 To UBound(arr, 1)
        '    If arr(i).StartsWith("[RELEASE#]=") Then
        '        RELEASE = GlobalSub.getValueInt(arr(i))
        '    ElseIf arr(i).StartsWith("[OWNER@]=") Then
        '        OWNER = GlobalSub.getValueStr(arr(i))
        '    End If
        'Next
    End Sub
End Class
