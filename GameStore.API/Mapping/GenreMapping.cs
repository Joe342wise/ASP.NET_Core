using GameStore.API.Dtos;
using GameStore.API.Entities;

namespace GameStore.API.Mapping;

public static class GenreMapping
{
    public static GenreDto ToGenreDto(this Genre genre)
    {
        return new GenreDto(genre.Id, genre.Name);
    }
}
