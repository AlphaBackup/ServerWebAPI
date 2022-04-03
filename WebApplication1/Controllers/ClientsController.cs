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
    public class ClientsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<User> Get()
        {
            return this.context.Clients.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public User Get(int id)
        {
            return this.context.Clients.Find(id);
        }

        [HttpPost]
        public User Create(User client)
        {
            this.context.Clients.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, User client)
        {
            User db = this.context.Clients.Find(id);

            db.Name = client.Name;
            db.Activated = client.Activated;
            db.Ip = client.Ip;
            db.MacAddress = client.MacAddress;
            db.Group = client.Group;

            this.context.SaveChanges();
            //return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            User client = this.context.Clients.Find(id);
            this.context.Clients.Remove(client);
            this.context.SaveChanges();
        }
    }
}
