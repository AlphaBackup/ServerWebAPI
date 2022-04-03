using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("scheduler")]
    public class Scheduler
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("day_of_month")]
        public int DayOfMonth { get; set; }

        [Column("day_of_week")]
        public int DayOfWeek { get; set; }

        [Column("month")]
        public int Month { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("time")]
        public int Time { get; set; }

        [ForeignKey("setting_id")]
        public virtual Setting BackupSettings { get; set; }
    }
}
