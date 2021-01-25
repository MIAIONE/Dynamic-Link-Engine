Public Class LinkService

    Public Function Compile(code As String) As CompileResults
        Dim Code_PLS As String = code

        If Equals(Code_PLS.Substring(0, 6).ToUpper, "!#[RE]") = False Then
            Return New CompileResults(False)
        End If

        Dim HoverCode As String = ApiFunction.GetOriginalCode(Code_PLS)
        Dim test1 As String = "(appk)"
        Dim test2 As String = "(object:i,int:x)"
        Dim test3 As String = "{
    int:kls;
    kls<-888;
    int:kmc;
    kmc<-666;
    string:result;
    result<-appv(kls,kmc);
    //out line
}"
        Dim testvoidf As New VoidStructure(test1, test2, test3)
        Console.WriteLine("name:" + testvoidf.VoidName)
        Console.WriteLine("var1:" + testvoidf.VoidParameter.Item("i"))
        Console.WriteLine("var2:" + testvoidf.VoidParameter.Item("x"))
        Console.WriteLine("code:" + testvoidf.VoidMainCode)

        Console.ReadKey()
    End Function



    Private Function GetAllVoid(code_h As String) As VoidStructure

    End Function
End Class
