using System.Collections.Generic;
using Soleup.API.Helper;

namespace Soleup.API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeOfPost Type { get; set; }
    }

   

}