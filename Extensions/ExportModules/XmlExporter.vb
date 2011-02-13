Imports SQLCEExplorer.Framework.Interfaces

Namespace Framework.Extentions
    Public Class XmlExporter
        Implements IExportModule
        Private Const m_FileTypes As String = "XML Files|*.xml"
        Private Const m_FileExtention As String = "xml"
        Public ReadOnly Property FileExtention As String Implements IExportModule.FileExtention
            Get
                Return m_FileExtention
            End Get
        End Property

        Public ReadOnly Property FileTypes As String Implements IExportModule.FileTypes
            Get
                Return m_FileTypes
            End Get
        End Property

        Public Sub ShowAbout() Implements IExportModule.ShowAbout
            MessageBox.Show("XML File Exporter." + vbCrLf + "Copyright (c) 2010 SqlCeExplorer Development team.", APPLICATION_NAME)
        End Sub

        Public Function ExportFile(ByVal data As System.Data.DataTable, ByVal fileName As String) As Boolean Implements Interfaces.IExportModule.ExportFile
            Dim result As Boolean = False
            Try
                data.WriteXml(fileName)
                result = True
            Catch ex As Exception
                result = False
            End Try
            Return result
        End Function
    End Class
End Namespace