using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("backup_destination_path")]
    public class BackupDestinationPath
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("path")]
        public string Path { get; set; }
        
        [Column("type")]
        public int Type { get; set; }

        [Column("ip")]
        public string Ip { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [ForeignKey("setting_group_id")]
        public virtual BackupSettings BackupSettings { get; set; }
    }
}
