

using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class GenresEndPoints
{
    const string GetGenreEndpoint = "GetGenre";

    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("/genres").WithParameterValidation();

        group.MapGet("/", async (GameStoreContext dbContext) =>
            await dbContext.Genres
            .Select(g => g.ToDto())
            .AsNoTracking()
            .ToListAsync()
        );

        
        return group;
    }

}
