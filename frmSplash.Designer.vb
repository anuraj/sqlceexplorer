<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplash
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
        Me.lblAppVersion = New System.Windows.Forms.Label
        Me.plMain = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.plMain.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAppVersion
        '
        Me.lblAppVersion.AutoSize = True
        Me.lblAppVersion.BackColor = System.Drawing.Color.White
        Me.lblAppVersion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppVersion.Location = New System.Drawing.Point(33, 160)
        Me.lblAppVersion.Name = "lblAppVersion"
        Me.lblAppVersion.Size = New System.Drawing.Size(46, 13)
        Me.lblAppVersion.TabIndex = 4
        Me.lblAppVersion.Text = "Version"
        '
        'plMain
        '
        Me.plMain.BackColor = System.Drawing.Color.White
        Me.plMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plMain.Controls.Add(Me.PictureBox1)
        Me.plMain.Controls.Add(Me.lblAppVersion)
        Me.plMain.Controls.Add(Me.Label2)
        Me.plMain.Controls.Add(Me.Label1)
        Me.plMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plMain.Location = New System.Drawing.Point(0, 0)
        Me.plMain.Name = "plMain"
        Me.plMain.Size = New System.Drawing.Size(383, 193)
        Me.plMain.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SQLCEExplorer.My.Resources.Resources.database_add
        Me.PictureBox1.Location = New System.Drawing.Point(9, 157)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(175, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Explorer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(91, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 65)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SQL CE"
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 193)
        Me.Controls.Add(Me.plMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSplash"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSplash"
        Me.plMain.ResumeLayout(False)
        Me.plMain.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblAppVersion As System.Windows.Forms.Label
    Friend WithEvents plMain As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
