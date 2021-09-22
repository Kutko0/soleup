
using System.ComponentModel.DataAnnotations;

namespace Soleup.API.Models
{
    public class DropItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        public string UserToken { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
    }

}