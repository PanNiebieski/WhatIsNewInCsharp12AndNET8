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


