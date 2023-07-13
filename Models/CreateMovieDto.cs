using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models
{
    public class CreateMovieDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
