

Product p1 = new Product(1, "Game");

Product p2 = new Product(1, "T-Shirt",
    new List<decimal>() { 50, 49, 52, 54 });

public class Product(int id, string name,
    IEnumerable<decimal> prices)
{
    public Product(int id, string name) :
        this(id, name, Enumerable.Empty<decimal>())
    { }

    public int Id => id;
    public string Name { get; set; } = name.Trim();
    public decimal AveragePrice => prices.Any() ?
        prices.Average() : 0.0m;
}

