using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            DropItem updated = this._context.DropItems.First(x => x.Id == item.Id);
            updated.UserToken = userToken;

            this._context.SaveChanges();
            return updated;
        }

        public async Task<IEnumerable<DropItem>> GetAllDropItems()
        {
            return await this._context.DropItems.ToListAsync();
        }

        public IEnumerable<DropUser> GetAllDropUsers()
        {
            return this._context.DropUsers.ToList();
        }

        public IEnumerable<DropUser> GetAllDropUsersThatWonItem()
        {
            List<DropItem> listOfItemsWithUser = this._context.DropItems.Where(x => x.UserToken != null).ToList();
            List<DropUser> winners = new List<DropUser>();

            foreach (var item in listOfItemsWithUser)
            {
                winners.Add(this._context.DropUsers.FirstOrDefault(x => x.Token == item.UserToken));    
            }

            return winners;
        }

        public IEnumerable<DropItem> GetAllTakenDropItems()
        {
            return this._context.DropItems.Where(x => x.UserToken != null).ToList();
        }

        public async Task<DropItem> GetDropItemById(int id)
        {
            return await this._context.DropItems.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<DropUser> GetDropUserByEmail(string email)
        {
            return await this._context.DropUsers.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<DropUser> GetDropUserByToken(string token)
        {
            return await this._context.DropUsers.FirstOrDefaultAsync(x => x.Token == token);
        }

        public bool HasUserItem(int id)
        {
            var user = this._context.DropUsers.FirstOrDefault(x => x.Id == id);
            return this._context.DropItems.FirstOrDefault(x => x.UserToken == user.Token) != null;
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
            DropItem item = this._context.DropItems.FirstOrDefault(x => x.Id == id);

            if(item == null) {
                return true;
            }

            this._context.DropItems.Remove(item);
            int changes = this._context.SaveChanges();

            if(changes > 0) {
                return true;
            }

            return false;
        }

        public bool RemoveDropUserByEmail(string email)
        {
           DropUser user = this._context.DropUsers.FirstOrDefault(x => x.Email == email);

            if(user == null) {
                return true;
            }

            this._context.DropUsers.Remove(user);
            int changes = this._context.SaveChanges();

            if(changes > 0) {
                return true;
            }

            return false;
        }

        public bool RemoveDropUserById(int id)
        {
            DropUser user = this._context.DropUsers.FirstOrDefault(x => x.Id == id);

            if(user == null) {
                return true;
            }

            this._context.DropUsers.Remove(user);
            int changes = this._context.SaveChanges();

            if(changes > 0) {
                return true;
            }

            return false;
        }

        public bool ResetDropSession()
        {
            this._context.DropItems.RemoveRange(this._context.DropItems);
            this._context.DropUsers.RemoveRange(this._context.DropUsers);
            int changes = this._context.SaveChanges();

            if(changes > 0) {
                return true;
            }
            return false;
        }
    }
}