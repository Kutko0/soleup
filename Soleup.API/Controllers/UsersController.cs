using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soleup.API.Data;
using Soleup.API.DTOs;
using Soleup.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soleup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _repo;
        public UserController(IUserRepository repo) {
            this._repo = repo;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult PostNewUser(UserDTO userdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Some required fields are not filled");
            }

            User user = userdto._ConvertToModel();
            User saved = _repo.InsertNewUser(user);

            if (saved != null)
            {
                return Ok(saved);
            }
            else
            {
                return BadRequest("User has not been saved correctly.");
            }
        }

    }
}
