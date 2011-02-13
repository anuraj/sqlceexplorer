Public Class frmConnect
    Public Event SqlCeDatabaseConnected(ByVal sender As Object, ByVal e As EventArgs)
    Sub New()
        InitializeComponent()
    End Sub
    Sub New(ByVal Filename As String)
        InitializeComponent()
        Me.AddToDropdown(Filename)
    End Sub
    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Using oOpenFileDialog As New OpenFileDialog
            With oOpenFileDialog
                If Me.cmbFiles.SelectedIndex <> -1 Then
                    .FileName = Me.cmbFiles.SelectedItem.ToString
                End If
                .Filter = "SQL CE Database File(*.sdf)|*.sdf"
                .Multiselect = False
                .ShowReadOnly = False
                .ReadOnlyChecked = False
                .DefaultExt = "SDF"
                .CheckFileExists = True
                .SupportMultiDottedExtensions = True
                .ValidateNames = True
                .Title = "Select SQL CE Database file"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.AddToDropdown(.FileName)
                End If
            End With
        End Using
    End Sub
    Private Sub AddToDropdown(ByVal item As String)
        Dim index As Integer
        If Me.cmbFiles.Items.Contains(item) Then
            Me.cmbFiles.SelectedIndex = Me.cmbFiles.Items.IndexOf(item)
        Else
            index = Me.cmbFiles.Items.Count
            Me.cmbFiles.Items.Insert(index, item)
            Me.cmbFiles.SelectedIndex = index
        End If
    End Sub
    Private Sub CmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConnect.Click
        If Me.cmbFiles.SelectedIndex = -1 Then
            SqlCeExplorerUtility.ShowMessage("Database file cannot be empty", Me.cmbFiles)
            Return
        End If
        Dim databasename As String = Me.cmbFiles.SelectedItem.ToString
        SqlCeMain.CreateConnectionString(databasename, Me.txtPassword.Text, Me.chkIsEncrypted.Checked)
        If SqlCeExplorerData.CheckConnection Then
            RaiseEvent SqlCeDatabaseConnected(Me, e)
            Me.Close()
        End If
    End Sub

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oFrmCreate As New frmCreate
        AddHandler oFrmCreate.SqlCeDatabaseCreated, AddressOf oFrmCreate_SqlCeDatabaseCreated
        oFrmCreate.ShowDialog(Me)
    End Sub
    Private Sub oFrmCreate_SqlCeDatabaseCreated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent SqlCeDatabaseConnected(Me, e)
        Me.Close()
    End Sub

    Private Sub frmConnect_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim files As List(Of String) = SqlCeExplorerUtility.GetRecentItems
        If files IsNot Nothing Then
            For Each Item As String In files
                If IO.File.Exists(Item) AndAlso Not Me.cmbFiles.Items.Contains(Item) Then
                    Me.cmbFiles.Items.Add(Item)
                End If
            Next
        End If
    End Sub
End Class