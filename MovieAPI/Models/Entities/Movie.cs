using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.Models.Entity
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double IMDbRate { get; set; }
        public string Director { get; set; }

    }
}