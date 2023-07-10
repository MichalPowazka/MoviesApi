using MoviesApi.Entities;

namespace MoviesApi.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public List<ReviewDto> Reviews { get; set; }
    }
}
