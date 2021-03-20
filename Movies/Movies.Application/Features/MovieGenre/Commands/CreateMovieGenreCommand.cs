using Movies.Application.Common.Models.Mediatr;
using Movies.Domain.Entities;

namespace Movies.Application.Features.MovieGenre.Commands
{
    public class CreateMovieGenreCommand : BaseCommand<MovieGenreEntity>
    {
        public int MovieId { get; set; }

        public int GenreId { get; set; }
    }
}
