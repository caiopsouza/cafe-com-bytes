using Microsoft.AspNetCore.Mvc;
using Take.Contexts;
using Take.Dto;
using Take.Entities;
using Take.Repositories;

namespace take.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        private readonly IGenreRepository _genreRepository;

        private readonly IMovieRepository _movieRepository;

        public MoviesController(IUnitOfWork uow, IGenreRepository genreRepository, IMovieRepository movieRepository)
        {
            _uow = uow;
            _genreRepository = genreRepository;
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public IEnumerable<Movie> Get() =>
            _movieRepository.GetAll();

        [HttpPost]
        public async Task<MovieDto> Post([FromBody] MovieUpdateDto movieDto, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.Add(movieDto);
            await _uow.SaveChangesAsync(cancellationToken);
            return movie;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            _movieRepository.Remove(id);
            await _uow.SaveChangesAsync(cancellationToken);
        }


        [HttpGet("by-genre")]
        public IEnumerable<object> ByGenre() =>
            _genreRepository.MoviesByGenre();

        [HttpGet("top-ten")]
        public IEnumerable<MovieRateDto> TopTen() =>
            _movieRepository.TopTen();
    }
}
