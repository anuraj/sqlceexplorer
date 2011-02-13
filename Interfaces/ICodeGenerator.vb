Namespace Framework.Interfaces
    Public Interface ICodeGenerator
        ReadOnly Property Language As String
        ReadOnly Property FileExtention As String
        Sub Initialize(ByVal directory As String, ByVal databaseName As String)
        Sub GenerateCode(ByVal tableNames As IEnumerable(Of String))
        Sub ShowAbout()
        Sub GenerateProject(ByVal databaseName As String)
    End Interface
End Namespace