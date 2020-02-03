Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions

Public Module StringExtensions
    ''' <summary>
    ''' Given a string with upper and lower cased letters separate them before each upper cased characters
    ''' </summary>
    ''' <param name="sender">String to work against</param>
    ''' <returns>String with spaces between upper-case letters</returns>
    <Extension>
    Public Function SplitCamelCase(ByVal sender As String) As String
        Return Regex.Replace(Regex.Replace(sender, "(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), "(\p{Ll})(\P{Ll})", "$1 $2")
    End Function
End Module
