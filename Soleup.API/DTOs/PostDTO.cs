using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Soleup.API.Models;

namespace Soleup.API.DTOs
{
    public class PostDTO
    {
        public int Id {get; set;} = -1;
        [Required]
        public int UserId { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "field must be atleast 6 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Type { get; set; }
        
        public Post _ConvertToModel() {
            Post model = new Post{
                Name = this.Name,
                Description = this.Description,
                UserId = this.UserId,
                TypeId = this.Type,
                Created = DateTime.Now
            };

            // required to have id for editting for now, I don't like it, seems messy
            // TODO: Find batter way to edit a user without relying on passing ID, maybe token would help
            if(this.Id > -1) {
                model.Id = this.Id;
            }

            return model;
        }
    }

    
}