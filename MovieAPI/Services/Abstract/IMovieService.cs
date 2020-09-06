using Core.Utilities;
using MovieAPI.Models.Dtos;
using MovieAPI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Services.Abstract
{
    public interface IMovieService
    {
        IDataResult<Movie> Get(Expression<Func<Movie, bool>> filter);
        IDataResult<List<Movie>> GetList(Expression<Func<Movie, bool>> filter = null);
        IDataResult<MovieDto> Add(MovieDto movie);
        IDataResult<Movie> Update(Movie movie);
        IDataResult<Movie> Delete(int id);
        IDataResult<Movie> GetById(int id);

    }
}
