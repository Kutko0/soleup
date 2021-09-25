using System.Collections.Generic;
using Soleup.API.Models;

namespace Soleup.API.Data.RepositoryInterfaces
{
    public interface IDropsRepository
    {
        IEnumerable<DropItem> GetAllDropItems();
        DropItem GetDropItemById(int id);
        bool RemoveDropItemById(int id);
        DropItem InsertDropItem(DropItem item);
        IEnumerable<DropItem> GetAllTakenDropItems();
        IEnumerable<DropUser> GetAllDropUsers();
        IEnumerable<DropUser> GetAllDropUsersThatWonItem();
        DropUser GetDropUserByEmail(string email);
        DropUser GetDropUserByToken(string token);
        DropUser InsertDropUser(DropUser user);
        DropUser RemoveDropUserById(int id);
        DropUser RemoveDropUserByEmail(string email);
        DropItem AssignDropUserToDropItem(string userToken, DropItem item);
        bool ResetDropSession();
        bool IsUserEmailInserted(string email);
    }
}