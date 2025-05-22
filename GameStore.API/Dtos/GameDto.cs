namespace GameStore.API.Dtos;

public record class GameDto(
    int Id,
    string Name,
    string Gernre,
    decimal Price,
    string Genre,
    DateOnly ReleaseDate
);
