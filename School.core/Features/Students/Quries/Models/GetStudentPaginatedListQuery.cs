using MediatR;
using School.core.Features.Students.Quries.Results;
using School.core.Wrapper;
using School.data.Helpers;

namespace School.core.Features.Students.Quries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
        public string Search { get; set; } = string.Empty;
    }
}
