using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints;

public static class GenreEndpoints
{
    public static RouteGroupBuilder MapGenreEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (GameStoreContext dbContext) => 
        await dbContext.Genres.Select(genre => genre.ToGenreDto()).AsNoTracking().ToListAsync());

        return group;
    }
}
