using MediatR;
using School.core.Bases;

namespace School.core.Features.User.Commands.Models
{
    public class ChangePasswordCommand : IRequest<Response<string>>
    {
        public string Id { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassowrd { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
