using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Movies.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMapper _mapper;
        private IMediator _mediator;

        protected IMapper Mapper => _mapper ??= (_mapper = HttpContext.RequestServices.GetService<IMapper>());

        protected IMediator Mediator => _mediator ??= (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}
