using GameStore.API.Dtos;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
    new (1, "The Witcher 3", "Action RPG", 59.99m, new DateOnly(2015, 5, 19)),
    new (2, "Dark Souls 3", "Action RPG", 49.99m, new DateOnly(2016, 3, 24)),
    new (3, "Elden Ring", "Action RPG", 69.99m, new DateOnly(2022, 2, 25)),
    new (4, "Horizon Zero Dawn", "Action RPG", 39.99m, new DateOnly(2017, 2, 28)),
    new (5, "The Last of Us Part II", "Action Adventure", 59.99m, new DateOnly(2020, 6, 19)),
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/{id}
app.MapGet("/games/{id}", (int id) => 
{
    GameDto? game = games.FirstOrDefault(g => g.Id == id);
    if (game == null) return Results.NotFound();

    return Results.Ok(game);
})
.WithName(GetGameEndpointName);

// POST /games
app.MapPost("/games", (CreateCameDto newGame) => {
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id}, game);
});

// PUT /games
app.MapPut("/games/{id}", (int id, UpdateGameDto updateGame) => {
    var index = games.FindIndex(g => g.Id == id);
    if (index == -1) return Results.NotFound();

    games[index] = new GameDto(
        id,
        updateGame.Name,
        updateGame.Genre,
        updateGame.Price,
        updateGame.ReleaseDate
    );

    return Results.NoContent();
});

// Delete /games/1
app.MapDelete("games/{id}", (int id) => {
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
});

// app.MapGet("/", () => "Hello World!");

app.Run();
