using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.DataTransferObjects;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<StatsInfo> Get()
        {
            return this.context.Stats.Select(
                s => new StatsInfo
                {
                    Id = s.Id,
                    BackupFileAmount = s.BackupFileAmount,
                    Date = s.Date,
                    State = s.State,
                    GroupName = s.Group.Name,
                    UserName = s.User.Name
                }).ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public StatsInfo Get(int id)
        {
            Stats stats = this.context.Stats.Find(id);
            
            return new StatsInfo
            {
                Id = stats.Id,
                BackupFileAmount = stats.BackupFileAmount,
                Date = stats.Date,
                State = stats.State,
                GroupName = stats.Group == null ? null : stats.Group.Name,
                UserName = stats.User == null ? null : stats.User.Name
            };
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
