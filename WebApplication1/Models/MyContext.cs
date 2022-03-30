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
        public DbSet<User> Users { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<StatsTable> Stats { get; set; }

        public DbSet<ClientGroupsTable> ClientGroups { get; set; }

        public DbSet<ClientsTable> Clients { get; set; }

        public DbSet<SettingGroupsTable> SettingGroups { get; set; }

        public DbSet<BackupDestinationPathTable> BackupDestinations { get; set; }

        public DbSet<BackupSourcePathTable> BackupSources { get; set; }

        public DbSet<SchedulersTable> Schedulers { get; set; }

        public DbSet<AdministratorsTable> Administrators { get; set; }

        public DbSet<SettingsTable> Settings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=3c1_ganzwohltadeas_db1;user=ganzwohltadeas;password=Projekt123;SslMode=none");
        }
    }
}
