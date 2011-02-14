Public Class frmSplash

    Private Sub frmSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblDevelopedBy.Text = SqlCeMain.GetAppInfo
    End Sub
End Class