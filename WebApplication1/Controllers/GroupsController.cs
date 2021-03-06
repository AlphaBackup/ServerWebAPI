using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.DataTransferObjects;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public List<GroupInfo> Get()
        {
            return this.context.Groups.Select(
                g => new GroupInfo
                {
                    Id = g.Id,
                    Activated = g.Activated,
                    UsersCount = g.Users.Count(),
                    Name = g.Name,
                }).ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public GroupDetailInfo Get(int id)
        {
            List<User> users = new List<User>();
            this.context.Users.ToList().ForEach(u => users.Add(u));

            Group group = this.context.Groups.Find(id);

            return new GroupDetailInfo
            {
                Id = group.Id,
                Activated = group.Activated,
                Name = group.Name,
                Setting = group.Setting,
                UsersToRemove = group.Users.Select(
                u => new UserInGroupInfo
                {
                    Id = u.Id,
                    Name = u.Name,
                }).ToList(),
                UsersToAdd = users
                .Where(u => group.Users.All(gu => gu.Id != u.Id))
                .Select(
                u => new UserInGroupInfo
                {
                    Id = u.Id,
                    Name = u.Name,
                }).ToList()
            };

        }

        [HttpPost]
        public GroupInfo Create(Group group)
        {
            //Group group = new Group();
            //group.Name = name;
            this.context.Groups.Add(group);
            this.context.SaveChanges();

            return new GroupInfo
            {
                Id = group.Id,
                Name = group.Name,
                Activated = group.Activated
            };
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id, GroupDetailInfo client)
        {
            List<User> users = new List<User>();
            this.context.Users.ToList().ForEach(u => users.Add(u));

            Group db = this.context.Groups.Find(id);

            db.Setting = client.Setting;
            db.Name = client.Name;
            db.Activated = client.Activated;
            db.Users = users.Where(u => client.UsersToRemove.Any(uInfo => uInfo.Id == u.Id)).ToList();
            
            this.context.SaveChanges();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Group client = this.context.Groups.Find(id);
            this.context.Groups.Remove(client);
            this.context.SaveChanges();
        }
    }
}
