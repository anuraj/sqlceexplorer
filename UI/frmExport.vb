Imports SQLCEExplorer.Framework
Imports System.Reflection
Imports SQLCEExplorer.Framework.Interfaces
Imports System.Data.SqlServerCe
Imports System.IO

Public Class frmExport
    Inherits Framework.frmBaseUI

    Private m_FileTypes As String
    Private m_IsExtentionsLoaded As Boolean = False
    Private m_ListOfExtns As List(Of IExportModule)
    Private m_Host As PluginHost(Of IExportModule)
    Private Const SELECTQUERYTABLES As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES"
    Private Const SELECTALL As String = "SELECT * FROM {0}"
    Private m_fileName As String = "Table"
    Private Sub LoadTables()
        Me.cmbTables.Items.Clear()
        Dim oSqlCeExplorerData As SqlCeExplorerData
        Dim oTablesReader As SqlCeDataReader
        oSqlCeExplorerData = New SqlCeExplorerData
        oTablesReader = oSqlCeExplorerData.ExecuteQuery(SELECTQUERYTABLES)
        If oTablesReader IsNot Nothing Then
            While oTablesReader.Read
                Me.cmbTables.Items.Add(oTablesReader("TABLE_NAME").ToString)
            End While
            oTablesReader.Close()
        End If
    End Sub
    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Using oFileDialog As New SaveFileDialog
            With oFileDialog
                .Filter = m_FileTypes
                .AutoUpgradeEnabled = False
                .FilterIndex = 0
                .OverwritePrompt = True
                .FileName = m_fileName
                .AddExtension = True
                If cmbFileTypes.SelectedIndex <> -1 Then
                    .FilterIndex = cmbFileTypes.SelectedIndex + 1
                End If
                .ShowHelp = False
                .SupportMultiDottedExtensions = True
                .Title = String.Format("Import - {0}", APPLICATION_NAME)
                If .ShowDialog(Me) = DialogResult.OK Then
                    Me.txtFileName.Text = .FileName
                    m_fileName = .FileName
                End If
            End With
        End Using
    End Sub
    Private Function GetFileFilters() As String
        Dim result As String = String.Empty
        If Not m_IsExtentionsLoaded Then
            Me.LoadtInstalledExtentions()
        End If
        For Each item As IExportModule In m_ListOfExtns
            result += String.Format("{0}|", item.FileTypes)
        Next
        Return IIf(result.EndsWith("|"), result.Remove(result.Length - 1, 1), result)
    End Function
    Private Sub LoadtInstalledExtentions()
        If Not m_IsExtentionsLoaded Then
            Me.m_Host = New PluginHost(Of IExportModule)
            m_ListOfExtns = m_Host.GetPlugins(Assembly.GetExecutingAssembly())
            m_IsExtentionsLoaded = True
        End If
    End Sub

    Private Sub frmExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.m_FileTypes = Me.GetFileFilters
        Me.cmbFileTypes.Items.Clear()
        For Each item As IExportModule In m_ListOfExtns
            Me.cmbFileTypes.Items.Add(item.FileExtention)
            Me.cmbFileTypes.SelectedIndex = 0
        Next
        Me.LoadTables()
    End Sub

    Private Sub cmdShowAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowAbout.Click
        For Each exportModule As IExportModule In m_ListOfExtns
            If exportModule.FileExtention.Equals(Me.cmbFileTypes.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase) Then
                exportModule.ShowAbout()
                Exit For
            End If
        Next
    End Sub

    Private Sub cmbTables_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTables.SelectedIndexChanged
        If Me.cmbTables.SelectedIndex <> -1 Then
            m_fileName = cmbTables.Items(cmbTables.SelectedIndex).ToString()
        End If
    End Sub

    Private Sub CmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOk.Click
        Dim fileExtn As String = Path.GetExtension(m_fileName)
        Dim exportModule As IExportModule =
                m_Host.GetPluginUsingProperty("FileExtention",
                                              IIf(fileExtn.StartsWith("."), fileExtn.Remove(0, 1), fileExtn))
        Dim oSqlCeExplorerData As New SqlCeExplorerData
        Dim table As String = cmbTables.Items(cmbTables.SelectedIndex).ToString()
        exportModule.ExportFile(oSqlCeExplorerData.Fill(oSqlCeExplorerData.ExecuteQuery(String.Format(SELECTALL, table))), m_fileName)
        Me.Close()
    End Sub

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub
End Class