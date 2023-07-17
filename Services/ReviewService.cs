using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Entities;
using MoviesApi.Exceptions;
using MoviesApi.Models;

namespace MoviesApi.Services
{
    public class ReviewService : IReviewService
    {
        private readonly MovieApiDbContext _context;
        private readonly IMapper _mapper;
        public ReviewService(MovieApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int movieId, [FromBody] CreateReviewDto reviewDto)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == movieId);
            if (movie is null) throw new NotFoundException("Movie not found");

            var reviewEntity = _mapper.Map<Review>(reviewDto);

            reviewEntity.MovieId = movieId;

            _context.Reviews.Add(reviewEntity);
            _context.SaveChanges();

            return reviewEntity.Id;

        }
    }
}
