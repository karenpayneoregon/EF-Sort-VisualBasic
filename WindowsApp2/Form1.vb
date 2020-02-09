Imports WindowsApp2.Classes
Imports Equin.ApplicationFramework

Public Class Form1
    Private CustomerView As BindingListView(Of CustomerEntity)
    Private CustomerBindingSource As BindingSource
    Property CustomerOperations() As CustomerOperations

    Private Async Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        DataGridView1.AutoGenerateColumns = False

        CustomerOperations = New CustomerOperations()
        Dim customers As List(Of CustomerEntity)
        customers = Await CustomerOperations.ReadAsync()

        CustomerView = New BindingListView(Of CustomerEntity)(customers)

        CustomerBindingSource = New BindingSource()
        CustomerBindingSource.DataSource = CustomerView

        DataGridView1.DataSource = CustomerBindingSource
        DataGridView1.ExpandColumns()

        BindingNavigator1.BindingSource = CustomerBindingSource

    End Sub
End Class
