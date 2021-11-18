using Microsoft.EntityFrameworkCore;
using Soleup.API.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using dotenv.net;

namespace Soleup.API.Data
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;
        private IConfiguration _config;
        public UserRepository(DataContext context, IConfiguration config)
        {
            this._context = context;
            this._config = config;
        }
        public async Task<User> DeleteUserById(int id)
        {
            // get entity from DB and delete it by ID
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if ( user != null) {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }else{
                return null;
            }

            return user;
        }

        public async Task<bool> EditUserInfo(User user)
        {
            // get entity in DB based on parameter Id and update values
            User entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            // needed in order for Id to not be changed in Entry function which results in error
            user.Id = entity.Id;
            if(entity != null) {
                _context.Entry(entity).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();
            }

            // Had to convert to Json object as when compared in raw form it was failing
            if(JsonConvert.SerializeObject(entity).Equals(JsonConvert.SerializeObject(user))) {
                return true;
            }else{
                return false;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User entity = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if(entity != null) {
                return entity;
            }
            return null;

        }

        public async Task<User> GetUserById(int id)
        {
            User entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null) {
                return entity;
            }
            return null;
        }

        public User InsertNewUser(User user)
        {
            // Expected that entity is validated in controller
            _context.Users.Add(user);
            _context.SaveChanges();

            if(user.Id > -1) {
                return user;
            }else {
                return null;
            }
        }

        // Return true if email is in use, false otherwise
        public async Task<bool> IsEmailInUse(string email)
        {
            var IsUsed = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if(IsUsed != null) {
                return true;
            }else {
                return false;
            }
        }

        // Return true if nickname is in use, false otherwise
        public async Task<bool> IsNicknameInUse(string nickname)
        {
            var IsUsed = await _context.Users.FirstOrDefaultAsync(x => x.Nickname == nickname);
            if(IsUsed != null) {
                return true;
            }else {
                return false;
            }
        }

        public async Task<bool> IsUserPresent(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user != null) {
                return true;
            }
            return false;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            bool emailCheck = await this.IsEmailInUse(email);
            bool loggedIn = false;
            if(emailCheck) {
                User entity = await GetUserByEmail(email);
                string generatedPass = this.GetHashedPassword(password);
                loggedIn = generatedPass.Equals(entity.PasswordHashed);
            }

            return loggedIn;
        }


        // HELPER FUNCTIONS
        public string GetHashedPassword(string password) {
            // Getting salt from config
            // TODO: load from env file in future
            string salt = DotEnv.Read()["SALT_PASS"];
            string toHashPassword = password + salt;

            //Converting string to bytes and hasing it with Sha512 and then encoding it to string 
            SHA512 shaM = new SHA512Managed();
            string hashedPass = Encoding.UTF8.GetString(shaM.ComputeHash(Encoding.ASCII.GetBytes(toHashPassword)));
            return hashedPass;
        }
    }
}
