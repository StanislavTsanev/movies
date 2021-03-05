using AutoMapper;
using Movies.Application.Features.Movies.Dtos;
using Movies.Domain.Entities;
using System.Linq;

namespace Movies.Application.Features.Movies.AutoMapper
{
    public class MovieEntityToDtoProfile : Profile
    {
        public MovieEntityToDtoProfile()
        {
            CreateMap<MovieEntity, MovieDto>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.MovieGenres.Select(x => x.Genre)));
        }
    }
}
