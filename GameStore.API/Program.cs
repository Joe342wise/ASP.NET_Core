using GameStore.API.Dtos;
using GameStore.API.Endpoints;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.MapGroup("/games").MapGamesEndpoints();

app.Run();
