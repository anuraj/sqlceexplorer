<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportFile
    Inherits Framework.frmBaseUI

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvImportedData = New System.Windows.Forms.DataGridView()
        Me.CmdOk = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.lblTables = New System.Windows.Forms.Label()
        Me.cmbTables = New System.Windows.Forms.ComboBox()
        Me.chkCreateTable = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbFileTypes = New System.Windows.Forms.ComboBox()
        Me.cmdShowAbout = New System.Windows.Forms.Button()
        CType(Me.dgvImportedData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&File Name :"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(90, 14)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(363, 21)
        Me.txtFileName.TabIndex = 1
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(459, 13)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowse.TabIndex = 2
        Me.cmdBrowse.Text = "&Browse..."
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Imported Data"
        '
        'dgvImportedData
        '
        Me.dgvImportedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImportedData.Location = New System.Drawing.Point(12, 90)
        Me.dgvImportedData.Name = "dgvImportedData"
        Me.dgvImportedData.Size = New System.Drawing.Size(522, 230)
        Me.dgvImportedData.TabIndex = 4
        '
        'CmdOk
        '
        Me.CmdOk.Location = New System.Drawing.Point(352, 380)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(87, 27)
        Me.CmdOk.TabIndex = 8
        Me.CmdOk.Text = "&OK"
        Me.CmdOk.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Location = New System.Drawing.Point(447, 380)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(87, 27)
        Me.CmdCancel.TabIndex = 9
        Me.CmdCancel.Text = "C&ancel"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'lblTables
        '
        Me.lblTables.AutoSize = True
        Me.lblTables.Enabled = False
        Me.lblTables.Location = New System.Drawing.Point(13, 357)
        Me.lblTables.Name = "lblTables"
        Me.lblTables.Size = New System.Drawing.Size(81, 15)
        Me.lblTables.TabIndex = 0
        Me.lblTables.Text = "&Table Name :"
        '
        'cmbTables
        '
        Me.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTables.Enabled = False
        Me.cmbTables.FormattingEnabled = True
        Me.cmbTables.Location = New System.Drawing.Point(104, 351)
        Me.cmbTables.Name = "cmbTables"
        Me.cmbTables.Size = New System.Drawing.Size(430, 23)
        Me.cmbTables.TabIndex = 10
        '
        'chkCreateTable
        '
        Me.chkCreateTable.AutoSize = True
        Me.chkCreateTable.Checked = True
        Me.chkCreateTable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCreateTable.Location = New System.Drawing.Point(12, 326)
        Me.chkCreateTable.Name = "chkCreateTable"
        Me.chkCreateTable.Size = New System.Drawing.Size(124, 19)
        Me.chkCreateTable.TabIndex = 11
        Me.chkCreateTable.Text = "&Create New Table"
        Me.chkCreateTable.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "&File Type :"
        '
        'cmbFileTypes
        '
        Me.cmbFileTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFileTypes.FormattingEnabled = True
        Me.cmbFileTypes.Location = New System.Drawing.Point(90, 41)
        Me.cmbFileTypes.Name = "cmbFileTypes"
        Me.cmbFileTypes.Size = New System.Drawing.Size(199, 23)
        Me.cmbFileTypes.TabIndex = 10
        '
        'cmdShowAbout
        '
        Me.cmdShowAbout.Location = New System.Drawing.Point(295, 41)
        Me.cmdShowAbout.Name = "cmdShowAbout"
        Me.cmdShowAbout.Size = New System.Drawing.Size(23, 23)
        Me.cmdShowAbout.TabIndex = 2
        Me.cmdShowAbout.Text = "?"
        Me.cmdShowAbout.UseVisualStyleBackColor = True
        '
        'frmImportFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(541, 413)
        Me.Controls.Add(Me.chkCreateTable)
        Me.Controls.Add(Me.cmbFileTypes)
        Me.Controls.Add(Me.cmbTables)
        Me.Controls.Add(Me.CmdOk)
        Me.Controls.Add(Me.CmdCancel)
        Me.Controls.Add(Me.dgvImportedData)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdShowAbout)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.lblTables)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmImportFile"
        Me.Text = "Import File"
        CType(Me.dgvImportedData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Private WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvImportedData As System.Windows.Forms.DataGridView
    Friend WithEvents CmdOk As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblTables As System.Windows.Forms.Label
    Friend WithEvents cmbTables As System.Windows.Forms.ComboBox
    Friend WithEvents chkCreateTable As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbFileTypes As System.Windows.Forms.ComboBox
    Friend WithEvents cmdShowAbout As System.Windows.Forms.Button

End Class
