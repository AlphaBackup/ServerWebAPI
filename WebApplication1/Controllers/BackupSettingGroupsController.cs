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
    public class BackupSettingGroupsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<Setting> Get()
        {
            return this.context.Settings.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Setting Get(int id)
        {
            return this.context.Settings.Find(id);
        }

        [HttpPost]
        public Setting Create(Setting client)
        {
            this.context.Settings.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, Setting client)
        {
            Setting db = this.context.Settings.Find(id);

            
            db.BackupType = client.BackupType;
            db.BackupFormat = client.BackupFormat;
            db.BackupLimit = client.BackupLimit;
            db.BackupPackageLimit = client.BackupPackageLimit;

            db.Schedulers = client.Schedulers;
            this.context.SaveChanges();
            //return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Setting client = this.context.Settings.Find(id);
            this.context.Settings.Remove(client);
            this.context.SaveChanges();
        }
    }
}
