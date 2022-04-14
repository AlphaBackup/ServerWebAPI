using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("activated")]
        public int Activated { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("ipAddress")]
        public string IpAddress { get; set; }

        [Column("macAddress")]
        public string MacAddress { get; set; }

        [ForeignKey("setting_id")]       
        public virtual Setting Setting { get; set; }

        public virtual List<Group> Groups { get; set; }

    }
}
