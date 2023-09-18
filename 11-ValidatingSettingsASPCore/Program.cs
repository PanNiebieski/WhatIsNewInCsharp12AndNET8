using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateSlimBuilder(args);
var config = builder.Configuration;

builder.Services.AddOptions<ExampleOptions>()
    .Bind(config.GetSection(ExampleOptions.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddOptions<OtherOptions>()
    .Bind(config.GetSection(OtherOptions.SectionName));


builder.Services.AddSingleton<IValidateOptions<OtherOptions>,
    OtherOptionsValidator>();

var app = builder.Build();


var todosApi = app.MapGroup("/config");

todosApi.MapGet("/", (IOptions<ExampleOptions> op) => { return op.Value; });

todosApi.MapGet("/2", (IOptions<OtherOptions> op) => { return op.Value; });

app.Run();


public class ExampleOptions
{
    public const string SectionName = "Example";

    [EnumDataType(typeof(Levels))]
    public required string Level { get; init; }

    [Range(1, 9)]
    public required int Retries { get; init; }

    [ValidateObjectMembers]
    public Inner Inner { get; set; }
}

public class Inner
{
    [Range(1, 9)]
    public required int Number { get; init; }
}

public class OtherOptions
{
    public const string SectionName = "Other";

    [EnumDataType(typeof(Levels))]
    public required string Level { get; init; }

    [Range(1, 9)]
    public required int Retries { get; init; }
}



public enum Levels
{
    Grass,
    Sky,
    Spaces
}
