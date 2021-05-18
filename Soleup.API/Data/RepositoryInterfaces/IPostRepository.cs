using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soleup.API.Models;

namespace Soleup.API.Data.RepositoryInterfaces
{
    public interface IPostRepository
    {
        Post InsertNewPost(Post post);
        Task<Post> GetPostById(int id);
        Task<bool> EditPost(Post post);
        Task<Post> DeletePostById(int id);
        Comment InsertNewComment(Comment comment);
        Task<Comment> GetCommentById(int id);
        Task<IEnumerable<Comment>> GetCommentsByPostId(int postid);
        Task<bool> EditComment(Comment comment);
        Task<Comment> DeleteCommentById(int id);

    }
}
