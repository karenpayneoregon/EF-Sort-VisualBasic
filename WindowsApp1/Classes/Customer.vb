Imports System.Linq.Expressions

''' <summary>
''' Default view for presenting data
''' </summary>
''' <remarks>
''' Important, how things are setup calling context.Customers.ToList
''' will fail as FirstName and LastName are not part of the model.
''' </remarks>
Partial Public Class Customer
    Public Property FirstName As String
    Public Property LastName As String

    Public Shared ReadOnly Property Projection() As Expression(Of Func(Of Customer, CustomerItem))

        Get
            Return Function(customer) New CustomerItem() With {
                .CustomerIdentifier = customer.CustomerIdentifier,
                .CompanyName = customer.CompanyName,
                .CountryName = customer.Country.Name,
                .FirstName = customer.Contact.FirstName,
                .LastName = customer.Contact.LastName}
        End Get

    End Property
End Class
