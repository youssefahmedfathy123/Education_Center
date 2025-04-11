using Education_Center_Domain.Entities;
using Education_Center_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Dto.Subject
{
    public class SubjectCreateDto
    {
        public SubjectName Name { get; set; }
        public int? Branch_id { get; set; }  

    }
}


