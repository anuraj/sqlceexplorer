Imports System.Reflection

Namespace Framework
    Public Class PluginHost(Of T)
        Private m_Plugins As List(Of T)
        Public Sub New()
            m_Plugins = New List(Of T)
        End Sub
        Public Function GetPlugins(ByVal Path As String) As List(Of T)
            Throw New NotImplementedException()
        End Function
        Public Function GetPlugins(ByVal assembly As Assembly) As List(Of T)
            Dim types() As Type = assembly.GetTypes()
            For Each plugin As Type In types
                Console.WriteLine(plugin.FullName)
                If GetType(T).IsAssignableFrom(plugin) AndAlso
                    plugin.IsClass AndAlso Not plugin.IsAbstract Then
                    m_Plugins.Add(CType(Activator.CreateInstance(plugin), T))
                End If
            Next
            Return m_Plugins
        End Function
        Public Function GetPluginUsingProperty(ByVal propertyName As String, ByVal propertyValue As Object) As T
            For Each o As T In Me.m_Plugins
                Dim properties() As PropertyInfo = o.GetType().GetProperties()
                For Each item As PropertyInfo In properties
                    If item.CanRead AndAlso item.GetValue(o, Nothing).ToString().
                        Equals(propertyValue.ToString(), StringComparison.CurrentCultureIgnoreCase) Then
                        Return o
                    End If
                Next
            Next
        End Function
    End Class
End Namespace