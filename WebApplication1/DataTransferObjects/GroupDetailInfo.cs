using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.DataTransferObjects
{
    public class GroupDetailInfo
    {
        public int Id { get; set; }

        public int Activated { get; set; }

        public string Name { get; set; }

        public Setting? Setting { get; set; }

        public List<UserInGroupInfo> UsersToRemove { get; set; }
        public List<UserInGroupInfo> UsersToAdd { get; set; }

    }
}
