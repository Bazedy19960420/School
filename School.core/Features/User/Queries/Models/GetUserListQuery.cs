using MediatR;
using School.core.Features.User.Queries.Responses;
using School.core.Wrapper;

namespace School.core.Features.User.Queries.Models
{
    public class GetUserListQuery : IRequest<PaginatedResult<GetUserListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
