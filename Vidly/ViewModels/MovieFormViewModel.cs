using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genres> Genres { get; set; }

        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Genre")]

        [Required]
        public byte? GenresId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [Range(1, 20)]
        [Display(Name = "Stock")]
        public int? Stock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Editar Película" : "Nueva Película";
            }
        }


        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel (Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenresId = movie.GenresId;
        }

    }
}