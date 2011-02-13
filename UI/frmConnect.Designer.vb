<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnect
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
        Me.lblSqlDbName = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.chkIsEncrypted = New System.Windows.Forms.CheckBox
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.CmdConnect = New System.Windows.Forms.Button
        Me.CmdCancel = New System.Windows.Forms.Button
        Me.cmbFiles = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblSqlDbName
        '
        Me.lblSqlDbName.AutoSize = True
        Me.lblSqlDbName.Location = New System.Drawing.Point(6, 12)
        Me.lblSqlDbName.Name = "lblSqlDbName"
        Me.lblSqlDbName.Size = New System.Drawing.Size(106, 15)
        Me.lblSqlDbName.TabIndex = 0
        Me.lblSqlDbName.Text = "&SQL CE Database"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(45, 43)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(61, 15)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "&Password"
        '
        'chkIsEncrypted
        '
        Me.chkIsEncrypted.AutoSize = True
        Me.chkIsEncrypted.Location = New System.Drawing.Point(122, 70)
        Me.chkIsEncrypted.Name = "chkIsEncrypted"
        Me.chkIsEncrypted.Size = New System.Drawing.Size(92, 19)
        Me.chkIsEncrypted.TabIndex = 5
        Me.chkIsEncrypted.Text = "&Is Encrypted"
        Me.chkIsEncrypted.UseVisualStyleBackColor = True
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBrowse.Location = New System.Drawing.Point(381, 7)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(27, 25)
        Me.cmdBrowse.TabIndex = 2
        Me.cmdBrowse.Text = "..."
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(122, 38)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(251, 21)
        Me.txtPassword.TabIndex = 4
        '
        'CmdConnect
        '
        Me.CmdConnect.Location = New System.Drawing.Point(122, 99)
        Me.CmdConnect.Name = "CmdConnect"
        Me.CmdConnect.Size = New System.Drawing.Size(87, 27)
        Me.CmdConnect.TabIndex = 6
        Me.CmdConnect.Text = "&Connect"
        Me.CmdConnect.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Location = New System.Drawing.Point(217, 99)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(87, 27)
        Me.CmdCancel.TabIndex = 7
        Me.CmdCancel.Text = "C&ancel"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'cmbFiles
        '
        Me.cmbFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiles.FormattingEnabled = True
        Me.cmbFiles.Location = New System.Drawing.Point(122, 9)
        Me.cmbFiles.Name = "cmbFiles"
        Me.cmbFiles.Size = New System.Drawing.Size(251, 23)
        Me.cmbFiles.TabIndex = 8
        '
        'frmConnect
        '
        Me.AcceptButton = Me.CmdConnect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CmdCancel
        Me.ClientSize = New System.Drawing.Size(429, 140)
        Me.Controls.Add(Me.cmbFiles)
        Me.Controls.Add(Me.CmdConnect)
        Me.Controls.Add(Me.CmdCancel)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.chkIsEncrypted)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblSqlDbName)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConnect"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Connect to SQL CE Database"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSqlDbName As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents chkIsEncrypted As System.Windows.Forms.CheckBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents CmdConnect As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmbFiles As System.Windows.Forms.ComboBox
End Class
