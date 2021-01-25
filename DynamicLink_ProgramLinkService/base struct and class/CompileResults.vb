Public Class CompileResults
    Public ReadOnly Property CompileError As Boolean


    Public Sub New(successis As Boolean)
        CompileError = successis
    End Sub

End Class
