Imports System.Data.SqlServerCe

Public Class frmModifyColumn
    Public Enum OperationMode
        CreateColumn = 1
        DropColumn = 2
        AlterColumn = 3
    End Enum
    Private Const SELECTQUERYCOLUMNS As String = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = '{0}')"

    Private Const DROPQUERY As String = "ALTER TABLE {0} DROP COLUMN [{1}]"
    Private Const CHANGECOLUMN As String = "ALTER TABLE {0} ALTER COLUMN [{1}] {2}"
    Private Const ADDCOLUMN As String = "ALTER TABLE {0} ADD COLUMN [{1}] {2}"

    Private m_ChangeMode As OperationMode
    Private m_DataLengths As Dictionary(Of String, String)
    Private m_TableName As String

    Public Event AlterColumnQueryFormed(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub FillColumns(ByVal table As String)
        Dim result As New List(Of String)
        Dim oTablesReader As SqlCeDataReader
        Dim query As String = String.Format(SELECTQUERYCOLUMNS, table)
        Dim oSqlCeExplorerData As New SqlCeExplorerData
        oTablesReader = oSqlCeExplorerData.ExecuteQuery(query)

        While oTablesReader.Read
            Me.cmbColumnNames.Items.Add(oTablesReader("COLUMN_NAME").ToString())
        End While
        oTablesReader.Close()
        oTablesReader = Nothing
        oSqlCeExplorerData = Nothing
    End Sub

    Public Sub New(ByVal modeOfChange As OperationMode, ByVal tableName As String)
        InitializeComponent()
        Me.m_TableName = tableName
        Me.m_ChangeMode = modeOfChange
        Select Case modeOfChange
            Case OperationMode.AlterColumn
                Me.cmbColumnNames.DropDownStyle = ComboBoxStyle.DropDownList
                Me.chkDropThisColumn.Enabled = False
                Me.chkChangeDataType.Checked = True
                Me.Text = "Change a Column data type"
                Me.FillColumns(tableName)
            Case OperationMode.CreateColumn
                Me.cmbColumnNames.DropDownStyle = ComboBoxStyle.Simple
                Me.chkDropThisColumn.Enabled = False
                Me.chkChangeDataType.Enabled = False
                Me.plDataTypeChange.Enabled = True
                Me.Text = "Add New Column"
            Case OperationMode.DropColumn
                Me.cmbColumnNames.DropDownStyle = ComboBoxStyle.DropDownList
                Me.chkDropThisColumn.Checked = True
                Me.chkChangeDataType.Enabled = False
                Me.Text = "Drop a Column"
                Me.FillColumns(tableName)
        End Select
    End Sub

    Private Sub chkChangeDataType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChangeDataType.CheckedChanged
        Me.plDataTypeChange.Enabled = chkChangeDataType.Checked
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Function GetDataLength(ByVal dataType As String, ByVal length As String) As String
        Dim result As String = ""

        Select Case dataType
            Case "bigint", "bit", "datetime", "float", "image", "int", "money", "numeric", "real", "smallint", "uniqueidentifier", "tinyint"
                result = String.Format(" {0}", dataType)
            Case Else
                result = String.Format(" {0}({1})", dataType, length)
        End Select
        Return result
    End Function
    Private Function ValidateControls() As Boolean
        Dim result As Boolean = False

        Select Case Me.m_ChangeMode
            Case OperationMode.AlterColumn
                If Me.chkChangeDataType.Checked Then
                    If cmbDataType.SelectedIndex = -1 Then
                        SqlCeExplorerUtility.ShowMessage("Please select a datatype", Me.cmbDataType)
                        Return False
                    ElseIf Me.txtDataTypeLength.Text.Length <= 0 OrElse Not IsNumeric(Me.txtDataTypeLength.Text) Then
                        SqlCeExplorerUtility.ShowMessage("Please enter a valid length", Me.txtDataTypeLength)
                        Return False
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If
            Case OperationMode.CreateColumn
                If Me.cmbColumnNames.Text.Length <= 0 Then
                    SqlCeExplorerUtility.ShowMessage("Please enter a column name", Me.cmbColumnNames)
                    Return False
                ElseIf cmbDataType.SelectedIndex = -1 Then
                    SqlCeExplorerUtility.ShowMessage("Please select a datatype", Me.cmbDataType)
                    Return False
                ElseIf Me.txtDataTypeLength.Text.Length <= 0 OrElse Not IsNumeric(Me.txtDataTypeLength.Text) Then
                    SqlCeExplorerUtility.ShowMessage("Please enter a valid length", Me.txtDataTypeLength)
                    Return False
                Else
                    Return True
                End If
            Case OperationMode.DropColumn
                If Me.chkDropThisColumn.Checked Then
                    If cmbColumnNames.SelectedIndex = -1 Then
                        SqlCeExplorerUtility.ShowMessage("Please select a column", Me.cmbDataType)
                        Return False
                    Else
                        Return True
                    End If
                End If
        End Select
    End Function

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim query As String = String.Empty
        If ValidateControls() Then
            Select Case Me.m_ChangeMode
                Case OperationMode.AlterColumn
                    query = String.Format(CHANGECOLUMN, m_TableName, Me.cmbColumnNames.SelectedItem.ToString(), Me.GetDataLength(Me.cmbDataType.SelectedItem.ToString(), Me.txtDataTypeLength.Text))
                Case OperationMode.CreateColumn
                    query = String.Format(ADDCOLUMN, m_TableName, Me.cmbColumnNames.Text, Me.GetDataLength(Me.cmbDataType.SelectedItem.ToString(), Me.txtDataTypeLength.Text))
                Case OperationMode.DropColumn
                    query = String.Format(DROPQUERY, m_TableName, Me.cmbColumnNames.SelectedItem.ToString())
            End Select
            SqlCeMain.CurrentQuery(query)
            RaiseEvent AlterColumnQueryFormed(Me, e)
            Me.Close()
        End If
    End Sub

    Private Sub cmbDataType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDataType.SelectedIndexChanged
        If Me.cmbDataType.SelectedIndex <> -1 Then
            If Me.m_DataLengths.ContainsKey(Me.cmbDataType.SelectedItem.ToString()) Then
                Me.txtDataTypeLength.Text = Me.m_DataLengths(Me.cmbDataType.SelectedItem.ToString())
            End If
        End If
    End Sub

    Private Sub frmModifyColumn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.m_DataLengths = New Dictionary(Of String, String)
        Me.m_DataLengths.Add("bigint", "8")
        Me.m_DataLengths.Add("binary", "100")
        Me.m_DataLengths.Add("bit", "1")
        Me.m_DataLengths.Add("datetime", "8")
        Me.m_DataLengths.Add("float", "8")
        Me.m_DataLengths.Add("image", "16")
        Me.m_DataLengths.Add("int", "4")
        Me.m_DataLengths.Add("money", "19")
        Me.m_DataLengths.Add("nchar", "100")
        Me.m_DataLengths.Add("nvarchar", "16")
        Me.m_DataLengths.Add("ntext", "5")
        Me.m_DataLengths.Add("numeric", "100")
        Me.m_DataLengths.Add("real", "4")
        Me.m_DataLengths.Add("smallint", "2")
        Me.m_DataLengths.Add("uniqueidentifier", "16")
        Me.m_DataLengths.Add("tinyint", "1")
        Me.m_DataLengths.Add("varbinary", "100")
    End Sub
End Class