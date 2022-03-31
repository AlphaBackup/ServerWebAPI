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
    public class SettingsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<SettingsTable> Get()
        {
            return this.context.Settings.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public SettingsTable Get(int id)
        {
            return this.context.Settings.Find(id);
        }

        [HttpPost]
        public SettingsTable Create(SettingsTable client)
        {
            this.context.Settings.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, SettingsTable client)
        {
            SettingsTable db = this.context.Settings.Find(id);

            db.Email = client.Email;
            db.Language = client.Language;

            this.context.SaveChanges();
            //return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            SettingsTable client = this.context.Settings.Find(id);
            this.context.Settings.Remove(client);
            this.context.SaveChanges();
        }
    }
}
