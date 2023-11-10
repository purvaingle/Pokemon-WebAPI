using Microsoft.Identity.Client;
using PokemonInfo.Data;
using PokemonInfo.Interfaces;
using PokemonInfo.Models;

namespace PokemonInfo.Repository
{
    
    public class PokemonRepository: IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);
            if(review.Count() <= 0)
                return 0;
            // conversion to make sure we get a decimal value instead of some funky value. (Check out topic: Conversion by Teddy Smith)
            return ((decimal)review.Sum(r => r.Rating) / review.Count());

        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy( p => p.Id).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemons.Any(p => p.Id == pokeId);
        }
    }
}