using Microsoft.AspNetCore.Mvc;
using School.api.Base;
using School.core.Features.Departments.Queries.Models;
using School.data.AppMetaData;

namespace School.api.Controllers
{
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        #region Constructors
        #endregion

        #region DepartmentControllerMethods

        [HttpGet]
        [Route(Router.Departments.GetDepartmentById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetDepartmentByIdQuery(id)));
        }
        #endregion
    }
}
