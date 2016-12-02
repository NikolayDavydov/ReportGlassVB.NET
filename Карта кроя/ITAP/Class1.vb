'Imports Report.ITAP.Components
'Imports Report.ITAP.Components.Enums
'Imports Report.ITAP.SquareOPT
'Imports ITAP.SquareOPT.Info
'Imports ITAP.SquareOPT.Modeling
'Imports System
'Imports System.Collections.Generic
'Imports System.ComponentModel
'Imports System.IO
'Imports System.Linq
'Imports System.Threading
'Imports System.Windows.Forms
'Imports System.Xml

'Namespace ITAP.SquareOPT.Strategy.GpsOpt
'    Public Class FromGpsOptResult
'        Inherits MainStrategy
'        Implements INotifyPropertyChanged
'        ' Events
'        Public Custom Event PropertyChanged As PropertyChangedEventHandler

'            ' Methods
'        Public Sub New()
'            MyBase.Name = "2D ðàñêðîé: GPS-OPT"
'            MyBase.Identificator = New Guid("23E4B446-CEC4-4BDC-802A-36B5F80510A3")
'            Me.variantOut = 0
'        End Sub

'        Public Overrides Function EditOptions() As Boolean?
'            Dim form As New SettingsForm(Me)
'            form.ShowDialog()
'            Return form.DialogResult
'        End Function

'        Public Overrides Sub Execute(ByVal optimizator As Optimizator)
'            Dim export As IExport = New ExportFromModel(optimizator)
'            If Me.IsInputPlateGroupBySize Then
'                export = New ExportFromModelGroupBySize(optimizator)
'            End If
'            Dim fileName As String = String.Empty
'            If (Me.VariantOut = 0) Then
'                fileName = $"{Me.OutputPath}\{Useful.NormalizeFileName(optimizator.InputData.Name)}.trf"
'                export.GetResult(fileName)
'            End If
'            If (Me.VariantOut = 1) Then
'                fileName = $"{Me.OutputPath}\gpsOpt.trf"
'                export.GetResult(fileName)
'            End If
'            Dim no As DialogResult = DialogResult.No
'            Do While (no = DialogResult.No)
'                no = MessageBox.Show(("Çàïóñòèòå âíåøíþþ ïðîãðàììó îïòèìèçàöèè è âûïîëíèòå îïòèìèçàöèþ." & ChrW(10) & "Ôàéë ñ äàííûìè:" & ChrW(10) & fileName & ChrW(10) & ChrW(10) & ChrW(10) & "Ðåçóëüòàò îïòèìèçàöèè äîñòóïåí äëÿ çàãðóçêè â ñèñòåìó?"), "Âîïðîñ", MessageBoxButtons.YesNoCancel)
'                If (no = DialogResult.Cancel) Then
'                    optimizator.Message(ProgressState.Abort, "Íå ïðîèçâåäåíà îïòèìèçàöèÿ")
'                    Return
'                End If
'                If Not (((no <> DialogResult.Yes) OrElse (Me.FileResult = String.Empty)) OrElse File.Exists(Me.FileResult)) Then
'                    no = DialogResult.No
'                    MessageBox.Show("Âûïîëíèòå îïòèìèçàöèþ!")
'                End If
'            Loop
'            Dim opt As New ResultOpt
'            opt.Load(Me.FileResult)
'            optimizator.OriginalInputName = "GpsOpt result"
'            Dim data As Byte() = Nothing
'            opt.Save(data)
'            optimizator.OriginalInputData = data
'            optimizator.Map.Clear()
'            Dim source As List(Of InputPlate) = Enumerable.ToList(Of InputPlate)(optimizator.InputData.Plates)
'            Dim usedFrames As New List(Of InputFrame)
'            Using enumerator As Enumerator(Of OPT_RESULT_STOCK_SHEET) = opt.OptResultStoockSheetList.GetEnumerator
'                Do While enumerator.MoveNext
'                    Dim classa As <>c__DisplayClassa
'                    Dim class4 As <>c__DisplayClass7
'                    Dim match As Predicate(Of GLASS) = Nothing
'                    Dim sheetArea As OPT_RESULT_STOCK_SHEET = enumerator.Current
'                    Dim predicate As Func(Of InputFrame, Boolean) = Nothing
'                    If (match Is Nothing) Then
'                        match = p >= (p.REC = sheetArea.GLASS_REF)
'                    End If
'                    Dim glass As GLASS = opt.GlassList.Find(match)
'                    Dim frame As InputFrame = Enumerable.FirstOrDefault(Of InputFrame)(optimizator.InputData.Frames, Function (ByVal p As InputFrame) 
'                        Dim classa1 As <>c__DisplayClassa = classa
'                        Dim class1 As <>c__DisplayClass7 = class4
'                        Return (((Enumerable.Count(Of InputFrame)(usedFrames, t => (t Is p)) <= p.Count) AndAlso (p.Width = glass.WIDTH)) AndAlso (p.Height = glass.HEIGHT))
'                    End Function)
'                    If (frame Is Nothing) Then
'                        If (predicate Is Nothing) Then
'                            predicate = Function (ByVal p As InputFrame) 
'                                Dim classa1 As <>c__DisplayClassa = classa
'                                Dim class1 As <>c__DisplayClass7 = class4
'                                Return (((Enumerable.Count(Of InputFrame)(usedFrames, t => (t Is p)) <= p.Count) AndAlso (p.Width = glass.HEIGHT)) AndAlso (p.Height = glass.WIDTH))
'                            End Function
'                        End If
'                        frame = Enumerable.FirstOrDefault(Of InputFrame)(optimizator.InputData.Frames, predicate)
'                        If (Not frame Is Nothing) Then
'                            Dim width As Double = frame.Width
'                            frame.Width = frame.Height
'                            frame.Height = width
'                        End If
'                    End If
'                    If (frame Is Nothing) Then
'                        Dim caption As String = $"Íå íàéäåíî ñòåêëî ñ ðàçìåðàìè {glass.WIDTH}õ{glass.HEIGHT}"
'                        Program.AddLog.Invoke(LogImage.Alert, caption, String.Empty)
'                        optimizator.Message(ProgressState.Abort, caption)
'                        Return
'                    End If
'                    frame.DBottom = glass.BOTTOM_TRIM
'                    frame.DLeft = glass.LEFT_TRIM
'                    frame.DRight = glass.RIGHT_TRIM
'                    frame.DTop = glass.TOP_TRIM
'                    frame.MinAllowSize = glass.MIN_BREAK_DIST
'                    usedFrames.Add(frame)
'                    Dim addedRectOriginal As New Rect(optimizator, frame, If((sheetArea.ROTATED_YN = 0), Orientation.Vertical, Orientation.Horizontal))
'                    optimizator.Map.Add(addedRectOriginal, AddActionMode.AndNoVerify)
'                    Dim num2 As Integer
'                    For Each num2 In sheetArea.X_AREA_REF
'                        Dim opt_result_x_area As OPT_RESULT_X_AREA = opt.GetOPT_RESULT_X_AREA(num2)
'                        If (opt_result_x_area Is Nothing) Then
'                            Throw New Exception
'                        End If
'                        Dim rect2 As New Rect(optimizator, 2)
'                        addedRectOriginal.Add(rect2, AddActionMode.AndNoVerify)
'                        Dim num3 As Integer
'                        For Each num3 In opt_result_x_area.Y_AREA_REF
'                            Dim opt_result_y_area As OPT_RESULT_Y_AREA = opt.GetOPT_RESULT_Y_AREA(num3)
'                            If (opt_result_y_area Is Nothing) Then
'                                MessageBox.Show("Íåîáõîäèìî ïðîâåðèòü ðåçóëüòàò çàãðóçêè îïòèìèçàöèè !!!")
'                            Else
'                                Dim rect3 As New Rect(optimizator, 3)
'                                rect2.Add(rect3, AddActionMode.AndNoVerify)
'                                Dim i As Integer
'                                For i = 0 To opt_result_y_area.U_V_W_Z_AREA_TYPE_QTY - 1
'                                    Dim func As Func(Of InputPlate, Boolean) = Nothing
'                                    Dim z As OPT_RESULT_U_V_W_Z_AREA = opt_result_y_area.ITEMS.Item(i)
'                                    Dim rect4 As Rect = Nothing
'                                    Dim flag As Boolean = ((z.U_V_W_Z_AREA_QTY_Y > 1) OrElse (z.U_V_W_Z_AREA_QTY_X > 1))
'                                    Dim parent As Rect = Nothing
'                                    If flag Then
'                                        parent = New Rect(optimizator, rect3)
'                                    End If
'                                    Dim j As Integer
'                                    For j = 0 To z.U_V_W_Z_AREA_QTY_Y - 1
'                                        Dim rect6 As Rect = Nothing
'                                        If flag Then
'                                            rect6 = New Rect(optimizator, parent)
'                                        End If
'                                        Dim k As Integer
'                                        For k = 0 To z.U_V_W_Z_AREA_QTY_X - 1
'                                            Dim item As ITEM = opt.GetITEM(z.U_V_W_Z_AREA_ITEM_REF)
'                                            If (item Is Nothing) Then
'                                                Throw New Exception
'                                            End If
'                                            Dim plate As InputPlate = Nothing
'                                            If Not Me.IsInputPlateGroupBySize Then
'                                                plate = Enumerable.FirstOrDefault(Of InputPlate)(optimizator.InputData.Plates, p >= (p.NumPos = item.REC))
'                                            Else
'                                                If (func Is Nothing) Then
'                                                    func = p >= (((p.Width = z.U_V_W_Z_AREA_WIDTH) AndAlso (p.Height = z.U_V_W_Z_AREA_HEIGHT)) OrElse ((p.Height = z.U_V_W_Z_AREA_WIDTH) AndAlso (p.Width = z.U_V_W_Z_AREA_HEIGHT)))
'                                                End If
'                                                plate = Enumerable.FirstOrDefault(Of InputPlate)(source, func)
'                                                source.Remove(plate)
'                                            End If
'                                            If (plate Is Nothing) Then
'                                                Throw New Exception
'                                            End If
'                                            If flag Then
'                                                rect4 = New Rect(optimizator, rect6)
'                                            Else
'                                                rect4 = New Rect(optimizator, rect3)
'                                            End If
'                                            rect4.InputPlate = plate
'                                            If ((z.U_V_W_Z_AREA_WIDTH <> rect4.InputPlate.Width) OrElse (z.U_V_W_Z_AREA_HEIGHT <> rect4.InputPlate.Height)) Then
'                                                rect4.Rotare()
'                                            End If
'                                        Next k
'                                    Next j
'                                Next i
'                            End If
'                        Next
'                    Next
'                Loop
'            End Using
'        End Sub

'        Public Overrides Sub LoadOptions(ByVal xmlDoc As XmlDocument)
'            Dim documentElement As XmlElement = xmlDoc.DocumentElement
'            If (Not documentElement Is Nothing) Then
'                Me.OutputPath = documentElement.GetAttribute("OutputPath")
'                Me.FileResult = documentElement.GetAttribute("FileResult")
'                If Not String.IsNullOrEmpty(documentElement.GetAttribute("VariantOut")) Then
'                    Me.VariantOut = Convert.ToInt32(documentElement.GetAttribute("VariantOut"))
'                End If
'                If Not String.IsNullOrEmpty(documentElement.GetAttribute("IsInputPlateGroupBySize")) Then
'                    Me.IsInputPlateGroupBySize = Convert.ToBoolean(documentElement.GetAttribute("IsInputPlateGroupBySize"))
'                End If
'            End If
'        End Sub

'        Public Overrides Function SaveOptions() As XmlDocument
'            Dim document As New XmlDocument
'            Dim newChild As XmlDeclaration = document.CreateXmlDeclaration("1.0", "utf-8", Nothing)
'            Dim element As XmlElement = document.CreateElement("Options")
'            document.InsertBefore(newChild, document.DocumentElement)
'            document.AppendChild(element)
'            element.SetAttribute("OutputPath", Me.OutputPath)
'            element.SetAttribute("FileResult", Me.FileResult)
'            element.SetAttribute("VariantOut", Me.VariantOut.ToString)
'            element.SetAttribute("IsInputPlateGroupBySize", Me.IsInputPlateGroupBySize.ToString)
'            Return document
'        End Function


'        ' Properties
'        Public Property FileResult As String
'            Get
'                Return Me.fileResult
'            End Get
'            Set(ByVal value As String)
'                Me.fileResult = value
'                If (Not Me.PropertyChanged Is Nothing) Then
'                    Me.PropertyChanged.Invoke(Me, New PropertyChangedEventArgs("FileResult"))
'                End If
'            End Set
'        End Property

'        Public Property IsInputPlateGroupBySize As Boolean
'            Get
'                Return Me.isInputPlateGroupBySize
'            End Get
'            Set(ByVal value As Boolean)
'                Me.isInputPlateGroupBySize = value
'                If (Not Me.PropertyChanged Is Nothing) Then
'                    Me.PropertyChanged.Invoke(Me, New PropertyChangedEventArgs("IsInputPlateGroupBySize"))
'                End If
'            End Set
'        End Property

'        Public Property OutputPath As String
'            Get
'                Return Me.outputPath
'            End Get
'            Set(ByVal value As String)
'                Me.outputPath = value
'                If (Not Me.PropertyChanged Is Nothing) Then
'                    Me.PropertyChanged.Invoke(Me, New PropertyChangedEventArgs("OutputPath"))
'                End If
'            End Set
'        End Property

'        Public Property VariantOut As Integer
'            Get
'                Return Me.variantOut
'            End Get
'            Set(ByVal value As Integer)
'                Me.variantOut = value
'                If (Not Me.PropertyChanged Is Nothing) Then
'                    Me.PropertyChanged.Invoke(Me, New PropertyChangedEventArgs("VariantOut"))
'                End If
'            End Set
'        End Property


'        ' Fields
'        Private fileResult As String
'        Private isInputPlateGroupBySize As Boolean
'        Private outputPath As String
'        Private variantOut As Integer
'    End Class
'End Namespace
