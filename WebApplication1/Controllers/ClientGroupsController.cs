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
        public List<Group> Get()
        {
            return this.context.Groups.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Group Get(int id)
        {
            return this.context.Groups.Find(id);
        }

        [HttpPost]
        public Group Create(Group client)
        {
            this.context.Groups.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, Group client)
        {
            Group db = this.context.Groups.Find(id);
            db.BackupSettings = client.BackupSettings;            

            this.context.SaveChanges();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Group client = this.context.Groups.Find(id);
            this.context.Groups.Remove(client);
            this.context.SaveChanges();
        }
    }
}
