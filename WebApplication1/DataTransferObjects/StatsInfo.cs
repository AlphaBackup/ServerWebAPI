using System;

namespace WebApplication1.DataTransferObjects
{
    public class StatsInfo
    {
        public int Id { get; set; }

        public int BackupFileAmount { get; set; }

        public DateTime Date { get; set; }

        public string State { get; set; }

        public string UserName { get; set; }

        public string GroupName { get; set; }

    }
}
