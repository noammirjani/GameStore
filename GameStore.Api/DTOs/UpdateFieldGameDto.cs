namespace GameStore.Api.DTOs;

using System;
using System.ComponentModel.DataAnnotations;

public record class UpdateFieldGameDto(
    [StringLength(50)]string? Name,
    [StringLength(20)]string? Genre,
    [Range(1,100)]decimal? Price,
    DateOnly? ReleaseDate
);