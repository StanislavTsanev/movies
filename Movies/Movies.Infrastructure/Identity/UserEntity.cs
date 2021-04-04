using Microsoft.AspNetCore.Identity;
using Movies.Application.Features.Identity;

namespace Movies.Infrastructure.Identity
{
    public class UserEntity : IdentityUser, IUser
    {
    }
}
