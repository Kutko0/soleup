using Microsoft.AspNetCore.Mvc;
using Soleup.API.Data;
using Soleup.API.Data.RepositoryInterfaces;
using Soleup.API.DTOs;
using Soleup.API.Helper;
using Soleup.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soleup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        private IPostRepository _repo;
        private IUserRepository _repo_user;

        public PostsController(IPostRepository repo, IUserRepository repouser)
        {
            this._repo = repo;
            this._repo_user = repouser;
        }
        
        [HttpPost]
        [Route("new")]
        public IActionResult PostNewPost(PostDTO postdto)
        {

            // Check for required fields and field constrains
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Some required fields are not filled."} );
            }
            // Check if user id is correct and user is registered
            if(!_repo_user.IsUserPresent(postdto.UserId).Result) {
                return BadRequest(new {error = "There is no such user for post creation."} );
            }

            Post toInsert = postdto._ConvertToModel();
            toInsert = this._repo.InsertNewPost(toInsert);
            if(toInsert != null) {
                return Ok(toInsert);
            }

            return BadRequest(new {error = "Post failed to be saved."} );
        }
        
    }
}
