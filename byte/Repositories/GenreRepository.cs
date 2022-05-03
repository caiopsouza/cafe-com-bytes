using Microsoft.EntityFrameworkCore;
using Take.Contexts;
using Take.Entities;

namespace Take.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DbSet<Genre> _dbSet;

        public GenreRepository(Context context)
        {
            _dbSet = context.Set<Genre>();
        }

        public async Task<List<Genre>> AllIn(IEnumerable<string> genres)
        {
            var query =
                from genre in _dbSet
                where genres.Contains(genre.Name)
                select genre;

            return await query.ToListAsync();
        }

        public IEnumerable<object> MoviesByGenre() =>
            from genre in _dbSet
            orderby genre.Name
            select new
            {
                genre.Id,
                genre.Name,
                Movies = genre.Movies.Count
            };
    }
}
