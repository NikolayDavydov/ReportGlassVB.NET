Public Class OPT_RESULT_Y_AREA
    Public Y_AREA As Int32
    Public WIDTH As Double
    Public HEIGHT As Double
    Public U_V_W_Z_AREA_TYPE As Integer
    Public U_V_W_Z_AREA_TYPE_QTY As Integer
    Public Z_AREA_TYPE_QTY As Int32
    Public Z_AREA_ITEM_REF As Int32
    Public Z_AREA_WIDTH As Int32
    Public Z_AREA_HEIGHT As Int32
    Public ITEMS As System.Collections.Generic.List(Of OPT_RESULT_U_V_W_Z_AREA)


    Sub New(ByVal _Y_AREA As Int32, ByVal _WIDTH As Int32, ByVal _HEIGHT As Int32, ByVal _Z_AREA_TYPE_QTY As Int32, _
            ByVal _Z_AREA_ITEM_REF As Int32, ByVal _Z_AREA_WIDTH As Int32, ByVal _Z_AREA_HEIGHT As Int32)
        Y_AREA = _Y_AREA
        WIDTH = _WIDTH
        HEIGHT = _HEIGHT
        Z_AREA_TYPE_QTY = _Z_AREA_TYPE_QTY
        Z_AREA_ITEM_REF = _Z_AREA_ITEM_REF
        Z_AREA_WIDTH = _Z_AREA_WIDTH
        Z_AREA_HEIGHT = _Z_AREA_HEIGHT




    End Sub

    Public Function draw(ByVal graph As System.Drawing.Graphics, ByVal pt As System.Drawing.Point, _
                          ByVal ratio As Single) As System.Drawing.Graphics
        Dim col As New Colors
        Dim fill As New System.Drawing.SolidBrush(col.RectDetail.colorFill)
        Dim pen As New System.Drawing.Pen(col.RectDetail.colorPen, 3)
        Dim rect As System.Drawing.Rectangle
        'sz.Width = WIDTH
        'sz.Height = HEIGHT
        'rect = New System.Drawing.Rectangle(ResizePoint(pt, ratio), ResizeSize(sz, ratio))
        graph.FillRectangle(fill, rect)
        graph.DrawRectangle(pen, rect)

        'Наносим на деталь маркировку
        Dim centerRectangle As PointF
        'centerRectangle.X = ResizePoint(pt, ratio).X + (ResizeSize(sz, ratio).Width / 2)
        'centerRectangle.Y = ResizePoint(pt, ratio).Y + (ResizeSize(sz, ratio).Height / 2)
        ' Create font and brush.
        Dim drawFont As New System.Drawing.Font("Arial", 38)
        Dim drawBrush As New SolidBrush(System.Drawing.Color.Black)
        ' Create point for upper-left corner of drawing.
        Dim drawPoint As New PointF()
        drawPoint.Y = centerRectangle.Y
        drawPoint.X = ResizePoint(pt, ratio).X
        ' Set format of string.
        Dim drawFormat As New StringFormat
        ' graph.DrawString(RACK, drawFont, drawBrush, drawPoint, drawFormat)
        Return graph
    End Function

End Class
