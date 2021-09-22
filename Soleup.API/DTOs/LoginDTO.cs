using System.ComponentModel.DataAnnotations;

namespace Soleup.API.DTOs
{
    public class LoginDTO
    {
        [Required]
        [MinLength(6, ErrorMessage = "field must be atleast 6 characters")]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Must be email format.")]
        public string email { get; set; }
        [MinLength(6, ErrorMessage = "Password must be atleast 6 characters")]
        [RegularExpression("(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$", 
            ErrorMessage = "Password must include 1 upper and 1 lower case letter, number or special digit and be at least 8 digit long.")]
        public string password { get; set; }
    }
}