using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Stats> Stats { get; set; }

        public DbSet<Group> ClientGroups { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<BackupSettings> SettingGroups { get; set; }

        public DbSet<BackupDestinationPath> BackupDestinations { get; set; }

        public DbSet<BackupSourcePath> BackupSources { get; set; }

        public DbSet<Schedule> Schedulers { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<AdminSettings> Settings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=3c1_musildavid_db1;user=musildavid;password=Projekt123;SslMode=none");
        }
    }
}
