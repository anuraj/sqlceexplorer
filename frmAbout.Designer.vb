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
        Me.txtLicenceInfo = New System.Windows.Forms.TextBox
        Me.cmdOk = New System.Windows.Forms.Button
        Me.llLinkToCodePlex = New System.Windows.Forms.LinkLabel
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
        Me.lblAppName.Location = New System.Drawing.Point(47, 12)
        Me.lblAppName.Name = "lblAppName"
        Me.lblAppName.Size = New System.Drawing.Size(106, 17)
        Me.lblAppName.TabIndex = 1
        Me.lblAppName.Text = "SQL CE Explorer"
        '
        'lblDevelopedBy
        '
        Me.lblDevelopedBy.AutoSize = True
        Me.lblDevelopedBy.Location = New System.Drawing.Point(47, 45)
        Me.lblDevelopedBy.Name = "lblDevelopedBy"
        Me.lblDevelopedBy.Size = New System.Drawing.Size(127, 15)
        Me.lblDevelopedBy.TabIndex = 2
        Me.lblDevelopedBy.Text = "Developed by Anuraj P"
        '
        'lblAppVersion
        '
        Me.lblAppVersion.AutoSize = True
        Me.lblAppVersion.Location = New System.Drawing.Point(47, 243)
        Me.lblAppVersion.Name = "lblAppVersion"
        Me.lblAppVersion.Size = New System.Drawing.Size(46, 15)
        Me.lblAppVersion.TabIndex = 3
        Me.lblAppVersion.Text = "Version"
        '
        'txtLicenceInfo
        '
        Me.txtLicenceInfo.BackColor = System.Drawing.SystemColors.Window
        Me.txtLicenceInfo.Location = New System.Drawing.Point(47, 68)
        Me.txtLicenceInfo.Multiline = True
        Me.txtLicenceInfo.Name = "txtLicenceInfo"
        Me.txtLicenceInfo.ReadOnly = True
        Me.txtLicenceInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLicenceInfo.ShortcutsEnabled = False
        Me.txtLicenceInfo.Size = New System.Drawing.Size(394, 145)
        Me.txtLicenceInfo.TabIndex = 0
        '
        'cmdOk
        '
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOk.Location = New System.Drawing.Point(366, 10)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 5
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'llLinkToCodePlex
        '
        Me.llLinkToCodePlex.ActiveLinkColor = System.Drawing.Color.Blue
        Me.llLinkToCodePlex.AutoSize = True
        Me.llLinkToCodePlex.Location = New System.Drawing.Point(47, 220)
        Me.llLinkToCodePlex.Name = "llLinkToCodePlex"
        Me.llLinkToCodePlex.Size = New System.Drawing.Size(160, 15)
        Me.llLinkToCodePlex.TabIndex = 6
        Me.llLinkToCodePlex.TabStop = True
        Me.llLinkToCodePlex.Text = "SQL CE Explorer - Homepage"
        Me.llLinkToCodePlex.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'frmAbout
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdOk
        Me.ClientSize = New System.Drawing.Size(453, 268)
        Me.Controls.Add(Me.llLinkToCodePlex)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtLicenceInfo)
        Me.Controls.Add(Me.lblAppVersion)
        Me.Controls.Add(Me.lblDevelopedBy)
        Me.Controls.Add(Me.lblAppName)
        Me.Controls.Add(Me.picIcon)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
    Friend WithEvents txtLicenceInfo As System.Windows.Forms.TextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents llLinkToCodePlex As System.Windows.Forms.LinkLabel
End Class
