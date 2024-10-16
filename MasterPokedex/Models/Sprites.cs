using System.Text.Json.Serialization;

namespace MasterPokedex.Models
{
    public record Sprites(
        [property: JsonPropertyName("back_default")] string BackDefault,
        [property: JsonPropertyName("back_female")] string BackFemale,
        [property: JsonPropertyName("back_shiny")] string BackShiny,
        [property: JsonPropertyName("back_shiny_female")] string BackShinyFemale,
        [property: JsonPropertyName("front_default")] string FrontDefault,
        [property: JsonPropertyName("front_female")] string FrontFemale,
        [property: JsonPropertyName("front_shiny")] string FrontShiny,
        [property: JsonPropertyName("front_shiny_female")] string FrontShinyFemale
        );
}
