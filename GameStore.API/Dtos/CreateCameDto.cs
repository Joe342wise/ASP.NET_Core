namespace GameStore.API.Dtos;

public record class CreateCameDto(
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
