using System.ComponentModel.DataAnnotations;

namespace Soleup.API.Models
{
    public class PostType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}