using PokemonInfo.Models;

namespace PokemonInfo.Interfaces
{
    public interface IOwnerRepository
    {
        // ICollection: editable version of IEnumerable
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);

        ICollection<Owner> GetOwnerOfAPokemon(int pokeId);

        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        bool OwnerExists(int ownerId);
    }
}