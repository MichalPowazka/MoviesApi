using AutoMapper;
using MoviesApi.Entities;
using MoviesApi.Models;

namespace MoviesApi
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
           
            CreateMap<Movie, MovieDto>().ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews)); ;

            CreateMap<Review, ReviewDto>();

            CreateMap<CreateMovieDto, Movie>();

            CreateMap<CreateReviewDto, Review>();

            
        }
    }
}
