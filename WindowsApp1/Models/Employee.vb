Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Employee
    Public Sub New()
        Orders = New HashSet(Of Order)()
    End Sub

    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property EmployeeID As Integer

    <Required>
    <StringLength(20)>
    Public Property LastName As String

    <Required>
    <StringLength(10)>
    Public Property FirstName As String

    <StringLength(30)>
    Public Property Title As String

    <StringLength(25)>
    Public Property TitleOfCourtesy As String

    Public Property BirthDate As Date?

    Public Property HireDate As Date?

    <StringLength(60)>
    Public Property Address As String

    <StringLength(15)>
    Public Property City As String

    <StringLength(15)>
    Public Property Region As String

    <StringLength(10)>
    Public Property PostalCode As String

    <StringLength(15)>
    Public Property Country As String

    <StringLength(24)>
    Public Property HomePhone As String

    <StringLength(4)>
    Public Property Extension As String

    Public Property Notes As String

    Public Property ReportsTo As Integer?

    Public Overridable Property Orders As ICollection(Of Order)
End Class
