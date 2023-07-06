using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesApi.Entities;

namespace MoviesApi
{
    public class MovieSeeder
    {
        private readonly MovieApiDbContext _dbcontext;
        public MovieSeeder(MovieApiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Seed() 
        {
            if (_dbcontext.Database.CanConnect())
            {
                if(!_dbcontext.Reviews.Any())
                {
                    var review = GetReviews();
                    _dbcontext.Reviews.AddRange(review);
                    _dbcontext.SaveChanges();
                }
            }

        }

        private IEnumerable<Review> GetReviews() 
        {
            var reviews = new List<Review>();
            new Review()
            {
                Content = "Content 1",
                Rate = 4,
                DateAdd = DateTime.Now,

                User = new User()
                {
                    UsserName = "damian21551",
                    Password = "kabanos",
                    Email = "damian21551@o2.pl"
                    
                },

                Movie = new Movie()
                {
                    Title = "Spiderman",
                    Description = "The story about amazing spider man adventures"
                }

            };               

            return reviews;
        }

    }
}
