﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LoadCustomersButton = New System.Windows.Forms.Button()
        Me.ColumnNameListBox = New System.Windows.Forms.ListBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DescendingOrderCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ConventionalSortOnePropertyButton = New System.Windows.Forms.Button()
        Me.UnusualSortButton = New System.Windows.Forms.Button()
        Me.TwoColumnOrderByButton = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LoadCustomersButton
        '
        Me.LoadCustomersButton.Location = New System.Drawing.Point(12, 229)
        Me.LoadCustomersButton.Name = "LoadCustomersButton"
        Me.LoadCustomersButton.Size = New System.Drawing.Size(180, 23)
        Me.LoadCustomersButton.TabIndex = 0
        Me.LoadCustomersButton.Text = "Load Customers"
        Me.LoadCustomersButton.UseVisualStyleBackColor = True
        '
        'ColumnNameListBox
        '
        Me.ColumnNameListBox.FormattingEnabled = True
        Me.ColumnNameListBox.Location = New System.Drawing.Point(6, 27)
        Me.ColumnNameListBox.Name = "ColumnNameListBox"
        Me.ColumnNameListBox.Size = New System.Drawing.Size(155, 121)
        Me.ColumnNameListBox.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(215, 28)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(622, 285)
        Me.DataGridView1.TabIndex = 4
        '
        'DescendingOrderCheckBox
        '
        Me.DescendingOrderCheckBox.AutoSize = True
        Me.DescendingOrderCheckBox.Location = New System.Drawing.Point(6, 172)
        Me.DescendingOrderCheckBox.Name = "DescendingOrderCheckBox"
        Me.DescendingOrderCheckBox.Size = New System.Drawing.Size(110, 17)
        Me.DescendingOrderCheckBox.TabIndex = 1
        Me.DescendingOrderCheckBox.Text = "Descending order"
        Me.DescendingOrderCheckBox.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ColumnNameListBox)
        Me.GroupBox1.Controls.Add(Me.DescendingOrderCheckBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 195)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sort by"
        '
        'ConventionalSortOnePropertyButton
        '
        Me.ConventionalSortOnePropertyButton.Location = New System.Drawing.Point(12, 258)
        Me.ConventionalSortOnePropertyButton.Name = "ConventionalSortOnePropertyButton"
        Me.ConventionalSortOnePropertyButton.Size = New System.Drawing.Size(180, 23)
        Me.ConventionalSortOnePropertyButton.TabIndex = 1
        Me.ConventionalSortOnePropertyButton.Text = "Conventional sort one property"
        Me.ConventionalSortOnePropertyButton.UseVisualStyleBackColor = True
        '
        'UnusualSortButton
        '
        Me.UnusualSortButton.Location = New System.Drawing.Point(12, 319)
        Me.UnusualSortButton.Name = "UnusualSortButton"
        Me.UnusualSortButton.Size = New System.Drawing.Size(180, 23)
        Me.UnusualSortButton.TabIndex = 3
        Me.UnusualSortButton.Text = "Unusual Sort"
        Me.UnusualSortButton.UseVisualStyleBackColor = True
        '
        'TwoColumnOrderByButton
        '
        Me.TwoColumnOrderByButton.Location = New System.Drawing.Point(12, 290)
        Me.TwoColumnOrderByButton.Name = "TwoColumnOrderByButton"
        Me.TwoColumnOrderByButton.Size = New System.Drawing.Size(180, 23)
        Me.TwoColumnOrderByButton.TabIndex = 2
        Me.TwoColumnOrderByButton.Text = "Two column order by"
        Me.TwoColumnOrderByButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 366)
        Me.Controls.Add(Me.TwoColumnOrderByButton)
        Me.Controls.Add(Me.UnusualSortButton)
        Me.Controls.Add(Me.ConventionalSortOnePropertyButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.LoadCustomersButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entity Framework dynamic sorting"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LoadCustomersButton As Button
    Friend WithEvents ColumnNameListBox As ListBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DescendingOrderCheckBox As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ConventionalSortOnePropertyButton As Button
    Friend WithEvents UnusualSortButton As Button
    Friend WithEvents TwoColumnOrderByButton As Button
End Class
