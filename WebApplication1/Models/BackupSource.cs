using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("backup_source")]
    public class BackupSource
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("path")]
        public string Path { get; set; }

        [ForeignKey("setting_id")]
        public virtual Setting BackupSettings { get; set; }
    }
}
