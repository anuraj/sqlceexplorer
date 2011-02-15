Imports System.Data
Imports System.Data.SqlServerCe
Public Class SqlCeDatalayer
    Private m_Connection As SqlCeConnection
    Private m_Command As SqlCeCommand
    Public Sub New(ByVal ConnectionString As String)
        m_Connection = New SqlCeConnection(ConnectionString)
    End Sub
    Public Sub Connect()
        If m_Connection IsNot Nothing Then
            If m_Connection.State <> ConnectionState.Open Then
                m_Connection.Open()
            End If
        End If
    End Sub
    Public Sub Disconnect()
        If m_Connection IsNot Nothing AndAlso m_Connection.State = ConnectionState.Open Then
            m_Connection.Close()
            m_Connection = Nothing
        End If
    End Sub
    Public Function ExecuteReader(ByVal Query As String) As SqlCeDataReader
        m_Command = New SqlCeCommand(Query, m_Connection)
        Return m_Command.ExecuteReader(CommandBehavior.Default AndAlso CommandBehavior.CloseConnection)
    End Function
    Public Function ExecuteReader(ByVal Query As String, ByVal Transaction As SqlCeTransaction) As SqlCeDataReader
        m_Command = New SqlCeCommand(Query, m_Connection)
        m_Command.Transaction = Transaction
        Return m_Command.ExecuteReader(CommandBehavior.CloseConnection)
    End Function
    Public Sub ExecuteNonQuery(ByVal Query As String, ByVal Transaction As SqlCeTransaction)
        m_Command = New SqlCeCommand(Query, m_Connection)
        m_Command.Transaction = Transaction
        m_Command.ExecuteNonQuery()
    End Sub
    Public ReadOnly Property Connection() As SqlCeConnection
        Get
            Return m_Connection
        End Get
    End Property
End Class
