Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Customer
    Public Sub New()
        Orders = New HashSet(Of Order)()
    End Sub

    <Key>
    Public Property CustomerIdentifier As Integer

    <Required>
    <StringLength(40)>
    Public Property CompanyName As String

    <StringLength(30)>
    Public Property ContactName As String

    Public Property ContactId As Integer?

    <StringLength(60)>
    Public Property Address As String

    <StringLength(15)>
    Public Property City As String

    <StringLength(15)>
    Public Property Region As String

    <StringLength(10)>
    Public Property PostalCode As String

    Public Property CountryIdentifier As Integer?

    <StringLength(24)>
    Public Property Phone As String

    <StringLength(24)>
    Public Property Fax As String

    Public Property ContactTypeIdentifier As Integer?

    <Column(TypeName:="datetime2")>
    Public Property ModifiedDate As Date?

    Public Overridable Property Contact As Contact

    Public Overridable Property ContactType As ContactType

    Public Overridable Property Country As Country

    Public Overridable Property Orders As ICollection(Of Order)
End Class
