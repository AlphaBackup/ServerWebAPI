using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{

    [Table("tbUzivatele")]
    public class User
    {
        public int Id { get; set; }

        [Column("Nejm")]
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        // Foreign key
        public virtual List<Contact> Contacts { get; set; }
    }
}
