using Education_Center_Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Education_Center_Domain.Entities
{
	public class ClassSessions : Entity<int>
    {
        public int Schedule_id { get; set; }
        public ClassSchedule ClassSchedule { get; set; }
        public DateTime? Date { get; set; } 
		public Status_ClassSessions Status { get; set; }
        public List<SessionAttendance> SessionAttendances { get; set; }

    }
}

