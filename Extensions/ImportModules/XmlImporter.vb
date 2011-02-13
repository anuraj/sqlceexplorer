Imports SQLCEExplorer.Framework.Interfaces
Imports System.Xml

Namespace Framework.Extentions
    Public Class XmlImporter
        Implements IImportModule
        Private ReadOnly m_fileTypes As String = "XML Files|*.xml"
        Private ReadOnly m_fileExtn As String = "XML"
        Public ReadOnly Property FileTypes As String Implements IImportModule.FileTypes
            Get
                Return m_fileTypes
            End Get
        End Property

        Public Function ImportFile(ByVal filename As String) As System.Data.DataTable Implements IImportModule.ImportFile
            Dim dts As New DataSet
            dts.ReadXml(filename)
            For Each dtable As DataTable In dts.Tables
                If dtable.Rows IsNot Nothing AndAlso dtable.Rows.Count >= 1 Then
                    Return dtable
                End If
            Next
            Return Nothing
        End Function
        Public ReadOnly Property FileExtention As String Implements Framework.Interfaces.IImportModule.FileExtention
            Get
                Return m_fileExtn
            End Get
        End Property
        Public Sub ShowAbout() Implements Framework.Interfaces.IImportModule.ShowAbout
            MessageBox.Show("XML File Importer." + vbCrLf + "Copyright (c) 2010 SqlCeExplorer Development team.", APPLICATION_NAME)
        End Sub
    End Class
End Namespace