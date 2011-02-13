Imports SQLCEExplorer.Framework
Imports System.Reflection
Imports SQLCEExplorer.Framework.Interfaces
Imports System.IO
Imports System.Data.SqlServerCe

Public Class frmImportFile
    Private m_CurrentAdapter As SqlCeDataAdapter
    Private m_DataTable As DataTable
    Private Const SELECTQUERYTABLES As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES"
    Private m_FileTypes As String
    Private m_IsExtentionsLoaded As Boolean = False
    Private m_ListOfExtns As List(Of IImportModule)
    Private m_Host As PluginHost(Of IImportModule)

    Private Sub LoadTables()
        Me.cmbTables.Items.Clear()
        Dim oSqlCeExplorerData As SqlCeExplorerData
        Dim oTablesReader As SqlCeDataReader
        oSqlCeExplorerData = New SqlCeExplorerData
        oTablesReader = oSqlCeExplorerData.ExecuteQuery(SELECTQUERYTABLES)
        If oTablesReader IsNot Nothing Then
            While oTablesReader.Read
                Me.cmbTables.Items.Add(oTablesReader("TABLE_NAME").ToString)
            End While
            oTablesReader.Close()
        End If
    End Sub
    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Using oFileDialog As New OpenFileDialog
            With oFileDialog
                .Filter = m_FileTypes
                .AutoUpgradeEnabled = False
                .CheckFileExists = True
                .FilterIndex = 0
                If cmbFileTypes.SelectedIndex <> -1 Then
                    .FilterIndex = cmbFileTypes.SelectedIndex + 1
                End If
                .Multiselect = False
                .ReadOnlyChecked = False
                .ShowHelp = False
                .ShowReadOnly = False
                .SupportMultiDottedExtensions = True
                .Title = String.Format("Import - {0}", APPLICATION_NAME)
                If .ShowDialog(Me) = DialogResult.OK Then
                    Me.ImportFile(.FileName)
                    Me.txtFileName.Text = .FileName
                End If
            End With
        End Using
    End Sub
  
    Private Sub ImportFile(ByVal filename As String)
        Dim fileExtn As String = Path.GetExtension(filename)
        If m_IsExtentionsLoaded Then
            Dim importModule As IImportModule =
                m_Host.GetPluginUsingProperty("FileExtention",
                                              IIf(fileExtn.StartsWith("."), fileExtn.Remove(0, 1), fileExtn))
            If importModule IsNot Nothing Then
                Me.dgvImportedData.DataSource = importModule.ImportFile(filename)
            End If
        End If
    End Sub

    Private Sub LoadtInstalledExtentions()
        If Not m_IsExtentionsLoaded Then
            Me.m_Host = New PluginHost(Of IImportModule)
            m_ListOfExtns = m_Host.GetPlugins(Assembly.GetExecutingAssembly())
            m_IsExtentionsLoaded = True
        End If
    End Sub
    Private Function GetFileFilters() As String
        Dim result As String = String.Empty
        If Not m_IsExtentionsLoaded Then
            Me.LoadtInstalledExtentions()
        End If
        For Each item As IImportModule In m_ListOfExtns
            result += String.Format("{0}|", item.FileTypes)
        Next
        Return IIf(result.EndsWith("|"), result.Remove(result.Length - 1, 1), result)
    End Function

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub

    Private Sub CmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOk.Click
        If Not Me.chkCreateTable.Checked AndAlso Me.cmbTables.SelectedIndex = -1 Then
            SqlCeExplorerUtility.ShowMessage("Table name cannot be empty", Me.cmbTables)
            Return
        End If
        Dim tableName As String
        If Me.chkCreateTable.Checked Then
            tableName = Path.GetFileNameWithoutExtension(Me.txtFileName.Text)
            Dim SqlQuery As String = BuildTableQuery(tableName)
            Dim oSqlCeExplorerData As New SqlCeExplorerData
            oSqlCeExplorerData.ExecuteQuery(SqlQuery)
        Else
            tableName = cmbTables.SelectedItem.ToString
        End If
        Me.ImportData(tableName)
        Me.Close()
    End Sub

    Public Function ImportData(ByVal tableName As String) As Integer
        Dim query As String = String.Format("SELECT * FROM [{0}]", tableName)
        Me.m_CurrentAdapter = New SqlCeDataAdapter(query, SqlCeMain.GetConnectionString())
        Dim commandBuilder As New SqlCeCommandBuilder(Me.m_CurrentAdapter)
        m_DataTable = New DataTable(tableName)
        m_CurrentAdapter.Fill(m_DataTable)
        m_DataTable = TryCast(Me.dgvImportedData.DataSource, DataTable).Copy()
        Dim rowsCount As Integer = m_CurrentAdapter.Update(m_DataTable)
        Return rowsCount
    End Function
    Private Function BuildTableQuery(ByVal filename As String)
        Dim query As String = String.Format("CREATE TABLE [{0}] (", filename)
        For Each column As DataGridViewColumn In Me.dgvImportedData.Columns
            query += String.Format("[{0}] NVARCHAR(255),", column.Name)
        Next
        query = query.Remove(query.Length - 1, 1)
        query += ")"
        Return query
    End Function

    Private Sub chkCreateTable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCreateTable.CheckedChanged
        Me.lblTables.Enabled = Not Me.chkCreateTable.Checked
        Me.cmbTables.Enabled = Not Me.chkCreateTable.Checked
        If Me.chkCreateTable.Checked Then
            Me.LoadTables()
        End If
    End Sub

    Private Sub frmImportFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.m_FileTypes = Me.GetFileFilters
        Me.cmbFileTypes.Items.Clear()
        For Each item As IImportModule In m_ListOfExtns
            Me.cmbFileTypes.Items.Add(item.FileExtention)
            Me.cmbFileTypes.SelectedIndex = 0
        Next
    End Sub

    Private Sub cmdShowAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowAbout.Click
        For Each importModule As IImportModule In m_ListOfExtns
            If importModule.FileExtention.Equals(Me.cmbFileTypes.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase) Then
                importModule.ShowAbout()
                Exit For
            End If
        Next
    End Sub
End Class
