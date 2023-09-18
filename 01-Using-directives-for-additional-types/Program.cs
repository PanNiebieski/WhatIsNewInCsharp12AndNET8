
//C# 12 Using directives for additional types

using Point3D = (int X, int Y, int Z);

using Numbers = int[];

using Strings = System.Collections.
                 Generic.List<string>;

using IsDefined = bool?;

using Person = (string FirstName, string L);










void Calculate(Point3D[] points)
{ }

void Write(Dictionary<Numbers, Strings> d)
{ }

void Check(IsDefined d, Person p)
{ }


public class Product
    (int id, string name, IEnumerable<decimal> prices)
{
    public Product(int id, string name)
        : this(id, name, Enumerable.Empty<decimal>()) { }

    public int Id => id;

    public string Name { get; set; }
        = name.Trim();

    public decimal AveragePrice
        => prices.Any() ? prices.Average() : 4.0m;
}