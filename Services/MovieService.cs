using AutoMapper;
using MoviesApi.Entities;
using MoviesApi.Models;
using System.Collections;
using System.Data.Entity;

namespace MoviesApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieApiDbContext _dbContext;
        private readonly IMapper _mapper;
        public MovieService(MovieApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public MovieDto GetById(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);

            if (movie is null) return null;

            var result = _mapper.Map<MovieDto>(movie);
            return result;
        }

        public IEnumerable<MovieDto> GetAll()
        {
            var movies = _dbContext.Movies.ToList();

            var moviesDto = _mapper.Map<List<MovieDto>>(movies);

            return moviesDto;

        }

        public int CreateAsync(CreateMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return movie.Id;
        }

        public bool Delete(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);

            if(movie is null) return false;

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

            return true;

        }

        public bool Update(UpdateMovieDto updateMovie , int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);

            if (movie is null) return false;
           
            movie.Title = updateMovie.Title;
            movie.Description =updateMovie.Description;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
