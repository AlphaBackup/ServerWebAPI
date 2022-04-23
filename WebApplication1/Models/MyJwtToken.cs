using System;

namespace WebApplication1.Models
{
    public class MyJwtToken
    {
        public int user_id { get; set; }
        public long exp { get; set;}
    }
}
