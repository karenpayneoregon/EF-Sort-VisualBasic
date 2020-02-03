Public Class EntityColumn
    Public Property Name() As String
    Public Property Type() As Type
    Public Property TypeName() As String
    Public Property Key() As Boolean

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class