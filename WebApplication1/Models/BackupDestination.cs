using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("backup_destination")]
    public class BackupDestination
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("ip")]
        public string Ip { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("path")]
        public string Path { get; set; }
        
        [Column("type")]
        public int Type { get; set; }
        
        [Column("username")]
        public string Username { get; set; }

        [ForeignKey("setting_id")]
        public virtual Setting BackupSettings { get; set; }
    }
}
