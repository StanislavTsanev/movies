using AutoMapper;
using Movies.Application.Features.Users.Commands.RegisterUserCommand;
using Movies.Domain.Entities;

namespace Movies.Application.Features.Users.AutoMapper
{
    public class UserRequestToEntityProfile : Profile
    {
        public UserRequestToEntityProfile()
        {
            //CreateMap<RegisterUserCommand, UserEntity>();
        }
    }
}
