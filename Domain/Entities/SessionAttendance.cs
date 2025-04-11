using Education_Center_Domain.Enum;
using Education_Center_Domain.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Education_Center_Domain.Entities
{
    public class SessionAttendance : Entity<int>
    {
       
        public int Session_id { get; set; }
        public ClassSessions ClassSessions { get; set; }
        public string? Student_id { get; set; }
        public string? Recorded_by { get; set; }
        public User User { get; set; }
        public Status_Attendence Status { get; set; }

    }
}

