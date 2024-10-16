using System.Text.Json.Serialization;

namespace MasterPokedex.Models
{
    public record Pokemon(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("url")] string Url,
        [property: JsonPropertyName("sprites")] Sprites Sprites,
        [property: JsonPropertyName("moves")] List<MoveWrapper> Moves,
        [property: JsonPropertyName("types")] List<TypeWrapper> Types
        );

    public record MoveWrapper([property: JsonPropertyName("move")] Move Move);
    public record TypeWrapper([property: JsonPropertyName("type")] Type Move);
}