using MoviesApi.Entities;
using MoviesApi.Models;

namespace MoviesApi.Services
{
    public interface IReviewService
    {
        int Create(int movieId, CreateReviewDto reviewDto);
        ReviewDto GetById(int movieId, int reviewId);
        List<ReviewDto> GetAll(int movieId);
        void RemoveAll(int movieId);
    }
}