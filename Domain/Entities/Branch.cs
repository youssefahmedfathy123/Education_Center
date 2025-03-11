using Education_Center_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Entities
{
    public class Branch : Entity<int>
    {
        public string Name { get; set; }
        public Center Center { get; set; }
        public int CenterId { get; set; }  // (FK → Centers.id)
        public User User { get; set; }
        public string? ManagerId { get; set; }  // (FK → Users.id, Nullable)
        public List<ClassSchedule> ClassSchedules { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<User> Users { get; set; }

    }
}


