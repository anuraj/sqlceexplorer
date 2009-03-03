Imports System.Data
Imports System.Data.SqlServerCe

Public Class SqlCeExplorerData
    Private Const PARSE_SUCCESS As String = "Query parsed successfully"
    Private Const PARSE_FAILED As String = "Query parsing failed"
    Private Const EXECUTE_SUCCESS As String = "Query executed successfully"
    Private Const EXECUTE_FAILED As String = "Query execution failed."
    Private m_ParseMessage As String
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
            oSqlCeDataLayer.ExecuteNonQuery(Query, oTrans)
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
    Public Function Fill(ByVal Reader As SqlCeDataReader) As DataTable
        Dim oDataset As New DataSet
        oDataset.EnforceConstraints = False
        oDataset.Tables.Add(New DataTable)
        oDataset.Tables(0).Load(Reader)
        Return oDataset.Tables(0)
    End Function

    Public Shared Function CheckConnection() As Boolean
        Dim oSqlCeDataLayer As SqlCeDatalayer = Nothing
        Try
            oSqlCeDataLayer = New SqlCeDatalayer(SqlCeMain.GetConnectionString())
            oSqlCeDataLayer.Connect()
            Return True
        Catch ex As Exception
            SqlCeExplorerException.Show(ex)
            Return False
        Finally
            oSqlCeDataLayer.Disconnect()
            oSqlCeDataLayer = Nothing
        End Try
    End Function

End Class
