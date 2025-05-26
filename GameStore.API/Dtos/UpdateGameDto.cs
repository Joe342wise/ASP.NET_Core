using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record class UpdateGameDto(
    [Required][MaxLength(100)]string Name,
    int GenreId,
    [Required]decimal Price,
    [Required]DateOnly ReleaseDate
);
