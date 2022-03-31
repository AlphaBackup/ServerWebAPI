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
        public List<Clients> Get()
        {
            return this.context.Clients.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Clients Get(int id)
        {
            return this.context.Clients.Find(id);
        }

        [HttpPost]
        public Clients Create(Clients client)
        {
            this.context.Clients.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, Clients client)
        {
            Clients db = this.context.Clients.Find(id);

            db.Name = client.Name;
            db.Activated = client.Activated;
            db.Ip = client.Ip;
            db.MacAddress = client.MacAddress;            

            this.context.SaveChanges();
            //return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Clients client = this.context.Clients.Find(id);
            this.context.Clients.Remove(client);
            this.context.SaveChanges();
        }
    }
}
