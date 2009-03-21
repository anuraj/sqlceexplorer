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
        Me.tcOptions = New System.Windows.Forms.TabControl
        Me.tpSettings = New System.Windows.Forms.TabPage
        Me.chkRecentItems = New System.Windows.Forms.CheckBox
        Me.nuRecentFiles = New System.Windows.Forms.NumericUpDown
        Me.lblRecentItems = New System.Windows.Forms.Label
        Me.cmdBrowseFonts = New System.Windows.Forms.Button
        Me.txtFont = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.chkConneciondlg = New System.Windows.Forms.CheckBox
        Me.tpDBOptions = New System.Windows.Forms.TabPage
        Me.cmdRepair = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdCompact = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.tcOptions.SuspendLayout()
        Me.tpSettings.SuspendLayout()
        CType(Me.nuRecentFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDBOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcOptions
        '
        Me.tcOptions.Controls.Add(Me.tpSettings)
        Me.tcOptions.Controls.Add(Me.tpDBOptions)
        Me.tcOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcOptions.Location = New System.Drawing.Point(0, 0)
        Me.tcOptions.Name = "tcOptions"
        Me.tcOptions.SelectedIndex = 0
        Me.tcOptions.Size = New System.Drawing.Size(377, 257)
        Me.tcOptions.TabIndex = 0
        '
        'tpSettings
        '
        Me.tpSettings.Controls.Add(Me.chkRecentItems)
        Me.tpSettings.Controls.Add(Me.nuRecentFiles)
        Me.tpSettings.Controls.Add(Me.lblRecentItems)
        Me.tpSettings.Controls.Add(Me.cmdBrowseFonts)
        Me.tpSettings.Controls.Add(Me.txtFont)
        Me.tpSettings.Controls.Add(Me.Label1)
        Me.tpSettings.Controls.Add(Me.cmdCancel)
        Me.tpSettings.Controls.Add(Me.cmdOk)
        Me.tpSettings.Controls.Add(Me.chkConneciondlg)
        Me.tpSettings.Location = New System.Drawing.Point(4, 24)
        Me.tpSettings.Name = "tpSettings"
        Me.tpSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSettings.Size = New System.Drawing.Size(369, 229)
        Me.tpSettings.TabIndex = 0
        Me.tpSettings.Text = "Settings"
        Me.tpSettings.UseVisualStyleBackColor = True
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
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(284, 198)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(193, 198)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 8
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = True
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
        Me.tpDBOptions.Size = New System.Drawing.Size(369, 229)
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
        'frmOptions
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(377, 257)
        Me.Controls.Add(Me.tcOptions)
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
End Class
