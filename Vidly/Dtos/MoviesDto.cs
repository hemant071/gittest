using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Movies Name")]
        public string Name { get; set; }




        public GenreDto Genre { get; set; }
        public byte GenreId { get; set; }


        public DateTime? ReleasedDate { get; set; }

        public DateTime? DateAdded { get; set; }



       // [Range(1, 20, ErrorMessage = "The number in stock most be in between 1 to 20")]
        public int NoInStock { get; set; }
    }
}