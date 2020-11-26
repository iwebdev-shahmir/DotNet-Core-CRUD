using myBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBlog.Data.Repository
{
    public class Repository : IRepository
    {
        private AppdbContext _ctx;

        public Repository(AppdbContext ctx)
        {
            _ctx = ctx;
        }

        public Post GetPost(int Id)
        {
            return _ctx.Posts.FirstOrDefault(p => p.Id == Id);
        }
        public List<Post> GetAllPost()
        {
            return _ctx.Posts.ToList();
        }

        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
           
        }
        public void RemovePost(int Id)
        {
            _ctx.Posts.Remove(GetPost(Id));
        }
        public void UpdatePost(Post post)
        {
             _ctx.Posts.Update(post);
        }

        public async Task<bool> SaveChangeAsync()
        {
            if (await _ctx.SaveChangesAsync()> 0) {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
