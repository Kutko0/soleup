using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soleup.API.Data;
using Soleup.API.DTOs;
using Soleup.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Soleup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /* TODO: 
            1. Find a way to check errors first and return message withh all errors,
            so when email and nickname are wrong user does not have to submit two times 
            for two different errors 
            
        */
        private IUserRepository _repo;
        public UserController(IUserRepository repo) {
            this._repo = repo;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult PostNewUser(UserDTO userdto)
        {
            // Check for required fields and field constrains
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Some required fields are not filled"} );
            }
            // Check if email is already used
            if(_repo.IsEmailInUse(userdto.Email).Result){
                return BadRequest(new {error = "Email is already used."});
            }
            // Check if nickname is already used
            if(_repo.IsNicknameInUse(userdto.Nickname).Result){
                return BadRequest(new {error = "Nickname is already used."});
            }

            User user = userdto._ConvertToModel();
            User saved = _repo.InsertNewUser(user);

            if (saved != null)
            {
                return Ok(saved);
            }
            else
            {
                return BadRequest(new {error = "User has not been saved correctly."});
            }
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult PostEditUser(UserDTO userdto)
        {
            // TODO: make it more programmatic and not messy like this, there is no 
            //       structure in this and it takes a long time to write it, there 
            //       is a better way for sure here

            // Getting user in order to compare the values from FE, if they are 
            // the same then the check should not fail
            User current;
            if(userdto.Id == -1) {
                return BadRequest(new {error = "Could not recognize user."});
            }else{
                current = _repo.GetUserById(userdto.Id).Result;
                if(current == null) {
                    return BadRequest(new {error = "Could not recognize user."});
                }
            }

            // Check for required fields and field constrains
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Some required fields are not filled"});
            }
            // Check if email is already used
            if(_repo.IsEmailInUse(userdto.Email).Result &&
                current.Email != userdto.Email){
                return BadRequest(new {error = "Email is already used."});
            }
            // Check if nickname is already used
            if(_repo.IsNicknameInUse(userdto.Nickname).Result &&
                current.Nickname != userdto.Nickname){
                return BadRequest(new {error = "Nickname is already used."});
            }

            User user = userdto._ConvertToModel();
            bool saved = _repo.EditUserInfo(user).Result;

            if (saved == true)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(new {error = "User has not been saved correctly."});
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GerUser(int id)
        {
            User user = _repo.GetUserById(id).Result;

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(new {error = "User has not been found."});
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult PostDeleteUser(int id)
        {
            User saved = _repo.DeleteUserById(id).Result;

            if (saved != null)
            {
                return Ok(saved);
            }
            else
            {
                return BadRequest(new {error = "User has not been deleted correctly."});
            }
        }
    }
}
