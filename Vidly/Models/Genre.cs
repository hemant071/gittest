﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {

       
        public byte Id { get; set; }

        public string Name { get; set; }

        public DateTime? DateAdded { get; set; }
        
        public DateTime? DateUpdated { get; set; }
    }
}