Imports System.Data.SqlServerCe

Public Class frmModifyIndex
    Private Const SELECTQUERYTABLES As String = "SELECT * FROM INFORMATION_SCHEMA.TABLES"
    Private Const SELECTQUERYCOLUMNS As String = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = '{0}')"
    Private Const SELECTQUERYINDEXES As String = "SELECT * FROM INFORMATION_SCHEMA.INDEXES WHERE (TABLE_NAME = '{0}')"
    Private m_Mode As OperationMode = OperationMode.Create
    Public Event ModifyIndexQueryFormed(ByVal sender As Object, ByVal e As EventArgs)
    Public Enum OperationMode
        Create = 1
        Drop = 2
    End Enum
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal Mode As OperationMode)
        InitializeComponent()
        m_Mode = Mode
    End Sub
    Private Sub frmModifyIndex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadTables()
        Dim result As Boolean = m_Mode = OperationMode.Drop
        Me.chkDropIndex.Enabled = result
        Me.chkDropIndex.Checked = result
        Me.plColumns.Enabled = Not result
        If result Then
            Me.cmbIndex.DropDownStyle = ComboBoxStyle.DropDownList
        Else
            Me.cmbIndex.DropDownStyle = ComboBoxStyle.Simple
        End If
    End Sub
    Private Sub LoadTables()
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
    Private Sub LoadIndexes(ByVal Tablename As String)
        Me.cmbIndex.Items.Clear()
        Dim oSqlCeExplorerData As SqlCeExplorerData
        Dim oTablesReader As SqlCeDataReader
        oSqlCeExplorerData = New SqlCeExplorerData
        oTablesReader = oSqlCeExplorerData.ExecuteQuery(String.Format(SELECTQUERYINDEXES, Tablename))
        If oTablesReader IsNot Nothing Then
            While oTablesReader.Read
                Me.cmbIndex.Items.Add(oTablesReader("INDEX_NAME").ToString)
            End While
            oTablesReader.Close()
        End If
    End Sub
    Private Sub LoadColumns(ByVal Tablename As String)
        Me.cmbIndex.Items.Clear()
        Dim oSqlCeExplorerData As SqlCeExplorerData
        Dim oTablesReader As SqlCeDataReader
        oSqlCeExplorerData = New SqlCeExplorerData
        oTablesReader = oSqlCeExplorerData.ExecuteQuery(String.Format(SELECTQUERYCOLUMNS, Tablename))
        If oTablesReader IsNot Nothing Then
            While oTablesReader.Read
                Me.cmbColumns.Items.Add(oTablesReader("COLUMN_NAME").ToString)
            End While
            oTablesReader.Close()
        End If
    End Sub
    Private Sub cmbTables_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTables.SelectedIndexChanged
        If m_Mode = OperationMode.Drop Then
            If Me.cmbTables.SelectedIndex <> -1 Then
                Me.LoadIndexes(Me.cmbTables.SelectedItem.ToString())
            End If
        Else
            If Me.cmbTables.SelectedIndex <> -1 Then
                Me.LoadColumns(Me.cmbTables.SelectedItem.ToString())
            End If
        End If
    End Sub

    Private Sub chkDropIndex_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDropIndex.CheckedChanged
        Me.plColumns.Enabled = Not chkDropIndex.Checked
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim createQuery As String = "CREATE {0}INDEX {1} ON {2} ({3})"
        Dim dropQuery As String = "DROP INDEX {0}.{1}"
        If cmbTables.SelectedIndex = -1 Then
            SQLCEExplorer.SqlCeExplorerUtility.ShowMessage("Please select a Table", cmbTables)
            Return
        End If
        If chkDropIndex.Checked Then
            If cmbIndex.SelectedIndex = -1 Then
                SQLCEExplorer.SqlCeExplorerUtility.ShowMessage("Please select an Index to drop", cmbIndex)
                Return
            End If
            Dim query As String = String.Format(dropQuery, cmbTables.SelectedItem.ToString, cmbIndex.SelectedItem.ToString())
            SQLCEExplorer.SqlCeMain.CurrentQuery(query)
        Else
            If cmbIndex.Text.Length <= 0 Then
                SQLCEExplorer.SqlCeExplorerUtility.ShowMessage("Please enter an Index to create", cmbIndex)
                Return
            End If
            If cmbColumns.SelectedIndex = -1 Then
                SQLCEExplorer.SqlCeExplorerUtility.ShowMessage("Please select a column to create index", cmbColumns)
                Return
            End If

            Dim unique As String = IIf(chkUnique.Checked, "UNIQUE ", String.Empty)
            Dim query As String = String.Format(createQuery, unique, cmbIndex.Text, cmbTables.SelectedItem.ToString, cmbColumns.SelectedItem.ToString)
            SQLCEExplorer.SqlCeMain.CurrentQuery(query)
        End If
        RaiseEvent ModifyIndexQueryFormed(Me, e)
        Me.Close()
    End Sub
End Class