Imports System.Reflection
Imports EntityFrameworkHelper
Imports EntityFrameworkHelper.Classes

Public Class Operations
    Public Async Function DatabaseTableInformation() As Task(Of List(Of TableInformation))

        Dim entityCrawler = New EntityCrawler() With {
                .AssembleName = Assembly.GetExecutingAssembly().GetName().Name,
                .TypeName = "NorthWindAzureContext"}

        Await Task.Run(Sub() entityCrawler.GetInformation())

        Return entityCrawler.TableInformation

    End Function
    Public Async Function CustomerSort1(propertyName As String, Optional SortDirection As SortDirection = SortDirection.Ascending) As Task(Of List(Of CustomerItem))
        Using context = New NorthWindAzureContext()
            Return Await Task.Run(Function() context.Customers.
                                     Select(Customer.Projection).
                                     ToList().
                                     Sort(propertyName, SortDirection))
        End Using
    End Function
    Public Function CustomerItemPropertyNames() As List(Of String)
        Dim list As New List(Of String)

        Dim customerItemType As Type = GetType(CustomerItem)

        For Each pi As PropertyInfo In customerItemType.GetProperties(BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
            list.Add(pi.Name.SplitCamelCase())
        Next

        Return list

    End Function
End Class
