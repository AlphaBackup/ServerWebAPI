using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Utils;

namespace WebApplication1.Models
{
    [Table("report_settings")]
    public class ReportSettings
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("activated")]
        public int Activated { get; set; } = 0;

        [Column("reportPeriod")]
        public ReportPeriod ReportPeriod { get; set; }

        [ForeignKey("admin_id")]
        public virtual Administrator Administrator { get; set; }
    }
}
