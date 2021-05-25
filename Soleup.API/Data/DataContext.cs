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
        public DbSet<Comment> Comments {get; set;}
        public DbSet<PostType> PostTypes {get; set;}
        
    }
}