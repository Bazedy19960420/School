using Microsoft.AspNetCore.Mvc;
using School.api.Base;
using School.core.Features.Students.Commands.Models;
using School.core.Features.Students.Quries.Models;
using School.data.AppMetaData;

namespace School.api.Controllers
{
    [ApiController]
    public class StudentsController : AppControllerBase
    {


        #region Actions
        [HttpGet]
        [Route(Router.Students.GetStudentList)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await Mediator.Send(new GetStudentListQuery());
                return Ok(result);
            }
            catch
            (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route(Router.Students.Paginated)]
        public async Task<IActionResult> Get([FromQuery] GetStudentPaginatedListQuery query)
        {
            try
            {
                var result = await Mediator.Send(query);
                return Ok(result);
            }
            catch
            (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route(Router.Students.GetStudentById)]
        public async Task<IActionResult> Get(int id)
        {

            var result = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(result);


        }
        [HttpPost]
        [Route(Router.Students.Create)]
        public async Task<IActionResult> create([FromBody] AddStudentCommand command)
        {

            var result = await Mediator.Send(command);
            return NewResult(result);
        }
        [HttpPut]
        [Route(Router.Students.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
        {

            var result = await Mediator.Send(command);
            return NewResult(result);

        }
        [HttpDelete]
        [Route(Router.Students.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var result = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(result);

        }
        #endregion

    }
}
