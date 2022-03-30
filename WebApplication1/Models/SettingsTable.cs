using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("settings")]
    public class SettingsTable
    {
        [Column("id")]
        public virtual List<AdministratorsTable> Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("language")]
        public string Language { get; set; }
    }
}
