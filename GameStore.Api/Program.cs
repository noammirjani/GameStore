using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//all the endpoints are defined in the GameEndpoints class
app.MapGamesEndpoints();

app.Run();