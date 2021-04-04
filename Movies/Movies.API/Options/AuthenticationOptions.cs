using Movies.Application.Common.Interfaces;

namespace Movies.API.Options
{
    public class AuthenticationOptions : IAuthenticationOptions
    {
        public string Secret { get; set; }
    }
}
