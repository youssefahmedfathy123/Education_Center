using Education_Center_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Dto
{
    public class Dto_ClassSessions
    {
        public int Schedule_id { get; set; }  // (FK → ClassSchedules.id)
        public string Status { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

    }
}

