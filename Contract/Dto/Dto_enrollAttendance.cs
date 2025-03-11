using Education_Center_Domain.Enum;
using Education_Center_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Dto
{
    public class Dto_enrollAttendance
    {
        public string Status { get; set; }
        public string Student_id { get; set; }   // (FK → Users.id, Only Students)
        public string Recorded_by { get; set; } // (FK → Users.id, Manager or Teacher)

    }
}

