using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Utils;
using WebApplication1.Models.Authentication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Role = "admin")]
    public class ReportSettingsController : ControllerBase
    {
        private MyContext context = new MyContext();

        [HttpGet]
        [Route("activate/{id}")]
        public int GetActivated(int id)
        {
            Administrator administrator = this.context.Administrators.Find(id);

            id = administrator.ReportSettings.Id;

            ReportSettings client = this.context.ReportSettings.Find(id);

            return client.Activated;
        }

        [HttpGet]
        [Route("period/{id}")]
        public int GetReportPeriod(int id)
        {
            Administrator administrator = this.context.Administrators.Find(id);

            id = administrator.ReportSettings.Id;

            ReportSettings client = this.context.ReportSettings.Find(id);

            return (int)client.ReportPeriod;
        }

        [HttpPut]
        [Route("activate/{id}")]
        public int UpdateActivated(int id)
        {
            Administrator administrator = this.context.Administrators.Find(id);

            id = administrator.ReportSettings.Id;

            ReportSettings client = this.context.ReportSettings.Find(id);

            client.Activated = (client.Activated + 1) % 2;

            this.context.ReportSettings.Update(client);
            this.context.SaveChanges();

            return client.Activated;
        }

        [HttpPut]
        [Route("period/{id}")]
        public int UpdatePeriod(int id)
        {
            Administrator administrator = this.context.Administrators.Find(id);

            id = administrator.ReportSettings.Id;

            ReportSettings client = this.context.ReportSettings.Find(id);

            client.ReportPeriod = (ReportPeriod)(((int)client.ReportPeriod + 1) % 3);

            this.context.ReportSettings.Update(client);
            this.context.SaveChanges();

            return (int)client.ReportPeriod;
        }
    }
}
