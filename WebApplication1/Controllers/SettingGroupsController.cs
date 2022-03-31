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
    public class SettingGroupsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<SettingGroupsTable> Get()
        {
            return this.context.SettingGroups.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public SettingGroupsTable Get(int id)
        {
            return this.context.SettingGroups.Find(id);
        }

        [HttpPost]
        public SettingGroupsTable Create(SettingGroupsTable client)
        {
            this.context.SettingGroups.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, SettingGroupsTable client)
        {
            SettingGroupsTable db = this.context.SettingGroups.Find(id);

            db.Name = client.Name;
            db.Activated = client.Activated;
            db.BackupType = client.BackupType;
            db.BackupFormat = client.BackupFormat;
            db.BackupLimit = client.BackupLimit;
            db.BackupPackageLimit = client.BackupPackageLimit;

            this.context.SaveChanges();
            //return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            SettingGroupsTable client = this.context.SettingGroups.Find(id);
            this.context.SettingGroups.Remove(client);
            this.context.SaveChanges();
        }
    }
}
