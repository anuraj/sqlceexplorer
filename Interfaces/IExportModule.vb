Namespace Framework.Interfaces
    Public Interface IExportModule
        Function ExportFile(ByVal data As DataTable, ByVal fileName As String) As Boolean
        Sub ShowAbout()
        ReadOnly Property FileTypes As String
        ReadOnly Property FileExtention As String
    End Interface
End Namespace