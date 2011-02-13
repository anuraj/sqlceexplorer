<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerateScript
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
        Me.chkScriptTables = New System.Windows.Forms.CheckBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.chkListTables = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radToFileSystem = New System.Windows.Forms.RadioButton()
        Me.radClipboard = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkScriptTables
        '
        Me.chkScriptTables.AutoSize = True
        Me.chkScriptTables.Checked = True
        Me.chkScriptTables.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkScriptTables.Location = New System.Drawing.Point(5, 104)
        Me.chkScriptTables.Name = "chkScriptTables"
        Me.chkScriptTables.Size = New System.Drawing.Size(97, 19)
        Me.chkScriptTables.TabIndex = 0
        Me.chkScriptTables.Text = "Script Tables"
        Me.chkScriptTables.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(181, 285)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(87, 27)
        Me.cmdOk.TabIndex = 5
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(274, 285)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(87, 27)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'chkListTables
        '
        Me.chkListTables.CheckOnClick = True
        Me.chkListTables.FormattingEnabled = True
        Me.chkListTables.Location = New System.Drawing.Point(5, 131)
        Me.chkListTables.Name = "chkListTables"
        Me.chkListTables.Size = New System.Drawing.Size(354, 148)
        Me.chkListTables.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radToFileSystem)
        Me.GroupBox1.Controls.Add(Me.radClipboard)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(349, 94)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Script Options"
        '
        'radToFileSystem
        '
        Me.radToFileSystem.AutoSize = True
        Me.radToFileSystem.Checked = True
        Me.radToFileSystem.Location = New System.Drawing.Point(14, 61)
        Me.radToFileSystem.Name = "radToFileSystem"
        Me.radToFileSystem.Size = New System.Drawing.Size(91, 17)
        Me.radToFileSystem.TabIndex = 0
        Me.radToFileSystem.TabStop = True
        Me.radToFileSystem.Text = "To FileSystem"
        Me.radToFileSystem.UseVisualStyleBackColor = True
        '
        'radClipboard
        '
        Me.radClipboard.AutoSize = True
        Me.radClipboard.Location = New System.Drawing.Point(14, 24)
        Me.radClipboard.Name = "radClipboard"
        Me.radClipboard.Size = New System.Drawing.Size(85, 17)
        Me.radClipboard.TabIndex = 0
        Me.radClipboard.TabStop = True
        Me.radClipboard.Text = "To Clipboard"
        Me.radClipboard.UseVisualStyleBackColor = True
        '
        'frmGenerateScript
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(368, 319)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkListTables)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.chkScriptTables)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGenerateScript"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generate Script"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkScriptTables As System.Windows.Forms.CheckBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents chkListTables As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radToFileSystem As System.Windows.Forms.RadioButton
    Friend WithEvents radClipboard As System.Windows.Forms.RadioButton
End Class
