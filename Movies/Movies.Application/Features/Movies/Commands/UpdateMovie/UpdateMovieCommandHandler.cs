using AutoMapper;
using Movies.Application.Common.Interfaces;
using Movies.Application.Common.Models.Mediatr;
using Movies.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Features.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandHandler : BaseRequestHandler<UpdateMovieCommand, MovieEntity>
    {
        public UpdateMovieCommandHandler(IData data, IMapper mapper) 
            : base(data, mapper)
        {
        }

        public override async Task<MovieEntity> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieEntity = await _data.Movies.GetByIdAsync(request.Id);

            var updatedMovieEntity = _mapper.Map(request, movieEntity);

            await _data.Movies.UpdateAsync(updatedMovieEntity);

            return updatedMovieEntity;
        }
    }
}
