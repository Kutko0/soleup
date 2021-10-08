using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private string SOLEUP_EMAIL_ADDRESS = "soleup@info.sk";
        private readonly object locker = new Object(); 

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

            SendConfirmationEmail(created.Email, created.Token, created.Instagram);

            return Ok(new ResponseWithObject{ Message = "User created", Item = created});
        }

        [HttpGet]
        [Route("user/all")]
        [Description("Gets all drop users")]
        public IActionResult GetAllDropUsers() {
            IEnumerable<DropUser> users = this._repo.GetAllDropUsers();
            return Ok(new ResponseWithObject{Message = "All users returned", Item = users});
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

        [HttpDelete]
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
        [Route("admin/login")]
        [Description("Logs in an admin in order to perform tasks")]
        public IActionResult PostAdminLogin()
        {
            return Ok();
        }

        [HttpPost]
        [Route("user/enroll/{token}")]
        [Description("Checks the validity of the token and returns user's data")]
        public async Task<IActionResult> PostEnrollToken(string token)
        {
            DropUser user = await this._repo.GetDropUserByToken(token);

            if(user != null) {
                return Ok(new ResponseWithObject{ Message = "Token is valid", Item = user});
            }

            return BadRequest(new ResponseWithObject{ Message = "Token is invalid", Item = user});
        }

        [HttpPost]
        [Route("item/take")]
        [Description("Reserves item for user by token")]
        public async Task<IActionResult> PostTakeItemByToken(TakeDropItem take)
        {
            System.Console.WriteLine(take.Token);
            System.Console.WriteLine(take.Id);
            DropUser user = await this._repo.GetDropUserByToken(take.Token);
            DropItem item = await this._repo.GetDropItemById(take.Id);

            if(user == null) {
                return BadRequest(new ResponseWithObject{ Message = "User token is invalid", Item = false});
            }

            if(item == null) {
                return BadRequest(new ResponseWithObject{ Message = "Item id is invalid", Item = false});
            }

            DropItem updated;
            //Concurrency of taking the item
            // TODO: update item props insisde lock 
            lock(locker) {
                System.Threading.Thread.Sleep(10000);
                
                if(item.UserToken == null) {
                    updated = this._repo.AssignDropUserToDropItem(take.Token, item);
                }else{
                    return BadRequest(new ResponseWithObject{ Message = "Item was already taken.", Item = false});
                }
            }

            return Ok(new ResponseWithObject{ Message = "Item secured for user with token: " + take.Token, Item = updated});
            
        }

        [HttpDelete]
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
        private bool SendAnEmailAfterRegistration(string email, string token) 
        {
            return true;
        }

        private string ToHex(byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }

        private void SendConfirmationEmail(string email, string token, string insta_name) 
        {
            // TODO: Use SoleUp's credentials later from env file
            // TODO: Set up trsutworthy server or add it somehow to list in order to not turn 
            //       off less secure apps in GMAIL as that is not permanent solution
            string fromMail = "";
            string password = "";

            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(email));
            mail.From = new MailAddress(fromMail);
            mail.Subject = "Testing the email";

            string Body = "<h1>Testing mail</h1>" + "<br> <p>Token <a href='#'>" + token + "</a>";
            mail.Body = Body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            // needs to be turned on
            // TODO: Put credentils into env file
            // PUT mail and pass here
            smtp.Credentials = new System.Net.NetworkCredential
                (fromMail, password);
            
            try{
                smtp.Send(mail);
            }
            catch(Exception e) {
                System.Console.WriteLine(e.ToString());
            }
        }

    }
}