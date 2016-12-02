Imports System.Linq
Imports System.Collections.ObjectModel
Imports System.IO
Imports Report
Imports Report.GLASS_FOLDER
Imports Report.GlobalSub
Imports Report.Form1
Public Class GLASS_FOLDER
    Public Structure optioDat_structure
        Public header As String
        Public opt_parameter As String
        Public opt_result_header As String
        Public item_array As List(Of String)
        Public glass_array As List(Of String)
        Public stock_sheet_array As List(Of String)
        Public x_area_array As List(Of String)
        Public y_area_array As List(Of String)
    End Structure
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
    Public Class GLASS_ARRAY
        Private GLASS_LIST As List(Of GLASS) 'Форматы стекол
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
    Public Class OPT_PARAMETER
        Public MAX_SUBPL_WIDTH As Double
        Public MIN_BREAK_DIST As Double
        Public MIN_SUBPL_WIDTH As Double
        Public OPT_TARGET As Integer
        Public OPT_TIME As Integer
        Private str As String

        Sub New(ByVal _str As String)
            str = _str
            'For i = 0 To UBound(arr, 1)
            '    If arr(i).StartsWith("[OPT_TIME#]=") Then
            '        OPT_TIME = getValueInt(arr(i))
            '    ElseIf arr(i).StartsWith("[OPT_%TARGET@]=") Then
            '        OPT_TARGET = getValueStr(arr(i))
            '    ElseIf arr(i).StartsWith("[MIN_SUBPL_WIDTH#.]=") Then
            '        MIN_SUBPL_WIDTH = getValueDouble(arr(i))
            '    ElseIf arr(i).StartsWith("[MAX_SUBPL_WIDTH#.]=") Then
            '        MAX_SUBPL_WIDTH = getValueDouble(arr(i))
            '    ElseIf arr(i).StartsWith("[MIN_BREAK_DIST#.]=") Then
            '        MIN_BREAK_DIST = getValueDouble(arr(i))
            '    End If
            'Next
        End Sub
    End Class
    Public Class OPT_RESULT_STOCK_SHEET
        Protected OPT As OPT_RESULT_STOCK_SHEET
        Public STOCK_SHEET As Integer 'номер листа
        Public GLASS_REF As Integer 'номер формата стекла на складе стекла
        Public REMNANT_WIDTH As Double 'Остаток на листе
        Public X_AREA_QTY As Integer 'Общее количество субпластин
        Public ROTATED_YN As Integer 'Признак поворота листа
        Public X_AREA_TYPE_QTY As Integer 'Общее количество субпластин
        Public X_AREA_REF As List(Of OPT_RESULT_X_AREA) 'Список субпластин

        Sub New(ByVal _str As String)
            Dim str As String = _str
            Dim split As New SplitBySubstring()
            Dim lst As List(Of String)
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
                        Dim xAreaRef As Integer 'Номер X_AREA_REF
                        xAreaRef = getValueInt(itm)
                        Dim xAreaString As String
                        xAreaString = optiodat.getXAreaRef(xAreaRef)
                        X_AREA_REF.Add(New OPT_RESULT_X_AREA(xAreaString))
                End Select
            Next
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
                'For i = 0 To UBound(arr, 1)
                '    If arr(i).StartsWith("[USED_STRATEGY#]=") Then
                '        USED_STRATEGY = getValueInt(arr(i))
                '    ElseIf arr(i).StartsWith("[USED_OPT_PARA@]=") Then
                '        USED_OPT_PARA = getValueStr(arr(i))
                '    ElseIf arr(i).StartsWith("[OPT_AREA_NET#]=") Then
                '        OPT_AREA_NET = getValueInt(arr(i))
                '    ElseIf arr(i).StartsWith("[OPT_AREA_GROSS#]=") Then
                '        OPT_AREA_GROSS = getValueInt(arr(i))
                '    ElseIf arr(i).StartsWith("[OPT_WASTE#]=") Then
                '        OPT_WASTE = getValueDouble(arr(i))
                '    ElseIf arr(i).StartsWith("[REMNANT_WIDTH#.]=") Then
                '        REMNANT_WIDTH = getValueDouble(arr(i))
                '    ElseIf arr(i).StartsWith("[REMNANT_HEIGHT#.]=") Then
                '        REMNANT_HEIGHT = getValueDouble(arr(i))
                '    ElseIf arr(i).StartsWith("[STOCK_SHEET_QTY#]=") Then
                '        STOCK_SHEET_QTY = getValueInt(arr(i))
                '    ElseIf arr(i).StartsWith("[STOCK_SHEET_TYPE_QTY#]=") Then
                '        STOCK_SHEET_TYPE_QTY = getValueInt(arr(i))
                '    ElseIf arr(i).StartsWith("[X_AREA_TYPE_QTY#]=") Then
                '        X_AREA_TYPE_QTY = getValueInt(arr(i))
                '    End If
                'Next
            End Sub
        End Class
        Public Class OPT_RESULT_X_AREA
            Public X_AREA As Integer
            Public WIDTH As Double
            Public HEIGHT As Double
            Public Y_AREA_QTY As Integer
            Public Y_AREA_TYPE_QTY As Integer
            Public Y_AREA_REF As System.Collections.Generic.List(Of OPT_RESULT_Y_AREA)
            'Public Y_AREA_CLASS As List(Of OPT_RESULT_Y_AREA)


            Sub New(ByVal _str As String)
                Dim str As String = _str
                Dim split As New SplitBySubstring()
                Dim lst As List(Of String)
                lst = split.GetList(str, "[")
                For Each itm As String In lst
                    Select Case split.getTag(itm)
                        Case "X_AREA"
                            X_AREA = getValueInt(itm)
                        Case "WIDTH"
                            WIDTH = getValueDouble(itm)
                        Case "HEIGHT"
                            HEIGHT = getValueDouble(itm)
                        Case "Y_AREA_QTY"
                            Y_AREA_QTY = getValueInt(itm)
                        Case "Y_AREA_TYPE_QTY"
                            Y_AREA_TYPE_QTY = getValueInt(itm)
                    Case "Y_AREA_REF"
                        Dim yAreaRef As Integer 'Номер Y_AREA_REF
                        yAreaRef = getValueInt(itm)
                        Dim yAreaString As String
                        yAreaString = optiodat.getYAreaRef(yAreaRef)
                        Y_AREA_REF.Add(New OPT_RESULT_Y_AREA(yAreaString))
                        'Y_AREA_REF.Add(New OPT_RESULT_Y_AREA(itm)
                End Select
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
        Public Z_AREA_TYPE_QTY As Integer
        Public Z_AREA_ITEM_REF As Integer
        Public Z_AREA_WIDTH As Integer
        Public Z_AREA_HEIGHT As Integer
        'Public ITEMS As System.Collections.Generic.List(Of OPT_RESULT_U_V_W_Z_AREA)

        Sub New(ByVal _str As String)
            Dim str As String = _str
            Dim split As New SplitBySubstring()
            Dim lst As List(Of String)
            Dim lst2 As List(Of String)
            lst = split.GetList(str, "[")
            lst2 = split.GetList(str, "[U_V_W_Z_AREA_ITEM_REF#]")
            For Each itm As String In lst
                Select Case split.getTag(itm)
                    Case "Y_AREA"
                        Y_AREA = getValueInt(itm)
                    Case "WIDTH"
                        WIDTH = getValueDouble(itm)
                    Case "HEIGHT"
                        HEIGHT = getValueDouble(itm)
                    Case "U_V_W_Z_AREA_TYPE"
                        U_V_W_Z_AREA_TYPE = getValueInt(itm)
                    Case "U_V_W_Z_AREA_TYPE_QTY"
                        U_V_W_Z_AREA_TYPE_QTY = getValueInt(itm)
                    Case "U_V_W_Z_AREA_TYPE_ITEM_REF"
                        Dim u_v_w_z_item_id As Integer 'Номер Y_AREA_REF
                        u_v_w_z_item_id = getValueInt(itm)
                        'Dim yAreaString As String
                        'yAreaString = optiodat.getYAreaRef(yAreaRef)
                        '   Y_AREA_REF.Add(New OPT_RESULT_Y_AREA(yAreaString))
                        ' Y_AREA_REF.Add(New OPT_RESULT_Y_AREA(itm)
                End Select
                For Each itm2 As String In lst2
                    
                Next
            Next
        End Sub



        'Sub New(ByVal _Y_AREA As Int32, ByVal _WIDTH As Int32, ByVal _HEIGHT As Int32, ByVal _Z_AREA_TYPE_QTY As Int32, _
        '        ByVal _Z_AREA_ITEM_REF As Int32, ByVal _Z_AREA_WIDTH As Int32, ByVal _Z_AREA_HEIGHT As Int32)
        '    Y_AREA = _Y_AREA
        '    WIDTH = _WIDTH
        '    HEIGHT = _HEIGHT
        '    Z_AREA_TYPE_QTY = _Z_AREA_TYPE_QTY
        '    Z_AREA_ITEM_REF = _Z_AREA_ITEM_REF
        '    Z_AREA_WIDTH = _Z_AREA_WIDTH
        '    Z_AREA_HEIGHT = _Z_AREA_HEIGHT




        'End Sub

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

    End Class
    Public optio As optioDat_structure
        Private path As String
        Private file As String
        Private nameGlass As String
    Shared optiodat As ReadOptioDat
        Public obj_header As HEADER
        Public obj_opt_parameter As OPT_PARAMETER
        Public obj_opt_result_header As OPT_RESULT_HEADER
        Public obj_GlassArray As New List(Of GLASS)
        Public obj_opt_result_stock_sheet_array As New List(Of OPT_RESULT_STOCK_SHEET)

        Sub New(ByVal _file As String)
        file = _file
        optiodat = New ReadOptioDat(file)
        'With optio
        '    .header = optiodat.header
        '    .glass_array = optio.glass_array
        '    .item_array = optiodat.item_array
        '    .opt_parameter = optiodat.opt_parameter
        '    .opt_result_header = optiodat.opt_result_header
        '    .stock_sheet_array = optiodat.stock_sheet_array
        '    .x_area_array = optiodat.x_area_array
        '    .y_area_array = optiodat.y_area_array
        'End With
            obj_header = New HEADER(optiodat.header)
            obj_opt_parameter = New OPT_PARAMETER(optiodat.opt_parameter)
            obj_opt_result_header = New OPT_RESULT_HEADER(optiodat.opt_result_header)
            For Each item In optiodat.glass_array
                obj_GlassArray.Add(New GLASS(item))
            Next
            For Each item In optiodat.stock_sheet_array
                obj_opt_result_stock_sheet_array.Add(New OPT_RESULT_STOCK_SHEET(item))
            Next
        End Sub

    End Class

