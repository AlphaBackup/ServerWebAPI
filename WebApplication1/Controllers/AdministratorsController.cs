using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.DataTransferObjects;
using WebApplication1.Models;
using WebApplication1.Models.Authentication;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Role = "admin")]
    public class AdministratorsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<AdministratorInfo> Get()
        {
            return this.context.Administrators
                .Select(x => new AdministratorInfo() { Id = x.Id, Name = x.Name, Email = x.Email })
                .ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public AdministratorInfo Get(int id)
        {
            Administrator a = this.context.Administrators.Find(id);

            return new AdministratorInfo() { Id = a.Id, Name = a.Name, Email = a.Email };
        }

        [HttpPost]
        [Route("verify/{id}")]
        public bool Get(int id, Credentials credentials)
        {
            Administrator a = this.context.Administrators.Find(id);

            return credentials.Password == a.Password;
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

            if (client.Name != string.Empty)
            {
                db.Name = client.Name;
            }
            if (client.Password != string.Empty)
            {
                db.Password = client.Password;
            }
            if (client.Email != string.Empty)
            {
                db.Email = client.Email;
            }

            this.context.Administrators.Update(db);
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
