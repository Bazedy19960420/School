using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using School.core.Bases;
using School.core.Features.User.Commands.Models;
using School.data.Entities.AuthEntities;

namespace School.core.Features.User.Commands.Handlers
{
    public class UserHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
    {
        #region fields
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion
        #region constructor
        public UserHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion
        #region methods
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userManager.FindByEmailAsync(request.Email).Result;
            if (user != null)
            {
                return BadRequest<string>("User already exists");
            }
            var userUserName = _userManager.FindByNameAsync(request.UserName).Result;
            if (userUserName != null)
            {
                return BadRequest<string>("User Name already exists");
            }
            var newUser = _mapper.Map<ApplicationUser>(request);
            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (result.Succeeded)
            {
                return Success<string>("User created successfully");
            }
            else
            {
                return BadRequest<string>("User creation failed");
            }

        }
        #endregion


    }
}
