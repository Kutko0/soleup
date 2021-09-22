using System.ComponentModel.DataAnnotations;

namespace Soleup.API.Models
{
    public class DropUser
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Must be email format.")]
        public string Email { get; set; }
        public string Token { get; set; }
        public string Instagram { get; set; }
    }
}