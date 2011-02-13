<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelationShips
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
        Me.txtRelationshipName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbTables = New System.Windows.Forms.ComboBox
        Me.txtFKTable = New System.Windows.Forms.TextBox
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbPKTableColumns = New System.Windows.Forms.ComboBox
        Me.cmbFKTableColumns = New System.Windows.Forms.ComboBox
        Me.cmbUpdateRule = New System.Windows.Forms.ComboBox
        Me.cmbDeleteRule = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'txtRelationshipName
        '
        Me.txtRelationshipName.Location = New System.Drawing.Point(56, 9)
        Me.txtRelationshipName.Name = "txtRelationshipName"
        Me.txtRelationshipName.Size = New System.Drawing.Size(290, 21)
        Me.txtRelationshipName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Primary Key Table"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(188, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Foriegn Key Table"
        '
        'cmbTables
        '
        Me.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTables.FormattingEnabled = True
        Me.cmbTables.Location = New System.Drawing.Point(11, 61)
        Me.cmbTables.Name = "cmbTables"
        Me.cmbTables.Size = New System.Drawing.Size(158, 23)
        Me.cmbTables.TabIndex = 1
        '
        'txtFKTable
        '
        Me.txtFKTable.Location = New System.Drawing.Point(188, 63)
        Me.txtFKTable.Name = "txtFKTable"
        Me.txtFKTable.ReadOnly = True
        Me.txtFKTable.Size = New System.Drawing.Size(158, 21)
        Me.txtFKTable.TabIndex = 2
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(154, 205)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(90, 26)
        Me.cmdOk.TabIndex = 6
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(256, 205)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(90, 26)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Updates"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(188, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 15)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Deletes"
        '
        'cmbPKTableColumns
        '
        Me.cmbPKTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPKTableColumns.FormattingEnabled = True
        Me.cmbPKTableColumns.Location = New System.Drawing.Point(11, 106)
        Me.cmbPKTableColumns.Name = "cmbPKTableColumns"
        Me.cmbPKTableColumns.Size = New System.Drawing.Size(158, 23)
        Me.cmbPKTableColumns.TabIndex = 2
        '
        'cmbFKTableColumns
        '
        Me.cmbFKTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFKTableColumns.FormattingEnabled = True
        Me.cmbFKTableColumns.Location = New System.Drawing.Point(188, 106)
        Me.cmbFKTableColumns.Name = "cmbFKTableColumns"
        Me.cmbFKTableColumns.Size = New System.Drawing.Size(158, 23)
        Me.cmbFKTableColumns.TabIndex = 3
        '
        'cmbUpdateRule
        '
        Me.cmbUpdateRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUpdateRule.FormattingEnabled = True
        Me.cmbUpdateRule.Items.AddRange(New Object() {"NO ACTION", "CASCADE", "SET DEFAULT", "SET NULL"})
        Me.cmbUpdateRule.Location = New System.Drawing.Point(11, 165)
        Me.cmbUpdateRule.Name = "cmbUpdateRule"
        Me.cmbUpdateRule.Size = New System.Drawing.Size(159, 23)
        Me.cmbUpdateRule.TabIndex = 4
        '
        'cmbDeleteRule
        '
        Me.cmbDeleteRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDeleteRule.FormattingEnabled = True
        Me.cmbDeleteRule.Items.AddRange(New Object() {"NO ACTION", "CASCADE", "SET DEFAULT", "SET NULL"})
        Me.cmbDeleteRule.Location = New System.Drawing.Point(188, 165)
        Me.cmbDeleteRule.Name = "cmbDeleteRule"
        Me.cmbDeleteRule.Size = New System.Drawing.Size(159, 23)
        Me.cmbDeleteRule.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Columns"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(188, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 15)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Columns"
        '
        'frmRelationShips
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(353, 239)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmbFKTableColumns)
        Me.Controls.Add(Me.cmbDeleteRule)
        Me.Controls.Add(Me.cmbUpdateRule)
        Me.Controls.Add(Me.cmbPKTableColumns)
        Me.Controls.Add(Me.cmbTables)
        Me.Controls.Add(Me.txtFKTable)
        Me.Controls.Add(Me.txtRelationshipName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRelationShips"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RelationShips - Tables and Columns"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRelationshipName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbTables As System.Windows.Forms.ComboBox
    Friend WithEvents txtFKTable As System.Windows.Forms.TextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbPKTableColumns As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFKTableColumns As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUpdateRule As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDeleteRule As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
