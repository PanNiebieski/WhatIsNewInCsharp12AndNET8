using System.Net.Mime;
using System.Text;

public class CustomHTMLResult : IResult
{
    private readonly string _htmlContent;

    public CustomHTMLResult(string htmlContent)
    {
        _htmlContent = htmlContent;
    }
    public async Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.ContentType = MediaTypeNames.Text.Html;
        httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(_htmlContent);
        await httpContext.Response.WriteAsync(_htmlContent);
    }
}
