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
    public class StatsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<Stats> Get()
        {
            return this.context.Stats.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Stats Get(int id)
        {
            return this.context.Stats.Find(id);
        }

        [HttpPost]
        public Stats Create(Stats client)
        {
            this.context.Stats.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, Stats client)
        {
            Stats db = this.context.Stats.Find(id);

            db.Date = client.Date;
            db.BackupFileAmount = client.BackupFileAmount;
            db.State = client.State;
            db.Group = client.Group;            

            this.context.SaveChanges();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Stats client = this.context.Stats.Find(id);
            this.context.Stats.Remove(client);
            this.context.SaveChanges();
        }
    }
}
