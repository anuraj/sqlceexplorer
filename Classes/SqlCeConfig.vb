Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.IO
Imports Microsoft.Win32

<XmlRoot("SqlCeConfig")> _
Public Class SqlCeConfig

    Private m_FontName As String
    Private m_FontSize As String
    Private m_ShowConnectDialogAtStartUp As Boolean
    Private m_RecentItems As String = "1"
    Private m_EnableRecentItems As Boolean = True
    Private m_FunctionsColor As String = "Grey"
    Private m_VariableColor As String = "Red"
    Private m_KeywordColor As String = "Blue"
    Private m_CommentsColor As String = "Green"

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
    Private m_EnableSyntaxHighlight As Boolean
    Public Property EnableSyntaxHighlight() As Boolean
        Get
            Return m_EnableSyntaxHighlight
        End Get
        Set(ByVal value As Boolean)
            m_EnableSyntaxHighlight = value
        End Set
    End Property
    Private m_EnableCommentHighlight As Boolean
    Public Property EnableCommentHighlight() As Boolean
        Get
            Return m_EnableCommentHighlight
        End Get
        Set(ByVal value As Boolean)
            m_EnableCommentHighlight = value
        End Set
    End Property
    Private m_EnableVariableHighlight As Boolean
    Public Property EnableVariableHighlight() As Boolean
        Get
            Return m_EnableVariableHighlight
        End Get
        Set(ByVal value As Boolean)
            m_EnableVariableHighlight = value
        End Set
    End Property

    Public Property KeywordColor() As String
        Get
            Return m_KeywordColor
        End Get
        Set(ByVal value As String)
            m_KeywordColor = value
        End Set
    End Property


    Public Property VariableColor() As String
        Get
            Return m_VariableColor
        End Get
        Set(ByVal value As String)
            m_VariableColor = value
        End Set
    End Property


    Public Property CommentsColor() As String
        Get
            Return m_CommentsColor
        End Get
        Set(ByVal value As String)
            m_CommentsColor = value
        End Set
    End Property


    Public Property FunctionsColor() As String
        Get
            Return m_FunctionsColor
        End Get
        Set(ByVal value As String)
            m_FunctionsColor = value
        End Set
    End Property

    Public Sub SaveConfig()
        Try
            Dim rootKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software")
            Dim AppNameKey As RegistryKey = rootKey.CreateSubKey(SqlCeMain.APPLICATION_NAME)
            Dim settingsKey As RegistryKey = AppNameKey.CreateSubKey("Settings")
            settingsKey.SetValue("CurrentUser", Environment.UserName)
            settingsKey.SetValue("FontName", Me.FontName)
            settingsKey.SetValue("FontSize", Me.FontSize)
            settingsKey.SetValue("ShowConnectDialogAtStartUp", Me.ShowConnectDialogAtStartUp)
            settingsKey.SetValue("EnableRecentItems", Me.EnableRecentItems)
            settingsKey.SetValue("RecentItems", Me.RecentItems)

            settingsKey.SetValue("EnableSyntaxHighlight", Me.EnableSyntaxHighlight)
            settingsKey.SetValue("VariableHighlight", Me.EnableVariableHighlight)
            settingsKey.SetValue("CommentHighlight", Me.EnableCommentHighlight)
            settingsKey.SetValue("KeywordColor", Me.KeywordColor)
            settingsKey.SetValue("FunctionsColor", Me.FunctionsColor)
            settingsKey.SetValue("CommentsColor", Me.CommentsColor)
            settingsKey.SetValue("VariableColor", Me.VariableColor)

            settingsKey.Close()
            AppNameKey.Close()
            rootKey.Close()
        Catch

        End Try
    End Sub
    Public Sub ReadConfig()
        Try
            Dim rootKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software")
            Dim AppNameKey As RegistryKey = rootKey.CreateSubKey(SqlCeMain.APPLICATION_NAME)
            If AppNameKey IsNot Nothing AndAlso AppNameKey.SubKeyCount >= 1 Then
                Dim settingsKey As RegistryKey = AppNameKey.CreateSubKey("Settings")
                If settingsKey IsNot Nothing AndAlso settingsKey.ValueCount >= 1 Then
                    Me.m_FontName = settingsKey.GetValue("FontName").ToString
                    Me.m_FontSize = settingsKey.GetValue("FontSize").ToString
                    Me.m_ShowConnectDialogAtStartUp = Boolean.Parse(settingsKey.GetValue("ShowConnectDialogAtStartUp").ToString)

                    If settingsKey.GetValue("RecentItems") Is Nothing Then
                        Me.m_RecentItems = "1"
                    Else
                        Me.m_RecentItems = settingsKey.GetValue("RecentItems")
                    End If
                    If settingsKey.GetValue("EnableRecentItems") Is Nothing Then
                        Me.m_EnableRecentItems = True
                    Else
                        Me.m_EnableRecentItems = Boolean.Parse(settingsKey.GetValue("EnableRecentItems").ToString)
                    End If

                    Me.EnableSyntaxHighlight = settingsKey.GetValue("EnableSyntaxHighlight")
                    Me.EnableVariableHighlight = settingsKey.GetValue("VariableHighlight")
                    Me.EnableCommentHighlight = settingsKey.GetValue("CommentHighlight")
                    Me.KeywordColor = settingsKey.GetValue("KeywordColor")
                    Me.FunctionsColor = settingsKey.GetValue("FunctionsColor")
                    Me.CommentsColor = settingsKey.GetValue("CommentsColor")
                    Me.VariableColor = settingsKey.GetValue("VariableColor")

                    settingsKey.Close()
                End If
                AppNameKey.Close()
            End If
            rootKey.Close()

        Catch
            'do nothing
        End Try
    End Sub


End Class
