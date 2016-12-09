﻿Imports System.Linq
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Drawing
Imports Report.GLASS_FOLDER
Imports Report.GlobalSub
Imports Report.Form1
Public Class GLASS_FOLDER
    Private path As String
    Private file As String
    Private nameGlass As String
    Shared optiodat As ReadOptioDat
    Public obj_header As HEADER
    Shared obj_GlassArray As GLASS_ARRAY
    Public obj_item_array As New List(Of ITEM)
    Public obj_opt_parameter As OPT_PARAMETER
    Public obj_opt_result_header As OPT_RESULT_HEADER
    Public obj_opt_result_stock_sheet_array As New List(Of OPT_RESULT_STOCK_SHEET)
    Public obj_x_area_array As New List(Of OPT_RESULT_X_AREA)
    Public obj_y_area_array As New List(Of OPT_RESULT_Y_AREA)

    Public Class HEADER
        Public OWNER As String
        Public RELEASE As Integer
        Private str As String
        Sub New(ByVal _str As String)
            str = _str
            RELEASE = GetInt32(optiodat.getValue(str, "RELEASE"))
            OWNER = optiodat.getValue(str, "OWNER")
        End Sub
    End Class
    Public Class GLASS_ARRAY
        Public ListGlass As New List(Of GLASS)
        Sub New()
            For Each itm In optiodat.glass_array
                ListGlass.Add(New GLASS(itm))
            Next
        End Sub
        Public Function GetGlass(ByVal ref As Integer) As GLASS
            Dim _glass As GLASS
            If ListGlass(ref).QTY > 0 Then
                _glass = ListGlass(ref).clone()
                _glass.QTY = 1
                ListGlass(ref).QTY = ListGlass(ref).QTY - 1
                Return _glass
            End If
            Return Nothing
        End Function
    End Class
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
            REC = GetInt32(optiodat.getValue(str, "REC"))
            CODE = optiodat.getValue(str, "CODE")
            DESCRIPTION = optiodat.getValue(str, "DESCRIPTION")
            RACK = optiodat.getValue(str, "RACK")
            WIDTH = GetDouble(optiodat.getValue(str, "WIDTH"))
            HEIGHT = GetDouble(optiodat.getValue(str, "HEIGHT"))
            QTY = GetInt32(optiodat.getValue(str, "QTY"))
            BOTTOM_TRIM = GetDouble(optiodat.getValue(str, "BOTTOM_TRIM"))
            TOP_TRIM = GetDouble(optiodat.getValue(str, "TOP_TRIM"))
            RIGHT_TRIM = GetDouble(optiodat.getValue(str, "RIGHT_TRIM"))
            LEFT_TRIM = GetDouble(optiodat.getValue(str, "LEFT_TRIM"))
            MIN_BREAK_DIST = GetDouble(optiodat.getValue(str, "MIN_BREAK_DIST"))
            ORIENTATION = GetInt32(optiodat.getValue(str, "ORIENTATION"))
        End Sub
        Public Function clone() As GLASS
            Return DirectCast(Me.MemberwiseClone(), GLASS)
        End Function
    End Class
    Public Class OPT_PARAMETER
        Public MAX_SUBPL_WIDTH As Double
        Public MIN_BREAK_DIST As Double
        Public MIN_SUBPL_WIDTH As Double
        Public OPT_TARGET As Integer
        Public OPT_TIME As Integer
        Private str As String
        Sub New(ByVal _str As String)
            str = _str
            OPT_TIME = GetInt32(optiodat.getValue(str, "OPT_TIME"))
            OPT_TARGET = GetInt32(optiodat.getValue(str, "OPT_TARGET"))
            MIN_SUBPL_WIDTH = GetDouble(optiodat.getValue(str, "MIN_SUBPL_WIDTH"))
            MAX_SUBPL_WIDTH = GetDouble(optiodat.getValue(str, "MAX_SUBPL_WIDTH"))
            MIN_BREAK_DIST = GetDouble(optiodat.getValue(str, "MIN_BREAK_DIST"))
        End Sub
    End Class
    Public Class OPT_RESULT_STOCK_SHEET
        'Protected OPT As OPT_RESULT_STOCK_SHEET
        Public graph As System.Drawing.Graphics
        Public STOCK_SHEET As Integer 'номер листа
        Public GLASS_FORMAT As GLASS
        Public GLASS_REF As Integer 'номер формата стекла на складе стекла
        Public REMNANT_WIDTH As Double 'Остаток на листе
        Public X_AREA_QTY As Integer 'Общее количество субпластин
        Public ROTATED_YN As Integer 'Признак поворота листа
        Public X_AREA_TYPE_QTY As Integer 'Общее количество субпластин
        Public X_AREA_REF As List(Of OPT_RESULT_X_AREA) 'Список субпластин

        Sub New(ByVal _str As String)
            Dim str As String = _str
            Dim lst As List(Of String)
            STOCK_SHEET = GetInt32(optiodat.getValue(str, "STOCK_SHEET"))
            GLASS_REF = GetInt32(optiodat.getValue(str, "GLASS_REF"))
            GLASS_FORMAT = obj_GlassArray.GetGlass(GLASS_REF)
            REMNANT_WIDTH = GetDouble(optiodat.getValue(str, "REMNANT_WIDTH"))
            X_AREA_QTY = GetInt32(optiodat.getValue(str, "X_AREA_QTY"))
            ROTATED_YN = GetInt32(optiodat.getValue(str, "ROTATED_YN"))
            X_AREA_TYPE_QTY = GetInt32(optiodat.getValue(str, "X_AREA_TYPE_QTY"))
            lst = optiodat.getValues(str, "*X_AREA_REF")
            For Each itm As String In lst
                Dim xAreaString As String
                xAreaString = optiodat.getXAreaRef(Convert.ToInt32(itm))
                X_AREA_REF.Add(New OPT_RESULT_X_AREA(xAreaString))
            Next
        End Sub

        Public Function GetFormat() As System.Drawing.Size
            Dim sizeSheet As System.Drawing.Size
            sizeSheet.Width = GLASS_FORMAT.WIDTH
            sizeSheet.Height = GLASS_FORMAT.HEIGHT
        End Function

        Public Sub Draw()
            Dim graph_tmp As System.Drawing.Graphics

        End Sub
    End Class
    Public Class OPT_RESULT_HEADER
        Public str As String
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

        Sub New(ByVal _str As String)
            str = _str
            'str = _str
            OPT_AREA_GROSS = GetInt32(optiodat.getValue(str, "OPT_AREA_GROSS"))
            OPT_AREA_NET = GetInt32(optiodat.getValue(str, "OPT_AREA_NET"))
            OPT_WASTE = GetDouble(optiodat.getValue(str, "OPT_WASTE"))
            REMNANT_HEIGHT = GetDouble(optiodat.getValue(str, "REMNANT_HEIGHT"))
            REMNANT_WIDTH = GetDouble(optiodat.getValue(str, "REMNANT_WIDTH"))
            STOCK_SHEET_QTY = GetInt32(optiodat.getValue(str, "STOCK_SHEET_QTY"))
            STOCK_SHEET_TYPE_QTY = GetInt32(optiodat.getValue(str, "STOCK_SHEET_TYPE_QTY"))
            USED_OPT_PARA = optiodat.getValue(str, "USED_OPT_PARA")
            USED_STRATEGY = GetInt32(optiodat.getValue(str, "USED_STRATEGY"))
            X_AREA_TYPE_QTY = GetInt32(optiodat.getValue(str, "X_AREA_TYPE_QTY"))
        End Sub
    End Class
    Public Class OPT_RESULT_X_AREA
        Public X_AREA As Integer
        Public WIDTH As Double
        Public HEIGHT As Double
        Public Y_AREA_QTY As Integer
        Public Y_AREA_TYPE_QTY As Integer
        Public Y_AREA_REF As New List(Of Integer)

        Sub New(ByVal _str As String)
            Dim str As String = _str
            Dim split As New SplitBySubstring()
            Dim lst As List(Of String)
            X_AREA = GetInt32(optiodat.getValue(str, "X_AREA"))
            WIDTH = GetDouble(optiodat.getValue(str, "WIDTH"))
            HEIGHT = GetDouble(optiodat.getValue(str, "HEIGHT"))
            Y_AREA_QTY = GetInt32(optiodat.getValue(str, "Y_AREA_QTY"))
            Y_AREA_TYPE_QTY = GetInt32(optiodat.getValue(str, "Y_AREA_TYPE_QTY"))
            lst = optiodat.getValues(str, "*Y_AREA_REF")
            For Each itm As String In lst
                Y_AREA_REF.Add(GetInt32(itm))
            Next
        End Sub
        Public Sub draw()
        End Sub
    End Class
    Public Class OPT_RESULT_Y_AREA
        Public Y_AREA As Integer
        Public WIDTH As Double
        Public HEIGHT As Double
        Public U_V_W_Z_AREA_TYPE As Integer
        Public U_V_W_Z_AREA_TYPE_QTY As Integer
        Public U_V_W_Z_ITEMS As List(Of OPT_RESULT_U_V_W_Z_AREA)

        Sub New(ByVal _str As String)
            Dim str As String = _str
            Dim split As New SplitBySubstring()
            Dim lst As List(Of String)
            lst = split.GetList(str, "[U_V_W_Z_AREA_ITEM_REF#]")
            Y_AREA = GetInt32(optiodat.getValue(str, "Y_AREA"))
            WIDTH = GetDouble(optiodat.getValue(str, "WIDTH"))
            HEIGHT = GetDouble(optiodat.getValue(str, "HEIGHT"))
            U_V_W_Z_AREA_TYPE_QTY = GetInt32(optiodat.getValue(str, "U_V_W_Z_AREA_TYPE_QTY"))
            For Each itm In lst
                U_V_W_Z_ITEMS.Add(New OPT_RESULT_U_V_W_Z_AREA(itm))
            Next
        End Sub
        'Public Function draw(ByVal graph As System.Drawing.Graphics, ByVal pt As System.Drawing.Point, _
        '                      ByVal ratio As Single) As System.Drawing.Graphics
        '    Dim col As New Colors
        '    Dim fill As New System.Drawing.SolidBrush(col.RectDetail.colorFill)
        '    Dim pen As New System.Drawing.Pen(col.RectDetail.colorPen, 3)
        '    Dim rect As System.Drawing.Rectangle
        '    'sz.Width = WIDTH
        '    'sz.Height = HEIGHT
        '    'rect = New System.Drawing.Rectangle(ResizePoint(pt, ratio), ResizeSize(sz, ratio))
        '    graph.FillRectangle(fill, rect)
        '    graph.DrawRectangle(pen, rect)

        '    'Наносим на деталь маркировку
        '    Dim centerRectangle As PointF
        '    'centerRectangle.X = ResizePoint(pt, ratio).X + (ResizeSize(sz, ratio).Width / 2)
        '    'centerRectangle.Y = ResizePoint(pt, ratio).Y + (ResizeSize(sz, ratio).Height / 2)
        '    ' Create font and brush.
        '    Dim drawFont As New System.Drawing.Font("Arial", 38)
        '    Dim drawBrush As New SolidBrush(System.Drawing.Color.Black)
        '    ' Create point for upper-left corner of drawing.
        '    Dim drawPoint As New PointF()
        '    drawPoint.Y = centerRectangle.Y
        '    drawPoint.X = ResizePoint(pt, ratio).X
        '    ' Set format of string.
        '    Dim drawFormat As New StringFormat
        '    ' graph.DrawString(RACK, drawFont, drawBrush, drawPoint, drawFormat)
        '    Return graph
        'End Function
    End Class
    Public Class OPT_RESULT_U_V_W_Z_AREA
        Public U_V_W_Z_AREA_HEIGHT As Double
        Public U_V_W_Z_AREA_ITEM_REF As Integer
        Public U_V_W_Z_AREA_QTY_X As Integer
        Public U_V_W_Z_AREA_QTY_Y As Integer
        Public U_V_W_Z_AREA_WIDTH As Double

        Sub New(ByVal _str As String)
            Dim str As String
            str = _str
            U_V_W_Z_AREA_HEIGHT = GetDouble(optiodat.getValue(str, "*U_V_W_Z_AREA_HEIGHT"))
            U_V_W_Z_AREA_WIDTH = GetDouble(optiodat.getValue(str, "*U_V_W_Z_AREA_WIDTH"))
            U_V_W_Z_AREA_ITEM_REF = GetInt32(optiodat.getValue(str, "*U_V_W_Z_AREA_ITEM_REF"))
        End Sub

    End Class
    Public Class ITEM
        Public REC As Integer
        Public BOX As Integer
        Public ORDER As String
        Public ITEM As Integer '[ITEM#]=1
        Public INFO As String
        Public OPT_GROUP As Integer '[OPT_GROUP#]=99
        Public CODE As String '[CODE@]=4 M1
        Public WIDTH As Double '[WIDTH#.]=1583.000
        Public HEIGHT As Double '[HEIGHT#.]=3180.000
        Public UNIT_QTY As Integer '[UNIT_QTY#]=1
        Public SHEET_QTY As Integer '[SHEET_QTY#]=1
        Public RACK As String '[*RACK@]=?
        Public SHAPE_FILE As String '[SHAPE_FILE@]=sf1.anz
        Private sz As System.Drawing.Size

        Sub New(ByVal _str As String)
            Dim str As String = _str
            'Dim lst As List(Of String)
            REC = GetInt32(optiodat.getValue(str, "REC"))
            BOX = GetInt32(optiodat.getValue(str, "BOX"))
            ORDER = optiodat.getValue(str, "ORDER")
            ITEM = GetInt32(optiodat.getValue(str, "ITEM"))
            OPT_GROUP = GetInt32(optiodat.getValue(str, "OPT_GROUP"))
            CODE = optiodat.getValue(str, "CODE")
            WIDTH = GetDouble(optiodat.getValue(str, "WIDTH"))
            HEIGHT = GetDouble(optiodat.getValue(str, "HEIGHT"))
            UNIT_QTY = GetInt32(optiodat.getValue(str, "UNIT_QTY"))
            SHEET_QTY = GetInt32(optiodat.getValue(str, "SHEET_QTY"))
            RACK = optiodat.getValue(str, "RACK")
            INFO = optiodat.getValue(str, "INFO")
            SHAPE_FILE = optiodat.getValue(str, "SHAPE_FILE")
        End Sub

        Public Function draw(ByVal graph As System.Drawing.Graphics, ByVal pt As System.Drawing.Point, _
                              ByVal ratio As Single) As System.Drawing.Graphics
            Dim col As New Colors
            Dim fill As New System.Drawing.SolidBrush(col.RectDetail.colorFill)
            Dim pen As New System.Drawing.Pen(col.RectDetail.colorPen, 3)
            Dim rect As System.Drawing.Rectangle
            sz.Width = WIDTH
            sz.Height = HEIGHT
            rect = New System.Drawing.Rectangle(ResizePoint(pt, ratio), ResizeSize(sz, ratio))
            graph.FillRectangle(fill, rect)
            graph.DrawRectangle(pen, rect)

            'Наносим на деталь маркировку
            Dim centerRectangle As PointF
            centerRectangle.X = ResizePoint(pt, ratio).X + (ResizeSize(sz, ratio).Width / 2)
            centerRectangle.Y = ResizePoint(pt, ratio).Y + (ResizeSize(sz, ratio).Height / 2)
            ' Create font and brush.
            Dim drawFont As New System.Drawing.Font("Arial", 38)
            Dim drawBrush As New SolidBrush(System.Drawing.Color.Black)
            ' Create point for upper-left corner of drawing.
            Dim drawPoint As New PointF()
            drawPoint.Y = centerRectangle.Y
            drawPoint.X = ResizePoint(pt, ratio).X
            ' Set format of string.
            Dim drawFormat As New StringFormat
            graph.DrawString(RACK, drawFont, drawBrush, drawPoint, drawFormat)
            Return graph
        End Function
    End Class

    Sub New(ByVal _file As String)
        file = _file
        optiodat = New ReadOptioDat(file)
        obj_header = New HEADER(optiodat.header)
        obj_opt_parameter = New OPT_PARAMETER(optiodat.opt_parameter)
        obj_opt_result_header = New OPT_RESULT_HEADER(optiodat.opt_result_header)
        'items
        For Each itm In optiodat.item_array
            obj_item_array.Add(New ITEM(itm))
        Next
        'Glass array
        obj_GlassArray = New GLASS_ARRAY()
        'For Each itm In optiodat.glass_array
        '    obj_GlassArray.Add(New GLASS(itm))
        'Next
        'Stock sheet array
        For Each itm In optiodat.stock_sheet_array
            obj_opt_result_stock_sheet_array.Add(New OPT_RESULT_STOCK_SHEET(itm))
        Next
        'X area array
        For Each itm In optiodat.x_area_array
            obj_x_area_array.Add(New OPT_RESULT_X_AREA(itm))
        Next

        'Y area array
        Dim _itm As String
        For Each itm In optiodat.y_area_list
            _itm = itm.y_area
            obj_y_area_array.Add(New OPT_RESULT_Y_AREA(_itm))
        Next
    End Sub
    Public Function GetGlassName() As String
        GetGlassName = My.Computer.FileSystem.GetName(path)
    End Function

    Public Function DrawStockSheet(ByVal numSheet As Integer) As System.Drawing.Graphics
        If numSheet > obj_opt_result_stock_sheet_array.Count Then
            Return Nothing
        Else
            Dim pict As System.Drawing.Bitmap
            Dim graph As System.Drawing.Graphics
            Dim sizeout As System.Drawing.Size
            sizeout = obj_opt_result_stock_sheet_array.Item(numSheet).GetFormat()
            pict = New Bitmap(Convert.ToInt32(sizeout.Width), Convert.ToInt32(sizeout.Height), System.Drawing.Imaging.PixelFormat.Format16bppRgb555)
            graph = System.Drawing.Graphics.FromImage(pict)
            graph.Clear(System.Drawing.Color.Gray)
            obj_opt_result_stock_sheet_array.Item(numSheet).Draw(graph)
        End If
        

    End Function

End Class

