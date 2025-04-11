using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Entities
{
    public class GradeTypes : Entity<int>
    {
      

        public string Name { get; set; }        // (e.g., “Exam”, “Assignment”, “Participation”)
        public List<Grade> Grades { get; set; }

    }
}

