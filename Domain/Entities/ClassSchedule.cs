using Education_Center_Domain.Enum;
using Education_Center_Domain.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Entities
{
    public class ClassSchedule : Entity<int>
    {
   

        public int? Subject_id { get; set; }
        public Subject Subject { get; set; }
        public string? Teacher_id { get; set; }
        public User User { get; set; }
        public int? Branch_id { get; set; }
        public Branch Branch { get; set; }
        public Days Day_of_week { get; set; }
		public TimeSpan Start_time { get; set; }
		public TimeSpan End_time { get; set; }
        public List<ClassSessions>? ClassSessions { get; set; }
    }
}

