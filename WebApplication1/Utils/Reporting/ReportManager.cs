using CronNET;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Net.Mail;
using WebApplication1.Models;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Utils.Enums;

namespace WebApplication1.Utils
{
    public class ReportManager
    {        
        private MyContext context = new MyContext();

        private CronDaemon cron;

        private SmtpClient smtpClient = new SmtpClient("smtp.office365.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("alphabackup@outlook.cz", "qwertzuiop123"),
            EnableSsl = true,
            UseDefaultCredentials = false,
        };

        public ReportManager(CronDaemon cron)
        {
            this.cron = cron;
        }

        public void Initialize()
        {
            this.cron.Stop();
            this.cron.ClearJobs();

            List<Administrator> administrators = this.context.Administrators.Where(a => a.Name != "Daemon" && a.ReportSettings.Activated == 1).ToList();

            administrators.ToList().ForEach(a =>
            {
                ReportPeriod period = a.ReportSettings.ReportPeriod;
                ReportFormat format = a.ReportSettings.ReportFormat;

                this.cron.AddJob(CronFormatTime(period),
                                  () => SendReport(a.Email, RelevantTimeStatsList(this.context.Stats, period), period, format));
            });

            this.cron.AddJob("0 12,23 * * *", Initialize);

            this.cron.Start();            
        }

        public void SendReport(string email, List<Stats> stats, ReportPeriod period, ReportFormat format)
        {            
            using (ReportFile reportFile = new ReportFile(stats, format))
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.Subject = "Report";
                    mailMessage.From = new MailAddress("alphabackup@outlook.cz");
                    mailMessage.Body = $"This is your {(period == ReportPeriod.DAY ? "Daily" : period == ReportPeriod.WEEK ? "Weekly" : "Monthly")} report.";
                    mailMessage.To.Add(email);                    

                    mailMessage.Attachments.Add(new Attachment(reportFile.FilePath));
                    this.smtpClient.SendMailAsync(mailMessage).Wait();
                };
            };
        }
        
        private List<Stats> RelevantTimeStatsList(DbSet<Stats> stats, ReportPeriod period)
        {
            DateTime dateTime = DateTime.Now;
            dateTime = period == ReportPeriod.DAY 
                ? dateTime.AddDays(-1) : period == ReportPeriod.WEEK 
                ? dateTime.AddDays(-7) 
                : dateTime.AddMonths(-1);

            return stats.Where(x => x.Date > dateTime).ToList();
        }

        private string CronFormatTime(ReportPeriod period)
        {/*
            return period == ReportPeriod.DAY
                ? "0 0 * * *" : period == ReportPeriod.WEEK
                ? "0 0 * * 0"
                : "0 0 1 * *";*/

            return "*/3 * * * *";
        }
    }
}
