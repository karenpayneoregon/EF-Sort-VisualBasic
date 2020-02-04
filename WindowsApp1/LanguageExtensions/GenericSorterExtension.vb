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

    End Module
End Namespace