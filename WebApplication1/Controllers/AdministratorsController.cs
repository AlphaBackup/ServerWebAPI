using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<Administrator> Get()
        {
            return this.context.Administrators.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Administrator Get(int id)
        {
            return this.context.Administrators.Find(id);
        }

        [HttpPost]
        public Administrator Create(Administrator client)
        {
            this.context.Administrators.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public Administrator Update(int id, Administrator client)
        {
            Administrator db = this.context.Administrators.Find(id);

            db.Name = client.Name;
            db.Password = client.Password;
            db.Email = client.Email;

            this.context.SaveChanges();

            return db;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Administrator client = this.context.Administrators.Find(id);
            this.context.Administrators.Remove(client);
            this.context.SaveChanges();
        }
    }
}
