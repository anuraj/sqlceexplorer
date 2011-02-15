Imports Microsoft.Win32
Imports System.Security.Permissions
Imports System.Security.AccessControl

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
            .RecentItemsCount = Me.nuRecentFiles.Value
            .EnableRecentItems = Me.chkRecentItems.Checked
            .EnableAutoComplete = Me.chkAutoComplete.Checked

            .EnableSyntaxHighlight = Me.chkEnableSyntaxHighlighting.Checked
            If Me.chkEnableSyntaxHighlighting.Checked Then
                .EnableCommentHighlight = Me.chkHighlightComments.Checked
                .EnableVariableHighlight = Me.chkHighlightVariables.Checked
                .KeywordColor = Me.txtKeywordSample.ForeColor.ToArgb.ToString
                .CommentsColor = Me.txtCommentSample.ForeColor.ToArgb.ToString
                .VariableColor = Me.txtVariableSample.ForeColor.ToArgb.ToString
                .FunctionsColor = Me.txtFunctionSample.ForeColor.ToArgb.ToString
            Else
                .EnableCommentHighlight = False
                .EnableVariableHighlight = False
            End If
            .IsAssociatedToSdf = Me.chkAssociate.Checked

            AssociateToSDFFile(Me.chkAssociate.Checked, Application.ExecutablePath)

            .SaveConfig()
        End With
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        tcOptions.TabPages.Remove(tpDBOptions)

        Dim oSqlCeConfig As New SqlCeConfig
        oSqlCeConfig.ReadConfig()
        If oSqlCeConfig.FontName IsNot Nothing Then
            Me.txtFont.Text = String.Format("{0} - {1}", oSqlCeConfig.FontName, oSqlCeConfig.FontSize)
        Else
            Me.txtFont.Text = String.Format("{0} - {1}", m_CurrentFont.Name, m_CurrentFont.Size)
        End If
        Me.chkRecentItems.Checked = oSqlCeConfig.EnableRecentItems
        Me.nuRecentFiles.Value = oSqlCeConfig.RecentItemsCount
        Me.chkConneciondlg.Checked = oSqlCeConfig.ShowConnectDialogAtStartUp

        Me.chkEnableSyntaxHighlighting.Checked = oSqlCeConfig.EnableSyntaxHighlight
        Me.plMain.Enabled = Me.chkEnableSyntaxHighlighting.Checked
        Me.chkHighlightComments.Checked = oSqlCeConfig.EnableCommentHighlight
        Me.plComments.Enabled = Me.chkHighlightComments.Checked
        Me.chkHighlightVariables.Checked = oSqlCeConfig.EnableVariableHighlight
        Me.plVariables.Enabled = Me.chkHighlightVariables.Checked

        Me.chkAutoComplete.Checked = oSqlCeConfig.EnableAutoComplete

        If oSqlCeConfig.CommentsColor IsNot Nothing Then
            Me.txtCommentSample.ForeColor = Color.FromArgb(oSqlCeConfig.CommentsColor)
        End If
        If oSqlCeConfig.FunctionsColor IsNot Nothing Then
            Me.txtFunctionSample.ForeColor = Color.FromArgb(oSqlCeConfig.FunctionsColor)
        End If
        If oSqlCeConfig.KeywordColor IsNot Nothing Then
            Me.txtKeywordSample.ForeColor = Color.FromArgb(oSqlCeConfig.KeywordColor)
        End If
        If oSqlCeConfig.VariableColor IsNot Nothing Then
            Me.txtVariableSample.ForeColor = Color.FromArgb(oSqlCeConfig.VariableColor)
        End If
        Me.chkAssociate.Checked = oSqlCeConfig.IsAssociatedToSdf

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

    Private Sub chkEnableSyntaxHighlighting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableSyntaxHighlighting.CheckedChanged
        Me.plMain.Enabled = Me.chkEnableSyntaxHighlighting.Checked
    End Sub

    Private Sub chkHighlightComments_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHighlightComments.CheckedChanged
        Me.plComments.Enabled = Me.chkHighlightComments.Checked
    End Sub

    Private Sub chkHighlightVariables_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHighlightVariables.CheckedChanged
        Me.plVariables.Enabled = Me.chkHighlightVariables.Checked
    End Sub

    Private Sub cmdBrowseComments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowseComments.Click
        Me.txtCommentSample.ForeColor = Me.GetColor(Me.txtCommentSample.ForeColor)
    End Sub

    Private Sub cmdBrowseVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowseVariable.Click
        Me.txtVariableSample.ForeColor = Me.GetColor(Me.txtVariableSample.ForeColor)
    End Sub

    Private Sub cmdBrowseKeyWords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowseKeyWords.Click
        Me.txtKeywordSample.ForeColor = Me.GetColor(Me.txtKeywordSample.ForeColor)
    End Sub

    Private Sub cmdBrowseFunctions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowseFunctions.Click
        Me.txtFunctionSample.ForeColor = Me.GetColor(Me.txtFunctionSample.ForeColor)
    End Sub

    Private Function GetColor(ByVal current As Color) As Color
        Dim result As Color = current
        Using dlg As New ColorDialog
            With dlg
                .Color = current
                .AllowFullOpen = False
                .AnyColor = False
                .FullOpen = False
                .SolidColorOnly = True
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    result = .Color
                End If
            End With
        End Using
        Return result
    End Function

    Private Sub AssociateToSDFFile(ByVal associate As Boolean, ByVal appPath As String)
        Dim sdfFileAssoc As RegistryKey = My.Computer.Registry.ClassesRoot.OpenSubKey(".sdf", True)
        If associate Then
            If sdfFileAssoc Is Nothing Then
                sdfFileAssoc = My.Computer.Registry.ClassesRoot.CreateSubKey(".sdf")
            End If
            sdfFileAssoc.SetValue("", "SQLCEExplorer", RegistryValueKind.String)
            My.Computer.Registry.ClassesRoot.CreateSubKey("SQLCEExplorer\Shell\Explore with SQLCE Explorer\Command").SetValue("", _
                        String.Format("{0} ""%1""", appPath), Microsoft.Win32.RegistryValueKind.String)
        Else
            If sdfFileAssoc Is Nothing Then
                Return
            End If
            sdfFileAssoc.SetValue("", "Microsoft SQL Server Compact Edition Database File", RegistryValueKind.String)
            My.Computer.Registry.ClassesRoot.DeleteSubKeyTree("SQLCEExplorer")
        End If
    End Sub
End Class