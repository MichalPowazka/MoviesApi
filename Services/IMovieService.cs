using MoviesApi.Models;

namespace MoviesApi.Services
{
    public interface IMovieService
    {
        int CreateAsync(CreateMovieDto movieDto);
        IEnumerable<MovieDto> GetAll();
        MovieDto GetById(int id);

        void Delete(int id);

        void Update(UpdateMovieDto updateMovie, int id);
    }
}