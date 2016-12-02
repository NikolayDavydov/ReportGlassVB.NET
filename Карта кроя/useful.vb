'Imports Microsoft.JScript
'Imports Microsoft.JScript.Vsa
'Imports System
'Imports System.Collections.Generic
'Imports System.Globalization
'Imports System.IO
'Imports System.Reflection
'Imports System.Runtime.CompilerServices
'Imports System.Runtime.InteropServices
'Imports System.Text
'Imports System.Windows.Forms

'Namespace ITAP.Components
'    Public Class Useful
'        ' Methods
'        Public Shared Function BeginMonth(ByVal dt As DateTime) As DateTime
'            Dim date As DateTime = dt.Date
'            Return [date].AddDays(CDbl((-[date].Day + 1)))
'        End Function

'        Public Shared Function BeginYear(ByVal dt As DateTime) As DateTime
'            Dim date As DateTime = dt.Date
'            [date] = [date].AddDays(CDbl((-[date].Day + 1)))
'            Return [date].AddMonths((-[date].Month + 1))
'        End Function

'        Public Shared Function CheckDirectX() As Boolean
'            Try
'                Dim assembly As Assembly = Assembly.Load(New AssemblyName("Microsoft.DirectX"))
'                If ([assembly] Is Nothing) Then
'                    Throw New Exception
'                End If
'                If ([assembly].FullName <> "Microsoft.DirectX, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35") Then
'                    Throw New Exception
'                End If
'            Catch exception As Exception
'                MessageBox.Show(("Íå óñòàíîâëåí managed directx MSG:" & exception.Message & "Exeption:" & exception.StackTrace))
'                Return False
'            End Try
'            Return True
'        End Function

'        Public Shared Sub CopyStream(ByVal From As Stream, ByVal [To] As Stream)
'            Dim num As Integer
'            Dim buffer As Byte() = New Byte(&H400 - 1) {}
'            Do While (num = From.Read(buffer, 0, &H400) > 0)
'                [To].Write(buffer, 0, num)
'            Loop
'        End Sub

'        Public Shared Function CreateDirectory(ByVal currentDir As String, ByVal newSubDir As String) As String
'            newSubDir = Useful.NormalizeFileName(newSubDir)
'            Dim path As String = (currentDir & "\" & newSubDir)
'            If Not Directory.Exists(path) Then
'                Directory.CreateDirectory(path)
'            End If
'            Return path
'        End Function

'        Public Shared Sub DateNoramalize(ByRef d1 As DateTime, ByRef d2 As DateTime)
'            d1 = d1.Date
'            d2 = d2.Date.AddDays(1).AddSeconds(-1)
'        End Sub

'        Public Shared Function DecimalNoramalize(ByVal source As String) As String
'            source = source.Replace(",", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
'            source = source.Replace(".", Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
'            Return source
'        End Function

'        Public Shared Function EndMonth(ByVal dt As DateTime) As DateTime
'            Dim date As DateTime = dt.Date
'            Dim introduced2 As Integer = DateTime.DaysInMonth([date].Year, [date].Month)
'            Return [date].AddDays(CDbl((introduced2 - [date].Day)))
'        End Function

'        Public Shared Function EndYear(ByVal dt As DateTime) As DateTime
'            Dim date As DateTime = dt.Date
'            [date] = [date].AddMonths((12 - [date].Month))
'            Return [date].AddDays(CDbl((&H1F - [date].Day)))
'        End Function

'        Public Shared Function FindButton(ByVal parent As Control, ByVal [Text] As String) As Control
'            If (TypeOf parent Is Button AndAlso (parent.Text = [Text])) Then
'                Return parent
'            End If
'            Dim control As Control
'            For Each control In parent.Controls
'                Dim control2 As Control = Useful.FindButton(control, [Text])
'                If (Not control2 Is Nothing) Then
'                    Return control2
'                End If
'            Next
'            Return Nothing
'        End Function

'        Public Shared Function FindInStr(ByVal Destanation As String, ByVal StringForFind As String, ByVal Separator As Char) As Boolean
'            If (Destanation = StringForFind) Then
'                Return True
'            End If
'            Dim strArray As String() = Destanation.Split(New Char() {Separator})
'            Dim str As String
'            For Each str In strArray
'                If (str.Trim = StringForFind.Trim) Then
'                    Return True
'                End If
'            Next
'            Return False
'        End Function

'        Public Shared Function GetBoolean(ByVal value As Object) As Boolean
'            Try
'                Return (((Not value Is DBNull.Value) AndAlso (Not value Is Nothing)) AndAlso Convert.ToBoolean(value))
'            Catch obj1 As Object
'                Return False
'            End Try
'        End Function

'        Public Shared Function GetDateTime(ByVal value As Object) As DateTime
'            Try
'                If ((Not value Is DBNull.Value) AndAlso (Not value Is Nothing)) Then
'                    Return Convert.ToDateTime(value)
'                End If
'                Return DateTime.MinValue
'            Catch obj1 As Object
'                Return DateTime.MinValue
'            End Try
'        End Function

'        Public Shared Function GetDecimal(ByVal value As Object) As Decimal
'            Try
'                If ((Not value Is DBNull.Value) AndAlso (Not value Is Nothing)) Then
'                    Return Convert.ToDecimal(Useful.DecimalNoramalize(value.ToString))
'                End If
'                Return 0
'            Catch obj1 As Object
'                Return 0
'            End Try
'        End Function

'        Public Shared Function GetDecimalList(ByVal str As String, ByVal separator As Char) As List(Of Decimal)
'            str = str.Replace("(", "")
'            str = str.Replace(")", "")
'            Dim list As New List(Of Decimal)
'            If (str <> String.Empty) Then
'                Dim strArray As String() = str.Split(New Char() {separator})
'                Dim str2 As String
'                For Each str2 In strArray
'                    list.Add(Convert.ToDecimal(str2))
'                Next
'            End If
'            Return list
'        End Function

'        Public Shared Function GetDouble(ByVal value As Object) As Double
'            Try
'                If ((Not value Is DBNull.Value) AndAlso (Not value Is Nothing)) Then
'                    Return Convert.ToDouble(Useful.DecimalNoramalize(value.ToString))
'                End If
'                Return 0
'            Catch obj1 As Object
'                Return 0
'            End Try
'        End Function

'        Public Shared Function getGuidFromAssemply(ByVal assemblyComp As Assembly) As Guid
'            Dim customAttributes As Object() = assemblyComp.GetCustomAttributes(GetType(GuidAttribute), False)
'            If (customAttributes.Length <> 0) Then
'                Return New Guid(TryCast(customAttributes(0), GuidAttribute).Value)
'            End If
'            Return Guid.Empty
'        End Function

'        Public Shared Function GetInt32(ByVal value As Object) As Integer
'            Try
'                If ((Not value Is DBNull.Value) AndAlso (Not value Is Nothing)) Then
'                    Return Convert.ToInt32(value)
'                End If
'                Return 0
'            Catch obj1 As Object
'                Return 0
'            End Try
'        End Function

'        Public Shared Function GetIntList(ByVal str As String) As List(Of Integer)
'            str = str.Replace("(", "")
'            str = str.Replace(")", "")
'            Dim list As New List(Of Integer)
'            If (str <> String.Empty) Then
'                Dim strArray As String() = str.Split(New Char() {","c})
'                Dim str2 As String
'                For Each str2 In strArray
'                    list.Add(Convert.ToInt32(str2))
'                Next
'            End If
'            Return list
'        End Function

'        Public Shared Function GetIntList(ByVal str As String, ByVal separator As Char) As List(Of Integer)
'            str = str.Replace("(", "")
'            str = str.Replace(")", "")
'            Dim list As New List(Of Integer)
'            If (str <> String.Empty) Then
'                Dim strArray As String() = str.Split(New Char() {separator})
'                Dim str2 As String
'                For Each str2 In strArray
'                    list.Add(Convert.ToInt32(str2))
'                Next
'            End If
'            Return list
'        End Function

'        Public Shared Function GetLetterByIndex(ByVal index As Integer) As String
'            Dim strArray As String() = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
'            Dim str As String = strArray((index Mod strArray.Length))
'            Do While ((index / strArray.Length) > 0)
'                index = ((index / strArray.Length) - 1)
'                str = (strArray((index Mod strArray.Length)) & str)
'            Loop
'            Return str
'        End Function

'        Public Shared Function GetString(ByVal list As List(Of Decimal)) As String
'            Dim builder As New StringBuilder
'            Dim num As Decimal
'            For Each num In list
'                If (builder.Length <> 0) Then
'                    builder.Append(",")
'                End If
'                builder.Append(num)
'            Next
'            Return builder.ToString
'        End Function

'        Public Shared Function GetString(ByVal list As List(Of Integer)) As String
'            Dim builder As New StringBuilder
'            Dim num As Integer
'            For Each num In list
'                If (builder.Length <> 0) Then
'                    builder.Append(",")
'                End If
'                builder.Append(num)
'            Next
'            Return builder.ToString
'        End Function

'        Public Shared Function GetString(ByVal list As List(Of String)) As String
'            Dim builder As New StringBuilder
'            Dim str As String
'            For Each str In list
'                If (builder.Length <> 0) Then
'                    builder.Append(",")
'                End If
'                builder.Append(str)
'            Next
'            Return builder.ToString
'        End Function

'        Public Shared Function GetString(ByVal value As Object) As String
'            Try
'                If ((Not value Is DBNull.Value) AndAlso (Not value Is Nothing)) Then
'                    Return Convert.ToString(value)
'                End If
'                Return ""
'            Catch obj1 As Object
'                Return ""
'            End Try
'        End Function

'        Public Shared Function GetString(ByVal list As List(Of Decimal), ByVal separator As Char) As String
'            Dim builder As New StringBuilder
'            Dim num As Decimal
'            For Each num In list
'                If (builder.Length <> 0) Then
'                    builder.Append(separator)
'                End If
'                builder.Append(num)
'            Next
'            Return builder.ToString
'        End Function

'        Public Shared Function GetString(ByVal list As List(Of Integer), ByVal separator As Char) As String
'            Dim builder As New StringBuilder
'            Dim num As Integer
'            For Each num In list
'                If (builder.Length <> 0) Then
'                    builder.Append(separator)
'                End If
'                builder.Append(num)
'            Next
'            Return builder.ToString
'        End Function

'        Public Shared Function GetString(ByVal list As List(Of String), ByVal separator As Char) As String
'            Dim builder As New StringBuilder
'            Dim str As String
'            For Each str In list
'                If (builder.Length <> 0) Then
'                    builder.Append(separator)
'                End If
'                builder.Append(str)
'            Next
'            Return builder.ToString
'        End Function

'        Public Shared Function GetString(ByVal Source As String, ByVal Separator As String, ByVal n As Integer) As String
'            Source = (Source & Separator)
'            Dim str As String = ""
'            Dim num As Integer = 0
'            Dim i As Integer
'            For i = 0 To Source.Length - 1
'                Dim str2 As String = Source.Substring(i, 1)
'                If (str2 = Separator) Then
'                    num += 1
'                    If (num = n) Then
'                        Return str.Trim
'                    End If
'                    str = ""
'                Else
'                    str = (str & str2)
'                End If
'            Next i
'            Return str.Trim
'        End Function

'        Public Shared Function GetStringList(ByVal str As String) As List(Of String)
'            str = str.Replace("(", "")
'            str = str.Replace(")", "")
'            Dim list As New List(Of String)
'            If (str <> String.Empty) Then
'                Dim strArray As String() = str.Split(New Char() {","c})
'                Dim str2 As String
'                For Each str2 In strArray
'                    list.Add(str2)
'                Next
'            End If
'            Return list
'        End Function

'        Public Shared Function GetStringList(ByVal str As String, ByVal separator As Char) As List(Of String)
'            str = str.Replace("(", "")
'            str = str.Replace(")", "")
'            Dim list As New List(Of String)
'            If (str <> String.Empty) Then
'                Dim strArray As String() = str.Split(New Char() {separator})
'                Dim str2 As String
'                For Each str2 In strArray
'                    list.Add(str2)
'                Next
'            End If
'            Return list
'        End Function

'        Public Shared Function getVersionFromAssemply(ByVal assemblyComp As Assembly) As String
'            Dim customAttributes As Object() = assemblyComp.GetCustomAttributes(GetType(AssemblyFileVersionAttribute), False)
'            If (customAttributes.Length <> 0) Then
'                Return TryCast(customAttributes(0), AssemblyFileVersionAttribute).Version
'            End If
'            Return String.Empty
'        End Function

'        Public Shared Function NormalizeFileName(ByVal source As String) As String
'            Dim str As String = source
'            Dim invalidFileNameChars As Char() = Path.GetInvalidFileNameChars
'            Dim ch As Char
'            For Each ch In invalidFileNameChars
'                str = str.Replace(ch, " "c)
'            Next
'            Return str
'        End Function

'        Public Shared Function Parce(ByVal expression As String) As Double
'            Try
'                Dim numberFormat As NumberFormatInfo = CultureInfo.CurrentCulture.NumberFormat
'                expression = expression.Replace(",", numberFormat.NumberDecimalSeparator)
'                expression = expression.Replace(".", numberFormat.NumberDecimalSeparator)
'                Return Convert.ToDouble(expression)
'            Catch exception1 As Exception
'            End Try
'            expression = expression.Replace(",", ".")
'            expression = expression.Replace("{", "")
'            expression = expression.Replace("}", "")
'            Try
'                Dim engine As VsaEngine = VsaEngine.CreateEngine
'                Return Convert.ToDouble(Eval.JScriptEvaluate(expression, engine))
'            Catch exception As JScriptException
'                MessageBox.Show(("Îøèáêà ïðåîáðàçîâàíèÿ! " & expression & " " & exception.Message), "Îøèáêà", MessageBoxButtons.OK, MessageBoxIcon.Hand)
'                Return -1
'            End Try
'        End Function

'        Public Shared Function ReplaceList(ByVal source As List(Of Integer), ByVal sheme As Dictionary(Of Integer, Integer)) As List(Of Integer)
'            Dim list As New List(Of Integer)
'            Dim num As Integer
'            For Each num In source
'                If sheme.ContainsKey(num) Then
'                    list.Add(sheme.Item(num))
'                End If
'            Next
'            Return list
'        End Function

'        Public Shared Function Round(ByVal value As Decimal, ByVal digits As Integer, ByVal roundType As RoundType) As Decimal
'            Return Useful.Round(value, digits, CInt(roundType))
'        End Function

'        Public Shared Function Round(ByVal value As Decimal, ByVal digits As Integer, ByVal variant As Integer) As Decimal
'            Dim num As Decimal = CDec(Math.Pow(10, CDbl(digits)))
'            Dim d As Decimal = (value * num)
'            Dim num3 As Decimal = (d - Math.Truncate(d))
'            If (num3 = 0) Then
'                Return value
'            End If
'            Dim flag As Boolean = False
'            If (num3 < 0.5) Then
'                flag = (value >= 0)
'            ElseIf (num3 > 0.5) Then
'                flag = (value < 0)
'            ElseIf (num3 = 0.5) Then
'                flag = (variant <> 0)
'            End If
'            If flag Then
'                Return (Math.Truncate(d) / num)
'            End If
'            Return (Math.Truncate(Decimal.op_Increment(d)) / num)
'        End Function

'        Public Shared Function Round(ByVal value As Double, ByVal digits As Integer, ByVal roundType As RoundType) As Double
'            Return Useful.Round(value, digits, CInt(roundType))
'        End Function

'        Public Shared Function Round(ByVal value As Double, ByVal digits As Integer, ByVal variant As Integer) As Double
'            Dim num As Double = Math.Pow(10, CDbl(digits))
'            Dim d As Double = (value * num)
'            Dim num3 As Double = (d - Math.Truncate(d))
'            If (num3 = 0) Then
'                Return value
'            End If
'            Dim flag As Boolean = False
'            If (num3 < 0.5) Then
'                flag = (value >= 0)
'            ElseIf (num3 > 0.5) Then
'                flag = (value < 0)
'            ElseIf (num3 = 0.5) Then
'                flag = (variant <> 0)
'            End If
'            If flag Then
'                Return (Math.Truncate(d) / num)
'            End If
'            Return (Math.Truncate(CDbl((d + 1))) / num)
'        End Function

'        Public Shared Function SetDisabledControlFromForm(ByVal form As Form) As List(Of Control)
'            Dim list As New List(Of Control)
'            Dim control As Control
'            For Each control In form.Controls
'                If control.Enabled Then
'                    list.Add(control)
'                    control.Enabled = False
'                End If
'            Next
'            Return list
'        End Function

'        Public Shared Sub SetEnabledControlFromForm(ByVal form As Form, ByVal list As List(Of Control))
'            Dim control As Control
'            For Each control In form.Controls
'                If list.Contains(control) Then
'                    control.Enabled = True
'                End If
'            Next
'        End Sub

'        Public Shared Function SetHiddenControlFromForm(ByVal form As Form) As List(Of Control)
'            Dim list As New List(Of Control)
'            Dim control As Control
'            For Each control In form.Controls
'                If control.Visible Then
'                    list.Add(control)
'                    control.Visible = False
'                End If
'            Next
'            Return list
'        End Function

'        Public Shared Sub SetShowControlFromForm(ByVal form As Form, ByVal list As List(Of Control))
'            Dim control As Control
'            For Each control In form.Controls
'                If list.Contains(control) Then
'                    control.Visible = True
'                End If
'            Next
'        End Sub


'        ' Nested Types
'        Public Delegate Function GetTableName(ByVal caption As String) As String

'        Public Enum RoundType
'            ' Fields
'            Ceiling = 0
'            Floor = 1
'        End Enum
'    End Class
'End Namespace
