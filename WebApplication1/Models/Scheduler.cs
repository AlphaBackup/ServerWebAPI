using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    [Table("scheduler")]
    public class Scheduler
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("dayMonth")]
        public string DayMonth { get; set; }

        [Column("dayWeek")]
        public string DayWeek { get; set; }

        [Column("month")]
        public string Month { get; set; }

        [Column("minute")]
        public string Minute { get; set; }

        [Column("hour")]
        public string Hour { get; set; }

        [ForeignKey("setting_id")]
        public virtual Setting BackupSettings { get; set; }
    }
}
