using _14_ShocrtCircuitASPNET8;

var builder = WebApplication.CreateSlimBuilder(args);


var app = builder.Build();

app.UseRequestLogger();
app.UseStaticFiles();

var sampleTodos = TodoGenerator.GenerateTodos().ToArray();

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

//Work only in minimal api 
//Controller can't do that ShortCircuit()
app.MapGet("_health", () => Results.Ok()).ShortCircuit();

app.MapShortCircuit(200, "htmlpage.html");
app.MapShortCircuit(404, "robot.txt", "favicon.ico", "404.html", "sitemap.xml");

app.Run();

