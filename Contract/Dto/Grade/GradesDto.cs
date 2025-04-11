using Education_Center_Domain.Entities;
using Education_Center_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Dto.Grade
{
    public class GradesDto
    {
        public string? Student_id { get; set; }
        public int? Subject_id { get; set; }       
        public int? Grade_type_id { get; set; }  
        public decimal _Grade { get; set; }
        public string Comments { get; set; }

    }
}


