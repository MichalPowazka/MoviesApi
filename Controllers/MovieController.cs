using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Entities;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [Route("api/movie")]
    public class MovieController : Controller
    {
        private readonly MovieApiDbContext _dbContext;

        public MovieController(MovieApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll()
        {
            var movies = await _dbContext.Movies.ToListAsync();
            var moviesDto = movies.Select(m => new MovieDto()
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
             
            });
            return Ok(moviesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get([FromRoute] int id)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if(movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

      



    }
}
