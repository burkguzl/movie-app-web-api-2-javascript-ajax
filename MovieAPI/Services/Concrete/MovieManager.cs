using Core.Utilities;
using MovieAPI.Models.Context;
using MovieAPI.Models.Dtos;
using MovieAPI.Models.Entity;
using MovieAPI.Services.Abstract;
using MovieAPI.Utilities.Constans;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Http.ModelBinding;

namespace MovieAPI.Services.Concrete
{//
    public class MovieManager : IMovieService
    {
        public IDataResult<MovieDto> Add(MovieDto movie)
        {
            try
            {

                Movie _movie = new Movie
                {
                    Name = movie.Name,
                    Description = movie.Description,
                    Director = movie.Director,
                    IMDbRate = movie.IMDbRate,
                    Type = movie.Type
                };

                using (var context = new DatabaseContext())
                {
                    context.Entry(_movie).State = EntityState.Added;
                    context.SaveChanges();
                }

                return new SuccessDataResult<MovieDto>(Messages.MovieAdded, movie);
            }
            catch (Exception)
            {
                return new ErrorDataResult<MovieDto>(Messages.Error, movie);
            }
        }

        public IDataResult<Movie> Delete(int id)
        {
            Movie _movie = new Movie();

            try
            {
                using (var context = new DatabaseContext())
                {
                    _movie = context.Movies.Where(i => i.MovieId == id).FirstOrDefault();
                    context.Entry(_movie).State = EntityState.Deleted;
                    context.SaveChanges();
                }

                return new SuccessDataResult<Movie>(Messages.MovieDeleted, _movie);
            }
            catch (Exception)
            {
                return new SuccessDataResult<Movie>(Messages.Error, _movie);
            }
        }

        public IDataResult<Movie> Get(Expression<Func<Movie, bool>> filter)
        {
            try
            {

                using (var context = new DatabaseContext())
                {
                    return new SuccessDataResult<Movie>(Messages.Successful, context.Movies.Where(filter).SingleOrDefault());
                }

            }
            catch (Exception)
            {

                return new ErrorDataResult<Movie>(Messages.Error);
            }
        }

        public IDataResult<Movie> GetById(int id)
        {
            
            try
            {

                using (var context = new DatabaseContext())
                {
                    Movie _movie = context.Movies.Where(i => i.MovieId == id).SingleOrDefault();
                    if (_movie == null)
                    {
                        return new ErrorDataResult<Movie>(Messages.Error);
                    }
                    else
                    {
                        return new SuccessDataResult<Movie>(Messages.Successful,_movie);
                    }               
                }

            }
            catch (Exception)
            {
                return new ErrorDataResult<Movie>(Messages.Error);
            }
        }

        public IDataResult<List<Movie>> GetList(Expression<Func<Movie, bool>> filter = null)
        {
            try
            {

                using (var context = new DatabaseContext())
                {
                    return filter == null ? new SuccessDataResult<List<Movie>>(Messages.Successful, context.Movies.ToList()) :
                        new SuccessDataResult<List<Movie>>(Messages.Successful, context.Movies.Where(filter).ToList());
                }

            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Movie>>(Messages.Error);
            }
        }

        public IDataResult<Movie> Update(Movie movie)
        {

            try
            {
                using (var context = new DatabaseContext())
                {
                    Movie _movie = context.Movies.Where(i => i.MovieId == movie.MovieId).SingleOrDefault();

                    _movie.Name = movie.Name;
                    _movie.Description = movie.Description;
                    _movie.Type = movie.Type;
                    _movie.Director = movie.Director;
                    _movie.IMDbRate = movie.IMDbRate;

                    context.Entry(_movie).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return new SuccessDataResult<Movie>(Messages.MovieUpdated, movie);
            }
            catch (Exception)
            {
                return new ErrorDataResult<Movie>(Messages.Error, movie);
            }
        }
    }
}