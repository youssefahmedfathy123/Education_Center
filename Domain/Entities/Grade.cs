using Education_Center_Domain.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Entities
{
    public class Grade : Entity<int>
    {
       

        public string? Student_id { get; set; }
        public User User { get; set; }
        public int? Subject_id { get; set; }
        public Subject Subject { get; set; }
        public GradeTypes GradeType { get; set; }
        public int? Grade_type_id { get; set; }   
        public decimal _Grade { get; set; }
        public string Comments { get; set; }

    }
}
