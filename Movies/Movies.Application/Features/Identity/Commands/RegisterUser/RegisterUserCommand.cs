using Movies.Application.Common.Models.Mediatr;
using Movies.Application.Features.Identity;

namespace Movies.Application.Features.Users.Commands.RegisterUserCommand
{
    public class RegisterUserCommand : BaseCommand<IUser>
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
