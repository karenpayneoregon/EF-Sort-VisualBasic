Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Country
    Public Sub New()
        Customers = New HashSet(Of Customer)()
        Suppliers = New HashSet(Of Supplier)()
    End Sub

    <Key>
    Public Property CountryIdentifier As Integer

    Public Property Name As String

    Public Overridable Property Customers As ICollection(Of Customer)

    Public Overridable Property Suppliers As ICollection(Of Supplier)
End Class
