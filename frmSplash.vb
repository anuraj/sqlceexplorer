Public Class frmSplash

    Private Sub frmSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblAppVersion.Text = String.Format("{0} Ver. Alpha 01", SqlCeMain.APPLICATION_NAME)
    End Sub
End Class