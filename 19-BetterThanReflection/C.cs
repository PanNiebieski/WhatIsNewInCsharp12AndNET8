public class C
{
    private string _field = "Private Field";

    private string _fieldTwo = "Private Field Two";

    private string Method()
    {
        return "Private Method from C";
    }

    public string GetField()
    {
        return _field;
    }

    protected string MyProperty { get; set; } = "Protected MyProperty";
}


