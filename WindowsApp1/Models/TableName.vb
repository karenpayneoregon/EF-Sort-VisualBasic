Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class TableName
    Public Property id As Integer

    <Column("TableName")>
    Public Property TableName1 As String
End Class
