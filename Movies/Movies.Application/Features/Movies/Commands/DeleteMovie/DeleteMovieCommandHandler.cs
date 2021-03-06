using AutoMapper;
using Movies.Application.Common.Interfaces;
using Movies.Application.Common.Models.Mediatr;
using Movies.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Features.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommandHandler : BaseRequestHandler<DeleteMovieCommand, MovieEntity>
    {
        public DeleteMovieCommandHandler(IData data, IMapper mapper) 
            : base(data, mapper)
        {
        }

        public override async Task<MovieEntity> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movieEntity = await _data.Movies.GetByIdAsync(request.Id);

            await _data.Movies.DeleteAsync(movieEntity);

            return movieEntity;
        }
    }
}
