using MovieAPI.Models.Dtos;
using MovieAPI.Models.Entity;
using MovieAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace MovieAPI.Controllers
{
    [RoutePrefix("api/movies")]
    public class MovieController : ApiController
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        [Route("")]
        //POST: api/movies
        public IHttpActionResult Add(MovieDto movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _movieService.Add(movie);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }

        [HttpPost]
        [Route("update/{id}")]
        //PUT : api/movies/update/{id}
        public IHttpActionResult Update(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return BadRequest();
            }

            var result = _movieService.Update(movie);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        //DELETE : api/movies/{id}
        public IHttpActionResult Delete(int id)
        {
            var result = _movieService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        //GET : api/movies/{id}
        public IHttpActionResult Detail(int id)
        {
            var result = _movieService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet]
        [Route("")]
        //GET : api/movies
        public IHttpActionResult List()
        {
            var result = _movieService.GetList();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
