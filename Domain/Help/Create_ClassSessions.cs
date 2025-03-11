using Education_Center_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Help
{
   public class Create_ClassSessions
    {
        public int Schedule_id { get; set; }  // (FK → ClassSchedules.id)
        public Status_ClassSessions Status { get; set; }

    }
}
