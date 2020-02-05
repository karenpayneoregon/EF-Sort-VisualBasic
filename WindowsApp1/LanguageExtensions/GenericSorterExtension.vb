Imports System.Linq.Expressions
Imports System.Runtime.CompilerServices

Namespace LanguageExtensions

    Public Module GenericSorterExtension
        ''' <summary>
        ''' Specifies the sort direction against a property
        ''' </summary>
        Public Enum SortDirection
            ''' <summary>
            ''' Sort ascending.
            ''' </summary>
            Ascending
            ''' <summary>
            ''' Sort descending.
            ''' </summary>
            Descending
        End Enum


        <Extension>
        Public Function Sort(Of T)(list As List(Of T), propertyName As String, sortDirection As SortDirection) As List(Of T)

            Dim param As ParameterExpression = Expression.Parameter(GetType(T), "item")

            Dim sortExpression As Expression(Of Func(Of T, Object)) = Expression.Lambda(Of Func(Of T, Object))(
                Expression.Convert(
                    Expression.Property(param, propertyName), GetType(Object)), param)

            Select Case sortDirection
                Case SortDirection.Ascending
                    list = list.AsQueryable().OrderBy(sortExpression).ToList()
                Case Else
                    list = list.AsQueryable().OrderByDescending(sortExpression).ToList()
            End Select

            Return list

        End Function
        <Extension>
        Public Function SortMultiColumn(Of T)(source As IQueryable(Of T),
            propertyNames() As String, sortOrder As SortDirection) As IOrderedQueryable(Of T)

            If propertyNames.Length = 0 Then
                Throw New InvalidOperationException()
            End If

            Dim param = Expression.Parameter(GetType(T), String.Empty)
            Dim expressionPropField = Expression.PropertyOrField(param, propertyNames(0))

            Dim sortExpression = Expression.Lambda(expressionPropField, param)

            Dim orderByCall As MethodCallExpression = Expression.Call(GetType(Queryable), "OrderBy" &
                ((If(sortOrder = SortDirection.Descending, "Descending", String.Empty))),
                    {GetType(T), expressionPropField.Type},
                        source.Expression, Expression.Quote(sortExpression))

            If propertyNames.Length > 1 Then
                For index As Integer = 1 To propertyNames.Length - 1
                    Dim item = propertyNames(index)
                    param = Expression.Parameter(GetType(T), String.Empty)
                    expressionPropField = Expression.PropertyOrField(param, item)

                    sortExpression = Expression.Lambda(expressionPropField, param)

                    orderByCall = Expression.Call(GetType(Queryable), "ThenBy" &
                        ((If(sortOrder = SortDirection.Descending, "Descending", String.Empty))),
                            {GetType(T), expressionPropField.Type},
                                orderByCall, Expression.Quote(sortExpression))
                Next
            End If


            Return DirectCast(source.Provider.CreateQuery(Of T)(orderByCall), IOrderedQueryable(Of T))

        End Function

    End Module
End Namespace