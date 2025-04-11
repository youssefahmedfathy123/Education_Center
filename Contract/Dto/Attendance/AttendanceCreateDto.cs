using Education_Center_Domain.Enum;
using Education_Center_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Dto.Attendance
{
    public class AttendanceCreateDto
    {
        public string? Student_id { get; set; }
        public Status_Attendence Status { get; set; }

    }
}

