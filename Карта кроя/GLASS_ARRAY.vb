Public Class GLASS_ARRAY 'Форматы стекол
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


    Sub New(ByVal _REC As Int32, ByVal _CODE As String, ByVal _DESCRIPTION As String, ByRef _RACK As String, _
            ByVal _WIDTH As Int32, ByVal _HEIGHT As Int32, ByVal _QTY As Int32, ByVal _BOTTOM_TRIM As Int32, _
            ByVal _RIGHT_TRIM As Int32, ByVal _TOP_TRIM As Int32, ByVal _LEFT_TRIM As Int32, ByVal _MIN_BREAK_DIST As Int32)
        REC = _REC
        CODE = _CODE
        DESCRIPTION = _DESCRIPTION
        RACK = _RACK
        WIDTH = _WIDTH
        HEIGHT = _HEIGHT
        QTY = _QTY
        BOTTOM_TRIM = _BOTTOM_TRIM
        RIGHT_TRIM = _RIGHT_TRIM
        TOP_TRIM = _TOP_TRIM
        LEFT_TRIM = _LEFT_TRIM
        MIN_BREAK_DIST = _MIN_BREAK_DIST
    End Sub
End Class
