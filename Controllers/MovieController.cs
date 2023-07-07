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
        public async Task<ActionResult<Movie>> GetAll()
        {
            var movies = await _dbContext.Movies.ToListAsync();
            return Ok(movies);
        }

    }
}
