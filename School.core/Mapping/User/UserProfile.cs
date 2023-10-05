using AutoMapper;

namespace School.core.Mapping.User
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserCommandMapping();
            GetUserListMapping();
            GetUserByIdMapping();
            UpdateUserCommandMapping();
        }
    }
}
