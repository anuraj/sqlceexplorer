<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Me.tcOptions = New System.Windows.Forms.TabControl()
        Me.tpSettings = New System.Windows.Forms.TabPage()
        Me.chkAssociate = New System.Windows.Forms.CheckBox()
        Me.chkAutoComplete = New System.Windows.Forms.CheckBox()
        Me.chkRecentItems = New System.Windows.Forms.CheckBox()
        Me.nuRecentFiles = New System.Windows.Forms.NumericUpDown()
        Me.lblRecentItems = New System.Windows.Forms.Label()
        Me.cmdBrowseFonts = New System.Windows.Forms.Button()
        Me.txtFont = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkConneciondlg = New System.Windows.Forms.CheckBox()
        Me.tpDBOptions = New System.Windows.Forms.TabPage()
        Me.cmdRepair = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdCompact = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tpEditorSettings = New System.Windows.Forms.TabPage()
        Me.chkEnableSyntaxHighlighting = New System.Windows.Forms.CheckBox()
        Me.plMain = New System.Windows.Forms.Panel()
        Me.plComments = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdBrowseComments = New System.Windows.Forms.Button()
        Me.txtCommentSample = New System.Windows.Forms.TextBox()
        Me.plVariables = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdBrowseVariable = New System.Windows.Forms.Button()
        Me.txtVariableSample = New System.Windows.Forms.TextBox()
        Me.chkHighlightVariables = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdBrowseFunctions = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdBrowseKeyWords = New System.Windows.Forms.Button()
        Me.txtFunctionSample = New System.Windows.Forms.TextBox()
        Me.txtKeywordSample = New System.Windows.Forms.TextBox()
        Me.chkHighlightComments = New System.Windows.Forms.CheckBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.tcOptions.SuspendLayout()
        Me.tpSettings.SuspendLayout()
        CType(Me.nuRecentFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDBOptions.SuspendLayout()
        Me.tpEditorSettings.SuspendLayout()
        Me.plMain.SuspendLayout()
        Me.plComments.SuspendLayout()
        Me.plVariables.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcOptions
        '
        Me.tcOptions.Controls.Add(Me.tpSettings)
        Me.tcOptions.Controls.Add(Me.tpDBOptions)
        Me.tcOptions.Controls.Add(Me.tpEditorSettings)
        Me.tcOptions.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcOptions.Location = New System.Drawing.Point(0, 0)
        Me.tcOptions.Name = "tcOptions"
        Me.tcOptions.SelectedIndex = 0
        Me.tcOptions.Size = New System.Drawing.Size(378, 257)
        Me.tcOptions.TabIndex = 0
        '
        'tpSettings
        '
        Me.tpSettings.Controls.Add(Me.chkAssociate)
        Me.tpSettings.Controls.Add(Me.chkAutoComplete)
        Me.tpSettings.Controls.Add(Me.chkRecentItems)
        Me.tpSettings.Controls.Add(Me.nuRecentFiles)
        Me.tpSettings.Controls.Add(Me.lblRecentItems)
        Me.tpSettings.Controls.Add(Me.cmdBrowseFonts)
        Me.tpSettings.Controls.Add(Me.txtFont)
        Me.tpSettings.Controls.Add(Me.Label1)
        Me.tpSettings.Controls.Add(Me.chkConneciondlg)
        Me.tpSettings.Location = New System.Drawing.Point(4, 24)
        Me.tpSettings.Name = "tpSettings"
        Me.tpSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSettings.Size = New System.Drawing.Size(370, 229)
        Me.tpSettings.TabIndex = 0
        Me.tpSettings.Text = "Settings"
        Me.tpSettings.UseVisualStyleBackColor = True
        '
        'chkAssociate
        '
        Me.chkAssociate.AutoSize = True
        Me.chkAssociate.Location = New System.Drawing.Point(19, 189)
        Me.chkAssociate.Name = "chkAssociate"
        Me.chkAssociate.Size = New System.Drawing.Size(237, 19)
        Me.chkAssociate.TabIndex = 18
        Me.chkAssociate.Text = "Associate *.SDF file to SQLCE Explorer"
        Me.chkAssociate.UseVisualStyleBackColor = True
        '
        'chkAutoComplete
        '
        Me.chkAutoComplete.AutoSize = True
        Me.chkAutoComplete.Location = New System.Drawing.Point(19, 163)
        Me.chkAutoComplete.Name = "chkAutoComplete"
        Me.chkAutoComplete.Size = New System.Drawing.Size(145, 19)
        Me.chkAutoComplete.TabIndex = 17
        Me.chkAutoComplete.Text = "Enable AutoComplete"
        Me.chkAutoComplete.UseVisualStyleBackColor = True
        '
        'chkRecentItems
        '
        Me.chkRecentItems.AutoSize = True
        Me.chkRecentItems.Location = New System.Drawing.Point(16, 94)
        Me.chkRecentItems.Name = "chkRecentItems"
        Me.chkRecentItems.Size = New System.Drawing.Size(127, 19)
        Me.chkRecentItems.TabIndex = 16
        Me.chkRecentItems.Text = "Enable recent files"
        Me.chkRecentItems.UseVisualStyleBackColor = True
        '
        'nuRecentFiles
        '
        Me.nuRecentFiles.Location = New System.Drawing.Point(15, 124)
        Me.nuRecentFiles.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.nuRecentFiles.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nuRecentFiles.Name = "nuRecentFiles"
        Me.nuRecentFiles.Size = New System.Drawing.Size(49, 21)
        Me.nuRecentFiles.TabIndex = 15
        Me.nuRecentFiles.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblRecentItems
        '
        Me.lblRecentItems.AutoSize = True
        Me.lblRecentItems.Location = New System.Drawing.Point(70, 128)
        Me.lblRecentItems.Name = "lblRecentItems"
        Me.lblRecentItems.Size = New System.Drawing.Size(174, 15)
        Me.lblRecentItems.TabIndex = 14
        Me.lblRecentItems.Text = "items shown in Recent files list"
        '
        'cmdBrowseFonts
        '
        Me.cmdBrowseFonts.Location = New System.Drawing.Point(329, 40)
        Me.cmdBrowseFonts.Name = "cmdBrowseFonts"
        Me.cmdBrowseFonts.Size = New System.Drawing.Size(30, 23)
        Me.cmdBrowseFonts.TabIndex = 12
        Me.cmdBrowseFonts.Text = "..."
        Me.cmdBrowseFonts.UseVisualStyleBackColor = True
        '
        'txtFont
        '
        Me.txtFont.BackColor = System.Drawing.SystemColors.Window
        Me.txtFont.Location = New System.Drawing.Point(16, 40)
        Me.txtFont.Name = "txtFont"
        Me.txtFont.ReadOnly = True
        Me.txtFont.Size = New System.Drawing.Size(306, 21)
        Me.txtFont.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Query Window Font"
        '
        'chkConneciondlg
        '
        Me.chkConneciondlg.AutoSize = True
        Me.chkConneciondlg.Location = New System.Drawing.Point(16, 69)
        Me.chkConneciondlg.Name = "chkConneciondlg"
        Me.chkConneciondlg.Size = New System.Drawing.Size(214, 19)
        Me.chkConneciondlg.TabIndex = 7
        Me.chkConneciondlg.Text = "Show connection dialog on startup"
        Me.chkConneciondlg.UseVisualStyleBackColor = True
        '
        'tpDBOptions
        '
        Me.tpDBOptions.Controls.Add(Me.cmdRepair)
        Me.tpDBOptions.Controls.Add(Me.Label4)
        Me.tpDBOptions.Controls.Add(Me.cmdCompact)
        Me.tpDBOptions.Controls.Add(Me.Label3)
        Me.tpDBOptions.Location = New System.Drawing.Point(4, 24)
        Me.tpDBOptions.Name = "tpDBOptions"
        Me.tpDBOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDBOptions.Size = New System.Drawing.Size(370, 229)
        Me.tpDBOptions.TabIndex = 1
        Me.tpDBOptions.Text = "Database options"
        Me.tpDBOptions.UseVisualStyleBackColor = True
        '
        'cmdRepair
        '
        Me.cmdRepair.Location = New System.Drawing.Point(29, 184)
        Me.cmdRepair.Name = "cmdRepair"
        Me.cmdRepair.Size = New System.Drawing.Size(141, 23)
        Me.cmdRepair.TabIndex = 3
        Me.cmdRepair.Text = "&Repair"
        Me.cmdRepair.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(277, 45)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Repair SQL CE Database - This option will Repair" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "your SQL CE Database if it is c" & _
            "orrupted. By default" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "it will try to recover the corrupted rows."
        '
        'cmdCompact
        '
        Me.cmdCompact.Location = New System.Drawing.Point(29, 86)
        Me.cmdCompact.Name = "cmdCompact"
        Me.cmdCompact.Size = New System.Drawing.Size(141, 23)
        Me.cmdCompact.TabIndex = 1
        Me.cmdCompact.Text = "&Compact"
        Me.cmdCompact.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(320, 45)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Compact SQL CE Database - This option will compact" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "your SQL CE Database, this wi" & _
            "ll be useful if your database" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "file size is in mega bytes."
        '
        'tpEditorSettings
        '
        Me.tpEditorSettings.Controls.Add(Me.chkEnableSyntaxHighlighting)
        Me.tpEditorSettings.Controls.Add(Me.plMain)
        Me.tpEditorSettings.Location = New System.Drawing.Point(4, 24)
        Me.tpEditorSettings.Name = "tpEditorSettings"
        Me.tpEditorSettings.Size = New System.Drawing.Size(370, 229)
        Me.tpEditorSettings.TabIndex = 2
        Me.tpEditorSettings.Text = "Editor Settings"
        Me.tpEditorSettings.UseVisualStyleBackColor = True
        '
        'chkEnableSyntaxHighlighting
        '
        Me.chkEnableSyntaxHighlighting.AutoSize = True
        Me.chkEnableSyntaxHighlighting.Location = New System.Drawing.Point(8, 8)
        Me.chkEnableSyntaxHighlighting.Name = "chkEnableSyntaxHighlighting"
        Me.chkEnableSyntaxHighlighting.Size = New System.Drawing.Size(221, 17)
        Me.chkEnableSyntaxHighlighting.TabIndex = 0
        Me.chkEnableSyntaxHighlighting.Text = "Enable Syntax Highlighting (Experimental)"
        Me.chkEnableSyntaxHighlighting.UseVisualStyleBackColor = True
        '
        'plMain
        '
        Me.plMain.Controls.Add(Me.plComments)
        Me.plMain.Controls.Add(Me.plVariables)
        Me.plMain.Controls.Add(Me.chkHighlightVariables)
        Me.plMain.Controls.Add(Me.Label7)
        Me.plMain.Controls.Add(Me.cmdBrowseFunctions)
        Me.plMain.Controls.Add(Me.Label2)
        Me.plMain.Controls.Add(Me.cmdBrowseKeyWords)
        Me.plMain.Controls.Add(Me.txtFunctionSample)
        Me.plMain.Controls.Add(Me.txtKeywordSample)
        Me.plMain.Controls.Add(Me.chkHighlightComments)
        Me.plMain.Enabled = False
        Me.plMain.Location = New System.Drawing.Point(8, 34)
        Me.plMain.Name = "plMain"
        Me.plMain.Size = New System.Drawing.Size(270, 183)
        Me.plMain.TabIndex = 1
        '
        'plComments
        '
        Me.plComments.Controls.Add(Me.Label5)
        Me.plComments.Controls.Add(Me.cmdBrowseComments)
        Me.plComments.Controls.Add(Me.txtCommentSample)
        Me.plComments.Enabled = False
        Me.plComments.Location = New System.Drawing.Point(0, 28)
        Me.plComments.Name = "plComments"
        Me.plComments.Size = New System.Drawing.Size(249, 35)
        Me.plComments.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Comments"
        '
        'cmdBrowseComments
        '
        Me.cmdBrowseComments.Location = New System.Drawing.Point(207, 6)
        Me.cmdBrowseComments.Name = "cmdBrowseComments"
        Me.cmdBrowseComments.Size = New System.Drawing.Size(25, 23)
        Me.cmdBrowseComments.TabIndex = 2
        Me.cmdBrowseComments.Text = "..."
        Me.cmdBrowseComments.UseVisualStyleBackColor = True
        '
        'txtCommentSample
        '
        Me.txtCommentSample.ForeColor = System.Drawing.Color.Green
        Me.txtCommentSample.Location = New System.Drawing.Point(76, 7)
        Me.txtCommentSample.Name = "txtCommentSample"
        Me.txtCommentSample.Size = New System.Drawing.Size(129, 21)
        Me.txtCommentSample.TabIndex = 1
        Me.txtCommentSample.Text = "this is a comment"
        '
        'plVariables
        '
        Me.plVariables.Controls.Add(Me.Label6)
        Me.plVariables.Controls.Add(Me.cmdBrowseVariable)
        Me.plVariables.Controls.Add(Me.txtVariableSample)
        Me.plVariables.Enabled = False
        Me.plVariables.Location = New System.Drawing.Point(0, 84)
        Me.plVariables.Name = "plVariables"
        Me.plVariables.Size = New System.Drawing.Size(249, 35)
        Me.plVariables.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Variables"
        '
        'cmdBrowseVariable
        '
        Me.cmdBrowseVariable.Location = New System.Drawing.Point(207, 6)
        Me.cmdBrowseVariable.Name = "cmdBrowseVariable"
        Me.cmdBrowseVariable.Size = New System.Drawing.Size(25, 23)
        Me.cmdBrowseVariable.TabIndex = 2
        Me.cmdBrowseVariable.Text = "..."
        Me.cmdBrowseVariable.UseVisualStyleBackColor = True
        '
        'txtVariableSample
        '
        Me.txtVariableSample.ForeColor = System.Drawing.Color.Red
        Me.txtVariableSample.Location = New System.Drawing.Point(76, 7)
        Me.txtVariableSample.Name = "txtVariableSample"
        Me.txtVariableSample.Size = New System.Drawing.Size(129, 21)
        Me.txtVariableSample.TabIndex = 1
        Me.txtVariableSample.Text = "this is a variable"
        '
        'chkHighlightVariables
        '
        Me.chkHighlightVariables.AutoSize = True
        Me.chkHighlightVariables.Location = New System.Drawing.Point(12, 66)
        Me.chkHighlightVariables.Name = "chkHighlightVariables"
        Me.chkHighlightVariables.Size = New System.Drawing.Size(113, 17)
        Me.chkHighlightVariables.TabIndex = 0
        Me.chkHighlightVariables.Text = "Highlight Variables"
        Me.chkHighlightVariables.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 15)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Functions"
        '
        'cmdBrowseFunctions
        '
        Me.cmdBrowseFunctions.Location = New System.Drawing.Point(207, 153)
        Me.cmdBrowseFunctions.Name = "cmdBrowseFunctions"
        Me.cmdBrowseFunctions.Size = New System.Drawing.Size(25, 23)
        Me.cmdBrowseFunctions.TabIndex = 2
        Me.cmdBrowseFunctions.Text = "..."
        Me.cmdBrowseFunctions.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Keywords"
        '
        'cmdBrowseKeyWords
        '
        Me.cmdBrowseKeyWords.Location = New System.Drawing.Point(207, 126)
        Me.cmdBrowseKeyWords.Name = "cmdBrowseKeyWords"
        Me.cmdBrowseKeyWords.Size = New System.Drawing.Size(25, 23)
        Me.cmdBrowseKeyWords.TabIndex = 2
        Me.cmdBrowseKeyWords.Text = "..."
        Me.cmdBrowseKeyWords.UseVisualStyleBackColor = True
        '
        'txtFunctionSample
        '
        Me.txtFunctionSample.ForeColor = System.Drawing.Color.Gray
        Me.txtFunctionSample.Location = New System.Drawing.Point(76, 153)
        Me.txtFunctionSample.Name = "txtFunctionSample"
        Me.txtFunctionSample.Size = New System.Drawing.Size(129, 21)
        Me.txtFunctionSample.TabIndex = 1
        Me.txtFunctionSample.Text = "this is a function"
        '
        'txtKeywordSample
        '
        Me.txtKeywordSample.ForeColor = System.Drawing.Color.Blue
        Me.txtKeywordSample.Location = New System.Drawing.Point(76, 126)
        Me.txtKeywordSample.Name = "txtKeywordSample"
        Me.txtKeywordSample.Size = New System.Drawing.Size(129, 21)
        Me.txtKeywordSample.TabIndex = 1
        Me.txtKeywordSample.Text = "this is a keyword"
        '
        'chkHighlightComments
        '
        Me.chkHighlightComments.AutoSize = True
        Me.chkHighlightComments.Location = New System.Drawing.Point(12, 12)
        Me.chkHighlightComments.Name = "chkHighlightComments"
        Me.chkHighlightComments.Size = New System.Drawing.Size(119, 17)
        Me.chkHighlightComments.TabIndex = 0
        Me.chkHighlightComments.Text = "Highlight Comments"
        Me.chkHighlightComments.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(288, 262)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(205, 262)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 8
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(378, 291)
        Me.Controls.Add(Me.tcOptions)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.tcOptions.ResumeLayout(False)
        Me.tpSettings.ResumeLayout(False)
        Me.tpSettings.PerformLayout()
        CType(Me.nuRecentFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDBOptions.ResumeLayout(False)
        Me.tpDBOptions.PerformLayout()
        Me.tpEditorSettings.ResumeLayout(False)
        Me.tpEditorSettings.PerformLayout()
        Me.plMain.ResumeLayout(False)
        Me.plMain.PerformLayout()
        Me.plComments.ResumeLayout(False)
        Me.plComments.PerformLayout()
        Me.plVariables.ResumeLayout(False)
        Me.plVariables.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcOptions As System.Windows.Forms.TabControl
    Friend WithEvents tpSettings As System.Windows.Forms.TabPage
    Friend WithEvents cmdBrowseFonts As System.Windows.Forms.Button
    Friend WithEvents txtFont As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents chkConneciondlg As System.Windows.Forms.CheckBox
    Friend WithEvents tpDBOptions As System.Windows.Forms.TabPage
    Friend WithEvents cmdRepair As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdCompact As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nuRecentFiles As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblRecentItems As System.Windows.Forms.Label
    Friend WithEvents chkRecentItems As System.Windows.Forms.CheckBox
    Friend WithEvents tpEditorSettings As System.Windows.Forms.TabPage
    Friend WithEvents chkEnableSyntaxHighlighting As System.Windows.Forms.CheckBox
    Friend WithEvents plMain As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowseKeyWords As System.Windows.Forms.Button
    Friend WithEvents cmdBrowseVariable As System.Windows.Forms.Button
    Friend WithEvents txtKeywordSample As System.Windows.Forms.TextBox
    Friend WithEvents cmdBrowseComments As System.Windows.Forms.Button
    Friend WithEvents txtVariableSample As System.Windows.Forms.TextBox
    Friend WithEvents txtCommentSample As System.Windows.Forms.TextBox
    Friend WithEvents chkHighlightVariables As System.Windows.Forms.CheckBox
    Friend WithEvents chkHighlightComments As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowseFunctions As System.Windows.Forms.Button
    Friend WithEvents txtFunctionSample As System.Windows.Forms.TextBox
    Friend WithEvents plComments As System.Windows.Forms.Panel
    Friend WithEvents plVariables As System.Windows.Forms.Panel
    Friend WithEvents chkAutoComplete As System.Windows.Forms.CheckBox
    Friend WithEvents chkAssociate As System.Windows.Forms.CheckBox
End Class
