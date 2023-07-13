using MoviesApi.Models;

namespace MoviesApi.Services
{
    public interface IMovieService
    {
        int CreateAsync(CreateMovieDto movieDto);
        IEnumerable<MovieDto> GetAll();
        MovieDto GetById(int id);

        bool Delete(int id);

        bool Update(UpdateMovieDto updateMovie, int id);
    }
}