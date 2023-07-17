using AutoMapper;
using MoviesApi.Entities;
using MoviesApi.Models;

namespace MoviesApi
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            //typ zrodlowy na jaki typ chcemy zmapowac
            CreateMap<Movie, MovieDto>();

            CreateMap<Review, ReviewDto>();

            CreateMap<CreateMovieDto, Movie>();

            CreateMap<CreateReviewDto, Review>();

            
        }
    }
}
