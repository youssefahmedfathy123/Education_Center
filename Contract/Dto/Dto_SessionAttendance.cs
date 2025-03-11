using Education_Center_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Dto
{
    public class Dto_SessionAttendance
    {
        public int Session_id { get; set; } // (FK → ClassSessions.id)
        public string Student_id { get; set; }  // (FK → Users.id, Only Students)
        public string recorded_by { get; set; }   // (FK → Users.id, Manager or Teacher)
        public string Status { get; set; }

    }
}

