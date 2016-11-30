Imports System.Linq
Imports System.Collections.ObjectModel
'Imports Report.ReadOptioDat

Public Class GLASS_FOLDER
    Private path As String
    Private file As String
    Private nameGlass As String
    Private optiodat As ReadOptioDat
    Public header As HEADER
    Public opt_parameter As OPT_PARAMETER
    Public opt_result_header As OPT_RESULT_HEADER
    Public GlassArray As New List(Of GLASS)
    Public opt_result_stock_sheet_array As New List(Of OPT_RESULT_STOCK_SHEET)
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
    Sub New(ByVal _file As String)
        file = _file
        optiodat = New ReadOptioDat(file)
        header = New HEADER(optiodat.header)
        opt_parameter = New OPT_PARAMETER(optiodat.opt_parameter)
        opt_result_header = New OPT_RESULT_HEADER(optiodat.opt_result_header)
        For Each item In optiodat.glass_array
            GlassArray.Add(New GLASS(item))
        Next
        For Each item In optiodat.stock_sheet_array
            opt_result_stock_sheet_array.Add(New OPT_RESULT_STOCK_SHEET(item))
        Next

    End Sub
    Public Function getXAreaRef(ByVal id As Integer) As String
        getXAreaRef = optiodat.x_area_array(id)
    End Function
    Public Function getYAreaRef(ByVal id As Integer) As String
        getYAreaRef = optiodat.y_area_array(id)
    End Function
    Public Function getItem(ByVal id As Integer) As String
        getItem = optiodat.item_array(id)
    End Function
End Class

