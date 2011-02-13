<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExport
    Inherits SQLCEExplorer.Framework.frmBaseUI

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
        Me.cmbFileTypes = New System.Windows.Forms.ComboBox()
        Me.cmbTables = New System.Windows.Forms.ComboBox()
        Me.CmdOk = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.cmdShowAbout = New System.Windows.Forms.Button()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.lblTables = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbFileTypes
        '
        Me.cmbFileTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFileTypes.FormattingEnabled = True
        Me.cmbFileTypes.Location = New System.Drawing.Point(101, 38)
        Me.cmbFileTypes.Name = "cmbFileTypes"
        Me.cmbFileTypes.Size = New System.Drawing.Size(199, 23)
        Me.cmbFileTypes.TabIndex = 19
        '
        'cmbTables
        '
        Me.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTables.FormattingEnabled = True
        Me.cmbTables.Location = New System.Drawing.Point(101, 70)
        Me.cmbTables.Name = "cmbTables"
        Me.cmbTables.Size = New System.Drawing.Size(430, 23)
        Me.cmbTables.TabIndex = 20
        '
        'CmdOk
        '
        Me.CmdOk.Location = New System.Drawing.Point(349, 99)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(87, 27)
        Me.CmdOk.TabIndex = 17
        Me.CmdOk.Text = "&OK"
        Me.CmdOk.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Location = New System.Drawing.Point(444, 99)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(87, 27)
        Me.CmdCancel.TabIndex = 18
        Me.CmdCancel.Text = "C&ancel"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'cmdShowAbout
        '
        Me.cmdShowAbout.Location = New System.Drawing.Point(306, 38)
        Me.cmdShowAbout.Name = "cmdShowAbout"
        Me.cmdShowAbout.Size = New System.Drawing.Size(23, 23)
        Me.cmdShowAbout.TabIndex = 16
        Me.cmdShowAbout.Text = "?"
        Me.cmdShowAbout.UseVisualStyleBackColor = True
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(456, 9)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowse.TabIndex = 15
        Me.cmdBrowse.Text = "&Browse..."
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(101, 10)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(349, 21)
        Me.txtFileName.TabIndex = 14
        '
        'lblTables
        '
        Me.lblTables.AutoSize = True
        Me.lblTables.Enabled = False
        Me.lblTables.Location = New System.Drawing.Point(10, 76)
        Me.lblTables.Name = "lblTables"
        Me.lblTables.Size = New System.Drawing.Size(81, 15)
        Me.lblTables.TabIndex = 11
        Me.lblTables.Text = "&Table Name :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 15)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "&File Type :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "&File Name :"
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 133)
        Me.Controls.Add(Me.cmbFileTypes)
        Me.Controls.Add(Me.cmbTables)
        Me.Controls.Add(Me.CmdOk)
        Me.Controls.Add(Me.CmdCancel)
        Me.Controls.Add(Me.cmdShowAbout)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.lblTables)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmExport"
        Me.Text = "Export"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbFileTypes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTables As System.Windows.Forms.ComboBox
    Friend WithEvents CmdOk As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdShowAbout As System.Windows.Forms.Button
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblTables As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
