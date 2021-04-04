using AutoMapper;
using Movies.API.AutoMapper.Converters;
using Movies.API.Models.BindingModels;
using Movies.Application.Features.Genres.Queries;
using Movies.Application.Features.Identity.LoginUser;
using Movies.Application.Features.Movies.Commands.CreateMovie;
using Movies.Application.Features.Movies.Commands.UpdateMovie;
using Movies.Application.Features.Movies.Queries.GetMovies;
using Movies.Application.Features.Users.Commands.RegisterUserCommand;

namespace Movies.API.AutoMapper
{
    public class BmToRequestProfile : Profile
    {
        public BmToRequestProfile()
        {
            CreateMap<CreateMovieBindingModel, CreateMovieCommand>()
                .ForMember(req => req.Poster, opt => opt.ConvertUsing(new FormFileToByteArrayConverter()));

            CreateMap<UpdateMovieBindingModel, UpdateMovieCommand>()
                .ForMember(req => req.Poster, opt => opt.ConvertUsing(new FormFileToByteArrayConverter()));

            CreateMap<GetAllGenresBindingModel, GetAllGenresQuery>();

            CreateMap<GetAllMoviesBindingModel, GetMoviesQuery>();

            CreateMap<RegisterUserBindingModel, RegisterUserCommand>();

            CreateMap<LoginBindingModel, LoginQuery>();
        }
    }
}
