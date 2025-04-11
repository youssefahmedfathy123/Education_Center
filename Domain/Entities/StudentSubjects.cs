using Education_Center_Domain.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Entities
{
    public class StudentSubjects : Entity<int>
    {
        public string UserName { get; set; }
        public int BranchId { get; set; }
        public User User { get; set; }
        public string Student_id { get; set; } 
        public Subject Subject { get; set; }
        public int Subject_id { get; set; }  

    }
}


