using Microsoft.AspNetCore.Identity;

namespace UniversityAPI.Authentication
{
    public class ApplicationUser:IdentityUser
    {
        public string Fullname { get; set; }
    }
}
