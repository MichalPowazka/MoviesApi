﻿using System;
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
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(50);



            modelBuilder.Entity<Review>()
                .Property(r => r.Content)
                .IsRequired();

            modelBuilder.Entity<Movie>().HasMany(m => m.Reviews).WithOne(r => r.Movie).HasForeignKey(r => r.MovieId).HasPrincipalKey(r=> r.Id);
            modelBuilder.Entity<Movie>().HasKey(r => r.Id);
            modelBuilder.Entity<Review>().HasKey(r => r.Id);


            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id=1,
                    Content = "Content",
                    Rate = 4,
                    DateAdd = DateTime.Now,
                    MovieId=1,
                    
                });

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Spiderman",
                    Description = "Test",

                });

            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Name = "User"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Admin"
                }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
