using Education_Center_Domain.Enum;
using Education_Center_Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Entities
{
    public class Attendance : Entity<int>
    {
        public DateTime Date { get; set; } = DateTime.Now;

        public string Status { get; set; }
        public User User { get; set; }
        public string Student_id { get; set; }   // (FK → Users.id, Only Students)
        public string Recorded_by { get; set; } // (FK → Users.id, Manager or Teacher)

    }
}



