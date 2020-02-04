Namespace Classes
    Public Class SpecificOrdering
        Inherits OrderedPredicateComparer(Of String)

        Private Shared ReadOnly Order() As Func(Of String, Boolean) = {
            Function(x) x.StartsWith("Bon"), Function(x) x.StartsWith("Cac"), Function(x) x.StartsWith("Du")}

        Public Sub New()
            MyBase.New(Order)
        End Sub
    End Class
End Namespace