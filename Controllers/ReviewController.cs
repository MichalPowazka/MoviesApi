using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{

    [Route("api/{movieId}/review")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewService _service;
        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int movieId, CreateReviewDto reviewDto) 
        {
            var newReviewId = _service.Create(movieId, reviewDto);

            return Created($"api/{movieId}/review/{newReviewId}", null);
        }
    }
}
