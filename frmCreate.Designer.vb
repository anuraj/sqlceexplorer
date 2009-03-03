<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreate
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
        Me.CmdCreate = New System.Windows.Forms.Button
        Me.CmdCancel = New System.Windows.Forms.Button
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtDBPath = New System.Windows.Forms.TextBox
        Me.chkIsEncrypted = New System.Windows.Forms.CheckBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblSqlDbName = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox
        Me.lblDbName = New System.Windows.Forms.Label
        Me.txtDBName = New System.Windows.Forms.TextBox
        Me.chkOverwrite = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'CmdCreate
        '
        Me.CmdCreate.Location = New System.Drawing.Point(124, 178)
        Me.CmdCreate.Name = "CmdCreate"
        Me.CmdCreate.Size = New System.Drawing.Size(135, 27)
        Me.CmdCreate.TabIndex = 11
        Me.CmdCreate.Text = "&Create Database"
        Me.CmdCreate.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Location = New System.Drawing.Point(265, 178)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(87, 27)
        Me.CmdCancel.TabIndex = 12
        Me.CmdCancel.Text = "C&ancel"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBrowse.Location = New System.Drawing.Point(382, 11)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(27, 23)
        Me.cmdBrowse.TabIndex = 2
        Me.cmdBrowse.Text = "..."
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(125, 68)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(251, 23)
        Me.txtPassword.TabIndex = 6
        '
        'txtDBPath
        '
        Me.txtDBPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtDBPath.Location = New System.Drawing.Point(125, 11)
        Me.txtDBPath.Name = "txtDBPath"
        Me.txtDBPath.ReadOnly = True
        Me.txtDBPath.Size = New System.Drawing.Size(251, 23)
        Me.txtDBPath.TabIndex = 1
        '
        'chkIsEncrypted
        '
        Me.chkIsEncrypted.AutoSize = True
        Me.chkIsEncrypted.Location = New System.Drawing.Point(125, 126)
        Me.chkIsEncrypted.Name = "chkIsEncrypted"
        Me.chkIsEncrypted.Size = New System.Drawing.Size(117, 19)
        Me.chkIsEncrypted.TabIndex = 9
        Me.chkIsEncrypted.Text = "&Encrypt Database"
        Me.chkIsEncrypted.UseVisualStyleBackColor = True
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(55, 72)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(57, 15)
        Me.lblPassword.TabIndex = 5
        Me.lblPassword.Text = "&Password"
        '
        'lblSqlDbName
        '
        Me.lblSqlDbName.AutoSize = True
        Me.lblSqlDbName.Location = New System.Drawing.Point(23, 15)
        Me.lblSqlDbName.Name = "lblSqlDbName"
        Me.lblSqlDbName.Size = New System.Drawing.Size(89, 15)
        Me.lblSqlDbName.TabIndex = 0
        Me.lblSqlDbName.Text = "&Folder to create"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "&Confirm Password"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(125, 97)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(251, 23)
        Me.txtConfirmPassword.TabIndex = 8
        '
        'lblDbName
        '
        Me.lblDbName.AutoSize = True
        Me.lblDbName.Location = New System.Drawing.Point(22, 44)
        Me.lblDbName.Name = "lblDbName"
        Me.lblDbName.Size = New System.Drawing.Size(90, 15)
        Me.lblDbName.TabIndex = 3
        Me.lblDbName.Text = "&Database Name"
        '
        'txtDBName
        '
        Me.txtDBName.Location = New System.Drawing.Point(125, 40)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(251, 23)
        Me.txtDBName.TabIndex = 4
        '
        'chkOverwrite
        '
        Me.chkOverwrite.AutoSize = True
        Me.chkOverwrite.Location = New System.Drawing.Point(124, 151)
        Me.chkOverwrite.Name = "chkOverwrite"
        Me.chkOverwrite.Size = New System.Drawing.Size(118, 19)
        Me.chkOverwrite.TabIndex = 10
        Me.chkOverwrite.Text = "&Overwrite if exists"
        Me.chkOverwrite.UseVisualStyleBackColor = True
        '
        'frmCreate
        '
        Me.AcceptButton = Me.CmdCreate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CmdCancel
        Me.ClientSize = New System.Drawing.Size(426, 217)
        Me.Controls.Add(Me.CmdCreate)
        Me.Controls.Add(Me.CmdCancel)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.txtDBName)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtDBPath)
        Me.Controls.Add(Me.chkOverwrite)
        Me.Controls.Add(Me.chkIsEncrypted)
        Me.Controls.Add(Me.lblDbName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblSqlDbName)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCreate"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create SQL CE Database"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdCreate As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtDBPath As System.Windows.Forms.TextBox
    Friend WithEvents chkIsEncrypted As System.Windows.Forms.CheckBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblSqlDbName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblDbName As System.Windows.Forms.Label
    Friend WithEvents txtDBName As System.Windows.Forms.TextBox
    Friend WithEvents chkOverwrite As System.Windows.Forms.CheckBox
End Class
