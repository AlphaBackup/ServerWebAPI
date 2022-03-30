using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("client_groups")]
    public class ClientGroupsTable
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("client_id")]
        public virtual List<ClientsTable> ClientId { get; set; }

        [Column("setting_group_id")]
        public virtual List<SettingGroupsTable> SettingGroupId { get; set; }
    }
}
