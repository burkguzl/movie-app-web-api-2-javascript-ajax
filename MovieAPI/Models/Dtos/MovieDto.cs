using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieAPI.Models.Dtos
{
    public class MovieDto
    {
        [Required(ErrorMessage = "Please enter a valid name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a valid type")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Please enter a valid description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a valid imdb rate")]
        public double IMDbRate { get; set; }
        [Required(ErrorMessage = "Please enter a valid director")]
        public string Director { get; set; }
    }
}