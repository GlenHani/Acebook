using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AcebookApi.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace AcebookApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly PostContext _context;

        public PostController(PostContext context)
        {
            _context = context;

        }

        [HttpGet]
        public ActionResult<List<Post>> Index()
        {
            ViewBag.Posts = _context.Posts.ToList();
            ViewBag.User = HttpContext.Session.GetString("username");
            return View();
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

        [Route("New")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public void Create()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            var UserId = HttpContext.Session.GetString("UserID");
            var userid  = Convert.ToInt32(UserId);
            string message = Request.Form["message"];


            var post = new Post() {
            Message = message,
            UserId = userid};

            _context.Posts.Add(post);
            _context.SaveChanges();
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
