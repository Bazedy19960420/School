using School.core.Features.User.Queries.Responses;
using School.data.Entities.AuthEntities;

namespace School.core.Mapping.User
{
    public partial class UserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<ApplicationUser, GetUserByIdResponse>();

        }
    }
}
