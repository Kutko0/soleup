using System.Collections.Generic;
using System.Linq;
using Soleup.API.Data.RepositoryInterfaces;
using Soleup.API.Models;

namespace Soleup.API.Data
{
    public class DropsRepository : IDropsRepository
    {

        private DataContext _context;
        public DropsRepository(DataContext context)
        {
            this._context = context;
        }


        public DropItem AssignDropUserToDropItem(string userToken, DropItem item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DropItem> GetAllDropItems()
        {
            return this._context.DropItems.ToList();
        }

        public IEnumerable<DropUser> GetAllDropUsers()
        {
            return this._context.DropUsers.ToList();
        }

        public IEnumerable<DropUser> GetAllDropUsersThatWonItem()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DropItem> GetAllTakenDropItems()
        {
            return this._context.DropItems.Where(x => x.UserToken != null).ToList();
        }

        public DropItem GetDropItemById(int id)
        {
            return this._context.DropItems.Where(x => x.Id == id).FirstOrDefault();
        }

        public DropUser GetDropUserByEmail(string email)
        {
            return this._context.DropUsers.Where(x => x.Email == email).FirstOrDefault();
        }

        public DropUser GetDropUserByToken(string token)
        {
            return this._context.DropUsers.Where(x => x.Token == token).FirstOrDefault();
        }

        public DropItem InsertDropItem(DropItem item)
        {
            this._context.Add(item);
            this._context.SaveChanges();
            return item;
        }

        public DropUser InsertDropUser(DropUser user)
        {
            this._context.Add(user);
            this._context.SaveChanges();
            return user;
        }

        public bool IsUserEmailInserted(string email)
        {
            var user = this._context.DropUsers.FirstOrDefault(x => x.Email == email);
            if(user != null) {
                return true;
            }
            return false;
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