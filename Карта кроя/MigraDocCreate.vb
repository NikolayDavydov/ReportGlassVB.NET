Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.Rendering
Imports PdfSharp
Imports Report.Report
Imports Report.Form1
Imports Report.GLASS_FOLDER

Public Class MigraDocCreate
    Public doc = New Document()


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
    Private Function CreateFirstPage(ByVal _doc As Document) As Document
        Dim doc As Document
        doc = _doc
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
        paragraph.AddFormattedText("Раскрой стекла " & Form1.selectedFolder, TextFormat.Bold)
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
        Dim i_tmp As Integer = UBound(PORTION, 1)
        Dim sPlate As Single = 0
        Dim widthPlate, heightPlate As Integer
        For i = 0 To i_tmp 'обходим порции
            'row = table.AddRow()
            With PORTION(i)
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
        Dim portion_tmp As Integer = UBound(PORTION, 1)
        For i = 0 To portion_tmp
            With PORTION(i)
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
                            paragraph.AddFormattedText(vbTab & "Стекло " & PORTION(i).glass(j).glassName, "Header")
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
    End Function
End Class
