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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.plMain = New System.Windows.Forms.Panel()
        Me.lblDevelopedBy = New System.Windows.Forms.Label()
        Me.plMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(293, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 37)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Explorer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(149, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 86)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Sql Ce"
        '
        'plMain
        '
        Me.plMain.BackColor = System.Drawing.Color.Transparent
        Me.plMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plMain.Controls.Add(Me.lblDevelopedBy)
        Me.plMain.Controls.Add(Me.Label2)
        Me.plMain.Controls.Add(Me.Label1)
        Me.plMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plMain.Location = New System.Drawing.Point(0, 0)
        Me.plMain.Name = "plMain"
        Me.plMain.Size = New System.Drawing.Size(486, 197)
        Me.plMain.TabIndex = 11
        '
        'lblDevelopedBy
        '
        Me.lblDevelopedBy.AutoSize = True
        Me.lblDevelopedBy.Location = New System.Drawing.Point(161, 131)
        Me.lblDevelopedBy.Name = "lblDevelopedBy"
        Me.lblDevelopedBy.Size = New System.Drawing.Size(304, 45)
        Me.lblDevelopedBy.TabIndex = 10
        Me.lblDevelopedBy.Text = "Copyright © 2011 Anuraj.P" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Version Beta 1.1 (Feb 13, 2011)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "See gnu_licence.txt f" & _
            "or copyright and redistribution info"
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(486, 197)
        Me.Controls.Add(Me.plMain)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSplash"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSplash"
        Me.plMain.ResumeLayout(False)
        Me.plMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents plMain As System.Windows.Forms.Panel
    Friend WithEvents lblDevelopedBy As System.Windows.Forms.Label
End Class
