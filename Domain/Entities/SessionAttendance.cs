using Education_Center_Domain.Enum;
using Education_Center_Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Education_Center_Domain.Entities
{
    public class SessionAttendance : Entity<int>
    {
        public ClassSessions ClassSessions { get; set; }
        public int Session_id { get; set; } // (FK → ClassSessions.id)
        public User User { get; set; }
        public string Student_id { get; set; }  // (FK → Users.id, Only Students)
        public string recorded_by { get; set; }   // (FK → Users.id, Manager or Teacher)
        public string Status { get; set; }

    }
}

