using Education_Center_Contract.Interfaces.Education;
using Education_Center_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEducation_crud<Subject> Subjects { get; }
        IEducation_crud<StudentSubjects> StudentSubjects { get; }
        IEducation_crud<Attendance> Attendances { get; }
        IEducation_crud<Grade> Grades { get; }
        IEducation_crud<GradeTypes> GradeTypes { get; }
        IEducation_crud<ClassSchedule> ClassSchedule { get; }
        IEducation_crud<ClassSessions> ClassSessions { get; }
        IEducation_crud<SessionAttendance> SessionAttendance { get; }


        






        Task<int> Complete();

    }
}

