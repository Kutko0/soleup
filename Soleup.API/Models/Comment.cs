using System;
using System.ComponentModel.DataAnnotations;

namespace Soleup.API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime Created {get; set;}
    }

}