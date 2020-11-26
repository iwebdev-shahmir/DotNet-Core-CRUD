using myBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBlog.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int Id);
        List<Post> GetAllPost();

        void AddPost(Post post);
        void RemovePost(int Id);
        void UpdatePost(Post post);

        Task<bool> SaveChangeAsync();
    }
}
