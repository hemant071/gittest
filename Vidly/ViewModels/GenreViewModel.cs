using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class GenreViewModel
    {
        public Genre Genre { get; set; }

        public IEnumerable<Movies> Movies { get; set; }

      
    }
}