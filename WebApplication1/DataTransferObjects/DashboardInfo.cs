using System;

namespace WebApplication1.DataTransferObjects
{
    public class DashboardInfo
    {
        public int ActiveUsers { get; set; }

        public int TotalUsers { get; set; }

        public int TotalGroups { get; set; }

        public int BackupsToday { get; set; }

        public int BackupsThisWeek { get; set; }

        public int BackupsFailed { get; set; }
    }
}
