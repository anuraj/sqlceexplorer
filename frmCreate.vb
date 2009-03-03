Imports System.IO
Public Class frmCreate
    Public Event SqlCeDatabaseCreated(ByVal sender As Object, ByVal e As EventArgs)
    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Using oFolderDialog As New FolderBrowserDialog
            With oFolderDialog
                .Description = "Select a Folder to create the Database"
                .ShowNewFolderButton = True
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.txtDBPath.Text = .SelectedPath
                End If
            End With
        End Using
    End Sub

    Private Sub CmdCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCreate.Click
        If Me.txtDBPath.Text.Equals(String.Empty) Then
            SqlCeExplorerUtility.ShowMessage("Please select a Folder to create the SQL CE Database", Me.cmdBrowse)
            Return
        End If

        If Me.txtDBName.Text.Equals(String.Empty) Then
            SqlCeExplorerUtility.ShowMessage("Please enter the name of SQL CE Database to create", Me.txtDBName)
            Return
        End If

        If Not Me.txtPassword.Text.Equals(Me.txtConfirmPassword.Text) Then
            SqlCeExplorerUtility.ShowMessage("Password and Confirm Password not matching", Me.txtPassword)
            Return
        End If
        Dim dbFilename As String = Path.Combine(Me.txtDBPath.Text, Me.txtDBName.Text)

        If Not Path.HasExtension(dbFilename) Then
            dbFilename = String.Concat(dbFilename, ".sdf")
        End If

        If File.Exists(dbFilename) AndAlso chkOverwrite.Checked Then
            Try
                File.Delete(dbFilename)
            Catch ex As Exception
                SqlCeExplorerException.Show(ex)
                Return
            End Try
        End If

        Dim oSqlCeExplorerDb As New SqlCeExplorerDB
        If oSqlCeExplorerDb.CreateDatabase(dbFilename, Me.txtPassword.Text, chkIsEncrypted.Checked) Then
            RaiseEvent SqlCeDatabaseCreated(Me, e)
            Me.Close()
        End If
    End Sub

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub
End Class