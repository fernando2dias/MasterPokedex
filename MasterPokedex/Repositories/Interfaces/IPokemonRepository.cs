using MasterPokedex.Models;

namespace MasterPokedex.Repositories.Interfaces
{
    public interface IPokemonRepository
    {
        Task<Pokemon?> GetPokemonByNameAsync(string name);
    }
}
