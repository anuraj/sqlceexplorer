Public Class SqlCeExplorerException
    Public Shared Sub Show(ByVal ex As Exception)
        Dim exMessage As String = "An error occured.{0}Error : {1}"
        MessageBox.Show(String.Format(exMessage, Environment.NewLine, ex.Message), SqlCeMain.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Public Shared Sub ShowError(ByVal ex As Exception)
        Dim exMessage As String = "A System error occured.{0}Error : {1}{0}{0}Please report bugs : http://www.codeplex.com/sqlceexplorer"
        MessageBox.Show(String.Format(exMessage, Environment.NewLine, ex.Message), SqlCeMain.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Class
