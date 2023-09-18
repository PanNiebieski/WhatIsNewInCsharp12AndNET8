using Microsoft.Extensions.Hosting;

public class MyService : IHostedLifecycleService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("😁StartAsync"); return Task.CompletedTask;
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("😍StartingAsync"); return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("🤩StartedAsync"); return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("😮StopAsync"); return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("😯StoppingAsync"); return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("😲StoppedAsync"); return Task.CompletedTask;
    }
}


