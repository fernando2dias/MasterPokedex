using MasterPokedex.Models;
using MasterPokedex.Settings;
using Microsoft.Extensions.Options;
using System.Collections.Immutable;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<PokeApiSettings>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/pokemon/{name}", async (string name, IOptions<PokeApiSettings> settings) =>
{
    using var client = new HttpClient();
    var baseUrl = settings.Value.PokeApiBaseUrl;
    var url = $"{baseUrl}pokemon/{name}";

    try
    {
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var pokemon = JsonSerializer.Deserialize<Pokemon>(content);

            pokemon = pokemon is not null ? pokemon with { Url = url } : pokemon;

            return Results.Ok(pokemon);
        }
        else
        {
            return Results.NotFound("Pokemon not found");
        }
    }
    catch (HttpRequestException ex)
    {
        return Results.StatusCode(500);
    }
})
.WithName("GetPokemonByName")
.WithOpenApi();

app.Run();
