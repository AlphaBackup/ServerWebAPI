using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    [Table("stats")]
    public class Stats
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("backupFileAmount")]
        public int BackupFileAmount { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("state")]
        public string State { get; set; }

        [Column("group_id")]
        public virtual Group Group { get; set; }

        [Column("user_id")]
        public virtual User User { get; set; }
    }
}