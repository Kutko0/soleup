using Microsoft.EntityFrameworkCore;
using Soleup.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if(entity != null) {
                _context.Entry(entity).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();
            }

            // get the user again and check if values has changes and resolve based on that
            entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if(entity.Equals(user)) {
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
    }
}
