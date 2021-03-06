﻿Public Class VoidStructure
    Public ReadOnly Property VoidName As String
    Public ReadOnly Property VoidParameter As Dictionary(Of String, Type)
    Public ReadOnly Property VoidMainCode As String
    Public Sub New(voidnamies As String, voidparam As String, voidcodes As String)
        VoidParameter = GetParam(voidparam)
        VoidName = ApiFunction.GetNameStr(voidnamies)
        VoidMainCode = ApiFunction.GetCodeStrNoLRNoEmpty(voidcodes)
    End Sub

    Private Function GetParam(paramStr As String) As Dictionary(Of String, Type)
        Dim dics_nio As New Dictionary(Of String, Type)

        Dim paramStrprovider As String = ApiFunction.GetParamStr(paramStr)

        Dim paramList As String() = paramStrprovider.Split(",", StringSplitOptions.RemoveEmptyEntries)
        For Each everyparamcode As String In paramList
            Dim dicKits As String() = everyparamcode.Split(":", StringSplitOptions.RemoveEmptyEntries)
            dics_nio.Add(dicKits(1).Trim, ApiFunction.GetTypeByString(dicKits(0)))
        Next

        Return dics_nio
    End Function

End Class
