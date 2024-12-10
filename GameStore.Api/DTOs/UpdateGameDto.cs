namespace GameStore.Api.DTOs;

using System.ComponentModel.DataAnnotations;

public record class UpdateGameDto(
    [Required][StringLength(50)]string Name,
    [Required][StringLength(20)]string Genre,
    [Range(1,100)]decimal Price,
    DateOnly ReleaseDate
);