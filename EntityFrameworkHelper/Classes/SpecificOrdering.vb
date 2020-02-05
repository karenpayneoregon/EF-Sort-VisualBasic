Namespace Classes
    Public Class SpecificOrdering
        Inherits OrderedPredicateComparer(Of String)

        Private Shared ReadOnly Order() As Func(Of String, Boolean) = {
            Function(value) value.StartsWith("Bon"),
            Function(item) item.StartsWith("Cac"),
            Function(item) item.StartsWith("Du")}

        Public Sub New()
            MyBase.New(Order)
        End Sub
    End Class
End Namespace