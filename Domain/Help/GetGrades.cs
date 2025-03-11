using Education_Center_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Dto
{
    public class GetGrades
    {
        public string Teacher_Name { get; set; }
         public string Subject_Name { get; set; }
        public string Grade_type_Name { get; set; }   
        public decimal _Grade { get; set; }
        public string Comments { get; set; }

    }
}


