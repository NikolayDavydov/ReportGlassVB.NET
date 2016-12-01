'Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports Report.ITAP.Components

Namespace ITAP.SquareOPT.Strategy.GpsOpt
    Public Class ResultOpt
        ' Methods
        Friend Function GetITEM(ByVal ID As Integer) As ITEM
            Dim item As ITEM
            For Each item In Me.ItemList
                If (item.REC = ID) Then
                    Return item
                End If
            Next
            Return Nothing
        End Function

        Friend Function GetOPT_RESULT_X_AREA(ByVal ID As Integer) As OPT_RESULT_X_AREA
            Dim opt_result_x_area As OPT_RESULT_X_AREA
            For Each opt_result_x_area In Me.OptResultXAreaList
                If (opt_result_x_area.X_AREA = ID) Then
                    Return opt_result_x_area
                End If
            Next
            Return Nothing
        End Function

        Friend Function GetOPT_RESULT_Y_AREA(ByVal ID As Integer) As OPT_RESULT_Y_AREA
            Dim opt_result_y_area As OPT_RESULT_Y_AREA
            For Each opt_result_y_area In Me.OptResultYAreaList
                If (opt_result_y_area.Y_AREA = ID) Then
                    Return opt_result_y_area
                End If
            Next
            Return Nothing
        End Function

        Private Function getValue(ByVal source As String, ByVal field As String) As String
            Dim strArray As String() = source.Split(New Char() {"["c})
            Dim str2 As String
            For Each str2 In strArray
                If str2.StartsWith(field) Then
                    Dim index As Integer = str2.IndexOf("="c)
                    Dim str3 As String = str2.Substring((index + 1), (str2.Length - (index + 1)))
                    If str2.Contains("#") Then
                        str3 = str3.Replace(".", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator).Replace(",", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                    End If
                    Return str3
                End If
            Next
            Return String.Empty
        End Function

        Private Function getValue1(ByVal source As String, ByVal field As String) As String
            If Not source.Contains(field) Then
                Return String.Empty
            End If
            Dim num As Integer = (source.IndexOf(field) + field.Length)
            Dim str As String = String.Empty
            Dim i As Integer
            For i = num To source.Length - 1
                If (source.Chars(i) = "["c) Then
                    Return str
                End If
                str = (str & source.Chars(i))
            Next i
            Return str
        End Function

        Private Function getValues(ByVal source As String, ByVal field As String) As String()
            Dim list As New List(Of String)
            Dim strArray As String() = source.Split(New Char() {"["c})
            Dim str As String
            For Each str In strArray
                If str.StartsWith(field) Then
                    Dim index As Integer = str.IndexOf("="c)
                    Dim item As String = str.Substring((index + 1), (str.Length - (index + 1))).Replace(".", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator).Replace(",", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                    list.Add(item)
                End If
            Next
            Return list.ToArray
        End Function

        Public Sub Load(ByVal data As Byte())
            Dim stream As New MemoryStream(data)
            Me.Load(stream)
            stream.Close()
        End Sub

        Public Sub Load(ByVal stream As Stream)
            Dim tr As TextReader = New StreamReader(stream)
            Dim undefined As Section = Section.Undefined
            Dim str As String = String.Empty
            Do While (Not str = tr.ReadLine Is Nothing)
                Dim str2 As String
                Dim str4 As String
                Dim num As Integer
                Dim num2 As Integer
                If (str = "[---HEADER---]") Then
                    undefined = Section.HEADER
                ElseIf (str = "[---ITEM_ARRAY---]") Then
                    undefined = Section.ITEM
                ElseIf (str = "[---GLASS_ARRAY---]") Then
                    undefined = Section.GLASS
                ElseIf (str = "[---OPT_PARAMETER---]") Then
                    undefined = Section.OPT_PARAMETER
                ElseIf (str = "[---OPT_RESULT_HEADER---]") Then
                    undefined = Section.OPT_RESULT_HEADER
                ElseIf (str = "[---OPT_RESULT_STOCK_SHEET_ARRAY---]") Then
                    undefined = Section.OPT_RESULT_STOCK_SHEET
                ElseIf (str = "[---OPT_RESULT_X_AREA_ARRAY---]") Then
                    undefined = Section.OPT_RESULT_X_AREA
                ElseIf (str = "[---OPT_RESULT_Y_AREA_ARRAY---]") Then
                    undefined = Section.OPT_RESULT_Y_AREA
                End If
                Select Case undefined
                    Case Section.ITEM
                        str2 = (str & Me.read(tr))
                        Dim item As New ITEM With { _
                            .REC = Components.Useful.GetInt32(Me.getValue(str2, "REC")), _
                            .BOX = Useful.GetInt32(Me.getValue(str2, "BOX")), _
                            .ORDER = Me.getValue(str2, "ORDER"), _
                            .ITEM_ = Useful.GetInt32(Me.getValue(str2, "ITEM")), _
                            .OPT_GROUP = Useful.GetInt32(Me.getValue(str2, "OPT_GROUP")), _
                            .CODE = Me.getValue(str2, "CODE"), _
                            .WIDTH = Useful.GetDouble(Me.getValue(str2, "WIDTH")), _
                            .HEIGHT = Useful.GetDouble(Me.getValue(str2, "HEIGHT")), _
                            .UNIT_QTY = Useful.GetInt32(Me.getValue(str2, "UNIT_QTY")), _
                            .SHEET_QTY = Useful.GetInt32(Me.getValue(str2, "SHEET_QTY")), _
                            .RACK = Me.getValue(str2, "*RACK"), _
                            .INFO = Me.getValue(str2, "INFO"), _
                            .SHAPE_FILE = Me.getValue(str2, "SHAPE_FILE") _
                        }
                        Me.ItemList.Add(item)
                        Continue Do
                    Case Section.GLASS
                        str2 = (str & Me.read(tr))
                        Dim glass As New GLASS With { _
                            .REC = Useful.GetInt32(Me.getValue(str2, "REC")), _
                            .CODE = Convert.ToString(Me.getValue(str2, "CODE")), _
                            .DESCRIPTION = Convert.ToString(Me.getValue(str2, "DESCRIPTION")), _
                            .RACK = Convert.ToString(Me.getValue(str2, "RACK")), _
                            .WIDTH = Useful.GetDouble(Me.getValue(str2, "WIDTH")), _
                            .HEIGHT = Useful.GetDouble(Me.getValue(str2, "HEIGHT")), _
                            .QTY = Useful.GetInt32(Me.getValue(str2, "QTY")), _
                            .BOTTOM_TRIM = Useful.GetDouble(Me.getValue(str2, "BOTTOM_TRIM")), _
                            .RIGHT_TRIM = Useful.GetDouble(Me.getValue(str2, "RIGHT_TRIM")), _
                            .TOP_TRIM = Useful.GetDouble(Me.getValue(str2, "TOP_TRIM")), _
                            .LEFT_TRIM = Useful.GetDouble(Me.getValue(str2, "LEFT_TRIM")), _
                            .MIN_BREAK_DIST = Useful.GetDouble(Me.getValue(str2, "MIN_BREAK_DIST")) _
                        }
                        If (Me.getValue(str2, "ORIENTATION") <> String.Empty) Then
                            glass.ORIENTATION = Useful.GetInt32(Me.getValue(str2, "ORIENTATION"))
                        End If
                        Me.GlassList.Add(glass)
                        Continue Do
                    Case Section.OPT_PARAMETER
                        str2 = (str & Me.read(tr))
                        Me.OptParametr.OPT_TIME = Useful.GetInt32(Me.getValue(str2, "OPT_TIME"))
                        Me.OptParametr.OPT_TARGET = Useful.GetInt32(Me.getValue(str2, "OPT_%TARGET"))
                        Me.OptParametr.MIN_SUBPL_WIDTH = Useful.GetDouble(Me.getValue(str2, "MIN_SUBPL_WIDTH"))
                        Me.OptParametr.MAX_SUBPL_WIDTH = Useful.GetDouble(Me.getValue(str2, "MAX_SUBPL_WIDTH"))
                        Me.OptParametr.MIN_BREAK_DIST = Useful.GetDouble(Me.getValue(str2, "MIN_BREAK_DIST"))
                        Continue Do
                    Case Section.OPT_RESULT_HEADER
                        str2 = (str & Me.read(tr))
                        Me.OptResultHeader.USED_STRATEGY = Useful.GetInt32(Me.getValue(str2, "USED_STRATEGY"))
                        Me.OptResultHeader.USED_OPT_PARA = Convert.ToString(Me.getValue(str2, "USED_OPT_PARA"))
                        Me.OptResultHeader.OPT_AREA_NET = Useful.GetInt32(Me.getValue(str2, "OPT_AREA_NET"))
                        Me.OptResultHeader.OPT_AREA_GROSS = Useful.GetInt32(Me.getValue(str2, "OPT_AREA_GROSS"))
                        Me.OptResultHeader.OPT_WASTE = Useful.GetDouble(Me.getValue(str2, "OPT_WASTE%"))
                        Me.OptResultHeader.REMNANT_WIDTH = Useful.GetDouble(Me.getValue(str2, "REMNANT_WIDTH"))
                        Me.OptResultHeader.REMNANT_HEIGHT = Useful.GetDouble(Me.getValue(str2, "REMNANT_HEIGHT"))
                        Me.OptResultHeader.STOCK_SHEET_QTY = Useful.GetInt32(Me.getValue(str2, "STOCK_SHEET_QTY"))
                        Me.OptResultHeader.STOCK_SHEET_TYPE_QTY = Useful.GetInt32(Me.getValue(str2, "STOCK_SHEET_TYPE_QTY"))
                        Me.OptResultHeader.X_AREA_TYPE_QTY = Useful.GetInt32(Me.getValue(str2, "X_AREA_TYPE_QTY"))
                        Continue Do
                    Case Section.HEADER
                        str2 = Me.read(tr)
                        Me.Header.OWNER = Me.getValue(str2, "OWNER")
                        Me.Header.RELEASE = Me.getValue(str2, "RELEASE")
                        Continue Do
                    Case Section.OPT_RESULT_STOCK_SHEET
                        str2 = (str & Me.read(tr))
                        Dim opt_result_stock_sheet As New OPT_RESULT_STOCK_SHEET With { _
                            .STOCK_SHEET = Useful.GetInt32(Me.getValue(str2, "STOCK_SHEET")), _
                            .GLASS_REF = Useful.GetInt32(Me.getValue(str2, "GLASS_REF")), _
                            .REMNANT_WIDTH = Useful.GetDouble(Me.getValue(str2, "REMNANT_WIDTH")), _
                            .X_AREA_QTY = Useful.GetInt32(Me.getValue(str2, "X_AREA_QTY")), _
                            .X_AREA_TYPE_QTY = Useful.GetInt32(Me.getValue(str2, "X_AREA_TYPE_QTY")) _
                        }
                        If (Me.getValue(str2, "ROTATED_YN") <> String.Empty) Then
                            opt_result_stock_sheet.ROTATED_YN = Useful.GetInt32(Me.getValue(str2, "ROTATED_YN"))
                        Else
                            opt_result_stock_sheet.ROTATED_YN = 0
                        End If
                        Dim str3 As String
                        For Each str3 In Me.getValues(str2, "*X_AREA_REF#")
                            str4 = Me.getValue1(str2, $"[*X_AREA_REF#]={str3}[*X_AREA_REF_QTY#]=")
                            If Not String.IsNullOrEmpty(str4) Then
                                num = 0
                                Do While (num < Convert.ToInt32(str4))
                                    opt_result_stock_sheet.X_AREA_REF.Add(Convert.ToInt32(str3))
                                    num += 1
                                Loop
                            Else
                                opt_result_stock_sheet.X_AREA_REF.Add(Convert.ToInt32(str3))
                            End If
                        Next
                        Dim str5 As String = Me.getValue(str2, "QTY#")
                        If Not String.IsNullOrEmpty(str5) Then
                            num2 = 0
                            Do While (num2 < Useful.GetInt32(str5))
                                Me.OptResultStoockSheetList.Add(opt_result_stock_sheet)
                                num2 += 1
                            Loop
                        Else
                            Me.OptResultStoockSheetList.Add(opt_result_stock_sheet)
                        End If
                        Continue Do
                    Case Section.OPT_RESULT_X_AREA
                        str2 = (str & Me.read(tr))
                        Dim opt_result_x_area As New OPT_RESULT_X_AREA With { _
                            .X_AREA = Useful.GetInt32(Me.getValue(str2, "X_AREA")), _
                            .WIDTH = Useful.GetDouble(Me.getValue(str2, "WIDTH")), _
                            .HEIGHT = Useful.GetDouble(Me.getValue(str2, "HEIGHT")), _
                            .Y_AREA_QTY = Useful.GetInt32(Me.getValue(str2, "Y_AREA_QTY")), _
                            .Y_AREA_TYPE_QTY = Useful.GetInt32(Me.getValue(str2, "Y_AREA_TYPE_QTY")) _
                        }
                        Dim str3 As String
                        For Each str3 In Me.getValues(str2, "*Y_AREA_REF#")
                            str4 = Me.getValue1(str2, $"[*Y_AREA_REF#]={str3}[*Y_AREA_REF_QTY#]=")
                            If Not String.IsNullOrEmpty(str4) Then
                                num()
                                For num = 0 To Convert.ToInt32(str4) - 1
                                    opt_result_x_area.Y_AREA_REF.Add(Convert.ToInt32(str3))
                                Next num
                            Else
                                opt_result_x_area.Y_AREA_REF.Add(Convert.ToInt32(str3))
                            End If
                        Next
                        Me.OptResultXAreaList.Add(opt_result_x_area)
                        Exit Select
                    Case Section.OPT_RESULT_Y_AREA
                        str2 = (str & Me.read(tr))
                        Dim opt_result_y_area As New OPT_RESULT_Y_AREA With { _
                            .Y_AREA = Useful.GetInt32(Me.getValue(str2, "Y_AREA")), _
                            .WIDTH = Useful.GetDouble(Me.getValue(str2, "WIDTH")), _
                            .HEIGHT = Useful.GetDouble(Me.getValue(str2, "HEIGHT")), _
                            .U_V_W_Z_AREA_TYPE_QTY = Useful.GetInt32(Me.getValue(str2, "U/V/W/Z_AREA_TYPE_QTY")) _
                        }
                        Dim strArray As String() = Me.getValues(str2, "*U/V/W/Z_AREA_ITEM_REF")
                        Dim strArray2 As String() = Me.getValues(str2, "*U/V/W/Z_AREA_WIDTH")
                        Dim strArray3 As String() = Me.getValues(str2, "*U/V/W/Z_AREA_HEIGHT")
                        Dim strArray4 As String() = str2.Split(New String() {"[*U/V/W/Z_AREA_ITEM_REF#]"}, StringSplitOptions.None)
                        num2()
                        For num2 = 0 To opt_result_y_area.U_V_W_Z_AREA_TYPE_QTY - 1
                            Dim source As String = strArray4((num2 + 1))
                            Dim opt_result_u_v_w_z_area As New OPT_RESULT_U_V_W_Z_AREA With { _
                                .U_V_W_Z_AREA_ITEM_REF = Useful.GetInt32(strArray(num2)), _
                                .U_V_W_Z_AREA_HEIGHT = Useful.GetDouble(strArray3(num2)), _
                                .U_V_W_Z_AREA_WIDTH = Useful.GetDouble(strArray2(num2)) _
                            }
                            opt_result_y_area.ITEMS.Add(opt_result_u_v_w_z_area)
                            Dim str7 As String = Me.getValue1(source, "[*U/V/W/Z_AREA_QTY_X#]=")
                            If Not String.IsNullOrEmpty(str7) Then
                                opt_result_u_v_w_z_area.U_V_W_Z_AREA_QTY_X = Convert.ToInt32(str7)
                            End If
                            Dim str8 As String = Me.getValue1(source, "[*U/V/W/Z_AREA_QTY_Y#]=")
                            If Not String.IsNullOrEmpty(str8) Then
                                opt_result_u_v_w_z_area.U_V_W_Z_AREA_QTY_Y = Convert.ToInt32(str8)
                            End If
                        Next num2
                        Me.OptResultYAreaList.Add(opt_result_y_area)
                        Exit Select
                End Select
            Loop
            tr.Close()
        End Sub

        Public Sub Load(ByVal fileName As String)
            Dim stream As New FileStream(fileName, FileMode.Open)
            Me.Load(stream)
            stream.Close()
        End Sub

        Private Function read(ByVal tr As TextReader) As String
            Dim str As String = String.Empty
            Dim str2 As String = String.Empty
            Do While (Not str2 = tr.ReadLine Is Nothing)
                If (str2 <> "") Then
                    str = (str & str2)
                Else
                    Return str
                End If
            Loop
            Return str
        End Function

        Public Sub Save(<Out> ByRef data As Byte())
            Dim stream As New MemoryStream
            Me.Save(stream)
            data = stream.ToArray
            stream.Close()
            stream.Dispose()
        End Sub

        Private Sub Save(ByVal stream As Stream)
            Try
                Try
                    Dim writer As TextWriter = New StreamWriter(stream, Encoding.UTF8)
                    Dim invariantInfo As NumberFormatInfo = NumberFormatInfo.InvariantInfo
                    writer.WriteLine("[---HEADER---]")
                    writer.WriteLine(String.Format(invariantInfo, "[RELEASE#]={0}[OWNER@]={1}", New Object() {Me.Header.RELEASE, Me.Header.OWNER}))
                    writer.WriteLine("")
                    writer.WriteLine("[---ITEM_ARRAY---]")
                    Dim item As ITEM
                    For Each item In Me.ItemList
                        writer.WriteLine(String.Format(invariantInfo, "[REC#]={0}[BOX#]={1}[ORDER@]={2}[ITEM#]={3}[OPT_GROUP#]={4}[CODE@]={5}", New Object() {item.REC, item.BOX, item.ORDER, item.ITEM_, item.OPT_GROUP, item.CODE}))
                        writer.WriteLine(String.Format(invariantInfo, "[WIDTH#.]={0:F3}[HEIGHT#.]={1:F3}[UNIT_QTY#]={2}[SHEET_QTY#]={3}[*RACK@]={4}", New Object() {item.WIDTH, item.HEIGHT, item.UNIT_QTY, item.SHEET_QTY, item.RACK.Trim}))
                        If Not String.IsNullOrEmpty(item.SHAPE_FILE) Then
                            writer.WriteLine(("[SHAPE_FILE@]=" & item.SHAPE_FILE))
                        End If
                        writer.WriteLine("")
                    Next
                    writer.WriteLine("[---GLASS_ARRAY---]")
                    Dim glass As GLASS
                    For Each glass In Me.GlassList
                        writer.WriteLine(String.Format(invariantInfo, "[REC#]={0}[CODE@]={1}[DESCRIPTION@]={2}[RACK@]={3}[WIDTH#.]={4:F3}", New Object() {glass.REC, glass.CODE, glass.DESCRIPTION, glass.RACK, glass.WIDTH}))
                        writer.WriteLine(String.Format(invariantInfo, "[HEIGHT#.]={0:F3}[QTY#]={1}[BOTTOM_TRIM#.]={2:F3}[RIGHT_TRIM#.]={3:F3}", New Object() {glass.HEIGHT, glass.QTY, glass.BOTTOM_TRIM, glass.RIGHT_TRIM}))
                        writer.WriteLine(String.Format(invariantInfo, "[TOP_TRIM#.]={0:F3}[LEFT_TRIM#.]={1:F3}[MIN_BREAK_DIST#.]={2:F3}", New Object() {glass.TOP_TRIM, glass.LEFT_TRIM, glass.MIN_BREAK_DIST}))
                        writer.WriteLine("")
                    Next
                    writer.WriteLine("[---OPT_PARAMETER---]")
                    writer.WriteLine(String.Format(invariantInfo, "[OPT_TIME#]={0}[OPT_%TARGET#]={1}[MIN_SUBPL_WIDTH#.]={2:F3}", New Object() {Me.OptParametr.OPT_TIME, Me.OptParametr.OPT_TARGET, Me.OptParametr.MIN_SUBPL_WIDTH}))
                    writer.WriteLine(String.Format(invariantInfo, "[MAX_SUBPL_WIDTH#.]={0:F3}[MIN_BREAK_DIST#.]={1:F3}", New Object() {Me.OptParametr.MAX_SUBPL_WIDTH, Me.OptParametr.MIN_BREAK_DIST}))
                    writer.WriteLine("")
                    writer.WriteLine("[---OPT_RESULT_HEADER---]")
                    writer.WriteLine(String.Format(invariantInfo, "[USED_STRATEGY#]={0}[USED_OPT_PARA@]={1}[OPT_AREA_NET#]={2}", New Object() {Me.OptResultHeader.USED_STRATEGY, Me.OptResultHeader.USED_OPT_PARA, Me.OptResultHeader.OPT_AREA_NET}))
                    writer.WriteLine(String.Format(invariantInfo, "[OPT_AREA_GROSS#]={0}[OPT_WASTE%#]={1}[REMNANT_WIDTH#.]={2:F3}", New Object() {Me.OptResultHeader.OPT_AREA_GROSS, Me.OptResultHeader.OPT_WASTE, Me.OptResultHeader.REMNANT_WIDTH}))
                    writer.WriteLine(String.Format(invariantInfo, "[REMNANT_HEIGHT#.]={0:F3}[STOCK_SHEET_QTY#]={1}[STOCK_SHEET_TYPE_QTY#]={2}", New Object() {Me.OptResultHeader.REMNANT_HEIGHT, Me.OptResultHeader.STOCK_SHEET_QTY, Me.OptResultHeader.STOCK_SHEET_TYPE_QTY}))
                    writer.WriteLine(String.Format(invariantInfo, "[X_AREA_TYPE_QTY#]={0}", New Object() {Me.OptResultHeader.X_AREA_TYPE_QTY}))
                    writer.WriteLine("")
                    writer.WriteLine("[---OPT_RESULT_STOCK_SHEET_ARRAY---]")
                    Dim opt_result_stock_sheet As OPT_RESULT_STOCK_SHEET
                    For Each opt_result_stock_sheet In Me.OptResultStoockSheetList
                        writer.WriteLine(String.Format(invariantInfo, "[STOCK_SHEET#]={0}[GLASS_REF#]={1}[REMNANT_WIDTH#.]={2:F3}[X_AREA_QTY#]={3}", New Object() {opt_result_stock_sheet.STOCK_SHEET, opt_result_stock_sheet.GLASS_REF, opt_result_stock_sheet.REMNANT_WIDTH, opt_result_stock_sheet.X_AREA_QTY}))
                        If (opt_result_stock_sheet.ROTATED_YN <> 0) Then
                            writer.WriteLine(String.Format(invariantInfo, "[ROTATED_YN#]={0}", New Object() {opt_result_stock_sheet.ROTATED_YN}))
                        End If
                        writer.WriteLine(String.Format(invariantInfo, "[X_AREA_TYPE_QTY#]={0}", New Object() {opt_result_stock_sheet.X_AREA_TYPE_QTY}))
                        Dim num As Integer
                        For Each num In opt_result_stock_sheet.X_AREA_REF
                            writer.WriteLine(String.Format(invariantInfo, "[*X_AREA_REF#]={0}", New Object() {num}))
                        Next
                        writer.WriteLine("")
                    Next
                    writer.WriteLine("[---OPT_RESULT_X_AREA_ARRAY---]")
                    Dim opt_result_x_area As OPT_RESULT_X_AREA
                    For Each opt_result_x_area In Me.OptResultXAreaList
                        writer.WriteLine(String.Format(invariantInfo, "[X_AREA#]={0}[WIDTH#.]={1:F3}[HEIGHT#.]={2:F3}[Y_AREA_QTY#]={3}", New Object() {opt_result_x_area.X_AREA, opt_result_x_area.WIDTH, opt_result_x_area.HEIGHT, opt_result_x_area.Y_AREA_QTY}))
                        writer.WriteLine(String.Format(invariantInfo, "[Y_AREA_TYPE_QTY#]={0}", New Object() {opt_result_x_area.Y_AREA_TYPE_QTY}))
                        Dim num As Integer
                        For Each num In opt_result_x_area.Y_AREA_REF
                            writer.WriteLine(String.Format(invariantInfo, "[*Y_AREA_REF#]={0}", New Object() {num}))
                        Next
                        writer.WriteLine("")
                    Next
                    writer.WriteLine("[---OPT_RESULT_Y_AREA_ARRAY---]")
                    Dim opt_result_y_area As OPT_RESULT_Y_AREA
                    For Each opt_result_y_area In Me.OptResultYAreaList
                        writer.WriteLine(String.Format(invariantInfo, "[Y_AREA#]={0}[WIDTH#.]={1:F3}[HEIGHT#.]={2:F3}[U/V/W/Z_AREA_TYPE_QTY#]={3}", New Object() {opt_result_y_area.Y_AREA, opt_result_y_area.WIDTH, opt_result_y_area.HEIGHT, opt_result_y_area.U_V_W_Z_AREA_TYPE_QTY}))
                        Dim opt_result_u_v_w_z_area As OPT_RESULT_U_V_W_Z_AREA
                        For Each opt_result_u_v_w_z_area In opt_result_y_area.ITEMS
                            writer.WriteLine(String.Format(invariantInfo, "[*U/V/W/Z_AREA_ITEM_REF#]={0}[*U/V/W/Z_AREA_WIDTH#.]={1:F3}", New Object() {opt_result_u_v_w_z_area.U_V_W_Z_AREA_ITEM_REF, opt_result_u_v_w_z_area.U_V_W_Z_AREA_WIDTH}))
                            If (opt_result_u_v_w_z_area.U_V_W_Z_AREA_QTY_Y <> 1) Then
                                writer.WriteLine(String.Format(invariantInfo, "[*U/V/W/Z_AREA_HEIGHT#.]={0:F3}[*U_V_W_Z_AREA_QTY_Y#]={1}", New Object() {opt_result_u_v_w_z_area.U_V_W_Z_AREA_HEIGHT, opt_result_u_v_w_z_area.U_V_W_Z_AREA_QTY_Y}))
                            Else
                                writer.WriteLine(String.Format(invariantInfo, "[*U/V/W/Z_AREA_HEIGHT#.]={0:F3}", New Object() {opt_result_u_v_w_z_area.U_V_W_Z_AREA_HEIGHT}))
                            End If
                        Next
                        writer.WriteLine("")
                    Next
                    writer.Flush()
                    writer.Close()
                Catch obj1 As Object
                End Try
            End Try
        End Sub

        Public Sub Save(ByVal fileName As String)
            Dim stream As New FileStream(fileName, FileMode.Create)
            Me.Save(stream)
            stream.Close()
        End Sub


        ' Fields
        Public GlassList As List(Of GLASS) = New List(Of GLASS)
        Public Header As HEADER = New HEADER
        Public ItemList As List(Of ITEM) = New List(Of ITEM)
        Public OptParametr As OPT_PARAMETER = New OPT_PARAMETER
        Public OptResultHeader As OPT_RESULT_HEADER = New OPT_RESULT_HEADER
        Public OptResultStoockSheetList As List(Of OPT_RESULT_STOCK_SHEET) = New List(Of OPT_RESULT_STOCK_SHEET)
        Public OptResultXAreaList As List(Of OPT_RESULT_X_AREA) = New List(Of OPT_RESULT_X_AREA)
        Public OptResultYAreaList As List(Of OPT_RESULT_Y_AREA) = New List(Of OPT_RESULT_Y_AREA)

        ' Nested Types
        Public Class GLASS
            ' Fields
            Public BOTTOM_TRIM As Double
            Public CODE As String
            Public DESCRIPTION As String
            Public HEIGHT As Double
            Public LEFT_TRIM As Double
            Public MIN_BREAK_DIST As Double
            Public ORIENTATION As Integer
            Public QTY As Integer
            Public RACK As String
            Public REC As Integer
            Public RIGHT_TRIM As Double
            Public TOP_TRIM As Double
            Public WIDTH As Double
        End Class

        Public Class HEADER
            ' Fields
            Public OWNER As String
            Public RELEASE As String
        End Class

        Public Class ITEM
            ' Fields
            Public BOX As Integer
            Public CODE As String
            Public HEIGHT As Double
            Public INFO As String
            Public ITEM_ As Integer
            Public OPT_GROUP As Integer
            Public ORDER As String
            Public RACK As String
            Public REC As Integer
            Public SHAPE_FILE As String
            Public SHEET_QTY As Integer
            Public UNIT_QTY As Integer
            Public WIDTH As Double
        End Class

        Public Class OPT_PARAMETER
            ' Fields
            Public MAX_SUBPL_WIDTH As Double
            Public MIN_BREAK_DIST As Double
            Public MIN_SUBPL_WIDTH As Double
            Public OPT_TARGET As Integer
            Public OPT_TIME As Integer
        End Class

        Public Class OPT_RESULT_HEADER
            ' Fields
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
        End Class

        Public Class OPT_RESULT_STOCK_SHEET
            ' Fields
            Public GLASS_REF As Integer
            Public REMNANT_WIDTH As Double
            Public ROTATED_YN As Integer
            Public STOCK_SHEET As Integer
            Public X_AREA_QTY As Integer
            Public X_AREA_REF As List(Of Integer) = New List(Of Integer)
            Public X_AREA_TYPE_QTY As Integer
        End Class

        Public Class OPT_RESULT_U_V_W_Z_AREA
            ' Fields
            Public U_V_W_Z_AREA_HEIGHT As Double
            Public U_V_W_Z_AREA_ITEM_REF As Integer
            Public U_V_W_Z_AREA_QTY_X As Integer = 1
            Public U_V_W_Z_AREA_QTY_Y As Integer = 1
            Public U_V_W_Z_AREA_WIDTH As Double
        End Class

        Public Class OPT_RESULT_X_AREA
            ' Fields
            Public HEIGHT As Double
            Public WIDTH As Double
            Public X_AREA As Integer
            Public Y_AREA_QTY As Integer
            Public Y_AREA_REF As List(Of Integer) = New List(Of Integer)
            Public Y_AREA_TYPE_QTY As Integer
        End Class

        Public Class OPT_RESULT_Y_AREA
            ' Fields
            Public HEIGHT As Double
            Public ITEMS As List(Of OPT_RESULT_U_V_W_Z_AREA) = New List(Of OPT_RESULT_U_V_W_Z_AREA)
            Public U_V_W_Z_AREA_TYPE As Integer
            Public U_V_W_Z_AREA_TYPE_QTY As Integer
            Public WIDTH As Double
            Public Y_AREA As Integer
        End Class

        Private Enum Section
            ' Fields
            GLASS = 3
            HEADER = 1
            ITEM = 2
            OPT_PARAMETER = 4
            OPT_RESULT_HEADER = 5
            OPT_RESULT_STOCK_SHEET = 6
            OPT_RESULT_X_AREA = 7
            OPT_RESULT_Y_AREA = 8
            Undefined = 0
        End Enum
    End Class
End Namespace
