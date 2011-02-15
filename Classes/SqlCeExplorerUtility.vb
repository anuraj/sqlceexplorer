Imports System.Xml
Imports System.IO

Public Class SqlCeExplorerUtility
    Private Const m_FileName As String = "SqlExplorer_Recent_Files.inf"
    Private Shared m_items As Hashtable
    Private Shared m_IsLoaded As Boolean = False
    Public Shared Property Items As Hashtable
        Get
            Dim i As Integer = 1
            Dim listItems As List(Of String) = GetRecentItems()
            Dim result As New Hashtable
            If listItems IsNot Nothing Then
                For Each item As String In listItems
                    If item.Trim().Length >= 1 Then
                        result.Add(i, item)
                        i += 1
                    End If
                Next
            End If
            Return result
        End Get
        Set(ByVal value As Hashtable)
            m_items = value
        End Set
    End Property


    Public Shared Sub ShowMessage(ByVal Message As String, ByVal Control As Control)
        MessageBox.Show(Message, SqlCeMain.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        If Control IsNot Nothing AndAlso Control.CanFocus Then
            Control.Focus()
        End If
    End Sub
    Public Shared Sub AddOrDeleteItem(ByVal item As String, Optional ByVal isDelete As Boolean = False)
        Dim settingsFile As String = GetRecentFileName()
        Dim listItems As List(Of String) = GetRecentItems()
        If listItems Is Nothing Then
            If Not File.Exists(settingsFile) Then
                Using sw As StreamWriter = File.CreateText(settingsFile)
                    'Do nothing.
                End Using
            End If
            listItems = New List(Of String)()
        End If
        If item.Trim().Length >= 1 AndAlso Not listItems.Contains(item) Then
            listItems.Add(item)
        End If
        If isDelete Then
            listItems.Remove(item)
        End If
        Using sw As New StreamWriter(settingsFile, False)
            For Each listItem As String In listItems
                sw.WriteLine(listItem)
            Next
        End Using
    End Sub

    Private Shared Function GetRecentFileName()
        Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), m_FileName)
    End Function

    Public Shared Function GetRecentItems() As List(Of String)
        Dim settingsFile As String = GetRecentFileName()

        If Not File.Exists(settingsFile) Then
            Return Nothing
        End If
        Dim content As String
        Using sr As New StreamReader(settingsFile)
            content = sr.ReadToEnd()
        End Using
        Return New List(Of String)(content.Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries))
    End Function
    Public Shared Sub ClearRecentItems(ByVal item As String)
        AddOrDeleteItem(item, True)
    End Sub
End Class
