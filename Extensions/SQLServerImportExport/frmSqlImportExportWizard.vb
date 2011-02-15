Public Class frmSqlImportExportWizard
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = &H1328 AndAlso Not DesignMode Then
            m.Result = 1
        Else
            MyBase.WndProc(m)
        End If
    End Sub
End Class