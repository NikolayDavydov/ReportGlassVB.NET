<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pgDown = New System.Windows.Forms.Button()
        Me.Menu2 = New System.Windows.Forms.Button()
        Me.Close2 = New System.Windows.Forms.Button()
        Me.pgUp = New System.Windows.Forms.Button()
        Me.Preview = New MigraDoc.Rendering.Forms.DocumentPreview()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.pgDown, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Menu2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Close2, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pgUp, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Preview, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.VScrollBar1, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ProgressBar1, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1178, 659)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pgDown
        '
        Me.pgDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pgDown.Location = New System.Drawing.Point(717, 3)
        Me.pgDown.Name = "pgDown"
        Me.pgDown.Size = New System.Drawing.Size(216, 64)
        Me.pgDown.TabIndex = 9
        Me.pgDown.Text = "PgDOWN"
        Me.pgDown.UseVisualStyleBackColor = True
        '
        'Menu2
        '
        Me.Menu2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Menu2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Menu2.Location = New System.Drawing.Point(3, 3)
        Me.Menu2.Name = "Menu2"
        Me.Menu2.Size = New System.Drawing.Size(216, 64)
        Me.Menu2.TabIndex = 5
        Me.Menu2.Text = "Меню"
        Me.Menu2.UseVisualStyleBackColor = True
        '
        'Close2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Close2, 2)
        Me.Close2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Close2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close2.Location = New System.Drawing.Point(939, 3)
        Me.Close2.Name = "Close2"
        Me.Close2.Size = New System.Drawing.Size(236, 64)
        Me.Close2.TabIndex = 6
        Me.Close2.Text = "Закрыть"
        Me.Close2.UseVisualStyleBackColor = True
        '
        'pgUp
        '
        Me.pgUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pgUp.Location = New System.Drawing.Point(225, 3)
        Me.pgUp.Name = "pgUp"
        Me.pgUp.Size = New System.Drawing.Size(216, 64)
        Me.pgUp.TabIndex = 8
        Me.pgUp.Text = "PgUP"
        Me.pgUp.UseVisualStyleBackColor = True
        '
        'Preview
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Preview, 5)
        Me.Preview.Ddl = Nothing
        Me.Preview.DesktopColor = System.Drawing.SystemColors.ControlDark
        Me.Preview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Preview.Document = Nothing
        Me.Preview.Location = New System.Drawing.Point(3, 73)
        Me.Preview.Name = "Preview"
        Me.Preview.Page = 0
        Me.Preview.PageColor = System.Drawing.Color.GhostWhite
        Me.Preview.PageSize = New System.Drawing.Size(595, 842)
        Me.Preview.PrivateFonts = Nothing
        Me.Preview.ShowScrollbars = False
        Me.Preview.Size = New System.Drawing.Size(1152, 583)
        Me.Preview.TabIndex = 10
        Me.Preview.TabStop = False
        Me.Preview.ZoomPercent = 51
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VScrollBar1.Location = New System.Drawing.Point(1158, 70)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(20, 589)
        Me.VScrollBar1.TabIndex = 11
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBar1.Location = New System.Drawing.Point(447, 3)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(264, 64)
        Me.ProgressBar1.TabIndex = 12
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1178, 659)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.KeyPreview = True
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Menu2 As System.Windows.Forms.Button
    Friend WithEvents Close2 As System.Windows.Forms.Button
    Friend WithEvents pgDown As System.Windows.Forms.Button
    Friend WithEvents pgUp As System.Windows.Forms.Button
    Friend WithEvents Preview As MigraDoc.Rendering.Forms.DocumentPreview
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
