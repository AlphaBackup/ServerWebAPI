using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Stats> Stats { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<BackupDestination> BackupDestinations { get; set; }

        public DbSet<BackupSource> BackupSources { get; set; }

        public DbSet<Scheduler> Schedulers { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<ReportSettings> ReportSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=3c1_dudabohdan_db2;user=dudabohdan;password=654321;SslMode=none");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                        .HasMany<User>(g => g.Users)
                        .WithMany(u => u.Groups);

            modelBuilder.Entity<Administrator>().HasOne<ReportSettings>(r => r.ReportSettings);
        }
    }
}
