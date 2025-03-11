using Education_Center_Domain.Enum;
using Education_Center_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Help
{
    public class Create_SessionsAttendance
    {
        public int Session_id { get; set; } // (FK → ClassSessions.id)
        public string Student_UserName { get; set; }  // (FK → Users.id, Only Students)
        public Status_Attendence Status { get; set; }

    }
}

