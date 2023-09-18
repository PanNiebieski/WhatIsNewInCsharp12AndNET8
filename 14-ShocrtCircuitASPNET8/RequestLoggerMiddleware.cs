namespace _14_ShocrtCircuitASPNET8;

public class RequestLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private long _number = 0;
    public RequestLoggerMiddleware(RequestDelegate next)
    { _next = next; }

    public async Task InvokeAsync(HttpContext context)
    {
        var start = TimeProvider.System.GetTimestamp();
        try
        { await _next(context); }
        finally
        {
            if (_number == long.MaxValue)
                _number = 0;
            _number++;
            var diff = TimeProvider.System.GetElapsedTime(start);
            Console.WriteLine("\n{1} Request took {0}ms\n", diff.TotalMilliseconds, _number);
        }
    }
}
public static class RequestLoggerMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLogger(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLoggerMiddleware>();
    }
}

