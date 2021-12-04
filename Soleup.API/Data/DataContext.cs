using Soleup.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Soleup.API.Data

{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        
        public DbSet<DropItem> DropItems {get; set;}
        public DbSet<DropUser> DropUsers {get; set;}
        public DbSet<DropAdmin> DropAdmins {get; set;}
        
    }
}