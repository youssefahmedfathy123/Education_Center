using Education_Center_Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Entities
{
   public class Subject : Entity<int>
    {
        

        public SubjectName Name { get; set; }
        public Branch Branch { get; set; }
        public int Branch_id { get; set; }   // (FK → Branches.id)
        public List<ClassSchedule> ClassSchedules { get; set; }
        public List<Grade> Grades { get; set; }
        public List<StudentSubjects> StudentSubjects { get; set; }
        public List<TeacherSubject> TeacherSubjects { get; set; }
    }
}

