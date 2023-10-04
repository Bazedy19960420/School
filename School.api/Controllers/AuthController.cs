using Microsoft.AspNetCore.Mvc;
using School.api.Base;
using School.core.Features.User.Commands.Models;
using School.data.AppMetaData;

namespace School.api.Controllers
{
    [ApiController]
    public class AuthController : AppControllerBase
    {
        [HttpPost]
        [Route(Router.Auth.Register)]
        public async Task<IActionResult> Register([FromForm] AddUserCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

    }
}
