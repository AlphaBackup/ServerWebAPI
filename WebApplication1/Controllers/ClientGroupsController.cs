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
        public List<ClientGroupsTable> Get()
        {
            return this.context.ClientGroups.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public ClientGroupsTable Get(int id)
        {
            return this.context.ClientGroups.Find(id);
        }

        [HttpPost]
        public ClientGroupsTable Create(ClientGroupsTable client)
        {
            this.context.ClientGroups.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, ClientGroupsTable client)
        {
            ClientGroupsTable db = this.context.ClientGroups.Find(id);

            db.ClientId = client.ClientId;
            db.SettingGroupId = client.SettingGroupId;

            this.context.SaveChanges();
            //return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            ClientGroupsTable client = this.context.ClientGroups.Find(id);
            this.context.ClientGroups.Remove(client);
            this.context.SaveChanges();
        }
    }
}
