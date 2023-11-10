using PokemonInfo.Data;
using PokemonInfo.Interfaces;
using PokemonInfo.Models;
//we're building the actual methods
//don't fret, repository is just where you put your database calls

namespace PokemonInfo.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        //_context is the code that sits on top of your database and gives access to your database

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c =>c.Id == id);
            //Any: bool
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
            //ToList is very important
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
            //FirstOrDefault since we're only returning 1
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(e =>e.CategoryId == categoryId).Select(c=>c.Pokemon).ToList();
            //in EF, if you have nested entities ( or navigation property), its not going to load it automatically fo ryou. You have to ask EF to load it for you.
        }
    }
}