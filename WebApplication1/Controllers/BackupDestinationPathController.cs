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
    public class BackupDestinationPathController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<BackupDestinationPath> Get()
        {
            return this.context.BackupDestinations.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public BackupDestinationPath Get(int id)
        {
            return this.context.BackupDestinations.Find(id);
        }

        [HttpPost]
        public BackupDestinationPath Create(BackupDestinationPath client)
        {
            this.context.BackupDestinations.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, BackupDestinationPath client)
        {
            BackupDestinationPath db = this.context.BackupDestinations.Find(id);

            db.Name = client.Name;
            db.Path  = client.Path;            
            db.Type = client.Type;
            db.Ip = client.Ip;
            db.Username = client.Username;
            db.Password = client.Password;            

            this.context.SaveChanges();
            //return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            BackupDestinationPath client = this.context.BackupDestinations.Find(id);
            this.context.BackupDestinations.Remove(client);
            this.context.SaveChanges();
        }
    }
}
