Namespace Framework.Interfaces
    Public Interface IImportModule
        Function ImportFile(ByVal filename As String) As DataTable
        Sub ShowAbout()
        ReadOnly Property FileTypes As String
        ReadOnly Property FileExtention As String
    End Interface
End Namespace