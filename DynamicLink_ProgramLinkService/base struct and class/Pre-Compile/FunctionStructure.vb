Public Class FunctionStructure
    Public ReadOnly Property FunctionName As String
    Public ReadOnly Property FunctionReturn As Type
    Public ReadOnly Property FunctionParameter As Dictionary(Of String, Type)
    Public ReadOnly Property FunctionMainCode As String
    Public Sub New(Functionnamies As String, FunctionRets As String, Functionparam As String, Functioncodes As String)
        FunctionParameter = GetParam(Functionparam)
        FunctionReturn = ApiFunction.GetFunctionReturnType(FunctionRets)
        FunctionName = ApiFunction.GetNameStr(Functionnamies)
        FunctionMainCode = ApiFunction.GetCodeStrNoLRNoEmpty(Functioncodes)
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
