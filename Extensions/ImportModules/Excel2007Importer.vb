Imports SQLCEExplorer.Framework.Interfaces
Imports System.Data.OleDb
Imports System.IO

Public Class Excel2007Importer
    Implements IImportModule
    Private ReadOnly m_fileTypes As String = "Excel 2007 Files|*.xlsx"
    Private ReadOnly m_fileExtn As String = "XLSX"
    Private ReadOnly m_ConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0"
    Public ReadOnly Property FileTypes As String Implements IImportModule.FileTypes
        Get
            Return m_fileTypes
        End Get
    End Property

    Public Function ImportFile(ByVal filename As String) As DataTable Implements IImportModule.ImportFile
        Dim result As New DataTable(Path.GetFileNameWithoutExtension(filename))
        Using oOleDbConnection As New OleDbConnection(String.Format(m_ConnectionString, filename))
            oOleDbConnection.Open()
            Dim dbSchema As DataTable = oOleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables_Info, Nothing)
            Dim importTable As String = dbSchema.Rows(0)("TABLE_NAME").ToString
            Dim dbColumns As DataTable = oOleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, Nothing)
            Dim rows() As DataRow = dbColumns.Select(String.Format("TABLE_NAME='{0}'", importTable))

            For Each row As DataRow In rows
                result.Columns.Add(row(0).ToString())
            Next

            Dim dr As DataRow

            Using oOleDbCommand As New OleDbCommand(String.Format("SELECT * FROM [{0}]", importTable), oOleDbConnection)
                Using oOleDbDataReader As OleDbDataReader = oOleDbCommand.ExecuteReader(CommandBehavior.CloseConnection)

                    While oOleDbDataReader.Read()
                        dr = result.NewRow
                        For index = 0 To oOleDbDataReader.FieldCount - 1
                            dr(index) = oOleDbDataReader(index).ToString
                        Next
                        result.Rows.Add(dr)
                    End While
                End Using
            End Using
        End Using
        Return result
    End Function
    Public ReadOnly Property FileExtention As String Implements Framework.Interfaces.IImportModule.FileExtention
        Get
            Return m_fileExtn
        End Get
    End Property
    Public Sub ShowAbout() Implements Framework.Interfaces.IImportModule.ShowAbout
        MessageBox.Show("MS Excel 2007 File Importer." + vbCrLf + "Copyright (c) 2010 SqlCeExplorer Development team.", APPLICATION_NAME)
    End Sub
End Class
