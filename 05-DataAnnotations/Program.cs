using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

class S
{
    [Base64String]
    public required string Base64Text { get; set; }

    [AllowedValues(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
    public int Score { get; set; }

    [DeniedValues(-1, 0)]
    public int Age { get; set; }

    [Length(3, 30)]
    public required string Address { get; set; }

    //[Required(DisallowAllDefaultValues = true)]
    public Guid Id { get; set; }
}