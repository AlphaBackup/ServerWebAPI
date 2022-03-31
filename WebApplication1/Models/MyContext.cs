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

        public DbSet<ClientGroups> ClientGroups { get; set; }

        public DbSet<Clients> Clients { get; set; }

        public DbSet<SettingGroups> SettingGroups { get; set; }

        public DbSet<BackupDestinationPath> BackupDestinations { get; set; }

        public DbSet<BackupSourcePath> BackupSources { get; set; }

        public DbSet<Schedulers> Schedulers { get; set; }

        public DbSet<Administrators> Administrators { get; set; }

        public DbSet<AdminSettings> Settings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=3c1_musildavid_db1;user=musildavid;password=Projekt123;SslMode=none");
        }
    }
}
