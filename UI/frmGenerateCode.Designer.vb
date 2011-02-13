<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerateCode
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbLanguages = New System.Windows.Forms.ComboBox()
        Me.cmdShowAbout = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'chkScriptTables
        '
        Me.chkScriptTables.AutoSize = True
        Me.chkScriptTables.Checked = True
        Me.chkScriptTables.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkScriptTables.Location = New System.Drawing.Point(5, 34)
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
        Me.chkListTables.Location = New System.Drawing.Point(5, 67)
        Me.chkListTables.Name = "chkListTables"
        Me.chkListTables.Size = New System.Drawing.Size(354, 212)
        Me.chkListTables.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "&Language"
        '
        'cmbLanguages
        '
        Me.cmbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLanguages.FormattingEnabled = True
        Me.cmbLanguages.Location = New System.Drawing.Point(71, 5)
        Me.cmbLanguages.Name = "cmbLanguages"
        Me.cmbLanguages.Size = New System.Drawing.Size(261, 23)
        Me.cmbLanguages.TabIndex = 12
        '
        'cmdShowAbout
        '
        Me.cmdShowAbout.Location = New System.Drawing.Point(338, 5)
        Me.cmdShowAbout.Name = "cmdShowAbout"
        Me.cmdShowAbout.Size = New System.Drawing.Size(23, 23)
        Me.cmdShowAbout.TabIndex = 14
        Me.cmdShowAbout.Text = "?"
        Me.cmdShowAbout.UseVisualStyleBackColor = True
        '
        'frmGenerateCode
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(368, 319)
        Me.Controls.Add(Me.cmdShowAbout)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbLanguages)
        Me.Controls.Add(Me.chkListTables)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.chkScriptTables)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGenerateCode"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generate Script"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkScriptTables As System.Windows.Forms.CheckBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents chkListTables As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbLanguages As System.Windows.Forms.ComboBox
    Friend WithEvents cmdShowAbout As System.Windows.Forms.Button
End Class
