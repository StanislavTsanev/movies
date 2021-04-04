using AutoMapper;
using Movies.Application.Common.Interfaces;
using Movies.Application.Common.Models.Mediatr;
using Movies.Application.Features.Identity.LoginUser;
using Movies.Application.Features.Identity.Queries.Models;
using Movies.Application.Features.Users;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Features.Identity.Queries.LoginUser
{
    public class LoginQueryHandler : BaseRequestHandler<LoginQuery, LoginDto>
    {
        private readonly IIdentity _identity;
        public LoginQueryHandler(IData data, IMapper mapper, IIdentity identity) 
            : base(data, mapper)
        {
            _identity = identity;
        }

        public override Task<LoginDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return _identity.Login(request);
        }
    }
}
