using Education_Center_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Help
{
    public class EnrollAttendance
    {
        public Status_Attendence Status { get; set; }
        public string Student_Email { get; set; }   // (FK → Users.id, Only Students)

    }
}


