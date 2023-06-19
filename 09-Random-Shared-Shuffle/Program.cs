using System.Data;
using System.Reflection;



ExampleType[] trainingData =
    new ExampleType[]
{
    new ExampleType(1),
    new ExampleType(2),
    new ExampleType(3),
    new ExampleType(4),
    new ExampleType(5),
    new ExampleType(6),
};

Random.Shared.Shuffle(trainingData);

foreach (var item in trainingData)
{
    Console.WriteLine(item.Id);
}
