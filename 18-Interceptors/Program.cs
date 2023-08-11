using System.Runtime.CompilerServices;

Example ex = new Example();
ex.MyMethod("Check");
ex.MyMethod("Check");
ex.MyMethod("Check");
ex.MyMethod("Check");
ex.MyMethod("Check");


public static class Code
{
    [InterceptsLocation("C:\\Users\\Admin\\source\\repos\\WhatIsNewInCsharp12AndNET8\\18-Interceptors\\Program.cs",
        line: 5, column: 4)]
    [InterceptsLocation("C:\\Users\\Admin\\source\\repos\\WhatIsNewInCsharp12AndNET8\\18-Interceptors\\Program.cs",
        line: 7, column: 4)]
    public static void MyInterceptorMethod(this Example ex, string param)
    {
        Console.WriteLine($"MyInterceptorMethod {param}");
    }
}

public class Example
{
    public void MyMethod(string param)
    {
        Console.WriteLine($"MyMethod {param}");
    }
}


namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    sealed class InterceptsLocationAttribute(string filePath, int line, int column) : Attribute
    {
    }
}

//https://andrewlock.net/exploring-the-dotnet-8-preview-changing-method-calls-with-interceptors/