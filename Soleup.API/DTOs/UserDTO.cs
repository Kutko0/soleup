using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Soleup.API.Models;

namespace Soleup.API.DTOs
{
    public class UserDTO
    {
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
            Password = Password + salt;
            //Converting string to bytes and hasing it with Sha512 and then encoding it to string 
            SHA512 shaM = new SHA512Managed();
            string hashedPass = Encoding.UTF8.GetString(shaM.ComputeHash(Encoding.ASCII.GetBytes(this.Password)));

            return new User{
                First_Name = this.First_Name,
                Last_Name = this.Last_Name,
                Nickname = this.Nickname,
                PasswordHashed = hashedPass
            };
        }
    }

    
}