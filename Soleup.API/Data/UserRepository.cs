using Microsoft.EntityFrameworkCore;
using Soleup.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Soleup.API.Data
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;
        public UserRepository(DataContext context)
        {
            this._context = context;
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
    }
}
