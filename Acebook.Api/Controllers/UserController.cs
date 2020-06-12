using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AcebookApi.Models;
using Acebook.Api.Models;
using System;

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

        [Route("SignUp")]
        [HttpPost]
        public object Create(User user)
        {
            var username = _context.Users.SingleOrDefault(i => i.UserName == user.UserName);

            if (username != null)
            {
                return "User Exits, please another user name";
            }
            else
            {
                var encyrt = new EncrytpionRepository(user.Password).ReturnEncrpyt();
                user.Password = encyrt;
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
        }

        [Route("SignIn")]
        [HttpPost()]
        public object SignIn(string user, string password)
        {
            var username = _context.Users.SingleOrDefault(i => i.UserName == user);
            var db_password = username.Password;
            var doesItMatch = new AuthoRepository();
            var result = doesItMatch.SignInValidation(db_password, password);

            if (username != null && result == true)
            {
                return true;
            }
            else
            {
                return "Indvalid Password or Username";
            }

        }

    }
}
