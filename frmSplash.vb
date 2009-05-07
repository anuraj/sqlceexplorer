Public Class frmSplash

    Private Sub frmSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblAppVersion.Text = String.Format("Assembly version :{0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString())
        Dim g As Graphics = Me.CreateGraphics
        Dim myBrush As New System.Drawing.Drawing2D.LinearGradientBrush _
           (ClientRectangle, Color.Red, Color.Yellow, _
           System.Drawing.Drawing2D.LinearGradientMode.Vertical)
        g.FillRectangle(myBrush, ClientRectangle)
    End Sub

End Class