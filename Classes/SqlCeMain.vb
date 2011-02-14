Module SqlCeMain

    Private m_Database As String
    Private m_Password As String
    Private m_Encrypted As Boolean
    Private m_ConnectionString As String
    Private m_Query As String
    'File Mode=Exclusive;
    Private Const CONNECTION_STRING_TEMPLATE As String = "Data Source={0};Encrypt Database={2};Password={1};Persist Security Info=False;"
    Public Const APPLICATION_NAME As String = "SQL CE Explorer"
    Public Function GetAppInfo() As String
        Return "Copyright © 2011 Anuraj.P" & vbCrLf & _
            "Version Beta 1.1 (Feb13, 2011)." & vbCrLf & vbCrLf & _
            "See gnu_licence.txt for copyright and redistribution info."
    End Function
    Public Sub CreateConnectionString(ByVal DatabaseFile As String, ByVal Password As String, ByVal Encrypted As Boolean)
        m_Database = DatabaseFile
        m_Password = Password
        m_Encrypted = Encrypted
    End Sub
    Public Sub CreateConnectionString(ByVal ConnectionString As String)
        m_ConnectionString = ConnectionString
    End Sub
    Public Function GetConnectionString() As String
        m_ConnectionString = String.Format(CONNECTION_STRING_TEMPLATE, m_Database, m_Password, m_Encrypted)
        Return m_ConnectionString
    End Function
    Public Function GetFileName() As String
        Dim tempFilename As String = m_ConnectionString.Substring(m_ConnectionString.IndexOf("Data Source="), m_ConnectionString.IndexOf(";"))
        Dim fileName As String = tempFilename.Substring(tempFilename.IndexOf("=") + 1)
        Return fileName
    End Function
    Public Sub ClearConnectionString()
        m_ConnectionString = Nothing
    End Sub
    Public Sub CurrentQuery(ByVal Query As String)
        m_Query = Query
    End Sub
    Public Function GetCurrentQuery() As String
        Return m_Query
    End Function
End Module

