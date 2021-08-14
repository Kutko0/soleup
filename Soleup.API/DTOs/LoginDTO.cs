using System.ComponentModel.DataAnnotations;

namespace Soleup.API.DTOs
{
    public class LoginDTO
    {
        [Required]
        [MinLength(6, ErrorMessage = "field must be atleast 6 characters")]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Must be email format.")]
        public string email { get; set; }
        public string password { get; set; }
    }
}