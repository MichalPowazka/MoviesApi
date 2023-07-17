using MoviesApi.Models;

namespace MoviesApi.Services
{
    public interface IReviewService
    {
        int Create(int movieId, CreateReviewDto reviewDto);
    }
}