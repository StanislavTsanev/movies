using Microsoft.AspNetCore.Mvc;
using Movies.API.Models.BindingModels;
using Movies.Application.Features.Identity.LoginUser;
using Movies.Application.Features.Identity.Queries.Models;
using Movies.Application.Features.Users.Commands.RegisterUserCommand;
using System.Threading.Tasks;

namespace Movies.API.Controllers
{
    public class IdentityController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Register(RegisterUserBindingModel userBm)
        {
            var response = await Mediator.Send(Mapper.Map<RegisterUserCommand>(userBm));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<LoginDto>> Login([FromBody] LoginBindingModel loginBm)
        {
            var response = await Mediator.Send(Mapper.Map<LoginQuery>(loginBm));

            return Ok(response);
        }
    }
}
