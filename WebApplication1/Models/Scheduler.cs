using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [Column("minute")]
        public int Minute { get; set; }

        [Column("hour")]
        public int Hour { get; set; }

        [ForeignKey("setting_id")]
        public virtual Setting BackupSettings { get; set; }
    }
}
