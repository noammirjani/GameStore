namespace GameStore.Api.DTOs;

public record class UpdateFieldGameDto(
    string? Name,
    string? Genre,
    decimal? Price,
    DateOnly? ReleaseDate
);