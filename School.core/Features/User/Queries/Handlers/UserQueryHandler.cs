using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using School.core.Bases;
using School.core.Features.User.Queries.Models;
using School.core.Features.User.Queries.Responses;
using School.core.Wrapper;
using School.data.Entities.AuthEntities;

namespace School.core.Features.User.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler
        , IRequestHandler<GetUserListQuery, PaginatedResult<GetUserListResponse>>
        , IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        #region fields
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion
        #region constructor
        public UserQueryHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion
        #region methods
        public Task<PaginatedResult<GetUserListResponse>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var result = _mapper.ProjectTo<GetUserListResponse>(users).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {
                return NotFound<GetUserByIdResponse>("User Not Exist");
            }
            var result = _mapper.Map<GetUserByIdResponse>(user);
            return Success(result);

        }
        #endregion

    }
}
