Public Class FindEventArgs
    Inherits System.EventArgs
    Private m_Text As String
    Private m_MatchCase As Boolean
    Public Sub New(ByVal Text As String, ByVal MatchCase As Boolean)
        m_Text = Text
        m_MatchCase = MatchCase
    End Sub
    Public ReadOnly Property Text() As String
        Get
            Return m_Text
        End Get
    End Property
    Public ReadOnly Property MatchCase() As Boolean
        Get
            Return m_MatchCase
        End Get
    End Property
End Class
