using Movies.Application.Common.Models.Mediatr;
using Movies.Application.Features.Movies.Dtos;

namespace Movies.Application.Features.Movies.Queries.GetMovieById
{
    public class GetMovieByIdQuery : BaseRequest<MovieDto>
    {
        public int Id { get; set; }
    }
}
