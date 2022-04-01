using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("client_groups")]
    public class Group
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [ForeignKey("setting_group_id")]
        public virtual BackupSettings BackupSettings { get; set; }
        public virtual List<Stats> Stats { get; set; }
        public virtual List<Client> Clients { get; set; }
    }
}
