using Microsoft.AspNetCore.Identity;

namespace School.data.Entities.AuthEntities
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
