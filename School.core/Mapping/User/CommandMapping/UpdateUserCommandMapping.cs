using School.core.Features.User.Commands.Models;
using School.data.Entities.AuthEntities;

namespace School.core.Mapping.User
{
    public partial class UserProfile
    {
        public void UpdateUserCommandMapping()
        {
            CreateMap<UpdateUserCommand, ApplicationUser>();
        }
    }
}
