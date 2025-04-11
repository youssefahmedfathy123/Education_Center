using Education_Center_Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Help
{
    public class DetailedAttendanceInfo_User
    {
        public string SubjectName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishingTime { get; set; }
        public string Day { get; set; }
        public string Status { get; set; }

    }
}

