Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Country
    Public Sub New()
        Customers = New HashSet(Of Customer)()
    End Sub

    <Key>
    Public Property CountryIdentifier As Integer

    Public Property Name As String

    Public Overridable Property Customers As ICollection(Of Customer)
End Class
