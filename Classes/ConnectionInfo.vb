Public Class ConnectionInfo
    Private _databaseName As String
    Private _isEncrypted As Boolean
    Private _Password As String

    Public Property DatabaseName As String
        Get
            Return _databaseName
        End Get
        Set(ByVal value As String)
            _databaseName = value
        End Set
    End Property
    Public Property IsEncrypted As Boolean
        Get
            Return _isEncrypted
        End Get
        Set(ByVal value As Boolean)
            _isEncrypted = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property
    Private Const CONNECTION_STRING_TEMPLATE As String = "Data Source={0};Encrypt Database={2};Password={1};Persist Security Info=False;"
    Public Overrides Function ToString() As String
        Return String.Format(CONNECTION_STRING_TEMPLATE, DatabaseName, Password, IsEncrypted)
    End Function
    Public Function ToObject(ByVal text As String) As ConnectionInfo
        Dim info As New ConnectionInfo
        With info
            .Password = GetString(text, "Password=")
            .DatabaseName = GetString(text, "Data Source=")
            .IsEncrypted = Convert.ToBoolean(GetString(text, "Encrypt Database="))
        End With
        Return info
    End Function
    Private Function GetString(ByVal text As String, ByVal prefix As String) As String
        Dim result As String = String.Empty
        Dim texts As String() = text.Split(New String() {";"}, StringSplitOptions.RemoveEmptyEntries)
        For Each item As String In texts
            Dim i As Integer = item.IndexOf(prefix)
            If i >= 0 Then
                result = item.Substring(i)
                Exit For
            End If
        Next
        Return result
    End Function
End Class
