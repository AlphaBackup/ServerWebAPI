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
    public class BackupSourcePathController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<BackupSourcePath> Get()
        {
            return this.context.BackupSources.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public BackupSourcePath Get(int id)
        {
            return this.context.BackupSources.Find(id);
        }

        [HttpPost]
        public BackupSourcePath Create(BackupSourcePath client)
        {
            this.context.BackupSources.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, BackupSourcePath client)
        {
            BackupSourcePath db = this.context.BackupSources.Find(id);

            db.Name = client.Name;
            db.Path = client.Path;
            db.BackupSettings = client.BackupSettings;            

            this.context.SaveChanges();
            //return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            BackupSourcePath client = this.context.BackupSources.Find(id);
            this.context.BackupSources.Remove(client);
            this.context.SaveChanges();
        }
    }
}
