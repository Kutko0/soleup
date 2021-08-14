using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Soleup.API.Models;

namespace Soleup.API.DTOs
{
    public class UserDTO
    {
        public int Id {get; set;} = -1;

        [Required]
        [MinLength(6, ErrorMessage = "field must be atleast 6 characters")]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Must be email format.")]
        public string Email { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "field must be atleast 4 characters")]
        public string First_Name { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "field must be atleast 4 characters")]
        public string Last_Name { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "field must be atleast 4 characters")]
        public string Nickname { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$", ErrorMessage = "Password must include at least one number and character")]
        public string Password { get; set; }
        
        public User _ConvertToModel() {
            // Adding salt to password string, this needs to be isolated and loaded form somewhere in production
            string salt = "soleupisthebest";
            this.Password = Password + salt;
            //Converting string to bytes and hasing it with Sha512 and then encoding it to string 
            SHA512 shaM = new SHA512Managed();
            string hashedPass = Encoding.UTF8.GetString(shaM.ComputeHash(Encoding.ASCII.GetBytes(this.Password)));

            User model = new User{
                Email = this.Email,
                First_Name = this.First_Name,
                Last_Name = this.Last_Name,
                Nickname = this.Nickname,
                PasswordHashed = hashedPass
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