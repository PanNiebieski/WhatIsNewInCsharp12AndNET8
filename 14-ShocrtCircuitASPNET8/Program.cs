using _14_ShocrtCircuitASPNET8;

var builder = WebApplication.CreateSlimBuilder(args);
var app = builder.Build();

app.UseRequestLogger();
app.UseStaticFiles();

//Works only in minimal api 
//Controller can't do that ShortCircuit()
app.MapGet("_health", () => Results.Ok()).ShortCircuit();
app.MapShortCircuit(200,
    "htmlpage.html");
app.MapShortCircuit(404,
    "robot.txt", "favicon.ico", "404.html", "sitemap.xml");
app.Run();

