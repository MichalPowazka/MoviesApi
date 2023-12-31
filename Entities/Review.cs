﻿using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Entities
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public float Rate { get; set; }
        public DateTime DateAdd { get; set; }

   
        public int MovieId { get; set; }   
      
        public virtual Movie Movie { get; set; }




    }
}
