Imports System.Data.SqlServerCe
Imports System.IO

Public Class frmEditTable
    Inherits Framework.frmBaseUI
    Private m_TableName As String
    Private m_CurrentAdapter As SqlCeDataAdapter
    Private m_DataTable As DataTable
    Public Sub New(ByVal tableName As String)
        InitializeComponent()
        Me.m_TableName = tableName
    End Sub

    Private Sub frmEditTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = String.Format("SELECT * FROM {0}", m_TableName)
        Me.m_CurrentAdapter = New SqlCeDataAdapter(query, SqlCeMain.GetConnectionString())
        Dim commandBuilder As New SqlCeCommandBuilder(Me.m_CurrentAdapter)
        Me.m_DataTable = New DataTable

        m_CurrentAdapter.Fill(m_DataTable)
        Dim bsource As New BindingSource
        bsource.DataSource = m_DataTable
        Me.dgvEditRows.DataSource = bsource
        Me.dgvEditRows.Width = Me.Width
        Me.dgvEditRows.AutoResizeColumns()

        For Each Item As DataGridViewColumn In Me.dgvEditRows.Columns
            Item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If m_CurrentAdapter IsNot Nothing Then
            m_CurrentAdapter.AcceptChangesDuringUpdate = True
            Try
                m_CurrentAdapter.Update(m_DataTable)
            Catch ex As SqlCeException
                SqlCeExplorerUtility.ShowMessage(String.Format("An exception occured. Update failed.{0}{1}", Environment.NewLine, ex.Message), Nothing)
            End Try
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub dgvEditRows_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEditRows.CellClick
        Dim cell As DataGridViewCell = Me.dgvEditRows.Rows(e.RowIndex).Cells(e.ColumnIndex)

        If TypeOf (cell) Is DataGridViewImageCell Then
            Using oFileDlg As New OpenFileDialog
                With oFileDlg
                    .CheckFileExists = True
                    .Filter = "Supported Images|*.bmp;*.jpg;*.gif;*.png"
                    .Multiselect = False
                    .ReadOnlyChecked = False
                    .ShowHelp = False
                    .ShowReadOnly = False
                    .SupportMultiDottedExtensions = True
                    .ValidateNames = True
                    .Title = String.Format("Insert Picture - {0}", APPLICATION_NAME)
                    If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Dim img As Bitmap = Image.FromFile(.FileName)
                        cell.Value = img
                    End If
                End With
            End Using
        End If
    End Sub

    Private Sub dgvEditRows_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        If e.Exception IsNot Nothing Then
            SqlCeExplorerUtility.ShowMessage(String.Format("Data Error occured.{0}{1}", Environment.NewLine, e.Exception.Message), Nothing)
        End If
    End Sub
End Class