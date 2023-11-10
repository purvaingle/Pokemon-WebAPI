using PokemonInfo.Models;

namespace PokemonInfo.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewsOfAPokemon(int reviewerId);
        ICollection<Review> GetReviewsByAReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId); // makes validation easier

    }
}