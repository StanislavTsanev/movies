using Movies.Application.Common.Models.Mediatr;
using Movies.Application.Features.Genres.Dtos;
using System.Collections.Generic;

namespace Movies.Application.Features.Genres.Queries
{
    public class GetAllGenresQuery : BaseQuery<IEnumerable<GenreDto>>
    {
    }
}
