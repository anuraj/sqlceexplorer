Imports System.IO

Public Class SqlCeExplorerException
    Public Shared Sub Show(ByVal ex As Exception)
        Dim exMessage As String = "An error occured.{0}Error : {1}"
        MessageBox.Show(String.Format(exMessage, Environment.NewLine, ex.Message), SqlCeMain.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Public Shared Sub ShowError(ByVal ex As Exception)
        LogError(ex)
        Dim exMessage As String = "A System error occured.{0}A error report also created in the application folder(SysError.log).{0}Error : {1}{0}{0}Please report bugs : http://sqlceexplorer.codeplex.com"
        MessageBox.Show(String.Format(exMessage, Environment.NewLine, ex.Message), SqlCeMain.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    Public Shared Sub LogError(ByVal ex As Exception)
        Dim errorLogPath As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "SysError.log")

        Using sw As New StreamWriter(errorLogPath)
            sw.WriteLine("<errorlog>")
            sw.WriteLine(String.Format("<date>{0}</date>", Date.Today.ToShortDateString))
            sw.WriteLine(String.Format("<time>{0}</time>", Date.Today.ToShortTimeString))
            sw.WriteLine(String.Format("<message>{0}</message>", ex.Message))
            sw.WriteLine(String.Format("<source>{0}</source>", ex.Source))
            sw.WriteLine(String.Format("<stackTrace>{0}</stackTrace>", ex.StackTrace))
            sw.WriteLine("</errorlog>")
        End Using

    End Sub
End Class
