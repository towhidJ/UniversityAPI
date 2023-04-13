using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using UniversityAPI.Authentication;
using UniversityAPI.Model;

namespace UniversityAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly StudentDB context;

        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, StudentDB db)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            context = db;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Register([FromBody] RegisterModel userModel)
        {
            var userExist = await userManager.FindByEmailAsync(userModel.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User Already Exists" });
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
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User Sign up failed" });
            }

            if (!await roleManager.RoleExistsAsync(UserRole.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
            }
            if (!await roleManager.RoleExistsAsync(UserRole.User))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRole.User));
            }
            if (userModel.Role=="")
            {
                await userManager.AddToRoleAsync(user, UserRole.User);
            }
            else
            {
                await userManager.AddToRoleAsync(user, userModel.Role);
            }

            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Success", Message = "User Create Success" });

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var user = await Authenticate(login);
            if (user != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var role = userRoles.FirstOrDefault();
                var token = await Generate(user);
                return Ok(new
                {
                    token,
                    User=user.UserName,
                    roles = role
                });
            }
            return Unauthorized("Authentication Falied");
        }

        private async Task<string> Generate(ApplicationUser user)
        {
            
            var userRoles = await userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                

            };
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:configuration["JWT:ValidIssuer"],
                audience:configuration["JWT:ValidAudience"],
                claims:authClaims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
                ); 
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<ApplicationUser> Authenticate(LoginModel login)
        {
            var currentUser = await userManager.FindByNameAsync(login.UserName);
            if (currentUser != null && await userManager.CheckPasswordAsync(currentUser, login.Password))
            {
                return currentUser;
            }

            return null;
        }


        [Authorize(Roles = UserRole.Admin)]
        [HttpGet]
        public ActionResult Get()
        {

            var re = context.DayTB.ToList();
            return Ok(re);
        }
    }
}
