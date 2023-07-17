using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models
{
    public class CreateReviewDto
    { 

        [Required]
        public string Content { get; set; }
        public float Rate { get; set; }
        public int MovieId { get; set; }


        
    }
}
