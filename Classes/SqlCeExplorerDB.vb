Imports System.Data.SqlServerCe
Public Class SqlCeExplorerDB
    Public Function CreateDatabase(ByVal DatabaseFile As String, ByVal Password As String, ByVal Encrypted As Boolean) As Boolean
        Dim oSqlCeEngine As SqlCeEngine
        Try
            SqlCeMain.ClearConnectionString()   'Clearing existing connection string.
            SqlCeMain.CreateConnectionString(DatabaseFile, Password, Encrypted)
            oSqlCeEngine = New SqlCeEngine(SqlCeMain.GetConnectionString())
            oSqlCeEngine.CreateDatabase()
            Return True
        Catch ex As Exception
            SqlCeExplorerException.Show(ex)
            Return False
        Finally
            oSqlCeEngine = Nothing
        End Try
    End Function
    Public Function CompactDatabase() As Boolean
        Dim oSqlCeEngine As SqlCeEngine
        Try
            oSqlCeEngine = New SqlCeEngine(SqlCeMain.GetConnectionString())
            oSqlCeEngine.Compact(SqlCeMain.GetConnectionString())
            oSqlCeEngine.Shrink()
            Return True
        Catch ex As Exception
            SqlCeExplorerException.Show(ex)
            Return False
        Finally
            oSqlCeEngine = Nothing
        End Try
    End Function
    Public Function RepairDatabase() As Boolean
        Dim oSqlCeEngine As SqlCeEngine
        Try
            oSqlCeEngine = New SqlCeEngine(SqlCeMain.GetConnectionString())
            oSqlCeEngine.Repair(SqlCeMain.GetConnectionString(), RepairOption.RecoverAllPossibleRows)
            oSqlCeEngine.Shrink()
            Return True
        Catch ex As Exception
            SqlCeExplorerException.Show(ex)
            Return False
        Finally
            oSqlCeEngine = Nothing
        End Try
    End Function
    Public Function UpgradeDatabase() As Boolean
        Dim oSqlCeEngine As SqlCeEngine
        Try
            oSqlCeEngine = New SqlCeEngine(SqlCeMain.GetConnectionString())
            oSqlCeEngine.Upgrade()
            Return True
        Catch ex As Exception
            SqlCeExplorerException.Show(ex)
            Return False
        Finally
            oSqlCeEngine = Nothing
        End Try
    End Function
End Class
