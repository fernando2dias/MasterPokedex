using MasterPokedex.Models;
using MasterPokedex.Repositories;
using MasterPokedex.Repositories.Interfaces;
using MasterPokedex.Services;
using MasterPokedex.Services.Interfaces;
using MasterPokedex.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<PokeApiSettings>(builder.Configuration);
builder.Services.AddHttpClient<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IPokemonService, PokemonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/pokemon/{name}", async (string name, IPokemonService pokemonService) =>
{
    try
    {
        var pokemon = await pokemonService.GetPokemonByNameAsync(name);

        if (pokemon is not null)
        {
            return Results.Ok(pokemon);
        }
        else
        {
            return Results.NotFound("Pokemon not found");
        }
    }
    catch (HttpRequestException)
    {
        return Results.StatusCode(500);
    }
})
.WithName("GetPokemonByName")
.WithOpenApi();

app.Run();
