using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genres Genres { get; set; }

        [Display(Name = "Genre")]
        
        [Required]
        public byte GenresId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Range (1, 20)]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        public static readonly int bottom = 1;

    }

    // /movie/random
}