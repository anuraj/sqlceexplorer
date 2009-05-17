Imports System.Data.SqlServerCe
Imports System.Text

Public Class frmGenerateScript
    Private Const SELECTQUERYTABLES As String = "SELECT * FROM INFORMATION_SCHEMA.TABLES"
    Private Const SELECTQUERYCOLUMNS As String = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = '{0}')"

    Public Event QueryFormed(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub chkScriptTables_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScriptTables.CheckedChanged
        Me.chkListTables.Enabled = Me.chkScriptTables.Checked
    End Sub
    Private Function ScriptTable(ByVal Tablename As String) As String
        Dim oTablesReader As SqlCeDataReader
        Dim query As String = String.Format(SELECTQUERYCOLUMNS, Tablename)
        Dim oSqlCeExplorerData As New SqlCeExplorerData
        Dim tableScript As New StringBuilder
        Dim nullable As String = "NOT NULL"
        oTablesReader = oSqlCeExplorerData.ExecuteQuery(query)
        tableScript.AppendFormat("CREATE TABLE {0} (", Tablename)
        tableScript.AppendLine()
        While oTablesReader.Read
            If oTablesReader("IS_NULLABLE") IsNot Nothing AndAlso oTablesReader("IS_NULLABLE").ToString.Equals("yes", StringComparison.CurrentCultureIgnoreCase) Then
                nullable = "NULL"
            End If
            tableScript.AppendFormat("[{0}] [{1}] ({2}) {3},", oTablesReader("COLUMN_NAME").ToString(), oTablesReader("DATA_TYPE").ToString(), oTablesReader("CHARACTER_MAXIMUM_LENGTH").ToString, nullable)
        End While
        tableScript.Replace(",", ")", tableScript.Length - 1, 1)
        tableScript.AppendLine()
        oTablesReader.Close()
        oTablesReader = Nothing
        oSqlCeExplorerData = Nothing
        Return tableScript.ToString()
    End Function
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Private Function GetScript() As String
        Dim result As New StringBuilder
        For Each Item As String In Me.chkListTables.CheckedItems
            result.AppendLine(String.Format("-- TABLE : {0} --", Item))
            result.Append(Me.ScriptTable(Item))
            result.AppendLine()
        Next
        Return result.ToString()
    End Function
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.chkListTables.CheckedItems.Count >= 1 Then
            Dim result As String = GetScript()
            If result.Length >= 1 Then


                If Me.radClipboard.Checked Then
                    Clipboard.SetText(result)
                    MessageBox.Show("Generated script copied to Clipboard", SqlCeMain.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    Return
                End If

                If Me.radToFileSystem.Checked Then
                    Using dlg As New SaveFileDialog
                        With dlg
                            .AddExtension = True
                            .CheckPathExists = True
                            .DefaultExt = "SQL"
                            .Filter = "SQL Files(*.sql)|*.sql|All Files(*.*)|*.*"
                            .FilterIndex = 0
                            .OverwritePrompt = True
                            .SupportMultiDottedExtensions = True
                            .ValidateNames = True
                            .Title = "Save Generated Script"
                            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                                Using sw As New IO.StreamWriter(.FileName)
                                    sw.WriteLine(result)
                                End Using
                                MessageBox.Show(String.Format("Generated script saved to {0}", .FileName), SqlCeMain.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.Close()
                            End If
                        End With

                    End Using
                    Return
                End If
            End If
        Else
            SQLCEExplorer.SqlCeExplorerUtility.ShowMessage("Please select a Table to script", Me.chkListTables)
        End If
    End Sub

    Private Sub frmGenerateScript_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadTables()
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
End Class