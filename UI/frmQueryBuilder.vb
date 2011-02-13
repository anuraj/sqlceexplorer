Imports System.Data.SqlServerCe

Public Class frmQueryBuilder
    Private Const SELECTQUERYTABLES As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES"
    Private Const SELECTQUERYCOLUMNS As String = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = '{0}')"
    Public Event QueryBuildCompleted(ByVal sender As Object, ByVal e As EventArgs)
    Private Sub frmQueryBuilder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadTables()
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
    Private Sub FillColumns(ByVal table As String)
        Me.cmbColumns.Items.Clear()
        Dim result As New List(Of String)
        Dim oTablesReader As SqlCeDataReader
        Dim query As String = String.Format(SELECTQUERYCOLUMNS, table)
        Dim oSqlCeExplorerData As New SqlCeExplorerData
        oTablesReader = oSqlCeExplorerData.ExecuteQuery(query)

        While oTablesReader.Read
            Me.cmbColumns.Items.Add(oTablesReader("COLUMN_NAME").ToString())
        End While
        oTablesReader.Close()
        oTablesReader = Nothing
        oSqlCeExplorerData = Nothing
    End Sub
    Private Sub cmbTables_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTables.SelectedIndexChanged
        If Me.cmbTables.SelectedIndex <> -1 Then
            Me.FillColumns(Me.cmbTables.SelectedItem.ToString())
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If cmbTables.SelectedIndex <> -1 AndAlso cmbColumns.SelectedIndex <> -1 Then
            Me.dgvDesigner.Rows.Add(New String() {Me.cmbTables.SelectedItem.ToString(), Me.cmbColumns.SelectedItem.ToString(), Me.chkOutput.Checked, Me.txtCriteria.Text})
            Me.txtCriteria.Text = String.Empty
        End If
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        If Me.dgvDesigner.SelectedRows IsNot Nothing Then
            Dim rows As DataGridViewSelectedRowCollection = Me.dgvDesigner.SelectedRows
            For Each selectedRow As DataGridViewRow In rows
                If Not selectedRow.IsNewRow Then
                    Me.dgvDesigner.Rows.Remove(selectedRow)
                End If
            Next
        End If
    End Sub

    Private Sub cmdBuildQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuildQuery.Click
        Dim query As String = "SELECT "
        Dim fromTables As String = " FROM "
        Dim criteria As String = " WHERE"
        For Each dataRow As DataGridViewRow In Me.dgvDesigner.Rows
            If Not dataRow.IsNewRow Then
                Dim table As String = dataRow.Cells(0).Value
                If Not fromTables.Contains(table) Then
                    fromTables += String.Format(" {0},", table)
                End If
                Dim column As String = dataRow.Cells(1).Value
                If Convert.ToBoolean(dataRow.Cells(2).Value) Then
                    query += String.Format("{0}.[{1}],", table, column)
                End If
                Dim condition As String = dataRow.Cells(3).Value
                If condition.Length >= 1 Then
                    criteria += String.Format(" {0}.[{1}]{2},", table, column, condition)
                End If
            End If
        Next
        fromTables = Me.RemoveTrailingComma(fromTables)
        query = Me.RemoveTrailingComma(query)
        criteria = Me.RemoveTrailingComma(criteria)
        If Not fromTables.Equals(" FROM ", StringComparison.CurrentCultureIgnoreCase) AndAlso
            Not query.Equals("SELECT ", StringComparison.CurrentCultureIgnoreCase) Then
            Me.txtOutput.Text = query + fromTables + IIf(criteria.Equals(" WHERE", StringComparison.CurrentCultureIgnoreCase), String.Empty, criteria)
        Else
            SqlCeExplorerUtility.ShowMessage("Please select Columns / Table", cmdBuildQuery)
        End If
    End Sub

    Private Function RemoveTrailingComma(ByVal query As String) As String
        If query.EndsWith(",") Then
            query = query.Remove(query.Length - 1, 1)
        End If
        Return query
    End Function

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        SqlCeMain.CurrentQuery(Me.txtOutput.Text)
        RaiseEvent QueryBuildCompleted(sender, e)
        Me.Close()
    End Sub
End Class