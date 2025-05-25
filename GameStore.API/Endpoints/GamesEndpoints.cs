using System;
using GameStore.API.Dtos;

namespace GameStore.API.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = [
        new (1, "The Witcher 3", "Action RPG", 59.99m, new DateOnly(2015, 5, 19)),
        new (2, "Dark Souls 3", "Action RPG", 49.99m, new DateOnly(2016, 3, 24)),
        new (3, "Elden Ring", "Action RPG", 69.99m, new DateOnly(2022, 2, 25)),
        new (4, "Horizon Zero Dawn", "Action RPG", 39.99m, new DateOnly(2017, 2, 28)),
        new (5, "The Last of Us Part II", "Action Adventure", 59.99m, new DateOnly(2020, 6, 19)),
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this RouteGroupBuilder gamesGroup){

        // GET /games
        gamesGroup.MapGet("/", () => games);

        // GET /games/{id}
        gamesGroup.MapGet("/{id}", (int id) => 
        {
            GameDto? game = games.FirstOrDefault(g => g.Id == id);
            if (game == null) return Results.NotFound();

            return Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        // POST /games
        gamesGroup.MapPost("/", (CreateCameDto newGame) => {
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
        gamesGroup.MapPut("/{id}", (int id, UpdateGameDto updateGame) => {
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
        gamesGroup.MapDelete("/{id}", (int id) => {
            games.RemoveAll(game => game.Id == id);

                    return Results.NoContent();
        });

        return gamesGroup;
    }

}
