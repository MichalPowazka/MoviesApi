using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Entities;
using MoviesApi.Models;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;

        }

        [Authorize]
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

            

            return Ok(movieDto);
        }

        [HttpPost]
        public ActionResult CreateMovie([FromBody] CreateMovieDto dto)
        {

            var id = _movieService.CreateAsync(dto);

            return Created($"/api/movie/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _movieService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]

        public ActionResult<UpdateMovieDto> Update([FromBody] UpdateMovieDto updateMovie , [FromRoute] int id)
        {
          
            _movieService.Update(updateMovie , id);

            
            return Ok();


        }





    }
}
