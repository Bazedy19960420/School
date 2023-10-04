using MediatR;
using School.core.Bases;

namespace School.core.Features.User.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassowrd { get; set; } = string.Empty;
    }
}
