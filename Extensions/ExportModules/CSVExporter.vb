Imports SQLCEExplorer.Framework.Interfaces
Imports System.Text
Imports System.IO

Namespace Framework.Extentions
    Public Class CSVExporter
        Implements IExportModule
        Private Const m_FileTypes As String = "CSV Files|*.csv"
        Private Const m_FileExtention As String = "csv"
        Public Function ExportFile(ByVal data As System.Data.DataTable, ByVal fileName As String) As Boolean Implements Interfaces.IExportModule.ExportFile
            Dim csvFile As New StringBuilder
            For Each row As DataRow In data.Rows
                For Each col As DataColumn In data.Columns
                    csvFile.AppendFormat("{0}|", row(col).ToString().Trim())
                Next
                csvFile.AppendLine()
            Next
            Using sw As StreamWriter = File.CreateText(fileName)
                sw.WriteLine(csvFile.ToString())
            End Using
        End Function

        Public ReadOnly Property FileExtention As String Implements Interfaces.IExportModule.FileExtention
            Get
                Return m_FileExtention
            End Get
        End Property

        Public ReadOnly Property FileTypes As String Implements Interfaces.IExportModule.FileTypes
            Get
                Return m_FileTypes
            End Get
        End Property

        Public Sub ShowAbout() Implements Interfaces.IExportModule.ShowAbout
            MessageBox.Show("CSV File Exporter." + vbCrLf + "Copyright (c) 2010 SqlCeExplorer Development team.", APPLICATION_NAME)
        End Sub
    End Class
End Namespace