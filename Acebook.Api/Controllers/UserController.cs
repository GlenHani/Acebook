using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AcebookApi.Models;

namespace AcebookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PostContext _context;

        public UserController(PostContext context)
        {
            _context = context;

        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetById(long id)
        {
            var item = _context.Users.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult SignUp()
        {
            string username = Request.Form["username"];
            string emailAddress = Request.Form["emailAddress"];
            string password = Request.Form["password"];
            string firstName = Request.Form["firstName"];
            string lastName = Request.Form["lastName"];

            var user = _context.Users.SingleOrDefault(c => c.UserName == username);
     
           _context.Users.Add(new User { UserName = username, Password = password, FirstName = firstName, LastName = lastName, EmailAddress = emailAddress });

            _context.SaveChanges();

            return RedirectToAction("SignUp", "Home");
        }
        

        //[HttpPost]
        //public object Create(User user)
        //{
        //    _context.Users.Add(user);
        //    _context.SaveChanges();
        //    return user;
        //}
    }
}
