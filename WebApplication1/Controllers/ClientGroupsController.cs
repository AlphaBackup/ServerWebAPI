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
    public class ClientGroupsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<ClientGroups> Get()
        {
            return this.context.ClientGroups.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public ClientGroups Get(int id)
        {
            return this.context.ClientGroups.Find(id);
        }

        [HttpPost]
        public ClientGroups Create(ClientGroups client)
        {
            this.context.ClientGroups.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, ClientGroups client)
        {
            ClientGroups db = this.context.ClientGroups.Find(id);

            db.Stats = client.Stats;
            db.Clients = client.Clients;              
            //db.Clients = client.Clients;
            //db.Stats = client.Stats;

            this.context.SaveChanges();
            //return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            ClientGroups client = this.context.ClientGroups.Find(id);
            this.context.ClientGroups.Remove(client);
            this.context.SaveChanges();
        }
    }
}
