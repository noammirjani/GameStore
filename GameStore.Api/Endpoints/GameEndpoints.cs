using GameStore.Api.DTOs;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndpoint = "GetGameById";

    private static readonly List<GameDto> games = [
        new GameDto(1, "Cyberpunk 2077", "RPG", 199.99m, new DateOnly(2020, 12, 10)),
        new GameDto(2, "The Witcher 3", "RPG", 99.99m, new DateOnly(2015, 5, 19)),
        new GameDto(3, "GTA", "Action", 149.99m, new DateOnly(2013, 9, 17)),
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app){
        var group = app.MapGroup("/games").WithParameterValidation();
        
        group.MapGet("/", () => games);

        group.MapGet("/{id}", (int id) => {
            GameDto? game = games.Find(game => game.Id == id);  // game or null
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName(GetGameEndpoint);

        group.MapPost("/", (CreateGameDto newGame) => {
            var game = new GameDto(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);
            games.Add(game);
            return Results.CreatedAtRoute(GetGameEndpoint, new {id = game.Id}, game);
        });

        group.MapDelete("/{id}", (int id) => {
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });

        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) => {
            var gameIndex = games.FindIndex(game => game.Id == id);
            if (gameIndex == -1)
            {
                return Results.NotFound();
            }
            games[gameIndex] = new GameDto(id, updatedGame.Name, updatedGame.Genre, updatedGame.Price, updatedGame.ReleaseDate);
            return Results.NoContent();
        });

        group.MapPatch("/{id}", (int id, UpdateFieldGameDto updatedGame)=> {
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            var game = games[index];
            var updated = game with {
                Name = updatedGame.Name ??  game.Name,
                Genre = updatedGame.Genre ?? game.Genre,
                Price = updatedGame.Price ?? game.Price,
                ReleaseDate = updatedGame.ReleaseDate ?? game.ReleaseDate
            };
            games[index] = updated;
            return Results.Ok(updated);
        });

        return group;
    }

}
