using System.Text.Json.Serialization;

namespace MasterPokedex.Models
{
    public record Move(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("url")] string Url
     );
}
