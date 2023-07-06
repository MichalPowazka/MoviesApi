﻿namespace MoviesApi.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Review> Reviews { get; set; }

    }
}
