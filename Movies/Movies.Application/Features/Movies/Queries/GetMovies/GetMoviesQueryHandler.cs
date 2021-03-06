using AutoMapper;
using Movies.Application.Common.Interfaces;
using Movies.Application.Common.Models.Mediatr;
using Movies.Application.Features.Movies.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Features.Movies.Queries.GetMovies
{
    public class GetMoviesQueryHandler : BaseRequestHandler<GetMoviesQuery, IEnumerable<MovieDto>>
    {
        public GetMoviesQueryHandler(IData data, IMapper mapper) 
            : base(data, mapper)
        {
        }

        public override async  Task<IEnumerable<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _data.Movies.GetAllAsync();

            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }
    }
}
