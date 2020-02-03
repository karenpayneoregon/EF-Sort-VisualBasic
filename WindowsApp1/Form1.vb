
Imports System.Reflection
Imports Equin.ApplicationFramework

Public Class Form1
    Private CustomerView As BindingListView(Of CustomerItem)
    Private operations As New Operations

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Async Sub LoadCustomersButton_Click(sender As Object, e As EventArgs) Handles LoadCustomersButton.Click
        Dim customers As List(Of CustomerItem)
        Dim PropertyName = ColumnNameListBox.Text.Replace(" "c, "")

        If Not DescendingOrderCheckBox.Checked Then
            customers = Await operations.CustomerSort1(PropertyName)
        Else
            customers = Await operations.CustomerSort1(PropertyName, SortDirection.Descending)
        End If

        CustomerView = New BindingListView(Of CustomerItem)(customers)

        DataGridView1.DataSource = CustomerView

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ColumnNameListBox.DataSource = operations.CustomerItemPropertyNames()
    End Sub
End Class
