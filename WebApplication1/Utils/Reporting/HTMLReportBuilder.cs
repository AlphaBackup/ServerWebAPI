using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Utils
{
    public class HTMLReportBuilder
    {
        private StringBuilder stringBuilder = new StringBuilder();

        public HTMLReportBuilder(List<Stats> stats)
        {
            var names = from s in stats
                        group s by s.Group == null
                        ? $"User_{s.User.Name}"
                        : $"Group_{s.Group.Name}"
                        into nms
                        select nms;

            foreach (IGrouping<string, Stats> n in names)
            {
                this.stringBuilder.AppendLine(@$"<div><h4>{n.Key}</h4></div>");
                this.stringBuilder.AppendLine(this.Table(n.ToList()));
            }
        }

        private string Table(List<Stats> stats)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.Row(isHeading: true));

            stats.ForEach(x => sb.AppendLine(this.Row(stat: x)));

            sb.Insert(0, @$"<table>");
            sb.AppendLine(@$"</table>");

            return sb.ToString();
        }

        private string Row(Stats stat = null, bool isHeading = false)
        {
            StringBuilder sb = new StringBuilder();

            if (isHeading)
            {
                sb.AppendLine(@$"<th>SourceName</th>");
                sb.AppendLine(@$"<th>DestinationName</th>");
                sb.AppendLine(@$"<th>Status</th>");
                sb.AppendLine(@$"<th>State</th>");
                sb.AppendLine(@$"<th>Date</th>");
                return sb.ToString();
            }

            sb.AppendLine(@$"<td>{stat.SourceName}</td>");
            sb.AppendLine(@$"<td>{stat.DestinationName}</td>");
            sb.AppendLine(@$"<td>{(stat.Status == 1 ? "Success" : "Failure")}</td>");
            sb.AppendLine(@$"<td>{stat.State}</td>");
            sb.AppendLine(@$"<td>{stat.Date.ToString("dd/MM/yyyy HH:mm")}</td>");

            sb.Insert(0, @$"<tr>");
            sb.AppendLine(@$"</tr>");

            return sb.ToString();
        }

        public string GetHtml()
        {
            this.stringBuilder.Insert(0, @$"<div class='main'>");
            this.stringBuilder.AppendLine(@$"</div>");

            this.stringBuilder.AppendLine(File.ReadAllText("styles.txt"));

            return this.stringBuilder.ToString();
        }
    }
}
