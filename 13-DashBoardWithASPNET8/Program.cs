using _13_DashBoardWithASPNET8;
using Microsoft.AspNetCore.SignalR;
using OpenTelemetry.Metrics;
using System.Net.Http.Headers;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenTelemetry().WithMetrics(x =>
       {
           x.AddPrometheusExporter();
           x.AddMeter(
               "Microsoft.AspNetCore.Hosting",
               "Microsoft.AspNetCore.Server.Kestrel");
           x.AddView("requst-duration", new ExplicitBucketHistogramConfiguration
           {
               Boundaries = new[] { 0, 0.005, 0.01, 0.025, 0.05, 0.075, 0.1, 0.25, }
           }); ;
       }
    ); ;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var sampleTodos = TodoGenerator.GenerateTodos().ToArray();

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.MapGet("/", () =>
{
    return Results.Extensions.HtmlResponse(HtmlBody.Get());
});

app.MapPrometheusScrapingEndpoint();

app.Run();
