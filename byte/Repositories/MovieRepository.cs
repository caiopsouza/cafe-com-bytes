using Microsoft.EntityFrameworkCore;
using Take.Contexts;
using Take.Dto;
using Take.Entities;

namespace Take.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DbSet<Movie> _dbSet;

        private readonly IGenreRepository _genreRepository;

        public MovieRepository(Context context, IGenreRepository genreRepository)
        {
            _dbSet = context.Set<Movie>();

            _genreRepository = genreRepository;
        }

        public IEnumerable<Movie> GetAll() =>
            _dbSet;

        public async Task<MovieDto> Add(MovieUpdateDto movieDto)
        {
            var movie = new Movie(movieDto.Name)
            {
                Uri = movieDto.Uri
            };

            _dbSet.Add(movie);

            var genres = await _genreRepository.AllIn(movieDto.Genres);

            genres.ForEach(movie.Genres.Add);

            return new MovieDto
            {
                Id = movie.Id,
                Name = movie.Name,
                Uri = movie.Uri,
                Genres = genres.OrderBy(genre => genre.Name).Select(genre => genre.Name)
            };
        }

        public void Remove(int id)
        {
            var movie = new Movie(null!) { Id = id };
            _dbSet.Remove(movie);
        }

        public IEnumerable<MovieRateDto> TopTen()
        {
            var query =
                from movie in _dbSet

                let rate = movie.Rates.Average(r => (int)r.Stars)
                let votes = movie.Rates.Count

                where votes > 10

                orderby rate descending

                select new MovieRateDto
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Uri = movie.Uri,
                    Rate = rate,
                    Votes = votes,
                    Genres =
                        from genre in movie.Genres
                        orderby genre.Name
                        select genre.Name
                };

            return query.Take(10);
        }
    }
}
