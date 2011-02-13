Imports System.IO
Imports System.Data.SqlServerCe
Imports System.Drawing.Printing
Imports System.Text

Public Class frmMain

    Private Const SELECTQUERYTABLES As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES"
    Private Const SELECTQUERYCOLUMNS As String = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = '{0}')"
    Private Const SELECTQUERYINDEXES As String = "SELECT INDEX_NAME, [UNIQUE], [CLUSTERED] FROM INFORMATION_SCHEMA.INDEXES WHERE (TABLE_NAME = '{0}')"
    Private Const SELECTQUERYRELATIONSHIPS As String = "SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME = '{0}' AND " & _
    "CONSTRAINT_NAME IN (SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS)"

    Private m_IsConnected As Boolean = False
    Private m_OldConnectionString As String
    Private m_StartPos As Integer = 0
    Private m_currentNode As TreeNode
    Private m_SavedFileName As String = String.Empty
    Private m_IsSaved As Boolean = True
    Private m_List As List(Of String)
    Private m_RecentItems As Integer
    Private m_StartIndex As Integer = 0
    Private m_Delimeter() As Char = {";"}
    Private m_AutoCompleteEnabled = False

    Private Sub mniConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniConnect.Click
        ShowConnectDialog()
    End Sub
    Private Sub ShowConnectDialog()
        Dim oFrmConnect As New frmConnect
        AddHandler oFrmConnect.SqlCeDatabaseConnected, AddressOf oFrmConnect_SqlCeDatabaseConnected
        oFrmConnect.ShowDialog(Me)
    End Sub
    Private Sub ShowConnectDialog(ByVal filename As String)
        Dim oFrmConnect As New frmConnect(filename)
        AddHandler oFrmConnect.SqlCeDatabaseConnected, AddressOf oFrmConnect_SqlCeDatabaseConnected
        oFrmConnect.ShowDialog(Me)
    End Sub
    Private Sub oFrmConnect_SqlCeDatabaseConnected(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_IsConnected = True
        PopulateUI()
        Me.UpdateStatusUI(Constants.DATABASE_CONNECTION_SUCCESSFULL)
        SqlCeExplorerUtility.AddOrDeleteItem(SqlCeMain.GetFileName)
    End Sub

    Private Sub mnuFile_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile.DropDownOpening
        mniConnect.Enabled = Not m_IsConnected
        mniDisconnect.Enabled = m_IsConnected
        mniSaveAs.Enabled = m_IsConnected AndAlso txtQueryWindow.TextLength >= 1
        mniSave.Enabled = m_IsConnected AndAlso txtQueryWindow.TextLength >= 1
        mniRecentFiles.Enabled = m_List IsNot Nothing AndAlso m_List.Count >= 1
        mniPrint.Enabled = Me.txtQueryWindow.TextLength >= 1
        mnuImport.Enabled = m_IsConnected
        mnuExport.Enabled = m_IsConnected
    End Sub

    Private Sub mniQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniQuit.Click
        Me.Close()
    End Sub

    Private Sub mniCreatSqlCeDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiCreateSeDatabase.Click, ctxiCreateDatabase.Click
        Dim oFrmCreate As New frmCreate
        m_OldConnectionString = SqlCeMain.GetConnectionString
        AddHandler oFrmCreate.SqlCeDatabaseCreated, AddressOf oFrmCreate_SqlCeDatabaseCreated
        oFrmCreate.ShowDialog(Me)
    End Sub
    Private Sub oFrmCreate_SqlCeDatabaseCreated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'TODO: Ask confirmation to switch to new database?
        'Now it is automatically switching to the new db.
        Me.UpdateStatusUI(Constants.DATABASE_CREATION_SUCCESSFUL)
        PopulateUI()
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
            If oTablesReader IsNot Nothing Then
                While oTablesReader.Read
                    tableNameNode = New TreeNode(oTablesReader("TABLE_NAME").ToString, 4, 4)
                    tableNameNode.Tag = tableNameNode.Text
                    tableRootNode.Nodes.Add(tableNameNode)
                End While
                oTablesReader.Close()
            End If
            dbNode.Nodes.Add(tableRootNode)
            tvDatabaseExplorer.Nodes.Add(dbNode)
            m_IsConnected = True
        Catch ex As Exception
            SqlCeExplorerException.Show(ex)
        Finally
            oTablesReader = Nothing
        End Try
    End Sub


    Private Sub tvDatabaseExplorer_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvDatabaseExplorer.BeforeExpand
        Select Case e.Node.Tag.ToString
            Case "#__TABLE_ROOT_NODE__#"
                For Each node As TreeNode In e.Node.Nodes
                    Me.FillColumns(node.Text, node)
                    Me.FillIndexes(node.Text, node)
                    Me.FillRelationShips(node.Text, node)
                Next
        End Select
    End Sub

    Private Sub tvDatabaseExplorer_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvDatabaseExplorer.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then

            ctxiRefersh.Enabled = True
            ctxiCreateTable.Enabled = False
            ctxiSelectAll.Enabled = False
            ctxiDeleteAllRows.Enabled = False
            ctxiDropTable.Enabled = False
            ctxiManageColumns.Enabled = False
            CtxiManageIndexes.Enabled = False
            CtxiAddNewColumn.Enabled = True
            ctxiDropaColumn.Enabled = False
            ctxiChangeColDataType.Enabled = False
            ctxiCreateNewIndex.Enabled = False
            ctxiDropAnIndex.Enabled = False
            ctxiGenerateScript.Enabled = False
            ctxiRefersh.Enabled = m_IsConnected
            ctxiDatabaseOptions.Enabled = True
            CtxiManageRelationships.Enabled = False
            ctxiEditAllRows.Enabled = False
            Dim currentNode As TreeNode = tvDatabaseExplorer.GetNodeAt(e.Location)
            If currentNode IsNot Nothing Then
                m_currentNode = currentNode
                Select Case currentNode.ImageIndex
                    Case 0
                        ctxiGenerateScript.Enabled = True
                        ctxiDatabaseOptions.Enabled = m_IsConnected
                    Case 1
                        ctxiCreateTable.Enabled = True
                        ctxiDropTable.Enabled = True
                        ctxiDatabaseOptions.Enabled = False
                    Case 4
                        ctxiDatabaseOptions.Enabled = False
                        ctxiCreateTable.Enabled = True
                        ctxiDropTable.Enabled = True
                        ctxiSelectAll.Enabled = True
                        ctxiDeleteAllRows.Enabled = True
                        ctxiManageColumns.Enabled = True
                        CtxiAddNewColumn.Enabled = True
                        ctxiDropaColumn.Enabled = True
                        ctxiChangeColDataType.Enabled = True
                        CtxiManageIndexes.Enabled = True
                        ctxiCreateNewIndex.Enabled = True
                        ctxiDropAnIndex.Enabled = True
                        CtxiManageRelationships.Enabled = True
                        ctxiEditAllRows.Enabled = True
                        'Case 2, 5
                        '    ctxiDatabaseOptions.Enabled = False
                        '    ctxiManageColumns.Enabled = False
                        '    CtxiAddNewColumn.Enabled = False
                        '    ctxiDropaColumn.Enabled = False
                        '    ctxiChangeColDataType.Enabled = True
                        'Case 3, 6
                        '    ctxiDatabaseOptions.Enabled = False
                        '    CtxiManageIndexes.Enabled = False
                        '    ctxiCreateNewIndex.Enabled = False
                        '    ctxiDropAnIndex.Enabled = False
                    Case 7

                End Select
            End If
        End If
    End Sub

    Private Sub ctxiRefersh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiRefersh.Click, mnuRefresh.Click
        PopulateUI()
    End Sub

    Private Sub mniDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniDisconnect.Click
        m_IsConnected = False
        SqlCeMain.ClearConnectionString()
        tvDatabaseExplorer.Nodes.Clear()
        Me.Text = SqlCeMain.APPLICATION_NAME

    End Sub
    Private Sub GotoSqlCeExplorerHome()
        Dim url As String = "http://sqlceexplorer.codeplex.com/"
        Process.Start(url)
    End Sub
    Private Sub mniHomePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniHomePage.Click
        Me.GotoSqlCeExplorerHome()
    End Sub

    Private Sub ctxiCreateTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiCreateTable.Click, mnuManageTableCreate.Click
        Dim oFrmCreateTable As New frmCreateTable
        AddHandler oFrmCreateTable.CreateTableQueryFormed, AddressOf oFrmCreateTable_CreateTableQueryFormed
        oFrmCreateTable.ShowDialog(Me)
    End Sub
    Private Sub oFrmCreateTable_CreateTableQueryFormed(ByVal sender As Object, ByVal e As EventArgs)
        Me.txtQueryWindow.Text = SqlCeMain.GetCurrentQuery
        Me.txtQueryWindow.SelectAll()
        Me.ExecuteQuery()
        Me.PopulateUI()
        Me.UpdateStatusUI(Constants.TABLE_QUERY_CREATED)
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
    'AutoSuggest related
    Private WordBuffer As List(Of String)
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = SqlCeMain.APPLICATION_NAME
        Me.tcMain.SelectedTab = Me.tpText

        Dim CurrentConfig As New SqlCeConfig
        Try
            CurrentConfig.ReadConfig()
            m_RecentItems = Integer.Parse(CurrentConfig.RecentItemsCount)
            If CurrentConfig.EnableRecentItems Then
                Me.LoadRecentItems()
            End If
            If CurrentConfig.ShowConnectDialogAtStartUp Then
                Me.Show()
                If Me.IsCommandLineArgumentsExists Then
                    ShowConnectDialog(My.Application.CommandLineArgs(0))
                Else
                    ShowConnectDialog()
                End If
            End If
            If Me.IsCommandLineArgumentsExists Then
                Me.Show()
                ShowConnectDialog(My.Application.CommandLineArgs(0))
            End If
            If CurrentConfig.FontName IsNot Nothing Then
                Me.txtQueryWindow.Font = New Font(CurrentConfig.FontName, Convert.ToSingle(CurrentConfig.FontSize))
            End If

            Me.txtQueryWindow.EnableSyntaxHighlighting = CurrentConfig.EnableSyntaxHighlight
            Me.txtQueryWindow.HighlightComments = CurrentConfig.EnableCommentHighlight
            Me.txtQueryWindow.HighlightVariables = CurrentConfig.EnableVariableHighlight

            Me.txtQueryWindow.KeywordColor = Color.FromArgb(CurrentConfig.KeywordColor)
            Me.txtQueryWindow.CommentsColor = Color.FromArgb(CurrentConfig.CommentsColor)
            Me.txtQueryWindow.VariableColor = Color.FromArgb(CurrentConfig.VariableColor)
            Me.txtQueryWindow.OperatorColor = Color.FromArgb(CurrentConfig.FunctionsColor)

            Me.m_AutoCompleteEnabled = CurrentConfig.EnableAutoComplete

        Catch ex As Exception
            'Do nothing
        Finally
            CurrentConfig = Nothing
        End Try

        Me.tvDatabaseExplorer.Focus()
        Me.txtQueryWindow.Focus()

        'Auto Suggestion
        If Me.m_AutoCompleteEnabled Then
            Me.WordBuffer = New List(Of String)
            Me.WordBuffer.AddRange(Me.txtQueryWindow.Keywords)
            Me.WordBuffer.AddRange(Me.txtQueryWindow.Operators)
        End If
    End Sub

    Private Function IsCommandLineArgumentsExists() As Boolean
        Return My.Application.CommandLineArgs.Count >= 1 AndAlso File.Exists(My.Application.CommandLineArgs(0))
    End Function

    Private Sub LoadRecentItems()
        Dim recentFile As ToolStripMenuItem
        If m_List Is Nothing AndAlso SqlCeExplorerUtility.GetRecentItems IsNot Nothing Then
            m_List = SqlCeExplorerUtility.GetRecentItems
            If m_List.Count > m_RecentItems Then
                m_List = m_List.GetRange(1, m_RecentItems)
            End If
        End If
        If m_List IsNot Nothing Then
            For Each Item As String In m_List
                recentFile = New ToolStripMenuItem(Item)
                AddHandler recentFile.Click, AddressOf recentFile_Click
                mniRecentFiles.DropDownItems.Add(recentFile)
                recentFile = Nothing
            Next
        End If
    End Sub

    Private Sub recentFile_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim recentFile As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        If IO.File.Exists(recentFile.Text) Then
            ShowConnectDialog(recentFile.Text)
        Else
            If MessageBox.Show("Specified file not exits. Would you like to remove it from this list?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                mniRecentFiles.DropDownItems.Remove(recentFile)
                SqlCeExplorerUtility.ClearRecentItems(recentFile.Text)
            End If
        End If
    End Sub

    Private Sub ctxiCreateDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oFrmCreate As New frmCreate
        m_OldConnectionString = SqlCeMain.GetConnectionString
        AddHandler oFrmCreate.SqlCeDatabaseCreated, AddressOf oFrmCreate_SqlCeDatabaseCreated
        oFrmCreate.ShowDialog(Me)
    End Sub

    Private Sub ctxiSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiSelectAll.Click, mnuManageTableSelectAll.Click
        If m_currentNode IsNot Nothing Then
            Me.txtQueryWindow.SelectAll()
            Me.txtQueryWindow.SelectedText = String.Format("SELECT * FROM [{0}]", m_currentNode.Text)
            Me.txtQueryWindow.SelectAll()
            Me.ExecuteQuery()
        End If
    End Sub

    Private Sub mniSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSaveAs.Click
        Me.SaveAs_Click()
    End Sub

    Private Sub mniFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniFind.Click
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

    Private Sub mniParse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniParse.Click, ctxiParse.Click
        If m_IsConnected Then
            Dim oSqlCeExplorerData As New SqlCeExplorerData
            Dim query As String
            If Me.txtQueryWindow.SelectionLength <= 0 Then
                query = Me.txtQueryWindow.Text
            Else
                query = Me.txtQueryWindow.SelectedText
            End If
            Dim RecordsAffected As Integer = 0
            Dim sqlResult As Boolean = oSqlCeExplorerData.ParseQuery(query)

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
        End If
    End Sub
    Private Function IsMultipleQuery() As Boolean
        Dim tempQuery As String = IIf(Me.txtQueryWindow.SelectionLength >= 1, Me.txtQueryWindow.SelectedText, Me.txtQueryWindow.Text)
        Return tempQuery.Split(Me.m_Delimeter, StringSplitOptions.RemoveEmptyEntries).Length >= 1
    End Function
    Private Sub mniExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniExecute.Click, ctxiExecute.Click
        If m_IsConnected Then
            If IsMultipleQuery() Then
                Me.ExecuteMultipleQuery()
            Else
                Me.ExecuteQuery()
            End If
        End If
    End Sub
    Private Sub ExecuteMultipleQuery()
        Dim oSqlCeExplorerData As New SqlCeExplorerData
        Dim dataReaders As List(Of SqlCeDataReader) =
            oSqlCeExplorerData.ExecuteMultipleQueries(IIf(Me.txtQueryWindow.SelectionLength >= 1, Me.txtQueryWindow.SelectedText, Me.txtQueryWindow.Text).
                                                      Split(Me.m_Delimeter, StringSplitOptions.RemoveEmptyEntries))
        Dim dataTables As New List(Of DataTable)
        Dim RecordsAffected As Integer = 0
        For Each SqlCeReader As SqlCeDataReader In dataReaders
            If SqlCeReader IsNot Nothing Then
                RecordsAffected = SqlCeReader.RecordsAffected
                Select Case RecordsAffected
                    Case 0
                        'Query failed
                        Me.tcMain.SelectedTab = Me.tpText
                        Me.txtOutput.Text = oSqlCeExplorerData.ParseMessage
                        Me.txtOutput.ForeColor = Color.Red
                        Me.txtOutput.SelectionLength = 0
                    Case -1
                        'Select statement

                        Me.txtOutput.ForeColor = Color.Black
                        Me.txtOutput.Text = oSqlCeExplorerData.ParseMessage
                        Dim results As DataTable = Nothing
                        If SqlCeReader IsNot Nothing Then
                            results = oSqlCeExplorerData.Fill(SqlCeReader)
                        End If
                        If results IsNot Nothing AndAlso results.Rows.Count >= 1 Then
                            Me.dgvResults.DataSource = results
                            Me.tcMain.SelectedTab = Me.tpGrid
                        Else
                            Me.tcMain.SelectedTab = Me.tpText
                            Me.dgvResults.DataSource = Nothing
                        End If

                    Case Else
                        'Insert, Update, or delete.
                        Me.tcMain.SelectedTab = Me.tpText
                        Me.txtOutput.ForeColor = Color.Black
                        Me.txtOutput.Text = oSqlCeExplorerData.ParseMessage
                        Me.dgvResults.DataSource = Nothing
                        Me.txtOutput.SelectionLength = 0
                End Select
            End If
        Next
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
                Me.tcMain.SelectedTab = Me.tpText
                Me.txtOutput.Text = oSqlCeExplorerData.ParseMessage
                Me.txtOutput.ForeColor = Color.Red
                Me.txtOutput.SelectionLength = 0
            Case -1
                'Select statement

                Me.txtOutput.ForeColor = Color.Black
                Me.txtOutput.Text = oSqlCeExplorerData.ParseMessage
                Dim results As DataTable = Nothing
                If SqlCeReader IsNot Nothing Then
                    results = oSqlCeExplorerData.Fill(SqlCeReader)
                End If
                If results IsNot Nothing AndAlso results.Rows.Count >= 1 Then
                    Me.dgvResults.DataSource = results
                    Me.tcMain.SelectedTab = Me.tpGrid
                Else
                    Me.tcMain.SelectedTab = Me.tpText
                    Me.dgvResults.DataSource = Nothing
                End If

            Case Else
                'Insert, Update, or delete.
                Me.tcMain.SelectedTab = Me.tpText
                Me.txtOutput.ForeColor = Color.Black
                Me.txtOutput.Text = oSqlCeExplorerData.ParseMessage
                Me.dgvResults.DataSource = Nothing
                Me.txtOutput.SelectionLength = 0
        End Select
    End Sub
    Private Sub mnuOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptions.Click
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
        'Clipboard.SetText(Me.txtQueryWindow.SelectedText)
        Me.txtQueryWindow.Copy()
    End Sub

    Private Sub mniCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCut.Click, ctxiCut.Click
        Me.txtQueryWindow.Cut()
    End Sub

    Private Sub mniPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniPaste.Click, ctxiPaste.Click
        If Clipboard.ContainsText() Then
            Me.txtQueryWindow.Paste()
            Me.txtQueryWindow.DoSyntaxHighlight()
        End If
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
        mniQueryBuilder.Enabled = m_IsConnected

        mnuManageTable.Enabled = m_IsConnected
        mnuManageCols.Enabled = m_IsConnected
        mnuManageIndexs.Enabled = m_IsConnected
        mnuManageRelations.Enabled = m_IsConnected
        mnuRefresh.Enabled = m_IsConnected
    End Sub
    Private Sub mniSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSave.Click
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
                .FileName = "*.sql"
                .AddExtension = True
                .Filter = "SQL Files(*.sql)|*.sql|SQL CE Files|*.sqlce"
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
                .FileName = "*.sql"
                .AddExtension = True
                .Filter = "SQL Files(*.sql)|*.sql|SQLCE Files|*.sqlce|All Files(*.*)|*.*"
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
        ctxiDeleteSelected.Enabled = Me.txtQueryWindow.SelectionLength >= 1
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


    Private Sub mniAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAbout.Click
        Dim ofrmAbout As New frmAbout
        ofrmAbout.ShowDialog(Me)
    End Sub

    Private Sub ctxiDropTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiDropTable.Click, mnuManageTableDelete.Click
        Dim ofrmDeleteTable As frmDeleteTable
        If m_currentNode IsNot Nothing Then
            ofrmDeleteTable = New frmDeleteTable(m_currentNode.Text)
        Else
            ofrmDeleteTable = New frmDeleteTable
        End If
        AddHandler ofrmDeleteTable.DeleteTableQueryFormed, AddressOf ofrmDeleteTable_DeleteTableQueryFormed
        ofrmDeleteTable.ShowDialog(Me)
    End Sub
    Private Sub ofrmDeleteTable_DeleteTableQueryFormed(ByVal sender As Object, ByVal e As EventArgs)
        Me.txtQueryWindow.SelectAll()
        Me.txtQueryWindow.SelectedText = SqlCeMain.GetCurrentQuery
        Me.txtQueryWindow.SelectAll()
        Me.ExecuteQuery()
    End Sub
    Private Sub ExecuteCommand(ByVal Command As ToolStripButton)
        Dim result As Boolean = False
        If Command Is tsbConnect Then
            result = Not m_IsConnected
            If result Then
                mniConnect_Click(tsbConnect, EventArgs.Empty)
            End If
        End If

        If Command Is tsbDisconnect Then
            result = m_IsConnected
            If result Then
                mniDisconnect_Click(tsbDisconnect, EventArgs.Empty)
            End If
        End If

        If Command Is tsbCreateDb Then
            result = True
            mniCreatSqlCeDatabase_Click(tsbCreateDb, EventArgs.Empty)
        End If

        If Command Is tsbExecute Then
            result = m_IsConnected AndAlso Me.txtQueryWindow.TextLength >= 1
            If result Then
                mniExecute_Click(tsbExecute, EventArgs.Empty)
            End If
        End If

        If Command Is tsbParse Then
            result = m_IsConnected AndAlso Me.txtQueryWindow.TextLength >= 1
            If result Then
                mniParse_Click(tsbParse, EventArgs.Empty)
            End If
        End If

        If Command Is tsbFind Then
            result = Me.txtQueryWindow.TextLength >= 1
            If result Then
                mniFind_Click(tsbFind, EventArgs.Empty)
            End If
        End If

        If Command Is tsbSaveAs Then
            result = Me.txtQueryWindow.TextLength >= 1
            If result Then
                mniSaveAs_Click(tsbSaveAs, EventArgs.Empty)
            End If
        End If
        If Command Is tsbOptions Then
            result = True
            mnuOptions_Click(tsbOptions, EventArgs.Empty)
        End If
        If Command Is tsbWeb Then
            result = True
            Me.GotoSqlCeExplorerHome()
        End If
    End Sub

    Private Sub ExecuteCommand(ByVal sender As Object, ByVal e As EventArgs) _
        Handles tsbConnect.Click, tsbOptions.Click, _
        tsbCreateDb.Click, tsbWeb.Click, tsbFind.Click, tsbParse.Click, tsbExecute.Click, tsbSaveAs.Click, tsbDisconnect.Click

        Me.ExecuteCommand(TryCast(sender, ToolStripButton))

    End Sub

    Private Sub mniDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiDeleteSelected.Click
        Me.txtQueryWindow.SelectedText = String.Empty
    End Sub

    Private Sub ctxiDeleteAllRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiDeleteAllRows.Click, mnuManageTableDeleteAll.Click
        If m_currentNode IsNot Nothing Then
            Me.txtQueryWindow.SelectedText = String.Format("DELETE FROM [{0}]", m_currentNode.Text)
            Me.txtQueryWindow.SelectAll()
            Me.ExecuteQuery()
        End If
    End Sub
    Private Sub CtxiAddNewColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtxiAddNewColumn.Click, mnuManageColsAdd.Click
        Me.ShowModifyColumnDialog(frmModifyColumn.OperationMode.CreateColumn)
    End Sub

    Private Sub ctxiDropaColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiDropaColumn.Click, mnuManageColsDelete.Click
        Me.ShowModifyColumnDialog(frmModifyColumn.OperationMode.DropColumn)
    End Sub

    Private Sub ctxiChangeColDataType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiChangeColDataType.Click, mnuManageColsChange.Click
        Me.ShowModifyColumnDialog(frmModifyColumn.OperationMode.AlterColumn)
    End Sub
    Private Sub ShowModifyColumnDialog(ByVal ModeOfOperation As frmModifyColumn.OperationMode)
        If m_currentNode IsNot Nothing Then
            Dim oFrmModifyColumn As frmModifyColumn = Nothing
            Select Case ModeOfOperation
                Case frmModifyColumn.OperationMode.AlterColumn
                    oFrmModifyColumn = New frmModifyColumn(frmModifyColumn.OperationMode.AlterColumn, m_currentNode.Text)
                Case frmModifyColumn.OperationMode.DropColumn
                    oFrmModifyColumn = New frmModifyColumn(frmModifyColumn.OperationMode.DropColumn, m_currentNode.Text)
                Case frmModifyColumn.OperationMode.CreateColumn
                    oFrmModifyColumn = New frmModifyColumn(frmModifyColumn.OperationMode.CreateColumn, m_currentNode.Text)
            End Select
            AddHandler oFrmModifyColumn.AlterColumnQueryFormed, AddressOf oFrmModifyColumn_AlterColumnQueryFormed
            oFrmModifyColumn.ShowDialog(Me)
        End If
    End Sub
    Private Sub oFrmModifyColumn_AlterColumnQueryFormed(ByVal sender As Object, ByVal e As EventArgs)
        Me.txtQueryWindow.Text = SqlCeMain.GetCurrentQuery
        Me.txtQueryWindow.SelectAll()
        Me.ExecuteQuery()
        Me.PopulateUI()
    End Sub
    Private Function NodeExists(ByVal NodeText As String, ByVal Node As TreeNode) As Boolean
        For Each currentNode As TreeNode In Node.Nodes
            If currentNode.Text = NodeText Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub FillRelationShips(ByVal TableName As String, ByVal Node As TreeNode)
        If Not NodeExists("Relationships", Node) Then
            Dim oTablesReader As SqlCeDataReader
            Dim query As String = String.Format(SELECTQUERYRELATIONSHIPS, TableName)
            Dim oSqlCeExplorerData As New SqlCeExplorerData
            Dim columnsNode As New TreeNode("Relationships", 7, 7)
            Dim nodeText As String
            Dim columnNode As TreeNode

            columnsNode.Tag = "#__RELATIONSHIPS__ROOT_NODE#"
            oTablesReader = oSqlCeExplorerData.ExecuteQuery(query)
            While oTablesReader.Read
                nodeText = String.Format("{0}", oTablesReader("CONSTRAINT_NAME").ToString())
                columnNode = New TreeNode(nodeText, 7, 7)
                columnNode.Tag = columnNode.Text
                columnsNode.Nodes.Add(columnNode)
            End While
            Node.Nodes.Add(columnsNode)
            oTablesReader.Close()
            oTablesReader = Nothing
            oSqlCeExplorerData = Nothing
        End If
    End Sub
    Private Sub FillIndexes(ByVal TableName As String, ByVal Node As TreeNode)
        If Not NodeExists("Indexes", Node) Then
            Dim oTablesReader As SqlCeDataReader
            Dim query As String = String.Format(SELECTQUERYINDEXES, TableName)
            Dim oSqlCeExplorerData As New SqlCeExplorerData
            Dim columnsNode As New TreeNode("Indexes", 3, 3)
            Dim nodeText As String
            Dim columnNode As TreeNode

            columnsNode.Tag = "#__INDEXES__ROOT_NODE#"
            oTablesReader = oSqlCeExplorerData.ExecuteQuery(query)
            While oTablesReader.Read
                nodeText = String.Format("{0} - {1} {2}", oTablesReader("INDEX_NAME").ToString(), _
                                                        IIf(CBool(oTablesReader("UNIQUE").ToString()), "Unique", "Non-Unique"), _
                                                        IIf(CBool(oTablesReader("CLUSTERED").ToString()) = "0", "Non-Clustered", "Clustered"))
                columnNode = New TreeNode(nodeText, 6, 6)
                columnNode.Tag = columnNode.Text
                columnsNode.Nodes.Add(columnNode)
            End While
            Node.Nodes.Add(columnsNode)
            oTablesReader.Close()
            oTablesReader = Nothing
            oSqlCeExplorerData = Nothing
        End If
    End Sub
    Private Sub FillColumns(ByVal TableName As String, ByVal Node As TreeNode)
        If Not NodeExists("Columns", Node) Then
            Dim oTablesReader As SqlCeDataReader
            Dim query As String = String.Format(SELECTQUERYCOLUMNS, TableName)
            Dim oSqlCeExplorerData As New SqlCeExplorerData
            Dim columnsNode As New TreeNode("Columns", 2, 2)
            columnsNode.Tag = "#__COLUMNS__ROOT_NODE#"
            Dim columnNode As TreeNode
            oTablesReader = oSqlCeExplorerData.ExecuteQuery(query)

            While oTablesReader.Read
                columnNode = New TreeNode(String.Format("{0} - {1}", _
                    oTablesReader("COLUMN_NAME").ToString(), oTablesReader("DATA_TYPE").ToString()), 5, 5)
                columnNode.Tag = columnNode.Text
                columnsNode.Nodes.Add(columnNode)
            End While
            Node.Nodes.Add(columnsNode)
            oTablesReader.Close()
            oTablesReader = Nothing
            oSqlCeExplorerData = Nothing
        End If
    End Sub

    Private Sub ctxiCreateNewIndex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiCreateNewIndex.Click, mnuManageIndexAdd.Click
        Dim ofrmModifyIndex As New frmModifyIndex(frmModifyIndex.OperationMode.Create)
        AddHandler ofrmModifyIndex.ModifyIndexQueryFormed, AddressOf ofrmModifyIndex_ModifyIndexQueryFormed
        ofrmModifyIndex.ShowDialog(Me)
    End Sub
    Private Sub ofrmModifyIndex_ModifyIndexQueryFormed(ByVal sender As Object, ByVal e As EventArgs)
        Me.txtQueryWindow.Text = SqlCeMain.GetCurrentQuery
        Me.txtQueryWindow.SelectAll()
        Me.ExecuteQuery()
        Me.PopulateUI()
    End Sub
    Private Sub ctxiDropAnIndex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiDropAnIndex.Click, mnuManageIndexDelete.Click
        Dim ofrmModifyIndex As New frmModifyIndex(frmModifyIndex.OperationMode.Drop)
        AddHandler ofrmModifyIndex.ModifyIndexQueryFormed, AddressOf ofrmModifyIndex_ModifyIndexQueryFormed
        ofrmModifyIndex.ShowDialog(Me)
        Me.txtQueryWindow.Text = SqlCeMain.GetCurrentQuery
    End Sub

    Private Sub mniCreatSqlCeDatabase_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCreatSqlCeDatabase.DropDownOpening
        Me.ctxiSeGenerateSql.Enabled = m_IsConnected
        Me.ctxiCompactSeDatabase.Enabled = m_IsConnected
        Me.ctxiSeRepairDatabase.Enabled = m_IsConnected
        Me.ctxiSeGenerateSql.Enabled = m_IsConnected
        Me.ctxiGenerateCode.Enabled = m_IsConnected
    End Sub

    Private Sub ctxiDatabaseOptions_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiDatabaseOptions.DropDownOpening
        Me.ctxiCreateDatabase.Enabled = m_IsConnected
        Me.ctxiCompactDB.Enabled = m_IsConnected
        Me.ctxiRepairDB.Enabled = m_IsConnected
        Me.ctxiGenerateScript.Enabled = m_IsConnected
        Me.ctxiCtxtGenerateCode.Enabled = m_IsConnected
    End Sub
    Private Sub CompactDB(ByVal Sender As Object, ByVal e As EventArgs) Handles ctxiCompactSeDatabase.Click, ctxiCompactDB.Click
        Dim confirmMsg As String = "This option will compact your SQL CE Database, this will be useful if your database file size is in mega bytes."
        If MessageBox.Show(confirmMsg, APPLICATION_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim engine As New SqlCeEngine(SqlCeMain.GetConnectionString)
            engine.Compact(SqlCeMain.GetConnectionString)
            MessageBox.Show("Compact database - completed successfully", APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub RepairDB(ByVal Sender As Object, ByVal e As EventArgs) Handles ctxiSeRepairDatabase.Click, ctxiRepairDB.Click
        Dim confirmMsg As String = "This option will Repair your SQL CE Database if it is corrupted. By default it will try to recover the corrupted rows."
        If MessageBox.Show(confirmMsg, APPLICATION_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim engine As New SqlCeEngine(SqlCeMain.GetConnectionString)
            engine.Repair(SqlCeMain.GetConnectionString, RepairOption.RecoverAllPossibleRows)
            engine.Shrink()
            MessageBox.Show("Repair database - completed successfully", APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ctxiSeGenerateSql_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiSeGenerateSql.Click, ctxiGenerateScript.Click
        Dim ofrmGenerateScript As New frmGenerateScript
        AddHandler ofrmGenerateScript.QueryFormed, AddressOf ofrmGenerateScript_QueryFormed
        ofrmGenerateScript.ShowDialog(Me)
    End Sub
    Private Sub ofrmGenerateScript_QueryFormed(ByVal sender As Object, ByVal e As EventArgs)
        Me.txtQueryWindow.Text = SqlCeMain.GetCurrentQuery
    End Sub

    Private Sub frmMain_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.txtQueryWindow.DoSyntaxHighlight()
    End Sub
    Private Sub mniPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniPrint.Click
        Dim oPrintDocument As New PrintDocument

        Using oPrintDialog As New PrintDialog
            With oPrintDialog
                .ShowHelp = False
                .ShowNetwork = False
                .Document = oPrintDocument
                .AllowCurrentPage = False
                .AllowSelection = False
                .AllowSomePages = False
                .AllowPrintToFile = True
                .UseEXDialog = True
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    oPrintDocument.PrinterSettings = .PrinterSettings
                    AddHandler oPrintDocument.PrintPage, AddressOf oPrintDocument_PrintPage

                    For index As Integer = 1 To .PrinterSettings.Copies
                        m_StartIndex = 0
                        oPrintDocument.Print()
                    Next

                End If
            End With
        End Using
    End Sub
    Private Sub oPrintDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Dim lineCounter As Integer = 0
        Dim lineTop As Double = 0

        For lineIndex As Integer = m_StartIndex To Me.txtQueryWindow.Lines.Length - 1
            Dim line As String = Me.txtQueryWindow.Lines(lineIndex)
            lineCounter += 1
            lineTop = e.MarginBounds.Top + lineCounter * Me.txtQueryWindow.Font.Size
            e.Graphics.DrawString(line, Me.txtQueryWindow.Font, Brushes.Black, e.MarginBounds.Left, lineTop)
            If lineTop > e.MarginBounds.Bottom Then
                m_StartIndex = lineIndex
                e.HasMorePages = True
                Return
            End If
        Next

    End Sub

    Private Sub ctxiAddRelation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiAddRelation.Click, mnuManageRelationAdd.Click
        If m_currentNode IsNot Nothing Then
            Using objFrmRelationShip As New frmRelationShips(m_currentNode.Text)
                AddHandler objFrmRelationShip.RelationShipQueryFormed, AddressOf objFrmRelationShip_RelationShipQueryFormed
                objFrmRelationShip.ShowDialog(Me)
            End Using
        End If
    End Sub

    Private Sub objFrmRelationShip_RelationShipQueryFormed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtQueryWindow.Text = SqlCeMain.GetCurrentQuery
        Me.txtQueryWindow.SelectAll()
        Me.ExecuteQuery()
        Me.PopulateUI()
        Me.UpdateStatusUI(Constants.TABLE_RELATIONSHIP_CREATED)
    End Sub

    Private Sub ctxiDeleteRelation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiDeleteRelation.Click, mnuManageRelationDelete.Click
        Dim ofrmDeleteRelation As frmDeleteRelation
        If m_currentNode IsNot Nothing Then
            ofrmDeleteRelation = New frmDeleteRelation(m_currentNode.Text)
        Else
            ofrmDeleteRelation = New frmDeleteRelation()
        End If
        AddHandler ofrmDeleteRelation.DeleteRelationQueryFormed, AddressOf ofrmDeleteRelation_DeleteRelationQueryFormed
        ofrmDeleteRelation.ShowDialog(Me)
    End Sub
    Public Sub ofrmDeleteRelation_DeleteRelationQueryFormed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtQueryWindow.Text = SqlCeMain.GetCurrentQuery
        Me.txtQueryWindow.SelectAll()
        Me.ExecuteQuery()
        Me.PopulateUI()
    End Sub

    Private Sub ctxGridMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxGridMenu.Opening
        Me.ctxiCopyGrid.Enabled = Me.dgvResults.SelectedCells IsNot Nothing AndAlso Me.dgvResults.SelectedCells.Count >= 1
        Me.ctxiExport.Enabled = Me.dgvResults.SelectedCells IsNot Nothing AndAlso Me.dgvResults.SelectedCells.Count >= 1
    End Sub

    Private Sub ctxiCopyGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiCopyGrid.Click
        Dim oCells As New StringBuilder
        For Each Item As DataGridViewCell In Me.dgvResults.SelectedCells

        Next
    End Sub

    Private Sub mniQueryBuilder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniQueryBuilder.Click
        Using ofrmQueryBuilder As New frmQueryBuilder
            AddHandler ofrmQueryBuilder.QueryBuildCompleted, AddressOf ofrmQueryBuilder_QueryBuildCompleted
            ofrmQueryBuilder.ShowDialog(Me)
        End Using
    End Sub
    Private Sub ofrmQueryBuilder_QueryBuildCompleted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtQueryWindow.Text = SqlCeMain.GetCurrentQuery()
    End Sub
    'Auto Suggestion
    Private isAutoSuggested As Boolean = False
    Private currentIndex As Integer = 0
    Private isAutoCompletedSuggestion As Boolean = False
    Private Sub txtQueryWindow_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQueryWindow.KeyDown
        If Not m_IsConnected Then
            Return
        End If
        If Not Me.m_AutoCompleteEnabled Then
            Return
        End If

        If e.Control AndAlso e.KeyCode = Keys.Space Then
            Dim charIndex As Integer = Me.txtQueryWindow.SelectionStart
            currentIndex = charIndex
            Dim currentPoint As Point = Me.txtQueryWindow.GetPositionFromCharIndex(charIndex)
            Dim c As Char = Me.txtQueryWindow.GetCharFromPosition(currentPoint)
            If FillSimilarWords(c) Then
                lstSuggestions.Show()
                currentPoint.Y += Me.Font.GetHeight()
                lstSuggestions.Location = currentPoint
                Me.ActiveControl = lstSuggestions
                isAutoSuggested = True
            End If
        Else
            isAutoSuggested = False
        End If
    End Sub
    Private Function FillSimilarWords(ByVal s As String) As Boolean

    End Function
    Private Function FillSimilarWords(ByVal startingletter As Char) As Boolean
        Dim startChar As String = startingletter.ToString()
        If startingletter = Nothing Then
            startChar = String.Empty
        End If

        lstSuggestions.Items.Clear()

        Dim result As Boolean = False
        For Each Item As String In Me.WordBuffer
            If startChar.Trim().Length >= 1 Then
                If Item.StartsWith(startChar, StringComparison.CurrentCultureIgnoreCase) Then
                    lstSuggestions.Items.Add(Item)
                    isAutoCompletedSuggestion = True
                    result = True
                End If
            Else
                lstSuggestions.Items.Add(Item)
                isAutoCompletedSuggestion = False
                result = True
            End If
        Next
        Return result
    End Function
    Private Sub txtQueryWindow_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQueryWindow.KeyPress
        If Me.isAutoSuggested Then
            e.Handled = True
        End If
    End Sub

    Private Sub lstSuggestions_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstSuggestions.KeyDown
        If e.KeyCode = Keys.Enter Then
            If lstSuggestions.SelectedIndex <> -1 Then
                If currentIndex >= 1 Then
                    If isAutoCompletedSuggestion Then
                        Me.txtQueryWindow.Select(currentIndex - 1, 1)
                    Else
                        Me.txtQueryWindow.Select(currentIndex, 1)
                    End If
                End If
                Me.txtQueryWindow.SelectedText = lstSuggestions.SelectedItem.ToString()
                Me.txtQueryWindow.Focus()
                lstSuggestions.Visible = False
            End If
        ElseIf e.KeyCode = Keys.Escape OrElse e.KeyCode = Keys.Back Then
            lstSuggestions.Visible = False
            Me.txtQueryWindow.Focus()
        End If

    End Sub

    Private Sub mnuImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImport.Click
        Using oFrmImportFile As New frmImportFile
            oFrmImportFile.ShowDialog(Me)
        End Using
    End Sub
    Private Sub UpdateStatusUI(ByVal status As String)
        tslblStatus.Text = status
    End Sub

    Private Sub mniClearResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniClearResults.Click, ctxiClear.Click
        Me.dgvResults.DataSource = Nothing
    End Sub

    Private Sub ctxiEditAllRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiEditAllRows.Click, mnuManageTableEditAll.Click
        If m_currentNode IsNot Nothing Then
            Using ofrmEditTable As New frmEditTable(m_currentNode.Text)
                ofrmEditTable.ShowDialog(Me)
            End Using
        End If
    End Sub

    Private Sub frmMain_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        Dim files As String() = e.Data.GetData(DataFormats.FileDrop)
        If Path.GetExtension(files(0)).Equals(".sql", StringComparison.CurrentCultureIgnoreCase) OrElse
            Path.GetExtension(files(0)).Equals(".sqlce", StringComparison.CurrentCultureIgnoreCase) Then
            Me.OpenFile(files(0))
        End If
    End Sub

    Private Sub frmMain_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ctxiGenerateCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxiGenerateCode.Click
        Using ofrmGenerateCode As New frmGenerateCode(Path.GetFileNameWithoutExtension(SqlCeMain.GetFileName))
            ofrmGenerateCode.ShowDialog(Me)
        End Using
    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        Using ofrmExport As New frmExport
            ofrmExport.ShowDialog(Me)
        End Using
    End Sub
End Class
