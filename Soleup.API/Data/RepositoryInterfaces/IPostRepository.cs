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
        IEnumerable<Comment> GetCommentsByPostId(int postid);
        Task<bool> EditComment(Comment comment);
        Task<bool> DeleteCommentById(int id);
        IEnumerable<Comment> GetCommentsByUserId(int userid);
        PostType InsertPostType(PostType type);
        Task<bool> DeletePostTypeById(int id);
        Task<PostType> EditPostType(PostType type);
        Task<bool> IsPostType(int id);
        Task<bool> IsPostPresent(int id);
        Task<IEnumerable<PostType>> GetPostTypes();
        Task<PostType> GetPostTypeById(int id);
        Task<IEnumerable<Post>> GetNNumberOfPostsByLastPostId(int lastId, int limit);

    }
}
