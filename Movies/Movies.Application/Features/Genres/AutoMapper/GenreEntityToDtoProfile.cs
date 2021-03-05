using AutoMapper;
using Movies.Application.Features.Genres.Dtos;
using Movies.Domain.Entities;
using System.Linq;

namespace Movies.Application.Features.Genres.AutoMapper
{
    public class GenreEntityToDtoProfile : Profile
    {
        public GenreEntityToDtoProfile()
        {
            CreateMap<GenreEntity, GenreDto>()
                .ForMember(dest => dest.MovieIds, opt => opt.MapFrom(src => src.MovieGenres.Select(x => x.Movie.Id)));
        }
    }
}
