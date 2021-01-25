Public Class Program
    Public Shared Sub Main()
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
        Dim P As New LinkService
        P.Compile(File.ReadAllText("D:\DLC.LSS"))
    End Sub

End Class
