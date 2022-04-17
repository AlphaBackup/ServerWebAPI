using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("setting")]
    public class Setting
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("activated")]
        public int Activated { get; set; }

        [Column("backupFormat")]
        public int BackupFormat { get; set; }

        [Column("backupLimit")]
        public int BackupLimit { get; set; }

        [Column("backupPackageLimit")]
        public int BackupPackageLimit { get; set; }

        [Column("backupType")]
        public int BackupType { get; set; }

        public virtual List<BackupSource> BackupSources { get; set; }
        public virtual List<BackupDestination> BackupDestinations { get; set; }
        public virtual List<Scheduler> Schedulers { get; set; }
    }
}
