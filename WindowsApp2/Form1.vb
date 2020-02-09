Imports WindowsApp2.Classes
Imports Equin.ApplicationFramework

Public Class Form1

    Private _customerView As BindingListView(Of CustomerEntity)
    Private _customerBindingSource As BindingSource

    Property CustomerOperations() As CustomerOperations

    Private Async Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '
        ' DataGridView has columns defined in the IDE with DataPropertyName set
        ' to a property of CustomerEntity.
        '
        DataGridView1.AutoGenerateColumns = False

        '
        ' Create new instance of CustomerOperations which creates 
        ' an instance of the DbContext NorthWindAzureContext
        '
        CustomerOperations = New CustomerOperations()

        CustomerOperations.Context.Database.Log = AddressOf Console.WriteLine

        '
        ' Read customers into a view
        '
        Dim customers As List(Of CustomerEntity) = Await CustomerOperations.ReadAsync()

        '
        ' Setup BindingListView with customers read in above
        '
        _customerView = New BindingListView(Of CustomerEntity)(customers)


        _customerBindingSource = New BindingSource()

        '
        ' Assign BindingListView to BindingSource
        '
        _customerBindingSource.DataSource = _customerView

        '
        ' Setup DataGridView DataSource to read in customers in the view
        '
        DataGridView1.DataSource = _customerBindingSource
        DataGridView1.ExpandColumns()

        BindingNavigator1.BindingSource = _customerBindingSource

        CurrentCustomerButton.Enabled = True

    End Sub
    ''' <summary>
    ''' Demonstrate obtaining current customer in current row of 
    ''' DataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CurrentCustomerButton_Click(sender As Object, e As EventArgs) _
        Handles CurrentCustomerButton.Click

        Dim customer = _customerBindingSource.CurrentCustomerEntity()

        MessageBox.Show(
            $"Company: {customer.CompanyName}{Environment.NewLine}" &
            $"Primary key: {customer.CustomerIdentifier}{Environment.NewLine}" &
            $"Contact key: {customer.ContactId}{Environment.NewLine}" &
            $"Country key: {customer.CountryIdentifier}")


    End Sub
End Class
