Imports WindowsApp1.Classes
Imports WindowsApp1.LanguageExtensions

Public Class MultiColumnSortForm
    Private operations As New Operations

    Private Async Sub MultiColumnSortForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim results = Await operations.
                CustomerSortTwoProperties({"CompanyName", "CountryName"},
                                          SortDirection.Descending)

        DataGridView1.DataSource = results
    End Sub
End Class