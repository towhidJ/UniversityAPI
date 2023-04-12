using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is Required")]
        public string UserName { get; set; }

        public string Email { get; set; }
        public string FullName { get; set; }

        public string Role { get; set; }
        [Required(ErrorMessage = "Password is Required")]

        public string Password { get; set; }
    }
}
