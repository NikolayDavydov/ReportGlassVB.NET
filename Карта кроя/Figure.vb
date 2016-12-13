Imports Report.Colors
Public Class Figure
    Const outWidth As Integer = 2048    'формат целевого изображения(ширина)
    Const outHeight As Integer = 1280   'формат целевого изображения(высота)
    Public ratio As Single
    Public szPlate As System.Drawing.Size


    Public Function PlaceRectangle(ByVal graph As System.Drawing.Graphics,
                                    ByVal _pt As System.Drawing.Point,
                                    ByVal _sz_tmp As System.Drawing.Size,
                                    ByVal _colorRect As colorRectangle) As System.Drawing.Graphics
        Dim pt As System.Drawing.Point = _pt
        Dim sz_tmp As System.Drawing.Size = _sz_tmp
        Dim colorRect As colorRectangle = _colorRect

        Dim fill As New System.Drawing.SolidBrush(colorRect.colorFill)
        Dim pen As New System.Drawing.Pen(colorRect.colorPen, 3)
        Dim rect As System.Drawing.Rectangle
        pt = TrfCoordRectangle(pt, sz_tmp, szPlate)
        rect = New System.Drawing.Rectangle(ResizeByRatio(pt, ratio), ResizeByRatio(sz_tmp, ratio))
        graph.FillRectangle(fill, rect)
        graph.DrawRectangle(pen, rect)
        Return graph
    End Function
    Public Function TrfCoordRectangle(ByVal origPoint As System.Drawing.Point,
                                       ByVal origSize As System.Drawing.Size,
                                       ByVal szPlate As System.Drawing.Size) As System.Drawing.Point

        Dim newPoint As System.Drawing.Point
        newPoint.X = szPlate.Width - origPoint.X - origSize.Width
        newPoint.Y = szPlate.Height - origPoint.Y - origSize.Height
        Return newPoint
    End Function

    Public Function PlaceLine(ByVal graph As System.Drawing.Graphics,
                               ByVal pt1 As System.Drawing.Point,
                               ByVal pt2 As System.Drawing.Point,
                               ByVal colorLine As colorRectangle) As System.Drawing.Graphics
        'pt1 Координата начала линии в исходной системе координат
        'pt2 Координата конца линии в исходной системе координат
        Dim pen As New System.Drawing.Pen(colorLine.colorPen, colorLine.penThikness)
        pt1 = TrfCoordPoint(pt1, szPlate)
        pt2 = TrfCoordPoint(pt2, szPlate)
        graph.DrawLine(pen, ResizeByRatio(pt1, ratio), ResizeByRatio(pt2, ratio))
        Return graph
    End Function
    Public Function TrfCoordPoint(ByVal origPoint As System.Drawing.Point, ByVal szPlate As System.Drawing.Size) As System.Drawing.Point
        Dim newPoint As System.Drawing.Point
        newPoint.X = szPlate.Width - origPoint.X
        newPoint.Y = szPlate.Height - origPoint.Y
        Return newPoint
    End Function

    Public Function ResizeByRatio(ByVal value As System.Drawing.Point, ByVal ratio As Double) As System.Drawing.Point
        ResizeByRatio.X = CInt(CDbl(value.X) / ratio)
        ResizeByRatio.Y = CInt(CDbl(value.Y) / ratio)
    End Function
    Public Function ResizeByRatio(ByVal value As System.Drawing.Size, ByVal ratio As Double) As System.Drawing.Size
        ResizeByRatio.Width = CInt(CDbl(value.Width) / ratio)
        ResizeByRatio.Height = CInt(CDbl(value.Height) / ratio)
    End Function
    Public Function ResizeByRatio(ByVal x As Integer, ByVal ratio As Double) As Integer
        ResizeByRatio = CInt(CDbl(x) / ratio)
    End Function
    Public Function CalcRatio(ByVal sz As System.Drawing.Size) As Single
        'Calculate ratio

        Dim ratio As Single
        Dim ratioWidth As Single
        Dim ratioHeight As Single

        Dim sizeNew As System.Drawing.SizeF

        If sz.Width > 0 And sz.Height > 0 Then
            ratioWidth = outWidth / sz.Width
            ratioHeight = outHeight / sz.Height
            sizeNew.Width = sz.Width * ratioHeight
            sizeNew.Height = sz.Height * ratioWidth

            If sizeNew.Width <= outWidth Then
                ratio = ratioHeight
            ElseIf sizeNew.Height <= outHeight Then
                ratio = ratioWidth
            Else
                ratio = 1
            End If
        Else
            ratio = 1
        End If

        Return ratio
    End Function
End Class
