using GameStore.API.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


List<GameDto> games = [
    new (1, "The Witcher 3", "Action RPG", 59.99m, "Action RPG", new DateOnly(2015, 5, 19)),
    new (2, "Dark Souls 3", "Action RPG", 49.99m, "Action RPG", new DateOnly(2016, 3, 24)),
    new (3, "Elden Ring", "Action RPG", 69.99m, "Action RPG", new DateOnly(2022, 2, 25)),
    new (4, "Horizon Zero Dawn", "Action RPG", 39.99m, "Action RPG", new DateOnly(2017, 2, 28)),
    new (5, "The Last of Us Part II", "Action Adventure", 59.99m, "Action Adventure", new DateOnly(2020, 6, 19)),
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/{id}
app.MapGet("/games/{id}", (int id) => games.FirstOrDefault(g => g.Id == id));

// app.MapGet("/", () => "Hello World!");

app.Run();
