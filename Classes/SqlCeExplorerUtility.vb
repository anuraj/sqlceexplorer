Imports Microsoft.Win32

Public Class SqlCeExplorerUtility
    Public Shared Sub ShowMessage(ByVal Message As String, ByVal Control As Control)
        MessageBox.Show(Message, SqlCeMain.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        If Control IsNot Nothing AndAlso Control.CanFocus Then
            Control.Focus()
        End If
    End Sub
    Public Shared Sub AddItem(ByVal item As String)
        Dim index As Integer = 1
        Dim rootKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software")
        Dim AppNameKey As RegistryKey = rootKey.CreateSubKey(SqlCeMain.APPLICATION_NAME)
        Dim settingsKey As RegistryKey = AppNameKey.CreateSubKey("RecentFiles")

        For Each Item1 As String In settingsKey.GetValueNames
            If settingsKey.GetValue(Item1).ToString.Equals(item, StringComparison.CurrentCultureIgnoreCase) Then
                settingsKey.SetValue(index, item)
                Return
            End If
            index += 1
        Next
        settingsKey.SetValue(index, item)
        settingsKey.Close()
        AppNameKey.Close()
        rootKey.Close()
    End Sub
    Public Shared Function GetRecentItems() As List(Of String)
        Dim rootKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software")
        Dim AppNameKey As RegistryKey = rootKey.CreateSubKey(SqlCeMain.APPLICATION_NAME)
        Dim settingsKey As RegistryKey = AppNameKey.CreateSubKey("RecentFiles")
        Dim result As New List(Of String)
        For Each Item1 As String In settingsKey.GetValueNames
            result.Add(settingsKey.GetValue(Item1))
        Next
        settingsKey.Close()
        AppNameKey.Close()
        rootKey.Close()
        Return result
    End Function
    Public Shared Sub ClearRecentItems(ByVal item As String)
        Dim rootKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software")
        Dim AppNameKey As RegistryKey = rootKey.CreateSubKey(SqlCeMain.APPLICATION_NAME)
        Dim settingsKey As RegistryKey = AppNameKey.CreateSubKey("RecentFiles")
        If item.Length >= 1 Then
            For Each Item1 As String In settingsKey.GetValueNames
                If item.Equals(settingsKey.GetValue(Item1).ToString(), StringComparison.CurrentCultureIgnoreCase) Then
                    settingsKey.DeleteValue(Item1)
                    Exit For
                End If
            Next
        Else
            For Each Item1 As String In settingsKey.GetValueNames
                settingsKey.DeleteValue(Item1)
            Next
        End If
    End Sub
End Class
