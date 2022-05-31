using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.DataTransferObjects;
using WebApplication1.Models.Authentication;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Role = "admin")]
    public class UsersController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<UserInfo> Get()
        {
            return this.context.Users.Select(
                u => new UserInfo
                {
                    Id = u.Id,
                    Activated = u.Activated,
                    IpAddress = u.IpAddress,
                    Name = u.Name,
                    Status = u.Status
                }).ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public User Get(int id)
        {
            return this.context.Users.Find(id);
        }

        [HttpPost]
        public User Create(User client)
        {
            this.context.Users.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public User Update(int id, User client)
        {
            User db = this.context.Users.Find(id);

            Setting s = this.context.Settings.Find(client.Setting.Id);
            this.context.Settings.Remove(s);

            client.Setting.Id = 0;

            db.Name = client.Name;
            db.Activated = client.Activated;
            db.IpAddress = client.IpAddress;
            db.MacAddress = client.MacAddress;
            db.Setting = client.Setting;

            this.context.SaveChanges();

            return db;
        }

        [HttpPut]
        [Route("activate/{id}")]
        public int Update(int id)
        {
            User db = this.context.Users.Find(id);
            db.Activated = (db.Activated + 1) % 2;

            this.context.Users.Update(db);

            this.context.SaveChanges();

            return db.Activated;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            User client = this.context.Users.Find(id);

            try
            {
                this.context.Users.Remove(client);
                this.context.SaveChanges();
            }
            catch { }            
        }

        [HttpPut]
        [Route("exists")]
        public int UserExists(User u)
        {
            bool result = this.context.Users.Any(x => x.Name == u.Name && u.Id != x.Id);

            return result ? 1 : 0;
        }
    }
}
