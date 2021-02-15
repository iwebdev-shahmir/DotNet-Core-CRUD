using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myBlog.Data;
using myBlog.Data.Repository;
using myBlog.Models;

namespace myBlog.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }

       public IActionResult Index()
        {
            var allPosts = _repo.GetAllPost();
            return View(allPosts);
        }

        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            return View(new Post());
            else
            {
                var editPost = _repo.GetPost((int)id);
                return View(editPost);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            if (post.Id > 0)
                _repo.UpdatePost(post);
            else
                _repo.AddPost(post);
                
            if (await _repo.SaveChangeAsync())
                    return RedirectToAction("Index");
            else
                    return View(post);  
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
          _repo.RemovePost(id);
          await _repo.SaveChangeAsync();
            return RedirectToAction("Index");
        }
    }
}
