using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AcebookApi.Models;

namespace AcebookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostContext _context;

        public PostController(PostContext context)
        {
            _context = context;

            if (_context.Posts.Count() == 0)
            {
                _context.Posts.Add(new Post { Message = "Hi, folks!" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Post>> GetAll()
        {
            return _context.Posts.ToList();
        }

        [HttpGet("{id}", Name = "GetPost")]
        public ActionResult<Post> GetById(long id)
        {
            var item = _context.Posts.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public object Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }
    }
}
