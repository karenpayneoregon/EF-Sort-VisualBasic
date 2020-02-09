Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("ImageData")>
Partial Public Class ImageData
    <Key>
    Public Property ImageID As Integer

    <Column("ImageData", TypeName:="image")>
    Public Property ImageData1 As Byte()

    Public Property Description As String
End Class
