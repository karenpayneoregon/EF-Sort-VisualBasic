Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Contact
    Public Sub New()
        Customers = New HashSet(Of Customer)()
    End Sub

    Public Property ContactId As Integer

    Public Property FirstName As String

    Public Property LastName As String

    Public Overridable Property Customers As ICollection(Of Customer)
End Class
