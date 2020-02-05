Imports System.Reflection
Imports WindowsApp1.LanguageExtensions
Imports EntityFrameworkHelper
Imports EntityFrameworkHelper.Classes

Namespace Classes
    Public Class Operations

        ''' <summary>
        ''' Sort on a specific property Ascending as default, pass SortDirection.Descending
        ''' for descending sort.
        ''' </summary>
        ''' <param name="propertyName">Property name to sort</param>
        ''' <param name="SortDirection">Direction of sort</param>
        ''' <returns></returns>
        Public Async Function CustomerSort(
           propertyName As String,
           Optional SortDirection As SortDirection = SortDirection.Ascending) As Task(Of List(Of CustomerItem))

            Using context = New NorthWindAzureContext()
                Return Await Task.Run(
                    Function()
                        Return context.Customers.
                                         Select(Customer.Projection).
                                         ToList().
                                         Sort(propertyName, SortDirection)
                    End Function)
            End Using

        End Function
        ''' <summary>
        ''' Perform order by with two columns same direction for sort
        ''' </summary>
        ''' <param name="propertyName"></param>
        ''' <param name="SortDirection"></param>
        ''' <returns></returns>
        Public Async Function CustomerSortTwoProperties(
            propertyName As String(),
            Optional SortDirection As SortDirection = SortDirection.Descending) As Task(Of List(Of CustomerItem))

            Using context = New NorthWindAzureContext()
                Return Await Task.Run(
                    Function()
                        Return context.Customers.
                                         Select(Customer.Projection).
                                         SortMultiColumn(propertyName, SortDirection).ToList()
                    End Function)
            End Using

        End Function
        ''' <summary>
        ''' Provides an example on how to custom order by, in this case
        ''' a check for company name that starts with specific text, if present
        ''' they are at the top of the order while the remaining values follow.
        ''' </summary>
        ''' <returns></returns>
        Public Async Function DemonstrationCustomOrdering() As Task(Of List(Of CustomerItem))

            Using context = New NorthWindAzureContext()

                Return Await Task.Run(
                    Function()
                        Dim customerItemsList As List(Of CustomerItem) =
                                context.Customers.Select(Customer.Projection).ToList()
                        Return customerItemsList.OrderBy(
                            Function(customer) customer.CompanyName, New SpecificOrdering).ToList()
                    End Function)

            End Using

        End Function
        ''' <summary>
        ''' Conventional order by using strong type property name, not a string
        ''' </summary>
        ''' <returns></returns>
        Public Async Function ConventionalOrderBy() As Task(Of List(Of CustomerItem))

            Using context = New NorthWindAzureContext()

                Return Await Task.Run(
                    Function()
                        Dim customerItemsList As List(Of CustomerItem) =
                                context.Customers.Select(Customer.Projection).ToList()
                        Return customerItemsList.OrderBy(
                            Function(customer) customer.CompanyName).ToList()
                    End Function)

            End Using

        End Function
        ''' <summary>
        ''' Get names of properties for CustomerItem which over
        ''' time CustomerItem have have properties added or removed
        ''' so this handles any changes rather than hard coded properties
        ''' or property name changes.
        ''' </summary>
        ''' <returns></returns>
        Public Function CustomerItemPropertyNames() As List(Of String)
            Dim list As New List(Of String)

            Dim customerItemType As Type = GetType(CustomerItem)

            For Each propertyInfo As PropertyInfo In
                customerItemType.GetProperties(BindingFlags.Instance Or
                                               BindingFlags.Public Or BindingFlags.NonPublic)

                list.Add(propertyInfo.Name.SplitCamelCase())

            Next

            Return list

        End Function

        ''' <summary>
        ''' Get information about tables in the entity model
        ''' </summary>
        ''' <returns></returns>
        Public Async Function DatabaseTableInformation() As Task(Of List(Of TableInformation))

            Dim entityCrawler = New EntityCrawler() With {
                    .AssembleName = Assembly.GetExecutingAssembly().GetName().Name,
                    .ContextName = "NorthWindAzureContext"}

            Await Task.Run(Sub() entityCrawler.GetInformation())

            Return entityCrawler.TableInformation

        End Function
    End Class
End Namespace