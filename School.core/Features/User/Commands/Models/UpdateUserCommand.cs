using MediatR;
using School.core.Bases;

namespace School.core.Features.User.Commands.Models
{
    public class UpdateUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
