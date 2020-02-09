Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq.Expressions
Imports WindowsApp2.Classes

Partial Public Class Customer
    <NotMapped>
    Public Property FirstName As String
    <NotMapped>
    Public Property LastName As String
    Public Shared ReadOnly Property Projection() As Expression(Of Func(Of Customer, CustomerEntity))

        Get
            Return Function(customer) New CustomerEntity() With {
                .CustomerIdentifier = customer.CustomerIdentifier,
                .CompanyName = customer.CompanyName,
                .CountryName = customer.Country.Name,
                .FirstName = customer.Contact.FirstName,
                .LastName = customer.Contact.LastName,
                .ContactId = CInt(customer.ContactId),
                .CountryIdentifier = customer.CountryIdentifier}
        End Get

    End Property

End Class