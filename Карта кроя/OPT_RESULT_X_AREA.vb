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
                    Y_AREA_REF.Add(New OPT_RESULT_Y_AREA(itm)
            End Select
        Next
    End Sub
    Public Sub draw()
    End Sub


End Class
