Public Class OPT_RESULT_STOCK_SHEET
    Public STOCK_SHEET As Integer 'номер листа
    Public GLASS_REF As Integer 'номер формата стекла на складе стекла
    Public REMNANT_WIDTH As Double 'Остаток на листе
    Public X_AREA_QTY As Integer 'Общее количество субпластин
    Public ROTATED_YN As Integer 'Признак поворота листа
    Public X_AREA_TYPE_QTY As Integer 'Общее количество субпластин
    Public X_AREA_REF As System.Collections.Generic.List(Of Integer) 'Список субпластин

    Sub New()

    End Sub

    'Sub New(ByVal _STOCK_SHEET As Int32, ByVal _GLASS_REF As Int32, ByVal _REMNANT_WIDTH As Int32, ByVal _X_AREA_QTY As Int32, _
    '    ByVal _ROTATED_YN As Boolean, ByVal _X_AREA_TYPE_QTY As Int32, ByVal _X_AREA_REF As List(Of Int32))
    '    STOCK_SHEET = _STOCK_SHEET
    '    GLASS_REF = _GLASS_REF
    '    REMNANT_WIDTH = _REMNANT_WIDTH
    '    X_AREA_QTY = _X_AREA_QTY
    '    ROTATED_YN = _ROTATED_YN
    '    X_AREA_TYPE_QTY = _X_AREA_TYPE_QTY
    '    X_AREA_REF = _X_AREA_REF
    'End Sub



End Class
