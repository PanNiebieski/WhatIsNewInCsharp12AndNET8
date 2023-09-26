using System.Reflection;
using System.Runtime.CompilerServices;



ReflectionExample.Go();


// C# 12
//UnsafeAccessorExample.Go();



//UnsafeAccessorExampleReadOnly.Go();






public static class ReflectionExample
{
    public static void Go()
    {
        var cez = new C();

        var text = typeof(C).GetMethod("Method",
            BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(cez, new object[] { });

        Console.WriteLine(text);

        var fieldText = typeof(C).GetField("_fieldTwo",
            BindingFlags.Instance | BindingFlags.NonPublic).GetValue(cez);

        Console.WriteLine(fieldText);


        var field = cez.GetType().GetField("_field", BindingFlags.NonPublic
            | BindingFlags.Instance);

        field.SetValue(cez, "New Value");

        Console.WriteLine(cez.GetField());
    }
}


public class BrigdeCesarClass
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "Method")]
    public static extern string GetMethod(C cesar);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_fieldTwo")]
    public static extern ref string GetFieldAnother(C cesar);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_field")]
    public static extern ref string GetField(C cesar);






    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_MyProperty")]
    public static extern string GetPropety(C cesar);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_MyProperty")]
    public extern static void SetterPropety(C @this, string text);
}








public static class UnsafeAccessorExample
{
    public static void Go()
    {
        var cez = new C();


        var text = BrigdeCesarClass.GetMethod(cez);
        Console.WriteLine(text);


        var fieldText = BrigdeCesarClass.GetFieldAnother(cez);
        Console.WriteLine(fieldText);


        BrigdeCesarClass.GetField(cez) = "New Value 2";
        Console.WriteLine(cez.GetField());


        BrigdeCesarClass.SetterPropety(cez,
            "Brigde.SetterPropety");
        Console.WriteLine(BrigdeCesarClass.GetPropety(cez));
    }
}

















public class Q
{
    // Fields
    private readonly int instanceFieldReadOnly = 1;

    // Static fields
    private static readonly int staticFieldReadOnly = 2;

    public int Show()
    {
        return instanceFieldReadOnly + staticFieldReadOnly;
    }
}







public class BridgeQ
{
    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "instanceFieldReadOnly")]
    public extern static ref int GetInstanceReadOnlyField(Q q);

    [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "staticFieldReadOnly")]
    public extern static ref int GetStaticReadOnlyField(Q q);
}








public static class UnsafeAccessorExampleReadOnly
{
    public static void Go()
    {
        var q1 = new Q();
        var q2 = new Q();

        BridgeQ.GetInstanceReadOnlyField(q1) = 60;
        BridgeQ.GetInstanceReadOnlyField(q2) = 160;

        BridgeQ.GetStaticReadOnlyField(q1) = 40; // ok

        typeof(Q).GetField("instanceFieldReadOnly",
            BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(q1, 260);

        // This fails at runtime
        try
        {
            typeof(Q).GetField("staticFieldReadOnly",
                BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(q2, 999);
        }
        catch (Exception)
        { };

        Console.WriteLine(q1.Show()); //300
        Console.WriteLine(q2.Show()); //200
    }
}
