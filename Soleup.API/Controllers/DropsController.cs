using System.ComponentModel;
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

    }
}