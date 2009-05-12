<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModifyIndex
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbTables = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbIndex = New System.Windows.Forms.ComboBox
        Me.chkDropIndex = New System.Windows.Forms.CheckBox
        Me.chkUnique = New System.Windows.Forms.CheckBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmbColumns = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.plColumns = New System.Windows.Forms.Panel
        Me.plColumns.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Table"
        '
        'cmbTables
        '
        Me.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTables.FormattingEnabled = True
        Me.cmbTables.Location = New System.Drawing.Point(87, 7)
        Me.cmbTables.Name = "cmbTables"
        Me.cmbTables.Size = New System.Drawing.Size(279, 23)
        Me.cmbTables.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Index name"
        '
        'cmbIndex
        '
        Me.cmbIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIndex.FormattingEnabled = True
        Me.cmbIndex.Location = New System.Drawing.Point(87, 36)
        Me.cmbIndex.Name = "cmbIndex"
        Me.cmbIndex.Size = New System.Drawing.Size(279, 23)
        Me.cmbIndex.TabIndex = 3
        '
        'chkDropIndex
        '
        Me.chkDropIndex.AutoSize = True
        Me.chkDropIndex.Enabled = False
        Me.chkDropIndex.Location = New System.Drawing.Point(87, 65)
        Me.chkDropIndex.Name = "chkDropIndex"
        Me.chkDropIndex.Size = New System.Drawing.Size(108, 19)
        Me.chkDropIndex.TabIndex = 4
        Me.chkDropIndex.Text = "Drop this Index"
        Me.chkDropIndex.UseVisualStyleBackColor = True
        '
        'chkUnique
        '
        Me.chkUnique.AutoSize = True
        Me.chkUnique.Location = New System.Drawing.Point(75, 37)
        Me.chkUnique.Name = "chkUnique"
        Me.chkUnique.Size = New System.Drawing.Size(66, 19)
        Me.chkUnique.TabIndex = 2
        Me.chkUnique.Text = "Unique"
        Me.chkUnique.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(291, 158)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(210, 158)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 6
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmbColumns
        '
        Me.cmbColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColumns.FormattingEnabled = True
        Me.cmbColumns.Location = New System.Drawing.Point(75, 8)
        Me.cmbColumns.Name = "cmbColumns"
        Me.cmbColumns.Size = New System.Drawing.Size(279, 23)
        Me.cmbColumns.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Column"
        '
        'plColumns
        '
        Me.plColumns.Controls.Add(Me.chkUnique)
        Me.plColumns.Controls.Add(Me.cmbColumns)
        Me.plColumns.Controls.Add(Me.Label2)
        Me.plColumns.Location = New System.Drawing.Point(12, 84)
        Me.plColumns.Name = "plColumns"
        Me.plColumns.Size = New System.Drawing.Size(366, 65)
        Me.plColumns.TabIndex = 5
        '
        'frmModifyIndex
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(386, 190)
        Me.Controls.Add(Me.plColumns)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.chkDropIndex)
        Me.Controls.Add(Me.cmbIndex)
        Me.Controls.Add(Me.cmbTables)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModifyIndex"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modify Index"
        Me.plColumns.ResumeLayout(False)
        Me.plColumns.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTables As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbIndex As System.Windows.Forms.ComboBox
    Friend WithEvents chkDropIndex As System.Windows.Forms.CheckBox
    Friend WithEvents chkUnique As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmbColumns As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents plColumns As System.Windows.Forms.Panel
End Class
