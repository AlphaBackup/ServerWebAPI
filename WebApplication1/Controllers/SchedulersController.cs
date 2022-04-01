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
    public class SchedulersController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<Schedule> Get()
        {
            return this.context.Schedulers.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Schedule Get(int id)
        {
            return this.context.Schedulers.Find(id);
        }

        [HttpPost]
        public Schedule Create(Schedule client)
        {
            this.context.Schedulers.Add(client);
            this.context.SaveChanges();

            return client;
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, Schedule client)
        {
            Schedule db = this.context.Schedulers.Find(id);

            db.Name = client.Name;
            db.Time = client.Time;
            db.DayOfWeek = client.DayOfWeek;
            db.DayOfMonth = client.DayOfMonth;
            db.Month = client.Month;
            db.BackupSettings = client.BackupSettings;

            this.context.SaveChanges();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Schedule client = this.context.Schedulers.Find(id);
            this.context.Schedulers.Remove(client);
            this.context.SaveChanges();
        }
    }
}
