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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.plMain.SuspendLayout()
        CType(Me.dgvEditRows, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(3, 4)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(87, 27)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(96, 4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(87, 27)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'plMain
        '
        Me.plMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.plMain.AutoScroll = True
        Me.plMain.Controls.Add(Me.dgvEditRows)
        Me.plMain.Location = New System.Drawing.Point(8, 5)
        Me.plMain.Name = "plMain"
        Me.plMain.Size = New System.Drawing.Size(658, 337)
        Me.plMain.TabIndex = 9
        '
        'dgvEditRows
        '
        Me.dgvEditRows.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEditRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEditRows.Location = New System.Drawing.Point(0, 0)
        Me.dgvEditRows.Margin = New System.Windows.Forms.Padding(5)
        Me.dgvEditRows.Name = "dgvEditRows"
        Me.dgvEditRows.RowHeadersVisible = False
        Me.dgvEditRows.Size = New System.Drawing.Size(658, 337)
        Me.dgvEditRows.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.cmdOk)
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Location = New System.Drawing.Point(478, 348)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(188, 35)
        Me.Panel1.TabIndex = 10
        '
        'frmEditTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 387)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.plMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MinimumSize = New System.Drawing.Size(691, 423)
        Me.Name = "frmEditTable"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Edit Table"
        Me.plMain.ResumeLayout(False)
        CType(Me.dgvEditRows, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents plMain As System.Windows.Forms.Panel
    Friend WithEvents dgvEditRows As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
