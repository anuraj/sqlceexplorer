Imports SQLCEExplorer.Framework.Interfaces
Imports System.Xml
Imports System.IO
Imports System.CodeDom

Namespace Framework
    Public MustInherit Class BaseCodeGenerator
        Implements ICodeGenerator

        Protected Const SELECTQUERYCOLUMNS As String = "SELECT COLUMN_NAME,[DATA_TYPE] ,[IS_NULLABLE], [CHARACTER_MAXIMUM_LENGTH] FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = '{0}')"
        Protected m_Directory As String = String.Empty
        Protected m_ListOfTables As IEnumerable(Of String)
        Protected m_Language As String = String.Empty
        Protected m_FileExtention As String = String.Empty
        Protected m_Database As String = String.Empty

        Public MustOverride ReadOnly Property FileExtention As String Implements Framework.Interfaces.ICodeGenerator.FileExtention
        Public MustOverride Sub GenerateCode(ByVal tableNames As System.Collections.Generic.IEnumerable(Of String)) Implements Framework.Interfaces.ICodeGenerator.GenerateCode

        Public MustOverride Sub GenerateProject(ByVal databaseName As String) Implements Framework.Interfaces.ICodeGenerator.GenerateProject

        Public Sub Initialize(ByVal directory As String, ByVal databaseName As String) Implements Framework.Interfaces.ICodeGenerator.Initialize
            m_Directory = directory
            m_Database = databaseName
        End Sub
        Public MustOverride ReadOnly Property Language As String Implements Framework.Interfaces.ICodeGenerator.Language
        Public MustOverride Sub ShowAbout() Implements Framework.Interfaces.ICodeGenerator.ShowAbout

        Protected Sub GenerateProjectXml(ByVal databaseName As String, ByVal targetType As String, ByVal ClassFiles As IEnumerable(Of String))
            If Me.m_ListOfTables Is Nothing Then
                Throw New ArgumentNullException()
            End If
            Dim projectTemplate As New XmlDocument
            projectTemplate.LoadXml(My.Resources.ProjectTemplate)
            projectTemplate.ChildNodes(1).ChildNodes(5).Attributes(0).InnerText = targetType

            For Each tableName As String In Me.m_ListOfTables
                Dim node As XmlNode = projectTemplate.CreateElement("Compile", projectTemplate.ChildNodes(1).ChildNodes(4).NamespaceURI)
                Dim attr As XmlAttribute = projectTemplate.CreateAttribute("Include")
                attr.Value = Path.ChangeExtension(tableName, m_FileExtention)
                node.Attributes.Append(attr)
                projectTemplate.ChildNodes(1).ChildNodes(4).AppendChild(node)
            Next

            Dim projectFileLocation As String = Path.Combine(m_Directory, Path.ChangeExtension(databaseName, String.Format("{0}proj", m_FileExtention)))
            projectTemplate.Save(projectFileLocation)
        End Sub

        Protected Function GetDataType(ByVal Dbtype As String) As String
            Dim result As String = "System.Object"

            Select Case Dbtype.ToUpperInvariant()
                Case "BIT"
                    result = "System.Boolean"
                Case "BIGINT", "INT", "NUMERIC", "SMALLINT", "TINYINT"
                    result = "System.Int32"
                Case "MONEY", "REAL", "FLOAT"
                    result = "System.Double"
                Case "BINARY", "IMAGE", "VARBINARY"
                    result = "System.Byte[]"
                Case "DATETIME"
                    result = "System.DateTime"
                Case "NCHAR"
                    result = "System.Char"
                Case "NVARCHAR", "NTEXT"
                    result = "System.String"
                Case "UNIQUEIDENTIFIER"
                    result = "System.Guid"
                Case Else
                    result = "System.Object"
            End Select
            Return result
        End Function
    End Class
End Namespace
