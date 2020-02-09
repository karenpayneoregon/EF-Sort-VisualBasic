Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class NorthWindAzureContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=NorthWindAzureContext")
    End Sub

    Public Overridable Property Categories As DbSet(Of Category)
    Public Overridable Property Contacts As DbSet(Of Contact)
    Public Overridable Property ContactTypes As DbSet(Of ContactType)
    Public Overridable Property Countries As DbSet(Of Country)
    Public Overridable Property Customers As DbSet(Of Customer)
    Public Overridable Property Departments As DbSet(Of Department)
    Public Overridable Property Employees As DbSet(Of Employee)
    Public Overridable Property ImageDatas As DbSet(Of ImageData)
    Public Overridable Property Order_Details As DbSet(Of Order_Detail)
    Public Overridable Property Orders As DbSet(Of Order)
    Public Overridable Property Products As DbSet(Of Product)
    Public Overridable Property Shippers As DbSet(Of Shipper)
    Public Overridable Property Suppliers As DbSet(Of Supplier)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Contact)() _
            .HasMany(Function(e) e.Customers) _
            .WithOptional(Function(e) e.Contact) _
            .WillCascadeOnDelete()

        modelBuilder.Entity(Of ContactType)() _
            .HasMany(Function(e) e.Customers) _
            .WithOptional(Function(e) e.ContactType) _
            .WillCascadeOnDelete()

        modelBuilder.Entity(Of Customer)() _
            .HasMany(Function(e) e.Orders) _
            .WithOptional(Function(e) e.Customer) _
            .WillCascadeOnDelete()

        modelBuilder.Entity(Of Order_Detail)() _
            .Property(Function(e) e.UnitPrice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Order)() _
            .Property(Function(e) e.Freight) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Product)() _
            .Property(Function(e) e.UnitPrice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Product)() _
            .HasMany(Function(e) e.Order_Details) _
            .WithRequired(Function(e) e.Product) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Shipper)() _
            .HasMany(Function(e) e.Orders) _
            .WithOptional(Function(e) e.Shipper) _
            .HasForeignKey(Function(e) e.ShipVia)
    End Sub
End Class
