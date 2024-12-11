using GameStore.Api.Data;
using GameStore.Api.Data.Migrations;
using GameStore.Api.DTOs;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndpoint = "GetGameById";

    // GameDetailsDto = genre as string
    // GameSummaryDto = genre as int
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app){
        
        var group = app.MapGroup("/games").WithParameterValidation();

        group.MapGet("/", (GameStoreContext dbContext) => 
            dbContext.Games
            .Include(g => g.Genre)               // connect Genre to Game
            .Select(g => g.ToGameSummaryDto())   // convert Game to GameSummaryDto
            .AsNoTracking()                     // read-only
        );

        group.MapGet("/{id}", (int id, GameStoreContext dbContext) => {
            Game? game = dbContext.Games.Find(id);
            
            return game is not null ? 
            Results.Ok(game.ToGameDetailsDto()) : Results.NotFound();
        
        }).WithName(GetGameEndpoint);

        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) => {

            Game game = newGame.ToEntity();

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(
                GetGameEndpoint,            // Route name
                new {id = game.Id},         // Route parameters
                game.ToGameDetailsDto());   // Response body
        });

        group.MapDelete("/{id}", (int id, GameStoreContext dbConnect) => {
            // no need to check if game is in db
            // no need to save changes
            dbConnect.Games
            .Where(game => game.Id == id)
            .ExecuteDelete();

            return Results.NoContent();
        });

        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) => {

            Game? existedGame = dbContext.Games.Find(id);
            if (existedGame is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existedGame)
            .CurrentValues
            .SetValues(updatedGame.ToEntity(id));
            dbContext.SaveChanges();

            return Results.NoContent();
        });

        group.MapPatch("/{id}", (int id, UpdateFieldGameDto updatedGame, GameStoreContext dbContext)=> {
            Game? existedGame = dbContext.Games.Find(id);
            if (existedGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existedGame)
            .CurrentValues
            .SetValues(updatedGame.ToEntity(id, existedGame));
            
            dbContext.SaveChanges();
            return Results.NoContent();
        });

        return group;
    }

}
