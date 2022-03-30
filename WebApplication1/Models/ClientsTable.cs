using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("clients")]
    public class ClientsTable
    {
        [Column("id")]
        public int Id { get; }

        [Column("name")]
        public string Name { get; set; }

        [Column("activated")]
        public int Activated { get; set; }

        [Column("ip_address")]
        public string Ip { get; set; }

        [Column("mac_adress")]
        public string MacAddress { get; set; }
    }
}
