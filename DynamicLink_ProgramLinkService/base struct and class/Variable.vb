Public Class Variable
    Inherits DictionaryBase

    Public ReadOnly Property VarName As String
    Public ReadOnly Property VarType As Object

    Public Sub New(VarListName As String, VarListType As Object)
        VarType = VarListType
        VarName = VarListName
    End Sub

End Class
