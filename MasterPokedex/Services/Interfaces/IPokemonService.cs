using MasterPokedex.Models;

namespace MasterPokedex.Services.Interfaces
{
    public interface IPokemonService
    {
        Task<Pokemon?> GetPokemonByNameAsync(string name);
    }
}
