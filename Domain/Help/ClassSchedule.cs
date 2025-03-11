using Education_Center_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Help
{
    public class ClassSchedule
    {
        public string? Subject_name { get; set; } // (FK → Subjects.id)
        public int? Branch_id { get; set; }    //  (FK → Branches.id)
        public Days Day_of_week { get; set; }
        public TimeSpan Start_time { get; set; }
        public TimeSpan End_time { get; set; }

    }
}

