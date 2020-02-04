Namespace Classes
    Public Class OrderedPredicateComparer(Of T)
        Implements IComparer(Of T)

        Private ReadOnly _ordinals() As Func(Of T, Boolean)
        Public Sub New(predicates As IEnumerable(Of Func(Of T, Boolean)))
            _ordinals = predicates.ToArray()
        End Sub

        Public Function Compare(item1 As T, item2 As T) As Integer Implements IComparer(Of T).Compare
            Return GetOrdinal(item1) - GetOrdinal(item2)
        End Function

        Private Function GetOrdinal(item As T) As Integer
            For index As Integer = 0 To _ordinals.Length - 1
                If _ordinals(index)(item) Then
                    Return index - _ordinals.Length
                End If
            Next index
            Return 0
        End Function
    End Class
End NameSpace