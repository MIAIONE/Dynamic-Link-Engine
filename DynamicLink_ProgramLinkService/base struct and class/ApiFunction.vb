Public Class ApiFunction
    Public Shared Function GetOriginalCode(ByVal input As String) As String
        input = Regex.Replace(input, "/\*[\s\S]*?\*/", "", RegexOptions.IgnoreCase)
        input = Regex.Replace(input, "^\s*//[\s\S]*?$", "", RegexOptions.Multiline)
        input = Regex.Replace(input, "^\s*$\n", "", RegexOptions.Multiline)
        input = Regex.Replace(input, "^\s*//[\s\S]*", "", RegexOptions.Multiline)
        Return input
    End Function

    Public Shared Function GetParamStr(oldstring As String) As String
        Return Regex.Replace(oldstring, "(.*\()(.*)(\).*)", "$2", RegexOptions.IgnoreCase)
    End Function

    Public Shared Function GetCodeStr(oldstring As String) As String
        Return GetStrCenter(oldstring, "\{", "\}").Trim
    End Function

    Public Shared Function GetNameStr(oldstring As String) As String
        Dim oldStr As String = Regex.Replace(oldstring, "(.*\()(.*)(\).*)", "$2", RegexOptions.IgnoreCase)
        Return oldStr.Split(",", StringSplitOptions.RemoveEmptyEntries)(0).Trim
    End Function

    Public Shared Function GetFunctionReturnType(oldstring As String) As String
        Dim oldStr As String = Regex.Replace(oldstring, "(.*\()(.*)(\).*)", "$2", RegexOptions.IgnoreCase)
        Return oldStr.Split(",", StringSplitOptions.RemoveEmptyEntries)(1).Trim
    End Function

    Public Shared Function GetStrCenter(sourse As String, startstr As String, endstr As String) As String
        Dim rg As Regex = New Regex(String.Format("(?<=({0}))[.\s\S]*?(?=({1}))", startstr, endstr), RegexOptions.Multiline Or RegexOptions.Singleline)
        Return rg.Match(sourse).Value
    End Function

    Public Shared Function GetNoLR(oldstring As String) As String
        Return Regex.Replace(oldstring, "\r|\n|\\s", "", RegexOptions.Multiline Or RegexOptions.Singleline)
    End Function

    Public Shared Function GetCodeStrNoLRNoEmpty(oldstring As String) As String
        Return GetNoLR(GetNoEmpty(GetCodeStr(oldstring)))
    End Function

    Public Shared Function GetNoEmpty(oldstring As String) As String
        Dim newprovider As String = oldstring.Trim
        Dim trees As String() = newprovider.Split(vbCrLf, StringSplitOptions.RemoveEmptyEntries)
        Dim new_trees As New ArrayList
        For Each everyLines As String In trees
            new_trees.Add(everyLines.Trim)
        Next
        Return String.Join(vbCrLf, new_trees.ToArray)
    End Function

End Class
