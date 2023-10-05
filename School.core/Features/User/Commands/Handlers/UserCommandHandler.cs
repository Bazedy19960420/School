using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using School.core.Bases;
using School.core.Features.User.Commands.Models;
using School.data.Entities.AuthEntities;

namespace School.core.Features.User.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler
        , IRequestHandler<AddUserCommand, Response<string>>
        , IRequestHandler<UpdateUserCommand, Response<string>>
        , IRequestHandler<DeleteUserCommand, Response<string>>
        , IRequestHandler<ChangePasswordCommand, Response<string>>
    {
        #region fields
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion
        #region constructor
        public UserCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
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

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {
                return BadRequest<string>("User does not exists");
            }
            var userMapper = _mapper.Map(request, user);
            var result = await _userManager.UpdateAsync(userMapper);
            if (!result.Succeeded)
            {
                return BadRequest<string>("User update failed");
            }
            return Success<string>("User updated successfully");
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {
                return NotFound<string>("User does not exists");
            }
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest<string>("User deletion failed");
            }
            return Deleted<string>();
        }

        public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {
                return NotFound<string>("User does not exists");
            }
            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassowrd);
            if (result.Succeeded)
            {
                return Success<string>("Password changed successfully");
            }
            return BadRequest<string>("Password change failed");
        }


        #endregion


    }
}
