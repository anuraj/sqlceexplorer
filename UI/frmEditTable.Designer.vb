<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditTable
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
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.plMain = New System.Windows.Forms.Panel()
        Me.dgvEditRows = New System.Windows.Forms.DataGridView()
        Me.plMain.SuspendLayout()
        CType(Me.dgvEditRows, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(486, 352)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(87, 27)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(579, 352)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(87, 27)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'plMain
        '
        Me.plMain.AutoScroll = True
        Me.plMain.Controls.Add(Me.dgvEditRows)
        Me.plMain.Location = New System.Drawing.Point(8, 5)
        Me.plMain.Name = "plMain"
        Me.plMain.Size = New System.Drawing.Size(658, 341)
        Me.plMain.TabIndex = 9
        '
        'dgvEditRows
        '
        Me.dgvEditRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEditRows.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEditRows.Location = New System.Drawing.Point(0, 0)
        Me.dgvEditRows.Margin = New System.Windows.Forms.Padding(5)
        Me.dgvEditRows.Name = "dgvEditRows"
        Me.dgvEditRows.RowHeadersVisible = False
        Me.dgvEditRows.Size = New System.Drawing.Size(658, 341)
        Me.dgvEditRows.TabIndex = 10
        '
        'frmEditTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 391)
        Me.Controls.Add(Me.plMain)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "frmEditTable"
        Me.Text = "Edit Table"
        Me.plMain.ResumeLayout(False)
        CType(Me.dgvEditRows, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents plMain As System.Windows.Forms.Panel
    Friend WithEvents dgvEditRows As System.Windows.Forms.DataGridView
End Class
