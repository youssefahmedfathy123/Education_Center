using Education_Center_Domain.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Education_Center_Domain.Entities
{
    public class Branch : Entity<int>
    {
        public string Name { get; set; }
        public int CenterId { get; set; }
        public Center Center { get; set; }
        public string? ManagerId { get; set; }
        public User User { get; set; }
        public List<ClassSchedule> ClassSchedules { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<User> Users { get; set; }

    }
}

