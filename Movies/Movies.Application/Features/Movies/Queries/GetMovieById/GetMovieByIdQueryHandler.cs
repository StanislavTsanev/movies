using AutoMapper;
using Movies.Application.Common.Interfaces;
using Movies.Application.Common.Models.Mediatr;
using Movies.Application.Features.Movies.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Features.Movies.Queries.GetMovieById
{
    public class GetMovieByIdQueryHandler : BaseRequestHandler<GetMovieByIdQuery, MovieDto>
    {
        public GetMovieByIdQueryHandler(IData data, IMapper mapper) 
            : base(data, mapper)
        {
        }

        public override async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movieEntity = await _data.Movies.GetByIdAsync(request.Id);

            return _mapper.Map<MovieDto>(movieEntity);
        }
    }
}
