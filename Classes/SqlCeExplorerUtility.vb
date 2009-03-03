Public Class SqlCeExplorerUtility
    Public Shared Sub ShowMessage(ByVal Message As String, ByVal Control As Control)
        MessageBox.Show(Message, SqlCeMain.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        If Control IsNot Nothing AndAlso Control.CanFocus Then
            Control.Focus()
        End If
    End Sub
End Class
