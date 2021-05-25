using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Soleup.API.Data.RepositoryInterfaces;
using Soleup.API.Models;

namespace Soleup.API.Data
{
    public class PostRepository : IPostRepository
    {
        private DataContext _context;
        public PostRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<bool> DeleteCommentById(int id)
        {
            Comment comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if ( comment != null) {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }else{
                return false;
            }

            return true;
        }

        public async Task<Post> DeletePostById(int id)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if ( post != null) {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }else{
                return null;
            }

            return post;
        }

        public async Task<bool> DeletePostTypeById(int id)
        {
            PostType type = await _context.PostTypes.FirstOrDefaultAsync(x => x.Id == id);
            if ( type != null) {
                _context.PostTypes.Remove(type);
                await _context.SaveChangesAsync();
            }else{
                return false;
            }

            return true;
        }

        public async Task<bool> EditComment(Comment comment)
        {
            Comment entity = await _context.Comments.FirstOrDefaultAsync(x => x.Id == comment.Id);
            comment.Id = entity.Id;
            comment.UserId = entity.UserId;
            if(entity != null) {
                _context.Entry(entity).CurrentValues.SetValues(comment);
                await _context.SaveChangesAsync();
            }

            if(JsonConvert.SerializeObject(entity).Equals(JsonConvert.SerializeObject(comment))) {
                return true;
            }else{
                return false;
            }
        }

        public async Task<bool> EditPost(Post post)
        {
            Post entity = await _context.Posts.FirstOrDefaultAsync(x => x.Id == post.Id);
            post.Id = entity.Id;
            if(entity != null) {
                _context.Entry(entity).CurrentValues.SetValues(post);
                await _context.SaveChangesAsync();
            }

            if(JsonConvert.SerializeObject(entity).Equals(JsonConvert.SerializeObject(post))) {
                return true;
            }else{
                return false;
            }
        }

        public async Task<PostType> EditPostType(PostType type)
        {
            PostType entity = await _context.PostTypes.FirstOrDefaultAsync(x => x.Id == type.Id);
            type.Id = entity.Id;
            if(entity != null) {
                _context.Entry(entity).CurrentValues.SetValues(type);
                await _context.SaveChangesAsync();
            }

            if(JsonConvert.SerializeObject(entity).Equals(JsonConvert.SerializeObject(type))) {
                return entity;
            }else{
                return null;
            }
        }

        public async Task<Comment> GetCommentById(int id)
        {
            Comment entity = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null) {
                return entity;
            }
            return null;
        }

        public IEnumerable<Comment> GetCommentsByPostId(int postid)
        {
            IEnumerable<Comment> entities = _context.Comments.Where(x => x.PostId == postid);

            return entities;
        }

        public IEnumerable<Comment> GetCommentsByUserId(int userid)
        {
            IEnumerable<Comment> entities =  _context.Comments.Where(x => x.UserId == userid);

            return entities;
        }

        public async Task<IEnumerable<Post>> GetNNumberOfPostsByLastPostId(int lastId = 0, int limit = 20)
        {
            return await _context.Posts.Where(x => x.Id > lastId).Take(limit).ToListAsync();
        }

        public async Task<Post> GetPostById(int id)
        {
            Post entity = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null) {
                return entity;
            }
            return null;
        }

        public async Task<PostType> GetPostTypeById(int id)
        {
            PostType type = await _context.PostTypes.FirstOrDefaultAsync(x => x.Id == id);
            if(type != null) {
                return type;
            }
            return null;
        }


        public async Task<IEnumerable<PostType>> GetPostTypes()
        {
            return await _context.PostTypes.ToListAsync();
        }

        public Comment InsertNewComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();

            if(comment.Id > -1) {
                return comment;
            }else {
                return null;
            }
        }

        public Post InsertNewPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();

            if(post.Id > -1) {
                return post;
            }else {
                return null;
            }
        }

        public PostType InsertPostType(PostType type)
        {
            _context.PostTypes.Add(type);
            _context.SaveChanges();

            if(type.Id > -1) {
                return type;
            }else {
                return null;
            }
        }

        public async Task<bool> IsPostPresent(int id)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);

            if(post != null) {
                return true;
            }
            return false;
        }

        public async Task<bool> IsPostType(int id)
        {
            PostType type = await _context.PostTypes.FirstOrDefaultAsync(x => x.Id == id);

            if(type != null) {
                return true;
            }
            return false;
        }
    }
}
