Imports System.Runtime.CompilerServices
Imports WindowsApp2.Classes
Imports Equin.ApplicationFramework

Public Module BindingSourceExtensions
    <Extension>
    Public Function CurrentCustomerEntity(ByVal sender As BindingSource) As CustomerEntity
        Return DirectCast(sender.Current, ObjectView(Of CustomerEntity)).Object
    End Function

End Module
