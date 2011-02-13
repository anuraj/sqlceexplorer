Imports System.Text
Imports System.Data.SqlServerCe
Imports System.IO
Imports System.Xml
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports Microsoft.CSharp

Namespace Framework.Extentions
    Public Class CSharpCodeGenerator
        Inherits BaseCodeGenerator
        Public Sub New()
            m_FileExtention = ".cs"
            m_Language = "C#"
        End Sub
        Public Overrides ReadOnly Property FileExtention As String
            Get
                Return m_FileExtention
            End Get
        End Property

        Public Overrides Sub GenerateCode(ByVal tableNames As System.Collections.Generic.IEnumerable(Of String))
            Me.m_ListOfTables = tableNames
            For Each tableName As String In tableNames
                Dim _datalayerNamespace As New CodeNamespace(m_Database)
                _datalayerNamespace.Imports.Add(New CodeNamespaceImport("System"))

                Dim _entity As New CodeTypeDeclaration(tableName)
                _entity.IsClass = True
                _entity.Attributes = MemberAttributes.Public

                Dim _codeCompileUnit As New CodeCompileUnit()
                _codeCompileUnit.Namespaces.Add(_datalayerNamespace)

                Dim query As String = String.Format(SELECTQUERYCOLUMNS, tableName)
                Dim oSqlCeExplorerData As New SqlCeExplorerData

                Dim options As New CodeGeneratorOptions()
                options.BlankLinesBetweenMembers = True
                options.ElseOnClosing = True
                options.VerbatimOrder = True

                Dim _member As CodeMemberField
                Dim _property As CodeMemberProperty
                Dim _dataType, _propertyName As String
                Dim _get, _set As CodeSnippetExpression
                Using dataReader As SqlCeDataReader = oSqlCeExplorerData.ExecuteQuery(query)
                    While dataReader.Read
                        _dataType = Me.GetDataType(dataReader("DATA_TYPE").ToString())
                        _propertyName = dataReader("COLUMN_NAME").ToString().Trim()
                        _member = New CodeMemberField(_dataType, String.Format("_{0}", _propertyName))
                        _entity.Members.Add(_member)

                        _property = New CodeMemberProperty()
                        _property.Name = dataReader("COLUMN_NAME").ToString()
                        _property.Type = New CodeTypeReference(_dataType)
                        _property.Attributes = MemberAttributes.Public
                        _get = New CodeSnippetExpression(String.Format("return _{0}", _propertyName))
                        _set = New CodeSnippetExpression(String.Format("_{0} = value", _propertyName))
                        _property.SetStatements.Add(_set)
                        _property.GetStatements.Add(_get)
                        _entity.Members.Add(_property)
                    End While
                    _datalayerNamespace.Types.Add(_entity)
                    Dim codeProvider As New CSharpCodeProvider
                    Using oStreamWriter As New StreamWriter(Path.Combine(Me.m_Directory, Path.ChangeExtension(tableName, m_FileExtention)))
                        codeProvider.GenerateCodeFromCompileUnit(_codeCompileUnit, oStreamWriter, options)
                    End Using
                End Using
            Next
        End Sub

        Public Overrides Sub GenerateProject(ByVal databaseName As String)
            MyBase.GenerateProjectXml(databaseName, "$(MSBuildToolsPath)\Microsoft.CSharp.targets", m_ListOfTables)
        End Sub

        Public Overrides ReadOnly Property Language As String
            Get
                Return m_Language
            End Get
        End Property

        Public Overrides Sub ShowAbout()
            MessageBox.Show("C# Code Generator" + vbCrLf + "Copyright (C) 2010 SqlCeExplorer Developement team", APPLICATION_NAME)
        End Sub
    End Class
End Namespace