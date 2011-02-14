Imports System.IO
Imports System.Reflection
Public Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblAppName.Text = SqlCeMain.APPLICATION_NAME
        Me.lblAppVersion.Text = String.Format("Assembly version :{0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString())
        Me.lblDevelopedBy.Text = SqlCeMain.GetAppInfo()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.Close()
    End Sub

    Private Sub llLinkToCodePlex_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLinkToCodePlex.LinkClicked
        Dim homepageUrl As String = "http://sqlceexplorer.codeplex.com"
        Process.Start(homepageUrl)
    End Sub
End Class