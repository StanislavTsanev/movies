using Movies.Application.Common.Models.Mediatr;
using Movies.Domain.Entities;

namespace Movies.Application.Features.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommand : BaseCommand<MovieEntity>
    {
        public int? Id { get; set; }
    }
}
