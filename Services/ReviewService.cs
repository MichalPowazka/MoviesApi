using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Entities;
using MoviesApi.Exceptions;
using MoviesApi.Models;
using System.Data.Entity;

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
            reviewEntity.DateAdd = DateTime.Now;

            _context.Reviews.Add(reviewEntity);
            _context.SaveChanges();

            return reviewEntity.Id;

        }

        public ReviewDto GetById(int movieId, int reviewId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if(movie is null) throw new NotFoundException($"Movie not found");

            var review = _context.Reviews.FirstOrDefault(r=> r.Id == reviewId);
            if(review is null || review.MovieId != movieId)
            {
                throw new NotFoundException($"Review not found");
            }

            var reviewDto = _mapper.Map<ReviewDto>(review);

            return reviewDto;

        }

        public List<ReviewDto> GetAll(int movieId)
        {
            var movie = _context.Movies.Include(r =>r.Reviews).FirstOrDefault(r=> r.Id == movieId);

            if (movie is null) throw new NotFoundException("Movie not found");

            var reviewDtos = _mapper.Map<List<ReviewDto>>(movie.Reviews);

            return reviewDtos;
                                          

           
        }
    }
}
