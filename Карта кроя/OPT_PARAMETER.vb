Imports Report.GlobalSub
Public Class OPT_PARAMETER
    Public MAX_SUBPL_WIDTH As Double
    Public MIN_BREAK_DIST As Double
    Public MIN_SUBPL_WIDTH As Double
    Public OPT_TARGET As Integer
    Public OPT_TIME As Integer
    Private arr() As String

    Sub New(ByVal _arr() As String)
        arr = _arr
        For i = 0 To UBound(arr, 1)
            If arr(i).StartsWith("[OPT_TIME#]=") Then
                OPT_TIME = getValueInt(arr(i))
            ElseIf arr(i).StartsWith("[OPT_%TARGET@]=") Then
                OPT_TARGET = getValueStr(arr(i))
            ElseIf arr(i).StartsWith("[MIN_SUBPL_WIDTH#.]=") Then
                MIN_SUBPL_WIDTH = getValueDouble(arr(i))
            ElseIf arr(i).StartsWith("[MAX_SUBPL_WIDTH#.]=") Then
                MAX_SUBPL_WIDTH = getValueDouble(arr(i))
            ElseIf arr(i).StartsWith("[MIN_BREAK_DIST#.]=") Then
                MIN_BREAK_DIST = getValueDouble(arr(i))
            End If
        Next
    End Sub
End Class
