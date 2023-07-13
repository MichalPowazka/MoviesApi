using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Entities
{
    public class MovieApiDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MoviesApi;Trusted_Connection=true";
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(50);



            modelBuilder.Entity<Review>()
                .Property(r => r.Content)
                .IsRequired();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id =1,
                    UserName = "Test",
                    Password = "Test",
                    Email = "Test"
                }
                );

            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id=1,
                    Content = "Content",
                    Rate = 4,
                    DateAdd = DateTime.Now,
                    UserId = 1,
                    MovieId=1,
                    
                });

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Spiderman",
                    Description = "Test",

                });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
