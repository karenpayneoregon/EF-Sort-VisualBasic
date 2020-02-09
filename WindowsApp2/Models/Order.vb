Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Order
    Public Sub New()
        Order_Details = New HashSet(Of Order_Detail)()
    End Sub

    Public Property OrderID As Integer

    Public Property CustomerIdentifier As Integer?

    Public Property EmployeeID As Integer?

    Public Property OrderDate As Date?

    Public Property RequiredDate As Date?

    Public Property ShippedDate As Date?

    Public Property ShipVia As Integer?

    <Column(TypeName:="money")>
    Public Property Freight As Decimal?

    <StringLength(60)>
    Public Property ShipAddress As String

    <StringLength(15)>
    Public Property ShipCity As String

    <StringLength(15)>
    Public Property ShipRegion As String

    <StringLength(10)>
    Public Property ShipPostalCode As String

    <StringLength(15)>
    Public Property ShipCountry As String

    Public Overridable Property Customer As Customer

    Public Overridable Property Employee As Employee

    Public Overridable Property Order_Details As ICollection(Of Order_Detail)

    Public Overridable Property Shipper As Shipper
End Class
