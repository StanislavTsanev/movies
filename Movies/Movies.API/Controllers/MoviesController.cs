using Microsoft.AspNetCore.Mvc;
using Movies.API.Models.BindingModels;
using Movies.Application.Features.Movies.Commands.CreateMovie;
using Movies.Application.Features.Movies.Dtos;
using Movies.Application.Features.Movies.Queries.GetMovies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.API.Controllers
{
    public class MoviesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<MovieDto>>> GetAll([FromQuery] GetAllMoviesBindingModel getAllMoviesBm)
        {
            var response = await Mediator.Send(Mapper.Map<GetMoviesQuery>(getAllMoviesBm));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<int>>> Create([FromForm] CreateMovieBindingModel createMovieBm)
        {
            var response = await Mediator.Send(Mapper.Map<CreateMovieCommand>(createMovieBm));

            return Ok(response);
        }
    }
}
