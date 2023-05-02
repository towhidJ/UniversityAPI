using Microsoft.AspNetCore.Identity;
using UniversityAPI.Authentication;
using UniversityAPI.Model;

namespace UniversityAPI.Repository
{
    public class AuthRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly StudentDB context;

        public AuthRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, StudentDB context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.context = context;
        }
        public async Task<Response> Register(RegisterModel userModel)
        {
            var userExist = await userManager.FindByEmailAsync(userModel.Email);
            if (userExist != null)
            {
                return new Response { Status = "Error", Message = "User Already Exists" };
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = userModel.Email,
                Fullname = userModel.FullName,
                UserName = userModel.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                return  new Response { Status = "Error", Message = "User Sign up failed" };
            }
            if (userModel.Role == "")
            {
                await userManager.AddToRoleAsync(user, UserRole.User);
            }
            else
            {
                await userManager.AddToRoleAsync(user, userModel.Role);
            }

            return new Response { Status = "Success", Message = "User Create Success"};

        }
    }
}
