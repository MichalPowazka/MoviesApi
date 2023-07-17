using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<Review> Reviews { get; set; }

    }
}
