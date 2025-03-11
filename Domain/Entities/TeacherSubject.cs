using Education_Center_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Entities
{
   public class TeacherSubject : Entity<int>
    {
        public User User { get; set; }
        public string Teacher_id { get; set; } // (FK → Users.id, Only Teachers)
        public Subject Subject { get; set; }
        public int Subject_id { get; set; }  // (FK → Subjects.id)
    }
}

