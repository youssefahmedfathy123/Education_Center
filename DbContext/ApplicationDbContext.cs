using Education_Center_Domain.Entities;
using Education_Center_Domain.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Education_Center_DbContext
{
   public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly TestClass testClass;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options, TestClass _testClass) : base(options) {
            testClass = _testClass;
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<StudentSubjects> StudentSubjects { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }
        public DbSet<ClassSessions> ClassSessions { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<GradeTypes> GradeTypes { get; set; }
        public DbSet<SessionAttendance> SessionAttendance { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(testClass);
            base.OnConfiguring(optionsBuilder);
        }



    }

}







