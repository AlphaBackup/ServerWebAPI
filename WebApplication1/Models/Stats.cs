using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
