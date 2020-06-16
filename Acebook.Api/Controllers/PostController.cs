using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AcebookApi.Models;


namespace AcebookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly PostContext _context;

        public PostController(PostContext context)
        {
            _context = context;

            if (_context.Posts.Count() == 0)
            {
                _context.Users.Add(new User { Id = 1, UserName = "Glen", FirstName = "Glen", LastName = "The Best", EmailAddress = "dev.outlook@test.ciom" });
                _context.Posts.Add(new Post { Message = "Hi, folks!" , UserId = 1 });
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

        [HttpGet("GetByUserId", Name = "GetPostByUserId")]
        public ActionResult<IList<Post>> GetByUserId(long id)
        {
            var item = _context.Posts.Where(i => i.UserId == id).ToList();
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }


        [HttpDelete("{id}")]
        public ActionResult<Post> DeleteById(long id)
        {


            var item = _context.Posts.Find(id);

            if(item == null)
            {
                return StatusCode(404);
            }
           
            _context.Posts.Remove(item);
            _context.SaveChanges();
            return StatusCode(200);

        }

        [HttpPut("{id}")]
        public ActionResult<Post> UpdateCommentByUserId(long id, string message)
        {
            var entry = _context.Posts.Find(id);

            if(entry == null)
            {
                return StatusCode(404);
            }

            entry.Message = message;
            _context.SaveChanges();



            return entry;
        }

        public IActionResult postView()
        {
            return View("UserPosts");
        }

    }
}
