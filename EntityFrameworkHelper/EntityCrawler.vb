Imports System
Imports System.Collections.Generic
Imports System.Data.Entity
Imports System.Data.Entity.Core.EntityClient
Imports System.Data.Entity.Core.Metadata.Edm
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports EntityFrameworkHelper.Classes

Public Class EntityCrawler
    Private _entityTypesData As IEnumerable(Of EntityType)

    Private _tableNames() As String
    Public ReadOnly Property TableNames() As String()
        Get
            Return _tableNames
        End Get
    End Property

    Public Property EntityModelName() As String
    ''' <summary>
    ''' Container for a single entity, columns and keys
    ''' </summary>
    Public Property TableInformation() As List(Of TableInformation)
    ''' <summary>
    ''' Assembly for Entity Framework project
    ''' </summary>
    Public Property AssembleName() As String
    ''' <summary>
    ''' DbContext
    ''' </summary>
    Public Property ContextName() As String

    ''' <summary>
    ''' Setup for code first, EDMX will be different
    ''' </summary>
    Public Sub New()
        EntityModelName = "CodeFirstDatabaseSchema"
    End Sub

    Public Sub New(entityModelName As String)
        Me.EntityModelName = entityModelName
    End Sub
    ''' <summary>
    ''' Populate our list
    ''' </summary>
    Public Sub GetInformation()

        Dim handle = Activator.CreateInstance(AssembleName, String.Concat(AssembleName, ".", ContextName))
        Dim dbContext = CType(handle.Unwrap(), DbContext)

        Dim objectContext = CType(dbContext, IObjectContextAdapter).ObjectContext
        Dim storageMetadata = CType(objectContext.Connection, EntityConnection).GetMetadataWorkspace().GetItems(DataSpace.SSpace)

        _entityTypesData = (
                From globalItem In storageMetadata
                Where globalItem.BuiltInTypeKind = BuiltInTypeKind.EntityType
                Select TryCast(globalItem, EntityType))

        _tableNames = Tables()

        TableInformation = New List(Of TableInformation)()

        Dim columnNames = New List(Of String)()
        Dim keyNames = New List(Of String)()

        For Each tableName As String In TableNames

            columnNames = GetColumnNames(tableName)

            Dim tempEntityColumns = GetColumnInformation(tableName)

            keyNames = New List(Of String)()

            Dim entityType As EntityType = _entityTypesData.ToList().Where(Function(item) item.Name = tableName).FirstOrDefault()

            ' get any primary keys
            Dim props = entityType.KeyProperties

            If props IsNot Nothing Then

                For Each edmProperty As EdmProperty In props
                    keyNames.Add(edmProperty.ToString())
                Next edmProperty

            End If

            TableInformation.Add(New TableInformation() With {
                                    .tableName = tableName,
                                    .Columns = columnNames,
                                    .PrimaryKeyList = keyNames,
                                    .EntityColumnList = tempEntityColumns})

        Next tableName
    End Sub
    ''' <summary>
    ''' Get all columns for table
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    Public Function GetColumnNames(ByVal tableName As String) As List(Of String)
        Dim columnNames = New List(Of String)()

        Dim metaData As List(Of ReadOnlyMetadataCollection(Of EdmProperty)) = (
                From entityType In _entityTypesData
                Where entityType.FullName = $"{EntityModelName}.{tableName}"
                Select entityType.DeclaredProperties).ToList()


        For Each prop As ReadOnlyMetadataCollection(Of EdmProperty) In metaData
            prop.ToList().ForEach(Sub(edm) columnNames.Add(edm.Name))
        Next prop

        Return columnNames

    End Function
    ''' <summary>
    ''' Get column details
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    Public Function GetColumnInformation(ByVal tableName As String) As List(Of EntityColumn)
        Dim list = New List(Of EntityColumn)()

        '            
        ' * Checking FullName differs between code first and edmx
        ' * code first: CodeFirstDatabaseSchema
        ' * edmx: store
        '             
        Dim metaData = (_entityTypesData.Where(Function(entityType) entityType.FullName = $"{EntityModelName}.{tableName}").Select(Function(entityTypesData) entityTypesData.DeclaredProperties)).ToList()


        Dim entityType1 As EntityType = _entityTypesData.ToList().Where(Function(item) item.Name = tableName).FirstOrDefault()
        Dim props As ReadOnlyMetadataCollection(Of EdmProperty) = entityType1.KeyProperties

        For Each prop As ReadOnlyMetadataCollection(Of EdmProperty) In metaData

            For Each itemEdmProperty In prop.ToList()
                Dim primaryKey As Boolean = False

                If props IsNot Nothing Then
                    primaryKey = props.FirstOrDefault(Function(item) item.Name = itemEdmProperty.Name) IsNot Nothing
                End If

                list.Add(New EntityColumn() With {.Name = itemEdmProperty.Name, .Type = itemEdmProperty.PrimitiveType.ClrEquivalentType, .TypeName = itemEdmProperty.TypeName, .Key = primaryKey})

            Next

        Next

        Return list
    End Function

    ''' <summary>
    ''' Return all tables in context excluding diagrams
    ''' </summary>
    ''' <returns></returns>
    Private Function Tables() As String()
        Return _entityTypesData.ToList().Where(Function(tbl) tbl.Name <> "sysdiagrams").Select(Function(item) item.Name).ToList().ToArray()
    End Function
End Class

