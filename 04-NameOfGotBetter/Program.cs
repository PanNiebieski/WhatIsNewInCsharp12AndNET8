
Console.WriteLine(Class.NameOfNumberMaxValue);
Console.WriteLine(Class.NameOfNumberMinValue);
Console.WriteLine(Class.NameOfTextLength);

public class Class
{
    public int Number { get; set; }
    public required string Text { get; set; }

    // Now legal with C# 12
    public const string NameOfNumberMaxValue =
        nameof(Number.MaxValue);

    public const string NameOfNumberMinValue =
        nameof(Number.MinValue);

    public const string NameOfTextLength =
        nameof(Text.Length);
}


public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

