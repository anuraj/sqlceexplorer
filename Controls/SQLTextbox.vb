Imports System.Text
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports System.IO

Public Class SQLTextbox
    Inherits System.Windows.Forms.RichTextBox

    Private m_Keywords As List(Of String)
    Private m_Operators As List(Of String)
    Private m_HighlightComments As Boolean = True
    Private m_HighlightVariables As Boolean = True
    Private m_EnableSyntaxHighlight As Boolean = False

    Private m_KeywordColor As Color = Color.Blue
    Private m_VariableColor As Color = Color.Red
    Private m_OperatorColor As Color = Color.Gray
    Private m_CommentsColor As Color = Color.Green

    Private m_IsParsed As Boolean = False
    Private m_KeywordStrings As StringBuilder
    Private m_OperatorStrings As StringBuilder

    Const WM_PAINT As Short = &HF
    Public Shared m_Paint As Boolean = True

    <Category("Syntax Highlighting")> _
    Public Property EnableSyntaxHighlighting() As Boolean
        Get
            Return m_EnableSyntaxHighlight
        End Get
        Set(ByVal value As Boolean)
            m_EnableSyntaxHighlight = value
        End Set
    End Property

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
        InitializeComponent()

    End Sub
    Private Sub ParseLists()
        If m_EnableSyntaxHighlight Then
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
        End If
    End Sub
    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyUp(e)
        If e.KeyCode = Keys.Space Or e.KeyCode = Keys.Enter Then
            Me.SyntaxHighlight()
        End If
    End Sub

    Private Sub SyntaxHighlight()
        If m_EnableSyntaxHighlight Then
            m_Paint = False
            If Not m_IsParsed Then
                Me.ParseLists()
            End If

            If m_IsParsed Then
                Dim currentPosition As Integer = Me.SelectionStart

                'Applying black color to all the words
                Dim words As MatchCollection = Regex.Matches(Me.Text, "\w", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                For Each word As Match In words
                    Me.SelectionStart = word.Index
                    Me.SelectionLength = word.Length
                    Me.SelectionColor = Color.Black
                    Me.SelectionLength = 0
                    Me.SelectionStart = currentPosition
                    Me.SelectionColor = Color.Black
                Next

                Dim keywords As MatchCollection = Regex.Matches(Me.Text, m_KeywordStrings.ToString, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                For Each keyword As Match In keywords
                    Me.SelectionStart = keyword.Index
                    Me.SelectionLength = keyword.Length
                    Me.SelectionColor = m_KeywordColor
                    Me.SelectionLength = 0
                    Me.SelectionStart = currentPosition
                    Me.SelectionColor = Color.Black
                Next

                Dim operators As MatchCollection = Regex.Matches(Me.Text, m_OperatorStrings.ToString, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                For Each [operator] As Match In operators
                    Me.SelectionStart = [operator].Index
                    Me.SelectionLength = [operator].Length
                    Me.SelectionColor = m_OperatorColor
                    Me.SelectionLength = 0
                    Me.SelectionStart = currentPosition
                    Me.SelectionColor = Color.Black
                Next

                If m_HighlightComments Then
                    Dim comments As MatchCollection = Regex.Matches(Me.Text, "--.*$", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                    For Each comment As Match In comments
                        Me.SelectionStart = comment.Index
                        Me.SelectionLength = comment.Length
                        Me.SelectionColor = m_CommentsColor
                        Me.SelectionLength = 0
                        Me.SelectionStart = currentPosition
                        Me.SelectionColor = Color.Black
                    Next
                End If

                If m_HighlightVariables Then
                    Dim variables As MatchCollection = Regex.Matches(Me.Text, "'.*$*.'", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                    For Each variable As Match In variables
                        Me.SelectionStart = variable.Index
                        Me.SelectionLength = variable.Length
                        Me.SelectionColor = m_VariableColor
                        Me.SelectionLength = 0
                        Me.SelectionStart = currentPosition
                        Me.SelectionColor = Color.Black
                    Next
                End If
                m_Paint = True
            End If
        End If
    End Sub

    Protected Overloads Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_PAINT Then
            If m_Paint Then
                MyBase.WndProc(m)
            End If
        Else
            MyBase.WndProc(m)
        End If
    End Sub
    Public Sub DoSyntaxHighlight()
        Me.SyntaxHighlight()
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'SQLTextbox
        '
        Me.AcceptsTab = True
        Me.ResumeLayout(False)

    End Sub
End Class
