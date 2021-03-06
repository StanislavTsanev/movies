using Movies.Application.Features.Movies.Models;
using System.Collections.Generic;

namespace Movies.Application.Features.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : UpsertMovieCommand
    {
        public IEnumerable<int> GenreIds { get; set; }
    }
}
