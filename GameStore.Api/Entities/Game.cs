using System;

namespace GameStore.Api.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int GenreId { get; set; }
    public Genre? Genre { get; set; } // not required
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
}
