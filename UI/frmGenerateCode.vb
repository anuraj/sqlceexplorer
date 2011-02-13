Imports System.Data.SqlServerCe
Imports System.Text
Imports SQLCEExplorer.Framework.Interfaces
Imports SQLCEExplorer.Framework
Imports System.Reflection
Imports System.IO

Public Class frmGenerateCode
    Private Const SELECTQUERYTABLES As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES"
    Private Const SELECTQUERYCOLUMNS As String = "SELECT COLUMN_NAME,[DATA_TYPE] ,[IS_NULLABLE], [CHARACTER_MAXIMUM_LENGTH] FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = '{0}')"

    Private m_IsExtentionsLoaded As Boolean = False
    Private m_ListOfExtns As List(Of ICodeGenerator)
    Private m_Host As PluginHost(Of ICodeGenerator)
    Private m_DatabaseName As String
    Public Event QueryFormed(ByVal sender As Object, ByVal e As EventArgs)

    Public Sub New(ByVal databaseName As String)
        InitializeComponent()
        Me.m_DatabaseName = databaseName
    End Sub

    Private Sub chkScriptTables_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScriptTables.CheckedChanged
        Me.chkListTables.Enabled = Me.chkScriptTables.Checked
    End Sub
    Private Function GetDataReader(ByVal Tablename As String) As SqlCeDataReader
        Dim query As String = String.Format(SELECTQUERYCOLUMNS, Tablename)
        Dim oSqlCeExplorerData As New SqlCeExplorerData
        Return oSqlCeExplorerData.ExecuteQuery(query)
    End Function
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Private Function GetScript() As String
        Dim result As New StringBuilder
        For Each Item As String In Me.chkListTables.CheckedItems
            result.AppendLine(String.Format("-- TABLE : {0} --", Item))
            result.Append(Me.GetDataReader(Item))
            result.AppendLine()
        Next
        Return result.ToString()
    End Function
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.chkListTables.CheckedItems.Count >= 1 Then
            Dim result As String = GetScript()
            If result.Length >= 1 Then
                Using oFolderDialog As New FolderBrowserDialog
                    With oFolderDialog
                        .Description = "Select the Folder to generate the files"
                        .ShowNewFolderButton = True
                        If .ShowDialog(Me) = DialogResult.OK Then
                            If Me.cmbLanguages.SelectedIndex <> -1 Then
                                Dim listOfTables As New List(Of String)(Me.chkListTables.CheckedItems.Count)
                                For Each tableName As String In Me.chkListTables.CheckedItems
                                    listOfTables.Add(tableName)
                                Next
                                Dim CodeGenerator As ICodeGenerator = m_Host.GetPluginUsingProperty("Language", cmbLanguages.SelectedItem.ToString)
                                CodeGenerator.Initialize(.SelectedPath, Me.m_DatabaseName)
                                CodeGenerator.GenerateCode(listOfTables)
                                CodeGenerator.GenerateProject(Me.m_DatabaseName)
                            End If
                        End If
                    End With
                End Using
            End If
            Me.Close()
        Else
            SQLCEExplorer.SqlCeExplorerUtility.ShowMessage("Please select a Table to script", Me.chkListTables)
        End If
    End Sub

    Private Sub frmGenerateScript_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadLanguages()
        Me.LoadTables()
    End Sub

    Private Sub LoadtInstalledExtentions()
        If Not m_IsExtentionsLoaded Then
            Me.m_Host = New PluginHost(Of ICodeGenerator)
            m_ListOfExtns = m_Host.GetPlugins(Assembly.GetExecutingAssembly())
            m_IsExtentionsLoaded = True
        End If
    End Sub

    Private Sub LoadLanguages()
        If Not m_IsExtentionsLoaded Then
            Me.LoadtInstalledExtentions()
        End If
        Me.cmbLanguages.Items.Clear()
        For Each codeGenerator As ICodeGenerator In m_ListOfExtns
            Me.cmbLanguages.Items.Add(codeGenerator.Language)
        Next
    End Sub

    Private Sub LoadTables()
        Dim oSqlCeExplorerData As SqlCeExplorerData
        Dim oTablesReader As SqlCeDataReader
        oSqlCeExplorerData = New SqlCeExplorerData
        oTablesReader = oSqlCeExplorerData.ExecuteQuery(SELECTQUERYTABLES)
        If oTablesReader IsNot Nothing Then
            While oTablesReader.Read
                Me.chkListTables.Items.Add(oTablesReader("TABLE_NAME").ToString)
            End While
            oTablesReader.Close()
        End If
    End Sub

    Private Sub cmdShowAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowAbout.Click
        If Me.cmbLanguages.SelectedIndex <> -1 Then
            For Each codeGenerator As ICodeGenerator In m_ListOfExtns
                If codeGenerator.Language.Equals(Me.cmbLanguages.SelectedItem.ToString(),
                                                 StringComparison.CurrentCultureIgnoreCase) Then
                    codeGenerator.ShowAbout()
                    Exit For
                End If
            Next
        End If
    End Sub
End Class