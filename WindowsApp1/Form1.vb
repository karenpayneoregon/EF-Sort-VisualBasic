
Imports System.Reflection
Imports WindowsApp1.Classes
Imports WindowsApp1.LanguageExtensions
Imports Equin.ApplicationFramework

Public Class Form1
    Private CustomerView As BindingListView(Of CustomerItem)
    Private operations As New Operations

    Private Async Sub LoadCustomersButton_Click(sender As Object, e As EventArgs) _
        Handles LoadCustomersButton.Click

        Dim customers As List(Of CustomerItem)
        Dim PropertyName = ColumnNameListBox.Text.Replace(" "c, "")

        If Not DescendingOrderCheckBox.Checked Then
            customers = Await operations.CustomerSort(PropertyName)
        Else
            customers = Await operations.CustomerSort(PropertyName, SortDirection.Descending)
        End If

        CustomerView = New BindingListView(Of CustomerItem)(customers)

        DataGridView1.DataSource = CustomerView
        DataGridView1.ExpandColumns()

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        '
        ' Get property names for CustomerItem
        '
        ColumnNameListBox.DataSource = operations.CustomerItemPropertyNames()

    End Sub

    Private Async Sub ConventionalSortOnePropertyButton_Click(sender As Object, e As EventArgs) Handles ConventionalSortOnePropertyButton.Click

        Dim conventionalSort = Await operations.ConventionalOrderBy()

        CustomerView = New BindingListView(Of CustomerItem)(conventionalSort)

        DataGridView1.DataSource = CustomerView
        DataGridView1.ExpandColumns()

    End Sub

    Private Async Sub UnusualSortButton_Click(sender As Object, e As EventArgs) Handles UnusualSortButton.Click
        Dim results = Await operations.DemonstrationCustomOrdering()

        CustomerView = New BindingListView(Of CustomerItem)(results)

        DataGridView1.DataSource = CustomerView
        DataGridView1.ExpandColumns()

    End Sub
End Class
