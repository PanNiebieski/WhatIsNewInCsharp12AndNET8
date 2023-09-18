

using Microsoft.Extensions.Time.Testing;

var start = TimeProvider.System.GetTimestamp();

var h = new HelloService
    (new FakeTimeProvider(DateTimeOffset.Now));

Console.WriteLine(h.Text());

var end = TimeProvider.System.GetTimestamp();

Console.WriteLine(TimeProvider.System.GetElapsedTime(start, end));



public class HelloService
{
    private readonly TimeProvider _timeProvider;

    public HelloService(TimeProvider timeProvider)
    { _timeProvider = timeProvider; }

    public string Text()
    {
        var dataTimeNow = _timeProvider.GetUtcNow();

        return dataTimeNow.Hour switch
        {
            >= 5 and < 12 => "Hello, Good moring",
            >= 12 and < 18 => "Good afternoon",
            _ => "Good evening",
        };
    }
}