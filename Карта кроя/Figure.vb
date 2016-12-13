Imports Report.Colors
Public Class Figure


    Private Function PlaceRectangle(ByVal graph As System.Drawing.Graphics, ByVal pt As System.Drawing.Point, _
            ByVal sz_tmp As System.Drawing.Size, ByVal colorRect As colorRectangle) As System.Drawing.Graphics
        Dim fill As New System.Drawing.SolidBrush(colorRect.colorFill)
        Dim pen As New System.Drawing.Pen(colorRect.colorPen, 3)
        Dim rect As System.Drawing.Rectangle
        rect = New System.Drawing.Rectangle(pt, sz_tmp)
        graph.FillRectangle(fill, rect)
        graph.DrawRectangle(pen, rect)
        Return graph
    End Function

    Private Function PlaceLine(ByVal graph As System.Drawing.Graphics, ByVal pt1 As System.Drawing.Point, ByVal pt2 As System.Drawing.Point, _
                               ByVal colorLine As colorRectangle) As System.Drawing.Graphics
        Dim pen As New System.Drawing.Pen(colorLine.colorPen, colorLine.penThikness)
        graph.DrawLine(pen, pt1, pt2)
        Return graph
    End Function

    Private Function TrfCoordRectangle(ByVal origPoint As System.Drawing.Point, ByVal origSize As System.Drawing.Size, _
                                   ByVal szPlate As System.Drawing.Size) As System.Drawing.Point
        Dim newPoint As System.Drawing.Point
        newPoint.X = szPlate.Width - origPoint.X - origSize.Width
        newPoint.Y = szPlate.Height - origPoint.Y - origSize.Height
        Return newPoint
    End Function
    Private Function TrfCoordPoint(ByVal origPoint As System.Drawing.Point, ByVal szPlate As System.Drawing.Size) As System.Drawing.Point
        Dim newPoint As System.Drawing.Point
        newPoint.X = szPlate.Width - origPoint.X
        newPoint.Y = szPlate.Height - origPoint.Y
        Return newPoint
    End Function
    Private Function ResizeByRatio(ByVal x As Integer, ByVal ratio As Double) As Integer
        ResizeByRatio = CInt(CDbl(x) / ratio)
    End Function


End Class
