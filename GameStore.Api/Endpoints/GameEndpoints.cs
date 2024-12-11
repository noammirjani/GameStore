using GameStore.Api.Data;
using GameStore.Api.Data.Migrations;
using GameStore.Api.DTOs;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndpoint = "GetGame";

    // GameDetailsDto = genre as string
    // GameSummaryDto = genre as int
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app){
        
        var group = app.MapGroup("/games").WithParameterValidation();

        group.MapGet("/", async (GameStoreContext dbContext) => 
           await dbContext.Games
            .Include(g => g.Genre)               // connect Genre to Game
            .Select(g => g.ToGameSummaryDto())   // convert Game to GameSummaryDto
            .AsNoTracking()                     // read-only
            .ToListAsync()                       // return List<GameSummaryDto>
        );

        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) => {
            Game? game = await dbContext.Games.FindAsync(id);
            
            return game is not null ? 
            Results.Ok(game.ToGameDetailsDto()) : Results.NotFound();
        
        }).WithName(GetGameEndpoint);

        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) => {

            Game game = newGame.ToEntity();

            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetGameEndpoint,            // Route name
                new {id = game.Id},         // Route parameters
                game.ToGameDetailsDto());   // Response body
        });

        group.MapDelete("/{id}", async (int id, GameStoreContext dbConnect) => {
            // no need to check if game is in db
            // no need to save changes
            await dbConnect.Games
            .Where(game => game.Id == id)
            .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        group.MapPut("/{id}", async(int id, UpdateGameDto updatedGame, GameStoreContext dbContext) => {

            Game? existedGame = await dbContext.Games.FindAsync(id);
            if (existedGame is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existedGame)
            .CurrentValues
            .SetValues(updatedGame.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapPatch("/{id}", async (int id, UpdateFieldGameDto updatedGame, GameStoreContext dbContext)=> {
            Game? existedGame = await dbContext.Games.FindAsync(id);
            if (existedGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existedGame)
            .CurrentValues
            .SetValues(updatedGame.ToEntity(id, existedGame));
            
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        return group;
    }

}
