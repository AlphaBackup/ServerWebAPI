using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("setting_groups")]
    public class SettingGroupsTable
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("activated")]
        public int Activated { get; set; }

        [Column("backup_type")]
        public int BackupType { get; set; }

        [Column("backup_format")]
        public int BackupFormat { get; set; }

        [Column("backup_limit")]
        public int BackupLimit { get; set; }

        [Column("backup_package_limit")]
        public int BackupPackageLimit { get; set; }
    }
}
