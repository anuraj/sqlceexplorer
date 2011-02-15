Imports System.Data
Imports System.Data.SqlServerCe

Public Class SqlCeExplorerData
    Private Const PARSE_SUCCESS As String = "Query parsed successfully"
    Private Const PARSE_FAILED As String = "Query parsing failed"
    Private Const EXECUTE_SUCCESS As String = "Query executed successfully"
    Private Const EXECUTE_FAILED As String = "Query execution failed."
    Private m_ParseMessage As String
    Private m_Delimeter() As String = {";", "GO"}
    Public ReadOnly Property ParseMessage() As String
        Get
            Return m_ParseMessage
        End Get
    End Property
    Public Function ParseQuery(ByVal Query As String) As Boolean
        Dim oTrans As SqlCeTransaction = Nothing
        Dim oSqlCeDataLayer As SqlCeDatalayer = Nothing
        Dim result As Boolean = False
        Try
            oSqlCeDataLayer = New SqlCeDatalayer(SqlCeMain.GetConnectionString())
            oSqlCeDataLayer.Connect()
            oTrans = oSqlCeDataLayer.Connection.BeginTransaction(IsolationLevel.Serializable)

            Dim queries() As String = Query.Split(m_Delimeter, StringSplitOptions.RemoveEmptyEntries)
            If queries.Length > 1 Then
                For Each _query As String In queries
                    oSqlCeDataLayer.ExecuteNonQuery(_query, oTrans)
                Next
            Else
                oSqlCeDataLayer.ExecuteNonQuery(Query, oTrans)
            End If

            m_ParseMessage = PARSE_SUCCESS
            result = True
            If oTrans IsNot Nothing Then
                oTrans.Rollback()
            End If
        Catch ex As Exception
            m_ParseMessage = String.Format("{0}{1}Error: {2}", PARSE_FAILED, Environment.NewLine, ex.Message)
            If oTrans IsNot Nothing Then
                oTrans.Rollback()
            End If
            result = False
        Finally
            oSqlCeDataLayer.Disconnect()
            oSqlCeDataLayer = Nothing
        End Try
        Return result
    End Function
    Public Function ExecuteQuery(ByVal Query As String) As SqlCeDataReader
        Dim oSqlCeDataLayer As SqlCeDatalayer = Nothing
        Dim result As Boolean = False
        Try
            oSqlCeDataLayer = New SqlCeDatalayer(SqlCeMain.GetConnectionString())
            oSqlCeDataLayer.Connect()
            m_ParseMessage = EXECUTE_SUCCESS
            Return oSqlCeDataLayer.ExecuteReader(Query)
        Catch ex As Exception
            m_ParseMessage = String.Format("{0}{1}Error: {2}", EXECUTE_FAILED, Environment.NewLine, ex.Message)
            oSqlCeDataLayer.Disconnect()
            Return Nothing
        Finally
            oSqlCeDataLayer = Nothing
        End Try
    End Function
    Public Function ExecuteMultipleQueries(ByVal Queries() As String) As List(Of SqlCeDataReader)
        Dim oSqlCeDataLayer As SqlCeDatalayer = Nothing
        Dim results As New List(Of SqlCeDataReader)(Queries.Length)
        Dim result As Boolean = False
        Try
            oSqlCeDataLayer = New SqlCeDatalayer(SqlCeMain.GetConnectionString())
            oSqlCeDataLayer.Connect()
            m_ParseMessage = EXECUTE_SUCCESS
            For Each query As String In Queries
                If query.Trim().Length >= 1 Then
                    results.Add(oSqlCeDataLayer.ExecuteReader(query))
                End If
            Next
        Catch ex As Exception
            m_ParseMessage = String.Format("{0}{1}Error: {2}", EXECUTE_FAILED, Environment.NewLine, ex.Message)
            oSqlCeDataLayer.Disconnect()
            Return Nothing
        Finally
            oSqlCeDataLayer = Nothing
        End Try
        Return results
    End Function
    Public Function Fill(ByVal reader As SqlCeDataReader) As DataTable
        Dim dt As New DataTable()
        dt.Load(reader)
        Return dt
    End Function

    Public Shared Function CheckConnection() As Boolean
        Dim oSqlCeDataLayer As SqlCeDatalayer = Nothing
        Try
            oSqlCeDataLayer = New SqlCeDatalayer(SqlCeMain.GetConnectionString())
            oSqlCeDataLayer.Connect()
            Return True
        Catch DBFormatException As SqlCeInvalidDatabaseFormatException
            If ConfirmUpgrade() Then
                MessageBox.Show("Database upgraded successfully", APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information)
                oSqlCeDataLayer.Connect()
                Return True
            End If
            Return False
        Catch ex As Exception
            SqlCeExplorerException.Show(ex)
            Return False
        Finally
            oSqlCeDataLayer.Disconnect()
            oSqlCeDataLayer = Nothing
        End Try
    End Function
    Public Shared Function ConfirmUpgrade() As Boolean
        Dim confirmMsg As String = "The database file has been created by an earlier version of SQL Server Compact{0}" & _
        "Would you like to upgrade it to the latest version?{0}{0}Please take backup of your database before continuing."
        If MessageBox.Show(String.Format(confirmMsg, Environment.NewLine), APPLICATION_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Dim oSqlCeExplorerDB As New SqlCeExplorerDB()
            Return oSqlCeExplorerDB.UpgradeDatabase()
        Else
            MessageBox.Show(String.Format("{0} doesn't support this version of database files", APPLICATION_NAME), APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
    End Function
End Class
