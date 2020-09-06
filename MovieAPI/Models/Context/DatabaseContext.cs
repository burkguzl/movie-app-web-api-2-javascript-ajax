using MovieAPI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieAPI.Models.Context
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext():base("MovieConnection")
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}