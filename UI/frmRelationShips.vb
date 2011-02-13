Imports System.Data.SqlServerCe

Public Class frmRelationShips
    Public Event RelationShipQueryFormed(ByVal sender As Object, ByVal e As EventArgs)

    Private fkTable As String
    Private Const SELECTQUERYTABLES As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES"
    Private Const SELECTQUERYCOLUMNS As String = "SELECT COLUMN_NAME, TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = '{0}')"
    Public Sub New(ByVal fkTable As String)
        InitializeComponent()
        Me.fkTable = fkTable
    End Sub
    Private Sub frmRelationShips_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtFKTable.Text = Me.fkTable
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
        If Me.cmbTables.Items.Count >= 1 Then
            Me.cmbTables.SelectedIndex = 0
        End If
        Me.AddColumns(Me.fkTable, Me.cmbFKTableColumns)
        Me.cmbUpdateRule.SelectedIndex = 0
        Me.cmbDeleteRule.SelectedIndex = 0
    End Sub

    Private Sub cmbTables_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTables.SelectedIndexChanged
        If cmbTables.SelectedIndex <> -1 Then
            Me.AddColumns(cmbTables.Items(cmbTables.SelectedIndex).ToString, Me.cmbPKTableColumns)
        End If
    End Sub

    Private Sub AddColumns(ByVal tableName As String, ByVal Dropdown As ComboBox)
        Dim oSqlCeExplorerData As SqlCeExplorerData
        Dim oTablesReader As SqlCeDataReader
        oSqlCeExplorerData = New SqlCeExplorerData

        oTablesReader = oSqlCeExplorerData.ExecuteQuery(String.Format(SELECTQUERYCOLUMNS, tableName))
        Dropdown.Items.Clear()
        If oTablesReader IsNot Nothing Then
            While oTablesReader.Read
                Dropdown.Items.Add(oTablesReader("COLUMN_NAME").ToString)
            End While
            oTablesReader.Close()
        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.txtRelationshipName.TextLength <= 0 Then
            SqlCeExplorerUtility.ShowMessage("Relationship name cannot be empty", Me.txtRelationshipName)
            Return
        End If

        Dim querytemplate As String = "ALTER TABLE {0} " & _
        "ADD CONSTRAINT {1} FOREIGN KEY ({2}) REFERENCES " & _
        "{3}({4}) ON DELETE {5} ON UPDATE {6}"
        Dim query As String = String.Format(querytemplate, Me.cmbTables.Items(Me.cmbTables.SelectedIndex).ToString(), _
                                            Me.txtRelationshipName.Text, Me.cmbFKTableColumns.Items(Me.cmbFKTableColumns.SelectedIndex).ToString(), _
                                            Me.txtFKTable.Text, Me.cmbFKTableColumns.Items(Me.cmbFKTableColumns.SelectedIndex).ToString(), _
                                            Me.cmbDeleteRule.Items(Me.cmbDeleteRule.SelectedIndex).ToString(), Me.cmbUpdateRule.Items(Me.cmbUpdateRule.SelectedIndex).ToString())
        SqlCeMain.CurrentQuery(query)
        RaiseEvent RelationShipQueryFormed(Me, e)
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class