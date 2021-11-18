
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Soleup.API.Models
{
    public class DropAdmin
    {   
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [JsonIgnore]
        public string PasswordHashed { get; set; }
    }

}