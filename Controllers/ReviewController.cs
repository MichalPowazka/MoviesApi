using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{

    [Route("api/movie/{movieId}/review")]
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

            return Created($"api/movie/{movieId}/review/{newReviewId}", null);
        }

        [HttpGet("{reviewId}")]
        public ActionResult<ReviewDto> Get([FromRoute] int movieId, [FromRoute] int reviewId)
        {
            var review = _service.GetById(movieId, reviewId);

            return Ok(review);
        }

        [HttpGet]
        public ActionResult<List<ReviewDto>> Get([FromRoute] int movieId)
        {
            var reviews = _service.GetAll(movieId);

            return Ok(reviews);
        }
    }
}
