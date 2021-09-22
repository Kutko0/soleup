using System.Collections.Generic;
using Soleup.API.Data.RepositoryInterfaces;
using Soleup.API.Models;

namespace Soleup.API.Data
{
    public class DropsRepository : IDropsRepository
    {
        public DropItem AssignDropUserToDropItem(string userToken, DropItem item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DropItem> GetAllDropItems()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DropUser> GetAllDropUsers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DropUser> GetAllDropUsersThatWonItem()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DropItem> GetAllTakenDropItems()
        {
            throw new System.NotImplementedException();
        }

        public DropItem GetDropItemById(int id)
        {
            throw new System.NotImplementedException();
        }

        public DropUser GetDropUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public DropUser GetDropUserByToken(string token)
        {
            throw new System.NotImplementedException();
        }

        public DropItem InsertDropItem(DropItem item)
        {
            throw new System.NotImplementedException();
        }

        public DropUser InsertDropUser(DropUser user)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveDropItemById(int id)
        {
            throw new System.NotImplementedException();
        }

        public DropUser RemoveDropUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public DropUser RemoveDropUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool ResetDropSession()
        {
            throw new System.NotImplementedException();
        }
    }
}