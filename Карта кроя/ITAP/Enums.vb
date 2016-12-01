Namespace ITAP.Components.Enums
    Public Class EnumHelper
        ' Methods
        Shared Sub New()
        Public Sub New()
        Public Shared Function GetColorValue(ByVal value As Enum) As Color
        Public Shared Function GetStringValue(ByVal value As Enum) As String
        Public Shared Function IsStringDefined(ByVal enumType As Type, ByVal stringValue As String) As Boolean
        Public Shared Function IsStringDefined(ByVal enumType As Type, ByVal stringValue As String, ByVal ignoreCase As Boolean) As Boolean
        Public Shared Function Parse(ByVal type As Type, ByVal stringValue As String) As Object
        Public Shared Function Parse(ByVal type As Type, ByVal stringValue As String, ByVal ignoreCase As Boolean) As Object

            ' Fields
            Private Shared _colorsValues As Hashtable
            Private Shared _stringValues As Hashtable
    End Class

    Public Enum LogImage
        ' Fields
        Alert = 3
        [Default] = 0
        Empty = -1
        Info = 2
        Save = 1
    End Enum

    Public Enum SelectFormType
        ' Fields
        MultiRecord = 0
        MultiRecordAndCount = 3
        None = 2
        OnlyRecord = 1
    End Enum

    Public Enum SortOrder
        ' Fields
        Ascending = 1
        Descending = 2
        Unspecified = 0
    End Enum
End Namespace


Collapse Types

