<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModifyColumn
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
        Me.cmbColumnNames = New System.Windows.Forms.ComboBox
        Me.cmbDataType = New System.Windows.Forms.ComboBox
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.chkChangeDataType = New System.Windows.Forms.CheckBox
        Me.lblDataType = New System.Windows.Forms.Label
        Me.chkDropThisColumn = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.plDataTypeChange = New System.Windows.Forms.Panel
        Me.txtDataTypeLength = New System.Windows.Forms.TextBox
        Me.plDataTypeChange.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Column Name :"
        '
        'cmbColumnNames
        '
        Me.cmbColumnNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColumnNames.FormattingEnabled = True
        Me.cmbColumnNames.Location = New System.Drawing.Point(123, 13)
        Me.cmbColumnNames.Name = "cmbColumnNames"
        Me.cmbColumnNames.Size = New System.Drawing.Size(277, 23)
        Me.cmbColumnNames.TabIndex = 1
        '
        'cmbDataType
        '
        Me.cmbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataType.FormattingEnabled = True
        Me.cmbDataType.Items.AddRange(New Object() {"bigint", "binary", "bit", "datetime", "float", "image", "int", "money", "nchar", "nvarchar", "ntext", "numeric", "real", "smallint", "uniqueidentifier", "tinyint", "varbinary"})
        Me.cmbDataType.Location = New System.Drawing.Point(101, 6)
        Me.cmbDataType.Name = "cmbDataType"
        Me.cmbDataType.Size = New System.Drawing.Size(186, 23)
        Me.cmbDataType.TabIndex = 1
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(214, 155)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(90, 26)
        Me.cmdOk.TabIndex = 5
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(310, 155)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(90, 26)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'chkChangeDataType
        '
        Me.chkChangeDataType.AutoSize = True
        Me.chkChangeDataType.Location = New System.Drawing.Point(123, 62)
        Me.chkChangeDataType.Name = "chkChangeDataType"
        Me.chkChangeDataType.Size = New System.Drawing.Size(120, 19)
        Me.chkChangeDataType.TabIndex = 3
        Me.chkChangeDataType.Text = "Change Datatype"
        Me.chkChangeDataType.UseVisualStyleBackColor = True
        '
        'lblDataType
        '
        Me.lblDataType.AutoSize = True
        Me.lblDataType.Location = New System.Drawing.Point(34, 9)
        Me.lblDataType.Name = "lblDataType"
        Me.lblDataType.Size = New System.Drawing.Size(61, 15)
        Me.lblDataType.TabIndex = 0
        Me.lblDataType.Text = "Datatype :"
        '
        'chkDropThisColumn
        '
        Me.chkDropThisColumn.AutoSize = True
        Me.chkDropThisColumn.Location = New System.Drawing.Point(123, 41)
        Me.chkDropThisColumn.Name = "chkDropThisColumn"
        Me.chkDropThisColumn.Size = New System.Drawing.Size(148, 19)
        Me.chkDropThisColumn.TabIndex = 2
        Me.chkDropThisColumn.Text = "Drop selected Column"
        Me.chkDropThisColumn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Length :"
        '
        'plDataTypeChange
        '
        Me.plDataTypeChange.Controls.Add(Me.txtDataTypeLength)
        Me.plDataTypeChange.Controls.Add(Me.Label2)
        Me.plDataTypeChange.Controls.Add(Me.lblDataType)
        Me.plDataTypeChange.Controls.Add(Me.cmbDataType)
        Me.plDataTypeChange.Enabled = False
        Me.plDataTypeChange.Location = New System.Drawing.Point(22, 83)
        Me.plDataTypeChange.Name = "plDataTypeChange"
        Me.plDataTypeChange.Size = New System.Drawing.Size(378, 62)
        Me.plDataTypeChange.TabIndex = 4
        '
        'txtDataTypeLength
        '
        Me.txtDataTypeLength.Location = New System.Drawing.Point(101, 35)
        Me.txtDataTypeLength.Name = "txtDataTypeLength"
        Me.txtDataTypeLength.Size = New System.Drawing.Size(100, 21)
        Me.txtDataTypeLength.TabIndex = 3
        '
        'frmModifyColumn
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(422, 192)
        Me.Controls.Add(Me.plDataTypeChange)
        Me.Controls.Add(Me.chkDropThisColumn)
        Me.Controls.Add(Me.chkChangeDataType)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmbColumnNames)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModifyColumn"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modify Column"
        Me.plDataTypeChange.ResumeLayout(False)
        Me.plDataTypeChange.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbColumnNames As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataType As System.Windows.Forms.ComboBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents chkChangeDataType As System.Windows.Forms.CheckBox
    Friend WithEvents lblDataType As System.Windows.Forms.Label
    Friend WithEvents chkDropThisColumn As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents plDataTypeChange As System.Windows.Forms.Panel
    Friend WithEvents txtDataTypeLength As System.Windows.Forms.TextBox
End Class
