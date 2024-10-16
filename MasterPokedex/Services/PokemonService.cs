using MasterPokedex.Models;
using MasterPokedex.Repositories.Interfaces;
using MasterPokedex.Services.Interfaces;

namespace MasterPokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<Pokemon?> GetPokemonByNameAsync(string name)
        {
            return await _pokemonRepository.GetPokemonByNameAsync(name);
        }
    }
}
