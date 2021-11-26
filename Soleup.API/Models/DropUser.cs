using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Soleup.API.Models
{
    public class DropUser
    {

        private int _defWonId = -1;
        public int Id { get; set; }
        [Required]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Must be email format.")]
        public string Email { get; set; }
        public string Token { get; set; }
        [Required]
        public string Instagram { get; set; }
        [DefaultValue(-1)]
        public int WonItemId 
        { get
            {
                return _defWonId;
            }
            set
            {
                _defWonId = value;
            } 
        } 
    }
}