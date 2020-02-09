Imports System.Data.Entity

Namespace Classes

    Public Class CustomerOperations
        Public Property Context() As NorthWindAzureContext
        Public Sub New()
            Context = New NorthWindAzureContext()
        End Sub
        Public Async Function ReadAsync() As Task(Of List(Of CustomerEntity))

            Return Await Task.Run(
                Function()
                    Dim customerItemsList As List(Of CustomerEntity) = Context.Customers.Select(Customer.Projection).ToList()
                    Return customerItemsList.OrderBy(Function(customer) customer.CompanyName).ToList()
                End Function)
        End Function
    End Class
End Namespace