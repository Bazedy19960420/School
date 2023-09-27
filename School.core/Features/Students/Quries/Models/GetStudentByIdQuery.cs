using MediatR;
using School.core.Bases;
using School.core.Features.Students.Quries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.core.Features.Students.Quries.Models
{
    public class GetStudentByIdQuery:IRequest<Response<GetStudentByIdResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
