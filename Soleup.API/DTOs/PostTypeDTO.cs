using System.ComponentModel.DataAnnotations;
using Soleup.API.Models;

namespace Soleup.API.DTOs
{
    public class PostTypeDTO
    {   
        [Required]
        [MinLength(4, ErrorMessage = "Mininmal length for post type is 4.")]
        public string Name { get; set; }

        public PostType _ConvertToModel() {
            PostType type = new PostType{
                Name = this.Name
            };

            return type;
        }
    }
}