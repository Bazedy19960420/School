using Microsoft.AspNetCore.Mvc;
using School.api.Base;
using School.core.Features.User.Commands.Models;
using School.core.Features.User.Queries.Models;
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
        [HttpGet]
        [Route(Router.Auth.UserList)]
        public async Task<IActionResult> UserList([FromQuery] GetUserListQuery response)
        {
            var result = await Mediator.Send(response);
            return Ok(result);
        }
        [HttpGet]
        [Route(Router.Auth.UserById)]
        public async Task<IActionResult> UserById([FromRoute] string id)
        {
            var result = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(result);
        }
        [HttpPut]
        [Route(Router.Auth.UpdateUser)]
        public async Task<IActionResult> updateUser([FromBody] UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
        [HttpDelete]
        [Route(Router.Auth.DeleteUser)]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var result = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(result);
        }
        [HttpPut]
        [Route(Router.Auth.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }


    }
}
