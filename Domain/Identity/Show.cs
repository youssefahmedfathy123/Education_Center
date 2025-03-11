using Education_Center_Domain.Entities;
using Education_Center_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Identity
{
    public class Show
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Role { get; set; }
        public int? Branch_id { get; set; }
        public string? Branch_name { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public string Position { get; set; }

    }
}

