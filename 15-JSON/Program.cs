using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json.Nodes;

JsonSerializer.Serialize<Memory<int>>
    (new int[] { 1, 2, 3 }); // [1,2,3]

JsonSerializer.Serialize<ReadOnlyMemory
    <byte>>(new byte[] { 1, 2, 3 }); // "AQID"

string json = JsonSerializer.Serialize(new MyPoco(42)); // {"X":42}
JsonSerializer.Deserialize<MyPoco>(json);

//IJsonTypeInfoResolver.WithAddedModifier
//This new extension method enables making modifications
//to serialization contracts of arbitrary IJsonTypeInfoResolver instances:
var options = new JsonSerializerOptions
{
    TypeInfoResolver = MyContext.Default
        .WithAddedModifier(static typeInfo =>
    {
        foreach (JsonPropertyInfo prop in typeInfo.Properties)
        {
            prop.Name = prop.Name.ToUpperInvariant();
        }
    })
};
JsonSerializer.Serialize(new MyRecord(42), options); // {"VALUE":42}

//Additional JsonNode functionality
//JsonNode has significantly updated functionality.
//For example, deep cloning.
JsonNode node = JsonNode.Parse("{\"Prop\":{\"NestedProp\":42}}");
JsonNode other = node.DeepClone();
bool same = JsonNode.DeepEquals(node, other); // true






public record MyRecord(int value);

[JsonSerializable(typeof(MyRecord))]
public partial class MyContext : JsonSerializerContext { }


//Extending JsonIncludeAttribute and JsonConstructorAttribute to non-public members
public class MyPoco
{
    [JsonConstructor]
    internal MyPoco(int x) => X = x;

    [JsonInclude]
    internal int X { get; }
}