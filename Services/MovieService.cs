using AutoMapper;
using MoviesApi.Entities;
using MoviesApi.Exceptions;
using MoviesApi.Models;
using System.Collections;
using System.Data.Entity;

namespace MoviesApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieApiDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<MovieService> _logger;
        public MovieService(MovieApiDbContext dbContext, IMapper mapper, ILogger<MovieService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;

        }
        public MovieDto GetById(int id)
        {
            var movie = _dbContext.Movies.Include(r=>r.Reviews).FirstOrDefault(m => m.Id == id);

            if (movie is null) throw new NotFoundException("Movie not found");

            var result = _mapper.Map<MovieDto>(movie);

            return result;
        
        }

        public IEnumerable<MovieDto> GetAll()
        {
            var movies = _dbContext.Movies
                        .Include(r=>r.Reviews)
                        .ToList();

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

        public void Delete(int id)
        {

            _logger.LogError($"Restaurant with id: {id} DELETE action invoked");

            var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);

            if(movie is null) throw new NotFoundException("Movie not found");

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

          
        }

        public void Update(UpdateMovieDto updateMovie , int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);

            if (movie is null) throw new NotFoundException("Movie not found");
           
            movie.Title = updateMovie.Title;
            movie.Description =updateMovie.Description;

            _dbContext.SaveChanges();
          
        }
    }
}
