Public Class ApiFunction
    Public Shared Function GetTypeByString(types As String) As Type
        Select Case types.ToLower()
            Case "bool"
                Return Type.[GetType]("System.Boolean", True, True)
            Case "byte"
                Return Type.[GetType]("System.Byte", True, True)
            Case "sbyte"
                Return Type.[GetType]("System.SByte", True, True)
            Case "char"
                Return Type.[GetType]("System.Char", True, True)
            Case "decimal"
                Return Type.[GetType]("System.Decimal", True, True)
            Case "double"
                Return Type.[GetType]("System.Double", True, True)
            Case "float"
                Return Type.[GetType]("System.Single", True, True)
            Case "int"
                Return Type.[GetType]("System.Int32", True, True)
            Case "uint"
                Return Type.[GetType]("System.UInt32", True, True)
            Case "long"
                Return Type.[GetType]("System.Int64", True, True)
            Case "ulong"
                Return Type.[GetType]("System.UInt64", True, True)
            Case "object"
                Return Type.[GetType]("System.Object", True, True)
            Case "short"
                Return Type.[GetType]("System.Int16", True, True)
            Case "ushort"
                Return Type.[GetType]("System.UInt16", True, True)
            Case "string"
                Return Type.[GetType]("System.String", True, True)
            Case "date", "datetime"
                Return Type.[GetType]("System.DateTime", True, True)
            Case "guid"
                Return Type.[GetType]("System.Guid", True, True)
            Case Else
                Return Type.[GetType](types, True, True)
        End Select
    End Function
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

    Public Shared Function GetFunctionReturnType(oldstring As String) As Type
        Dim oldStr As String = Regex.Replace(oldstring, "(.*\()(.*)(\).*)", "$2", RegexOptions.IgnoreCase)
        Return Type.GetType(oldStr.Split(",", StringSplitOptions.RemoveEmptyEntries)(1).Trim)
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
