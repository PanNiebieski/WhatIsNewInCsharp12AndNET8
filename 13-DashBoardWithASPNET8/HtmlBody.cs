public static class HtmlBody
{
    public static string Get()
    {
        var a = "<html><body><a href=\"http://localhost:5210/metrics\">http://localhost:5210/metrics</a>";
        var b = "<br /><br /><a href=\"http://localhost:5210/todos\">http://localhost:5210/todos</a></body><html>";

        return a + b;
    }
}