using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("user")]
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
