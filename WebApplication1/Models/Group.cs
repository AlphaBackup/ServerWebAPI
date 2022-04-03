using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("group")]
    public class Group
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("activated")]
        public int Activated { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [ForeignKey("setting_id")]
        public virtual Setting BackupSettings { get; set; }
        
    }
}
