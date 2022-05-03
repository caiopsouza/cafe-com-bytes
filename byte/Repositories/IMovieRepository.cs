using Take.Dto;
using Take.Entities;

namespace Take.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();

        Task<MovieDto> Add(MovieUpdateDto movieDto);

        void Remove(int id);

        IEnumerable<MovieRateDto> TopTen();
    }
}
