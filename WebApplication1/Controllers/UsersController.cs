using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<User> Get()
        {
            return this.context.Users.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public User Get(int id)
        {
            return this.context.Users.Find(id);
        }

        [HttpPost]
        public User Create(User user)
        {
            this.context.Users.Add(user);
            this.context.SaveChanges();

            return user;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, User user)
        {
            User db = this.context.Users.Find(id);
            db.Name = user.Name;
            db.Surname = user.Surname;
            db.Age = user.Age;

            this.context.SaveChanges();
            //return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            User user = this.context.Users.Find(id);
            this.context.Users.Remove(user);
            this.context.SaveChanges();
        }
    }
}
