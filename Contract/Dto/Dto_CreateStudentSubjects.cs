using Education_Center_Domain.Entities;
using Education_Center_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Dto
{
    public class Dto_CreateStudentSubjects
    {
        public string Student_id { get; set; } // (FK → Users.id, Only Students)
        public int Subject_id { get; set; }  // (FK → Subjects.id)

    }
}

