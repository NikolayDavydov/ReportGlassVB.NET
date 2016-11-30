Public Class GLASS 'Форматы стекол
    Public REC As Integer 'Номер записи
    Public CODE As String 'Наименование стекла
    Public DESCRIPTION As String
    Public RACK As String 'Ячейка на складе
    Public WIDTH As Double 'Размер необлекаленного листа
    Public HEIGHT As Double 'Размер необлекаленного листа
    Public QTY As Integer 'Количество на складе
    Public BOTTOM_TRIM As Double 'Кромки облекаливания
    Public RIGHT_TRIM As Double 'Кромки облекаливания
    Public TOP_TRIM As Double 'Кромки облекаливания
    Public LEFT_TRIM As Double   'Кромки облекаливания
    Public MIN_BREAK_DIST As Double 'Дистанция разлома
    Public ORIENTATION As Integer

    Sub New(ByVal _str As String)
        Dim str As String = _str
        Dim split As New SplitBySubstring()
        Dim lst As List(Of String)
        lst = split.GetList(str, "[")
        For Each itm As String In lst
            Select Case split.getTag(itm)
                Case "REC"
                    REC = getValueInt(itm)
                Case "CODE"
                    CODE = getValueStr(itm)
                Case "DESCRIPTION"
                    DESCRIPTION = getValueStr(itm)
                Case "RACK"
                    RACK = getValueStr(itm)
                Case "WIDTH"
                    WIDTH = getValueDouble(itm)
                Case "HEIGHT"
                    HEIGHT = getValueDouble(itm)
                Case "QTY"
                    QTY = getValueInt(itm)
                Case "BOTTOM_TRIM"
                    BOTTOM_TRIM = getValueDouble(itm)
                Case "RIGHT_TRIM"
                    RIGHT_TRIM = getValueDouble(itm)
                Case "TOP_TRIM"
                    TOP_TRIM = getValueDouble(itm)
                Case "LEFT_TRIM"
                    LEFT_TRIM = getValueDouble(itm)
                Case "MIN_BREAK_DIST"
                    MIN_BREAK_DIST = getValueDouble(itm)
                Case "ORIENTATION"
                    ORIENTATION = getValueInt(itm)
            End Select
        Next
    End Sub




End Class
