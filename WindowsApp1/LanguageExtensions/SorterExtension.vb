Imports System.Runtime.CompilerServices

Namespace LanguageExtensions 

    Module SorterExtension
        ''' <summary>
        ''' Sort by predicate which uses hard wired property names
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="sequence"></param>
        ''' <param name="predicate"></param>
        ''' <returns></returns>
        <Extension>
        Public Function OrderFirst(Of T)(sequence As IEnumerable(Of T), predicate As Func(Of T, Boolean)) As IEnumerable(Of T)
            Return sequence.OrderByDescending(predicate)
        End Function
        ''' <summary>
        ''' Sort by predicate which uses hard wired property names
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="sequence"></param>
        ''' <param name="predicate"></param>
        ''' <returns></returns>
        <Extension>
        Public Function OrderLast(Of T)(sequence As IEnumerable(Of T), predicate As Func(Of T, Boolean)) As IEnumerable(Of T)
            Return sequence.OrderBy(predicate)
        End Function
    End Module
End Namespace