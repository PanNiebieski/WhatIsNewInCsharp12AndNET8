var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<ExampleLoopedBGService>();
builder.Services.AddHostedService<ExampleBGService>();
builder.Services.AddHostedService<ExampleHostedService>();

builder.Services.Configure<HostOptions>(x =>
{
    x.ServicesStartConcurrently = true;
    x.ServicesStopConcurrently = false;
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();


public class ExampleLoopedBGService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("Working Working");
            await Task.Delay(1000);
        }
    }
}


public class ExampleBGService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("Just Once");
        }
    }
}


public class ExampleHostedService : IHostedService
{
    private readonly ILogger<ExampleHostedService> _logger;

    public ExampleHostedService(ILogger<ExampleHostedService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("ExampleHostedService StartAsync");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("ExampleHostedService StartAsync");
        return Task.CompletedTask;
    }
}


public class MyService : IHostedLifecycleService
{
    public Task StartingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StartingAsync");
        return Task.CompletedTask;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StartAsync");


        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StartedAsync");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StopAsync");
        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StoppedAsync");
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StoppingAsync");
        return Task.CompletedTask;
    }
}
