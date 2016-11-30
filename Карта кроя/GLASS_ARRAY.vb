Public Class GLASS_ARRAY
    Private GLASS_LIST As List(Of GLASS)'Форматы стекол
    'Public REC As Integer 'Номер записи
    'Public CODE As String 'Наименование стекла
    'Public DESCRIPTION As String
    'Public RACK As String 'Ячейка на складе
    'Public WIDTH As Double 'Размер необлекаленного листа
    'Public HEIGHT As Double 'Размер необлекаленного листа
    'Public QTY As Integer 'Количество на складе
    'Public BOTTOM_TRIM As Double 'Кромки облекаливания
    'Public RIGHT_TRIM As Double 'Кромки облекаливания
    'Public TOP_TRIM As Double 'Кромки облекаливания
    'Public LEFT_TRIM As Double   'Кромки облекаливания
    'Public MIN_BREAK_DIST As Double 'Дистанция разлома
    'Public ORIENTATION As Integer

    Sub New(ByVal _lst As List(Of String))
        Dim lst As List(Of String) = _lst
        For Each l In lst
            GLASS_LIST.Add(New GLASS(l))
        Next
    End Sub

    'Sub New(ByVal _str As String)
    '    Dim str As String = _str
    '    Dim split As New SplitBySubstring()
    '    Dim lst As List(Of String)
    '    lst = split.GetList(str, "[")
    '    For Each itm As String In lst
    '        Select Case split.getTag(itm)
    '            Case "REC"
    '            Case "CODE"
    '            Case "DESCRIPTION"
    '            Case "RACK"
    '            Case "WIDTH"
    '            Case "HEIGHT"
    '            Case "QTY"
    '            Case "BOTTOM_TRIM"
    '            Case "RIGHT_TRIM"
    '            Case "TOP_TRIM"
    '            Case "LEFT_TRIM"
    '            Case "MIN_BREAK_DIST"
    '            Case "ORIENTATION"
    '        End Select
    '    Next
    'End Sub
    'Sub New(ByVal _REC As Int32, ByVal _CODE As String, ByVal _DESCRIPTION As String, ByRef _RACK As String, _
    '        ByVal _WIDTH As Int32, ByVal _HEIGHT As Int32, ByVal _QTY As Int32, ByVal _BOTTOM_TRIM As Int32, _
    '        ByVal _RIGHT_TRIM As Int32, ByVal _TOP_TRIM As Int32, ByVal _LEFT_TRIM As Int32, ByVal _MIN_BREAK_DIST As Int32)
    '    REC = _REC
    '    CODE = _CODE
    '    DESCRIPTION = _DESCRIPTION
    '    RACK = _RACK
    '    WIDTH = _WIDTH
    '    HEIGHT = _HEIGHT
    '    QTY = _QTY
    '    BOTTOM_TRIM = _BOTTOM_TRIM
    '    RIGHT_TRIM = _RIGHT_TRIM
    '    TOP_TRIM = _TOP_TRIM
    '    LEFT_TRIM = _LEFT_TRIM
    '    MIN_BREAK_DIST = _MIN_BREAK_DIST
    'End Sub

End Class
