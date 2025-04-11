using Education_Center_Domain.Entities;
using Education_Center_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Dto.StudentSubjects
{
    public class StudentSubjectsCreateDto
    {
        public string? Student_id { get; set; } 
        public int Subject_id { get; set; }
        public int? BranchId { get; set; }
        public string? UserName { get; set; }
    }
}



