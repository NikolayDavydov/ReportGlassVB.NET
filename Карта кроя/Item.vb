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


    Sub New(ByVal _rec As Int32, ByVal _box As Int32, ByVal _ORDER As String, _
        ByVal _ITEM As Int32, ByVal _OPT_GROUP As Int32, ByVal _CODE As String, _
        ByVal _WIDTH As Int32, ByVal _HEIGHT As Int32, ByVal _UNIT_QTY As Int32, _
        ByVal _SHEET_QTY As Int32, ByVal _RACK As String, ByVal _SHAPE_FILE As String)
        REC = _rec
        BOX = _box
        ORDER = _ORDER
        ITEM = _ITEM
        OPT_GROUP = _OPT_GROUP
        CODE = _CODE
        WIDTH = _WIDTH
        HEIGHT = _HEIGHT
        UNIT_QTY = _UNIT_QTY
        SHEET_QTY = _SHEET_QTY
        SHAPE_FILE = _SHAPE_FILE
        'Проверка на наличие шейпа
        If SHAPE_FILE <> "" Then

        End If
    End Sub

    Public Sub rotate()
        Dim tmp As Int32
        tmp = HEIGHT
        HEIGHT = WIDTH
        WIDTH = tmp
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
