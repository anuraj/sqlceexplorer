Imports System.Data.SqlServerCe

Public Class frmDeleteRelation
    Private Const SELECTQUERYTABLES As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES"
    Private Const SELECTQUERYRELATIONSHIPS As String = "SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME = '{0}' AND " & _
    "CONSTRAINT_NAME IN (SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS)"

    Private m_Tablename As String = String.Empty
    Private m_Relation As String = String.Empty
    Public Event DeleteRelationQueryFormed(ByVal sender As Object, ByVal e As EventArgs)
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal Tablename As String)
        InitializeComponent()
        m_Tablename = Tablename
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
    Private Sub LoadRelations(ByVal TableName As String)
        Dim oSqlCeExplorerData As SqlCeExplorerData
        Dim oTablesReader As SqlCeDataReader
        oSqlCeExplorerData = New SqlCeExplorerData
        oTablesReader = oSqlCeExplorerData.ExecuteQuery(String.Format(SELECTQUERYRELATIONSHIPS, TableName))
        If oTablesReader IsNot Nothing Then
            While oTablesReader.Read
                Me.cmbRelations.Items.Add(oTablesReader("CONSTRAINT_NAME").ToString)
            End While
            oTablesReader.Close()
        End If
    End Sub
    Private Sub frmDeleteRelation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadTables()
        If m_Tablename.Length >= 1 Then
            For index As Integer = 0 To Me.cmbTables.Items.Count - 1
                If Me.cmbTables.Items(index).ToString.Equals(m_Tablename, StringComparison.CurrentCultureIgnoreCase) Then
                    Me.cmbTables.SelectedIndex = index
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cmbTables_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTables.SelectedIndexChanged
        If Me.cmbTables.SelectedIndex <> -1 Then
            Me.LoadRelations(Me.cmbTables.Items(Me.cmbTables.SelectedIndex).ToString())
        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If m_Tablename.Length <= 0 AndAlso Me.cmbTables.SelectedIndex = -1 Then
            SqlCeExplorerUtility.ShowMessage("Please select a Table", Me.cmbTables)
            Return
        End If
        If Me.cmbRelations.SelectedIndex = -1 Then
            SqlCeExplorerUtility.ShowMessage("Please select a Relation", Me.cmbRelations)
            Return
        End If
        m_Tablename = cmbTables.SelectedItem.ToString
        m_Relation = cmbRelations.SelectedItem.ToString
        If MessageBox.Show(String.Format("This will permanently delete the ""{1}"" from ""{0}"" table in the database.{2}Are you sure want to continue?", m_Tablename, m_Relation, Environment.NewLine), SqlCeMain.APPLICATION_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            SqlCeMain.CurrentQuery(String.Format("ALTER TABLE [{0}] DROP CONSTRAINT [{1}]", m_Tablename, m_Relation))
            RaiseEvent DeleteRelationQueryFormed(Me, e)
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class