using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.DataTransferObjects;
using WebApplication1.Models.Authentication;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Role = "admin")]
    public class DashboardController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        public DashboardInfo Get()
        {
            DateTime weekAgo = DateTime.Now.AddDays(-7);

            int activeUsers = this.context.Users
                .Where(u => u.Activated == 1)
                .Count();
            int totalUsers = this.context.Users.Count();
            int totalGroups = this.context.Groups.Count();
            int backupsThisWeek = this.context.Stats
                .Where(s => s.Date >= weekAgo)
                .Count();
            int backupsToday = this.context.Stats
                .Where(s => s.Date == DateTime.Today)
                .Count();
            int backupsFailed = this.context.Stats
                .Where(s => s.Status == 0)
                .Count();

            return new DashboardInfo
            {
                ActiveUsers = activeUsers,
                TotalUsers = totalUsers,
                TotalGroups = totalGroups,
                BackupsToday = backupsToday,
                BackupsFailed = backupsFailed,
                BackupsThisWeek = backupsThisWeek
            };

        }

    }
}
