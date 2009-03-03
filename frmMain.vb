Imports System.IO
Imports System.Data.SqlServerCe
Public Class frmMain

    Private Const SELECTQUERYTABLES As String = "SELECT * FROM INFORMATION_SCHEMA.TABLES"
    Private Const SELECTQUERYCOLUMNS As String = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = '{0}')"
    Private Const SELECTQUERYINDEXES As String = "SELECT * FROM INFORMATION_SCHEMA.INDEXES WHERE (TABLE_NAME = '{0}')"

    Private m_IsConnected As Boolean = False
    Private m_OldConnectionString As String
    Private m_StartPos As Integer = 0
    Private m_currentNode As TreeNode
    Private m_SavedFileName As String = String.Empty
    Private m_IsSaved As Boolean = True

    Private Sub mniConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniConnect.Click, tsbConnect.Click
        ShowConnectDialog()
    End Sub
    Private Sub ShowConnectDialog()
        Dim oFrmConnect As New frmConnect
        AddHandler oFrmConnect.SqlCeDatabaseConnected, AddressOf oFrmConnect_SqlCeDatabaseConnected
        oFrmConnect.ShowDialog(Me)
    End Sub
    Private Sub oFrmConnect_SqlCeDatabaseConnected(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_IsConnected = True
        PopulateUI()
        Me.ManageToolbarButtons()
    End Sub

    Private Sub mnuFile_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile.DropDownOpening
        mniConnect.Enabled = Not m_IsConnected
        mniDisconnect.Enabled = m_IsConnected
        mniSaveAs.Enabled = m_IsConnected AndAlso Not txtQueryWindow.TextLength >= 1
        mniSave.Enabled = m_IsConnected AndAlso Not txtQueryWindow.TextLength >= 1
    End Sub

    Private Sub mniQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniQuit.Click
        Me.Close()
    End Sub

    Private Sub mniCreatSqlCeDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCreatSqlCeDatabase.Click, tsbCreateDb.Click
        Dim oFrmCreate As New frmCreate
        m_OldConnectionString = SqlCeMain.GetConnectionString
        AddHandler oFrmCreate.SqlCeDatabaseCreated, AddressOf oFrmCreate_SqlCeDatabaseCreated
        oFrmCreate.ShowDialog(Me)
    End Sub
    Private Sub oFrmCreate_SqlCeDatabaseCreated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'TODO: Ask confirmation to switch to new database?
        'Now it is automatically switching to the new db.
        PopulateUI()
        Me.ManageToolbarButtons()
    End Sub
    Private Sub PopulateUI()

        Dim dbNode As TreeNode
        Dim tableRootNode, tableNameNode As TreeNode
        Dim oSqlCeExplorerData As SqlCeExplorerData
        Dim oTablesReader As SqlCeDataReader
        Try

            Me.tvDatabaseExplorer.Nodes.Clear()

            dbNode = New TreeNode(Path.GetFileNameWithoutExtension(SqlCeMain.GetFileName), 0, 0)
            Me.Text = String.Format("{0} - {1}", SqlCeMain.APPLICATION_NAME, Path.GetFileNameWithoutExtension(SqlCeMain.GetFileName))
            dbNode.Tag = "#__DATABASE_ROOT_NODE__#"
            oSqlCeExplorerData = New SqlCeExplorerData
            oTablesReader = oSqlCeExplorerData.ExecuteQuery(SELECTQUERYTABLES)
            tableRootNode = New TreeNode("Tables", 1, 1)
            tableRootNode.Tag = "#__TABLE_ROOT_NODE__#"
            While oTablesReader.Read
                tableNameNode = New TreeNode(oTablesReader("TABLE_NAME").ToString, 2, 2)
                tableNameNode.Tag = tableNameNode.Text
                tableRootNode.Nodes.Add(tableNameNode)
            End While
            oTablesReader.Close()
            dbNode.Nodes.Add(tableRootNode)
            tvDatabaseExplorer.Nodes.Add(dbNode)
            m_IsConnected = True
        Catch ex As Exception
            SqlCeExplorerException.Show(ex)
        Finally
            oTablesReader = Nothing
        End Try
    End Sub
    Private Sub FillColumns(ByVal TableName As String, ByVal Node As TreeNode)
        If Node.Nodes IsNot Nothing AndAlso Node.Nodes.Count >= 1 Then
            Return
        End If
        Dim oTablesReader As SqlCeDataReader
        Dim query As String = String.Format(SELECTQUERYCOLUMNS, TableName)
        Dim oSqlCeExplorerData As New SqlCeExplorerData
        Dim columnsNode As New TreeNode("Columns")
        columnsNode.Tag = "#__COLUMNS__ROOT_NODE#"
        Dim columnNode As TreeNode
        oTablesReader = oSqlCeExplorerData.ExecuteQuery(query)

        While oTablesReader.Read
            columnNode = New TreeNode(String.Format("{0} - {1}", oTablesReader("COLUMN_NAME").ToString(), oTablesReader("DATA_TYPE").ToString()), 3, 3)
            columnNode.Tag = columnNode.Text
            columnsNode.Nodes.Add(columnNode)
        End While
        Node.Nodes.Add(columnsNode)
        oTablesReader.Close()
        oTablesReader = Nothing
        oSqlCeExplorerData = Nothing
    End Sub
    
    Private Sub tvDatabaseExplorer_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvDatabaseExplorer.BeforeExpand
        Select Case e.Node.Tag.ToString
            Case "#__TABLE_ROOT_NODE__#"
                For Each node As TreeNode In e.Node.Nodes
                    FillColumns(node.Text, node)
                Next
        End Select
    End Sub

    Private Sub tvDatabaseExplorer_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvDatabaseExplorer.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then

            ctxiCreateDatabase.Enabled = False
            ctxiRefersh.Enabled = False
            ctxiCreateTable.Enabled = False
            ctxiSelectAll.Enabled = False
            ctxiDropTable.Enabled = False

            Dim currentNode As TreeNode = tvDatabaseExplorer.GetNodeAt(e.Location)
            If currentNode IsNot Nothing Then
                m_currentNode = currentNode
                Select Case currentNode.ImageIndex
                    Case 0
                        'Database operations.
                        ctxiCreateDatabase.Enabled = True
                        ctxiRefersh.Enabled = True
                        ctxiCreateTable.Enabled = False
                        ctxiSelectAll.Enabled = False
                        ctxiDropTable.Enabled = False
                    Case 1
                        'Tables operations
                        ctxiCreateDatabase.Enabled = False
                        ctxiRefersh.Enabled = True
                        ctxiCreateTable.Enabled = True
                        ctxiSelectAll.Enabled = False
                        ctxiDropTable.Enabled = False
                    Case 2
                        'Table operations
                        ctxiCreateDatabase.Enabled = False
                        ctxiDropTable.Enabled = True
                        ctxiRefersh.Enabled = True
                        ctxiCreateTable.Enabled = False
                        ctxiSelectAll.Enabled = True
                    Case 3
                        'Table operations - Column level
                        ctxiDropTable.Enabled = False
                        ctxiCreateDatabase.Enabled = False
                        ctxiRefersh.Enabled = True
                        ctxiCreateTable.Enabled = False
                        ctxiSelectAll.Enabled = False
                End Select

            End If
        End If
    End Sub

    Private Sub ctxiRefersh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiRefersh.Click
        PopulateUI()
        If m_currentNode IsNot Nothing Then
            m_currentNode.Collapse()
            m_currentNode.ExpandAll()
        End If
        Me.ManageToolbarButtons()
    End Sub

    Private Sub mniDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniDisconnect.Click, tsbDisconnect.Click
        m_IsConnected = False
        SqlCeMain.ClearConnectionString()
        tvDatabaseExplorer.Nodes.Clear()
        Me.Text = SqlCeMain.APPLICATION_NAME
        Me.ManageToolbarButtons()
    End Sub

    Private Sub mniHomePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniHomePage.Click, tsbWeb.Click
        Dim url As String = "http://www.codeplex.com/sqlceexplorer"
        Process.Start(url)
    End Sub

    Private Sub ctxiCreateTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiCreateTable.Click
        Dim oFrmCreateTable As New frmCreateTable
        AddHandler oFrmCreateTable.CreateTableQueryFormed, AddressOf oFrmCreateTable_CreateTableQueryFormed
        oFrmCreateTable.ShowDialog(Me)
    End Sub
    Private Sub oFrmCreateTable_CreateTableQueryFormed(ByVal sender As Object, ByVal e As EventArgs)
        Me.txtQueryWindow.Text = SqlCeMain.GetCurrentQuery
        Me.txtQueryWindow.SelectAll()
        Me.ExecuteQuery()
    End Sub
    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not m_IsSaved Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save changes to Untitled?", SqlCeMain.APPLICATION_NAME, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.Yes Then
                SaveAs_Click()
                If Not m_IsSaved Then
                    e.Cancel = True
                End If
            ElseIf result = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.tcMain.TabPages.Remove(Me.tpGrid)
        'TODO: Taking too much time to load the Config stuff.
        Dim CurrentConfig As New SqlCeConfig
        Try
            CurrentConfig.ReadConfig()
            If CurrentConfig.ShowConnectDialogAtStartUp Then
                Me.Show()
                ShowConnectDialog()
            End If
            If CurrentConfig.FontName IsNot Nothing Then
                Me.txtQueryWindow.Font = New Font(CurrentConfig.FontName, Convert.ToSingle(CurrentConfig.FontSize))
            End If
        Catch ex As Exception
            'Do nothing
        Finally
            CurrentConfig = Nothing
        End Try

        Me.Text = SqlCeMain.APPLICATION_NAME
        Me.tvDatabaseExplorer.Focus()
        Me.txtQueryWindow.Focus()
        Me.ManageToolbarButtons()
    End Sub

    Private Sub ctxiCreateDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiCreateDatabase.Click
        Dim oFrmCreate As New frmCreate
        m_OldConnectionString = SqlCeMain.GetConnectionString
        AddHandler oFrmCreate.SqlCeDatabaseCreated, AddressOf oFrmCreate_SqlCeDatabaseCreated
        oFrmCreate.ShowDialog(Me)
    End Sub

    Private Sub ctxiSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiSelectAll.Click
        If m_currentNode IsNot Nothing Then
            Me.txtQueryWindow.SelectedText = String.Format("SELECT * FROM [{0}]", m_currentNode.Text)
            Me.txtQueryWindow.SelectAll()
            Me.ExecuteQuery()
        End If
    End Sub

    Private Sub mniSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSaveAs.Click
        Me.SaveAs_Click()
    End Sub

    Private Sub mniFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniFind.Click, tsbFind.Click
        Dim ofrmFind As New frmFind
        m_StartPos = 0
        ofrmFind.StartPosition = FormStartPosition.Manual
        ofrmFind.Location = New Point(Me.Left + 200, Me.Top + 100)
        AddHandler ofrmFind.FindText, AddressOf ofrmFind_FindText
        ofrmFind.Show(Me)
    End Sub
    Private Sub ofrmFind_FindText(ByVal sender As Object, ByVal e As FindEventArgs)
        Dim txtFind As String = e.Text
        Dim compareType As System.StringComparison = StringComparison.InvariantCultureIgnoreCase
        If e.MatchCase Then
            compareType = StringComparison.InvariantCulture
        End If
        If txtFind.Length >= 1 Then
            m_StartPos = Me.txtQueryWindow.Text.IndexOf(txtFind, m_StartPos, compareType)
            If m_StartPos >= 0 Then
                Me.txtQueryWindow.SelectionStart = m_StartPos
                Me.txtQueryWindow.SelectionLength = txtFind.Length
                m_StartPos += txtFind.Length
            Else
                SqlCeExplorerUtility.ShowMessage(String.Format("Cannot find ""{0}"" ", txtFind), Nothing)
                m_StartPos = 0
            End If
        End If
    End Sub

    Private Sub mniParse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniParse.Click, tsbParse.Click
        Dim oSqlCeExplorerData As New SqlCeExplorerData
        Dim query As String
        If Me.txtQueryWindow.SelectionLength <= 0 Then
            query = Me.txtQueryWindow.Text
        Else
            query = Me.txtQueryWindow.SelectedText
        End If
        Dim RecordsAffected As Integer = 0
        Dim sqlResult As Boolean = oSqlCeExplorerData.ParseQuery(query)

        tcMain.TabPages.Remove(Me.tpGrid)

        If Not sqlResult Then
            'Query failed
            Me.tcMain.SelectedTab = Me.tpText
            Me.txtOutput.Text = oSqlCeExplorerData.ParseMessage
            Me.txtOutput.ForeColor = Color.Red
            Me.txtOutput.SelectionLength = 0
            Me.dgvResults.DataSource = Nothing
        Else
            'Insert, Update, or delete.
            Me.tcMain.SelectedTab = Me.tpText
            Me.txtOutput.ForeColor = Color.Black
            Me.txtOutput.Text = oSqlCeExplorerData.ParseMessage
            Me.dgvResults.DataSource = Nothing
            Me.txtOutput.SelectionLength = 0
        End If
    End Sub

    Private Sub mniExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniExecute.Click, tsbExecute.Click
        Me.ExecuteQuery()
    End Sub
    Private Sub ExecuteQuery()
        Dim oSqlCeExplorerData As New SqlCeExplorerData
        Dim query As String
        If Me.txtQueryWindow.SelectionLength <= 0 Then
            query = Me.txtQueryWindow.Text
        Else
            query = Me.txtQueryWindow.SelectedText
        End If
        Dim RecordsAffected As Integer = 0
        Dim SqlCeReader As SqlCeDataReader = Nothing
        If oSqlCeExplorerData.ParseQuery(query) Then
            SqlCeReader = oSqlCeExplorerData.ExecuteQuery(query)
            If SqlCeReader IsNot Nothing Then
                RecordsAffected = SqlCeReader.RecordsAffected
            End If
        End If

        Select Case RecordsAffected
            Case 0
                'Query failed
                tcMain.TabPages.Remove(Me.tpGrid)
                Me.tcMain.SelectedTab = Me.tpText
                Me.txtOutput.Text = oSqlCeExplorerData.ParseMessage
                Me.txtOutput.ForeColor = Color.Red
                Me.txtOutput.SelectionLength = 0
            Case -1
                'Select statement
                Me.tcMain.TabPages.Add(Me.tpGrid)
                Me.tcMain.SelectedTab = Me.tpGrid
                Me.txtOutput.ForeColor = Color.Black
                Me.txtOutput.Text = oSqlCeExplorerData.ParseMessage
                Dim results As DataTable = Nothing
                If SqlCeReader IsNot Nothing Then
                    results = oSqlCeExplorerData.Fill(SqlCeReader)
                End If
                If results IsNot Nothing AndAlso results.Rows.Count >= 1 Then
                    Me.dgvResults.DataSource = results
                Else
                    Me.tcMain.TabPages.Remove(Me.tpGrid)
                    Me.tcMain.SelectedTab = Me.tpText
                End If

            Case Else
                'Insert, Update, or delete.
                tcMain.TabPages.Remove(Me.tpGrid)
                Me.tcMain.SelectedTab = Me.tpText
                Me.txtOutput.ForeColor = Color.Black
                Me.txtOutput.Text = oSqlCeExplorerData.ParseMessage
                Me.dgvResults.DataSource = Nothing
                Me.txtOutput.SelectionLength = 0
        End Select
        PopulateUI()
    End Sub
    Private Sub mnuOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptions.Click, tsbOptions.Click
        Dim ofrmOptions As New frmOptions
        ofrmOptions.CurrentFont = Me.txtQueryWindow.Font
        ofrmOptions.IsConnected = Me.m_IsConnected
        ofrmOptions.ShowDialog(Me)
    End Sub

    Private Sub mnuEdit_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.DropDownOpening
        mniUndo.Enabled = Me.txtQueryWindow.CanUndo
        mniCopy.Enabled = Me.txtQueryWindow.SelectionLength >= 1
        mniCut.Enabled = Me.txtQueryWindow.SelectionLength >= 1
        mniClearAll.Enabled = Me.txtQueryWindow.SelectionLength >= 1
        mniPaste.Enabled = Clipboard.ContainsText
        mniSelectAll.Enabled = Me.txtQueryWindow.TextLength >= 1
        mniFind.Enabled = Me.txtQueryWindow.TextLength >= 1
    End Sub

    Private Sub mniUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniUndo.Click
        Me.txtQueryWindow.Undo()
    End Sub

    Private Sub mniCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCopy.Click, ctxiCopy.Click
        Clipboard.SetText(Me.txtQueryWindow.SelectedText)
    End Sub

    Private Sub mniCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCut.Click, ctxiCut.Click
        Clipboard.SetText(Me.txtQueryWindow.SelectedText)
        Me.txtQueryWindow.SelectedText = String.Empty
    End Sub

    Private Sub mniPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniPaste.Click, ctxiPaste.Click
        Me.txtQueryWindow.SelectedText = Clipboard.GetText
    End Sub

    Private Sub mniSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSelectAll.Click, ctxiSelectAllEditor.Click
        Me.txtQueryWindow.SelectAll()
    End Sub

    Private Sub mniClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniClearAll.Click
        Me.txtQueryWindow.SelectedText = String.Empty
    End Sub

    Private Sub mnuQuery_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQuery.DropDownOpening
        mniParse.Enabled = Me.txtQueryWindow.TextLength >= 1 AndAlso m_IsConnected
        mniExecute.Enabled = Me.txtQueryWindow.TextLength >= 1 AndAlso m_IsConnected
        mniClearResults.Enabled = Me.txtQueryWindow.TextLength >= 1 AndAlso m_IsConnected
    End Sub
    Private Sub mniSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSave.Click, tsbSaveAs.Click
        If m_SavedFileName.Length >= 1 Then
            WriteFile(m_SavedFileName)
        Else
            SaveAs_Click()
        End If
    End Sub
    Private Sub SaveAs_Click()
        Using oSaveFileDialog As New SaveFileDialog
            With oSaveFileDialog
                .AddExtension = True
                .OverwritePrompt = True
                .CheckPathExists = True
                .DefaultExt = "SQL"
                .Filter = "SQL Files(*.sql)|*.sql"
                .SupportMultiDottedExtensions = True
                .Title = String.Format("Save SQL File - {0}", SqlCeMain.APPLICATION_NAME)
                .ValidateNames = True
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    WriteFile(.FileName)
                    m_SavedFileName = .FileName
                    m_IsSaved = True
                End If
            End With
        End Using
    End Sub
    Private Sub WriteFile(ByVal Filename As String)
        Try
            Using sw As New StreamWriter(Filename)
                For Each line As String In Me.txtQueryWindow.Lines
                    sw.WriteLine(line)
                Next
                sw.Flush()
                sw.Close()
                m_IsSaved = True
            End Using
        Catch ex As Exception
            SqlCeExplorerException.Show(ex)
        End Try
    End Sub

    Private Sub mniOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniOpenFile.Click
        If Not m_IsSaved Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save changes to Untitled?", SqlCeMain.APPLICATION_NAME, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.Yes Then
                SaveAs_Click()
                If Not m_IsSaved Then
                    Return
                End If
            ElseIf result = Windows.Forms.DialogResult.No Then
                Me.txtQueryWindow.Text = String.Empty
            Else
                Return
            End If
        End If
        Open_Click()
    End Sub
    Private Sub Open_Click()
        Using oOpenFileDialog = New OpenFileDialog
            With oOpenFileDialog
                .AddExtension = True
                .CheckFileExists = True
                .DefaultExt = "SQL"
                .Filter = "SQL Files(*.sql)|*.sql|All Files(*.*)|*.*"
                .Multiselect = False
                .ReadOnlyChecked = False
                .ShowReadOnly = False
                .SupportMultiDottedExtensions = True
                .ValidateNames = True
                .Title = String.Format("Open SQL File - {0}", SqlCeMain.APPLICATION_NAME)
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    OpenFile(.FileName)
                    m_SavedFileName = .FileName
                End If
            End With
        End Using
    End Sub
    Private Sub OpenFile(ByVal Filename As String)
        Using sw As New StreamReader(Filename)
            Me.txtQueryWindow.Text = sw.ReadToEnd
        End Using
    End Sub

    Private Sub txtQueryWindow_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQueryWindow.TextChanged
        If txtQueryWindow.TextLength >= 1 Then
            m_IsSaved = False
        End If
    End Sub

    Private Sub ctxEditor_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxEditor.Opening
        ctxiParse.Enabled = Me.txtQueryWindow.TextLength >= 1 AndAlso m_IsConnected
        ctxiExecute.Enabled = Me.txtQueryWindow.TextLength >= 1 AndAlso m_IsConnected
        ctxiClear.Enabled = Me.txtQueryWindow.TextLength >= 1 AndAlso m_IsConnected
        ctxiCopy.Enabled = Me.txtQueryWindow.SelectionLength >= 1
        ctxiCut.Enabled = Me.txtQueryWindow.SelectionLength >= 1
        ctxiPaste.Enabled = Clipboard.ContainsText
        ctxiSelectAllEditor.Enabled = Me.txtQueryWindow.TextLength >= 1
    End Sub

    Private Sub ctxiOutputCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiOutputCopy.Click
        Clipboard.SetText(Me.txtOutput.SelectedText)
    End Sub

    Private Sub ctxiOutputCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiOutputCut.Click
        Clipboard.SetText(Me.txtOutput.SelectedText)
        Me.txtOutput.SelectedText = String.Empty
    End Sub

    Private Sub ctxiOutputSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiOutputSelectAll.Click
        Me.txtOutput.SelectAll()
    End Sub

    Private Sub ctxOutputWindow_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxOutputWindow.Opening
        Me.ctxiOutputCopy.Enabled = Me.txtOutput.SelectionLength >= 1
        Me.ctxiOutputCut.Enabled = Me.txtOutput.SelectionLength >= 1
        Me.ctxiOutputSelectAll.Enabled = Me.txtOutput.TextLength >= 1
    End Sub
    Private Sub ManageToolbarButtons()
        Me.tsbConnect.Enabled = Not m_IsConnected
        Me.tsbDisconnect.Enabled = m_IsConnected
        Me.tsbCreateDb.Enabled = True
        Me.tsbExecute.Enabled = m_IsConnected AndAlso Me.txtQueryWindow.TextLength >= 1
        Me.tsbParse.Enabled = m_IsConnected AndAlso Me.txtQueryWindow.TextLength >= 1
        Me.tsbFind.Enabled = Me.txtQueryWindow.TextLength >= 1
        Me.tsbSaveAs.Enabled = Me.txtQueryWindow.TextLength >= 1
    End Sub

    Private Sub mniAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAbout.Click
        Dim ofrmAbout As New frmAbout
        ofrmAbout.ShowDialog(Me)
    End Sub

    Private Sub ctxiDropTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiDropTable.Click
        If m_currentNode IsNot Nothing Then
            If MessageBox.Show(String.Format("This will permanently delete the ""{0}"" table from the database.{1}Are you sure want to continue?", m_currentNode.Text, Environment.NewLine), SqlCeMain.APPLICATION_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Me.txtQueryWindow.SelectedText = String.Format("DROP TABLE [{0}]", m_currentNode.Text)
                Me.txtQueryWindow.SelectAll()
                Me.ExecuteQuery()
            End If
        End If
    End Sub
End Class
