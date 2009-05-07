<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Me.picIcon = New System.Windows.Forms.PictureBox
        Me.lblAppName = New System.Windows.Forms.Label
        Me.lblDevelopedBy = New System.Windows.Forms.Label
        Me.lblAppVersion = New System.Windows.Forms.Label
        Me.cmdOk = New System.Windows.Forms.Button
        Me.llLinkToCodePlex = New System.Windows.Forms.LinkLabel
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picIcon
        '
        Me.picIcon.Image = Global.SQLCEExplorer.My.Resources.Resources.database_add
        Me.picIcon.Location = New System.Drawing.Point(15, 11)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(18, 18)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picIcon.TabIndex = 0
        Me.picIcon.TabStop = False
        '
        'lblAppName
        '
        Me.lblAppName.AutoSize = True
        Me.lblAppName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppName.Location = New System.Drawing.Point(50, 12)
        Me.lblAppName.Name = "lblAppName"
        Me.lblAppName.Size = New System.Drawing.Size(106, 17)
        Me.lblAppName.TabIndex = 1
        Me.lblAppName.Text = "SQL CE Explorer"
        '
        'lblDevelopedBy
        '
        Me.lblDevelopedBy.AutoSize = True
        Me.lblDevelopedBy.Location = New System.Drawing.Point(50, 67)
        Me.lblDevelopedBy.Name = "lblDevelopedBy"
        Me.lblDevelopedBy.Size = New System.Drawing.Size(304, 60)
        Me.lblDevelopedBy.TabIndex = 2
        Me.lblDevelopedBy.Text = "Copyright © 2009 Anuraj.P" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Version Beta 0.1 ( May 09, 2009)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "See gnu_licence.tx" & _
            "t for copyright and redistribution info"
        '
        'lblAppVersion
        '
        Me.lblAppVersion.AutoSize = True
        Me.lblAppVersion.Location = New System.Drawing.Point(50, 167)
        Me.lblAppVersion.Name = "lblAppVersion"
        Me.lblAppVersion.Size = New System.Drawing.Size(103, 15)
        Me.lblAppVersion.TabIndex = 3
        Me.lblAppVersion.Text = "Assembly Version"
        '
        'cmdOk
        '
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOk.Location = New System.Drawing.Point(140, 201)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(95, 23)
        Me.cmdOk.TabIndex = 5
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'llLinkToCodePlex
        '
        Me.llLinkToCodePlex.ActiveLinkColor = System.Drawing.Color.Blue
        Me.llLinkToCodePlex.AutoSize = True
        Me.llLinkToCodePlex.Location = New System.Drawing.Point(50, 144)
        Me.llLinkToCodePlex.Name = "llLinkToCodePlex"
        Me.llLinkToCodePlex.Size = New System.Drawing.Size(171, 15)
        Me.llLinkToCodePlex.TabIndex = 6
        Me.llLinkToCodePlex.TabStop = True
        Me.llLinkToCodePlex.Text = "SQL CE Explorer - Homepage"
        Me.llLinkToCodePlex.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "A simple utility to explore SQL CE Database"
        '
        'frmAbout
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdOk
        Me.ClientSize = New System.Drawing.Size(374, 236)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.llLinkToCodePlex)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lblAppVersion)
        Me.Controls.Add(Me.lblDevelopedBy)
        Me.Controls.Add(Me.lblAppName)
        Me.Controls.Add(Me.picIcon)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblAppName As System.Windows.Forms.Label
    Friend WithEvents lblDevelopedBy As System.Windows.Forms.Label
    Friend WithEvents lblAppVersion As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents llLinkToCodePlex As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
