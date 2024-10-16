using MasterPokedex.Models;
using MasterPokedex.Repositories.Interfaces;
using MasterPokedex.Settings;
using Microsoft.Extensions.Options;

namespace MasterPokedex.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public PokemonRepository(HttpClient httpClient, IOptions<PokeApiSettings> settings)
        {
            _httpClient = httpClient;
            _baseUrl = settings.Value.PokeApiBaseUrl;
        }

        public async Task<Pokemon?> GetPokemonByNameAsync(string name)
        {
            var url = $"{_baseUrl}pokemon/{name}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var pokemon = await response.Content.ReadFromJsonAsync<Pokemon>();
                    return pokemon is not null ? pokemon with { Url = url } : pokemon;
                }
                return null;
            }
            catch (HttpRequestException)
            {
                throw; //TODO: Criar resiliencia
            }
        }
    }
}
