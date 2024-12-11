using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("GameStoreDb");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

//all the endpoints are defined in the GameEndpoints class
app.MapGamesEndpoints();

app.MigrateDb();

app.Run();