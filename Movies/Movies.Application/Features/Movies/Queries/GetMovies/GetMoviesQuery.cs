using Movies.Application.Common.Models.Mediatr;
using Movies.Application.Features.Movies.Dtos;
using System.Collections.Generic;

namespace Movies.Application.Features.Movies.Queries.GetMovies
{
    public class GetMoviesQuery : BaseQuery<IEnumerable<MovieDto>>
    {
    }
}
