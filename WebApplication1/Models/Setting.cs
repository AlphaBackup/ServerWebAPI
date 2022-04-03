using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("setting")]
    public class Setting
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("backup_format")]
        public int BackupFormat { get; set; }

        [Column("backup_limit")]
        public int BackupLimit { get; set; }

        [Column("backup_package_limit")]
        public int BackupPackageLimit { get; set; }

        [Column("backup_type")]
        public int BackupType { get; set; }

        public virtual List<BackupSource> BackupSources { get; set; }
        public virtual List<BackupDestination> BackupDestinations { get; set; }
        public virtual List<Scheduler> Schedulers { get; set; }
    }
}
