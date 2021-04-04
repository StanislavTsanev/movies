using Movies.Application.Common.Models.Mediatr;
using Movies.Application.Features.Identity.Queries.Models;

namespace Movies.Application.Features.Identity.LoginUser
{
    public class LoginQuery : BaseQuery<LoginDto>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
