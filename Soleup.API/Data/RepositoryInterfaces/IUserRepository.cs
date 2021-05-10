using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soleup.API.Models;

namespace Soleup.API.Data
{
    public interface IUserRepository
    {
        User InsertNewUser(User user);
        Task<User> GetUserById(int id);
        Task<bool> EditUserInfo(User user);
        Task<User> DeleteUserById(int id);
    }
}
