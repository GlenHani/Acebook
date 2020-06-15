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

        [HttpPost]
        public ActionResult SignUp()
        {
            string username = Request.Form["username"];
            string emailAddress = Request.Form["emailAddress"];
            string password = Request.Form["password"];
            string firstName = Request.Form["firstName"];
            string lastName = Request.Form["lastName"];

            var user = new User()
            {
                UserName = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

           var result = _context.Users.FirstOrDefault(c => c.UserName == user.UserName);

            if (result != null)
            {
                return RedirectToAction("Sign_Up", "Home");
            }
            else
            {
                var encyrt = new EncrytpionRepository(user.Password).ReturnEncrpyt();
                user.Password = encyrt;
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Sign_In", "Home");
            }
        }

           

        [HttpPost]
        public IActionResult SignIn()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];


            var user = _context.Users.SingleOrDefault(i => i.UserName == username);
            var db_password = user.Password;
            var doesItMatch = new AuthoRepository();
            var result = doesItMatch.SignInValidation(db_password, password);

            if (username != null && result == true)
            {
                return RedirectToAction("Account", "User");
            }
            else
            {
                return RedirectToAction("Sign_In", "Home");
            }

        }

    }
}
