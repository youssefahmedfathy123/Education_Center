using Education_Center_Domain.Enum;
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
        public ClassSchedule ClassSchedule { get; set; }
        public int Schedule_id { get; set; }  // (FK → ClassSchedules.id)
        public DateTime Date { get; set; } = DateTime.Now;
		public string Status { get; set; }
        public List<SessionAttendance> SessionAttendances { get; set; }

    }
}


