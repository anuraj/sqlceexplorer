<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQueryBuilder
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
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.cmdRemove = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.txtCriteria = New System.Windows.Forms.TextBox
        Me.chkOutput = New System.Windows.Forms.CheckBox
        Me.cmbColumns = New System.Windows.Forms.ComboBox
        Me.cmbTables = New System.Windows.Forms.ComboBox
        Me.cmdBuildQuery = New System.Windows.Forms.Button
        Me.txtOutput = New System.Windows.Forms.TextBox
        Me.dgvDesigner = New System.Windows.Forms.DataGridView
        Me.TableCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FieldCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OutputCol = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CriteriaCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.label2 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        CType(Me.dgvDesigner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(353, 3)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(46, 15)
        Me.label5.TabIndex = 25
        Me.label5.Text = "Criteria"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(306, 3)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(43, 15)
        Me.label4.TabIndex = 26
        Me.label4.Text = "Output"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(206, 3)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(56, 15)
        Me.label3.TabIndex = 27
        Me.label3.Text = "Columns"
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(3, 50)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(112, 23)
        Me.cmdRemove.TabIndex = 10
        Me.cmdRemove.Text = "Remove"
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(567, 50)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(112, 23)
        Me.cmdAdd.TabIndex = 4
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'txtCriteria
        '
        Me.txtCriteria.Location = New System.Drawing.Point(356, 22)
        Me.txtCriteria.Name = "txtCriteria"
        Me.txtCriteria.Size = New System.Drawing.Size(323, 21)
        Me.txtCriteria.TabIndex = 3
        '
        'chkOutput
        '
        Me.chkOutput.AutoSize = True
        Me.chkOutput.Location = New System.Drawing.Point(321, 26)
        Me.chkOutput.Name = "chkOutput"
        Me.chkOutput.Size = New System.Drawing.Size(15, 14)
        Me.chkOutput.TabIndex = 2
        Me.chkOutput.UseVisualStyleBackColor = True
        '
        'cmbColumns
        '
        Me.cmbColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColumns.FormattingEnabled = True
        Me.cmbColumns.Location = New System.Drawing.Point(209, 22)
        Me.cmbColumns.Name = "cmbColumns"
        Me.cmbColumns.Size = New System.Drawing.Size(96, 23)
        Me.cmbColumns.TabIndex = 1
        '
        'cmbTables
        '
        Me.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTables.FormattingEnabled = True
        Me.cmbTables.Location = New System.Drawing.Point(4, 22)
        Me.cmbTables.Name = "cmbTables"
        Me.cmbTables.Size = New System.Drawing.Size(199, 23)
        Me.cmbTables.TabIndex = 0
        '
        'cmdBuildQuery
        '
        Me.cmdBuildQuery.Location = New System.Drawing.Point(4, 220)
        Me.cmdBuildQuery.Name = "cmdBuildQuery"
        Me.cmdBuildQuery.Size = New System.Drawing.Size(154, 23)
        Me.cmdBuildQuery.TabIndex = 6
        Me.cmdBuildQuery.Text = "Build Query"
        Me.cmdBuildQuery.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(3, 249)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(676, 151)
        Me.txtOutput.TabIndex = 7
        '
        'dgvDesigner
        '
        Me.dgvDesigner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDesigner.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TableCol, Me.FieldCol, Me.OutputCol, Me.CriteriaCol})
        Me.dgvDesigner.Location = New System.Drawing.Point(3, 83)
        Me.dgvDesigner.Name = "dgvDesigner"
        Me.dgvDesigner.RowHeadersVisible = False
        Me.dgvDesigner.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDesigner.ShowCellErrors = False
        Me.dgvDesigner.ShowCellToolTips = False
        Me.dgvDesigner.ShowRowErrors = False
        Me.dgvDesigner.Size = New System.Drawing.Size(677, 130)
        Me.dgvDesigner.TabIndex = 5
        '
        'TableCol
        '
        Me.TableCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TableCol.FillWeight = 200.0!
        Me.TableCol.HeaderText = "Table"
        Me.TableCol.Name = "TableCol"
        Me.TableCol.ReadOnly = True
        Me.TableCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TableCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TableCol.Width = 200
        '
        'FieldCol
        '
        Me.FieldCol.HeaderText = "Column"
        Me.FieldCol.Name = "FieldCol"
        Me.FieldCol.ReadOnly = True
        Me.FieldCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FieldCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'OutputCol
        '
        Me.OutputCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.OutputCol.HeaderText = "Output"
        Me.OutputCol.Name = "OutputCol"
        Me.OutputCol.ReadOnly = True
        Me.OutputCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OutputCol.Width = 49
        '
        'CriteriaCol
        '
        Me.CriteriaCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CriteriaCol.HeaderText = "Criteria"
        Me.CriteriaCol.Name = "CriteriaCol"
        Me.CriteriaCol.ReadOnly = True
        Me.CriteriaCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CriteriaCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(3, 3)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(38, 15)
        Me.label2.TabIndex = 28
        Me.label2.Text = "Table"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(568, 406)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(112, 23)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(450, 406)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(112, 23)
        Me.cmdOk.TabIndex = 8
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmQueryBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 436)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.txtCriteria)
        Me.Controls.Add(Me.chkOutput)
        Me.Controls.Add(Me.cmbColumns)
        Me.Controls.Add(Me.cmbTables)
        Me.Controls.Add(Me.cmdBuildQuery)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.dgvDesigner)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQueryBuilder"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "QueryBuilder"
        CType(Me.dgvDesigner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents cmdRemove As System.Windows.Forms.Button
    Private WithEvents cmdAdd As System.Windows.Forms.Button
    Private WithEvents txtCriteria As System.Windows.Forms.TextBox
    Private WithEvents chkOutput As System.Windows.Forms.CheckBox
    Private WithEvents cmbColumns As System.Windows.Forms.ComboBox
    Private WithEvents cmbTables As System.Windows.Forms.ComboBox
    Private WithEvents cmdBuildQuery As System.Windows.Forms.Button
    Private WithEvents txtOutput As System.Windows.Forms.TextBox
    Private WithEvents dgvDesigner As System.Windows.Forms.DataGridView
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents TableCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FieldCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutputCol As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CriteriaCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents cmdCancel As System.Windows.Forms.Button
    Private WithEvents cmdOk As System.Windows.Forms.Button
End Class
