<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.stsMain = New System.Windows.Forms.StatusStrip
        Me.tslblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.msMain = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mniConnect = New System.Windows.Forms.ToolStripMenuItem
        Me.mniDisconnect = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.mniCreatSqlCeDatabase = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSep8 = New System.Windows.Forms.ToolStripSeparator
        Me.mniOpenFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSep9 = New System.Windows.Forms.ToolStripSeparator
        Me.mniSave = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSaveAs = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSep2 = New System.Windows.Forms.ToolStripSeparator
        Me.mniRecentFiles = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSep10 = New System.Windows.Forms.ToolStripSeparator
        Me.mniQuit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.mniUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSep3 = New System.Windows.Forms.ToolStripSeparator
        Me.mniCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.mniCut = New System.Windows.Forms.ToolStripMenuItem
        Me.mniPaste = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSep5 = New System.Windows.Forms.ToolStripSeparator
        Me.mniFind = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSep4 = New System.Windows.Forms.ToolStripSeparator
        Me.mniSelectAll = New System.Windows.Forms.ToolStripMenuItem
        Me.mniClearAll = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuQuery = New System.Windows.Forms.ToolStripMenuItem
        Me.mniParse = New System.Windows.Forms.ToolStripMenuItem
        Me.mniExecute = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSep6 = New System.Windows.Forms.ToolStripSeparator
        Me.mniClearResults = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.mniHomePage = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSep7 = New System.Windows.Forms.ToolStripSeparator
        Me.mniAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxTreeMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxiCreateDatabase = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.ctxiCreateTable = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiDropTable = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxisep2 = New System.Windows.Forms.ToolStripSeparator
        Me.ctxiSelectAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiDeleteAllRows = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiSep3 = New System.Windows.Forms.ToolStripSeparator
        Me.ctxiManageColumns = New System.Windows.Forms.ToolStripMenuItem
        Me.CtxiAddNewColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiDropaColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiSep6 = New System.Windows.Forms.ToolStripSeparator
        Me.ctxiChangeColDataType = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiSep8 = New System.Windows.Forms.ToolStripSeparator
        Me.CtxiManageIndexes = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiCreateNewIndex = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiSep5 = New System.Windows.Forms.ToolStripSeparator
        Me.ctxiDropAnIndex = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiSep7 = New System.Windows.Forms.ToolStripSeparator
        Me.ctxiRefersh = New System.Windows.Forms.ToolStripMenuItem
        Me.iltvExplorer = New System.Windows.Forms.ImageList(Me.components)
        Me.ctxEditor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxiCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiCut = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiPaste = New System.Windows.Forms.ToolStripMenuItem
        Me.tspSep7 = New System.Windows.Forms.ToolStripSeparator
        Me.ctxiSelectAllEditor = New System.Windows.Forms.ToolStripMenuItem
        Me.tspSep5 = New System.Windows.Forms.ToolStripSeparator
        Me.ctxiDeleteSelected = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiParse = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiExecute = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiSep4 = New System.Windows.Forms.ToolStripSeparator
        Me.ctxiClear = New System.Windows.Forms.ToolStripMenuItem
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.tsbConnect = New System.Windows.Forms.ToolStripButton
        Me.tsbDisconnect = New System.Windows.Forms.ToolStripButton
        Me.tsbSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbCreateDb = New System.Windows.Forms.ToolStripButton
        Me.tsbSep2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbSaveAs = New System.Windows.Forms.ToolStripButton
        Me.tsbSep3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbFind = New System.Windows.Forms.ToolStripButton
        Me.tsbSep5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbParse = New System.Windows.Forms.ToolStripButton
        Me.tsbExecute = New System.Windows.Forms.ToolStripButton
        Me.tsbSep6 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbOptions = New System.Windows.Forms.ToolStripButton
        Me.tsbSep8 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbWeb = New System.Windows.Forms.ToolStripButton
        Me.plContainer = New System.Windows.Forms.Panel
        Me.scMain = New System.Windows.Forms.SplitContainer
        Me.tvDatabaseExplorer = New System.Windows.Forms.TreeView
        Me.scRightSide = New System.Windows.Forms.SplitContainer
        Me.tcMain = New System.Windows.Forms.TabControl
        Me.tpGrid = New System.Windows.Forms.TabPage
        Me.dgvResults = New System.Windows.Forms.DataGridView
        Me.tpText = New System.Windows.Forms.TabPage
        Me.txtOutput = New System.Windows.Forms.TextBox
        Me.ctxOutputWindow = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxiOutputCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiOutputCut = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxiOutputSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.ctxiOutputSelectAll = New System.Windows.Forms.ToolStripMenuItem
        Me.txtQueryWindow = New SQLCEExplorer.SQLTextbox
        Me.stsMain.SuspendLayout()
        Me.msMain.SuspendLayout()
        Me.ctxTreeMenu.SuspendLayout()
        Me.ctxEditor.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.plContainer.SuspendLayout()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.Panel2.SuspendLayout()
        Me.scMain.SuspendLayout()
        Me.scRightSide.Panel1.SuspendLayout()
        Me.scRightSide.Panel2.SuspendLayout()
        Me.scRightSide.SuspendLayout()
        Me.tcMain.SuspendLayout()
        Me.tpGrid.SuspendLayout()
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpText.SuspendLayout()
        Me.ctxOutputWindow.SuspendLayout()
        Me.SuspendLayout()
        '
        'stsMain
        '
        Me.stsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblStatus})
        Me.stsMain.Location = New System.Drawing.Point(0, 530)
        Me.stsMain.Name = "stsMain"
        Me.stsMain.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.stsMain.Size = New System.Drawing.Size(780, 22)
        Me.stsMain.TabIndex = 0
        Me.stsMain.Text = "StatusStrip1"
        '
        'tslblStatus
        '
        Me.tslblStatus.Name = "tslblStatus"
        Me.tslblStatus.Size = New System.Drawing.Size(157, 17)
        Me.tslblStatus.Text = "Welcome to SQL CE Explorer"
        '
        'msMain
        '
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuQuery, Me.mnuTools, Me.mnuHelp})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.msMain.Size = New System.Drawing.Size(780, 24)
        Me.msMain.TabIndex = 2
        Me.msMain.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniConnect, Me.mniDisconnect, Me.mniSep1, Me.mniCreatSqlCeDatabase, Me.mniSep8, Me.mniOpenFile, Me.mniSep9, Me.mniSave, Me.mniSaveAs, Me.mniSep2, Me.mniRecentFiles, Me.mniSep10, Me.mniQuit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "&File"
        '
        'mniConnect
        '
        Me.mniConnect.Image = Global.SQLCEExplorer.My.Resources.Resources.connect
        Me.mniConnect.Name = "mniConnect"
        Me.mniConnect.Size = New System.Drawing.Size(237, 22)
        Me.mniConnect.Text = "&Connect to SQL CE Database ..."
        '
        'mniDisconnect
        '
        Me.mniDisconnect.Image = Global.SQLCEExplorer.My.Resources.Resources.disconnect
        Me.mniDisconnect.Name = "mniDisconnect"
        Me.mniDisconnect.Size = New System.Drawing.Size(237, 22)
        Me.mniDisconnect.Text = "&Disconnect"
        '
        'mniSep1
        '
        Me.mniSep1.Name = "mniSep1"
        Me.mniSep1.Size = New System.Drawing.Size(234, 6)
        '
        'mniCreatSqlCeDatabase
        '
        Me.mniCreatSqlCeDatabase.Image = Global.SQLCEExplorer.My.Resources.Resources.database_add
        Me.mniCreatSqlCeDatabase.Name = "mniCreatSqlCeDatabase"
        Me.mniCreatSqlCeDatabase.Size = New System.Drawing.Size(237, 22)
        Me.mniCreatSqlCeDatabase.Text = "C&reate SQL CE Database ..."
        '
        'mniSep8
        '
        Me.mniSep8.Name = "mniSep8"
        Me.mniSep8.Size = New System.Drawing.Size(234, 6)
        '
        'mniOpenFile
        '
        Me.mniOpenFile.Name = "mniOpenFile"
        Me.mniOpenFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.mniOpenFile.Size = New System.Drawing.Size(237, 22)
        Me.mniOpenFile.Text = "&Open ..."
        '
        'mniSep9
        '
        Me.mniSep9.Name = "mniSep9"
        Me.mniSep9.Size = New System.Drawing.Size(234, 6)
        '
        'mniSave
        '
        Me.mniSave.Image = Global.SQLCEExplorer.My.Resources.Resources.floppy
        Me.mniSave.Name = "mniSave"
        Me.mniSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mniSave.Size = New System.Drawing.Size(237, 22)
        Me.mniSave.Text = "&Save"
        '
        'mniSaveAs
        '
        Me.mniSaveAs.Image = Global.SQLCEExplorer.My.Resources.Resources.floppy
        Me.mniSaveAs.Name = "mniSaveAs"
        Me.mniSaveAs.Size = New System.Drawing.Size(237, 22)
        Me.mniSaveAs.Text = "Save &As ..."
        '
        'mniSep2
        '
        Me.mniSep2.Name = "mniSep2"
        Me.mniSep2.Size = New System.Drawing.Size(234, 6)
        '
        'mniRecentFiles
        '
        Me.mniRecentFiles.Name = "mniRecentFiles"
        Me.mniRecentFiles.Size = New System.Drawing.Size(237, 22)
        Me.mniRecentFiles.Text = "Re&cent Files"
        '
        'mniSep10
        '
        Me.mniSep10.Name = "mniSep10"
        Me.mniSep10.Size = New System.Drawing.Size(234, 6)
        '
        'mniQuit
        '
        Me.mniQuit.Name = "mniQuit"
        Me.mniQuit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.mniQuit.Size = New System.Drawing.Size(237, 22)
        Me.mniQuit.Text = "&Exit ..."
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniUndo, Me.mniSep3, Me.mniCopy, Me.mniCut, Me.mniPaste, Me.mniSep5, Me.mniFind, Me.mniSep4, Me.mniSelectAll, Me.mniClearAll})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(39, 20)
        Me.mnuEdit.Text = "&Edit"
        '
        'mniUndo
        '
        Me.mniUndo.Name = "mniUndo"
        Me.mniUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.mniUndo.Size = New System.Drawing.Size(164, 22)
        Me.mniUndo.Text = "&Undo"
        '
        'mniSep3
        '
        Me.mniSep3.Name = "mniSep3"
        Me.mniSep3.Size = New System.Drawing.Size(161, 6)
        '
        'mniCopy
        '
        Me.mniCopy.Name = "mniCopy"
        Me.mniCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mniCopy.Size = New System.Drawing.Size(164, 22)
        Me.mniCopy.Text = "&Copy"
        '
        'mniCut
        '
        Me.mniCut.Name = "mniCut"
        Me.mniCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.mniCut.Size = New System.Drawing.Size(164, 22)
        Me.mniCut.Text = "C&ut"
        '
        'mniPaste
        '
        Me.mniPaste.Name = "mniPaste"
        Me.mniPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.mniPaste.Size = New System.Drawing.Size(164, 22)
        Me.mniPaste.Text = "&Paste"
        '
        'mniSep5
        '
        Me.mniSep5.Name = "mniSep5"
        Me.mniSep5.Size = New System.Drawing.Size(161, 6)
        '
        'mniFind
        '
        Me.mniFind.Image = Global.SQLCEExplorer.My.Resources.Resources.search
        Me.mniFind.Name = "mniFind"
        Me.mniFind.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.mniFind.Size = New System.Drawing.Size(164, 22)
        Me.mniFind.Text = "&Find ..."
        '
        'mniSep4
        '
        Me.mniSep4.Name = "mniSep4"
        Me.mniSep4.Size = New System.Drawing.Size(161, 6)
        '
        'mniSelectAll
        '
        Me.mniSelectAll.Name = "mniSelectAll"
        Me.mniSelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.mniSelectAll.Size = New System.Drawing.Size(164, 22)
        Me.mniSelectAll.Text = "&Select All"
        '
        'mniClearAll
        '
        Me.mniClearAll.Image = Global.SQLCEExplorer.My.Resources.Resources.trash
        Me.mniClearAll.Name = "mniClearAll"
        Me.mniClearAll.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.mniClearAll.Size = New System.Drawing.Size(164, 22)
        Me.mniClearAll.Text = "&Delete"
        '
        'mnuQuery
        '
        Me.mnuQuery.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniParse, Me.mniExecute, Me.mniSep6, Me.mniClearResults})
        Me.mnuQuery.Name = "mnuQuery"
        Me.mnuQuery.Size = New System.Drawing.Size(51, 20)
        Me.mnuQuery.Text = "&Query"
        '
        'mniParse
        '
        Me.mniParse.Image = Global.SQLCEExplorer.My.Resources.Resources.symbol_check
        Me.mniParse.Name = "mniParse"
        Me.mniParse.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.mniParse.Size = New System.Drawing.Size(226, 22)
        Me.mniParse.Text = "&Parse"
        '
        'mniExecute
        '
        Me.mniExecute.Image = Global.SQLCEExplorer.My.Resources.Resources.control_play
        Me.mniExecute.Name = "mniExecute"
        Me.mniExecute.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mniExecute.Size = New System.Drawing.Size(226, 22)
        Me.mniExecute.Text = "&Execute"
        '
        'mniSep6
        '
        Me.mniSep6.Name = "mniSep6"
        Me.mniSep6.Size = New System.Drawing.Size(223, 6)
        '
        'mniClearResults
        '
        Me.mniClearResults.Image = Global.SQLCEExplorer.My.Resources.Resources.trash
        Me.mniClearResults.Name = "mniClearResults"
        Me.mniClearResults.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.mniClearResults.Size = New System.Drawing.Size(226, 22)
        Me.mniClearResults.Text = "&Clear Results Pane"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOptions})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(48, 20)
        Me.mnuTools.Text = "&Tools"
        '
        'mnuOptions
        '
        Me.mnuOptions.Image = Global.SQLCEExplorer.My.Resources.Resources.wrench
        Me.mnuOptions.Name = "mnuOptions"
        Me.mnuOptions.Size = New System.Drawing.Size(128, 22)
        Me.mnuOptions.Text = "&Options ..."
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniHomePage, Me.mniSep7, Me.mniAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnuHelp.Text = "&Help"
        '
        'mniHomePage
        '
        Me.mniHomePage.Image = Global.SQLCEExplorer.My.Resources.Resources.world
        Me.mniHomePage.Name = "mniHomePage"
        Me.mniHomePage.Size = New System.Drawing.Size(251, 22)
        Me.mniHomePage.Text = "&Goto SQL CE Explorer Home page"
        '
        'mniSep7
        '
        Me.mniSep7.Name = "mniSep7"
        Me.mniSep7.Size = New System.Drawing.Size(248, 6)
        '
        'mniAbout
        '
        Me.mniAbout.Image = Global.SQLCEExplorer.My.Resources.Resources.symbol_question
        Me.mniAbout.Name = "mniAbout"
        Me.mniAbout.Size = New System.Drawing.Size(251, 22)
        Me.mniAbout.Text = "&About SQL CE Explorer ..."
        '
        'ctxTreeMenu
        '
        Me.ctxTreeMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxiCreateDatabase, Me.ctxiSep1, Me.ctxiCreateTable, Me.ctxiDropTable, Me.ctxisep2, Me.ctxiSelectAll, Me.ctxiDeleteAllRows, Me.ctxiSep3, Me.ctxiManageColumns, Me.ctxiSep8, Me.CtxiManageIndexes, Me.ctxiSep7, Me.ctxiRefersh})
        Me.ctxTreeMenu.Name = "ctxTreeMenu"
        Me.ctxTreeMenu.Size = New System.Drawing.Size(213, 232)
        '
        'ctxiCreateDatabase
        '
        Me.ctxiCreateDatabase.Image = Global.SQLCEExplorer.My.Resources.Resources.database_add
        Me.ctxiCreateDatabase.Name = "ctxiCreateDatabase"
        Me.ctxiCreateDatabase.Size = New System.Drawing.Size(212, 22)
        Me.ctxiCreateDatabase.Text = "Create SQL CE Database ..."
        '
        'ctxiSep1
        '
        Me.ctxiSep1.Name = "ctxiSep1"
        Me.ctxiSep1.Size = New System.Drawing.Size(209, 6)
        '
        'ctxiCreateTable
        '
        Me.ctxiCreateTable.Image = Global.SQLCEExplorer.My.Resources.Resources.theme
        Me.ctxiCreateTable.Name = "ctxiCreateTable"
        Me.ctxiCreateTable.Size = New System.Drawing.Size(212, 22)
        Me.ctxiCreateTable.Text = "Create Table ..."
        '
        'ctxiDropTable
        '
        Me.ctxiDropTable.Image = Global.SQLCEExplorer.My.Resources.Resources.trash
        Me.ctxiDropTable.Name = "ctxiDropTable"
        Me.ctxiDropTable.Size = New System.Drawing.Size(212, 22)
        Me.ctxiDropTable.Text = "Delete Table ..."
        '
        'ctxisep2
        '
        Me.ctxisep2.Name = "ctxisep2"
        Me.ctxisep2.Size = New System.Drawing.Size(209, 6)
        '
        'ctxiSelectAll
        '
        Me.ctxiSelectAll.Name = "ctxiSelectAll"
        Me.ctxiSelectAll.Size = New System.Drawing.Size(212, 22)
        Me.ctxiSelectAll.Text = "Select All Rows"
        '
        'ctxiDeleteAllRows
        '
        Me.ctxiDeleteAllRows.Name = "ctxiDeleteAllRows"
        Me.ctxiDeleteAllRows.Size = New System.Drawing.Size(212, 22)
        Me.ctxiDeleteAllRows.Text = "Delete All Rows"
        '
        'ctxiSep3
        '
        Me.ctxiSep3.Name = "ctxiSep3"
        Me.ctxiSep3.Size = New System.Drawing.Size(209, 6)
        '
        'ctxiManageColumns
        '
        Me.ctxiManageColumns.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CtxiAddNewColumn, Me.ctxiDropaColumn, Me.ctxiSep6, Me.ctxiChangeColDataType})
        Me.ctxiManageColumns.Name = "ctxiManageColumns"
        Me.ctxiManageColumns.Size = New System.Drawing.Size(212, 22)
        Me.ctxiManageColumns.Text = "Manage Columns"
        '
        'CtxiAddNewColumn
        '
        Me.CtxiAddNewColumn.Name = "CtxiAddNewColumn"
        Me.CtxiAddNewColumn.Size = New System.Drawing.Size(210, 22)
        Me.CtxiAddNewColumn.Text = "Add a new Column"
        '
        'ctxiDropaColumn
        '
        Me.ctxiDropaColumn.Name = "ctxiDropaColumn"
        Me.ctxiDropaColumn.Size = New System.Drawing.Size(210, 22)
        Me.ctxiDropaColumn.Text = "Drop a Column"
        '
        'ctxiSep6
        '
        Me.ctxiSep6.Name = "ctxiSep6"
        Me.ctxiSep6.Size = New System.Drawing.Size(207, 6)
        '
        'ctxiChangeColDataType
        '
        Me.ctxiChangeColDataType.Name = "ctxiChangeColDataType"
        Me.ctxiChangeColDataType.Size = New System.Drawing.Size(210, 22)
        Me.ctxiChangeColDataType.Text = "Change Column datatype"
        '
        'ctxiSep8
        '
        Me.ctxiSep8.Name = "ctxiSep8"
        Me.ctxiSep8.Size = New System.Drawing.Size(209, 6)
        '
        'CtxiManageIndexes
        '
        Me.CtxiManageIndexes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxiCreateNewIndex, Me.ctxiSep5, Me.ctxiDropAnIndex})
        Me.CtxiManageIndexes.Name = "CtxiManageIndexes"
        Me.CtxiManageIndexes.Size = New System.Drawing.Size(212, 22)
        Me.CtxiManageIndexes.Text = "Manage Indexes"
        '
        'ctxiCreateNewIndex
        '
        Me.ctxiCreateNewIndex.Name = "ctxiCreateNewIndex"
        Me.ctxiCreateNewIndex.Size = New System.Drawing.Size(164, 22)
        Me.ctxiCreateNewIndex.Text = "Create new Index"
        '
        'ctxiSep5
        '
        Me.ctxiSep5.Name = "ctxiSep5"
        Me.ctxiSep5.Size = New System.Drawing.Size(161, 6)
        '
        'ctxiDropAnIndex
        '
        Me.ctxiDropAnIndex.Name = "ctxiDropAnIndex"
        Me.ctxiDropAnIndex.Size = New System.Drawing.Size(164, 22)
        Me.ctxiDropAnIndex.Text = "Drop an Index"
        '
        'ctxiSep7
        '
        Me.ctxiSep7.Name = "ctxiSep7"
        Me.ctxiSep7.Size = New System.Drawing.Size(209, 6)
        '
        'ctxiRefersh
        '
        Me.ctxiRefersh.Image = Global.SQLCEExplorer.My.Resources.Resources.arrows_circle
        Me.ctxiRefersh.Name = "ctxiRefersh"
        Me.ctxiRefersh.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ctxiRefersh.Size = New System.Drawing.Size(212, 22)
        Me.ctxiRefersh.Text = "Refresh"
        '
        'iltvExplorer
        '
        Me.iltvExplorer.ImageStream = CType(resources.GetObject("iltvExplorer.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iltvExplorer.TransparentColor = System.Drawing.Color.Transparent
        Me.iltvExplorer.Images.SetKeyName(0, "database.gif")
        Me.iltvExplorer.Images.SetKeyName(1, "application_view_icons.gif")
        Me.iltvExplorer.Images.SetKeyName(2, "album.gif")
        Me.iltvExplorer.Images.SetKeyName(3, "album_sub_album.gif")
        Me.iltvExplorer.Images.SetKeyName(4, "application_view_icons.gif")
        Me.iltvExplorer.Images.SetKeyName(5, "album.gif")
        Me.iltvExplorer.Images.SetKeyName(6, "album_sub_album.gif")
        '
        'ctxEditor
        '
        Me.ctxEditor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxiCopy, Me.ctxiCut, Me.ctxiPaste, Me.tspSep7, Me.ctxiSelectAllEditor, Me.tspSep5, Me.ctxiDeleteSelected, Me.ctxiParse, Me.ctxiExecute, Me.ctxiSep4, Me.ctxiClear})
        Me.ctxEditor.Name = "ctxEditor"
        Me.ctxEditor.Size = New System.Drawing.Size(171, 198)
        '
        'ctxiCopy
        '
        Me.ctxiCopy.Name = "ctxiCopy"
        Me.ctxiCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ctxiCopy.Size = New System.Drawing.Size(170, 22)
        Me.ctxiCopy.Text = "&Copy"
        '
        'ctxiCut
        '
        Me.ctxiCut.Name = "ctxiCut"
        Me.ctxiCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ctxiCut.Size = New System.Drawing.Size(170, 22)
        Me.ctxiCut.Text = "C&ut"
        '
        'ctxiPaste
        '
        Me.ctxiPaste.Name = "ctxiPaste"
        Me.ctxiPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.ctxiPaste.Size = New System.Drawing.Size(170, 22)
        Me.ctxiPaste.Text = "&Paste"
        '
        'tspSep7
        '
        Me.tspSep7.Name = "tspSep7"
        Me.tspSep7.Size = New System.Drawing.Size(167, 6)
        '
        'ctxiSelectAllEditor
        '
        Me.ctxiSelectAllEditor.Name = "ctxiSelectAllEditor"
        Me.ctxiSelectAllEditor.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ctxiSelectAllEditor.Size = New System.Drawing.Size(170, 22)
        Me.ctxiSelectAllEditor.Text = "&Select All"
        '
        'tspSep5
        '
        Me.tspSep5.Name = "tspSep5"
        Me.tspSep5.Size = New System.Drawing.Size(167, 6)
        '
        'ctxiDeleteSelected
        '
        Me.ctxiDeleteSelected.Name = "ctxiDeleteSelected"
        Me.ctxiDeleteSelected.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.ctxiDeleteSelected.Size = New System.Drawing.Size(170, 22)
        Me.ctxiDeleteSelected.Text = "&Delete"
        '
        'ctxiParse
        '
        Me.ctxiParse.Image = Global.SQLCEExplorer.My.Resources.Resources.symbol_check
        Me.ctxiParse.Name = "ctxiParse"
        Me.ctxiParse.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.ctxiParse.Size = New System.Drawing.Size(170, 22)
        Me.ctxiParse.Text = "&Parse"
        '
        'ctxiExecute
        '
        Me.ctxiExecute.Image = Global.SQLCEExplorer.My.Resources.Resources.control_play
        Me.ctxiExecute.Name = "ctxiExecute"
        Me.ctxiExecute.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ctxiExecute.Size = New System.Drawing.Size(170, 22)
        Me.ctxiExecute.Text = "&Execute"
        '
        'ctxiSep4
        '
        Me.ctxiSep4.Name = "ctxiSep4"
        Me.ctxiSep4.Size = New System.Drawing.Size(167, 6)
        '
        'ctxiClear
        '
        Me.ctxiClear.Image = Global.SQLCEExplorer.My.Resources.Resources.trash
        Me.ctxiClear.Name = "ctxiClear"
        Me.ctxiClear.Size = New System.Drawing.Size(170, 22)
        Me.ctxiClear.Text = "Clear Results pane"
        '
        'tsMain
        '
        Me.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConnect, Me.tsbDisconnect, Me.tsbSep1, Me.tsbCreateDb, Me.tsbSep2, Me.tsbSaveAs, Me.tsbSep3, Me.tsbFind, Me.tsbSep5, Me.tsbParse, Me.tsbExecute, Me.tsbSep6, Me.tsbOptions, Me.tsbSep8, Me.tsbWeb})
        Me.tsMain.Location = New System.Drawing.Point(0, 24)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(780, 25)
        Me.tsMain.TabIndex = 0
        Me.tsMain.Text = "ToolStrip1"
        '
        'tsbConnect
        '
        Me.tsbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbConnect.Image = Global.SQLCEExplorer.My.Resources.Resources.connect
        Me.tsbConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConnect.Name = "tsbConnect"
        Me.tsbConnect.Size = New System.Drawing.Size(23, 22)
        Me.tsbConnect.Text = "&Connect to SQL CE Database ..."
        '
        'tsbDisconnect
        '
        Me.tsbDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDisconnect.Image = Global.SQLCEExplorer.My.Resources.Resources.disconnect
        Me.tsbDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDisconnect.Name = "tsbDisconnect"
        Me.tsbDisconnect.Size = New System.Drawing.Size(23, 22)
        Me.tsbDisconnect.Text = "Disconnect"
        '
        'tsbSep1
        '
        Me.tsbSep1.Name = "tsbSep1"
        Me.tsbSep1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbCreateDb
        '
        Me.tsbCreateDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCreateDb.Image = Global.SQLCEExplorer.My.Resources.Resources.database_add
        Me.tsbCreateDb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCreateDb.Name = "tsbCreateDb"
        Me.tsbCreateDb.Size = New System.Drawing.Size(23, 22)
        Me.tsbCreateDb.Text = "Create SQL CE Database ..."
        '
        'tsbSep2
        '
        Me.tsbSep2.Name = "tsbSep2"
        Me.tsbSep2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbSaveAs
        '
        Me.tsbSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSaveAs.Image = Global.SQLCEExplorer.My.Resources.Resources.floppy
        Me.tsbSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSaveAs.Name = "tsbSaveAs"
        Me.tsbSaveAs.Size = New System.Drawing.Size(23, 22)
        Me.tsbSaveAs.Text = "Save"
        '
        'tsbSep3
        '
        Me.tsbSep3.Name = "tsbSep3"
        Me.tsbSep3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbFind
        '
        Me.tsbFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbFind.Image = Global.SQLCEExplorer.My.Resources.Resources.search
        Me.tsbFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFind.Name = "tsbFind"
        Me.tsbFind.Size = New System.Drawing.Size(23, 22)
        Me.tsbFind.Text = "Find ..."
        '
        'tsbSep5
        '
        Me.tsbSep5.Name = "tsbSep5"
        Me.tsbSep5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbParse
        '
        Me.tsbParse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbParse.Image = Global.SQLCEExplorer.My.Resources.Resources.symbol_check
        Me.tsbParse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbParse.Name = "tsbParse"
        Me.tsbParse.Size = New System.Drawing.Size(23, 22)
        Me.tsbParse.Text = "Parse"
        '
        'tsbExecute
        '
        Me.tsbExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbExecute.Image = Global.SQLCEExplorer.My.Resources.Resources.control_play
        Me.tsbExecute.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExecute.Name = "tsbExecute"
        Me.tsbExecute.Size = New System.Drawing.Size(23, 22)
        Me.tsbExecute.Text = "Execute"
        '
        'tsbSep6
        '
        Me.tsbSep6.Name = "tsbSep6"
        Me.tsbSep6.Size = New System.Drawing.Size(6, 25)
        '
        'tsbOptions
        '
        Me.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbOptions.Image = Global.SQLCEExplorer.My.Resources.Resources.wrench
        Me.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOptions.Name = "tsbOptions"
        Me.tsbOptions.Size = New System.Drawing.Size(23, 22)
        Me.tsbOptions.Text = "Options ..."
        '
        'tsbSep8
        '
        Me.tsbSep8.Name = "tsbSep8"
        Me.tsbSep8.Size = New System.Drawing.Size(6, 25)
        '
        'tsbWeb
        '
        Me.tsbWeb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbWeb.Image = Global.SQLCEExplorer.My.Resources.Resources.world
        Me.tsbWeb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbWeb.Name = "tsbWeb"
        Me.tsbWeb.Size = New System.Drawing.Size(23, 22)
        Me.tsbWeb.Text = "Visit SQL CE Explorer Home"
        '
        'plContainer
        '
        Me.plContainer.Controls.Add(Me.scMain)
        Me.plContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plContainer.Location = New System.Drawing.Point(0, 49)
        Me.plContainer.Name = "plContainer"
        Me.plContainer.Size = New System.Drawing.Size(780, 481)
        Me.plContainer.TabIndex = 6
        '
        'scMain
        '
        Me.scMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scMain.Location = New System.Drawing.Point(0, 0)
        Me.scMain.Name = "scMain"
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.Controls.Add(Me.tvDatabaseExplorer)
        '
        'scMain.Panel2
        '
        Me.scMain.Panel2.Controls.Add(Me.scRightSide)
        Me.scMain.Size = New System.Drawing.Size(780, 481)
        Me.scMain.SplitterDistance = 258
        Me.scMain.SplitterWidth = 5
        Me.scMain.TabIndex = 3
        '
        'tvDatabaseExplorer
        '
        Me.tvDatabaseExplorer.ContextMenuStrip = Me.ctxTreeMenu
        Me.tvDatabaseExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvDatabaseExplorer.ImageIndex = 0
        Me.tvDatabaseExplorer.ImageList = Me.iltvExplorer
        Me.tvDatabaseExplorer.Location = New System.Drawing.Point(0, 0)
        Me.tvDatabaseExplorer.Name = "tvDatabaseExplorer"
        Me.tvDatabaseExplorer.SelectedImageIndex = 0
        Me.tvDatabaseExplorer.Size = New System.Drawing.Size(258, 481)
        Me.tvDatabaseExplorer.TabIndex = 0
        '
        'scRightSide
        '
        Me.scRightSide.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scRightSide.Location = New System.Drawing.Point(0, 0)
        Me.scRightSide.Name = "scRightSide"
        Me.scRightSide.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scRightSide.Panel1
        '
        Me.scRightSide.Panel1.Controls.Add(Me.txtQueryWindow)
        '
        'scRightSide.Panel2
        '
        Me.scRightSide.Panel2.Controls.Add(Me.tcMain)
        Me.scRightSide.Size = New System.Drawing.Size(517, 481)
        Me.scRightSide.SplitterDistance = 184
        Me.scRightSide.SplitterWidth = 5
        Me.scRightSide.TabIndex = 0
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.tpGrid)
        Me.tcMain.Controls.Add(Me.tpText)
        Me.tcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMain.Location = New System.Drawing.Point(0, 0)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(517, 292)
        Me.tcMain.TabIndex = 0
        '
        'tpGrid
        '
        Me.tpGrid.Controls.Add(Me.dgvResults)
        Me.tpGrid.Location = New System.Drawing.Point(4, 24)
        Me.tpGrid.Name = "tpGrid"
        Me.tpGrid.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGrid.Size = New System.Drawing.Size(509, 264)
        Me.tpGrid.TabIndex = 0
        Me.tpGrid.Text = "Results"
        Me.tpGrid.UseVisualStyleBackColor = True
        '
        'dgvResults
        '
        Me.dgvResults.AllowUserToAddRows = False
        Me.dgvResults.AllowUserToDeleteRows = False
        Me.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvResults.Location = New System.Drawing.Point(3, 3)
        Me.dgvResults.Name = "dgvResults"
        Me.dgvResults.RowHeadersVisible = False
        Me.dgvResults.ShowEditingIcon = False
        Me.dgvResults.ShowRowErrors = False
        Me.dgvResults.Size = New System.Drawing.Size(503, 258)
        Me.dgvResults.TabIndex = 0
        '
        'tpText
        '
        Me.tpText.Controls.Add(Me.txtOutput)
        Me.tpText.Location = New System.Drawing.Point(4, 24)
        Me.tpText.Name = "tpText"
        Me.tpText.Padding = New System.Windows.Forms.Padding(3)
        Me.tpText.Size = New System.Drawing.Size(509, 264)
        Me.tpText.TabIndex = 1
        Me.tpText.Text = "Messages"
        Me.tpText.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.BackColor = System.Drawing.SystemColors.Window
        Me.txtOutput.ContextMenuStrip = Me.ctxOutputWindow
        Me.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOutput.Location = New System.Drawing.Point(3, 3)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutput.Size = New System.Drawing.Size(503, 260)
        Me.txtOutput.TabIndex = 3
        '
        'ctxOutputWindow
        '
        Me.ctxOutputWindow.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxiOutputCopy, Me.ctxiOutputCut, Me.ctxiOutputSep1, Me.ctxiOutputSelectAll})
        Me.ctxOutputWindow.Name = "ctxEditor"
        Me.ctxOutputWindow.Size = New System.Drawing.Size(123, 76)
        '
        'ctxiOutputCopy
        '
        Me.ctxiOutputCopy.Name = "ctxiOutputCopy"
        Me.ctxiOutputCopy.Size = New System.Drawing.Size(122, 22)
        Me.ctxiOutputCopy.Text = "&Copy"
        '
        'ctxiOutputCut
        '
        Me.ctxiOutputCut.Name = "ctxiOutputCut"
        Me.ctxiOutputCut.Size = New System.Drawing.Size(122, 22)
        Me.ctxiOutputCut.Text = "C&ut"
        '
        'ctxiOutputSep1
        '
        Me.ctxiOutputSep1.Name = "ctxiOutputSep1"
        Me.ctxiOutputSep1.Size = New System.Drawing.Size(119, 6)
        '
        'ctxiOutputSelectAll
        '
        Me.ctxiOutputSelectAll.Name = "ctxiOutputSelectAll"
        Me.ctxiOutputSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.ctxiOutputSelectAll.Text = "&Select All"
        '
        'txtQueryWindow
        '
        Me.txtQueryWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQueryWindow.CommentsColor = System.Drawing.Color.Green
        Me.txtQueryWindow.ContextMenuStrip = Me.ctxEditor
        Me.txtQueryWindow.DetectUrls = False
        Me.txtQueryWindow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQueryWindow.HideSelection = False
        Me.txtQueryWindow.HighlightComments = True
        Me.txtQueryWindow.HighlightVariables = True
        Me.txtQueryWindow.KeywordColor = System.Drawing.Color.Blue
        Me.txtQueryWindow.Keywords = CType(resources.GetObject("txtQueryWindow.Keywords"), System.Collections.Generic.List(Of String))
        Me.txtQueryWindow.Location = New System.Drawing.Point(0, 0)
        Me.txtQueryWindow.Name = "txtQueryWindow"
        Me.txtQueryWindow.OperatorColor = System.Drawing.Color.Gray
        Me.txtQueryWindow.Operators = CType(resources.GetObject("txtQueryWindow.Operators"), System.Collections.Generic.List(Of String))
        Me.txtQueryWindow.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtQueryWindow.ShortcutsEnabled = False
        Me.txtQueryWindow.Size = New System.Drawing.Size(517, 184)
        Me.txtQueryWindow.TabIndex = 0
        Me.txtQueryWindow.Text = ""
        Me.txtQueryWindow.VariableColor = System.Drawing.Color.Red
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 552)
        Me.Controls.Add(Me.plContainer)
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.stsMain)
        Me.Controls.Add(Me.msMain)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.msMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SQL CE Explorer"
        Me.stsMain.ResumeLayout(False)
        Me.stsMain.PerformLayout()
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        Me.ctxTreeMenu.ResumeLayout(False)
        Me.ctxEditor.ResumeLayout(False)
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.plContainer.ResumeLayout(False)
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel2.ResumeLayout(False)
        Me.scMain.ResumeLayout(False)
        Me.scRightSide.Panel1.ResumeLayout(False)
        Me.scRightSide.Panel2.ResumeLayout(False)
        Me.scRightSide.ResumeLayout(False)
        Me.tcMain.ResumeLayout(False)
        Me.tpGrid.ResumeLayout(False)
        CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpText.ResumeLayout(False)
        Me.tpText.PerformLayout()
        Me.ctxOutputWindow.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stsMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tslblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents msMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuQuery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniConnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniDisconnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mniSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mniQuit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniSep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mniCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniSep4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mniSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniClearAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniSep5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mniFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniParse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniExecute As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniSep6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mniClearResults As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniHomePage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniSep7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mniAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniCreatSqlCeDatabase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniSep8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents iltvExplorer As System.Windows.Forms.ImageList
    Friend WithEvents ctxTreeMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxiCreateDatabase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxiCreateTable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxisep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxiSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiSep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxiRefersh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxEditor As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxiParse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiExecute As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiSep4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxiClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbCreateDb As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSaveAs As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSep5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbParse As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExecute As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSep6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbOptions As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSep8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbWeb As System.Windows.Forms.ToolStripButton
    Friend WithEvents plContainer As System.Windows.Forms.Panel
    Friend WithEvents scMain As System.Windows.Forms.SplitContainer
    Friend WithEvents tvDatabaseExplorer As System.Windows.Forms.TreeView
    Friend WithEvents scRightSide As System.Windows.Forms.SplitContainer
    Friend WithEvents txtQueryWindow As SQLCEExplorer.SQLTextbox
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
    Friend WithEvents tpGrid As System.Windows.Forms.TabPage
    Friend WithEvents dgvResults As System.Windows.Forms.DataGridView
    Friend WithEvents tpText As System.Windows.Forms.TabPage
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents mniOpenFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniSep9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mniSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspSep5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxiCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tspSep7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxiSelectAllEditor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxOutputWindow As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxiOutputCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiOutputCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiOutputSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxiOutputSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiDropTable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbDisconnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents mniRecentFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniSep10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxiDeleteSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiDeleteAllRows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiManageColumns As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiSep7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CtxiAddNewColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiDropaColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiSep6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxiChangeColDataType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiSep8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CtxiManageIndexes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiCreateNewIndex As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxiSep5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxiDropAnIndex As System.Windows.Forms.ToolStripMenuItem

End Class
