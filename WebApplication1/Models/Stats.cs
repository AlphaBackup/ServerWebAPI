using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("stats")]
    public class Stats
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("backup_file_amount")]
        public int BackupFileAmount { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("state")]
        public string State { get; set; }

        [ForeignKey("group_id")]
        public virtual Group Group { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }
    }
}
