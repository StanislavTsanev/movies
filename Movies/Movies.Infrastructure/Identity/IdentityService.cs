using Microsoft.AspNetCore.Identity;
using Movies.Application.Features.Identity;
using Movies.Application.Features.Identity.LoginUser;
using Movies.Application.Features.Identity.Queries.Models;
using Movies.Application.Features.Users;
using Movies.Application.Features.Users.Commands.RegisterUserCommand;
using System;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Identity
{
    public class IdentityService : IIdentity
    {
        private const string InvalidCredentials = "Invalid credentials.";
        private readonly UserManager<UserEntity> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public IdentityService(UserManager<UserEntity> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<IUser> Register(RegisterUserCommand request)
        {
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
                throw new InvalidOperationException(InvalidCredentials);
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!passwordValid)
            {
                throw new InvalidOperationException(InvalidCredentials);
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new LoginDto { Token = token };
        }

    }
}
