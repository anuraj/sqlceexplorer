Imports System.IO
Imports System.Reflection
Public Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblAppName.Text = SqlCeMain.APPLICATION_NAME
        Me.lblAppVersion.Text = String.Format("{0} Ver. Alpha 01", SqlCeMain.APPLICATION_NAME)
        Using reader As New StreamReader(Assembly.GetExecutingAssembly.GetManifestResourceStream("SQLCEExplorer.licence.txt"))
            Me.txtLicenceInfo.Text = reader.ReadToEnd()
            reader.Close()
        End Using
        Me.txtLicenceInfo.SelectedText = String.Empty
        Me.txtLicenceInfo.SelectionStart = 0
        Me.txtLicenceInfo.SelectionLength = 0
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.Close()
    End Sub

    Private Sub llLinkToCodePlex_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLinkToCodePlex.LinkClicked
        Dim homepageUrl As String = "http://anuraj.wordpress.com/sqlceexplorer"
        Process.Start(homepageUrl)
    End Sub
End Class