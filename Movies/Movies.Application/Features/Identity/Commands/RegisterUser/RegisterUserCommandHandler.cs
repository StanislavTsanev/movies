using AutoMapper;
using Movies.Application.Common.Interfaces;
using Movies.Application.Common.Models.Mediatr;
using Movies.Application.Features.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Features.Users.Commands.RegisterUserCommand
{
    public class RegisterUserCommandHandler : BaseRequestHandler<RegisterUserCommand, IUser>
    {
        private readonly IIdentity _identity;

        public RegisterUserCommandHandler(IData data, IMapper mapper, IIdentity identity)
            : base(data, mapper)
        {
            _identity = identity;
        }

        public override async Task<IUser> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _identity.Register(request);
        }
    }
}
