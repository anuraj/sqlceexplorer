Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.IO
Imports Microsoft.Win32

<XmlRoot("SqlCeConfig")> _
Public Class SqlCeConfig
    Private m_FileName As String
    Private m_FilePath As String

    Private m_FontName As String
    Private m_FontSize As String
    Private m_ShowConnectDialogAtStartUp As Boolean
    Private m_RecentItems As String = "1"
    Private m_EnableRecentItems As Boolean = True
    <XmlElement("FontName")> _
    Public Property FontName() As String
        Get
            Return m_FontName
        End Get
        Set(ByVal value As String)
            m_FontName = value
        End Set
    End Property
    <XmlElement("FontSize")> _
    Public Property FontSize() As String
        Get
            Return m_FontSize
        End Get
        Set(ByVal value As String)
            m_FontSize = value
        End Set
    End Property
    <XmlElement("ShowConnectDialogAtStartUp")> _
    Public Property ShowConnectDialogAtStartUp() As Boolean
        Get
            Return m_ShowConnectDialogAtStartUp
        End Get
        Set(ByVal value As Boolean)
            m_ShowConnectDialogAtStartUp = value
        End Set
    End Property
    Public Property RecentItems() As String
        Get
            Return m_RecentItems
        End Get
        Set(ByVal value As String)
            m_RecentItems = value
        End Set
    End Property
    Public Property EnableRecentItems() As Boolean
        Get
            Return m_EnableRecentItems
        End Get
        Set(ByVal value As Boolean)
            m_EnableRecentItems = value
        End Set
    End Property
    Public Sub New()
        m_FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location)
        m_FileName = String.Format("SQLCEExplorer.{0}.Config", Environment.UserName)
    End Sub
    Public Sub SaveConfig()
        'Dim fileName As String = Path.Combine(m_FilePath, m_FileName)
        'Dim serializer As New XmlSerializer(GetType(SqlCeConfig))
        'Using sw As New StreamWriter(File.Open(fileName, FileMode.OpenOrCreate))
        '    serializer.Serialize(sw, Me)
        '    sw.Flush()
        '    sw.Close()
        'End Using
        Dim rootKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software")
        Dim AppNameKey As RegistryKey = rootKey.CreateSubKey(SqlCeMain.APPLICATION_NAME)
        Dim settingsKey As RegistryKey = AppNameKey.CreateSubKey("Settings")
        settingsKey.SetValue("CurrentUser", Environment.UserName)
        settingsKey.SetValue("FontName", Me.FontName)
        settingsKey.SetValue("FontSize", Me.FontSize)
        settingsKey.SetValue("ShowConnectDialogAtStartUp", Me.ShowConnectDialogAtStartUp)
        settingsKey.SetValue("EnableRecentItems", Me.EnableRecentItems)
        settingsKey.SetValue("RecentItems", Me.RecentItems)
        settingsKey.Close()
        AppNameKey.Close()
        rootKey.Close()
    End Sub
    Public Sub ReadConfig()
        'Try
        '    Dim fileName As String = Path.Combine(m_FilePath, m_FileName)
        '    If File.Exists(fileName) Then
        '        Dim oSqlCeConfing As SqlCeConfig = Nothing
        '        Dim serializer As New XmlSerializer(GetType(SqlCeConfig))
        '        Using sw As New StreamReader(File.Open(fileName, FileMode.Open))
        '            oSqlCeConfing = TryCast(serializer.Deserialize(sw), SqlCeConfig)
        '            sw.Close()
        '        End Using
        '        If oSqlCeConfing IsNot Nothing Then
        '            Me.m_FontName = oSqlCeConfing.FontName
        '            Me.m_FontSize = oSqlCeConfing.FontSize
        '            Me.m_ShowConnectDialogAtStartUp = oSqlCeConfing.ShowConnectDialogAtStartUp
        '        End If
        '    End If
        'Catch ex As Exception
        '    'do nothing
        'End Try
        Dim rootKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software")
        Dim AppNameKey As RegistryKey = rootKey.CreateSubKey(SqlCeMain.APPLICATION_NAME)
        If AppNameKey IsNot Nothing AndAlso AppNameKey.SubKeyCount >= 1 Then
            Dim settingsKey As RegistryKey = AppNameKey.CreateSubKey("Settings")
            If settingsKey IsNot Nothing AndAlso settingsKey.ValueCount >= 1 Then
                Me.m_FontName = settingsKey.GetValue("FontName").ToString
                Me.m_FontSize = settingsKey.GetValue("FontSize").ToString
                Me.m_RecentItems = IIf(settingsKey.GetValue("RecentItems") Is Nothing, "1", settingsKey.GetValue("RecentItems"))
                Me.m_EnableRecentItems = Boolean.Parse(IIf(settingsKey.GetValue("EnableRecentItems") Is Nothing, True, settingsKey.GetValue("EnableRecentItems").ToString).ToString)
                Me.m_ShowConnectDialogAtStartUp = Boolean.Parse(settingsKey.GetValue("ShowConnectDialogAtStartUp").ToString)
                settingsKey.Close()
            End If
            AppNameKey.Close()
        End If
        rootKey.Close()
    End Sub


End Class
