Imports System.Text
Imports System.Text.RegularExpressions
Imports System.ComponentModel

Public Class SQLTextbox
    Inherits System.Windows.Forms.RichTextBox
    Private m_Keywords As List(Of String)
    Private m_Operators As List(Of String)
    Private m_HighlightComments As Boolean = True
    Private m_HighlightVariables As Boolean = True

    Private m_KeywordColor As Color = Color.Blue
    Private m_VariableColor As Color = Color.Red
    Private m_OperatorColor As Color = Color.Gray
    Private m_CommentsColor As Color = Color.Green

    Private m_IsParsed As Boolean = False
    Private m_KeywordStrings As StringBuilder
    Private m_OperatorStrings As StringBuilder
    <Category("Syntax Highlighting"), Description("Color of the Keyword")> _
    Public Property KeywordColor() As Color
        Get
            Return m_KeywordColor
        End Get
        Set(ByVal value As Color)
            m_KeywordColor = value
        End Set
    End Property
    <Category("Syntax Highlighting")> _
    Public Property VariableColor() As Color
        Get
            Return m_VariableColor
        End Get
        Set(ByVal value As Color)
            m_VariableColor = value
        End Set
    End Property
    <Category("Syntax Highlighting")> _
    Public Property OperatorColor() As Color
        Get
            Return m_OperatorColor
        End Get
        Set(ByVal value As Color)
            m_OperatorColor = value
        End Set
    End Property
    <Category("Syntax Highlighting")> _
    Public Property CommentsColor() As Color
        Get
            Return m_CommentsColor
        End Get
        Set(ByVal value As Color)
            m_CommentsColor = value
        End Set
    End Property
    <Category("Syntax Highlighting")> _
    <Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property Keywords() As List(Of String)
        Get
            Return m_Keywords
        End Get
        Set(ByVal value As List(Of String))
            m_Keywords = value
        End Set
    End Property
    <Category("Syntax Highlighting")> _
    <Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property Operators() As List(Of String)
        Get
            Return m_Operators
        End Get
        Set(ByVal value As List(Of String))
            m_Operators = value
        End Set
    End Property
    <Category("Syntax Highlighting")> _
    Public Property HighlightComments() As Boolean
        Get
            Return Me.m_HighlightComments
        End Get
        Set(ByVal value As Boolean)
            Me.m_HighlightComments = value
        End Set
    End Property
    <Category("Syntax Highlighting")> _
    Public Property HighlightVariables() As Boolean
        Get
            Return Me.m_HighlightVariables
        End Get
        Set(ByVal value As Boolean)
            Me.m_HighlightVariables = value
        End Set
    End Property

    Public Sub New()
        Me.m_Keywords = New List(Of String)
        Me.m_Operators = New List(Of String)
    End Sub

    Private Sub ParseLists()
        m_KeywordStrings = New StringBuilder
        m_OperatorStrings = New StringBuilder

        If m_Operators IsNot Nothing Then
            For index As Integer = 0 To m_Operators.Count - 1
                If index = m_Operators.Count - 1 Then
                    m_OperatorStrings.Append(String.Format("\b{0}\b", m_Operators(index)))
                Else
                    m_OperatorStrings.Append(String.Format("\b{0}\b|", m_Operators(index)))
                End If
            Next
        End If
        If m_Keywords IsNot Nothing Then
            For index As Integer = 0 To m_Keywords.Count - 1
                If index = m_Keywords.Count - 1 Then
                    m_KeywordStrings.Append(String.Format("\b{0}\b", m_Keywords(index)))
                Else
                    m_KeywordStrings.Append(String.Format("\b{0}\b|", m_Keywords(index)))
                End If
            Next
        End If
        m_IsParsed = True
    End Sub
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        _Paint = False
        If Not m_IsParsed Then
            Me.ParseLists()
        End If

        If m_IsParsed Then
            Dim keywords As New Regex(m_KeywordStrings.ToString, RegexOptions.IgnoreCase)
            Dim operators As New Regex(m_OperatorStrings.ToString, RegexOptions.IgnoreCase)
            Dim comments As New Regex("--.*$", RegexOptions.IgnoreCase)
            Dim variables As New Regex("'.*$*.'", RegexOptions.IgnoreCase)
            Dim words As New Regex("\w", RegexOptions.IgnoreCase)

            Dim selPos As Integer = Me.SelectionStart
            For Each keywordMatch As Match In words.Matches(Me.Text)
                Me.Select(keywordMatch.Index, keywordMatch.Length)
                Me.SelectionColor = Color.Black
                Me.SelectionStart = selPos
                Me.SelectionColor = Color.Black
            Next

            For Each keywordMatch As Match In keywords.Matches(Me.Text)
                Me.Select(keywordMatch.Index, keywordMatch.Length)
                Me.SelectionColor = m_KeywordColor
                Me.SelectionStart = selPos
                Me.SelectionColor = Color.Black
            Next

            For Each keywordMatch As Match In operators.Matches(Me.Text)
                Me.Select(keywordMatch.Index, keywordMatch.Length)
                Me.SelectionColor = m_OperatorColor
                Me.SelectionStart = selPos
                Me.SelectionColor = Color.Black
            Next

            If m_HighlightComments Then
                For Each keywordMatch As Match In comments.Matches(Me.Text)
                    Me.Select(keywordMatch.Index, keywordMatch.Length)
                    Me.SelectionColor = m_CommentsColor
                    Me.SelectionStart = selPos
                    Me.SelectionColor = Color.Black
                Next
            End If
            If m_HighlightVariables Then
                For Each keywordMatch As Match In variables.Matches(Me.Text)
                    Me.Select(keywordMatch.Index, keywordMatch.Length)
                    Me.SelectionColor = m_VariableColor
                    Me.SelectionStart = selPos
                    Me.SelectionColor = Color.Black
                Next
            End If
            _Paint = True
        End If
    End Sub
    Const WM_PAINT As Short = &HF
    Public Shared _Paint As Boolean = True
    Protected Overloads Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_PAINT Then
            If _Paint Then
                MyBase.WndProc(m)
            End If
        Else
            MyBase.WndProc(m)
        End If
    End Sub
End Class
