using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Entities;
using MoviesApi.Models;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [Route("api/movie")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetAll()
        {

            var moviesDtos = _movieService.GetAll();

            return Ok(moviesDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> Get([FromRoute] int id)
        {
            var movieDto = _movieService.GetById(id);

            if (movieDto is null)
            {
                return NotFound();
            }

            return Ok(movieDto);
        }

        [HttpPost]
        public ActionResult CreateMovie([FromBody] CreateMovieDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _movieService.CreateAsync(dto);

            return Created($"/api/movie/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _movieService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}")]

        public ActionResult<UpdateMovieDto> Update([FromBody] UpdateMovieDto updateMovie , [FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _movieService.Update(updateMovie , id);

            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok(isUpdated);


        }





    }
}
