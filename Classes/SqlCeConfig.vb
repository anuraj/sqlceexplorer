Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.IO
Imports Microsoft.Win32
Imports System.Collections.Specialized

<XmlRoot("SqlCeConfig")> _
Public Class SqlCeConfig

    Private m_FontName As String = "Courier New"
    Private m_FontSize As String = "12"
    Private m_ShowConnectDialogAtStartUp As Boolean = False
    Private m_RecentItems As String = String.Empty
    Private m_EnableRecentItems As Boolean = True
    Private m_FunctionsColor As String = "-8355712"
    Private m_VariableColor As String = "-65536"
    Private m_KeywordColor As String = "-16776961"
    Private m_CommentsColor As String = "-16744448"
    Private m_RecentItemsCount As String = "5"
    Private m_EnableAutoComplete As Boolean = False

    Public Property EnableAutoComplete As Boolean
        Get
            Return m_EnableAutoComplete
        End Get
        Set(ByVal value As Boolean)
            m_EnableAutoComplete = value
        End Set
    End Property

    Public Property RecentItemsCount() As String
        Get
            Return m_RecentItemsCount
        End Get
        Set(ByVal value As String)
            m_RecentItemsCount = value
        End Set
    End Property
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
    Private m_EnableSyntaxHighlight As Boolean = False
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
            With My.Settings
                .CommentHighlight = Me.EnableCommentHighlight
                .CommentsColor = Me.CommentsColor
                .CurrentUser = Environment.UserName
                .EnableRecentItems = Me.EnableRecentItems
                .EnableSyntaxHighlight = Me.EnableSyntaxHighlight
                .FontName = Me.FontName
                .FontSize = Me.FontSize
                .FunctionsColor = Me.FunctionsColor
                .KeywordColor = Me.KeywordColor
                .ShowConnectDialogAtStartUp = Me.ShowConnectDialogAtStartUp
                .VariableColor = Me.VariableColor
                .VariableHighlight = Me.EnableVariableHighlight
                .RecentItemsCount = Me.RecentItemsCount
                .EnableAutoComplete = Me.EnableAutoComplete
                .Save()
            End With
        Catch

        End Try
    End Sub
    Public Sub ReadConfig()
        Try
            With My.Settings
                Me.EnableCommentHighlight = .CommentHighlight
                Me.CommentsColor = .CommentsColor
                Me.EnableRecentItems = .EnableRecentItems
                Me.EnableSyntaxHighlight = .EnableSyntaxHighlight
                Me.FontName = .FontName
                Me.FontSize = .FontSize
                Me.FunctionsColor = .FunctionsColor
                Me.KeywordColor = .KeywordColor
                Me.ShowConnectDialogAtStartUp = .ShowConnectDialogAtStartUp
                Me.VariableColor = .VariableColor
                Me.EnableVariableHighlight = .VariableHighlight
                Me.RecentItemsCount = .RecentItemsCount
                Me.EnableAutoComplete = .EnableAutoComplete
            End With
        Catch
            'do nothing
        End Try
    End Sub
End Class
