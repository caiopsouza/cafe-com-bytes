using Take.Entities;

namespace Take.Repositories
{
    public interface IGenreRepository
    {
        Task<List<Genre>> AllIn(IEnumerable<string> genres);

        IEnumerable<object> MoviesByGenre();
    }
}
