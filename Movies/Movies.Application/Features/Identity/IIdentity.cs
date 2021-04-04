using Movies.Application.Features.Identity;
using Movies.Application.Features.Identity.LoginUser;
using Movies.Application.Features.Identity.Queries.Models;
using Movies.Application.Features.Users.Commands.RegisterUserCommand;
using System.Threading.Tasks;

namespace Movies.Application.Features.Users
{
    public interface IIdentity
    {
        Task<IUser> Register(RegisterUserCommand request);

        Task<LoginDto> Login(LoginQuery request);
    }
}
