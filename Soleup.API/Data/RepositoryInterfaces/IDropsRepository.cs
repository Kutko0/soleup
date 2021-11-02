using System.Collections.Generic;
using System.Threading.Tasks;
using Soleup.API.Models;

namespace Soleup.API.Data.RepositoryInterfaces
{
    public interface IDropsRepository
    {
        Task<IEnumerable<DropItem>> GetAllDropItems();
        Task<DropItem> GetDropItemById(int id);
        bool RemoveDropItemById(int id);
        DropItem InsertDropItem(DropItem item);
        IEnumerable<DropItem> GetAllTakenDropItems();
        IEnumerable<DropUser> GetAllDropUsers();
        IEnumerable<DropUser> GetAllDropUsersThatWonItem();
        Task<DropUser> GetDropUserByEmail(string email);
        Task<DropUser> GetDropUserByToken(string token);
        DropUser InsertDropUser(DropUser user);
        bool RemoveDropUserById(int id);
        bool RemoveDropUserByEmail(string email);
        DropItem AssignDropUserToDropItem(string userToken, DropItem item);
        bool ResetDropSession();
        bool IsUserEmailInserted(string email);
        bool HasUserItem(int id);
    }
}