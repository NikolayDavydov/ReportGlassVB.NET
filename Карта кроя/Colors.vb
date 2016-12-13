Public Class Colors
    Public Structure colorRectangle
        Public colorFill As System.Drawing.Color
        Public colorPen As System.Drawing.Color
        Public penThikness As Single
    End Structure
    Public RectPlate As colorRectangle 'Параметры прямоугольника листа
    Public RectPlateWithoutBorders As colorRectangle 'Параметры окромленного листа

    Public LineRed As colorRectangle 'Параметры границы субпластин
    Public RectSubPlate As colorRectangle 'Параметры субпластины

    Public LineBlack As colorRectangle 'Параметры границы группы деталей
    Public RectDetail As colorRectangle 'Параметры детали

    Sub New()
        RectPlate.colorFill = System.Drawing.Color.LightGray
        RectPlate.colorPen = System.Drawing.Color.Black
        RectPlate.penThikness = 4
        LineRed.colorPen = System.Drawing.Color.Red
        LineRed.penThikness = 4
        LineBlack.colorPen = System.Drawing.Color.Black
        LineBlack.penThikness = 4
        RectPlateWithoutBorders.colorFill = System.Drawing.Color.LightGray
        RectPlateWithoutBorders.colorPen = System.Drawing.Color.Black
        RectPlateWithoutBorders.penThikness = 4
        RectSubPlate.colorFill = System.Drawing.Color.LightGray
        RectSubPlate.colorPen = System.Drawing.Color.Black
        RectSubPlate.penThikness = 4
        RectDetail.colorFill = System.Drawing.Color.White
        RectDetail.colorPen = System.Drawing.Color.Black
        RectDetail.penThikness = 4
    End Sub
End Class
