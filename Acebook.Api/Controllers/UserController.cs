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
        public ActionResult<User> SignUp(string Password, string username, string FirstName, string LastName, string EmailAddress)
        {
            var user = _context.Users.SingleOrDefault(c => c.UserName == username);
     
           _context.Users.Add(new User { UserName = username, Password = Password, FirstName = FirstName, LastName = LastName, EmailAddress = EmailAddress });

            _context.SaveChanges();

            return user;
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
