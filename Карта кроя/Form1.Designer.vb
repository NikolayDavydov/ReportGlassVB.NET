<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim folder As System.Windows.Forms.ColumnHeader
        Me.Text_Path_Name = New System.Windows.Forms.TextBox()
        Me.Browse = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Text_Prf_Name = New System.Windows.Forms.TextBox()
        Me.Report = New System.Windows.Forms.Button()
        Me.Button_1 = New System.Windows.Forms.Button()
        Me.Button_2 = New System.Windows.Forms.Button()
        Me.Button_3 = New System.Windows.Forms.Button()
        Me.Button_6 = New System.Windows.Forms.Button()
        Me.Button_5 = New System.Windows.Forms.Button()
        Me.Button_4 = New System.Windows.Forms.Button()
        Me.Button_9 = New System.Windows.Forms.Button()
        Me.Button_8 = New System.Windows.Forms.Button()
        Me.Button_7 = New System.Windows.Forms.Button()
        Me.Button_0 = New System.Windows.Forms.Button()
        Me.Button_del = New System.Windows.Forms.Button()
        Me.Button_Exit = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DataSet1 = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.DataTable3 = New System.Data.DataTable()
        Me.DataTable4 = New System.Data.DataTable()
        Me.DataTable5 = New System.Data.DataTable()
        Me.DataTable6 = New System.Data.DataTable()
        Me.DataTable7 = New System.Data.DataTable()
        folder = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'folder
        '
        folder.Text = "Портфель"
        folder.Width = 445
        '
        'Text_Path_Name
        '
        Me.Text_Path_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Text_Path_Name.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Text_Path_Name.Location = New System.Drawing.Point(13, 13)
        Me.Text_Path_Name.Name = "Text_Path_Name"
        Me.Text_Path_Name.ReadOnly = True
        Me.Text_Path_Name.Size = New System.Drawing.Size(522, 41)
        Me.Text_Path_Name.TabIndex = 0
        Me.Text_Path_Name.Text = "Папка"
        '
        'Browse
        '
        Me.Browse.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Browse.Location = New System.Drawing.Point(542, 13)
        Me.Browse.Name = "Browse"
        Me.Browse.Size = New System.Drawing.Size(145, 41)
        Me.Browse.TabIndex = 1
        Me.Browse.Text = "Папка"
        Me.Browse.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {folder})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(13, 136)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(445, 416)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Text_Prf_Name
        '
        Me.Text_Prf_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Prf_Name.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Text_Prf_Name.Location = New System.Drawing.Point(12, 60)
        Me.Text_Prf_Name.Name = "Text_Prf_Name"
        Me.Text_Prf_Name.Size = New System.Drawing.Size(447, 71)
        Me.Text_Prf_Name.TabIndex = 3
        Me.Text_Prf_Name.Text = "Потфель"
        Me.Text_Prf_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Report
        '
        Me.Report.Enabled = False
        Me.Report.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Report.Location = New System.Drawing.Point(466, 364)
        Me.Report.Name = "Report"
        Me.Report.Size = New System.Drawing.Size(222, 70)
        Me.Report.TabIndex = 4
        Me.Report.Text = "Отчет"
        Me.Report.UseVisualStyleBackColor = True
        '
        'Button_1
        '
        Me.Button_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button_1.Location = New System.Drawing.Point(466, 60)
        Me.Button_1.Name = "Button_1"
        Me.Button_1.Size = New System.Drawing.Size(70, 70)
        Me.Button_1.TabIndex = 5
        Me.Button_1.Text = "1"
        Me.Button_1.UseVisualStyleBackColor = True
        '
        'Button_2
        '
        Me.Button_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button_2.Location = New System.Drawing.Point(542, 60)
        Me.Button_2.Name = "Button_2"
        Me.Button_2.Size = New System.Drawing.Size(70, 70)
        Me.Button_2.TabIndex = 6
        Me.Button_2.Text = "2"
        Me.Button_2.UseVisualStyleBackColor = True
        '
        'Button_3
        '
        Me.Button_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button_3.Location = New System.Drawing.Point(618, 60)
        Me.Button_3.Name = "Button_3"
        Me.Button_3.Size = New System.Drawing.Size(70, 70)
        Me.Button_3.TabIndex = 7
        Me.Button_3.Text = "3"
        Me.Button_3.UseVisualStyleBackColor = True
        '
        'Button_6
        '
        Me.Button_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button_6.Location = New System.Drawing.Point(618, 136)
        Me.Button_6.Name = "Button_6"
        Me.Button_6.Size = New System.Drawing.Size(70, 70)
        Me.Button_6.TabIndex = 10
        Me.Button_6.Text = "6"
        Me.Button_6.UseVisualStyleBackColor = True
        '
        'Button_5
        '
        Me.Button_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button_5.Location = New System.Drawing.Point(542, 136)
        Me.Button_5.Name = "Button_5"
        Me.Button_5.Size = New System.Drawing.Size(70, 70)
        Me.Button_5.TabIndex = 9
        Me.Button_5.Text = "5"
        Me.Button_5.UseVisualStyleBackColor = True
        '
        'Button_4
        '
        Me.Button_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button_4.Location = New System.Drawing.Point(466, 136)
        Me.Button_4.Name = "Button_4"
        Me.Button_4.Size = New System.Drawing.Size(70, 70)
        Me.Button_4.TabIndex = 8
        Me.Button_4.Text = "4"
        Me.Button_4.UseVisualStyleBackColor = True
        '
        'Button_9
        '
        Me.Button_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button_9.Location = New System.Drawing.Point(618, 212)
        Me.Button_9.Name = "Button_9"
        Me.Button_9.Size = New System.Drawing.Size(70, 70)
        Me.Button_9.TabIndex = 13
        Me.Button_9.Text = "9"
        Me.Button_9.UseVisualStyleBackColor = True
        '
        'Button_8
        '
        Me.Button_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button_8.Location = New System.Drawing.Point(542, 212)
        Me.Button_8.Name = "Button_8"
        Me.Button_8.Size = New System.Drawing.Size(70, 70)
        Me.Button_8.TabIndex = 12
        Me.Button_8.Text = "8"
        Me.Button_8.UseVisualStyleBackColor = True
        '
        'Button_7
        '
        Me.Button_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button_7.Location = New System.Drawing.Point(466, 212)
        Me.Button_7.Name = "Button_7"
        Me.Button_7.Size = New System.Drawing.Size(70, 70)
        Me.Button_7.TabIndex = 11
        Me.Button_7.Text = "7"
        Me.Button_7.UseVisualStyleBackColor = True
        '
        'Button_0
        '
        Me.Button_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button_0.Location = New System.Drawing.Point(466, 288)
        Me.Button_0.Name = "Button_0"
        Me.Button_0.Size = New System.Drawing.Size(146, 70)
        Me.Button_0.TabIndex = 14
        Me.Button_0.Text = "0"
        Me.Button_0.UseVisualStyleBackColor = True
        '
        'Button_del
        '
        Me.Button_del.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button_del.Location = New System.Drawing.Point(618, 288)
        Me.Button_del.Name = "Button_del"
        Me.Button_del.Size = New System.Drawing.Size(70, 70)
        Me.Button_del.TabIndex = 15
        Me.Button_del.Text = "<="
        Me.Button_del.UseVisualStyleBackColor = True
        '
        'Button_Exit
        '
        Me.Button_Exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button_Exit.Location = New System.Drawing.Point(465, 482)
        Me.Button_Exit.Name = "Button_Exit"
        Me.Button_Exit.Size = New System.Drawing.Size(222, 70)
        Me.Button_Exit.TabIndex = 18
        Me.Button_Exit.Text = "Выход"
        Me.Button_Exit.UseVisualStyleBackColor = True
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.SelectedPath = Global.Report.My.MySettings.Default.FolderPath
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        Me.FolderBrowserDialog1.Tag = ""
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "PortionDataSet"
        Me.DataSet1.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1, Me.DataTable2, Me.DataTable3, Me.DataTable4, Me.DataTable5, Me.DataTable6, Me.DataTable7})
        '
        'DataTable1
        '
        Me.DataTable1.TableName = "ITEM_ARRAY"
        '
        'DataTable2
        '
        Me.DataTable2.TableName = "GLASS_ARRAY"
        '
        'DataTable3
        '
        Me.DataTable3.TableName = "OPT_PARAMETER"
        '
        'DataTable4
        '
        Me.DataTable4.TableName = "OPT_RESULT_HEADER"
        '
        'DataTable5
        '
        Me.DataTable5.TableName = "OPT_RESULT_STOCK_SHEET_ARRAY"
        '
        'DataTable6
        '
        Me.DataTable6.TableName = "OPT_RESULT_X_AREA_ARRAY"
        '
        'DataTable7
        '
        Me.DataTable7.TableName = "OPT_RESULT_Y_AREA_ARRAY"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 564)
        Me.Controls.Add(Me.Button_Exit)
        Me.Controls.Add(Me.Button_del)
        Me.Controls.Add(Me.Button_0)
        Me.Controls.Add(Me.Button_9)
        Me.Controls.Add(Me.Button_8)
        Me.Controls.Add(Me.Button_7)
        Me.Controls.Add(Me.Button_6)
        Me.Controls.Add(Me.Button_5)
        Me.Controls.Add(Me.Button_4)
        Me.Controls.Add(Me.Button_3)
        Me.Controls.Add(Me.Button_2)
        Me.Controls.Add(Me.Button_1)
        Me.Controls.Add(Me.Report)
        Me.Controls.Add(Me.Text_Prf_Name)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Browse)
        Me.Controls.Add(Me.Text_Path_Name)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Text_Path_Name As System.Windows.Forms.TextBox
    Friend WithEvents Browse As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Text_Prf_Name As System.Windows.Forms.TextBox
    Friend WithEvents Report As System.Windows.Forms.Button
    Friend WithEvents Button_1 As System.Windows.Forms.Button
    Friend WithEvents Button_2 As System.Windows.Forms.Button
    Friend WithEvents Button_3 As System.Windows.Forms.Button
    Friend WithEvents Button_6 As System.Windows.Forms.Button
    Friend WithEvents Button_5 As System.Windows.Forms.Button
    Friend WithEvents Button_4 As System.Windows.Forms.Button
    Friend WithEvents Button_9 As System.Windows.Forms.Button
    Friend WithEvents Button_8 As System.Windows.Forms.Button
    Friend WithEvents Button_7 As System.Windows.Forms.Button
    Friend WithEvents Button_0 As System.Windows.Forms.Button
    Friend WithEvents Button_del As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button_Exit As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DataSet1 As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents DataTable2 As System.Data.DataTable
    Friend WithEvents DataTable3 As System.Data.DataTable
    Friend WithEvents DataTable4 As System.Data.DataTable
    Friend WithEvents DataTable5 As System.Data.DataTable
    Friend WithEvents DataTable6 As System.Data.DataTable
    Friend WithEvents DataTable7 As System.Data.DataTable

End Class
