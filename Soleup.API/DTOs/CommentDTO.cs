using System;
using System.ComponentModel.DataAnnotations;
using Soleup.API.Models;

namespace Soleup.API.DTOs
{
    public class CommentDTO
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Field must contain a text.")]
        public string Content { get; set; }

        public Comment _ConvertToModel () {
            Comment comment = new Comment{
                PostId = this.PostId,
                UserId = this.UserId,
                Content = this.Content,
                Created = DateTime.Now
            };

            return comment;
        }
    }
}