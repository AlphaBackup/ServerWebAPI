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
    public class AdministratorsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<AdministratorsTable> Get()
        {
            return this.context.Administrators.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public AdministratorsTable Get(int id)
        {
            return this.context.Administrators.Find(id);
        }

        [HttpPost]
        public AdministratorsTable Create(AdministratorsTable client)
        {
            this.context.Administrators.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, AdministratorsTable client)
        {
            AdministratorsTable db = this.context.Administrators.Find(id);

            db.Name = client.Name;
            db.Activated = client.Activated;

            this.context.SaveChanges();
            //return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            AdministratorsTable client = this.context.Administrators.Find(id);
            this.context.Administrators.Remove(client);
            this.context.SaveChanges();
        }
    }
}
