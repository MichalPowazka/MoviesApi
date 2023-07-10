namespace MoviesApi.Models
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public float Rate { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
