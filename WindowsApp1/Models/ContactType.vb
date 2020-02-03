Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("ContactType")>
Partial Public Class ContactType
    Public Sub New()
        Customers = New HashSet(Of Customer)()
    End Sub

    <Key>
    Public Property ContactTypeIdentifier As Integer

    Public Property ContactTitle As String

    Public Overridable Property Customers As ICollection(Of Customer)
End Class
