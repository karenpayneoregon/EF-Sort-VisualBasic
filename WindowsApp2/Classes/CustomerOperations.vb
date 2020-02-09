Imports System.Data.Entity

Namespace Classes

    Public Class CustomerOperations
        ''' <summary>
        ''' Unlike many examples which will do using someContext we
        ''' need access to the DbContext which will be covered in
        ''' an upcoming next step to save data back to the database.
        ''' </summary>
        ''' <returns></returns>
        Public Property Context() As NorthWindAzureContext
        Public Sub New()
            Context = New NorthWindAzureContext()
        End Sub
        ''' <summary>
        ''' Read view/projection asynchronously, note the use
        ''' of inner ToListAsync which on larger operations can
        ''' accept a cancellation token yet there are less than
        ''' 90 records here so no need for a token.
        ''' </summary>
        ''' <returns></returns>
        Public Async Function ReadAsync() As Task(Of List(Of CustomerEntity))

            Return Await Task.Run(
                Async Function()
                    Dim customerItemsList As List(Of CustomerEntity) =
                            Await Context.Customers.Select(Customer.Projection).ToListAsync()
                    Return customerItemsList.OrderBy(Function(customer) customer.CompanyName).ToList()
                End Function)

        End Function
    End Class
End Namespace