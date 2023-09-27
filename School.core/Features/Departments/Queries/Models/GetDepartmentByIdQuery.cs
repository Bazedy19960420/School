using MediatR;
using School.core.Bases;
using School.core.Features.Departments.Queries.Results;

namespace School.core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public GetDepartmentByIdQuery(int id)
        {
            Id= id;
        }
    }
}
