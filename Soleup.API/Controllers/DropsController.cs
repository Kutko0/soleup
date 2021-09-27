using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Soleup.API.Data.RepositoryInterfaces;
using Soleup.API.DTOs;
using Soleup.API.Models;

namespace Soleup.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DropsController : ControllerBase
    {
        private IDropsRepository _repo { get; set; }
        private string TOKEN_SALT = "SOLEUP_DROPS_SESH";

        public DropsController(IDropsRepository repo)
        {
            this._repo = repo;
        }

        [HttpPost]
        [Route("user/new")]
        [Description("Inserts new user to drop session")]
        public IActionResult PostInsertNewUser([Description("User model to be inserted")]DropUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Some required fields are not filled."} );
            }

            if(this._repo.IsUserEmailInserted(user.Email)) 
            {
                return BadRequest(new {error = "Email is already in database"} );
            }

            byte[] dataForToken = Encoding.UTF8.GetBytes(user.Email + TOKEN_SALT);

            using (SHA512 shaM = new SHA512Managed())
            {
                user.Token = ToHex(shaM.ComputeHash(dataForToken), false);
            }

            var created = this._repo.InsertDropUser(user);

            return Ok(new ResponseWithObject{ Message = "User created", Item = created});
        }

        [HttpPost]
        [Route("item/new")]
        [Description("Inserts new drop item")]
        public IActionResult PostInsertNewItem([Description("Item model to be inserted")]DropItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Some required fields are not filled."} );
            }

            var created = this._repo.InsertDropItem(item);

            return Ok(new ResponseWithObject{ Message = "Item created", Item = created});
        }

        [HttpGet]
        [Route("item/all")]
        [Description("Gets all drop items")]
        public IActionResult GetAllItems()
        {
            var list = this._repo.GetAllDropItems();
            return Ok(new ResponseWithObject{ Message = "All items returned", Item = list});
        }

        [HttpPost]
        [Route("item/remove/{id}")]
        [Description("Gets all drop items")]
        public IActionResult PostRemoveDropItemById(int id)
        {
            bool removed = this._repo.RemoveDropItemById(id);
            if(!removed) {
                return BadRequest(new ResponseWithObject{ Message = "Item could not be removed", Item = removed});
            }

            return Ok(new ResponseWithObject{ Message = "Item removed", Item = removed});
        }


        [HttpPost]
        [Route("admin/reset/session")]
        [Description("Deletes all items from session, meaning all users and items gets deleted")]
        public IActionResult PostResetSession()
        {
            bool removed = this._repo.ResetDropSession();

            return Ok(new ResponseWithObject{ Message = "Session reseted, DB is clean", Item = removed});
        }

        [HttpPost]
        [Route("user/enroll/{token}")]
        [Description("Checks the validity of the token and returns user's data")]
        public IActionResult PostEnrollToken(string token)
        {
            DropUser user = this._repo.GetDropUserByToken(token);

            if(user != null) {
                return Ok(new ResponseWithObject{ Message = "Token is valid", Item = user});
            }

            return BadRequest(new ResponseWithObject{ Message = "Token is invalid", Item = user});

        }

        [HttpPost]
        [Route("user/remove/{id}")]
        [Description("Removes user based on his ID")]
        public IActionResult PostRemoveUserById(int id)
        {
            bool removed = this._repo.RemoveDropUserById(id);

            if(removed) {
                return Ok(new ResponseWithObject{ Message = "User was removed.", Item = removed});
            }

            return BadRequest(new ResponseWithObject{ Message = "User could not be removed.", Item = removed});

        }




        // HELPER FUNCTIONS
        //-----------------
        private bool SendAnEmailAfterRegistration(string email, string token) {
            return true;
        }

        private string ToHex(byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }

    }
}