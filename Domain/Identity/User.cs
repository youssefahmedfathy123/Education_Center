using Education_Center_Domain.Entities;
using Education_Center_Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Identity
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        public Branch Branch { get; set; }
        public int? Branch_id { get; set; }   //  Forgin Key for Branches Table 
        public List<Attendance> Attendances { get; set; }
        public List<Branch> Branchs { get; set; }
        public List<ClassSchedule> ClassSchedules { get; set; }
        public List<Grade> Grades { get; set; }
        public List<SessionAttendance> SessionAttendances { get; set; }
        public List<StudentSubjects> StudentSubjects { get; set; }
        public List<TeacherSubject> TeacherSubjects { get; set; }


        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }


    }

}

