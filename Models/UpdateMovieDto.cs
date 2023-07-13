using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models
{
    public class UpdateMovieDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }


    }
}
