Imports System.Text

Public Class frmCreateTable
    Public Event CreateTableQueryFormed(ByVal sender As Object, ByVal e As EventArgs)
    Private m_DataLengths As Dictionary(Of String, String)
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If dgvCreateTable.SelectedRows IsNot Nothing AndAlso _
            dgvCreateTable.SelectedRows.Count >= 1 AndAlso _
            Not dgvCreateTable.SelectedRows(0).IsNewRow Then
            dgvCreateTable.Rows.Remove(dgvCreateTable.SelectedRows(0))
        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Not txtTableName.Text.Equals(String.Empty) Then
            CreateQuery()
            RaiseEvent CreateTableQueryFormed(Me, e)
            Me.Close()
        Else
            SqlCeExplorerUtility.ShowMessage("Table name cannot be empty", Me.txtTableName)
        End If
    End Sub

    Private Sub CreateQuery()
        Dim allowNull As String
        Dim uniqueKey As String
        Dim primaryKey As String
        Dim query As New StringBuilder
        query.AppendFormat("CREATE TABLE [{0}] {1}({1}", Me.txtTableName.Text, Environment.NewLine)

        For Each row As DataGridViewRow In dgvCreateTable.Rows

            allowNull = String.Empty
            uniqueKey = String.Empty
            primaryKey = String.Empty

            If row.Cells(0).Value IsNot Nothing _
                AndAlso Not row.Cells(0).Value.Equals(String.Empty) Then

                'Primary Key
                If row.Cells(5).Value IsNot Nothing AndAlso row.Cells(5).Value.ToString.Equals("Yes", StringComparison.InvariantCultureIgnoreCase) Then
                    primaryKey = "PRIMARY KEY"
                End If

                'Unique
                If row.Cells(4).Value IsNot Nothing AndAlso row.Cells(4).Value.ToString.Equals("Yes", StringComparison.InvariantCultureIgnoreCase) Then
                    uniqueKey = "UNIQUE"
                End If

                If row.Cells(3).Value IsNot Nothing AndAlso row.Cells(3).Value.ToString.Equals("No", StringComparison.InvariantCultureIgnoreCase) Then
                    allowNull = "NOT NULL"
                Else
                    allowNull = "NULL"
                End If
                'If Primary key is TRUE, the column can't be NULLABLE.
                If primaryKey.Length >= 1 Then
                    allowNull = "NOT NULL"
                End If

                'query.AppendFormat("[{0}] {1}({2}) {5} {3} {4} ", row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, uniqueKey, primaryKey, allowNull)
                query.AppendFormat("[{0}] {1} {4} {2} {3}", row.Cells(0).Value, GetDataLength(row.Cells(1).Value, row.Cells(2).Value), uniqueKey, primaryKey, allowNull)
                query.Append(",")
            Else
                Dim lastPos As Integer = query.ToString.LastIndexOf(",")
                If lastPos <> -1 Then
                    query.Remove(lastPos, 1)
                End If
            End If
        Next
        query.AppendFormat("){0}", Environment.NewLine)
        SqlCeMain.CurrentQuery(query.ToString)
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

    Private Sub dgvCreateTable_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCreateTable.CellEnter
        Select Case e.ColumnIndex
            Case 1
                Dim combo As DataGridViewComboBoxCell = TryCast(dgvCreateTable.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell)
                If combo IsNot Nothing Then
                    combo.Value = "nchar"
                End If
            Case 2
                Dim txtBox As DataGridViewTextBoxCell = TryCast(dgvCreateTable.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewTextBoxCell)
                Dim combo As DataGridViewComboBoxCell = TryCast(dgvCreateTable.Rows(e.RowIndex).Cells(e.ColumnIndex - 1), DataGridViewComboBoxCell)
                If combo IsNot Nothing AndAlso txtBox IsNot Nothing Then
                    If m_DataLengths.ContainsKey(combo.Value.ToString()) Then
                        txtBox.Value = m_DataLengths.Item(combo.Value.ToString())
                    End If
                End If
            Case 3
                Dim combo As DataGridViewComboBoxCell = TryCast(dgvCreateTable.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell)
                If combo IsNot Nothing Then
                    combo.Value = "Yes"
                End If
            Case 4, 5
                Dim combo As DataGridViewComboBoxCell = TryCast(dgvCreateTable.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell)
                If combo IsNot Nothing Then
                    combo.Value = "No"
                End If
        End Select
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Private Sub frmCreateTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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