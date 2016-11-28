
Public Class OPT_RESULT_HEADER
    Public arr() As String
    Public OPT_AREA_GROSS As Integer
    Public OPT_AREA_NET As Integer
    Public OPT_WASTE As Double
    Public REMNANT_HEIGHT As Double
    Public REMNANT_WIDTH As Double
    Public STOCK_SHEET_QTY As Integer
    Public STOCK_SHEET_TYPE_QTY As Integer
    Public USED_OPT_PARA As String
    Public USED_STRATEGY As Integer
    Public X_AREA_TYPE_QTY As Integer
    Sub New(ByVal _arr() As String)
        arr = _arr
        For i = 0 To UBound(arr, 1)
            If arr(i).StartsWith("[USED_STRATEGY#]=") Then
                USED_STRATEGY = getValueInt(arr(i))
            ElseIf arr(i).StartsWith("[USED_OPT_PARA@]=") Then
                USED_OPT_PARA = getValueStr(arr(i))
            ElseIf arr(i).StartsWith("[OPT_AREA_NET#]=") Then
                OPT_AREA_NET = getValueInt(arr(i))
            ElseIf arr(i).StartsWith("[OPT_AREA_GROSS#]=") Then
                OPT_AREA_GROSS = getValueInt(arr(i))
            ElseIf arr(i).StartsWith("[OPT_WASTE#]=") Then
                OPT_WASTE = getValueDouble(arr(i))
            ElseIf arr(i).StartsWith("[REMNANT_WIDTH#.]=") Then
                REMNANT_WIDTH = getValueDouble(arr(i))
            ElseIf arr(i).StartsWith("[REMNANT_HEIGHT#.]=") Then
                REMNANT_HEIGHT = getValueDouble(arr(i))
            ElseIf arr(i).StartsWith("[STOCK_SHEET_QTY#]=") Then
                STOCK_SHEET_QTY = getValueInt(arr(i))
            ElseIf arr(i).StartsWith("[STOCK_SHEET_TYPE_QTY#]=") Then
                STOCK_SHEET_TYPE_QTY = getValueInt(arr(i))
            ElseIf arr(i).StartsWith("[X_AREA_TYPE_QTY#]=") Then
                X_AREA_TYPE_QTY = getValueInt(arr(i))
            End If
        Next
    End Sub
End Class
