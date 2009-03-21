Public Class frmOptions
    Private m_CurrentFont As Font = Nothing
    Private m_IsConnected As Boolean = False
    Public Property IsConnected() As Boolean
        Get
            Return Me.m_IsConnected
        End Get
        Set(ByVal value As Boolean)
            Me.m_IsConnected = value
        End Set
    End Property
    Public Property CurrentFont() As Font
        Get
            Return m_CurrentFont
        End Get
        Set(ByVal value As Font)
            m_CurrentFont = value
        End Set
    End Property

    Private Sub cmdBrowseFonts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowseFonts.Click
        Using oFontDialog As New FontDialog
            With oFontDialog
                If m_CurrentFont IsNot Nothing Then
                    .Font = m_CurrentFont
                End If
                .ShowEffects = False
                .ShowHelp = False
                .ShowColor = False
                .FontMustExist = True
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.txtFont.Text = String.Format("{0} - {1}", .Font.Name, .Font.Size)
                    m_CurrentFont = .Font
                End If
            End With
        End Using
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim oSqlCeConfig As New SqlCeConfig
        With oSqlCeConfig
            .FontName = m_CurrentFont.Name
            .FontSize = m_CurrentFont.Size
            .ShowConnectDialogAtStartUp = Me.chkConneciondlg.Checked
            .RecentItems = Me.nuRecentFiles.Value
            .EnableRecentItems = Me.chkRecentItems.Checked
            .SaveConfig()
        End With
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oSqlCeConfig As New SqlCeConfig
        oSqlCeConfig.ReadConfig()
        If oSqlCeConfig.FontName IsNot Nothing Then
            Me.txtFont.Text = String.Format("{0} - {1}", oSqlCeConfig.FontName, oSqlCeConfig.FontSize)
        Else
            Me.txtFont.Text = String.Format("{0} - {1}", m_CurrentFont.Name, m_CurrentFont.Size)
        End If
        Me.chkRecentItems.Checked = oSqlCeConfig.EnableRecentItems
        Me.nuRecentFiles.Value = oSqlCeConfig.RecentItems
        Me.chkConneciondlg.Checked = oSqlCeConfig.ShowConnectDialogAtStartUp
        Me.ToggleRecentItems()
        oSqlCeConfig = Nothing

        Me.cmdCompact.Enabled = Me.m_IsConnected
        Me.cmdRepair.Enabled = Me.m_IsConnected

    End Sub

    Private Sub cmdCompact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompact.Click
        If MessageBox.Show(String.Format("This will try to compact the SQL CE Database you are connected.{0}Are you sure you want to continue?", Environment.NewLine), SqlCeMain.APPLICATION_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim oSqlCeExplorerDB As New SqlCeExplorerDB
            oSqlCeExplorerDB.CompactDatabase()
        End If
    End Sub

    
    Private Sub cmdRepair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRepair.Click
        If MessageBox.Show(String.Format("This will try repair the SQL CE Database you have connected.{0}This operation will try to recover corrupted rows.{0}Are you sure you want to continue?", Environment.NewLine), SqlCeMain.APPLICATION_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim oSqlCeExplorerDB As New SqlCeExplorerDB
            oSqlCeExplorerDB.RepairDatabase()
        End If
    End Sub

    Private Sub chkRecentItems_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecentItems.CheckedChanged
        Me.ToggleRecentItems()
    End Sub
    Private Sub ToggleRecentItems()
        Me.nuRecentFiles.Enabled = Me.chkRecentItems.Checked
        Me.lblRecentItems.Enabled = Me.chkRecentItems.Checked
    End Sub
End Class