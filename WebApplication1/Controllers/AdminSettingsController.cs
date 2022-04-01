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
    public class AdminSettingsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<AdminSettings> Get()
        {
            return this.context.Settings.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public AdminSettings Get(int id)
        {
            return this.context.Settings.Find(id);
        }

        [HttpPost]
        public AdminSettings Create(AdminSettings client)
        {
            this.context.Settings.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, AdminSettings client)
        {
            AdminSettings db = this.context.Settings.Find(id);

            db.Email = client.Email;
            db.Language = client.Language;
            db.Administrator = client.Administrator;

            this.context.SaveChanges();
            //return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            AdminSettings client = this.context.Settings.Find(id);
            this.context.Settings.Remove(client);
            this.context.SaveChanges();
        }
    }
}
