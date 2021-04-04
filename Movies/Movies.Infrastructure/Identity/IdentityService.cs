using Microsoft.AspNetCore.Identity;
using Movies.Application.Common.Exceptions;
using Movies.Application.Features.Identity;
using Movies.Application.Features.Identity.LoginUser;
using Movies.Application.Features.Identity.Queries.Models;
using Movies.Application.Features.Users;
using Movies.Application.Features.Users.Commands.RegisterUserCommand;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Identity
{
    public class IdentityService : IIdentity
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public IdentityService(UserManager<UserEntity> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<IUser> Register(RegisterUserCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.Password))
                throw new ValidationException("Password is required.");

            if (_userManager.Users.Any(x => x.UserName == request.UserName))
                throw new ValidationException("Username already taken.");

            if (_userManager.Users.Any(x => x.Email == request.Email))
                throw new ValidationException("Email already taken.");

            var user = new UserEntity();
            user.UserName = request.UserName;
            user.Email = request.Email;

            await _userManager.CreateAsync(user, request.Password);

            return user;
        }

        public async Task<LoginDto> Login(LoginQuery request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return null;
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!passwordValid)
            {
                return null;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new LoginDto { Token = token };
        }

    }
}
