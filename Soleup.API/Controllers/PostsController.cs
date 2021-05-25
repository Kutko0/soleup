using Microsoft.AspNetCore.Mvc;
using Soleup.API.Data;
using Soleup.API.Data.RepositoryInterfaces;
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
    public class PostsController : Controller
    {
        private IPostRepository _repo;
        private IUserRepository _repo_user;

        public PostsController(IPostRepository repo, IUserRepository repouser)
        {
            this._repo = repo;
            this._repo_user = repouser;
        }
        
        // 1. CRUD POST - done, 2. CRUD PostTypes - done, 3. Load post with comments, 4. Load posts by last id and limit, 5. CRUD Comments

        [HttpPost]
        [Route("new")]
        public IActionResult PostNewPost(PostDTO postdto)
        {
            // Check for required fields and field constrains
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Some required fields are not filled."} );
            }

            // TODO: Remove after tokens get introduced
            if(!_repo_user.IsUserPresent(postdto.UserId).Result) {
                return BadRequest(new {error = "There is no such user for post creation."} );
            }

            if(!_repo.IsPostType(postdto.Type).Result) {
                return BadRequest(new {error = "Wrong post type."} );
            }

            Post toInsert = postdto._ConvertToModel();
            toInsert = this._repo.InsertNewPost(toInsert);
            if(toInsert != null) {
                return Ok(toInsert);
            }

            return BadRequest(new {error = "Post failed to be saved."} );
        }

        [HttpPost]
        [Route("update")]
        public IActionResult PostUpdatePost(PostDTO postdto)
        {
            // Check for required fields and field constrains
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Some required fields are not filled."} );
            }

            if(!_repo.IsPostType(postdto.Type).Result) {
                return BadRequest(new {error = "Wrong post type."} );
            }

            // TODO: Remove after tokens get introduced
            if(!_repo_user.IsUserPresent(postdto.UserId).Result) {
                return BadRequest(new {error = "There is no such user for post creation."} );
            }

            bool success = _repo.EditPost(postdto._ConvertToModel()).Result;

            if(success) {
                return Ok(new {success = true});
            }

            return BadRequest(new {error = "Failed to update post."} );
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetReadPostById(int id)
        {
            Post post = _repo.GetPostById(id).Result;
            if(post != null) {
                return Ok(post);
            }
            return BadRequest(new {error = "Failed to load post."} );
        }

        [HttpPost]
        [Route("remove/{id}")]
        public IActionResult PostRemovePost(int id)
        {
            Post post = _repo.DeletePostById(id).Result;
            if(post != null) {
                return Ok(new{removed = post});
            }
            return BadRequest(new {error = "Failed to remove post."} );
        }

        [HttpGet]
        [Route("types/all")]
        public IActionResult GetAllPostTypes()
        {
            return Ok(_repo.GetPostTypes().Result);
        }

        [HttpPost]
        [Route("types/new")]
        public IActionResult PostInsertPostType(PostTypeDTO type) {
            PostType saved = _repo.InsertPostType(type._ConvertToModel());
            if(saved != null) {
                return Ok(saved);
            } 
            return BadRequest(new {error = "Failed to insert post type."} );

        }

        [HttpPost]
        [Route("types/remove/{id}")]
        public IActionResult PostRemovePostType(int id)
        {
            bool success = _repo.DeletePostTypeById(id).Result;
            if(success) {
                return Ok(new {success = "Post type deleted."});
            }
            return BadRequest(new {error = "Failed to remove post type."} );
        }

        [HttpPost]
        [Route("comment/remove/{id}")]
        public IActionResult RemoveCommentById(int id){
            bool success = _repo.DeleteCommentById(id).Result;
            if(success) {
                return Ok(new {success = "Comment deleted."});
            }
            return BadRequest(new {error = "Failed to delete comment."} );
        }

        [HttpPost]
        [Route("comment/update/")]
        public IActionResult PostUpdateComment (CommentDTO comment){
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Some required fields are not filled."} );
            }

            bool success = _repo.EditComment(comment._ConvertToModel()).Result;
            if(success) {
                return Ok(new{ success = true});
            }
            return BadRequest(new {error = "Something went wrong with updating."} );

        }

        [HttpGet]
        [Route("comment/user/{id}")]
        public IActionResult GetCommentsByUserId(int id){
            IEnumerable<Comment> comments = _repo.GetCommentsByUserId(id);
            return Ok(comments);
        }

        [HttpGet]
        [Route("comment/{id}")]
        public IActionResult GetCommentById(int id){
            Comment comment = _repo.GetCommentById(id).Result;
            if(comment != null) {
                return Ok(comment);
            }

            return BadRequest(new {error = "Comment was not found, bad id."} );
        }

        [HttpGet]
        [Route("complete/{id}")]
        public IActionResult GetPostWithCommentsById(int id){
            Post post = _repo.GetPostById(id).Result;
            if(post != null) {
                IEnumerable<Comment> comments = _repo.GetCommentsByPostId(post.Id);
                return Ok(new{_post = post, _comments = comments});
            }

            return BadRequest(new {error = "Post was not found, bad id."} );
            
        }

        [HttpPost]
        [Route("comment/new")]
        public IActionResult PostInsertNewComment(CommentDTO comment){
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Some required fields are not filled."} );
            }

            if(!_repo_user.IsUserPresent(comment.UserId).Result) {
                return BadRequest(new {error = "User does not exists."} );
            }

            if(!_repo.IsPostPresent(comment.PostId).Result) {
                return BadRequest(new {error = "Post does not exists."} );
            }

            Comment saved = _repo.InsertNewComment(comment._ConvertToModel());
            if(saved != null) {
                return Ok(saved);
            }

            return BadRequest(new {error = "Problem with saving to db."} );
        }

        
    }
}
