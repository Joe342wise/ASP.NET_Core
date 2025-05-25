using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;


public record class CreateCameDto(
    [Required]
    [MaxLength(100)]
    string Name,
    [Required]
    [MaxLength(50)]
    string Genre,
    [Required]
    decimal Price,
    [Required]
    DateOnly ReleaseDate
);
