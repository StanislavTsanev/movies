using Movies.Application.Common.Models.Mediatr;
using Movies.Application.Features.Movies.Models;
using Movies.Domain.Entities;

namespace Movies.Application.Features.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommand : UpsertMovieCommand
    {
        public int Id { get; set; }
    }
}
