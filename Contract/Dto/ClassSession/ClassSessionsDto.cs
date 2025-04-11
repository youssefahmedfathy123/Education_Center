using Education_Center_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Dto.ClassSession
{
    public class ClassSessionsDto
    {
        public int? Schedule_id { get; set; }  
        public Status_ClassSessions Status { get; set; }
        public DateTime? Date { get; set; } 

    }
}

