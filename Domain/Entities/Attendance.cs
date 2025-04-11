using Education_Center_Domain.Enum;
using Education_Center_Domain.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Entities
{
    public class Attendance : Entity<int>
    {
      
        public DateTime Date { get; set; }
        public Status_Attendence Status { get; set; }
        public string Student_id { get; set; }
        public User User { get; set; }
        public string? Recorded_by { get; set; } 

    }
}

