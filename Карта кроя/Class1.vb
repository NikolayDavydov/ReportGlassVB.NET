'Imports System.IO

'Public Class LoadStream
'    Private Enum Section
'        ' Fields
'        GLASS = 3
'        HEADER = 1
'        ITEM = 2
'        OPT_PARAMETER = 4
'        OPT_RESULT_HEADER = 5
'        OPT_RESULT_STOCK_SHEET = 6
'        OPT_RESULT_X_AREA = 7
'        OPT_RESULT_Y_AREA = 8
'        Undefined = 0
'    End Enum


'    Public Sub Load(ByVal stream As Stream)
'        Dim tr As TextReader = New StreamReader(stream)
'        Dim undefined As Section = Section.Undefined
'        Dim str As String = String.Empty
'        Do While (Not str = tr.ReadLine Is Nothing)
'            Dim str2 As String
'            Dim str4 As String
'            Dim num As Integer
'            Dim num2 As Integer
'            If (str = "[---HEADER---]") Then
'                undefined = Section.HEADER
'            ElseIf (str = "[---ITEM_ARRAY---]") Then
'                undefined = Section.ITEM
'            ElseIf (str = "[---GLASS_ARRAY---]") Then
'                undefined = Section.GLASS
'            ElseIf (str = "[---OPT_PARAMETER---]") Then
'                undefined = Section.OPT_PARAMETER
'            ElseIf (str = "[---OPT_RESULT_HEADER---]") Then
'                undefined = Section.OPT_RESULT_HEADER
'            ElseIf (str = "[---OPT_RESULT_STOCK_SHEET_ARRAY---]") Then
'                undefined = Section.OPT_RESULT_STOCK_SHEET
'            ElseIf (str = "[---OPT_RESULT_X_AREA_ARRAY---]") Then
'                undefined = Section.OPT_RESULT_X_AREA
'            ElseIf (str = "[---OPT_RESULT_Y_AREA_ARRAY---]") Then
'                undefined = Section.OPT_RESULT_Y_AREA
'            End If
'            Select Case undefined
'                Case Section.ITEM
'                    str2 = (str & Me.read(tr))
'                    Dim item As New ITEM With { _
'                        .REC = Useful.GetInt32(Me.getValue(str2, "REC")), _
'                        .BOX = Useful.GetInt32(Me.getValue(str2, "BOX")), _
'                        .ORDER = Me.getValue(str2, "ORDER"), _
'                        .ITEM_ = Useful.GetInt32(Me.getValue(str2, "ITEM")), _
'                        .OPT_GROUP = Useful.GetInt32(Me.getValue(str2, "OPT_GROUP")), _
'                        .CODE = Me.getValue(str2, "CODE"), _
'                        .WIDTH = Useful.GetDouble(Me.getValue(str2, "WIDTH")), _
'                        .HEIGHT = Useful.GetDouble(Me.getValue(str2, "HEIGHT")), _
'                        .UNIT_QTY = Useful.GetInt32(Me.getValue(str2, "UNIT_QTY")), _
'                        .SHEET_QTY = Useful.GetInt32(Me.getValue(str2, "SHEET_QTY")), _
'                        .RACK = Me.getValue(str2, "*RACK"), _
'                        .INFO = Me.getValue(str2, "INFO"), _
'                        .SHAPE_FILE = Me.getValue(str2, "SHAPE_FILE") _
'                    }
'                    Me.ItemList.Add(item)
'                    Continue Do
'                Case Section.GLASS
'                    str2 = (str & Me.read(tr))
'                    Dim glass As New GLASS With { _
'                        .REC = Useful.GetInt32(Me.getValue(str2, "REC")), _
'                        .CODE = Convert.ToString(Me.getValue(str2, "CODE")), _
'                        .DESCRIPTION = Convert.ToString(Me.getValue(str2, "DESCRIPTION")), _
'                        .RACK = Convert.ToString(Me.getValue(str2, "RACK")), _
'                        .WIDTH = Useful.GetDouble(Me.getValue(str2, "WIDTH")), _
'                        .HEIGHT = Useful.GetDouble(Me.getValue(str2, "HEIGHT")), _
'                        .QTY = Useful.GetInt32(Me.getValue(str2, "QTY")), _
'                        .BOTTOM_TRIM = Useful.GetDouble(Me.getValue(str2, "BOTTOM_TRIM")), _
'                        .RIGHT_TRIM = Useful.GetDouble(Me.getValue(str2, "RIGHT_TRIM")), _
'                        .TOP_TRIM = Useful.GetDouble(Me.getValue(str2, "TOP_TRIM")), _
'                        .LEFT_TRIM = Useful.GetDouble(Me.getValue(str2, "LEFT_TRIM")), _
'                        .MIN_BREAK_DIST = Useful.GetDouble(Me.getValue(str2, "MIN_BREAK_DIST")) _
'                    }
'                    If (Me.getValue(str2, "ORIENTATION") <> String.Empty) Then
'                        glass.ORIENTATION = Useful.GetInt32(Me.getValue(str2, "ORIENTATION"))
'                    End If
'                    Me.GlassList.Add(glass)
'                    Continue Do
'                Case Section.OPT_PARAMETER
'                    str2 = (str & Me.read(tr))
'                    Me.OptParametr.OPT_TIME = Useful.GetInt32(Me.getValue(str2, "OPT_TIME"))
'                    Me.OptParametr.OPT_TARGET = Useful.GetInt32(Me.getValue(str2, "OPT_%TARGET"))
'                    Me.OptParametr.MIN_SUBPL_WIDTH = Useful.GetDouble(Me.getValue(str2, "MIN_SUBPL_WIDTH"))
'                    Me.OptParametr.MAX_SUBPL_WIDTH = Useful.GetDouble(Me.getValue(str2, "MAX_SUBPL_WIDTH"))
'                    Me.OptParametr.MIN_BREAK_DIST = Useful.GetDouble(Me.getValue(str2, "MIN_BREAK_DIST"))
'                    Continue Do
'                Case Section.OPT_RESULT_HEADER
'                    str2 = (str & Me.read(tr))
'                    Me.OptResultHeader.USED_STRATEGY = Useful.GetInt32(Me.getValue(str2, "USED_STRATEGY"))
'                    Me.OptResultHeader.USED_OPT_PARA = Convert.ToString(Me.getValue(str2, "USED_OPT_PARA"))
'                    Me.OptResultHeader.OPT_AREA_NET = Useful.GetInt32(Me.getValue(str2, "OPT_AREA_NET"))
'                    Me.OptResultHeader.OPT_AREA_GROSS = Useful.GetInt32(Me.getValue(str2, "OPT_AREA_GROSS"))
'                    Me.OptResultHeader.OPT_WASTE = Useful.GetDouble(Me.getValue(str2, "OPT_WASTE%"))
'                    Me.OptResultHeader.REMNANT_WIDTH = Useful.GetDouble(Me.getValue(str2, "REMNANT_WIDTH"))
'                    Me.OptResultHeader.REMNANT_HEIGHT = Useful.GetDouble(Me.getValue(str2, "REMNANT_HEIGHT"))
'                    Me.OptResultHeader.STOCK_SHEET_QTY = Useful.GetInt32(Me.getValue(str2, "STOCK_SHEET_QTY"))
'                    Me.OptResultHeader.STOCK_SHEET_TYPE_QTY = Useful.GetInt32(Me.getValue(str2, "STOCK_SHEET_TYPE_QTY"))
'                    Me.OptResultHeader.X_AREA_TYPE_QTY = Useful.GetInt32(Me.getValue(str2, "X_AREA_TYPE_QTY"))
'                    Continue Do
'                Case Section.HEADER
'                    str2 = Me.read(tr)
'                    Me.Header.OWNER = Me.getValue(str2, "OWNER")
'                    Me.Header.RELEASE = Me.getValue(str2, "RELEASE")
'                    Continue Do
'                Case Section.OPT_RESULT_STOCK_SHEET
'                    str2 = (str & Me.read(tr))
'                    Dim opt_result_stock_sheet As New OPT_RESULT_STOCK_SHEET With { _
'                        .STOCK_SHEET = Useful.GetInt32(Me.getValue(str2, "STOCK_SHEET")), _
'                        .GLASS_REF = Useful.GetInt32(Me.getValue(str2, "GLASS_REF")), _
'                        .REMNANT_WIDTH = Useful.GetDouble(Me.getValue(str2, "REMNANT_WIDTH")), _
'                        .X_AREA_QTY = Useful.GetInt32(Me.getValue(str2, "X_AREA_QTY")), _
'                        .X_AREA_TYPE_QTY = Useful.GetInt32(Me.getValue(str2, "X_AREA_TYPE_QTY")) _
'                    }
'                    If (Me.getValue(str2, "ROTATED_YN") <> String.Empty) Then
'                        opt_result_stock_sheet.ROTATED_YN = Useful.GetInt32(Me.getValue(str2, "ROTATED_YN"))
'                    Else
'                        opt_result_stock_sheet.ROTATED_YN = 0
'                    End If
'                    Dim str3 As String
'                    For Each str3 In Me.getValues(str2, "*X_AREA_REF#")
'                    str4 = Me.getValue1(str2, $"[*X_AREA_REF#]={str3}[*X_AREA_REF_QTY#]=")
'                        If Not String.IsNullOrEmpty(str4) Then
'                            num = 0
'                            Do While (num < Convert.ToInt32(str4))
'                                opt_result_stock_sheet.X_AREA_REF.Add(Convert.ToInt32(str3))
'                                num += 1
'                            Loop
'                        Else
'                            opt_result_stock_sheet.X_AREA_REF.Add(Convert.ToInt32(str3))
'                        End If
'                    Next
'                    Dim str5 As String = Me.getValue(str2, "QTY#")
'                    If Not String.IsNullOrEmpty(str5) Then
'                        num2 = 0
'                        Do While (num2 < Useful.GetInt32(str5))
'                            Me.OptResultStoockSheetList.Add(opt_result_stock_sheet)
'                            num2 += 1
'                        Loop
'                    Else
'                        Me.OptResultStoockSheetList.Add(opt_result_stock_sheet)
'                    End If
'                    Continue Do
'                Case Section.OPT_RESULT_X_AREA
'                    str2 = (str & Me.read(tr))
'                    Dim opt_result_x_area As New OPT_RESULT_X_AREA With { _
'                        .X_AREA = Useful.GetInt32(Me.getValue(str2, "X_AREA")), _
'                        .WIDTH = Useful.GetDouble(Me.getValue(str2, "WIDTH")), _
'                        .HEIGHT = Useful.GetDouble(Me.getValue(str2, "HEIGHT")), _
'                        .Y_AREA_QTY = Useful.GetInt32(Me.getValue(str2, "Y_AREA_QTY")), _
'                        .Y_AREA_TYPE_QTY = Useful.GetInt32(Me.getValue(str2, "Y_AREA_TYPE_QTY")) _
'                    }
'                    Dim str3 As String
'                    For Each str3 In Me.getValues(str2, "*Y_AREA_REF#")
'                    str4 = Me.getValue1(str2, $"[*Y_AREA_REF#]={str3}[*Y_AREA_REF_QTY#]=")
'                        If Not String.IsNullOrEmpty(str4) Then
'                            num()
'                            For num = 0 To Convert.ToInt32(str4) - 1
'                                opt_result_x_area.Y_AREA_REF.Add(Convert.ToInt32(str3))
'                            Next num
'                        Else
'                            opt_result_x_area.Y_AREA_REF.Add(Convert.ToInt32(str3))
'                        End If
'                    Next
'                    Me.OptResultXAreaList.Add(opt_result_x_area)
'                    Exit Select
'                Case Section.OPT_RESULT_Y_AREA
'                    str2 = (str & Me.read(tr))
'                    Dim opt_result_y_area As New OPT_RESULT_Y_AREA With { _
'                        .Y_AREA = Useful.GetInt32(Me.getValue(str2, "Y_AREA")), _
'                        .WIDTH = Useful.GetDouble(Me.getValue(str2, "WIDTH")), _
'                        .HEIGHT = Useful.GetDouble(Me.getValue(str2, "HEIGHT")), _
'                        .U_V_W_Z_AREA_TYPE_QTY = Useful.GetInt32(Me.getValue(str2, "U/V/W/Z_AREA_TYPE_QTY")) _
'                    }
'                    Dim strArray As String() = Me.getValues(str2, "*U/V/W/Z_AREA_ITEM_REF")
'                    Dim strArray2 As String() = Me.getValues(str2, "*U/V/W/Z_AREA_WIDTH")
'                    Dim strArray3 As String() = Me.getValues(str2, "*U/V/W/Z_AREA_HEIGHT")
'                    Dim strArray4 As String() = str2.Split(New String() {"[*U/V/W/Z_AREA_ITEM_REF#]"}, StringSplitOptions.None)
'                    num2()
'                    For num2 = 0 To opt_result_y_area.U_V_W_Z_AREA_TYPE_QTY - 1
'                        Dim source As String = strArray4((num2 + 1))
'                        Dim opt_result_u_v_w_z_area As New OPT_RESULT_U_V_W_Z_AREA With { _
'                            .U_V_W_Z_AREA_ITEM_REF = Useful.GetInt32(strArray(num2)), _
'                            .U_V_W_Z_AREA_HEIGHT = Useful.GetDouble(strArray3(num2)), _
'                            .U_V_W_Z_AREA_WIDTH = Useful.GetDouble(strArray2(num2)) _
'                        }
'                        opt_result_y_area.ITEMS.Add(opt_result_u_v_w_z_area)
'                        Dim str7 As String = Me.getValue1(source, "[*U/V/W/Z_AREA_QTY_X#]=")
'                        If Not String.IsNullOrEmpty(str7) Then
'                            opt_result_u_v_w_z_area.U_V_W_Z_AREA_QTY_X = Convert.ToInt32(str7)
'                        End If
'                        Dim str8 As String = Me.getValue1(source, "[*U/V/W/Z_AREA_QTY_Y#]=")
'                        If Not String.IsNullOrEmpty(str8) Then
'                            opt_result_u_v_w_z_area.U_V_W_Z_AREA_QTY_Y = Convert.ToInt32(str8)
'                        End If
'                    Next num2
'                    Me.OptResultYAreaList.Add(opt_result_y_area)
'                    Exit Select
'            End Select
'        Loop
'        tr.Close()
'    End Sub

'End Class
