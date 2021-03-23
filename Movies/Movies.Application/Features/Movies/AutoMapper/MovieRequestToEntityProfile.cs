using AutoMapper;
using Movies.Application.Features.Movies.Commands.UpdateMovie;
using Movies.Application.Features.Movies.Models;
using Movies.Domain.Entities;

namespace Movies.Application.Features.Movies.AutoMapper
{
    public class MovieRequestToEntityProfile : Profile
    {
        public MovieRequestToEntityProfile()
        {
            AllowNullCollections = true;

            CreateMap<UpsertMovieCommand, MovieEntity>();

            CreateMap<UpdateMovieCommand, MovieEntity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
