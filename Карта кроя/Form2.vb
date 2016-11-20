Public Class Form2

    Public Property keyUpDown As Integer = 0 ' 1-up, 2-down, 0-none
    Public Property keyP As Boolean = False

    Public Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.pgDown.Select()
    End Sub

    Private Sub Close2_Click(sender As Object, e As EventArgs) Handles Close2.Click
        Me.Close()
    End Sub
    Private Sub pgDown_Click(sender As Object, e As EventArgs) Handles pgDown.Click
        Me.Preview.NextPage()
    End Sub
    Private Sub pgUp_Click(sender As Object, e As EventArgs) Handles pgUp.Click
        Me.Preview.PrevPage()
    End Sub
    Private Sub Mouse_Wheel(sender As Object, e As EventArgs) Handles Preview.MouseWheel

    End Sub

    Private Sub Preview_KeyDown(sender As Object, e As KeyEventArgs) Handles Preview.KeyDown, MyBase.KeyDown, Me.KeyDown
        If e.KeyCode = Keys.Up Then
            keyUpDown = 1
            keyP = True
        ElseIf e.KeyCode = Keys.Down Or e.KeyCode = Keys.Space Then
            keyUpDown = 2
            keyP = True
        End If
    End Sub
    Private Sub Preview_KeyUp(sender As Object, e As KeyEventArgs) Handles Preview.KeyUp, MyBase.KeyUp, Me.KeyUp
        If keyP Then
            If keyUpDown = 1 Then
                Me.Preview.PrevPage()
                keyP = False
                keyUpDown = 0
            ElseIf keyUpDown = 2 Then
                Me.Preview.NextPage()
                keyP = False
                keyUpDown = 0
            End If
        End If
    End Sub



End Class