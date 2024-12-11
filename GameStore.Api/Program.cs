using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("GameStoreDb");
builder.Services.AddSqlite<GameStoreContext>(connString);
// The GameStoreContext is registered as a scoped service, so we can inject it in the endpoints.
// Scoped lifetime ensures that a new instance will be created and exposed for every single request.
// Scoped lifetime because:
//          1. Thread safety, preventing concurrent access to the same instance.
//          2. Efficiency, as database connections are limited and expensive relative resources.
//          3. Transactions, ensuring data consistency per request.
//          4. Reducing memory overhead, disposing of the context after the request is done.
builder.Services.AddScoped<GameStoreContext>();

var app = builder.Build();

//all the endpoints are defined in the GameEndpoints.cs
app.MapGamesEndpoints();

await app.MigrateDbAsync();

app.Run();