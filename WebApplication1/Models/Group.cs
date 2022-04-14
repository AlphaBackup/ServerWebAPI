using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual Setting Setting { get; set; }

        public virtual List<User> Users { get; set; }

    }
}
