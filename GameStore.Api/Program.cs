using GameStore.Api.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpoint = "GetGameById";

List<GameDto> games = [
    new GameDto(1, "Cyberpunk 2077", "RPG", 199.99m, new DateOnly(2020, 12, 10)),
    new GameDto(2, "The Witcher 3", "RPG", 99.99m, new DateOnly(2015, 5, 19)),
    new GameDto(3, "GTA", "Action", 149.99m, new DateOnly(2013, 9, 17)),
];

app.MapGet("/games", () => games);
app.MapGet("/games/{id}", (int id) => {
    GameDto? game = games.Find(game => game.Id == id);  // game or null
    return game is not null ? Results.Ok(game) : Results.NotFound();
}).WithName(GetGameEndpoint);

app.MapPost("games", (CreateGameDto newGame) => {
    var game = new GameDto(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpoint, new {id = game.Id}, game);
});

app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) => {
    var gameIndex = games.FindIndex(game => game.Id == id);
    if (gameIndex == -1)
    {
        return Results.NotFound();
    }
    games[gameIndex] = new GameDto(id, updatedGame.Name, updatedGame.Genre, updatedGame.Price, updatedGame.ReleaseDate);
    return Results.NoContent();
});

app.MapDelete("/games/{id}", (int id) => {
    games.RemoveAll(game => game.Id == id);
    return Results.NoContent();
});

app.MapPatch("/games/{id}", (int id, UpdateFieldGameDto updatedGame)=> {
    var game = games.Find(game => game.Id == id);
    if (game == null)
    {
        return Results.NotFound();
    }
    game = game with {
        Name = updatedGame.Name ??  game.Name,
        Genre = updatedGame.Genre ?? game.Genre,
        Price = updatedGame.Price ?? game.Price,
        ReleaseDate = updatedGame.ReleaseDate ?? game.ReleaseDate
    };
    return Results.Ok(game);
});

app.Run();