Public Class OPT_RESULT_STOCK_SHEET
    Public STOCK_SHEET As Integer 'номер листа
    Public GLASS_REF As Integer 'номер формата стекла на складе стекла
    Public REMNANT_WIDTH As Double 'Остаток на листе
    Public X_AREA_QTY As Integer 'Общее количество субпластин
    Public ROTATED_YN As Integer 'Признак поворота листа
    Public X_AREA_TYPE_QTY As Integer 'Общее количество субпластин
    Public X_AREA_REF As System.Collections.Generic.List(Of OPT_RESULT_X_AREA) 'Список субпластин

    Sub New(ByVal _str As String)
        Dim str As String = _str
        Dim split As New SplitBySubstring()
        Dim lst As List(Of String)
        Dim xAreaRef As Integer 'Номер X_AREA_REF
        lst = split.GetList(str, "[")
        For Each itm As String In lst
            Select Case split.getTag(itm)
                Case "STOCK_SHEET"
                    STOCK_SHEET = getValueInt(itm)
                Case "GLASS_REF"
                    GLASS_REF = getValueInt(itm)
                Case "REMNANT_WIDTH"
                    REMNANT_WIDTH = getValueDouble(itm)
                Case "X_AREA_QTY"
                    X_AREA_QTY = getValueInt(itm)
                Case "ROTATED_YN"
                    ROTATED_YN = getValueInt(itm)
                Case "X_AREA_TYPE_QTY"
                    X_AREA_TYPE_QTY = getValueInt(itm)
                Case "X_AREA_REF"
                    X_AREA_REF.Add(New OPT_RESULT_X_AREA(itm)
            End Select
        Next
    End Sub
End Class
