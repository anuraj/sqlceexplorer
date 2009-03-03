Public Class frmConnect
    Public Event SqlCeDatabaseConnected(ByVal sender As Object, ByVal e As EventArgs)
    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Using oOpenFileDialog As New OpenFileDialog
            With oOpenFileDialog
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
                    Me.txtDatabaseFilename.Text = .FileName
                End If
            End With
        End Using
    End Sub

    Private Sub CmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConnect.Click
        SqlCeMain.CreateConnectionString(Me.txtDatabaseFilename.Text, Me.txtPassword.Text, Me.chkIsEncrypted.Checked)
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

End Class