using System.Text.Json.Serialization;

namespace MasterPokedex.Models
{
    public record Type(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("url")] string Url
        );
}
