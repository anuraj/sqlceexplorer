Imports SQLCEExplorer.Framework.Interfaces
Imports System.IO

Namespace Framework.Extentions
    Public Class CSVImporter
        Implements IImportModule
        Private ReadOnly m_fileTypes As String = "CSV Files|*.csv"
        Private ReadOnly m_fileExtn As String = "CSV"
        Private ReadOnly m_Delimiters() As Char = New Char() {"|", ",", ";"}
        Public ReadOnly Property FileTypes As String Implements IImportModule.FileTypes
            Get
                Return m_fileTypes
            End Get
        End Property

        Public Function ImportFile(ByVal filename As String) As DataTable Implements IImportModule.ImportFile
            Dim result As New DataTable(filename)
            Using oStreamReader As New StreamReader(filename)
                Dim line As String = oStreamReader.ReadLine()
                Dim columns() As String = Me.SplitLine(line)
                Me.CreateColumns(columns, result)
                Dim data() As String
                If result.Columns IsNot Nothing AndAlso result.Columns.Count >= 1 Then
                    While Not oStreamReader.EndOfStream
                        line = oStreamReader.ReadLine()
                        data = Me.SplitLine(line)
                        Dim dr As DataRow = result.NewRow
                        For index = 0 To columns.Length - 1
                            dr(index) = data(index)
                        Next
                        result.Rows.Add(dr)
                    End While
                End If
            End Using
            Return result
        End Function

        Private Function SplitLine(ByVal line As String) As String()
            Return line.Split(m_Delimiters, StringSplitOptions.RemoveEmptyEntries)
        End Function

        Private Sub CreateColumns(ByVal columns() As String, ByVal oDataTable As DataTable)
            For Each column As String In columns
                oDataTable.Columns.Add(column)
            Next
        End Sub

        Public ReadOnly Property FileExtention As String Implements Framework.Interfaces.IImportModule.FileExtention
            Get
                Return m_fileExtn
            End Get
        End Property

        Public Sub ShowAbout() Implements Framework.Interfaces.IImportModule.ShowAbout
            MessageBox.Show("CSV File Importer." + vbCrLf + "Copyright (c) 2010 SqlCeExplorer Development team.", APPLICATION_NAME)
        End Sub
    End Class
End Namespace