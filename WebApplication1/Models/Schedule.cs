using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("schedulers")]
    public class Schedule
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("time")]
        public int Time { get; set; }

        [Column("day_of_week")]
        public int DayOfWeek { get; set; }

        [Column("day_of_month")]
        public int DayOfMonth { get; set; }

        [Column("month")]
        public int Month { get; set; }

        [ForeignKey("setting_group_id")]
        public virtual BackupSettings BackupSettings { get; set; }
    }
}
