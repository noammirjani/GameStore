using GameStore.Api.DTOs;
using GameStore.Api.Entities;

namespace GameStore.Api.Data.Migrations;

// This class contains extension methods for mapping between DTOs and entities 
public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game)
    {   
        return new Game()
        {
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public static Game ToEntity(this UpdateGameDto game, int id)
    {   
        return new Game()
        {
            Id = id,
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public static Game ToEntity(this UpdateFieldGameDto toUpdate, int id, Game existedGame)
    {   
        return new Game()
            {
                Id = id,
                Name = toUpdate.Name ?? existedGame.Name,
                GenreId = toUpdate.GenreId ?? existedGame.GenreId,
                Price = toUpdate.Price ?? existedGame.Price,
                ReleaseDate = toUpdate.ReleaseDate ?? existedGame.ReleaseDate
            };
    }

    public static GameSummaryDto ToGameSummaryDto(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.Genre!.Name,
            game.Price,
            game.ReleaseDate
        );
    }

    public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleaseDate
        );
    }
}
