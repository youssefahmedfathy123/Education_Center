using Education_Center_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Entities
{
    public class Grade : Entity<int>
    {
        public User User { get; set; }
        public string Student_id  { get; set; }        //  (FK → Users.id, Only Students)
        public string Teacher_id { get; set; }        //   (FK → Users.id, Only Teachers)
        public Subject Subject { get; set; }
        public int Subject_id  { get; set; }       //   (FK → Subjects.id)
        public GradeTypes GradeType { get; set; }
        public int Grade_type_id { get; set; }   // (FK → GradeTypes.id)
        public decimal _Grade { get; set; }
        public string Comments { get; set; }

    }
}
