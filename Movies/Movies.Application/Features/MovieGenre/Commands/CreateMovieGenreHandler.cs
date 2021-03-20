using AutoMapper;
using Movies.Application.Common.Interfaces;
using Movies.Application.Common.Models.Mediatr;
using Movies.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Features.MovieGenre.Commands
{
    public class CreateMovieGenreHandler : BaseRequestHandler<CreateMovieGenreCommand, MovieGenreEntity>
    {
        public CreateMovieGenreHandler(IData data, IMapper mapper) 
            : base(data, mapper)
        {
        }

        public override async Task<MovieGenreEntity> Handle(CreateMovieGenreCommand request, CancellationToken cancellationToken)
        {
            var movieEntity = await _data.Movies.GetByIdAsync(request.MovieId);
            var genreEntity = await _data.Genres.GetByIdAsync(request.GenreId);

            var movieGenreEntity = new MovieGenreEntity()
            {
                Movie = movieEntity,
                Genre = genreEntity,
            };

            await _data.MovieGenres.AddAsync(movieGenreEntity);

            return movieGenreEntity; 
        }
    }
}
