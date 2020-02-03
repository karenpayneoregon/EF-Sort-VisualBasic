Namespace Classes
    Public Class TableInformation
        ''' <summary>
        ''' Table name from model
        ''' </summary>
        Public Property TableName() As String
        Public Property Columns() As List(Of String)
        Public Property EntityColumnList() As List(Of EntityColumn)
        Public Property PrimaryKeyList() As List(Of String)
        Public Overrides Function ToString() As String
            Return TableName
        End Function
    End Class
End Namespace