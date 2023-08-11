using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHostBuilder hostBuilder = new HostBuilder();

hostBuilder.ConfigureServices(services =>
{
    services.AddHostedService<MyService>();
});

using (IHost host = hostBuilder.Build())
{
    await host.StartAsync();
    Task.Delay(5000).Wait();
    await host.StopAsync();
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