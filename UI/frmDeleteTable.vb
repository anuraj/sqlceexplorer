Imports System.Data.SqlServerCe

Public Class frmDeleteTable
    Private Const SELECTQUERYTABLES As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES"
    Private m_Tablename As String = String.Empty
    Public Event DeleteTableQueryFormed(ByVal sender As Object, ByVal e As EventArgs)
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal Tablename As String)
        InitializeComponent()
        m_Tablename = Tablename
    End Sub
    Private Sub frmDeleteTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadTables()
        If m_Tablename.Length >= 1 Then
            For index As Integer = 0 To Me.cmbTables.Items.Count - 1
                If Me.cmbTables.Items(index).ToString.Equals(m_Tablename, StringComparison.CurrentCultureIgnoreCase) Then
                    Me.cmbTables.SelectedIndex = index
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub LoadTables()
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

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If m_Tablename.Length <= 0 AndAlso Me.cmbTables.SelectedIndex = -1 Then
            SqlCeExplorerUtility.ShowMessage("Please select a Table", Me.cmbTables)
            Return
        End If
        m_Tablename = cmbTables.SelectedItem.ToString
        If MessageBox.Show(String.Format("This will permanently delete the ""{0}"" table from the database.{1}Are you sure want to continue?", m_Tablename, Environment.NewLine), SqlCeMain.APPLICATION_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            SqlCeMain.CurrentQuery(String.Format("DROP TABLE [{0}]", m_Tablename))
            RaiseEvent DeleteTableQueryFormed(Me, e)
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class