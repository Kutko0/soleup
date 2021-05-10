using Soleup.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Soleup.API.Data

{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
                
        public DbSet<Post> Posts {get; set;}
        public DbSet<User> Users {get; set;}
        
    }
}