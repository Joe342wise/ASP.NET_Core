using GameStore.API.Dtos;
using GameStore.API.Endpoints;
using GameStore.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("GameStoreConnection");
builder.Services.AddSqlite<GameStoreContext>(connectionString);

// app.MapGet("/", () => "Hello World!");

app.MapGroup("/games").MapGamesEndpoints().WithParameterValidation();

app.MigrateDb();

app.Run();
