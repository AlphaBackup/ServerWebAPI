using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("clients")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("activated")]
        public int Activated { get; set; }

        [Column("ip_address")]
        public string IpAddress { get; set; }

        [Column("mac_address")]
        public string MacAddress { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [ForeignKey("group_id")]
        public virtual Group Group { get; set; }
    }
}
