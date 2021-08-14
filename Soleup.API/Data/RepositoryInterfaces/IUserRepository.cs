using System.Threading.Tasks;
using Soleup.API.Models;

namespace Soleup.API.Data
{
    public interface IUserRepository
    {
        User InsertNewUser(User user);
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<bool> EditUserInfo(User user);
        Task<User> DeleteUserById(int id);
        Task<bool> IsEmailInUse(string email);
        Task<bool> IsNicknameInUse(string nickname);
        Task<bool> IsUserPresent(int id);
        Task<bool> LoginUser(string email, string password);
    }
}
