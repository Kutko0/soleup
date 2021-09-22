using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Soleup.API.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        [JsonIgnore]
        public string PasswordHashed { get; set; }
        
    }
}