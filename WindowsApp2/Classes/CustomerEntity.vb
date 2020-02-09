Imports System.Data.Entity

Namespace Classes
    ''' <summary>
    ''' Custom view of customer including property to know
    ''' state of customer.
    ''' </summary>
    Public Class CustomerEntity
        Public Property CustomerIdentifier() As Integer
        Public Property CompanyName() As String
        Public Property FirstName() As String
        Public Property LastName As String
        Public Property CountryName() As String
        Public Property ContactId As Integer
        Public Property CountryIdentifier As Integer
        ''' <summary>
        ''' State of customer e.g. modified, deleted etc
        ''' </summary>
        ''' <returns></returns>
        Public Property EntityState() As EntityState
    End Class
End Namespace