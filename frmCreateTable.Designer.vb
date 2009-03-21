<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateTable
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
        Me.lblTableName = New System.Windows.Forms.Label
        Me.txtTableName = New System.Windows.Forms.TextBox
        Me.dgvCreateTable = New System.Windows.Forms.DataGridView
        Me.ColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataType = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ucLength = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ucAllowNulls = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ucUnique = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ucPrimaryKey = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        CType(Me.dgvCreateTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Location = New System.Drawing.Point(15, 20)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(41, 15)
        Me.lblTableName.TabIndex = 0
        Me.lblTableName.Text = "&Name"
        '
        'txtTableName
        '
        Me.txtTableName.Location = New System.Drawing.Point(64, 15)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(468, 21)
        Me.txtTableName.TabIndex = 1
        '
        'dgvCreateTable
        '
        Me.dgvCreateTable.AllowUserToDeleteRows = False
        Me.dgvCreateTable.AllowUserToResizeColumns = False
        Me.dgvCreateTable.AllowUserToResizeRows = False
        Me.dgvCreateTable.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCreateTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCreateTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnName, Me.DataType, Me.ucLength, Me.ucAllowNulls, Me.ucUnique, Me.ucPrimaryKey})
        Me.dgvCreateTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvCreateTable.EnableHeadersVisualStyles = False
        Me.dgvCreateTable.Location = New System.Drawing.Point(19, 54)
        Me.dgvCreateTable.MultiSelect = False
        Me.dgvCreateTable.Name = "dgvCreateTable"
        Me.dgvCreateTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCreateTable.RowHeadersVisible = False
        Me.dgvCreateTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvCreateTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCreateTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCreateTable.Size = New System.Drawing.Size(514, 219)
        Me.dgvCreateTable.TabIndex = 2
        '
        'ColumnName
        '
        Me.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColumnName.HeaderText = "Column Name"
        Me.ColumnName.Name = "ColumnName"
        Me.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataType
        '
        Me.DataType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataType.HeaderText = "Data Type"
        Me.DataType.Items.AddRange(New Object() {"bigint", "binary", "bit", "datetime", "float", "image", "int", "money", "nchar", "nvarchar", "ntext", "numeric", "real", "smallint", "uniqueidentifier", "tinyint", "varbinary"})
        Me.DataType.Name = "DataType"
        Me.DataType.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'ucLength
        '
        Me.ucLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ucLength.HeaderText = "Length"
        Me.ucLength.Name = "ucLength"
        Me.ucLength.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ucLength.Width = 51
        '
        'ucAllowNulls
        '
        Me.ucAllowNulls.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ucAllowNulls.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ucAllowNulls.HeaderText = "Allow Nulls"
        Me.ucAllowNulls.Items.AddRange(New Object() {"Yes", "No"})
        Me.ucAllowNulls.Name = "ucAllowNulls"
        Me.ucAllowNulls.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucAllowNulls.Width = 73
        '
        'ucUnique
        '
        Me.ucUnique.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ucUnique.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ucUnique.HeaderText = "Unique"
        Me.ucUnique.Items.AddRange(New Object() {"No", "Yes"})
        Me.ucUnique.Name = "ucUnique"
        Me.ucUnique.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucUnique.Width = 53
        '
        'ucPrimaryKey
        '
        Me.ucPrimaryKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ucPrimaryKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ucPrimaryKey.HeaderText = "Primary Key"
        Me.ucPrimaryKey.Items.AddRange(New Object() {"No", "Yes"})
        Me.ucPrimaryKey.Name = "ucPrimaryKey"
        Me.ucPrimaryKey.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucPrimaryKey.Width = 78
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(19, 293)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(87, 27)
        Me.cmdDelete.TabIndex = 5
        Me.cmdDelete.Text = "&Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(446, 293)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(87, 27)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(353, 293)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(87, 27)
        Me.cmdOk.TabIndex = 3
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmCreateTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 332)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.dgvCreateTable)
        Me.Controls.Add(Me.txtTableName)
        Me.Controls.Add(Me.lblTableName)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCreateTable"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create Table"
        CType(Me.dgvCreateTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTableName As System.Windows.Forms.Label
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents dgvCreateTable As System.Windows.Forms.DataGridView
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents ColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ucLength As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ucAllowNulls As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ucUnique As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ucPrimaryKey As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
