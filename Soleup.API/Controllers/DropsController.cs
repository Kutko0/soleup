using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using dotenv.net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Soleup.API.Data.RepositoryInterfaces;
using Soleup.API.DTOs;
using Soleup.API.Models;
using Soleup.API.Services;

namespace Soleup.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes="Bearer")]
    public class DropsController : ControllerBase
    {
        private IDropsRepository _repo { get; set; }
        private IConfiguration _config;  
        private string TOKEN_SECRET;
        private string SOLEUP_EMAIL_ADDRESS;
        private static readonly object locker = new Object(); 

        public DropsController(IDropsRepository repo, IConfiguration config)
        {
            this._repo = repo;
            this._config = config;
            this.TOKEN_SECRET = DotEnv.Read()["TOKEN_SECRET"];
            this.SOLEUP_EMAIL_ADDRESS = DotEnv.Read()["SOLEUP_EMAIL_ADDRESS"];
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

            byte[] dataForToken = Encoding.UTF8.GetBytes(user.Email + TOKEN_SECRET);

            using (SHA512 shaM = new SHA512Managed())
            {
                user.Token = ToHex(shaM.ComputeHash(dataForToken), false);
            }

            var created = this._repo.InsertDropUser(user);

            // TODO: finish emails to work on server side
            //SendConfirmationEmail(created.Email, created.Token, created.Instagram);

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
            this.IsAdmin();
            bool removed = this._repo.ResetDropSession();

            return Ok(new ResponseWithObject{ Message = "Session reseted, DB is clean", Item = removed});
        }

        [HttpPost]
        [Route("admin/login")]
        [Description("Logs in an admin in order to perform tasks")]
        public IActionResult PostAdminLogin(string name, string password)
        {
            password = password + DotEnv.Read()["SALT_PASS"];
            SHA512 shaM = new SHA512Managed();
            string hashedPass = Encoding.UTF8.GetString(shaM.ComputeHash(Encoding.ASCII.GetBytes(password)));

            DropAdmin admin = this._repo.DropAdminLogin(name, hashedPass);
            if(admin == null) {
                return BadRequest(new ResponseWithObject{ Message = "Incorrect admin login"});
            }

            AuthTokenService tokenGenerator = new AuthTokenService(this._config);
            string token = tokenGenerator.GenerateSecurityToken(name, true);

            return Ok(new ResponseWithObject{ Message = "Admin logged in succesfully", Item = admin, JwtToken = token});
        }

        [HttpPost]
        [Route("admin/login/initiate")]
        [Description("Used for making initial admin account, afterwards this method will be removed in production")]
        public IActionResult PostAdminLoginMock()
        {
            string password = "!ILoveMyDropsWithDrips74" + DotEnv.Read()["SALT_PASS"];
            SHA512 shaM = new SHA512Managed();
            string hashedPass = Encoding.UTF8.GetString(shaM.ComputeHash(Encoding.ASCII.GetBytes(password)));

            DropAdmin admin = new DropAdmin{
                Name = "admin",
                PasswordHashed = hashedPass
            };
            admin = this._repo.InsertDropAdmin(admin);

            AuthTokenService tokenGenerator = new AuthTokenService(this._config);
            string token = tokenGenerator.GenerateSecurityToken("admin", true);

            return Ok(new ResponseWithObject{ Message = "Admin logged in succesfully", Item = admin});
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
        public IActionResult PostTakeItemByToken(TakeDropItem take)
        {
            lock(locker) {
                DropUser user = this._repo.GetDropUserByToken(take.Token).Result;
                DropItem item = this._repo.GetDropItemById(take.Id).Result;
                DropItem updated;

                if(user == null) {
                    return BadRequest(new ResponseWithObject{ Message = "User token is invalid"});
                }

                if(this._repo.HasUserItem(user.Id)) {
                    return BadRequest(new ResponseWithObject{ Message = "Item taken *wink"});
                }
                
                if(item == null) {
                    return BadRequest(new ResponseWithObject{ Message = "Item id is invalid"});
                }
                
                if(item.UserToken == null) {
                    updated = this._repo.AssignDropUserToDropItem(take.Token, item);
                }else{
                    return BadRequest(new ResponseWithObject{ Message = "Item was already taken."});
                }

                return Ok(new ResponseWithObject{ Message = "Item secured for user with token: " + take.Token, Item = updated});
            }
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

        private bool IsAdmin() {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var UserClaims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            System.Console.WriteLine(UserClaims.FirstOrDefault( x => x.Type.Equals("admin_allowed_in")).Value);

            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                foreach (var item in claims)
                {
                    System.Console.WriteLine(item);
                }
            }

            return true;
        }

    }
}