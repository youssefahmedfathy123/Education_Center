using Education_Center_Domain.Enum;
using Education_Center_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Entities
{
    public class ClassSchedule : Entity<int>
    {
        public Subject Subject { get; set; }
        public int? Subject_id { get; set; } // (FK → Subjects.id)
        public User User { get; set; }
        public string? Teacher_id { get; set; }  // (FK → Users.id, Only Teachers)
        public Branch Branch { get; set; }
        public int? Branch_id { get; set; }    //  (FK → Branches.id)
        public string Day_of_week { get; set; }
		public TimeSpan Start_time { get; set; }
		public TimeSpan End_time { get; set; }
        public List<ClassSessions>? ClassSessions { get; set; }
    }
}

