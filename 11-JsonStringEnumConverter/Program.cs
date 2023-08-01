// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;

string jsonString2 = JsonSerializer.Serialize(new Test());


Console.WriteLine(jsonString2);

[JsonConverter(typeof(JsonStringEnumConverter<MyEnum>))]
public enum MyEnum { Value1, Value2, Value3 }

[JsonSerializable(typeof(MyEnum))]
public partial class MyContext : JsonSerializerContext { }

public class Test
{
    public Test()
    {
        MyEnum = MyEnum.Value2;
        MyContext = new MyContext();
    }

    public MyEnum MyEnum { get; set; }

    public MyContext MyContext { get; set; }
}