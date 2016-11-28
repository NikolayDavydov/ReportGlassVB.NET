Imports System.IO
Imports System.Linq
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.ObjectModel
Imports System.Security.Cryptography
Imports System.Text
Imports PdfSharp
Imports PdfSharp.Pdf
Imports PdfSharp.Drawing
Imports PdfSharp.Fonts
Imports PdfSharp.Forms
Imports MigraDoc
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.Rendering
'Imports System.Xml.XPath
Imports FileHelpers
Public Class Form1
    
    Dim columnName() As String = {"Номер опт.", "Материал", "Площадь листов", "Кол-во листов", _
                                      "Кол-во пластин", "Площадь пластин", "Кол-во остатков", "Кол-во раб. остатков", _
                                      "Площадь остатков", "Процент общий"}

    Public colors As New Colors
    Public Structure ITEM_ARRAY
        Public REC As Int32
        Public BOX As Int32
        Public ORDER As Int32
        Public ITEM As Int32 '[ITEM#]=1
        Public OPT_GROUP As Int32 '[OPT_GROUP#]=99
        Public CODE As String '[CODE@]=4 M1
        Public WIDTH As Int32 '[WIDTH#.]=1583.000
        Public HEIGHT As Int32 '[HEIGHT#.]=3180.000
        Public UNIT_QTY As Int32 '[UNIT_QTY#]=1
        Public SHEET_QTY As Int32 '[SHEET_QTY#]=1
        Public RACK As String '[*RACK@]=?
        Public SHAPE_FILE As String '[SHAPE_FILE@]=sf1.anz
    End Structure
    Public Structure GLASS_ARRAY
        Public REC As Int32 '[REC#]=1
        Public CODE As String '[CODE@]=4 M1
        Public DESCRIPTION As String '[DESCRIPTION@]=
        Public RACK As String '[RACK@]=A1
        Public WIDTH As Int32 '[WIDTH#.]=1613.000
        Public HEIGHT As Int32 '[HEIGHT#.]=3210.000
        Public QTY As Int32 '[QTY#]=1
        Public BOTTOM_TRIM As Int32 '[BOTTOM_TRIM#.]=15.000
        Public RIGHT_TRIM As Int32 '[RIGHT_TRIM#.]=15.000
        Public TOP_TRIM As Int32 '[TOP_TRIM#.]=15.000
        Public LEFT_TRIM As Int32 '[LEFT_TRIM#.]=15.000
        Public MIN_BREAK_DIST As Int32 '[MIN_BREAK_DIST#.]=15.000
    End Structure
    Public Structure OPT_PARAMETER
        Public OPT_TIME As Int32 '[OPT_TIME#]=60
        Public OPT_TARGET As Int32 '[OPT_%TARGET#]=0
        Public MIN_SUBPL_WIDTH As Int32 '[MIN_SUBPL_WIDTH#.]=0.000
        Public MAX_SUBPL_WIDTH As Int32 '[MAX_SUBPL_WIDTH#.]=6000.000
        Public MIN_BREAK_DIST As Int32 '[MIN_BREAK_DIST#.]=15.000
    End Structure
    Public Structure OPT_RESULT_HEADER
        Public USED_STRATEGY As Int32 '[USED_STRATEGY#]=0
        Public USED_OPT_PARA As Int32 '[USED_OPT_PARA@]=
        Public OPT_AREA_NET As Int32 '[OPT_AREA_NET#]=84940
        Public OPT_AREA_GROSS As Int32 '[OPT_AREA_GROSS#]=89671
        Public OPT_WASTE As Int32 '[OPT_WASTE%#]=528
        Public REMNANT_WIDTH As Int32 '[REMNANT_WIDTH#.]=3678.000
        Public REMNANT_HEIGHT As Int32 '[REMNANT_HEIGHT#.]=3210.000
        Public STOCK_SHEET_QTY As Int32 '[STOCK_SHEET_QTY#]=6
        Public STOCK_SHEET_TYPE_QTY As Int32 '[STOCK_SHEET_TYPE_QTY#]=6
        Public X_AREA_TYPE_QTY As Int32 '[X_AREA_TYPE_QTY#]=6
    End Structure
    Public Structure OPT_RESULT_STOCK_SHEET_ARRAY
        Public STOCK_SHEET As Int32 '[STOCK_SHEET#]=1
        Public GLASS_REF As Int32 '[GLASS_REF#]=1
        Public REMNANT_WIDTH As Int32 '[REMNANT_WIDTH#.]=15.000
        Public X_AREA_QTY As Int32 '[X_AREA_QTY#]=1
        Public ROTATED_YN As Int32 '[ROTATED_YN#]=1
        Public X_AREA_TYPE_QTY As Int32 '[X_AREA_TYPE_QTY#]=1
        Public X_AREA_REF As Int32 '[*X_AREA_REF#]=1
    End Structure
    Public Structure OPT_RESULT_X_AREA_ARRAY
        Public X_AREA As Int32 '[X_AREA#]=1
        Public WIDTH As Int32 '[WIDTH#.]=3180.000
        Public HEIGHT As Int32 '[HEIGHT#.]=1583.000
        Public Y_AREA_QTY As Int32 '[Y_AREA_QTY#]=1
        Public Y_AREA_TYPE_QTY As Int32 '[Y_AREA_TYPE_QTY#]=1
        Public Y_AREA_REF As Int32 '[*Y_AREA_REF#]=1
    End Structure
    Public Structure OPT_RESULT_Y_AREA_ARRAY
        Public Y_AREA As Int32 '[Y_AREA#]=1
        Public WIDTH As Int32 '[WIDTH#.]=1235.000
        Public HEIGHT As Int32 '[HEIGHT#.]=678.000
        Public Z_AREA_TYPE_QTY As Int32 '[U/V/W/Z_AREA_TYPE_QTY#]=1
        Public Z_AREA_ITEM_REF As Int32 '[*U/V/W/Z_AREA_ITEM_REF#]=2
        Public Z_AREA_WIDTH As Int32 '[*U/V/W/Z_AREA_WIDTH#.]=1235.000
        Public Z_AREA_HEIGHT As Int32 '[*U/V/W/Z_AREA_HEIGHT#.]=678.000
    End Structure
    Public Structure prfGlass
        Public itemArray() As ITEM_ARRAY
        Public glassArray() As GLASS_ARRAY
        Public optParameter() As OPT_PARAMETER
        Public optResultHeader() As OPT_RESULT_HEADER
        Public optResultStockSheetArray() As OPT_RESULT_STOCK_SHEET_ARRAY
        Public optResultXAreaArray() As OPT_RESULT_X_AREA_ARRAY
        Public optResultYAreaArray() As OPT_RESULT_Y_AREA_ARRAY
    End Structure
    Public Structure prfstr
        Public numPortion As Integer
        Public GlassInPrf() As prfGlass
    End Structure
    Dim prf() As prfstr
    Dim optioLine As Int32 = 0 'Итератор строк OptioDat

    Public Structure optioDatIndexes
        Public ITEM_ARRAY As Integer
        Public GLASS_ARRAY As Integer
        Public OPT_PARAMETER As Integer
        Public OPT_RESULT_HEADER As Integer
        Public OPT_RESULT_STOCK_SHEET_ARRAY As Integer
        Public OPT_RESULT_X_AREA_ARRAY As Integer
        Public OPT_RESULT_Y_AREA_ARRAY As Integer
    End Structure
    Dim optiodatIndex As optioDatIndexes
    Dim selectedFolder As String 'Выбранный портфель в ListView
    Dim ScreenWidth, ScreenHeight As Int16
    Dim graph As System.Drawing.Graphics
    Dim pict As System.Drawing.Bitmap
    Dim bmp As System.Drawing.Bitmap
    Public bmp_tmp As System.Drawing.Bitmap
    Dim formatsArray() As System.Drawing.Size 'Массив форматов стекол
    Dim screenFormat As System.Drawing.Size
    Dim coordPlate As System.Drawing.Point
    Dim coordSubPlate As System.Drawing.Point
    Dim coordGroupDetail As System.Drawing.Point
    Dim coordDetail As System.Drawing.Point
    Public Structure kromka
        Public left As Byte
        Public right As Byte
        Public top As Byte
        Public bottom As Byte
    End Structure
    Dim border As kromka
    Public Structure anzFile
        Public filename As String
        Public filenum As Integer
        Public anzLines() As String
    End Structure
    Public Structure DetailStructure
        Public widthDetail As Integer
        Public heightDetail As Integer
        Public quVertical As Integer
        Public quHorisontal As Integer
        Public marking As String
    End Structure
    Public Structure GroupDetailStructure
        Public quGroupDetail As Integer
        Public quDetail As Integer
        Public widthGroup As Integer
        Public heightGroup As Integer
        Public details() As DetailStructure
    End Structure
    Public Structure SubPlateStructure
        Public quGroupDetail As Integer
        Public widthSubPlate As Integer
        Public heightSubplate As Integer
        Public subIndex() As Integer
        Public groupDetail() As GroupDetailStructure
    End Structure
    Public Structure PlateStructure
        Public quSubPlate As Integer
        Public quCopyOfSubPlate As Integer
        Public widthOst As Integer
        Public subIndex() As Integer
        Public subPlate() As SubPlateStructure
        Public format As System.Drawing.Size
    End Structure
    Public Structure GlassStructure
        Public glassName As String
        Public quPlate As Integer
        Public quSubplate As Integer
        Public quDetails As Integer
        Public widthOst As Integer
        Public heightOst As Integer
        Public squareDetail As Single
        Public borders As kromka
        Public plate() As PlateStructure
        Public anzFile() As anzFile
    End Structure
    Public Structure PortionStructure
        Public numPortion As Integer
        Public glass() As GlassStructure
    End Structure
    Public Structure RectParams
        Public point As System.Drawing.Point
        Public size As System.Drawing.Size
    End Structure
    
    Dim Portion() As PortionStructure 'Массив порций
    Dim szPlateWOBorgers As System.Drawing.Size 'Размер листа без кромок
    Dim sz As System.Drawing.Size 'Размер листа
    Dim sz2 As System.Drawing.Size 'Размер листа без кромок
    Dim pt As System.Drawing.Point
    Public FolderPath As String 'Папка с выгрузками
    Dim AppPath As String   'Папка с программой
    Dim foldersArray() As String

    'Блок функций
    'Private Function PlaceLine(ByVal graph As System.Drawing.Graphics, ByVal pt1 As System.Drawing.Point, _
    '                           ByVal pt2 As System.Drawing.Point, _
    '                           ByVal ratio As Single, _
    '                           ByVal colorLine As colorRectangle) As System.Drawing.Graphics
    '    Dim pen As New System.Drawing.Pen(colorLine.colorPen, colorLine.penThikness)
    '    graph.DrawLine(pen, ResizePoint(pt1, ratio), ResizePoint(pt2, ratio))
    '    Return graph
    'End Function
    Private Function Get_str_to_int(ByVal str As String, ByVal start As Int16, ByVal len As Int16) As Int32
        Dim str_tmp As String = "0"
        If start = 0 Then
            str_tmp = Microsoft.VisualBasic.Left(str, len)
        Else
            str_tmp = Microsoft.VisualBasic.Left(str, start + len)
            str_tmp = Microsoft.VisualBasic.Mid(str, start, len)
        End If
        str_tmp = Microsoft.VisualBasic.Trim(str_tmp)
        Return Convert.ToInt32(str_tmp)
    End Function
    Private Function Get_str(ByVal str As String, ByVal start As Int16, ByVal len As Int16) As String
        Dim str_tmp As String = ""
        If start = 0 Then
            str_tmp = Microsoft.VisualBasic.Left(str, len)
        Else
            str_tmp = Microsoft.VisualBasic.Mid(str, start, len)
        End If
        str_tmp = Microsoft.VisualBasic.Trim(str_tmp)
        Return str_tmp
    End Function
    Private Function file_num(ByVal filename As String) As Int16
        Dim fname As String
        fname = System.IO.Path.GetFileName(filename).ToUpper
        If Microsoft.VisualBasic.Left(fname, 3) = "TRA" And Microsoft.VisualBasic.Right(fname, 8) = "_NEU.FIL" Then
            Return CInt(Microsoft.VisualBasic.Mid(fname, 4, 1))
        ElseIf Microsoft.VisualBasic.Left(fname, 8) = "TRA4.FIL" Then
            Return CInt(Microsoft.VisualBasic.Mid(fname, 4, 1))
        Else
            Return 0
        End If
    End Function
    Private Function SelectFile(ByVal files As ReadOnlyCollection(Of String), ByVal name As String) As String
        SelectFile = ""
        For Each f In files
            If System.IO.Path.GetFileName(f).ToUpper = name Then
                Return f
            End If
        Next
    End Function
    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Dim frm2 As New Form
        'frm2.Name = "Form2"
        screenFormat.Width = Screen.PrimaryScreen.WorkingArea.Width
        screenFormat.Height = Screen.PrimaryScreen.WorkingArea.Height

        'frm2.Name = "Карта раскроя"
        'frm2.Width = ScreenWidth
        'frm2.Height = ScreenHeight
        'frm2.ShowDialog()
        'frm2.Close()

        FolderPath = "C:\Rezka"
        Text_Path_Name.Text = FolderPath
        AppPath = My.Application.Info.DirectoryPath.ToString
        '
    End Sub
    Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Form2.TopMost = True 'ставим форму поверх "всего"
        Form2.Activate()  'На всякий случай активируем её.
        Form2.FormBorderStyle = FormBorderStyle.None
        Form2.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub CreateReport()
        Dim webPathExists As Boolean
        Dim imgPath As String
        Dim webPath As String
        Dim pt_tmp As System.Drawing.Point
        Dim pt2_tmp As System.Drawing.Point

        Dim sz_tmp As System.Drawing.Size
        webPath = FolderPath + "\" + selectedFolder + "\web"
        imgPath = webPath + "\img"
        webPathExists = My.Computer.FileSystem.DirectoryExists(imgPath)
        If webPathExists = True Then
            My.Computer.FileSystem.DeleteDirectory(webPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.CreateDirectory(webPath)
            My.Computer.FileSystem.CreateDirectory(imgPath)
        Else
            My.Computer.FileSystem.CreateDirectory(webPath)
            My.Computer.FileSystem.CreateDirectory(imgPath)
        End If
        For i = 0 To UBound(Portion, 1) 'Порция
            With Portion(i)
                For j = 0 To UBound(.glass, 1) 'Стекло
                    With .glass(j)
                        For n = 0 To .quPlate - 1 'Лист
                            coordPlate.X = .borders.left
                            coordPlate.Y = .borders.bottom
                            'Рисуем лист
                            pt.X = 0
                            pt.Y = 0
                            'Размеры листа
                            sz.Width = .plate(n).format.Width + .borders.left + .borders.right
                            sz.Height = .plate(n).format.Height + .borders.top + .borders.bottom
                            'Размеры облекаленного листа
                            szPlateWOBorgers.Width = .plate(n).format.Width
                            szPlateWOBorgers.Height = .plate(n).format.Height
                            sz2.Width = .plate(n).format.Width
                            sz2.Height = .plate(n).format.Height

                            'Calculate ratio
                            Dim ratio As Single
                            Dim sizeOut As Size 'Размеры выходного ихображения
                            Dim sizeNew As SizeF
                            Dim ratioWidth As Single
                            Dim ratioHeight As Single
                            sizeOut.Width = 2048
                            sizeOut.Height = 1280
                            ratioWidth = sizeOut.Width / sz.Width
                            ratioHeight = sizeOut.Height / sz.Height
                            sizeNew.Width = sz.Width * ratioHeight
                            sizeNew.Height = sz.Height * ratioWidth

                            If sizeNew.Width <= sizeOut.Width Then
                                ratio = ratioHeight
                            ElseIf sizeNew.Height <= sizeOut.Height Then
                                ratio = ratioWidth
                            End If

                            'If sz.Width >= sz.Height Then
                            '    If sz.Width * sizeOut.Height / sz.Height <= sizeOut.Width Then
                            '        ratio = sizeOut.Width / sz.Width
                            '    ElseIf sz.Height * sizeOut.Width / sz.Width <= sizeOut.Height Then
                            '        ratio = sizeOut.Height / sz.Height
                            '    End If
                            'Else
                            '    If sz.Width * sizeOut.Height / sz.Height <= sizeOut.Width Then
                            '        ratio = sizeOut.Width / sz.Width
                            '    ElseIf sz.Height * sizeOut.Width / sz.Width <= sizeOut.Height Then
                            '        ratio = sizeOut.Height / sz.Height
                            '    End If
                            '    ratio = 1 / ratio
                            'End If

                            'If sz.Height > sz.Width Then
                            '    ratio = sizeOut.Height / sz.Height
                            'Else
                            '    ratio = sizeOut.Width / sz.Width
                            'End If

                            'Создаем рисунок
                            Dim plateGraph As System.Drawing.Graphics
                            pict = New Bitmap(Convert.ToInt32(sizeOut.Width), Convert.ToInt32(sizeOut.Height), System.Drawing.Imaging.PixelFormat.Format16bppRgb555)

                            plateGraph = System.Drawing.Graphics.FromImage(pict)
                            plateGraph.Clear(System.Drawing.Color.Gray)

                            'Рисуем целый лист
                            'plateGraph = PlaceRectangle(plateGraph, pt, sz, ratio, colorRectPlate)

                            'Рисуем лист без кромок
                            'plateGraph = PlaceRectangle(plateGraph, coordPlate, sz2, ratio, colorRectPlateWithoutBorders)
                            With .plate(n)
                                coordSubPlate.X = coordPlate.X
                                coordSubPlate.Y = coordPlate.Y
                                For m = 0 To .quSubPlate - 1  'Субпластина
                                    With .subPlate(m)
                                        'Рисуем Субпластину
                                        sz_tmp.Width = .widthSubPlate
                                        sz_tmp.Height = .heightSubplate
                                        pt_tmp = TrfCoordRectangle(coordSubPlate, sz_tmp, sz)
                                        'plateGraph = PlaceRectangle(plateGraph, pt_tmp, sz_tmp, ratio, colorRectSubPlate)

                                        sz_tmp.Height = sz2.Height
                                        pt_tmp = TrfCoordRectangle(coordSubPlate, sz_tmp, sz)
                                        'plateGraph = PlaceRectangle(plateGraph, pt_tmp, sz_tmp, ratio, colorRectSubPlate)
                                        coordGroupDetail.X = coordSubPlate.X
                                        coordGroupDetail.Y = coordSubPlate.Y
                                        For p = 0 To .quGroupDetail - 1 'Группа деталей
                                            With .groupDetail(p)
                                                sz_tmp.Width = .widthGroup
                                                sz_tmp.Height = .heightGroup
                                                pt_tmp = TrfCoordRectangle(coordGroupDetail, sz_tmp, sz)
                                                'plateGraph = PlaceRectangle(plateGraph, pt_tmp, sz_tmp, ratio, colorRectDetail)
                                                For q = 0 To .quDetail - 1 'Деталь

                                                    'Рисуем Группу деталей
                                                    If .details(q).quVertical = 1 And .details(q).quHorisontal = 1 Then
                                                        sz_tmp.Width = .widthGroup
                                                        sz_tmp.Height = .heightGroup
                                                        pt_tmp = TrfCoordRectangle(coordGroupDetail, sz_tmp, sz)
                                                        'plateGraph = PlaceRectangle(plateGraph, pt_tmp, sz_tmp, ratio, colorRectDetail)
                                                        'plateGraph = PlaceMarking(plateGraph, pt_tmp, sz_tmp, ratio, .details(q).marking)
                                                    Else
                                                        With .details(q)
                                                            coordDetail.X = coordSubPlate.X
                                                            coordDetail.Y = coordSubPlate.Y
                                                            For r = 0 To .quHorisontal - 1
                                                                For s = 0 To .quVertical - 1
                                                                    sz_tmp.Width = .widthDetail
                                                                    sz_tmp.Height = .heightDetail
                                                                    pt_tmp = TrfCoordRectangle(coordDetail, sz_tmp, sz)
                                                                    'plateGraph = PlaceRectangle(plateGraph, pt_tmp, sz_tmp, ratio, colorRectDetail)
                                                                    'plateGraph = PlaceMarking(plateGraph, pt_tmp, sz_tmp, ratio, .marking)
                                                                    coordDetail.Y = coordDetail.Y + .heightDetail
                                                                Next s
                                                                coordDetail.X = coordDetail.X + .widthDetail
                                                            Next r
                                                        End With
                                                    End If
                                                Next q 'Деталь
                                                coordGroupDetail.Y = coordGroupDetail.Y + .heightGroup
                                            End With
                                        Next p 'Группа деталей
                                        coordSubPlate.X = coordSubPlate.X + .widthSubPlate
                                    End With
                                Next m 'Субпластина
                                coordSubPlate.X = coordPlate.X
                                coordSubPlate.Y = coordPlate.Y
                                For m = 0 To .quSubPlate - 1  'Субпластина
                                    With .subPlate(m)
                                        pt_tmp = TrfCoordPoint(coordSubPlate, sz)
                                        pt2_tmp.X = pt_tmp.X
                                        pt2_tmp.Y = pt_tmp.Y - sz2.Height
                                        'plateGraph = PlaceLine(plateGraph, pt_tmp, pt2_tmp, ratio, colorLineRed)
                                        coordGroupDetail.X = coordSubPlate.X
                                        coordGroupDetail.Y = coordSubPlate.Y
                                        For p = 0 To .quGroupDetail - 1 'Группа деталей
                                            'Рисуем Границу группы деталей
                                            coordGroupDetail.Y = coordGroupDetail.Y + .groupDetail(p).heightGroup
                                            pt_tmp = TrfCoordPoint(coordGroupDetail, sz)
                                            pt2_tmp.X = pt_tmp.X - .widthSubPlate
                                            pt2_tmp.Y = pt_tmp.Y '- sz2.Height
                                            'plateGraph = PlaceLine(plateGraph, pt_tmp, pt2_tmp, ratio, colorLineBlack)
                                        Next
                                        coordSubPlate.X = coordSubPlate.X + .widthSubPlate
                                    End With
                                Next m
                            End With
                            Dim bmpPath As String
                            bmpPath = imgPath + "\" + CStr(i) + "-" + CStr(j) + "-" + CStr(n) + ".png"
                            pict.Save(bmpPath, System.Drawing.Imaging.ImageFormat.Png)
                            plateGraph.Dispose()
                            pict.Dispose()
                        Next n 'Лист
                    End With
                Next j 'Стекло
            End With
        Next i 'Порция
    End Sub
    Private Sub FindFiles(ByVal foldPath As String)
        'Dim report As New Report(foldPath)
        Dim files As ReadOnlyCollection(Of String)
        Dim file As String
        Dim numPortion As Integer = 0
        Dim numGlass As Integer = 0
        Dim path_tmp As String
        path_tmp = FolderPath + "\" + foldPath
        Dim portions = From fold In Directory.EnumerateDirectories(path_tmp, "?", SearchOption.TopDirectoryOnly)
        For Each folder In portions
            numGlass = 0
            Dim number As Integer
            Dim result As Boolean = Int32.TryParse(My.Computer.FileSystem.GetName(folder), number)
            If result Then
                ReDim Preserve Portion(numPortion)
                ReDim Preserve prf(numPortion)
                With Portion(numPortion)
                    .numPortion = CInt(My.Computer.FileSystem.GetName(folder))
                    Dim glassesPath As String
                    glassesPath = path_tmp + "\" + .numPortion.ToString + "\1\"
                    Dim glasses = From fold2 In _
                                  Directory.EnumerateDirectories(glassesPath, "*", SearchOption.TopDirectoryOnly)
                    For Each glass In glasses
                        ReDim Preserve .glass(numGlass)
                        ReDim Preserve prf(numPortion).GlassInPrf(numGlass)
                        .glass(numGlass).glassName = My.Computer.FileSystem.GetName(glass)
                        files = My.Computer.FileSystem.GetFiles(glass, FileIO.SearchOption.SearchAllSubDirectories, "*.fil")
                        'Glak.fil
                        file = SelectFile(files, "GLAK.FIL")
                        ReadGlakFil(file, numPortion, numGlass)
                        'Tra1_neu.fil
                        file = SelectFile(files, "TRA1_NEU.FIL")
                        ReadTraFil(file, numPortion, numGlass)
                        'Tra2_neu.fil
                        file = SelectFile(files, "TRA2_NEU.FIL")
                        ReadTraFil(file, numPortion, numGlass)
                        'Tra3_neu.fil
                        file = SelectFile(files, "TRA3_NEU.FIL")
                        ReadTraFil(file, numPortion, numGlass)
                        'Tra4.fil
                        file = SelectFile(files, "TRA4.FIL")
                        ReadTraFil(file, numPortion, numGlass)
                        'Обработка optio.dat
                        files = My.Computer.FileSystem.GetFiles(glass, FileIO.SearchOption.SearchAllSubDirectories, "optio.dat")
                        file = SelectFile(files, "OPTIO.DAT")
                        'ReadOptioDat(file, numPortion, numGlass)
                        'обработка ANZ файлов
                        files = My.Computer.FileSystem.GetFiles(glass, FileIO.SearchOption.SearchAllSubDirectories, "*.anz")
                        For Each file In files
                            ReadAnz(file, numPortion, numGlass)
                        Next
                        numGlass = numGlass + 1
                    Next
                End With
            End If
            numPortion = numPortion + 1
        Next
    End Sub 'Выбираем файлы для дальнейшей обработки
    Private Sub ReadAnz(ByVal filename As String, ByVal numPortion As Integer, ByVal numGlass As Integer)
        Dim anz() As String = System.IO.File.ReadAllLines(filename)
        Dim i As Integer = 0
        With Portion(numPortion).glass(numGlass)
            ReDim .anzFile(i)
            .anzFile(i).filename = My.Computer.FileSystem.GetName(filename)
            ' .anzFile(i).filenum = Get_str_to_int(.anzFile(i).filename, 0, 6)
            With .anzFile(i)
                ReDim .anzLines(UBound(anz, 1))
                For j = 0 To UBound(anz, 1)
                    .anzLines(j) = anz(j)
                Next
            End With
        End With
    End Sub
    Private Sub ReadGlakFil(ByVal filename As String, ByVal numPortion As Integer, ByVal numGlass As Integer)
        Dim glakFilLines() As String = System.IO.File.ReadAllLines(filename)
        Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        With Portion(numPortion).glass(numGlass)
            '.glassName = Get_str(glakFilLines(0), 0, 16)
            .quDetails = Get_str_to_int(glakFilLines(0), 17, 3) - 1 'Количество деталей

            .borders.left = CByte(Get_str_to_int(glakFilLines(0), 182, 2))
            .borders.right = CByte(Get_str_to_int(glakFilLines(0), 186, 2))
            .borders.top = CByte(Get_str_to_int(glakFilLines(0), 190, 2))
            .borders.bottom = CByte(Get_str_to_int(glakFilLines(0), 194, 2))
            .squareDetail = CSng(Get_str_to_int(glakFilLines(4), 17, 8)) + CSng(Get_str_to_int(glakFilLines(4), 25, 8)) / 100
        End With
        'Форматы
        'Dim Formats As String 'Строка форматов
        Dim Qu As Int16
        'Formats = glakFilLines(3)
        For i = 0 To 9
            Qu = Get_str_to_int(glakFilLines(3), 81 + i * 4, 4)
            If Qu <> 0 Then
                For j = 0 To Qu - 1
                    ReDim Preserve formatsArray(i + j)
                    formatsArray(i + j).Width = Get_str_to_int(glakFilLines(3), 1 + i * 4, 4) 'width
                    formatsArray(i + j).Height = Get_str_to_int(glakFilLines(3), 41 + i * 4, 4) 'height
                Next j
            ElseIf Qu = 0 Then
            End If
        Next i
    End Sub 'Читаем в массив файл Glak
    Public Sub ReadTraFil(ByVal filename As String, ByVal numPortion As Integer, ByVal numGlass As Integer)
        Dim traFilLines() As String = System.IO.File.ReadAllLines(filename)
        With Portion(numPortion).glass(numGlass)
            Select Case file_num(filename)
                Case 1
                    .quSubplate = Get_str_to_int(traFilLines(0), 0, 4) 'Количество деталей
                    .quPlate = Get_str_to_int(traFilLines(0), 5, 4) 'Количество листов
                    .widthOst = Get_str_to_int(traFilLines(0), 13, 4) 'Ширина остатка на последнем листе
                    .heightOst = Get_str_to_int(traFilLines(0), 18, 4) 'Высота остатка на последнем листе
                    .squareDetail = Get_str_to_int(traFilLines(0), 23, 8) / 100000 'Площадь деталей
                    ReDim Preserve .plate(.quPlate - 1)
                    Dim i_tmp As Integer = .quPlate
                    For i = 1 To i_tmp
                        'If i = 0 Then Continue For
                        With .plate(i - 1)
                            .quSubPlate = Get_str_to_int(traFilLines(i), 0, 4)
                            .quCopyOfSubPlate = Get_str_to_int(traFilLines(i), 6, 3)
                            .format.Width = formatsArray(i - 1).Width
                            .format.Height = formatsArray(i - 1).Height
                            .widthOst = Get_str_to_int(traFilLines(i), 13, 5) / 10
                            ReDim Preserve .subIndex(.quSubPlate - 1)
                            Dim j_tmp As Integer = .quSubPlate - 1
                            For j = 1 To j_tmp
                                If j = 0 Then Continue For
                                .subIndex(j - 1) = Get_str_to_int(traFilLines(i), 18 + j * 10, 6)
                            Next j
                        End With
                    Next i
                Case 2
                    Dim numsubplate As Integer = 0
                    Dim i_tmp As Integer = .quPlate
                    For i = 1 To i_tmp
                        With .plate(i - 1)
                            ReDim Preserve .subPlate(.quSubPlate - 1)
                            Dim j_tmp As Integer = .quSubPlate
                            For j = 1 To j_tmp
                                With .subPlate(j - 1)
                                    .quGroupDetail = Get_str_to_int(traFilLines(numsubplate), 0, 4)
                                    .widthSubPlate = Get_str_to_int(traFilLines(numsubplate), 5, 4)
                                    .heightSubplate = Get_str_to_int(traFilLines(numsubplate), 10, 4)
                                    ReDim Preserve .groupDetail(.quGroupDetail - 1)
                                    ReDim Preserve .subIndex(.quGroupDetail - 1)
                                    Dim h_tmp As Integer = .quGroupDetail
                                    For h = 1 To h_tmp
                                        'If h = 0 Then Continue For
                                        .subIndex(h - 1) = Get_str_to_int(traFilLines(numsubplate), 15 + (h - 1) * 10, 6)
                                    Next h
                                End With
                                numsubplate = numsubplate + 1
                            Next
                        End With
                    Next
                Case 3
                    Dim numgroupdetail As Integer = 0
                    Dim i_tmp As Integer = .quPlate
                    For i = 1 To i_tmp ' Итератор Листов
                        'If i = 0 Then Continue For
                        With .plate(i - 1)
                            Dim j_tmp As Integer = .quSubPlate
                            For j = 1 To j_tmp 'Итератор Сублистов
                                'If j = 0 Then Continue For
                                With .subPlate(j - 1)
                                    Dim h_tmp As Integer = .quGroupDetail
                                    For h = 1 To h_tmp 'Итератор Групп деталей
                                        'If h = 0 Then Continue For
                                        With .groupDetail(h - 1)
                                            .quDetail = Get_str_to_int(traFilLines(numgroupdetail), 0, 4)
                                            .widthGroup = Get_str_to_int(traFilLines(numgroupdetail), 5, 4)
                                            .heightGroup = Get_str_to_int(traFilLines(numgroupdetail), 10, 4)
                                            ReDim Preserve .details(.quDetail - 1)
                                            Dim f_tmp As Integer = .quDetail
                                            For f = 1 To f_tmp
                                                ' If f = 0 Then Continue For
                                                With .details(f - 1)
                                                    .widthDetail = Get_str_to_int(traFilLines(numgroupdetail), 15 + (f - 1) * 27, 4)
                                                    .heightDetail = Get_str_to_int(traFilLines(numgroupdetail), 20 + (f - 1) * 27, 4)
                                                    .quVertical = Get_str_to_int(traFilLines(numgroupdetail), 25 + (f - 1) * 27, 4)
                                                    .quHorisontal = Get_str_to_int(traFilLines(numgroupdetail), 38 + (f - 1) * 27, 4)
                                                End With
                                            Next f
                                        End With
                                        numgroupdetail = numgroupdetail + 1
                                    Next h
                                End With
                            Next j
                        End With
                    Next i
                Case 4
                    Dim numdetail As Integer = 0 'Итератор Деталей
                    Dim markingLine As String
                    Dim i_tmp As Integer = .quPlate
                    For i = 1 To i_tmp ' Итератор Листов
                        'If i = 0 Then Continue For
                        With .plate(i - 1)
                            Dim j_tmp As Integer = .quSubPlate
                            For j = 1 To j_tmp 'Итератор Сублистов
                                'If j = 0 Then Continue For
                                markingLine = traFilLines(j - 1)
                                numdetail = 0
                                With .subPlate(j - 1)
                                    Dim h_tmp As Integer = .quGroupDetail
                                    For h = 1 To h_tmp 'Итератор Групп деталей
                                        'If h = 0 Then Continue For
                                        With .groupDetail(h - 1)
                                            Dim f_tmp As Integer = .quDetail
                                            For f = 1 To f_tmp
                                                'If f = 0 Then Continue For
                                                With .details(f - 1)
                                                    .marking = Get_str(markingLine, 5 + numdetail * 10, 10)
                                                    numdetail = numdetail + 1
                                                End With
                                            Next f
                                        End With
                                    Next h
                                End With
                            Next j
                        End With
                    Next i
            End Select
        End With
    End Sub 'Читаем в массивы файлы Tra
    'Private Function isHeadTag(ByVal str) As String
    '    isHeadTag = ""
    '    If str.StartsWith("---") And str.indexof("]") <> -1 Then
    '        isHeadTag = Mid(str, 4, Len(str) - 9).ToUpper
    '    End If
    'End Function
    'Private Function isTag(ByVal str) As String
    '    isTag = ""
    '    If str.StartsWith("---") And str.indexof("]") <> -1 Then
    '        isTag = Mid(str, 4, Len(str) - 9).ToUpper
    '    End If
    'End Function
    'Private Function getTag(ByVal str) As String
    '    getTag = Mid(str, 1, str.indexof("]"))
    'End Function
    'Private Function getHeadTag(ByVal str) As String
    '    getHeadTag = Microsoft.VisualBasic.Left(str, Len(str) - 6)
    '    getHeadTag = Microsoft.VisualBasic.Right(getHeadTag, Len(getHeadTag) - 3)
    '    'getHeadTag = Mid(str, 2, str.indexof("]"))
    'End Function
    'Private Function getValue(ByVal str) As String
    '    getValue = Microsoft.VisualBasic.Right(str, Len(str) - str.indexof("]") - 1)
    'End Function
    'Private Function getValueInt(ByVal str) As Integer
    '    Dim str_tmp As String
    '    str_tmp = Microsoft.VisualBasic.Right(str, Len(str) - str.indexof("]") - 2)
    '    If str_tmp.IndexOf(".") <> -1 Then
    '        str_tmp = Microsoft.VisualBasic.Left(str_tmp, str_tmp.IndexOf("."))
    '    End If
    '    getValueInt = Convert.ToInt32(str_tmp)
    'End Function

    'Public Sub getItemArray(ByVal split() As String, ByVal strt As Int32, ByVal numportion As Integer, ByVal glass As Integer)
    '    Dim iterator As Int32 = strt
    '    Dim str As String
    '    Dim itemIterator As Int32 = -1
    '    With prf(numportion).GlassInPrf(glass)
    '        While isTag(Split(iterator)) <> "GLASS_ARRAY)"
    '            iterator = iterator + 1
    '            str = getTag(split(iterator))
    '            If str = "REC#" Then
    '                itemIterator = itemIterator + 1
    '            End If
    '            ReDim Preserve .itemArray(itemIterator)
    '            With .itemArray(itemIterator)
    '                Select Case str
    '                    Case "REC#"
    '                        .REC = getValueInt(split(iterator))
    '                    Case "BOX#"
    '                        .BOX = getValueInt(split(iterator))
    '                    Case "ORDER@"
    '                        .ORDER = getValueInt(split(iterator))
    '                    Case "ITEM#"
    '                        .ITEM = getValueInt(split(iterator))
    '                    Case "OPT_GROUP#"
    '                        .OPT_GROUP = getValueInt(split(iterator))
    '                    Case "CODE@"
    '                        .CODE = getValue(split(iterator))
    '                    Case "WIDTH#."
    '                        .WIDTH = getValueInt(split(iterator))
    '                    Case "HEIGHT#."
    '                        .HEIGHT = getValueInt(split(iterator))
    '                    Case "UNIT_QTY#"
    '                        .UNIT_QTY = getValueInt(split(iterator))
    '                    Case "SHEET_QTY#"
    '                        .SHEET_QTY = getValueInt(split(iterator))
    '                    Case "*RACK@"
    '                        .RACK = getValue(split(iterator))
    '                    Case "SHAPE_FILE@"
    '                        .SHAPE_FILE = getValue(split(iterator))
    '                End Select
    '            End With
    '            'iterator = iterator + 1
    '        End While
    '    End With
    '    optioLine = iterator - 1
    'End Sub
    'Public Sub ReadOptioDat(ByVal file As String, ByVal numportion As Integer, ByVal numglass As Integer)
    '    Dim optlines As String = System.IO.File.ReadAllText(file)
    '    Dim tag As String = ""
    '    Dim split As String() = optlines.Split("[")
    '    optioLine = 0
    '    Dim maxLine As Int32 = UBound(split, 1)
    '    While optioLine < maxLine
    '        If isTag(split(optioLine)) <> "" Then

    '            Select Case getHeadTag(split(optioLine))
    '                Case "ITEM_ARRAY"
    '                    optiodatIndex.ITEM_ARRAY = optioLine
    '                    getItemArray(split, optioLine, numportion, numglass)
    '                Case "GLASS_ARRAY"
    '                    optiodatIndex.GLASS_ARRAY = optioLine
    '                Case "OPT_PARAMETER"
    '                    optiodatIndex.OPT_PARAMETER = optioLine
    '                Case "OPT_RESULT_HEADER"
    '                    optiodatIndex.OPT_RESULT_HEADER = optioLine
    '                Case "OPT_RESULT_STOCK_SHEET_ARRAY"
    '                    optiodatIndex.OPT_RESULT_STOCK_SHEET_ARRAY = optioLine
    '                Case "OPT_RESULT_X_AREA_ARRAY"
    '                    optiodatIndex.OPT_RESULT_X_AREA_ARRAY = optioLine
    '                Case "OPT_RESULT_Y_AREA_ARRAY"
    '                    optiodatIndex.OPT_RESULT_Y_AREA_ARRAY = optioLine
    '            End Select
    '        End If
    '        optioLine = optioLine + 1
    '    End While
    'Parsing GlassArray
    'For i = optiodatIndex.GLASS_ARRAY To optiodatIndex.OPT_PARAMETER - 1
    '    If getTag(split(i)) = "REC#" Then

    '    End If
    'Next
    ' End Sub

    'Public Sub ReadOptioDat(ByVal file As String, ByVal numportion As Integer, ByVal numglass As Integer)
    '    Dim optlines As String = System.IO.File.ReadAllText(file)
    '    Dim tag As String = ""
    '    Dim split As String() = optlines.Split("[")
    '    Dispose(optlines)
    '    Dim h_iterator As Int32 = -1 'счетчик заголовков
    '    Dim i_iterator As Int32 = 0 'счетчик записей
    '    Dim t_iterator As Int32 = 0 'счетчик тегов
    '    Dim str As String = ""
    '    'Dim i As Int32
    '    Dim maxLine As Int32 = UBound(split, 1)
    '    For h_iterator = 0 to 


    '        While h_iterator + i_iterator + t_iterator < maxLine
    '            h_iterator = h_iterator + 1
    '            If isHeadTag(split(h_iterator)) <> "" Then
    '                If getHeadTag(split(h_iterator)) = "ITEM_ARRAY" Then
    '                    While isHeadTag(split(h_iterator + 1)) <> "GLASS_ARRAY"
    '                        i_iterator = i_iterator + 1
    '                        If isHeadTag(split(h_iterator + i_iterator)) = "" Then
    '                        While 
    '                                str = split(h_iterator + i_iterator + t_iterator)
    '                                If getTag(str) = "REC#" Then
    '                                    i_iterator = i_iterator + 1
    '                                End If



    '                    End If

    '                        'ReDim Preserve .itemArray(itemIterator)
    '                        'With .itemArray(itemIterator)
    '                        '    Select Case str()
    '                        '        Case "REC#"
    '                        '            .REC = getValueInt(split(iterator))
    '                        '        Case "BOX#"
    '                        '            .BOX = getValueInt(split(iterator))
    '                        '        Case "ORDER@"
    '                        '            .ORDER = getValueInt(split(iterator))
    '                        '        Case "ITEM#"
    '                        '            .ITEM = getValueInt(split(iterator))
    '                        '        Case "OPT_GROUP#"
    '                        '            .OPT_GROUP = getValueInt(split(iterator))
    '                        '        Case "CODE@"
    '                        '            .CODE = getValue(split(iterator))
    '                        '        Case "WIDTH#."
    '                        '            .WIDTH = getValueInt(split(iterator))
    '                        '        Case "HEIGHT#."
    '                        '            .HEIGHT = getValueInt(split(iterator))
    '                        '        Case "UNIT_QTY#"
    '                        '            .UNIT_QTY = getValueInt(split(iterator))
    '                        '        Case "SHEET_QTY#"
    '                        '            .SHEET_QTY = getValueInt(split(iterator))
    '                        '        Case "*RACK@"
    '                        '            .RACK = getValue(split(iterator))
    '                        '        Case "SHAPE_FILE@"
    '                        '            .SHAPE_FILE = getValue(split(iterator))
    '                        '    End Select
    '                        'End With
    '                    End While
    '                End If
    '            End If
    '        End While
    '                    End If


    'End Sub

    'Private Function parseTag(ByVal optiodatlines() As String, ByVal strtLine As Int32, ByVal tag As String) As String
    '    Dim str_tmp As String
    '    For i = strtLine To UBound(optiodatlines, 1)
    '        If optiodatlines(i) = tag Then


    '        End If
    '    Next
    'End Function

    Private Sub Button_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Exit.Click
        Application.Exit()
    End Sub 'Выход
    Private Sub Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse.Click
        FolderPath = "C:\Rezka"
        Text_Path_Name.Text = FolderPath
        Dim folders = From fold In _
                Directory.EnumerateDirectories(FolderPath, "Прф *", SearchOption.TopDirectoryOnly)
        Dim i = 0
        For Each folder In folders
            ListView1.Items.Add(My.Computer.FileSystem.GetName(folder))
            ReDim Preserve foldersArray(i)
            foldersArray(i) = folder
            i = i + 1
        Next
        ListView1.Sort()
    End Sub
    Private Sub Text_Prf_Name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_Prf_Name.TextChanged

    End Sub
    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        selectedFolder = ""
        If ListView1.SelectedItems.Count > 0 Then
            selectedFolder = ListView1.SelectedItems(0).Text
            Report.Enabled = True
        Else
            Report.Enabled = False
        End If
    End Sub
    Private Sub Report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Report.Click
        If selectedFolder.Length > 0 Then
            FindFiles(selectedFolder)
            CreateReport()
            CreateDocument()
            Form2.ShowDialog()
            Report.Enabled = False
        End If
    End Sub
    Dim doc = New Document()
    Public Function CreateDocument() As Document
        ' Create a new MigraDoc document
        doc.Info.Title = "Glass Cutting Report"
        doc.Info.Subject = "Report of glass cutting"
        doc.Info.Author = "Nikolay Davydov"
        DefineStyles()
        CreatePage()
        Return Me.doc
    End Function
    Public Sub DefineStyles()
        ' Get the predefined style Normal.
        Dim style As Style = doc.Styles("Normal")
        ' Because all styles are derived from Normal, the next line changes the 
        ' font of the whole document. Or, more exactly, it changes the font of
        ' all styles and paragraphs that do not redefine the font.
        style.Font.Name = "Verdana"

        style = doc.Styles(StyleNames.Header)
        style.ParagraphFormat.AddTabStop("16cm", MigraDoc.DocumentObjectModel.TabAlignment.Right)

        style = doc.Styles(StyleNames.Footer)
        style.ParagraphFormat.AddTabStop("8cm", MigraDoc.DocumentObjectModel.TabAlignment.Center)

        ' Create a new 
        style = doc.styles.addstyle("Header", "Normal")
        style.Font.Name = "Times New Roman"
        style.Font.Size = 32
        style.Font.Bold = True


        ' Create a new style called Table based on style Normal
        style = doc.Styles.AddStyle("Table", "Normal")
        style.Font.Name = "Verdana"
        style.Font.Name = "Times New Roman"
        style.Font.Size = 9

        ' Create a new style called Reference based on style Normal
        style = Me.doc.Styles.AddStyle("Reference", "Normal")
        style.ParagraphFormat.SpaceBefore = "5mm"
        style.ParagraphFormat.SpaceAfter = "5mm"
        style.ParagraphFormat.TabStops.AddTabStop("16cm", MigraDoc.DocumentObjectModel.TabAlignment.Right)
    End Sub
    Public Sub CreatePage()
        ' Each MigraDoc document needs at least one section.
        Dim section As Section = doc.AddSection()
        section.PageSetup.PageFormat = PageFormat.A4
        section.PageSetup.Orientation = DocumentObjectModel.Orientation.Landscape
        section.PageSetup.BottomMargin = 10 'нижний отступ
        section.PageSetup.TopMargin = 10 ' верхний отступ
        section.PageSetup.LeftMargin = 10
        section.PageSetup.RightMargin = 10
        Dim paragraph As Paragraph = section.AddParagraph()

        'Пишем заголовок
        paragraph = section.AddParagraph()
        paragraph.Format.Alignment = ParagraphAlignment.Center
        'paragraph.Format.SpaceBefore = "8cm"
        paragraph.Style = "Reference"
        paragraph.AddFormattedText("Раскрой стекла " & selectedFolder, TextFormat.Bold)
        Dim table As Table = section.AddTable()
        table.Style = "Table"
        table.Borders.Color = MigraDoc.DocumentObjectModel.Colors.Black
        table.Borders.Width = 0.25
        table.Borders.Left.Width = 0.5
        table.Borders.Right.Width = 0.5
        table.Rows.LeftIndent = 0

        ' Before you can add a row, you must define the columns
        Dim column As Column = table.AddColumn("1.63cm")
        column.Format.Alignment = ParagraphAlignment.Center
        column = table.AddColumn("7.96cm")
        column.Format.Alignment = ParagraphAlignment.Left
        For i = 1 To 8
            column = table.AddColumn("2.26cm")
            column.Format.Alignment = ParagraphAlignment.Right
        Next
        Dim row As Row = table.AddRow()
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Shading.Color = MigraDoc.DocumentObjectModel.Color.Empty
        For i = 0 To UBound(columnName, 1)
            row.Cells(i).AddParagraph(columnName(i))
            'row.Cells(i).Format.Font.Bold = False
            row.Cells(i).Format.Alignment = MigraDoc.DocumentObjectModel.ParagraphAlignment.Center
            row.Cells(i).VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Bottom
        Next
        Dim i_tmp As Integer = UBound(Portion, 1)
        Dim sPlate As Single = 0
        Dim widthPlate, heightPlate As Integer
        For i = 0 To i_tmp 'обходим порции
            'row = table.AddRow()
            With Portion(i)
                Dim j_tmp As Integer = UBound(.glass, 1)
                For j = 0 To j_tmp  'обходим стекло
                    row = table.AddRow()
                    If j = 0 Then
                        row.Cells(0).MergeDown = j_tmp
                        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
                        row.Cells(0).VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center
                        row.Cells(0).AddParagraph(i + 1) 'Номер порции
                    End If
                    With .glass(j)
                        row.Cells(1).AddParagraph(.glassName) 'Материал
                        Dim n_tmp As Integer = UBound(.plate, 1)
                        sPlate = 0
                        For n = 0 To n_tmp
                            widthPlate = .plate(n).format.Width + .borders.right + IIf(.plate(n).widthOst = 0, .borders.left, (-1) * .plate(n).widthOst)
                            heightPlate = .plate(n).format.Height + .borders.top + .borders.bottom
                            sPlate = sPlate + widthPlate * heightPlate / 1000000
                        Next n
                        row.Cells(2).AddParagraph(Format(sPlate, "f")) 'Площадь листов
                        row.Cells(3).AddParagraph(.quPlate) 'Количество листов
                        row.Cells(4).AddParagraph(.quDetails) 'Количество деталей
                        row.Cells(5).AddParagraph(Format(.squareDetail, "f")) 'Площадь деталей
                        row.Cells(6).AddParagraph("0") 'Пока ставим ноль, возможно в дальнейшем доработаю
                        row.Cells(7).AddParagraph("") 'Количество остатков
                        row.Cells(8).AddParagraph("") 'Площадь остатков
                        row.Cells(9).AddParagraph(Format(((sPlate / .squareDetail) - 1), "p")) 'Процент отхода
                    End With
                Next
            End With
        Next
        Dim portion_tmp As Integer = UBound(Portion, 1)
        For i = 0 To portion_tmp
            With Portion(i)
                Dim glass_tmp As Integer = UBound(.glass, 1)
                For j = 0 To glass_tmp
                    With .glass(j)
                        Dim plate_tmp As Integer = UBound(.plate, 1)
                        For k = 0 To plate_tmp
                            section = doc.AddSection()
                            paragraph = section.AddParagraph()
                            paragraph.Format.Alignment = ParagraphAlignment.Justify
                            'paragraph.Format.Font = MigraDoc.DocumentObjectModel.Font
                            paragraph.Format.Font.Size = 26
                            paragraph.AddFormattedText("Портфель № " & selectedFolder, "Header")
                            paragraph.AddFormattedText(vbTab & "Порция " & i + 1, "Header")
                            paragraph.AddFormattedText(vbTab & "Стекло " & Portion(i).glass(j).glassName, "Header")
                            paragraph.AddFormattedText(vbTab & "Лист " & k + 1, "Header")
                            Dim imgpath As String
                            imgpath = FolderPath + "\" + selectedFolder + "\web\img"
                            paragraph = section.AddParagraph()
                            Dim imgName As String
                            imgName = imgpath + "\" + CStr(i) + "-" + CStr(j) + "-" + CStr(k) + ".png"

                            'Dim image2 As MigraDoc.DocumentObjectModel.Shapes.Image = paragraph.AddImage(imgName)
                            Dim image As MigraDoc.DocumentObjectModel.Shapes.Image = paragraph.AddImage(imgName)
                            image.Width = "29cm"
                            'image.Height = "13.4cm"
                            image.LockAspectRatio = True
                            image.RelativeVertical = RelativeVertical.Line
                            image.RelativeHorizontal = RelativeHorizontal.Margin
                            image.Top = ShapePosition.Top
                            image.Left = ShapePosition.Left
                            image.WrapFormat.Style = WrapStyle.TopBottom
                        Next k
                    End With
                Next j
            End With
        Next i


        'Form2.Preview.
        Form2.Preview.Ddl = DdlWriter.WriteToString(doc)
    End Sub
    'Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

    '    ' Convert the input string to a byte array and compute the hash.
    '    Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

    '    ' Create a new Stringbuilder to collect the bytes
    '    ' and create a string.
    '    Dim sBuilder As New StringBuilder()

    '    ' Loop through each byte of the hashed data 
    '    ' and format each one as a hexadecimal string.
    '    Dim i As Integer
    '    For i = 0 To data.Length - 1
    '        sBuilder.Append(data(i).ToString("x2"))
    '    Next i

    '    ' Return the hexadecimal string.
    '    Return sBuilder.ToString()

    'End Function

    'Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
    '    ' Hash the input.
    '    Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

    '    ' Create a StringComparer an compare the hashes.
    '    Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

    '    If 0 = comparer.Compare(hashOfInput, hash) Then
    '        Return True
    '    Else
    '        Return False
    '    End If

    'End Function
End Class
