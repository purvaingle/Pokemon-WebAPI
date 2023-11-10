using AutoMapper;
using PokemonInfo.Data;
using PokemonInfo.Interfaces;
using PokemonInfo.Models;
//we're building the actual methods
//don't fret, repository is just where you put your database calls

namespace PokemonInfo.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int OwnerId)
        {
            return _context.Owner.Where(o => o.Id == OwnerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            return _context.Owner.Where(c => c.Country.Id == countryId).ToList();
        }
    }
}