using MediatR;
using School.core.Bases;
using School.core.Features.Students.Quries.Results;
using School.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.core.Features.Students.Quries.Models
{
    public class GetStudentListQuery:IRequest<Response<List<GetStudentListResponse>>>
    {

    }
}
