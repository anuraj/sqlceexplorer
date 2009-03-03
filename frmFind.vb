Public Class frmFind
    Public Event FindText(ByVal sender As Object, ByVal e As FindEventArgs)
    Private Sub txtFindWhat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFindWhat.TextChanged
        If txtFindWhat.TextLength >= 1 Then
            cmdFind.Enabled = True
        Else
            cmdFind.Enabled = False
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        RaiseEvent FindText(Me.txtFindWhat, New FindEventArgs(Me.txtFindWhat.Text, Me.chkMatchCase.Checked))
    End Sub
End Class