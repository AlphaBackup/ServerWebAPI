using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.DataTransferObjects;
using WebApplication1.Models.Authentication;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Role = "admin")]
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
                    Status = s.Status,
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
                Status = stats.Status,
                GroupName = stats.Group == null ? null : stats.Group.Name,
                UserName = stats.User == null ? null : stats.User.Name
            };
        }

        [HttpPost]
        public Stats Create(Stats client)
        {
            Group g = client.Group == null ? null : this.context.Groups.Find(client.Group.Id);
            User u = client.User == null ? null : this.context.Users.Find(client.User.Id);

            client.Group = g;
            client.User = u;

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
            db.Status = client.Status;

            this.context.SaveChanges();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Stats client = this.context.Stats.Find(id);

            Group g = client.Group == null ? null : this.context.Groups.Find(client.Group.Id);
            User u = client.User == null ? null : this.context.Users.Find(client.User.Id);

            client.Group = g;
            client.User = u;

            try
            {
                this.context.Stats.Remove(client);
                this.context.SaveChanges();
            }
            catch {}
        }
    }
}
